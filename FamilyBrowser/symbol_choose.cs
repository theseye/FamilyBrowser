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
    public partial class Symbol_Choose : Form
    {
        public UIDocument uidoc;

        public List<Family_Data> symbols = new List<Family_Data>();

        public Symbol_Choose()
        {
            InitializeComponent();
        }

        public Symbol_Choose(UIDocument uidoc, List<Family_Data> symbols)
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

                        Family_Browser.Family_browser.Hide();

                        uidoc.PostRequestForElementTypePlacement(item.symbol);
                    }
                }
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close();

            Family_Browser.Family_browser.ShowDialog();
        }
    }
}
