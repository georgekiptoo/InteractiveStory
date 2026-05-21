using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using Story.Engine;
using Story.Model;
using Story.Persistence;

namespace Story.Player.WinForms
{
    public partial class MainForm : Form
    {
        private GameEngine _engine;
        private ImageRepository _images;

        public MainForm()
        {
            InitializeComponent();
            WireUpMenus();
            UpdateMenusEnabled();
        }

        private void WireUpMenus()
        {
            foreach (ToolStripMenuItem topLevel in mainMenu.Items)
            {
                foreach (ToolStripItem item in topLevel.DropDownItems)
                {
                    if (!(item is ToolStripMenuItem menuItem)) continue;

                    string text = (menuItem.Text ?? "").Replace("&", "").ToLowerInvariant();
                    if (text.Contains("deschide")) menuItem.Click += MenuOpen_Click;
                    else if (text.Contains("restart")) menuItem.Click += MenuRestart_Click;
                    else if (text.Contains("salveaza")) menuItem.Click += MenuSaveState_Click;
                    else if (text.Contains("incarca")) menuItem.Click += MenuLoadState_Click;
                    else if (text.Contains("iesire")) menuItem.Click += MenuExit_Click;
                }
            }
        }

        private void MenuOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            try
            {
                var repo = new StoryRepository();
                var loaded = repo.Load(openFileDialog.FileName);

                _engine = new GameEngine(loaded.Story);
                _images = loaded.Images;

                lblTitle.Text = loaded.Story.Title;
                RefreshUI();
                UpdateMenusEnabled();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nu am putut incarca povestea:\n\n" + ex.Message,
                    "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MenuRestart_Click(object sender, EventArgs e)
        {
            if (_engine == null) return;
            if (MessageBox.Show("Sigur vrei sa iei povestea de la inceput?",
                "Restart", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                != DialogResult.Yes) return;
            _engine.Restart();
            RefreshUI();
        }

        private void MenuSaveState_Click(object sender, EventArgs e)
        {
            if (_engine == null) return;
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            try
            {
                var json = JsonConvert.SerializeObject(_engine.State, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(saveFileDialog.FileName, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Salvare esuata:\n\n" + ex.Message,
                    "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MenuLoadState_Click(object sender, EventArgs e)
        {
            if (_engine == null) return;
            var dlg = new OpenFileDialog { Filter = "Salvare stare (*.json)|*.json" };
            if (dlg.ShowDialog() != DialogResult.OK) return;
            try
            {
                var json = File.ReadAllText(dlg.FileName);
                var state = JsonConvert.DeserializeObject<GameState>(json);
                if (state == null) throw new Exception("Fisier invalid.");
                _engine.State.Properties = state.Properties;
                _engine.State.CurrentBlockId = state.CurrentBlockId;
                RefreshUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Incarcare esuata:\n\n" + ex.Message,
                    "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MenuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UpdateMenusEnabled()
        {
            bool hasStory = _engine != null;
            foreach (ToolStripMenuItem topLevel in mainMenu.Items)
            {
                foreach (ToolStripItem item in topLevel.DropDownItems)
                {
                    if (!(item is ToolStripMenuItem menuItem)) continue;
                    string text = (menuItem.Text ?? "").Replace("&", "").ToLowerInvariant();
                    if (text.Contains("restart") || text.Contains("salveaza") || text.Contains("incarca"))
                        menuItem.Enabled = hasStory;
                }
            }
        }

        private void RefreshUI()
        {
            if (_engine == null) return;
            var block = _engine.GetCurrentBlock();
            txtBlockText.Text = block.Text;
            picBackground.Image = !string.IsNullOrEmpty(block.BackgroundImage)
                ? _images?.Get(block.BackgroundImage) : null;
            BuildHud();
            BuildDecisions(block);
        }

        private void BuildHud()
        {
            panelHud.Controls.Clear();
            var visibleProps = _engine.Story.Properties
                .Where(p => p.VisibleInHud)
                .OrderBy(p => p.HudOrder);

            foreach (var prop in visibleProps)
            {
                int value = _engine.State.GetValue(prop.Key);
                var lbl = new Label
                {
                    Text = prop.HudLabel + ": " + value + " / " + prop.Max,
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Margin = new Padding(0, 4, 0, 4)
                };
                panelHud.Controls.Add(lbl);

                var bar = new ProgressBar
                {
                    Minimum = prop.Min,
                    Maximum = prop.Max,
                    Value = Math.Max(prop.Min, Math.Min(prop.Max, value)),
                    Width = panelHud.ClientSize.Width - 20,
                    Height = 16,
                    Margin = new Padding(0, 0, 0, 8)
                };
                panelHud.Controls.Add(bar);
            }
        }

        private void BuildDecisions(StoryBlock block)
        {
            panelDecisions.Controls.Clear();

            if (block.IsEnding)
            {
                panelDecisions.Controls.Add(new Label
                {
                    Text = "--- Sfarsitul povestii ---",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 12, FontStyle.Italic),
                    ForeColor = Color.DarkRed,
                    Margin = new Padding(10)
                });
                return;
            }

            var available = _engine.GetAvailableDecisions();
            if (available.Count == 0)
            {
                panelDecisions.Controls.Add(new Label
                {
                    Text = "(Nu exista decizii disponibile)",
                    AutoSize = true,
                    ForeColor = Color.Gray,
                    Margin = new Padding(10)
                });
                return;
            }

            foreach (var decision in available)
            {
                var btn = new Button
                {
                    Text = decision.Text,
                    Width = panelDecisions.ClientSize.Width - 30,
                    Height = 40,
                    Margin = new Padding(5),
                    Tag = decision,
                    Font = new Font("Segoe UI", 10),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Padding = new Padding(8, 0, 0, 0)
                };

                if (!string.IsNullOrEmpty(decision.IconPath) &&
                    _images != null && _images.Contains(decision.IconPath))
                {
                    btn.Image = _images.Get(decision.IconPath);
                    btn.ImageAlign = ContentAlignment.MiddleLeft;
                    btn.TextAlign = ContentAlignment.MiddleRight;
                }

                btn.Click += DecisionButton_Click;
                panelDecisions.Controls.Add(btn);
            }
        }

        private void DecisionButton_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var decision = (DecisionDefinition)btn.Tag;
            try
            {
                _engine.ApplyDecision(decision);
                RefreshUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la aplicarea deciziei:\n\n" + ex.Message,
                    "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}