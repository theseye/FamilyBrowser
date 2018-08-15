using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FamilyBrowser
{
    public partial class SymbolChoose : Form
    {
        public UIDocument uidoc;

        public List<FamilyData> symbols = new List<FamilyData>();

        public SymbolChoose()
        {
            InitializeComponent();
        }

        public SymbolChoose(UIDocument uidoc, List<FamilyData> symbols)
        {
            InitializeComponent();

            this.uidoc = uidoc;

            this.symbols = symbols;
        }

        private void symbol_choose_Load(object sender, EventArgs e)
        {
            foreach (var item in symbols)
            {
                listView.Items.Add(item.symbol_name);
            }
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                foreach (var item in symbols)
                {
                    if (item.symbol_name == listView.SelectedItems[0].Text)
                    {
                        Close();

                        FamilyBrowser.Family_browser.Hide();

                        uidoc.PostRequestForElementTypePlacement(item.symbol);
                    }
                }
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close();

            FamilyBrowser.Family_browser.ShowDialog();
        }
    }
}
