namespace Story.Editor.WinForms
{
    partial class DecisionEditDialog
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
            this.lblText = new System.Windows.Forms.Label();
            this.txtText = new System.Windows.Forms.TextBox();
            this.lblTarget = new System.Windows.Forms.Label();
            this.cmbTarget = new System.Windows.Forms.ComboBox();
            this.lblIcon = new System.Windows.Forms.Label();
            this.txtIcon = new System.Windows.Forms.TextBox();
            this.lblEffects = new System.Windows.Forms.Label();
            this.dgvEffects = new System.Windows.Forms.DataGridView();
            this.panelEffectsButtons = new System.Windows.Forms.Panel();
            this.btnAddEffect = new System.Windows.Forms.Button();
            this.btnDeleteEffect = new System.Windows.Forms.Button();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnSetCondition = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEffects)).BeginInit();
            this.panelEffectsButtons.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblText.Location = new System.Drawing.Point(12, 12);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(82, 15);
            this.lblText.TabIndex = 0;
            this.lblText.Text = "Text decizie:";
            // 
            // txtText
            // 
            this.txtText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtText.Location = new System.Drawing.Point(12, 32);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(556, 23);
            this.txtText.TabIndex = 1;
            // 
            // lblTarget
            // 
            this.lblTarget.AutoSize = true;
            this.lblTarget.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTarget.Location = new System.Drawing.Point(12, 68);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(72, 15);
            this.lblTarget.TabIndex = 2;
            this.lblTarget.Text = "Bloc tinta:";
            // 
            // cmbTarget
            // 
            this.cmbTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTarget.FormattingEnabled = true;
            this.cmbTarget.Location = new System.Drawing.Point(12, 88);
            this.cmbTarget.Name = "cmbTarget";
            this.cmbTarget.Size = new System.Drawing.Size(556, 23);
            this.cmbTarget.TabIndex = 3;
            // 
            // lblIcon
            // 
            this.lblIcon.AutoSize = true;
            this.lblIcon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblIcon.Location = new System.Drawing.Point(12, 124);
            this.lblIcon.Name = "lblIcon";
            this.lblIcon.Size = new System.Drawing.Size(160, 15);
            this.lblIcon.TabIndex = 4;
            this.lblIcon.Text = "Iconita (optional, cale relativa):";
            // 
            // txtIcon
            // 
            this.txtIcon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIcon.Location = new System.Drawing.Point(12, 144);
            this.txtIcon.Name = "txtIcon";
            this.txtIcon.Size = new System.Drawing.Size(556, 23);
            this.txtIcon.TabIndex = 5;
            // 
            // lblEffects
            // 
            this.lblEffects.AutoSize = true;
            this.lblEffects.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEffects.Location = new System.Drawing.Point(12, 180);
            this.lblEffects.Name = "lblEffects";
            this.lblEffects.Size = new System.Drawing.Size(50, 15);
            this.lblEffects.TabIndex = 6;
            this.lblEffects.Text = "Efecte:";
            // 
            // dgvEffects
            // 
            this.dgvEffects.AllowUserToAddRows = false;
            this.dgvEffects.AllowUserToDeleteRows = false;
            this.dgvEffects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEffects.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEffects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEffects.Location = new System.Drawing.Point(12, 200);
            this.dgvEffects.Name = "dgvEffects";
            this.dgvEffects.RowHeadersVisible = false;
            this.dgvEffects.Size = new System.Drawing.Size(556, 200);
            this.dgvEffects.TabIndex = 7;
            // 
            // panelEffectsButtons
            // 
            this.panelEffectsButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelEffectsButtons.Controls.Add(this.btnAddEffect);
            this.panelEffectsButtons.Controls.Add(this.btnDeleteEffect);
            this.panelEffectsButtons.Location = new System.Drawing.Point(12, 408);
            this.panelEffectsButtons.Name = "panelEffectsButtons";
            this.panelEffectsButtons.Size = new System.Drawing.Size(556, 40);
            this.panelEffectsButtons.TabIndex = 8;
            // 
            // btnAddEffect
            // 
            this.btnAddEffect.Location = new System.Drawing.Point(0, 5);
            this.btnAddEffect.Name = "btnAddEffect";
            this.btnAddEffect.Size = new System.Drawing.Size(120, 30);
            this.btnAddEffect.TabIndex = 0;
            this.btnAddEffect.Text = "Adauga efect";
            this.btnAddEffect.UseVisualStyleBackColor = true;
            // 
            // btnDeleteEffect
            // 
            this.btnDeleteEffect.Location = new System.Drawing.Point(130, 5);
            this.btnDeleteEffect.Name = "btnDeleteEffect";
            this.btnDeleteEffect.Size = new System.Drawing.Size(120, 30);
            this.btnDeleteEffect.TabIndex = 1;
            this.btnDeleteEffect.Text = "Sterge efect";
            this.btnDeleteEffect.UseVisualStyleBackColor = true;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.btnSetCondition);
            this.panelBottom.Controls.Add(this.btnOk);
            this.panelBottom.Controls.Add(this.btnCancel);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 458);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(580, 50);
            this.panelBottom.TabIndex = 9;
            // 
            // btnSetCondition
            // 
            this.btnSetCondition.Location = new System.Drawing.Point(12, 10);
            this.btnSetCondition.Name = "btnSetCondition";
            this.btnSetCondition.Size = new System.Drawing.Size(180, 30);
            this.btnSetCondition.TabIndex = 0;
            this.btnSetCondition.Text = "Setare conditie (fara)";
            this.btnSetCondition.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(380, 10);
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
            this.btnCancel.Location = new System.Drawing.Point(478, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Anuleaza";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // DecisionEditDialog
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(580, 508);
            this.Controls.Add(this.dgvEffects);
            this.Controls.Add(this.panelEffectsButtons);
            this.Controls.Add(this.lblEffects);
            this.Controls.Add(this.txtIcon);
            this.Controls.Add(this.lblIcon);
            this.Controls.Add(this.cmbTarget);
            this.Controls.Add(this.lblTarget);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.panelBottom);
            this.MinimumSize = new System.Drawing.Size(560, 560);
            this.Name = "DecisionEditDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Editare decizie";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEffects)).EndInit();
            this.panelEffectsButtons.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.Label lblTarget;
        private System.Windows.Forms.ComboBox cmbTarget;
        private System.Windows.Forms.Label lblIcon;
        private System.Windows.Forms.TextBox txtIcon;
        private System.Windows.Forms.Label lblEffects;
        private System.Windows.Forms.DataGridView dgvEffects;
        private System.Windows.Forms.Panel panelEffectsButtons;
        private System.Windows.Forms.Button btnAddEffect;
        private System.Windows.Forms.Button btnDeleteEffect;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnSetCondition;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}