namespace Story.Editor.WinForms
{
    partial class ConditionEditorDialog
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.treeCondition = new System.Windows.Forms.TreeView();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnAddAnd = new System.Windows.Forms.Button();
            this.btnAddOr = new System.Windows.Forms.Button();
            this.btnAddComparison = new System.Windows.Forms.Button();
            this.btnDeleteNode = new System.Windows.Forms.Button();
            this.panelEdit = new System.Windows.Forms.Panel();
            this.lblNodeType = new System.Windows.Forms.Label();
            this.lblProperty = new System.Windows.Forms.Label();
            this.cmbProperty = new System.Windows.Forms.ComboBox();
            this.lblOperator = new System.Windows.Forms.Label();
            this.cmbOperator = new System.Windows.Forms.ComboBox();
            this.lblValue = new System.Windows.Forms.Label();
            this.nudValue = new System.Windows.Forms.NumericUpDown();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnClearCondition = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.panelEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudValue)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitMain
            // 
            this.splitMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitMain.Location = new System.Drawing.Point(12, 12);
            this.splitMain.Name = "splitMain";
            this.splitMain.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.splitMain.Panel1.Controls.Add(this.treeCondition);
            this.splitMain.Panel1.Controls.Add(this.panelButtons);
            this.splitMain.Panel2.Controls.Add(this.panelEdit);
            this.splitMain.Size = new System.Drawing.Size(660, 400);
            this.splitMain.SplitterDistance = 340;
            this.splitMain.TabIndex = 0;
            // 
            // treeCondition
            // 
            this.treeCondition.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeCondition.HideSelection = false;
            this.treeCondition.Location = new System.Drawing.Point(0, 0);
            this.treeCondition.Name = "treeCondition";
            this.treeCondition.Size = new System.Drawing.Size(660, 295);
            this.treeCondition.TabIndex = 0;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnAddAnd);
            this.panelButtons.Controls.Add(this.btnAddOr);
            this.panelButtons.Controls.Add(this.btnAddComparison);
            this.panelButtons.Controls.Add(this.btnDeleteNode);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 295);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(660, 45);
            this.panelButtons.TabIndex = 1;
            // 
            // btnAddAnd
            // 
            this.btnAddAnd.Location = new System.Drawing.Point(0, 8);
            this.btnAddAnd.Name = "btnAddAnd";
            this.btnAddAnd.Size = new System.Drawing.Size(80, 30);
            this.btnAddAnd.TabIndex = 0;
            this.btnAddAnd.Text = "+ AND";
            this.btnAddAnd.UseVisualStyleBackColor = true;
            // 
            // btnAddOr
            // 
            this.btnAddOr.Location = new System.Drawing.Point(86, 8);
            this.btnAddOr.Name = "btnAddOr";
            this.btnAddOr.Size = new System.Drawing.Size(80, 30);
            this.btnAddOr.TabIndex = 1;
            this.btnAddOr.Text = "+ OR";
            this.btnAddOr.UseVisualStyleBackColor = true;
            // 
            // btnAddComparison
            // 
            this.btnAddComparison.Location = new System.Drawing.Point(172, 8);
            this.btnAddComparison.Name = "btnAddComparison";
            this.btnAddComparison.Size = new System.Drawing.Size(100, 30);
            this.btnAddComparison.TabIndex = 2;
            this.btnAddComparison.Text = "+ Compare";
            this.btnAddComparison.UseVisualStyleBackColor = true;
            // 
            // btnDeleteNode
            // 
            this.btnDeleteNode.Location = new System.Drawing.Point(278, 8);
            this.btnDeleteNode.Name = "btnDeleteNode";
            this.btnDeleteNode.Size = new System.Drawing.Size(100, 30);
            this.btnDeleteNode.TabIndex = 3;
            this.btnDeleteNode.Text = "Sterge nod";
            this.btnDeleteNode.UseVisualStyleBackColor = true;
            // 
            // panelEdit
            // 
            this.panelEdit.Controls.Add(this.lblNodeType);
            this.panelEdit.Controls.Add(this.lblProperty);
            this.panelEdit.Controls.Add(this.cmbProperty);
            this.panelEdit.Controls.Add(this.lblOperator);
            this.panelEdit.Controls.Add(this.cmbOperator);
            this.panelEdit.Controls.Add(this.lblValue);
            this.panelEdit.Controls.Add(this.nudValue);
            this.panelEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEdit.Location = new System.Drawing.Point(0, 0);
            this.panelEdit.Name = "panelEdit";
            this.panelEdit.Padding = new System.Windows.Forms.Padding(10);
            this.panelEdit.Size = new System.Drawing.Size(660, 56);
            this.panelEdit.TabIndex = 0;
            // 
            // lblNodeType
            // 
            this.lblNodeType.AutoSize = true;
            this.lblNodeType.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNodeType.Location = new System.Drawing.Point(10, 10);
            this.lblNodeType.Name = "lblNodeType";
            this.lblNodeType.Size = new System.Drawing.Size(220, 19);
            this.lblNodeType.TabIndex = 0;
            this.lblNodeType.Text = "Selecteaza un nod din arbore";
            // 
            // lblProperty
            // 
            this.lblProperty.AutoSize = true;
            this.lblProperty.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblProperty.Location = new System.Drawing.Point(10, 40);
            this.lblProperty.Name = "lblProperty";
            this.lblProperty.Size = new System.Drawing.Size(71, 15);
            this.lblProperty.TabIndex = 1;
            this.lblProperty.Text = "Proprietate:";
            this.lblProperty.Visible = false;
            // 
            // cmbProperty
            // 
            this.cmbProperty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbProperty.FormattingEnabled = true;
            this.cmbProperty.Location = new System.Drawing.Point(10, 58);
            this.cmbProperty.Name = "cmbProperty";
            this.cmbProperty.Size = new System.Drawing.Size(300, 23);
            this.cmbProperty.TabIndex = 2;
            this.cmbProperty.Visible = false;
            // 
            // lblOperator
            // 
            this.lblOperator.AutoSize = true;
            this.lblOperator.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblOperator.Location = new System.Drawing.Point(320, 40);
            this.lblOperator.Name = "lblOperator";
            this.lblOperator.Size = new System.Drawing.Size(57, 15);
            this.lblOperator.TabIndex = 3;
            this.lblOperator.Text = "Operator:";
            this.lblOperator.Visible = false;
            // 
            // cmbOperator
            // 
            this.cmbOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOperator.FormattingEnabled = true;
            this.cmbOperator.Items.AddRange(new object[] { "<", "<=", ">", ">=", "==", "!=" });
            this.cmbOperator.Location = new System.Drawing.Point(320, 58);
            this.cmbOperator.Name = "cmbOperator";
            this.cmbOperator.Size = new System.Drawing.Size(80, 23);
            this.cmbOperator.TabIndex = 4;
            this.cmbOperator.Visible = false;
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblValue.Location = new System.Drawing.Point(410, 40);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(47, 15);
            this.lblValue.TabIndex = 5;
            this.lblValue.Text = "Valoare:";
            this.lblValue.Visible = false;
            // 
            // nudValue
            // 
            this.nudValue.Location = new System.Drawing.Point(410, 58);
            this.nudValue.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            this.nudValue.Minimum = new decimal(new int[] { 99999, 0, 0, unchecked((int)0x80000000) });
            this.nudValue.Name = "nudValue";
            this.nudValue.Size = new System.Drawing.Size(100, 23);
            this.nudValue.TabIndex = 6;
            this.nudValue.Visible = false;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.btnClearCondition);
            this.panelBottom.Controls.Add(this.btnOk);
            this.panelBottom.Controls.Add(this.btnCancel);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 424);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(684, 50);
            this.panelBottom.TabIndex = 1;
            // 
            // btnClearCondition
            // 
            this.btnClearCondition.Location = new System.Drawing.Point(12, 10);
            this.btnClearCondition.Name = "btnClearCondition";
            this.btnClearCondition.Size = new System.Drawing.Size(130, 30);
            this.btnClearCondition.TabIndex = 0;
            this.btnClearCondition.Text = "Sterge conditia";
            this.btnClearCondition.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(472, 10);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(90, 30);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(572, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Anuleaza";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // ConditionEditorDialog
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(684, 474);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.panelBottom);
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "ConditionEditorDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Editor conditie";
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.panelEdit.ResumeLayout(false);
            this.panelEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudValue)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.TreeView treeCondition;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnAddAnd;
        private System.Windows.Forms.Button btnAddOr;
        private System.Windows.Forms.Button btnAddComparison;
        private System.Windows.Forms.Button btnDeleteNode;
        private System.Windows.Forms.Panel panelEdit;
        private System.Windows.Forms.Label lblNodeType;
        private System.Windows.Forms.Label lblProperty;
        private System.Windows.Forms.ComboBox cmbProperty;
        private System.Windows.Forms.Label lblOperator;
        private System.Windows.Forms.ComboBox cmbOperator;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.NumericUpDown nudValue;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnClearCondition;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}