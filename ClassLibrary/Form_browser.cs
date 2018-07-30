using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using EasyHttp.Http;
using FamliyBrowser;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace FamilyBrowser
{
    public partial class Form_browser : System.Windows.Forms.Form
    {
        public class JsonData
        {
            public JArray list { get; set; }
        }

        public static Form_browser Form_Browser;

        public UIDocument uidoc;

        public ExternalEvent exEvent;

        public static string symbol_name;

        public Form_browser(UIDocument uidoc, ExternalEvent exEvent)
        {
            this.uidoc = uidoc;

            this.exEvent = exEvent;

            Form_Browser = this;

            InitializeComponent();
        }

        public Form_browser()
        {
            InitializeComponent();
        }

        private void Family_public_Load(object sender, EventArgs e)
        {
            fresh_tabPage_architecture();

            fresh_door();
        }

        void fresh_tabPage_architecture()
        {
            var http = new HttpClient();

            var response = http.Get("http://www.hibim.com/gateWay.do?s=H4sIAAAAAAAEAMssqSxItTUytlDLTc0r9UyxNVRLy89JSS0KAYkbqxXnlxYlp4I5Ac5qxZnpebYWhimpyaaGFmmpFqYpaYYmaWbGSWYpFqnGxmnmFiaWpgAZbIJBUwAAAA%3d%3d").RawText;

            JsonData jsonData = JsonConvert.DeserializeObject<JsonData>(response);

            var parent = new List<FamilyData>();

            var child = new List<FamilyData>();

            foreach (var item in jsonData.list)
            {
                var FamilyData = new FamilyData();

                FamilyData.parent_id = item["parent_id"].ToString();

                FamilyData.folder_id = item["folder_id"].ToString();

                FamilyData.folder_name = item["folder_name"].ToString();

                if (FamilyData.parent_id == "")
                {
                    parent.Add(FamilyData);
                }
                else
                {
                    child.Add(FamilyData);
                }
            }

            parent.Reverse();

            child.Reverse();

            foreach (var item_parent in parent)
            {
                var node_root = treeView.Nodes.Add(item_parent.folder_name);

                node_root.Expand();

                foreach (var item_child in child)
                {
                    if (item_child.parent_id == item_parent.folder_id)
                    {
                        node_root.Nodes.Add(item_child.folder_name);
                    }
                }
            }
        }

        void fresh_door()
        {
            listView.Items.Clear();

            var http = new HttpClient();

            var response = http.Get("http://www.hibim.com/gateWay.do?s=H4sIAAAAAAAEAMssqSxItTUyNlNLy89JSS3yTLE1VCtITE8FUsWZVam2xgZqxfmlRcmpISCFAc5A0fQ8WwODJMsUE2ODZCOjZKMUy0RLAwszQ5MUS0PjJAtDS8MkAPQLxAdXAAAA").RawText;

            JsonData jsonData = JsonConvert.DeserializeObject<JsonData>(response);

            foreach (var item in jsonData.list)
            {
                listView.Items.Add(item["family_name"].ToString(), 0);
            }
        }

        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Text == "门")
            {
                fresh_door();
            }
        }

        private void 创建实例ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                symbol_name = listView.SelectedItems[0].Text;

                exEvent.Raise();
            }
        }

        private void Form_browser_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void listView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            symbol_name = listView.SelectedItems[0].Text;
        }

        private void Form_browser_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide(); e.Cancel = true;
        }
    }
}
