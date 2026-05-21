using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Story.Model;
using Story.Persistence;

namespace Story.Editor.WinForms
{
    public partial class EditorMainForm : Form
    {
        private StoryDefinition _story;
        private string _currentFilePath;
        private bool _isDirty;
        private StoryBlock _currentBlock;

        public EditorMainForm()
        {
            InitializeComponent();
            WireUpMenus();
            WireUpTreeView();
            WireUpDecisionButtons();
            UpdateUIState();
        }

        private void WireUpMenus()
        {
            foreach (ToolStripMenuItem topLevel in mainMenu.Items)
            {
                foreach (ToolStripItem item in topLevel.DropDownItems)
                {
                    if (!(item is ToolStripMenuItem menuItem)) continue;
                    string text = (menuItem.Text ?? "").Replace("&", "").ToLowerInvariant();
                    if (text.Contains("poveste noua")) menuItem.Click += MenuNew_Click;
                    else if (text.Contains("deschide")) menuItem.Click += MenuOpen_Click;
                    else if (text.Contains("salveaza ca")) menuItem.Click += MenuSaveAs_Click;
                    else if (text.Contains("salveaza")) menuItem.Click += MenuSave_Click;
                    else if (text.Contains("iesire")) menuItem.Click += MenuExit_Click;
                    else if (text.Contains("adauga bloc")) menuItem.Click += MenuAddBlock_Click;
                    else if (text.Contains("proprietate")) menuItem.Click += MenuAddProperty_Click;
                    else if (text.Contains("sterge")) menuItem.Click += MenuDelete_Click;
                    else if (text.Contains("valideaza")) menuItem.Click += MenuValidate_Click;
                }
            }
        }

        private void WireUpTreeView()
        {
            treeStory.AfterSelect += TreeStory_AfterSelect;
        }

        private void WireUpDecisionButtons()
        {
            btnAddDecision.Click += BtnAddDecision_Click;
            btnEditDecision.Click += BtnEditDecision_Click;
            btnDeleteDecision.Click += BtnDeleteDecision_Click;
        }

        private void MenuNew_Click(object sender, EventArgs e)
        {
            if (!ConfirmDiscardChanges()) return;
            _story = new StoryDefinition { Title = "Poveste noua", StartBlock = "intro" };
            _currentFilePath = null;
            _isDirty = false;
            SetStatus("Poveste noua creata.");
            RefreshTreeView();
            UpdateUIState();
        }

        private void MenuOpen_Click(object sender, EventArgs e)
        {
            if (!ConfirmDiscardChanges()) return;
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            try
            {
                var repo = new StoryRepository();
                var loaded = repo.Load(openFileDialog.FileName);
                _story = loaded.Story;
                _currentFilePath = openFileDialog.FileName;
                _isDirty = false;
                SetStatus("Poveste incarcata: " + Path.GetFileName(_currentFilePath));
                RefreshTreeView();
                UpdateUIState();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nu am putut incarca:\n\n" + ex.Message,
                    "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MenuSave_Click(object sender, EventArgs e)
        {
            if (_story == null) return;
            if (string.IsNullOrEmpty(_currentFilePath)) { MenuSaveAs_Click(sender, e); return; }
            SaveToPath(_currentFilePath);
        }

        private void MenuSaveAs_Click(object sender, EventArgs e)
        {
            if (_story == null) return;
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            SaveToPath(saveFileDialog.FileName);
        }

        private void SaveToPath(string path)
        {
            try
            {
                var repo = new StoryRepository();

                // Construim dictionarul cu imagini — cautam pe Desktop
                var imagePaths = new Dictionary<string, string>();
                foreach (var block in _story.Blocks)
                {
                    if (!string.IsNullOrEmpty(block.BackgroundImage) &&
                        !imagePaths.ContainsKey(block.BackgroundImage))
                    {
                        string fileName = Path.GetFileName(block.BackgroundImage);
                        string desktopPath = Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                            fileName);
                        if (File.Exists(desktopPath))
                            imagePaths[block.BackgroundImage] = desktopPath;
                    }
                }

                repo.Save(path, _story, imagePaths.Count > 0 ? imagePaths : null);
                _currentFilePath = path;
                _isDirty = false;
                SetStatus("Poveste salvata: " + Path.GetFileName(path));
                UpdateUIState();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Salvare esuata:\n\n" + ex.Message,
                    "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MenuExit_Click(object sender, EventArgs e)
        {
            if (!ConfirmDiscardChanges()) return;
            Close();
        }

        private void MenuAddBlock_Click(object sender, EventArgs e)
        {
            if (_story == null) return;
            string newId = GenerateUniqueBlockId("bloc_nou");
            var block = new StoryBlock { Id = newId, Text = "Text nou..." };
            _story.Blocks.Add(block);
            if (_story.Blocks.Count == 1) _story.StartBlock = block.Id;
            MarkDirty();
            RefreshTreeView();
            SelectBlockInTree(block.Id);
            SetStatus("Bloc adaugat: " + block.Id);
        }

        private void MenuAddProperty_Click(object sender, EventArgs e)
        {
            if (_story == null) return;
            string newKey = GenerateUniquePropertyKey("proprietate_noua");
            var prop = new StatePropertyDefinition
            {
                Key = newKey,
                HudLabel = "Proprietate",
                Min = 0,
                Max = 100,
                Initial = 50,
                VisibleInHud = true,
                HudOrder = _story.Properties.Count + 1
            };
            _story.Properties.Add(prop);
            MarkDirty();
            RefreshTreeView();
            SelectPropertyInTree(prop.Key);
            SetStatus("Proprietate adaugata: " + prop.Key);
        }

        private void MenuDelete_Click(object sender, EventArgs e)
        {
            if (_story == null || treeStory.SelectedNode == null) return;
            var tag = treeStory.SelectedNode.Tag as TreeTag;
            if (tag == null) return;
            if (tag.Kind == TreeNodeKind.Block)
            {
                var block = _story.Blocks.FirstOrDefault(b => b.Id == tag.Id);
                if (block == null) return;
                if (MessageBox.Show("Stergi blocul \"" + block.Id + "\"?", "Confirmare",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                _story.Blocks.Remove(block);
                if (_story.StartBlock == block.Id)
                    _story.StartBlock = _story.Blocks.FirstOrDefault()?.Id ?? "";
                MarkDirty(); RefreshTreeView(); ClearEditor();
                SetStatus("Bloc sters.");
            }
            else if (tag.Kind == TreeNodeKind.Property)
            {
                var prop = _story.Properties.FirstOrDefault(p => p.Key == tag.Id);
                if (prop == null) return;
                if (MessageBox.Show("Stergi proprietatea \"" + prop.Key + "\"?", "Confirmare",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                _story.Properties.Remove(prop);
                MarkDirty(); RefreshTreeView(); ClearEditor();
                SetStatus("Proprietate stearsa.");
            }
            else
            {
                MessageBox.Show("Selecteaza un bloc sau o proprietate pentru a sterge.",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void MenuValidate_Click(object sender, EventArgs e)
        {
            if (_story == null) return;
            var validator = new Story.Engine.StoryValidator(_story);
            var errors = validator.Validate();
            if (errors.Count == 0)
            {
                MessageBox.Show("Povestea este valida! Nu s-au gasit erori.",
                    "Validare reusita", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetStatus("Validare: OK");
            }
            else
            {
                string message = "S-au gasit " + errors.Count + " erori:\n\n";
                foreach (var error in errors)
                    message += "- " + error + "\n";
                MessageBox.Show(message, "Erori de validare",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SetStatus("Validare: " + errors.Count + " erori gasite.");
            }
        }

        private void BtnAddDecision_Click(object sender, EventArgs e)
        {
            if (_currentBlock == null)
            {
                MessageBox.Show("Selecteaza intai un bloc din arbore.",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var decision = new DecisionDefinition { Text = "Decizie noua", TargetBlock = "" };
            _currentBlock.Decisions.Add(decision);
            MarkDirty();
            PopulateDecisionsGrid(_currentBlock);
            lblDecisionsTitle.Text = "Decizii (" + _currentBlock.Decisions.Count + ")";
            SetStatus("Decizie adaugata.");
        }

        private void BtnEditDecision_Click(object sender, EventArgs e)
        {
            if (_currentBlock == null) return;
            if (dgvDecisions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecteaza un rand din tabel.",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var row = dgvDecisions.SelectedRows[0];
            var decision = row.Tag as DecisionDefinition;
            if (decision == null) return;
            var blockIds = _story.Blocks.Select(b => b.Id).ToList();
            var propertyKeys = _story.Properties.Select(p => p.Key).ToList();
            using (var dialog = new DecisionEditDialog(decision, blockIds, propertyKeys))
            {
                if (dialog.ShowDialog(this) == DialogResult.OK && dialog.Result != null)
                {
                    decision.Text = dialog.Result.Text;
                    decision.TargetBlock = dialog.Result.TargetBlock;
                    decision.IconPath = dialog.Result.IconPath;
                    decision.Effects = dialog.Result.Effects;
                    decision.Condition = dialog.Result.Condition;
                    MarkDirty();
                    PopulateDecisionsGrid(_currentBlock);
                    SetStatus("Decizie modificata.");
                }
            }
        }

        private void BtnDeleteDecision_Click(object sender, EventArgs e)
        {
            if (_currentBlock == null) return;
            if (dgvDecisions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecteaza un rand din tabel pentru a sterge.",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var row = dgvDecisions.SelectedRows[0];
            var decision = row.Tag as DecisionDefinition;
            if (decision == null) return;
            if (MessageBox.Show("Stergi decizia \"" + decision.Text + "\"?",
                "Confirmare", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            _currentBlock.Decisions.Remove(decision);
            MarkDirty();
            PopulateDecisionsGrid(_currentBlock);
            lblDecisionsTitle.Text = "Decizii (" + _currentBlock.Decisions.Count + ")";
            SetStatus("Decizie stearsa.");
        }

        private void RefreshTreeView()
        {
            treeStory.BeginUpdate();
            try
            {
                treeStory.Nodes.Clear();
                if (_story == null) return;
                var rootNode = new TreeNode("Poveste: " + (_story.Title ?? "(Fara titlu)"))
                { Tag = new TreeTag(TreeNodeKind.Story, null) };
                treeStory.Nodes.Add(rootNode);
                var propsNode = new TreeNode("Proprietati (" + _story.Properties.Count + ")")
                { Tag = new TreeTag(TreeNodeKind.PropertiesFolder, null) };
                rootNode.Nodes.Add(propsNode);
                foreach (var prop in _story.Properties)
                {
                    var propNode = new TreeNode("- " + (prop.Key ?? "(fara cheie)"))
                    { Tag = new TreeTag(TreeNodeKind.Property, prop.Key) };
                    propsNode.Nodes.Add(propNode);
                }
                var blocksNode = new TreeNode("Blocuri (" + _story.Blocks.Count + ")")
                { Tag = new TreeTag(TreeNodeKind.BlocksFolder, null) };
                rootNode.Nodes.Add(blocksNode);
                foreach (var block in _story.Blocks)
                {
                    string label = "- " + (block.Id ?? "(fara id)");
                    if (block.IsEnding) label += " [FINAL]";
                    if (block.Id == _story.StartBlock) label += " [START]";
                    var blockNode = new TreeNode(label)
                    { Tag = new TreeTag(TreeNodeKind.Block, block.Id) };
                    blocksNode.Nodes.Add(blockNode);
                }
                rootNode.Expand();
                propsNode.Expand();
                blocksNode.Expand();
            }
            finally { treeStory.EndUpdate(); }
        }

        private void SelectBlockInTree(string blockId)
        {
            if (treeStory.Nodes.Count == 0) return;
            foreach (TreeNode child in treeStory.Nodes[0].Nodes[1].Nodes)
                if ((child.Tag as TreeTag)?.Id == blockId)
                { treeStory.SelectedNode = child; break; }
        }

        private void SelectPropertyInTree(string propKey)
        {
            if (treeStory.Nodes.Count == 0) return;
            foreach (TreeNode child in treeStory.Nodes[0].Nodes[0].Nodes)
                if ((child.Tag as TreeTag)?.Id == propKey)
                { treeStory.SelectedNode = child; break; }
        }

        private void TreeStory_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var tag = e.Node?.Tag as TreeTag;
            if (tag == null) { ClearEditor(); return; }
            switch (tag.Kind)
            {
                case TreeNodeKind.Story: ShowStoryEditor(); break;
                case TreeNodeKind.Property:
                    var prop = _story.Properties.FirstOrDefault(p => p.Key == tag.Id);
                    if (prop != null) ShowPropertyEditor(prop);
                    break;
                case TreeNodeKind.Block:
                    var block = _story.Blocks.FirstOrDefault(b => b.Id == tag.Id);
                    if (block != null) ShowBlockEditor(block);
                    break;
                default: ClearEditor(); break;
            }
        }

        private void ClearEditor()
        {
            panelEditor.Controls.Clear();
            lblDecisionsTitle.Text = "Decizii";
            dgvDecisions.DataSource = null;
            dgvDecisions.Columns.Clear();
            dgvDecisions.Rows.Clear();
            _currentBlock = null;
        }

        private void ShowStoryEditor()
        {
            ClearEditor();
            int y = 10;
            AddLabel("Titlu poveste:", y); y += 22;
            AddTextBox(_story.Title, y, t => { _story.Title = t; MarkDirty(); RefreshTreeView(); });
            y += 30;
            AddLabel("Bloc de start (id):", y); y += 22;
            AddTextBox(_story.StartBlock, y, t => { _story.StartBlock = t; MarkDirty(); RefreshTreeView(); });
        }

        private void ShowPropertyEditor(StatePropertyDefinition prop)
        {
            ClearEditor();
            int y = 10;
            AddLabel("Cheie (key):", y); y += 22;
            AddTextBox(prop.Key, y, t =>
            {
                prop.Key = t; MarkDirty(); RefreshTreeView(); SelectPropertyInTree(t);
            }); y += 30;
            AddLabel("Eticheta HUD:", y); y += 22;
            AddTextBox(prop.HudLabel, y, t => { prop.HudLabel = t; MarkDirty(); }); y += 30;
            AddLabel("Min:", y); y += 22;
            AddNumeric(prop.Min, y, v => { prop.Min = v; MarkDirty(); }); y += 30;
            AddLabel("Max:", y); y += 22;
            AddNumeric(prop.Max, y, v => { prop.Max = v; MarkDirty(); }); y += 30;
            AddLabel("Valoare initiala:", y); y += 22;
            AddNumeric(prop.Initial, y, v => { prop.Initial = v; MarkDirty(); }); y += 30;
            AddLabel("Ordine in HUD:", y); y += 22;
            AddNumeric(prop.HudOrder, y, v => { prop.HudOrder = v; MarkDirty(); }); y += 30;
            AddCheckBox("Vizibila in HUD", prop.VisibleInHud, y, v => { prop.VisibleInHud = v; MarkDirty(); }); y += 30;
            AddLabel("Bloc la minim (optional):", y); y += 22;
            AddTextBox(prop.OnMinBlock, y, t => { prop.OnMinBlock = t; MarkDirty(); }); y += 30;
            AddLabel("Bloc la maxim (optional):", y); y += 22;
            AddTextBox(prop.OnMaxBlock, y, t => { prop.OnMaxBlock = t; MarkDirty(); });
        }

        private void ShowBlockEditor(StoryBlock block)
        {
            ClearEditor();
            _currentBlock = block;
            int y = 10;
            AddLabel("Id bloc:", y); y += 22;
            AddTextBox(block.Id, y, t =>
            {
                string old = block.Id;
                block.Id = t;
                if (_story.StartBlock == old) _story.StartBlock = t;
                MarkDirty(); RefreshTreeView(); SelectBlockInTree(t);
            }); y += 30;
            AddLabel("Text narativ:", y); y += 22;
            var txtBlock = new TextBox
            {
                Text = block.Text ?? "",
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                Left = 10,
                Top = y,
                Width = panelEditor.ClientSize.Width - 30,
                Height = 150,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            txtBlock.TextChanged += (s, e) => { block.Text = txtBlock.Text; MarkDirty(); };
            panelEditor.Controls.Add(txtBlock);
            y += 160;
            AddLabel("Imagine fundal (optional, cale relativa):", y); y += 22;
            AddTextBox(block.BackgroundImage, y, t => { block.BackgroundImage = t; MarkDirty(); }); y += 30;
            AddCheckBox("Bloc final (ending)", block.IsEnding, y, v =>
            {
                block.IsEnding = v; MarkDirty(); RefreshTreeView();
            });
            lblDecisionsTitle.Text = "Decizii (" + block.Decisions.Count + ")";
            PopulateDecisionsGrid(block);
        }

        private void PopulateDecisionsGrid(StoryBlock block)
        {
            dgvDecisions.DataSource = null;
            dgvDecisions.Columns.Clear();
            dgvDecisions.Rows.Clear();
            dgvDecisions.Columns.Add("colText", "Text");
            dgvDecisions.Columns.Add("colTarget", "Bloc tinta");
            dgvDecisions.Columns.Add("colCondition", "Conditie");
            dgvDecisions.Columns.Add("colEffects", "Efecte");
            foreach (var decision in block.Decisions)
            {
                string conditionText = decision.Condition == null ? "(fara)" : "(setata)";
                string effectsText = decision.Effects.Count == 0
                    ? "(fara)" : decision.Effects.Count.ToString();
                int rowIndex = dgvDecisions.Rows.Add(
                    decision.Text ?? "", decision.TargetBlock ?? "",
                    conditionText, effectsText);
                dgvDecisions.Rows[rowIndex].Tag = decision;
            }
        }

        private void AddLabel(string text, int top)
        {
            var lbl = new Label
            {
                Text = text,
                Left = 10,
                Top = top,
                AutoSize = true,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
            panelEditor.Controls.Add(lbl);
        }

        private TextBox AddTextBox(string value, int top, Action<string> onChange)
        {
            var tb = new TextBox
            {
                Text = value ?? "",
                Left = 10,
                Top = top,
                Width = panelEditor.ClientSize.Width - 30,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            tb.TextChanged += (s, e) => onChange(tb.Text);
            panelEditor.Controls.Add(tb);
            return tb;
        }

        private NumericUpDown AddNumeric(int value, int top, Action<int> onChange)
        {
            var nud = new NumericUpDown
            {
                Minimum = -10000,
                Maximum = 10000,
                Value = Math.Max(-10000, Math.Min(10000, value)),
                Left = 10,
                Top = top,
                Width = 120
            };
            nud.ValueChanged += (s, e) => onChange((int)nud.Value);
            panelEditor.Controls.Add(nud);
            return nud;
        }

        private CheckBox AddCheckBox(string text, bool value, int top, Action<bool> onChange)
        {
            var cb = new CheckBox
            {
                Text = text,
                Checked = value,
                Left = 10,
                Top = top,
                AutoSize = true
            };
            cb.CheckedChanged += (s, e) => onChange(cb.Checked);
            panelEditor.Controls.Add(cb);
            return cb;
        }

        private void MarkDirty() { _isDirty = true; UpdateUIState(); }

        private string GenerateUniqueBlockId(string baseName)
        {
            int n = 1; string id = baseName;
            while (_story.Blocks.Any(b => b.Id == id)) { n++; id = baseName + "_" + n; }
            return id;
        }

        private string GenerateUniquePropertyKey(string baseName)
        {
            int n = 1; string key = baseName;
            while (_story.Properties.Any(p => p.Key == key)) { n++; key = baseName + "_" + n; }
            return key;
        }

        private bool ConfirmDiscardChanges()
        {
            if (!_isDirty || _story == null) return true;
            var result = MessageBox.Show("Exista modificari nesalvate. Vrei sa le salvezi?",
                "Modificari nesalvate", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel) return false;
            if (result == DialogResult.Yes) { MenuSave_Click(null, EventArgs.Empty); return !_isDirty; }
            return true;
        }

        private void UpdateUIState()
        {
            bool hasStory = _story != null;
            menuSave.Enabled = hasStory; menuSaveAs.Enabled = hasStory;
            menuAddBlock.Enabled = hasStory; menuAddProperty.Enabled = hasStory;
            menuDelete.Enabled = hasStory; menuValidate.Enabled = hasStory;
            string title = "Editor de povesti interactive";
            if (hasStory)
            {
                string fileName = string.IsNullOrEmpty(_currentFilePath)
                    ? "Poveste noua" : Path.GetFileName(_currentFilePath);
                string dirty = _isDirty ? " *" : "";
                title = fileName + dirty + " - " + title;
            }
            Text = title;
        }

        private void SetStatus(string message) { lblStatus.Text = message; }

        private class TreeTag
        {
            public TreeNodeKind Kind { get; }
            public string Id { get; }
            public TreeTag(TreeNodeKind kind, string id) { Kind = kind; Id = id; }
        }

        private enum TreeNodeKind { Story, PropertiesFolder, Property, BlocksFolder, Block }
    }
}