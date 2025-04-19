using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductPropertyKliensApp
{
    public partial class ColumnSelectorForm : Form
    {
        private readonly List<string> mandatoryDisplays;

        private readonly Dictionary<string, string> propertyTranslations;

        private readonly List<string> currentDisplayedKeys;

        public List<string> SelectedKeys { get; private set; }

        public ColumnSelectorForm(
            Dictionary<string, string> propertyTranslationsLocal,
            List<string> currentDisplayedColumnsKeys,
            List<string> mandatoryDisplaysLocal)
        {
            InitializeComponent();
            propertyTranslations = propertyTranslationsLocal;
            currentDisplayedKeys = currentDisplayedColumnsKeys;
            mandatoryDisplays = mandatoryDisplaysLocal;

            checkedListBox1.ItemCheck += CheckedListBox1_ItemCheck;
        }

        private void ColumnSelectorForm_Load(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();

            foreach (var kvp in propertyTranslations)
            {
                var key = kvp.Key;
                var display = kvp.Value;
                int idx = checkedListBox1.Items.Add(display);

                checkedListBox1.Items[idx] = new CheckedListBoxItem(display, key);


                if (currentDisplayedKeys.Contains(key))
                    checkedListBox1.SetItemChecked(idx, true);
            }
        }

        private void CheckedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var item = (CheckedListBoxItem)checkedListBox1.Items[e.Index];
            if (mandatoryDisplays.Contains(item.Key))
            {
                e.NewValue = CheckState.Checked;
            }
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            SelectedKeys = checkedListBox1.CheckedItems
                .Cast<CheckedListBoxItem>()
                .Select(ci => ci.Key)
                .ToList();

            DialogResult = DialogResult.OK;
            Close();
        }

        private class CheckedListBoxItem
        {
            public string Display { get; }
            public string Key { get; }

            public CheckedListBoxItem(string display, string key)
            {
                Display = display;
                Key = key;
            }

            public override string ToString() => Display;
        }
    }
}
