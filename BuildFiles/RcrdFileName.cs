//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Neo.ApplicationFramework.Generated {
    using Neo.ApplicationFramework.Controls.Controls;
    using Neo.ApplicationFramework.Controls;
    using Neo.ApplicationFramework.Interfaces;
    using Neo.ApplicationFramework.Tools.Security;
    using Neo.ApplicationFramework.Tools.Actions;
    using Neo.ApplicationFramework.Common.MultiLanguage;
    
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class RcrdFileName : BackRcrd {
        
        private Neo.ApplicationFramework.Controls.Controls.Label m_Text12;
        
        private Neo.ApplicationFramework.Controls.Controls.Label m_Text13;
        
        private Neo.ApplicationFramework.Controls.Controls.Button m_Button14;
        
        private Neo.ApplicationFramework.Controls.Controls.Button m_Button16;
        
        private Neo.ApplicationFramework.Controls.Controls.Button m_Button17;
        
        private Neo.ApplicationFramework.Controls.Controls.Line m_Line2;
        
        private Neo.ApplicationFramework.Controls.Controls.Label m_Text18;
        
        private Neo.ApplicationFramework.Controls.Controls.Button m_Button15;
        
        private Neo.ApplicationFramework.Controls.Controls.Label m_Text2;
        
        private Neo.ApplicationFramework.Controls.Controls.Label m_Text;
        
        private bool m_Initialized_RcrdFileName;
        
        public RcrdFileName() {
            this.InitializeComponent();
            this.Button14.Click += new System.EventHandler(this.Button14_Click);
            this.Button17.Click += new System.EventHandler(this.Button17_Click);
            this.Button15.Click += new System.EventHandler(this.Button15_Click);
            this.Adapter.Closed += new System.EventHandler(this.RcrdFileName_Closed);
            this.Opened += new System.EventHandler(this.RcrdFileName_Action_Opened);
            this.m_Button14.Click += new System.EventHandler(this.m_Button14_Action_Click);
            this.m_Button16.Click += new System.EventHandler(this.m_Button16_Action_Click);
            this.m_Button17.Click += new System.EventHandler(this.m_Button17_Action_Click);
            this.m_Button15.Click += new System.EventHandler(this.m_Button15_Action_Click);
            this.ApplyLanguageInitialize();
        }
        
        protected Neo.ApplicationFramework.Controls.Script.TextControlCFAdapter Text12 {
            get {
                return this.AdapterService.CreateAdapter<Neo.ApplicationFramework.Controls.Script.TextControlCFAdapter>(this.m_Text12);
            }
        }
        
        protected Neo.ApplicationFramework.Controls.Script.TextControlCFAdapter Text13 {
            get {
                return this.AdapterService.CreateAdapter<Neo.ApplicationFramework.Controls.Script.TextControlCFAdapter>(this.m_Text13);
            }
        }
        
        protected Neo.ApplicationFramework.Controls.Script.ButtonCFAdapter Button14 {
            get {
                return this.AdapterService.CreateAdapter<Neo.ApplicationFramework.Controls.Script.ButtonCFAdapter>(this.m_Button14);
            }
        }
        
        protected Neo.ApplicationFramework.Controls.Script.ButtonCFAdapter Button16 {
            get {
                return this.AdapterService.CreateAdapter<Neo.ApplicationFramework.Controls.Script.ButtonCFAdapter>(this.m_Button16);
            }
        }
        
        protected Neo.ApplicationFramework.Controls.Script.ButtonCFAdapter Button17 {
            get {
                return this.AdapterService.CreateAdapter<Neo.ApplicationFramework.Controls.Script.ButtonCFAdapter>(this.m_Button17);
            }
        }
        
        protected Neo.ApplicationFramework.Controls.Script.LineCFAdapter Line2 {
            get {
                return this.AdapterService.CreateAdapter<Neo.ApplicationFramework.Controls.Script.LineCFAdapter>(this.m_Line2);
            }
        }
        
        protected Neo.ApplicationFramework.Controls.Script.TextControlCFAdapter Text18 {
            get {
                return this.AdapterService.CreateAdapter<Neo.ApplicationFramework.Controls.Script.TextControlCFAdapter>(this.m_Text18);
            }
        }
        
        protected Neo.ApplicationFramework.Controls.Script.ButtonCFAdapter Button15 {
            get {
                return this.AdapterService.CreateAdapter<Neo.ApplicationFramework.Controls.Script.ButtonCFAdapter>(this.m_Button15);
            }
        }
        
        protected Neo.ApplicationFramework.Controls.Script.TextControlCFAdapter Text2 {
            get {
                return this.AdapterService.CreateAdapter<Neo.ApplicationFramework.Controls.Script.TextControlCFAdapter>(this.m_Text2);
            }
        }
        
        protected Neo.ApplicationFramework.Controls.Script.TextControlCFAdapter Text {
            get {
                return this.AdapterService.CreateAdapter<Neo.ApplicationFramework.Controls.Script.TextControlCFAdapter>(this.m_Text);
            }
        }
        
        private void InitializeComponent() {
            Neo.ApplicationFramework.Common.Dynamics.SymbolIntervalMapper symbolintervalmapper1 = new Neo.ApplicationFramework.Common.Dynamics.SymbolIntervalMapper();
            Neo.ApplicationFramework.Common.Dynamics.SymbolIntervalMapper symbolintervalmapper2 = new Neo.ApplicationFramework.Common.Dynamics.SymbolIntervalMapper();
            Neo.ApplicationFramework.Common.Dynamics.SymbolIntervalMapper symbolintervalmapper3 = new Neo.ApplicationFramework.Common.Dynamics.SymbolIntervalMapper();
            Neo.ApplicationFramework.Common.Dynamics.SymbolIntervalMapper symbolintervalmapper4 = new Neo.ApplicationFramework.Common.Dynamics.SymbolIntervalMapper();
            this.m_Text12 = new Neo.ApplicationFramework.Controls.Controls.Label();
            this.m_Text13 = new Neo.ApplicationFramework.Controls.Controls.Label();
            this.m_Button14 = new Neo.ApplicationFramework.Controls.Controls.Button();
            this.m_Button16 = new Neo.ApplicationFramework.Controls.Controls.Button();
            this.m_Button17 = new Neo.ApplicationFramework.Controls.Controls.Button();
            this.m_Line2 = new Neo.ApplicationFramework.Controls.Controls.Line();
            this.m_Text18 = new Neo.ApplicationFramework.Controls.Controls.Label();
            this.m_Button15 = new Neo.ApplicationFramework.Controls.Controls.Button();
            this.m_Text2 = new Neo.ApplicationFramework.Controls.Controls.Label();
            this.m_Text = new Neo.ApplicationFramework.Controls.Controls.Label();
            ((System.ComponentModel.ISupportInitialize)(this.m_Text12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_Text13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_Button14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_Button16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_Button17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_Text18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_Button15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_Text2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_Text)).BeginInit();
            this.SuspendLayout();
            // 
            // RcrdFileName
            // 
            this.BorderStyle = Neo.ApplicationFramework.Interfaces.ScreenBorderStyle.ThreeDBorder;
            this.ControlBox = false;
            // 
            // m_Text12
            // 
            this.m_Text12.AutoSize = false;
            this.m_Text12.Background = new Neo.ApplicationFramework.Common.Graphics.Logic.BrushCF(System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(237)))), ((int)(((byte)(242))))), System.Drawing.Color.Empty, Neo.ApplicationFramework.Interfaces.FillDirection.None);
            this.m_Text12.BlinkDynamicsValue = false;
            this.m_Text12.EnabledDynamicsValue = true;
            this.m_Text12.FontSizePixels = 30;
            this.m_Text12.Height = 79;
            this.m_Text12.Left = 223;
            this.m_Text12.Name = "m_Text12";
            this.m_Text12.ScreenOwnerName = "RcrdFileName";
            this.m_Text12.TextHorizontalAlignment = "Center";
            this.m_Text12.TextVerticalAlignment = "Center";
            this.m_Text12.Top = 150;
            this.m_Text12.VisibleDynamicsValue = true;
            this.m_Text12.Width = 385;
            // 
            // m_Text13
            // 
            this.m_Text13.AutoSize = false;
            this.m_Text13.Background = new Neo.ApplicationFramework.Common.Graphics.Logic.BrushCF(System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(237)))), ((int)(((byte)(242))))), System.Drawing.Color.Empty, Neo.ApplicationFramework.Interfaces.FillDirection.None);
            this.m_Text13.BlinkDynamicsValue = false;
            this.m_Text13.EnabledDynamicsValue = true;
            this.m_Text13.FontSizePixels = 30;
            this.m_Text13.Height = 79;
            this.m_Text13.Left = 223;
            this.m_Text13.Name = "m_Text13";
            this.m_Text13.ScreenOwnerName = "RcrdFileName";
            this.m_Text13.TextHorizontalAlignment = "Center";
            this.m_Text13.TextVerticalAlignment = "Center";
            this.m_Text13.Top = 261;
            this.m_Text13.VisibleDynamicsValue = true;
            this.m_Text13.Width = 385;
            // 
            // m_Button14
            // 
            this.m_Button14.Background = new Neo.ApplicationFramework.Common.Graphics.Logic.BrushCF(System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(229))))), System.Drawing.Color.Empty, Neo.ApplicationFramework.Interfaces.FillDirection.None);
            this.m_Button14.BlinkDynamicsValue = false;
            this.m_Button14.Bold = true;
            this.m_Button14.BorderBrush = new Neo.ApplicationFramework.Common.Graphics.Logic.BrushCF(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))), System.Drawing.Color.Empty, Neo.ApplicationFramework.Interfaces.FillDirection.None);
            this.m_Button14.BorderThickness = new Neo.ApplicationFramework.Common.Graphics.Logic.ThicknessCF(2D, 2D, 2D, 2D);
            this.m_Button14.EnabledDynamicsValue = true;
            this.m_Button14.FontFamily = "Arial";
            this.m_Button14.FontSizePixels = 26;
            this.m_Button14.ForceTransparency = true;
            this.m_Button14.Height = 79;
            this.m_Button14.IndicatorMargin = null;
            this.m_Button14.Left = 621;
            this.m_Button14.Name = "m_Button14";
            this.m_Button14.RequiresTransparency = true;
            this.m_Button14.ScreenOwnerName = "RcrdFileName";
            this.m_Button14.StyleName = "Glossy";
            this.m_Button14.SymbolIntervalMapper = symbolintervalmapper1;
            this.m_Button14.TextHeight = 32;
            this.m_Button14.TextValue = 0D;
            this.m_Button14.TextWidth = 154;
            this.m_Button14.Top = 150;
            this.m_Button14.Value = 0D;
            this.m_Button14.VisibleDynamicsValue = true;
            this.m_Button14.VisualPropertiesHashCode = -1271751849;
            this.m_Button14.Width = 160;
            // 
            // m_Button16
            // 
            this.m_Button16.Background = new Neo.ApplicationFramework.Common.Graphics.Logic.BrushCF(System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(229))))), System.Drawing.Color.Empty, Neo.ApplicationFramework.Interfaces.FillDirection.None);
            this.m_Button16.BlinkDynamicsValue = false;
            this.m_Button16.Bold = true;
            this.m_Button16.BorderBrush = new Neo.ApplicationFramework.Common.Graphics.Logic.BrushCF(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))), System.Drawing.Color.Empty, Neo.ApplicationFramework.Interfaces.FillDirection.None);
            this.m_Button16.BorderThickness = new Neo.ApplicationFramework.Common.Graphics.Logic.ThicknessCF(2D, 2D, 2D, 2D);
            this.m_Button16.EnabledDynamicsValue = true;
            this.m_Button16.FontSizePixels = 26;
            this.m_Button16.ForceTransparency = true;
            this.m_Button16.Height = 88;
            this.m_Button16.IndicatorMargin = null;
            this.m_Button16.Left = 223;
            this.m_Button16.Name = "m_Button16";
            this.m_Button16.RequiresTransparency = true;
            this.m_Button16.ScreenOwnerName = "RcrdFileName";
            this.m_Button16.StyleName = "Glossy";
            this.m_Button16.SymbolIntervalMapper = symbolintervalmapper2;
            this.m_Button16.TextHeight = 31;
            this.m_Button16.TextValue = 0D;
            this.m_Button16.TextWidth = 250;
            this.m_Button16.Top = 365;
            this.m_Button16.Value = 0D;
            this.m_Button16.VisibleDynamicsValue = true;
            this.m_Button16.VisualPropertiesHashCode = -1139217449;
            this.m_Button16.Width = 256;
            // 
            // m_Button17
            // 
            this.m_Button17.Background = new Neo.ApplicationFramework.Common.Graphics.Logic.BrushCF(System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(229))))), System.Drawing.Color.Empty, Neo.ApplicationFramework.Interfaces.FillDirection.None);
            this.m_Button17.BlinkDynamicsValue = false;
            this.m_Button17.Bold = true;
            this.m_Button17.BorderBrush = new Neo.ApplicationFramework.Common.Graphics.Logic.BrushCF(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))), System.Drawing.Color.Empty, Neo.ApplicationFramework.Interfaces.FillDirection.None);
            this.m_Button17.BorderThickness = new Neo.ApplicationFramework.Common.Graphics.Logic.ThicknessCF(2D, 2D, 2D, 2D);
            this.m_Button17.EnabledDynamicsValue = true;
            this.m_Button17.FontSizePixels = 26;
            this.m_Button17.ForceTransparency = true;
            this.m_Button17.Height = 88;
            this.m_Button17.IndicatorMargin = null;
            this.m_Button17.Left = 510;
            this.m_Button17.Name = "m_Button17";
            this.m_Button17.RequiresTransparency = true;
            this.m_Button17.ScreenOwnerName = "RcrdFileName";
            this.m_Button17.StyleName = "Glossy";
            this.m_Button17.SymbolIntervalMapper = symbolintervalmapper3;
            this.m_Button17.TextHeight = 31;
            this.m_Button17.TextValue = 0D;
            this.m_Button17.TextWidth = 265;
            this.m_Button17.Top = 365;
            this.m_Button17.Value = 0D;
            this.m_Button17.VisibleDynamicsValue = true;
            this.m_Button17.VisualPropertiesHashCode = -748615786;
            this.m_Button17.Width = 271;
            // 
            // m_Line2
            // 
            this.m_Line2.BlinkDynamicsValue = false;
            this.m_Line2.EnabledDynamicsValue = true;
            this.m_Line2.Fill = null;
            this.m_Line2.Name = "m_Line2";
            this.m_Line2.ScreenOwnerName = "RcrdFileName";
            this.m_Line2.Stroke = new Neo.ApplicationFramework.Common.Graphics.Logic.BrushCF(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))), System.Drawing.Color.Empty, Neo.ApplicationFramework.Interfaces.FillDirection.None);
            this.m_Line2.VisibleDynamicsValue = true;
            this.m_Line2.X1 = 223;
            this.m_Line2.X2 = 781;
            this.m_Line2.Y1 = 119;
            this.m_Line2.Y2 = 119;
            // 
            // m_Text18
            // 
            this.m_Text18.AutoSize = false;
            this.m_Text18.BlinkDynamicsValue = false;
            this.m_Text18.EnabledDynamicsValue = true;
            this.m_Text18.FontFamily = "Arial";
            this.m_Text18.FontSizePixels = 23;
            this.m_Text18.Height = 54;
            this.m_Text18.Left = 346;
            this.m_Text18.Name = "m_Text18";
            this.m_Text18.ScreenOwnerName = "RcrdFileName";
            this.m_Text18.TextVerticalAlignment = "Center";
            this.m_Text18.Top = 215;
            this.m_Text18.VisibleDynamicsValue = true;
            this.m_Text18.Width = 198;
            // 
            // m_Button15
            // 
            this.m_Button15.Background = new Neo.ApplicationFramework.Common.Graphics.Logic.BrushCF(System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(229))))), System.Drawing.Color.Empty, Neo.ApplicationFramework.Interfaces.FillDirection.None);
            this.m_Button15.BlinkDynamicsValue = false;
            this.m_Button15.Bold = true;
            this.m_Button15.BorderBrush = new Neo.ApplicationFramework.Common.Graphics.Logic.BrushCF(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))), System.Drawing.Color.Empty, Neo.ApplicationFramework.Interfaces.FillDirection.None);
            this.m_Button15.BorderThickness = new Neo.ApplicationFramework.Common.Graphics.Logic.ThicknessCF(2D, 2D, 2D, 2D);
            this.m_Button15.EnabledDynamicsValue = true;
            this.m_Button15.FontFamily = "Arial";
            this.m_Button15.FontSizePixels = 26;
            this.m_Button15.ForceTransparency = true;
            this.m_Button15.Height = 79;
            this.m_Button15.IndicatorMargin = null;
            this.m_Button15.Left = 621;
            this.m_Button15.Name = "m_Button15";
            this.m_Button15.RequiresTransparency = true;
            this.m_Button15.ScreenOwnerName = "RcrdFileName";
            this.m_Button15.StyleName = "Glossy";
            this.m_Button15.SymbolIntervalMapper = symbolintervalmapper4;
            this.m_Button15.TextHeight = 32;
            this.m_Button15.TextValue = 0D;
            this.m_Button15.TextWidth = 154;
            this.m_Button15.Top = 261;
            this.m_Button15.Value = 0D;
            this.m_Button15.VisibleDynamicsValue = true;
            this.m_Button15.VisualPropertiesHashCode = -1271751849;
            this.m_Button15.Width = 160;
            // 
            // m_Text2
            // 
            this.m_Text2.AutoSize = false;
            this.m_Text2.BlinkDynamicsValue = false;
            this.m_Text2.EnabledDynamicsValue = true;
            this.m_Text2.FontFamily = "Arial";
            this.m_Text2.FontSizePixels = 30;
            this.m_Text2.Height = 47;
            this.m_Text2.Left = 211;
            this.m_Text2.Name = "m_Text2";
            this.m_Text2.ScreenOwnerName = "RcrdFileName";
            this.m_Text2.TextHorizontalAlignment = "Center";
            this.m_Text2.TextVerticalAlignment = "Center";
            this.m_Text2.Top = 67;
            this.m_Text2.VisibleDynamicsValue = true;
            this.m_Text2.Width = 213;
            // 
            // m_Text
            // 
            this.m_Text.AutoSize = false;
            this.m_Text.BlinkDynamicsValue = false;
            this.m_Text.EnabledDynamicsValue = true;
            this.m_Text.FontFamily = "Arial";
            this.m_Text.FontSizePixels = 23;
            this.m_Text.Height = 54;
            this.m_Text.Left = 281;
            this.m_Text.Name = "m_Text";
            this.m_Text.ScreenOwnerName = "RcrdFileName";
            this.m_Text.TextHorizontalAlignment = "Center";
            this.m_Text.TextVerticalAlignment = "Center";
            this.m_Text.Top = 105;
            this.m_Text.VisibleDynamicsValue = true;
            this.m_Text.Width = 276;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.IsCacheable = true;
            this.Location = new System.Drawing.Point(0, 0);
            this.ModalScreen = true;
            this.Name = "RcrdFileName";
            this.PopupScreen = false;
            this.ScreenID = null;
            this.ScreenTitle = "";
            this.StyleName = "";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.m_Initialized_RcrdFileName = true;
            this.AddControlsAndPrimitives();
            this.ResumeLayout(false);
        }
        
        protected override Neo.ApplicationFramework.Common.Alias.Entities.AliasInstancesCF CreateInstanceData() {
            System.Collections.Generic.List<Neo.ApplicationFramework.Common.Alias.Entities.AliasInstanceCF> instanceList = new System.Collections.Generic.List<Neo.ApplicationFramework.Common.Alias.Entities.AliasInstanceCF>(1);
            instanceList.Add(this.CreateInstanceData_Default());
            Neo.ApplicationFramework.Common.Alias.Entities.AliasInstancesCF aliasInstances = new Neo.ApplicationFramework.Common.Alias.Entities.AliasInstancesCF();
            aliasInstances.Instances = instanceList.ToArray();
            return aliasInstances;
        }
        
        private Neo.ApplicationFramework.Common.Alias.Entities.AliasInstanceCF CreateInstanceData_Default() {
            Neo.ApplicationFramework.Common.Alias.Entities.AliasInstanceCF aliasinstancecf1 = new Neo.ApplicationFramework.Common.Alias.Entities.AliasInstanceCF();
            aliasinstancecf1.Name = "Default";
            aliasinstancecf1.Values = new Neo.ApplicationFramework.Common.Alias.Entities.AliasValueCF[0];
            return aliasinstancecf1;
        }
        
        protected override void BindAliases() {
        }
        
        protected override void Dispose(bool disposing) {
            base.Dispose(disposing);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override void AddControlsAndPrimitives() {
            if (!m_Initialized_RcrdFileName) {
                return;
            }
            this.AddControls();
            this.AddDrawingPrimitives();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override void AddControls() {
            base.AddControls();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override void AddDrawingPrimitives() {
            base.AddDrawingPrimitives();
            this.DrawingPrimitives.Add(this.m_Text12);
            this.DrawingPrimitives.Add(this.m_Text13);
            this.DrawingPrimitives.Add(this.m_Button14);
            this.DrawingPrimitives.Add(this.m_Button16);
            this.DrawingPrimitives.Add(this.m_Button17);
            this.DrawingPrimitives.Add(this.m_Line2);
            this.DrawingPrimitives.Add(this.m_Text18);
            this.DrawingPrimitives.Add(this.m_Button15);
            this.DrawingPrimitives.Add(this.m_Text2);
            this.DrawingPrimitives.Add(this.m_Text);
            ((System.ComponentModel.ISupportInitialize)(this.m_Text12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_Text13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_Button14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_Button16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_Button17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_Text18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_Button15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_Text2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_Text)).EndInit();
        }
        
        private void RcrdFileName_Action_Opened(object sender, System.EventArgs e) {
            Neo.ApplicationFramework.Generated.Globals.AuditTrailService.LogAction("RcrdFileName", "Opened", "Set Analog", "Tags.CurrentScreen", "");
            Neo.ApplicationFramework.Generated.Globals.Tags.CurrentScreen.SetAnalog(31);
        }
        
        private void m_Button14_Action_Click(object sender, System.EventArgs e) {
            Neo.ApplicationFramework.Generated.Globals.AuditTrailService.LogAction("m_Button14", "Click", "Execute Script", "Buzzer", "");
            Neo.ApplicationFramework.Generated.Globals.Buzzer.Buzz();
        }
        
        private void m_Button16_Action_Click(object sender, System.EventArgs e) {
            Neo.ApplicationFramework.Generated.Globals.AuditTrailService.LogAction("m_Button16", "Click", "Execute Script", "Buzzer", "");
            Neo.ApplicationFramework.Generated.Globals.Buzzer.Buzz();
            Neo.ApplicationFramework.Generated.Globals.AuditTrailService.LogAction("m_Button16", "Click", "Show Screen", "SelectData", "Default", "");
            Neo.ApplicationFramework.Generated.Globals.SelectData.Show();
        }
        
        private void m_Button17_Action_Click(object sender, System.EventArgs e) {
            Neo.ApplicationFramework.Generated.Globals.AuditTrailService.LogAction("m_Button17", "Click", "Execute Script", "Buzzer", "");
            Neo.ApplicationFramework.Generated.Globals.Buzzer.Buzz();
        }
        
        private void m_Button15_Action_Click(object sender, System.EventArgs e) {
            Neo.ApplicationFramework.Generated.Globals.AuditTrailService.LogAction("m_Button15", "Click", "Execute Script", "Buzzer", "");
            Neo.ApplicationFramework.Generated.Globals.Buzzer.Buzz();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private void ApplyLanguageInternal() {
            Neo.ApplicationFramework.Tools.MultiLanguage.MultiLanguageResourceManager resources = new Neo.ApplicationFramework.Tools.MultiLanguage.MultiLanguageResourceManager(typeof(RcrdFileName));
            this.m_Text12.Text = resources.GetText("RcrdFileName.Text12.Text", "Text");
            this.m_Text13.Text = resources.GetText("RcrdFileName.Text13.Text", "Text");
            this.m_Button14.Text = resources.GetText("RcrdFileName.Button14.Text", "Select");
            this.m_Button16.Text = resources.GetText("RcrdFileName.Button16.Text", "Show Data");
            this.m_Button17.Text = resources.GetText("RcrdFileName.Button17.Text", "Show Files (USB)");
            this.m_Text18.Text = resources.GetText("RcrdFileName.Text18.Text", "Tester Initial");
            this.m_Button15.Text = resources.GetText("RcrdFileName.Button15.Text", "Select");
            this.m_Text2.Text = resources.GetText("RcrdFileName.Text2.Text", "File and Data");
            this.m_Text.Text = resources.GetText("RcrdFileName.Text.Text", "Recording File Name");
            this.ApplyResourcesOnForm();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        protected override void ApplyLanguage() {
            if (((Neo.ApplicationFramework.Interfaces.IScreen)(this)).IsCachedDeactivated) {
                return;
            }
            this.ApplyLanguageInternal();
            base.ApplyLanguage();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override void ApplyLanguageInitialize() {
            if (!m_Initialized_RcrdFileName) {
                return;
            }
            base.ApplyLanguageInitialize();
            this.ApplyLanguageInternal();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override void ConnectDataBindings() {
            base.ConnectDataBindings();
            Neo.ApplicationFramework.Common.Data.DynamicBinding dynamicBinding1 = new Neo.ApplicationFramework.Common.Data.DynamicBinding("Value", Neo.ApplicationFramework.Common.Data.DataItemProxyFactory.CreateProxy("Tags.Selected_TesterInitial"), "Value", true, System.Windows.Forms.DataSourceUpdateMode.Never, Neo.ApplicationFramework.Common.Dynamics.VariantValueConverterCF.Default);
            this.m_Text13.DataBindings.Add(dynamicBinding1);
            this.m_DynamicBindings.Add(dynamicBinding1);
            Neo.ApplicationFramework.Common.Data.DynamicBinding dynamicBinding2 = new Neo.ApplicationFramework.Common.Data.DynamicBinding("Value", Neo.ApplicationFramework.Common.Data.DataItemProxyFactory.CreateProxy("Tags.Selected_FileName"), "Value", true, System.Windows.Forms.DataSourceUpdateMode.Never, Neo.ApplicationFramework.Common.Dynamics.VariantValueConverterCF.Default);
            this.m_Text12.DataBindings.Add(dynamicBinding2);
            this.m_DynamicBindings.Add(dynamicBinding2);
        }
    }
}
