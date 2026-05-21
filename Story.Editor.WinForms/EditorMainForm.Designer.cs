namespace Story.Editor.WinForms
{
    partial class EditorMainForm
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
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fisierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.editareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAddBlock = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAddProperty = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.validareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuValidate = new System.Windows.Forms.ToolStripMenuItem();
            this.splitOuter = new System.Windows.Forms.SplitContainer();
            this.treeStory = new System.Windows.Forms.TreeView();
            this.splitInner = new System.Windows.Forms.SplitContainer();
            this.panelEditor = new System.Windows.Forms.Panel();
            this.panelDecisionsContainer = new System.Windows.Forms.Panel();
            this.dgvDecisions = new System.Windows.Forms.DataGridView();
            this.panelDecisionsButtons = new System.Windows.Forms.Panel();
            this.btnAddDecision = new System.Windows.Forms.Button();
            this.btnEditDecision = new System.Windows.Forms.Button();
            this.btnDeleteDecision = new System.Windows.Forms.Button();
            this.lblDecisionsTitle = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitOuter)).BeginInit();
            this.splitOuter.Panel1.SuspendLayout();
            this.splitOuter.Panel2.SuspendLayout();
            this.splitOuter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitInner)).BeginInit();
            this.splitInner.Panel1.SuspendLayout();
            this.splitInner.Panel2.SuspendLayout();
            this.splitInner.SuspendLayout();
            this.panelDecisionsContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDecisions)).BeginInit();
            this.panelDecisionsButtons.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fisierToolStripMenuItem,
            this.editareToolStripMenuItem,
            this.validareToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1184, 24);
            this.mainMenu.TabIndex = 0;
            // 
            // fisierToolStripMenuItem
            // 
            this.fisierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNew,
            this.menuOpen,
            this.toolStripMenuItem1,
            this.menuSave,
            this.menuSaveAs,
            this.toolStripMenuItem2,
            this.menuExit});
            this.fisierToolStripMenuItem.Name = "fisierToolStripMenuItem";
            this.fisierToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.fisierToolStripMenuItem.Text = "&Fisier";
            // 
            // menuNew
            // 
            this.menuNew.Name = "menuNew";
            this.menuNew.Size = new System.Drawing.Size(180, 22);
            this.menuNew.Text = "&Poveste noua";
            // 
            // menuOpen
            // 
            this.menuOpen.Name = "menuOpen";
            this.menuOpen.Size = new System.Drawing.Size(180, 22);
            this.menuOpen.Text = "&Deschide...";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // menuSave
            // 
            this.menuSave.Name = "menuSave";
            this.menuSave.Size = new System.Drawing.Size(180, 22);
            this.menuSave.Text = "&Salveaza";
            // 
            // menuSaveAs
            // 
            this.menuSaveAs.Name = "menuSaveAs";
            this.menuSaveAs.Size = new System.Drawing.Size(180, 22);
            this.menuSaveAs.Text = "Sa&lveaza ca...";
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
            // editareToolStripMenuItem
            // 
            this.editareToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAddBlock,
            this.menuAddProperty,
            this.toolStripMenuItem3,
            this.menuDelete});
            this.editareToolStripMenuItem.Name = "editareToolStripMenuItem";
            this.editareToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.editareToolStripMenuItem.Text = "&Editare";
            // 
            // menuAddBlock
            // 
            this.menuAddBlock.Name = "menuAddBlock";
            this.menuAddBlock.Size = new System.Drawing.Size(195, 22);
            this.menuAddBlock.Text = "Adauga &bloc";
            // 
            // menuAddProperty
            // 
            this.menuAddProperty.Name = "menuAddProperty";
            this.menuAddProperty.Size = new System.Drawing.Size(195, 22);
            this.menuAddProperty.Text = "Adauga &proprietate";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(192, 6);
            // 
            // menuDelete
            // 
            this.menuDelete.Name = "menuDelete";
            this.menuDelete.Size = new System.Drawing.Size(195, 22);
            this.menuDelete.Text = "St&erge selectia";
            // 
            // validareToolStripMenuItem
            // 
            this.validareToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuValidate});
            this.validareToolStripMenuItem.Name = "validareToolStripMenuItem";
            this.validareToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.validareToolStripMenuItem.Text = "&Validare";
            // 
            // menuValidate
            // 
            this.menuValidate.Name = "menuValidate";
            this.menuValidate.Size = new System.Drawing.Size(195, 22);
            this.menuValidate.Text = "&Valideaza povestea";
            // 
            // splitOuter
            // 
            this.splitOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitOuter.Location = new System.Drawing.Point(0, 24);
            this.splitOuter.Name = "splitOuter";
            this.splitOuter.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.splitOuter.Panel1.Controls.Add(this.treeStory);
            this.splitOuter.Panel2.Controls.Add(this.splitInner);
            this.splitOuter.Size = new System.Drawing.Size(1184, 665);
            this.splitOuter.SplitterDistance = 250;
            this.splitOuter.SplitterWidth = 6;
            this.splitOuter.TabIndex = 1;
            // 
            // treeStory
            // 
            this.treeStory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeStory.Location = new System.Drawing.Point(0, 0);
            this.treeStory.Name = "treeStory";
            this.treeStory.Size = new System.Drawing.Size(250, 665);
            this.treeStory.TabIndex = 0;
            this.treeStory.HideSelection = false;
            // 
            // splitInner
            // 
            this.splitInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitInner.Location = new System.Drawing.Point(0, 0);
            this.splitInner.Name = "splitInner";
            this.splitInner.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.splitInner.Panel1.Controls.Add(this.panelEditor);
            this.splitInner.Panel2.Controls.Add(this.panelDecisionsContainer);
            this.splitInner.Size = new System.Drawing.Size(928, 665);
            this.splitInner.SplitterDistance = 540;
            this.splitInner.SplitterWidth = 6;
            this.splitInner.TabIndex = 0;
            // 
            // panelEditor
            // 
            this.panelEditor.AutoScroll = true;
            this.panelEditor.BackColor = System.Drawing.Color.White;
            this.panelEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEditor.Location = new System.Drawing.Point(0, 0);
            this.panelEditor.Name = "panelEditor";
            this.panelEditor.Padding = new System.Windows.Forms.Padding(10);
            this.panelEditor.Size = new System.Drawing.Size(540, 665);
            this.panelEditor.TabIndex = 0;
            // 
            // panelDecisionsContainer
            // 
            this.panelDecisionsContainer.Controls.Add(this.dgvDecisions);
            this.panelDecisionsContainer.Controls.Add(this.panelDecisionsButtons);
            this.panelDecisionsContainer.Controls.Add(this.lblDecisionsTitle);
            this.panelDecisionsContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDecisionsContainer.Location = new System.Drawing.Point(0, 0);
            this.panelDecisionsContainer.Name = "panelDecisionsContainer";
            this.panelDecisionsContainer.Size = new System.Drawing.Size(382, 665);
            this.panelDecisionsContainer.TabIndex = 0;
            // 
            // lblDecisionsTitle
            // 
            this.lblDecisionsTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDecisionsTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDecisionsTitle.Location = new System.Drawing.Point(0, 0);
            this.lblDecisionsTitle.Name = "lblDecisionsTitle";
            this.lblDecisionsTitle.Padding = new System.Windows.Forms.Padding(8, 8, 0, 4);
            this.lblDecisionsTitle.Size = new System.Drawing.Size(382, 30);
            this.lblDecisionsTitle.TabIndex = 0;
            this.lblDecisionsTitle.Text = "Decizii";
            // 
            // dgvDecisions
            // 
            this.dgvDecisions.AllowUserToAddRows = false;
            this.dgvDecisions.AllowUserToDeleteRows = false;
            this.dgvDecisions.AllowUserToResizeRows = false;
            this.dgvDecisions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDecisions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDecisions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDecisions.Location = new System.Drawing.Point(0, 30);
            this.dgvDecisions.Name = "dgvDecisions";
            this.dgvDecisions.ReadOnly = true;
            this.dgvDecisions.RowHeadersVisible = false;
            this.dgvDecisions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDecisions.Size = new System.Drawing.Size(382, 585);
            this.dgvDecisions.TabIndex = 1;
            // 
            // panelDecisionsButtons
            // 
            this.panelDecisionsButtons.Controls.Add(this.btnDeleteDecision);
            this.panelDecisionsButtons.Controls.Add(this.btnEditDecision);
            this.panelDecisionsButtons.Controls.Add(this.btnAddDecision);
            this.panelDecisionsButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelDecisionsButtons.Location = new System.Drawing.Point(0, 615);
            this.panelDecisionsButtons.Name = "panelDecisionsButtons";
            this.panelDecisionsButtons.Padding = new System.Windows.Forms.Padding(6);
            this.panelDecisionsButtons.Size = new System.Drawing.Size(382, 50);
            this.panelDecisionsButtons.TabIndex = 2;
            // 
            // btnAddDecision
            // 
            this.btnAddDecision.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAddDecision.Location = new System.Drawing.Point(6, 6);
            this.btnAddDecision.Name = "btnAddDecision";
            this.btnAddDecision.Size = new System.Drawing.Size(100, 38);
            this.btnAddDecision.TabIndex = 0;
            this.btnAddDecision.Text = "Adauga";
            this.btnAddDecision.UseVisualStyleBackColor = true;
            // 
            // btnEditDecision
            // 
            this.btnEditDecision.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnEditDecision.Location = new System.Drawing.Point(106, 6);
            this.btnEditDecision.Name = "btnEditDecision";
            this.btnEditDecision.Size = new System.Drawing.Size(100, 38);
            this.btnEditDecision.TabIndex = 1;
            this.btnEditDecision.Text = "Editeaza";
            this.btnEditDecision.UseVisualStyleBackColor = true;
            // 
            // btnDeleteDecision
            // 
            this.btnDeleteDecision.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDeleteDecision.Location = new System.Drawing.Point(206, 6);
            this.btnDeleteDecision.Name = "btnDeleteDecision";
            this.btnDeleteDecision.Size = new System.Drawing.Size(100, 38);
            this.btnDeleteDecision.TabIndex = 2;
            this.btnDeleteDecision.Text = "Sterge";
            this.btnDeleteDecision.UseVisualStyleBackColor = true;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Poveste (*.zip;*.story)|*.zip;*.story|Toate fisierele (*.*)|*.*";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Poveste (*.zip)|*.zip";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 689);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1184, 22);
            this.statusStrip.TabIndex = 2;
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(39, 17);
            this.lblStatus.Text = "Gata.";
            // 
            // EditorMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 711);
            this.Controls.Add(this.splitOuter);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "EditorMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editor de povesti interactive";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.splitOuter.Panel1.ResumeLayout(false);
            this.splitOuter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitOuter)).EndInit();
            this.splitOuter.ResumeLayout(false);
            this.splitInner.Panel1.ResumeLayout(false);
            this.splitInner.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitInner)).EndInit();
            this.splitInner.ResumeLayout(false);
            this.panelDecisionsContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDecisions)).EndInit();
            this.panelDecisionsButtons.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fisierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuNew;
        private System.Windows.Forms.ToolStripMenuItem menuOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuSave;
        private System.Windows.Forms.ToolStripMenuItem menuSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripMenuItem editareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuAddBlock;
        private System.Windows.Forms.ToolStripMenuItem menuAddProperty;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem menuDelete;
        private System.Windows.Forms.ToolStripMenuItem validareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuValidate;
        private System.Windows.Forms.SplitContainer splitOuter;
        private System.Windows.Forms.TreeView treeStory;
        private System.Windows.Forms.SplitContainer splitInner;
        private System.Windows.Forms.Panel panelEditor;
        private System.Windows.Forms.Panel panelDecisionsContainer;
        private System.Windows.Forms.DataGridView dgvDecisions;
        private System.Windows.Forms.Panel panelDecisionsButtons;
        private System.Windows.Forms.Button btnAddDecision;
        private System.Windows.Forms.Button btnEditDecision;
        private System.Windows.Forms.Button btnDeleteDecision;
        private System.Windows.Forms.Label lblDecisionsTitle;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    }
}