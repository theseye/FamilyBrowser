namespace FamilyBrowser
{
    partial class Family_Browser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Family_Browser));
            this.contextMenuStrip_cloud = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.创建实例ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.tabPage_cloud = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listView = new System.Windows.Forms.ListView();
            this.treeView_cloud = new System.Windows.Forms.TreeView();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage_local = new System.Windows.Forms.TabPage();
            this.button_folder = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.treeView_directory = new System.Windows.Forms.TreeView();
            this.contextMenuStrip_directory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.treeView_project = new System.Windows.Forms.TreeView();
            this.contextMenuStrip_project = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.载入实例ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage_company = new System.Windows.Forms.TabPage();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.contextMenuStrip_cloud.SuspendLayout();
            this.tabPage_cloud.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage_local.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.contextMenuStrip_directory.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip_project.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip_cloud
            // 
            this.contextMenuStrip_cloud.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.创建实例ToolStripMenuItem});
            this.contextMenuStrip_cloud.Name = "contextMenuStrip";
            this.contextMenuStrip_cloud.Size = new System.Drawing.Size(125, 26);
            // 
            // 创建实例ToolStripMenuItem
            // 
            this.创建实例ToolStripMenuItem.Name = "创建实例ToolStripMenuItem";
            this.创建实例ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.创建实例ToolStripMenuItem.Text = "创建实例";
            this.创建实例ToolStripMenuItem.Click += new System.EventHandler(this.创建实例ToolStripMenuItem_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "BIMCC_logo.png");
            // 
            // tabPage_cloud
            // 
            this.tabPage_cloud.Controls.Add(this.groupBox1);
            this.tabPage_cloud.Controls.Add(this.listView);
            this.tabPage_cloud.Controls.Add(this.treeView_cloud);
            this.tabPage_cloud.Location = new System.Drawing.Point(4, 22);
            this.tabPage_cloud.Name = "tabPage_cloud";
            this.tabPage_cloud.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_cloud.Size = new System.Drawing.Size(820, 442);
            this.tabPage_cloud.TabIndex = 0;
            this.tabPage_cloud.Text = "    云族库    ";
            this.tabPage_cloud.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(808, 52);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "筛选";
            // 
            // listView
            // 
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.ContextMenuStrip = this.contextMenuStrip_cloud;
            this.listView.LargeImageList = this.imageList;
            this.listView.Location = new System.Drawing.Point(174, 64);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(640, 372);
            this.listView.TabIndex = 1;
            this.listView.UseCompatibleStateImageBehavior = false;
            // 
            // treeView_cloud
            // 
            this.treeView_cloud.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView_cloud.Location = new System.Drawing.Point(6, 64);
            this.treeView_cloud.Name = "treeView_cloud";
            this.treeView_cloud.Size = new System.Drawing.Size(162, 372);
            this.treeView_cloud.TabIndex = 0;
            this.treeView_cloud.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_NodeMouseClick);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPage_cloud);
            this.tabControl.Controls.Add(this.tabPage_local);
            this.tabControl.Controls.Add(this.tabPage_company);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(828, 468);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPage_local
            // 
            this.tabPage_local.Controls.Add(this.button_folder);
            this.tabPage_local.Controls.Add(this.groupBox3);
            this.tabPage_local.Controls.Add(this.groupBox2);
            this.tabPage_local.Location = new System.Drawing.Point(4, 22);
            this.tabPage_local.Name = "tabPage_local";
            this.tabPage_local.Size = new System.Drawing.Size(820, 442);
            this.tabPage_local.TabIndex = 1;
            this.tabPage_local.Text = "    本地族库    ";
            this.tabPage_local.UseVisualStyleBackColor = true;
            // 
            // button_folder
            // 
            this.button_folder.Location = new System.Drawing.Point(10, 26);
            this.button_folder.Name = "button_folder";
            this.button_folder.Size = new System.Drawing.Size(75, 23);
            this.button_folder.TabIndex = 4;
            this.button_folder.Text = "选择文件夹";
            this.button_folder.UseVisualStyleBackColor = true;
            this.button_folder.Click += new System.EventHandler(this.button_folder_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.treeView_directory);
            this.groupBox3.Location = new System.Drawing.Point(91, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(360, 433);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "载入族库";
            // 
            // treeView_directory
            // 
            this.treeView_directory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView_directory.ContextMenuStrip = this.contextMenuStrip_directory;
            this.treeView_directory.Location = new System.Drawing.Point(6, 20);
            this.treeView_directory.Name = "treeView_directory";
            this.treeView_directory.Size = new System.Drawing.Size(348, 407);
            this.treeView_directory.TabIndex = 1;
            // 
            // contextMenuStrip_directory
            // 
            this.contextMenuStrip_directory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.contextMenuStrip_directory.Name = "contextMenuStrip_local";
            this.contextMenuStrip_directory.Size = new System.Drawing.Size(125, 48);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem1.Text = "创建实例";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.directory创建实例toolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem2.Text = "刷新";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.dirctory刷新toolStripMenuItem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.treeView_project);
            this.groupBox2.Location = new System.Drawing.Point(457, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(360, 433);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "项目族库";
            // 
            // treeView_project
            // 
            this.treeView_project.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView_project.ContextMenuStrip = this.contextMenuStrip_project;
            this.treeView_project.Location = new System.Drawing.Point(6, 20);
            this.treeView_project.Name = "treeView_project";
            this.treeView_project.Size = new System.Drawing.Size(348, 407);
            this.treeView_project.TabIndex = 1;
            // 
            // contextMenuStrip_project
            // 
            this.contextMenuStrip_project.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.载入实例ToolStripMenuItem,
            this.刷新ToolStripMenuItem});
            this.contextMenuStrip_project.Name = "contextMenuStrip_local";
            this.contextMenuStrip_project.Size = new System.Drawing.Size(125, 48);
            // 
            // 载入实例ToolStripMenuItem
            // 
            this.载入实例ToolStripMenuItem.Name = "载入实例ToolStripMenuItem";
            this.载入实例ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.载入实例ToolStripMenuItem.Text = "创建实例";
            this.载入实例ToolStripMenuItem.Click += new System.EventHandler(this.project创建实例ToolStripMenuItem_Click);
            // 
            // 刷新ToolStripMenuItem
            // 
            this.刷新ToolStripMenuItem.Name = "刷新ToolStripMenuItem";
            this.刷新ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.刷新ToolStripMenuItem.Text = "刷新";
            this.刷新ToolStripMenuItem.Click += new System.EventHandler(this.project刷新ToolStripMenuItem_Click);
            // 
            // tabPage_company
            // 
            this.tabPage_company.Location = new System.Drawing.Point(4, 22);
            this.tabPage_company.Name = "tabPage_company";
            this.tabPage_company.Size = new System.Drawing.Size(820, 442);
            this.tabPage_company.TabIndex = 2;
            this.tabPage_company.Text = "    企业族库    ";
            this.tabPage_company.UseVisualStyleBackColor = true;
            // 
            // Family_Browser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(852, 492);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "Family_Browser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FamilyBrowser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_browser_FormClosing);
            this.Load += new System.EventHandler(this.Family_public_Load);
            this.contextMenuStrip_cloud.ResumeLayout(false);
            this.tabPage_cloud.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPage_local.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.contextMenuStrip_directory.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.contextMenuStrip_project.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_cloud;
        private System.Windows.Forms.ToolStripMenuItem 创建实例ToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage_cloud;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.TreeView treeView_cloud;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage_local;
        private System.Windows.Forms.TabPage tabPage_company;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView treeView_project;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_project;
        private System.Windows.Forms.ToolStripMenuItem 载入实例ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_folder;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TreeView treeView_directory;
        private System.Windows.Forms.ToolStripMenuItem 刷新ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_directory;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}