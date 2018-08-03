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
using System.Threading;
using System.Windows.Forms;

namespace FamilyBrowser
{
    public partial class Family_browser : System.Windows.Forms.Form
    {
        public class JsonData
        {
            public JArray list { get; set; }
        }

        public static string fileName;

        public string familyName;

        public static Family_browser Family_Browser;

        public UIDocument uidoc;

        public ExternalEvent exEvent;

        public List<FamilyData> Data;

        public List<string> folder_path;

        public Family_browser(UIDocument uidoc, ExternalEvent exEvent, List<FamilyData> Data)
        {
            this.uidoc = uidoc;

            this.exEvent = exEvent;

            this.Data = Data;

            Family_Browser = this;

            InitializeComponent();
        }

        public Family_browser()
        {
            InitializeComponent();
        }

        private void Family_public_Load(object sender, EventArgs e)
        {
            fresh_tabPage_cloud();

            fresh_door();
        }

        void fresh_tabPage_cloud()
        {
            treeView_cloud.Nodes.Clear();

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

            var architecture_node = treeView_cloud.Nodes.Add("建筑");

            foreach (var item_parent in parent)
            {
                var node_root = architecture_node.Nodes.Add(item_parent.folder_name);

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

        void fresh_project()
        {
            treeView_project.Nodes.Clear();

            var category = new HashSet<string>();

            foreach (var item in Data)
            {
                category.Add(item.category_name);
            }

            foreach (var item in category)
            {
                var category_node = treeView_project.Nodes.Add(item);

                var family = new HashSet<string>();

                foreach (var data in Data)
                {
                    if (category_node.Text == data.category_name)
                    {
                        family.Add(data.family_name);
                    }
                }

                foreach (var _family in family)
                {
                    var family_node = category_node.Nodes.Add(_family);

                    foreach (var _data in Data)
                    {
                        if (family_node.Text == _data.family_name)
                        {
                            family_node.Nodes.Add(_data.symbol_name);
                        }
                    }
                }

                //category_node.Expand();
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
                familyName = listView.SelectedItems[0].Text;

                var directory = Path.Combine(Path.GetTempPath(), "Bimcc");

                Directory.CreateDirectory(directory);

                fileName = Path.Combine(directory, familyName + ".rfa");

                if (File.Exists(fileName))
                {
                    //
                }
                else
                {
                    var http = new WebClient();

                    http.DownloadFile("http://img01.pinming.cn/8a9b6c3d6209756f01621d38a19a01de.rfa?Expires=1532929251&OSSAccessKeyId=LTAI8ZbJOm3c5VVZ&Signature=dOA6DRrM2eQxtfg7qwjtYpvO73c%3D", fileName);
                }

                Hide();

                exEvent.Raise();
            }
        }

        private void Form_browser_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void listView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            familyName = listView.SelectedItems[0].Text;
        }

        private void Form_browser_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide(); e.Cancel = true;
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl.SelectedIndex)
            {
                //云
                case 0:

                    fresh_tabPage_cloud();

                    fresh_door();

                    break;

                //本地
                case 1:

                    fresh_project();

                    break;

                //企业
                case 2:

                    break;
            }
        }

        private void project刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fresh_project();
        }

        private void dirctory刷新toolStripMenuItem_Click(object sender, EventArgs e)
        {
            folder_path = new List<string>();

            if (folderBrowserDialog.SelectedPath.Length > 0)
            {
                treeView_directory.Nodes.Clear();

                var files = Directory.GetFiles(folderBrowserDialog.SelectedPath);

                foreach (var item in files)
                {
                    var name = item.Substring(item.LastIndexOf("\\") + 1);

                    if (name.Contains("rfa"))
                    {
                        name = name.Remove(name.LastIndexOf("."));

                        folder_path.Add(item);

                        treeView_directory.Nodes.Add(name);
                    }
                }
            }
        }

        private void button_folder_Click(object sender, EventArgs e)

        {
            folder_path = new List<string>();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                treeView_directory.Nodes.Clear();

                var files = Directory.GetFiles(folderBrowserDialog.SelectedPath);

                foreach (var item in files)
                {
                    var name = item.Substring(item.LastIndexOf("\\") + 1);

                    if (name.Contains("rfa"))
                    {
                        name = name.Remove(name.LastIndexOf("."));

                        folder_path.Add(item);

                        treeView_directory.Nodes.Add(name);
                    }
                }
            }

        }

        private void directory创建实例toolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in folder_path)
            {
                if (item.Contains(treeView_directory.SelectedNode.Text))
                {
                    fileName = item;

                    Hide();

                    exEvent.Raise();
                }
            }
        }

        private void project创建实例ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView_project.SelectedNode == null)
            {
                return;
            }

            foreach (var item in Data)
            {
                if (treeView_project.SelectedNode.Text == item.symbol_name)
                {
                    Hide();

                    uidoc.PostRequestForElementTypePlacement(item.symbol);
                }
            }
        }
    }
}
