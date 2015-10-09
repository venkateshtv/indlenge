namespace APIDownload
{
    partial class tabIndix : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public tabIndix()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.grpIndix = this.Factory.CreateRibbonGroup();
            this.btnDownload = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.grpIndix.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.grpIndix);
            this.tab1.Label = "Indix";
            this.tab1.Name = "tab1";
            // 
            // grpIndix
            // 
            this.grpIndix.Items.Add(this.btnDownload);
            this.grpIndix.Label = "Pricing";
            this.grpIndix.Name = "grpIndix";
            // 
            // btnDownload
            // 
            this.btnDownload.Label = "Download";
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnDownload_Click);
            // 
            // tabIndix
            // 
            this.Name = "tabIndix";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.tabIndix_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.grpIndix.ResumeLayout(false);
            this.grpIndix.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grpIndix;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnDownload;
    }

    partial class ThisRibbonCollection
    {
        internal tabIndix tabIndix
        {
            get { return this.GetRibbon<tabIndix>(); }
        }
    }
}
