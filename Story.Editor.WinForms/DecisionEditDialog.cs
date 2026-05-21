using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Story.Model;

namespace Story.Editor.WinForms
{
    public partial class DecisionEditDialog : Form
    {
        public DecisionDefinition Result { get; private set; }

        private List<EffectDefinition> _effects;
        private List<string> _propertyKeys;
        private ConditionNode _condition;

        public DecisionEditDialog(DecisionDefinition source,
                                  IEnumerable<string> blockIds,
                                  IEnumerable<string> propertyKeys)
        {
            InitializeComponent();

            _propertyKeys = propertyKeys.ToList();

            cmbTarget.Items.Clear();
            foreach (var id in blockIds) cmbTarget.Items.Add(id);

            txtText.Text = source.Text ?? "";
            cmbTarget.Text = source.TargetBlock ?? "";
            txtIcon.Text = source.IconPath ?? "";

            _effects = source.Effects
                .Select(e => new EffectDefinition
                {
                    Type = e.Type,
                    Property = e.Property,
                    Value = e.Value
                })
                .ToList();

            _condition = source.Condition;

            SetupEffectsGrid();
            RefreshEffectsGrid();

            btnAddEffect.Click += BtnAddEffect_Click;
            btnDeleteEffect.Click += BtnDeleteEffect_Click;
            btnOk.Click += BtnOk_Click;
            btnSetCondition.Click += BtnSetCondition_Click;

            UpdateConditionButton();
        }

        private void BtnSetCondition_Click(object sender, EventArgs e)
        {
            using (var dialog = new ConditionEditorDialog(_condition, _propertyKeys))
            {
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    _condition = dialog.Result;
                    UpdateConditionButton();
                }
            }
        }

        private void UpdateConditionButton()
        {
            btnSetCondition.Text = _condition == null
                ? "Setare conditie (fara)"
                : "Setare conditie (setata)";
        }

        private void SetupEffectsGrid()
        {
            dgvEffects.Columns.Clear();

            var colType = new DataGridViewComboBoxColumn
            {
                Name = "colType",
                HeaderText = "Tip",
                Width = 80
            };
            colType.Items.Add("ADD");
            colType.Items.Add("SET");
            dgvEffects.Columns.Add(colType);

            var colProp = new DataGridViewComboBoxColumn
            {
                Name = "colProp",
                HeaderText = "Proprietate"
            };
            foreach (var key in _propertyKeys) colProp.Items.Add(key);
            dgvEffects.Columns.Add(colProp);

            var colValue = new DataGridViewTextBoxColumn
            {
                Name = "colValue",
                HeaderText = "Valoare",
                Width = 100
            };
            dgvEffects.Columns.Add(colValue);

            dgvEffects.CellValueChanged += DgvEffects_CellValueChanged;
            dgvEffects.CurrentCellDirtyStateChanged += DgvEffects_CurrentCellDirtyStateChanged;
        }

        private void DgvEffects_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvEffects.IsCurrentCellDirty)
                dgvEffects.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void DgvEffects_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _effects.Count) return;
            var effect = _effects[e.RowIndex];
            var row = dgvEffects.Rows[e.RowIndex];

            var typeVal = row.Cells["colType"].Value?.ToString();
            effect.Type = typeVal == "SET" ? EffectType.SET : EffectType.ADD;
            effect.Property = row.Cells["colProp"].Value?.ToString() ?? "";

            int v;
            if (int.TryParse(row.Cells["colValue"].Value?.ToString(), out v))
                effect.Value = v;
        }

        private void RefreshEffectsGrid()
        {
            dgvEffects.Rows.Clear();
            foreach (var effect in _effects)
            {
                int rowIdx = dgvEffects.Rows.Add();
                var row = dgvEffects.Rows[rowIdx];
                row.Cells["colType"].Value = effect.Type.ToString();
                row.Cells["colProp"].Value = effect.Property ?? "";
                row.Cells["colValue"].Value = effect.Value;
            }
        }

        private void BtnAddEffect_Click(object sender, EventArgs e)
        {
            var newEffect = new EffectDefinition
            {
                Type = EffectType.ADD,
                Property = _propertyKeys.FirstOrDefault() ?? "",
                Value = 0
            };
            _effects.Add(newEffect);
            RefreshEffectsGrid();
        }

        private void BtnDeleteEffect_Click(object sender, EventArgs e)
        {
            if (dgvEffects.SelectedRows.Count == 0) return;
            int rowIdx = dgvEffects.SelectedRows[0].Index;
            if (rowIdx < 0 || rowIdx >= _effects.Count) return;
            _effects.RemoveAt(rowIdx);
            RefreshEffectsGrid();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            Result = new DecisionDefinition
            {
                Text = txtText.Text,
                TargetBlock = cmbTarget.Text,
                IconPath = string.IsNullOrWhiteSpace(txtIcon.Text) ? null : txtIcon.Text,
                Effects = _effects,
                Condition = _condition
            };
        }
    }
}