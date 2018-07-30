namespace FamilyBrowser
{
    partial class Form_browser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_browser));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.创建实例ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.tabPage_architecture = new System.Windows.Forms.TabPage();
            this.treeView = new System.Windows.Forms.TreeView();
            this.listView = new System.Windows.Forms.ListView();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.contextMenuStrip.SuspendLayout();
            this.tabPage_architecture.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.创建实例ToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(125, 26);
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
            // tabPage_architecture
            // 
            this.tabPage_architecture.Controls.Add(this.listView);
            this.tabPage_architecture.Controls.Add(this.treeView);
            this.tabPage_architecture.Location = new System.Drawing.Point(4, 22);
            this.tabPage_architecture.Name = "tabPage_architecture";
            this.tabPage_architecture.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_architecture.Size = new System.Drawing.Size(820, 442);
            this.tabPage_architecture.TabIndex = 0;
            this.tabPage_architecture.Text = "建筑";
            this.tabPage_architecture.UseVisualStyleBackColor = true;
            // 
            // treeView
            // 
            this.treeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView.Location = new System.Drawing.Point(6, 6);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(162, 430);
            this.treeView.TabIndex = 0;
            this.treeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_NodeMouseClick);
            // 
            // listView
            // 
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.ContextMenuStrip = this.contextMenuStrip;
            this.listView.LargeImageList = this.imageList;
            this.listView.Location = new System.Drawing.Point(174, 6);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(640, 430);
            this.listView.TabIndex = 1;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listView_ItemChecked);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPage_architecture);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(828, 468);
            this.tabControl.TabIndex = 0;
            // 
            // Form_browser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 492);
            this.Controls.Add(this.tabControl);
            this.KeyPreview = true;
            this.Name = "Form_browser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Family_public";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_browser_FormClosing);
            this.Load += new System.EventHandler(this.Family_public_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form_browser_KeyPress);
            this.contextMenuStrip.ResumeLayout(false);
            this.tabPage_architecture.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 创建实例ToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage_architecture;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.TabControl tabControl;
    }
}