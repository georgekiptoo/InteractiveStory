namespace Story.Player.WinForms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fisierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRestart = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuSaveState = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLoadState = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelHud = new System.Windows.Forms.FlowLayoutPanel();
            this.panelDecisions = new System.Windows.Forms.FlowLayoutPanel();
            this.txtBlockText = new System.Windows.Forms.RichTextBox();
            this.picBackground = new System.Windows.Forms.PictureBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.mainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fisierToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(984, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "mainMenu";
            // 
            // fisierToolStripMenuItem
            // 
            this.fisierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOpen,
            this.menuRestart,
            this.toolStripMenuItem1,
            this.menuSaveState,
            this.menuLoadState,
            this.toolStripMenuItem2,
            this.menuExit});
            this.fisierToolStripMenuItem.Name = "fisierToolStripMenuItem";
            this.fisierToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.fisierToolStripMenuItem.Text = "&Fisier";
            // 
            // menuOpen
            // 
            this.menuOpen.Name = "menuOpen";
            this.menuOpen.Size = new System.Drawing.Size(180, 22);
            this.menuOpen.Text = "&Deschide poveste...";
            // 
            // menuRestart
            // 
            this.menuRestart.Name = "menuRestart";
            this.menuRestart.Size = new System.Drawing.Size(180, 22);
            this.menuRestart.Text = "&Restart";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // menuSaveState
            // 
            this.menuSaveState.Name = "menuSaveState";
            this.menuSaveState.Size = new System.Drawing.Size(180, 22);
            this.menuSaveState.Text = "&Salveaza starea";
            // 
            // menuLoadState
            // 
            this.menuLoadState.Name = "menuLoadState";
            this.menuLoadState.Size = new System.Drawing.Size(180, 22);
            this.menuLoadState.Text = "&Incarca starea";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(180, 22);
            this.menuExit.Text = "&Iesire";
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 64);
            this.splitMain.Name = "splitMain";
            this.splitMain.Panel1.Controls.Add(this.panelHud);
            this.splitMain.Panel2.Controls.Add(this.picBackground);
            this.splitMain.Panel2.Controls.Add(this.txtBlockText);
            this.splitMain.Panel2.Controls.Add(this.panelDecisions);
            this.splitMain.Size = new System.Drawing.Size(984, 597);
            this.splitMain.SplitterDistance = 328;
            this.splitMain.TabIndex = 3;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(0, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(984, 40);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Nicio poveste incarcata";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelHud
            // 
            this.panelHud.AutoScroll = true;
            this.panelHud.BackColor = System.Drawing.Color.Gainsboro;
            this.panelHud.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHud.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panelHud.Location = new System.Drawing.Point(0, 0);
            this.panelHud.Name = "panelHud";
            this.panelHud.Padding = new System.Windows.Forms.Padding(8);
            this.panelHud.Size = new System.Drawing.Size(328, 597);
            this.panelHud.TabIndex = 0;
            this.panelHud.WrapContents = false;
            // 
            // panelDecisions
            // 
            this.panelDecisions.AutoScroll = true;
            this.panelDecisions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelDecisions.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panelDecisions.Location = new System.Drawing.Point(0, 447);
            this.panelDecisions.Name = "panelDecisions";
            this.panelDecisions.Padding = new System.Windows.Forms.Padding(10);
            this.panelDecisions.Size = new System.Drawing.Size(652, 150);
            this.panelDecisions.TabIndex = 0;
            this.panelDecisions.WrapContents = false;
            // 
            // txtBlockText
            // 
            this.txtBlockText.BackColor = System.Drawing.Color.White;
            this.txtBlockText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBlockText.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtBlockText.Location = new System.Drawing.Point(0, 297);
            this.txtBlockText.Name = "txtBlockText";
            this.txtBlockText.ReadOnly = true;
            this.txtBlockText.Size = new System.Drawing.Size(652, 150);
            this.txtBlockText.TabIndex = 1;
            this.txtBlockText.Text = "";
            // 
            // picBackground
            // 
            this.picBackground.BackColor = System.Drawing.Color.Black;
            this.picBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBackground.Location = new System.Drawing.Point(0, 0);
            this.picBackground.Name = "picBackground";
            this.picBackground.Size = new System.Drawing.Size(652, 297);
            this.picBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBackground.TabIndex = 2;
            this.picBackground.TabStop = false;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Filter = "Poveste (*.zip;*.story)|*.zip;*.story|Toate fisierele (*.*)|*.*";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Salvare stare (*.json)|*.json";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cititor de povesti interactive";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fisierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuOpen;
        private System.Windows.Forms.ToolStripMenuItem menuRestart;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuSaveState;
        private System.Windows.Forms.ToolStripMenuItem menuLoadState;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.FlowLayoutPanel panelHud;
        private System.Windows.Forms.FlowLayoutPanel panelDecisions;
        private System.Windows.Forms.PictureBox picBackground;
        private System.Windows.Forms.RichTextBox txtBlockText;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}