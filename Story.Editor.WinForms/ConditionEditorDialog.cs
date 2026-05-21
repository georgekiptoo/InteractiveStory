using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Story.Model;

namespace Story.Editor.WinForms
{
    public partial class ConditionEditorDialog : Form
    {
        public ConditionNode Result { get; private set; }

        private List<string> _propertyKeys;

        private class NodeTag
        {
            public ConditionNode Node { get; set; }
            public NodeTag(ConditionNode node) { Node = node; }
        }

        public ConditionEditorDialog(ConditionNode existingCondition,
                                     IEnumerable<string> propertyKeys)
        {
            InitializeComponent();
            _propertyKeys = propertyKeys.ToList();

            foreach (var key in _propertyKeys)
                cmbProperty.Items.Add(key);
            if (cmbProperty.Items.Count > 0)
                cmbProperty.SelectedIndex = 0;
            if (cmbOperator.Items.Count > 0)
                cmbOperator.SelectedIndex = 0;

            btnAddAnd.Click += BtnAddAnd_Click;
            btnAddOr.Click += BtnAddOr_Click;
            btnAddComparison.Click += BtnAddComparison_Click;
            btnDeleteNode.Click += BtnDeleteNode_Click;
            btnClearCondition.Click += BtnClearCondition_Click;
            btnOk.Click += BtnOk_Click;
            treeCondition.AfterSelect += TreeCondition_AfterSelect;

            cmbProperty.SelectedIndexChanged += ComparisonFieldChanged;
            cmbProperty.TextChanged += ComparisonFieldChanged;
            cmbOperator.SelectedIndexChanged += ComparisonFieldChanged;
            nudValue.ValueChanged += ComparisonFieldChanged;

            if (existingCondition != null)
                BuildTreeFromCondition(existingCondition);
            else
                treeCondition.Nodes.Clear();

            UpdateEditPanel(null);
        }

        private void BuildTreeFromCondition(ConditionNode node)
        {
            treeCondition.Nodes.Clear();
            var treeNode = CreateTreeNodeFrom(node);
            treeCondition.Nodes.Add(treeNode);
            treeCondition.ExpandAll();
        }

        private TreeNode CreateTreeNodeFrom(ConditionNode node)
        {
            string label = GetNodeLabel(node);
            var treeNode = new TreeNode(label) { Tag = new NodeTag(node) };

            if (node is AndCondition and)
                foreach (var child in and.Conditions)
                    treeNode.Nodes.Add(CreateTreeNodeFrom(child));
            else if (node is OrCondition or)
                foreach (var child in or.Conditions)
                    treeNode.Nodes.Add(CreateTreeNodeFrom(child));

            return treeNode;
        }

        private string GetNodeLabel(ConditionNode node)
        {
            if (node is ComparisonCondition cmp)
                return cmp.Property + " " + cmp.Operator + " " + cmp.Value;
            if (node is AndCondition) return "AND";
            if (node is OrCondition) return "OR";
            return "?";
        }

        private void TreeCondition_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var tag = e.Node?.Tag as NodeTag;
            UpdateEditPanel(tag?.Node);
        }

        private void UpdateEditPanel(ConditionNode node)
        {
            bool isComparison = node is ComparisonCondition;

            lblProperty.Visible = isComparison;
            cmbProperty.Visible = isComparison;
            lblOperator.Visible = isComparison;
            cmbOperator.Visible = isComparison;
            lblValue.Visible = isComparison;
            nudValue.Visible = isComparison;

            if (node == null)
                lblNodeType.Text = "Selecteaza un nod din arbore";
            else if (node is AndCondition)
                lblNodeType.Text = "AND - toate sub-conditiile trebuie sa fie adevarate";
            else if (node is OrCondition)
                lblNodeType.Text = "OR - cel putin o sub-conditie trebuie sa fie adevarata";
            else if (node is ComparisonCondition cmp)
            {
                lblNodeType.Text = "COMPARISON - compara o proprietate cu o valoare";

                cmbProperty.SelectedIndexChanged -= ComparisonFieldChanged;
                cmbProperty.TextChanged -= ComparisonFieldChanged;
                cmbOperator.SelectedIndexChanged -= ComparisonFieldChanged;
                nudValue.ValueChanged -= ComparisonFieldChanged;

                cmbProperty.Text = cmp.Property ?? "";
                cmbOperator.Text = cmp.Operator ?? "==";
                nudValue.Value = Math.Max(nudValue.Minimum,
                    Math.Min(nudValue.Maximum, cmp.Value));

                cmbProperty.SelectedIndexChanged += ComparisonFieldChanged;
                cmbProperty.TextChanged += ComparisonFieldChanged;
                cmbOperator.SelectedIndexChanged += ComparisonFieldChanged;
                nudValue.ValueChanged += ComparisonFieldChanged;
            }
        }

        private void ComparisonFieldChanged(object sender, EventArgs e)
        {
            var tag = treeCondition.SelectedNode?.Tag as NodeTag;
            if (!(tag?.Node is ComparisonCondition cmp)) return;

            cmp.Property = cmbProperty.Text;
            cmp.Operator = cmbOperator.Text;
            cmp.Value = (int)nudValue.Value;

            if (treeCondition.SelectedNode != null)
                treeCondition.SelectedNode.Text = GetNodeLabel(cmp);
        }

        private void BtnAddAnd_Click(object sender, EventArgs e)
        {
            AddNodeToSelected(new AndCondition());
        }

        private void BtnAddOr_Click(object sender, EventArgs e)
        {
            AddNodeToSelected(new OrCondition());
        }

        private void BtnAddComparison_Click(object sender, EventArgs e)
        {
            AddNodeToSelected(new ComparisonCondition
            {
                Property = _propertyKeys.FirstOrDefault() ?? "",
                Operator = ">=",
                Value = 0
            });
        }

        private void AddNodeToSelected(ConditionNode newNode)
        {
            if (treeCondition.SelectedNode == null && treeCondition.Nodes.Count == 0)
            {
                var treeNode = CreateTreeNodeFrom(newNode);
                treeCondition.Nodes.Add(treeNode);
                treeCondition.SelectedNode = treeNode;
                return;
            }

            var selectedTag = treeCondition.SelectedNode?.Tag as NodeTag;

            if (selectedTag?.Node is AndCondition and)
            {
                and.Conditions.Add(newNode);
                var childTreeNode = CreateTreeNodeFrom(newNode);
                treeCondition.SelectedNode.Nodes.Add(childTreeNode);
                treeCondition.SelectedNode.Expand();
                treeCondition.SelectedNode = childTreeNode;
                return;
            }

            if (selectedTag?.Node is OrCondition or)
            {
                or.Conditions.Add(newNode);
                var childTreeNode = CreateTreeNodeFrom(newNode);
                treeCondition.SelectedNode.Nodes.Add(childTreeNode);
                treeCondition.SelectedNode.Expand();
                treeCondition.SelectedNode = childTreeNode;
                return;
            }

            MessageBox.Show(
                "Poti adauga sub-noduri doar la noduri AND sau OR.\n" +
                "Selecteaza un nod AND/OR sau sterge selectia pentru nodul radacina.",
                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnDeleteNode_Click(object sender, EventArgs e)
        {
            if (treeCondition.SelectedNode == null) return;
            var nodeToDelete = treeCondition.SelectedNode;
            var tag = nodeToDelete.Tag as NodeTag;
            if (tag == null) return;

            if (nodeToDelete.Parent != null)
            {
                var parentTag = nodeToDelete.Parent.Tag as NodeTag;
                if (parentTag?.Node is AndCondition and)
                    and.Conditions.Remove(tag.Node);
                else if (parentTag?.Node is OrCondition or)
                    or.Conditions.Remove(tag.Node);
                nodeToDelete.Parent.Nodes.Remove(nodeToDelete);
            }
            else
            {
                treeCondition.Nodes.Clear();
            }
            UpdateEditPanel(null);
        }

        private void BtnClearCondition_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Stergi toata conditia?", "Confirmare",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            treeCondition.Nodes.Clear();
            UpdateEditPanel(null);
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (treeCondition.Nodes.Count == 0)
                Result = null;
            else
            {
                var rootTag = treeCondition.Nodes[0].Tag as NodeTag;
                Result = rootTag?.Node;
            }
        }
    }
}