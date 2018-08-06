using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using FamliyBrowser;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace FamilyBrowser
{
    public partial class Family_Browser : System.Windows.Forms.Form
    {
        public class JsonData
        {
            public JArray list { get; set; }
        }

        public static string fileName;

        public string familyName;

        public static Family_Browser Family_Browser;

        public UIDocument uidoc;

        public ExternalEvent exEvent;

        public List<FamilyData> Data;

        public List<string> folder_path;

        public Family_Browser()
        {
            InitializeComponent();
        }

        public Family_Browser(UIDocument uidoc, ExternalEvent exEvent, List<FamilyData> Data)
        {
            this.uidoc = uidoc;

            this.exEvent = exEvent;

            this.Data = Data;

            Family_Browser = this;

            InitializeComponent();
        }

        private void Family_public_Load(object sender, EventArgs e)
        {
            Fresh_tabPage_cloud();

            Fresh_door();
        }

        void Fresh_tabPage_cloud()
        {
            treeView_cloud.Nodes.Clear();

            var client = new RestClient("http://www.hibim.com/gateWay.do?s=H4sIAAAAAAAEAMssqSxItTUytlDLTc0r9UyxNVRLy89JSS0KAYkbqxXnlxYlp4I5Ac5qxZnpebYWhimpyaaGFmmpFqYpaYYmaWbGSWYpFqnGxmnmFiaWpgAZbIJBUwAAAA%3d%3d");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Postman-Token", "ba1b14be-381b-419e-adaa-28c64d6f3023");
            request.AddHeader("Cache-Control", "no-cache");
            IRestResponse response = client.Execute(request);

            JsonData jsonData = JsonConvert.DeserializeObject<JsonData>(response.Content);

            var parent = new List<FamilyData>();

            var child = new List<FamilyData>();

            foreach (var item in jsonData.list)
            {
                var FamilyData = new FamilyData
                {
                    parent_id = item["parent_id"].ToString(),

                    folder_id = item["folder_id"].ToString(),

                    folder_name = item["folder_name"].ToString()
                };

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

        void Fresh_door()
        {
            listView.Items.Clear();

            var client = new RestClient("http://www.hibim.com/gateWay.do?s=H4sIAAAAAAAEAMssqSxItTUyNlNLy89JSS3yTLE1VCtITE8FUsWZVam2xgZqxfmlRcmpISCFAc5A0fQ8WwODJMsUE2ODZCOjZKMUy0RLAwszQ5MUS0PjJAtDS8MkAPQLxAdXAAAA");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Postman-Token", "1edd33c1-a69d-4d66-8e44-8c799c52d365");
            request.AddHeader("Cache-Control", "no-cache");
            IRestResponse response = client.Execute(request);

            JsonData jsonData = JsonConvert.DeserializeObject<JsonData>(response.Content);

            foreach (var item in jsonData.list)
            {
                listView.Items.Add(item["family_name"].ToString(), 0);
            }
        }

        void Fresh_project()
        {
            treeView_project.Nodes.Clear();

            var category = new HashSet<string>();

            foreach (var item in Data)
            {
                category.Add(item.category_name);
            }

            foreach (var _category in category)
            {
                var category_node = treeView_project.Nodes.Add(_category);

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
                Fresh_door();
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

                    Fresh_tabPage_cloud();

                    Fresh_door();

                    break;

                //本地
                case 1:

                    Fresh_project();

                    break;

                //企业
                case 2:

                    break;
            }
        }

        private void project刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fresh_project();
        }

        private void dirctory刷新toolStripMenuItem_Click(object sender, EventArgs e)
        {
            folder_path = new List<string>();

            if (folderBrowserDialog.SelectedPath.Length > 0)
            {
                treeView_directory.Nodes.Clear();

                var paths = Directory.GetFiles(folderBrowserDialog.SelectedPath);

                foreach (var item in paths)
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

                var paths = Directory.GetFiles(folderBrowserDialog.SelectedPath);

                foreach (var item in paths)
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
            if (treeView_project.SelectedNode == null)
            {
                return;
            }

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
