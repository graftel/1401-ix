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
    public partial class StartScreen : Neo.ApplicationFramework.Controls.Controls.Form {
        
        private Neo.ApplicationFramework.Controls.Controls.RectangleCF m_Rectangle1;
        
        private Neo.ApplicationFramework.Controls.Controls.RectangleCF m_Rectangle;
        
        private Neo.ApplicationFramework.Controls.Controls.Label m_Text1;
        
        private Neo.ApplicationFramework.Controls.Controls.Label m_Text3;
        
        private Neo.ApplicationFramework.Controls.Symbol.PictureCF m_Picture1;
        
        private Neo.ApplicationFramework.Controls.Controls.Button m_btnStart;
        
        private Neo.ApplicationFramework.Controls.Controls.Label m_Text4;
        
        private Neo.ApplicationFramework.Controls.Controls.Label m_Text5;
        
        private Neo.ApplicationFramework.Controls.Controls.Label m_lblFirmware;
        
        private Neo.ApplicationFramework.Controls.Controls.Label m_Text;
        
        private Neo.ApplicationFramework.Controls.Controls.Label m_Text2;
        
        private Neo.ApplicationFramework.Controls.Symbol.PictureCF m_Picture;
        
        private bool m_Initialized_StartScreen;
        
        private Neo.ApplicationFramework.Common.Dynamics.BrushDynamicsConverterCF brushdynamicsconvertercf1;
        
        public StartScreen() {
            this.InitializeComponent();
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            this.Text4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Text4_MouseDown);
            this.Text5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Text5_MouseDown);
            this.Adapter.Opened += new System.EventHandler(this.StartScreen_Opened);
            this.Opened += new System.EventHandler(this.StartScreen_Action_Opened);
            this.m_btnStart.Click += new System.EventHandler(this.m_btnStart_Action_Click);
            this.m_Text4.MouseDown += new System.EventHandler(this.m_Text4_Action_MouseDown);
            this.m_Text5.MouseDown += new System.EventHandler(this.m_Text5_Action_MouseDown);
            this.ApplyLanguageInitialize();
        }
        
        protected Neo.ApplicationFramework.Controls.Script.ShapeCFAdapter Rectangle1 {
            get {
                return this.AdapterService.CreateAdapter<Neo.ApplicationFramework.Controls.Script.ShapeCFAdapter>(this.m_Rectangle1);
            }
        }
        
        protected Neo.ApplicationFramework.Controls.Script.ShapeCFAdapter Rectangle {
            get {
                return this.AdapterService.CreateAdapter<Neo.ApplicationFramework.Controls.Script.ShapeCFAdapter>(this.m_Rectangle);
            }
        }
        
        protected Neo.ApplicationFramework.Controls.Script.TextControlCFAdapter Text1 {
            get {
                return this.AdapterService.CreateAdapter<Neo.ApplicationFramework.Controls.Script.TextControlCFAdapter>(this.m_Text1);
            }
        }
        
        protected Neo.ApplicationFramework.Controls.Script.TextControlCFAdapter Text3 {
            get {
                return this.AdapterService.CreateAdapter<Neo.ApplicationFramework.Controls.Script.TextControlCFAdapter>(this.m_Text3);
            }
        }
        
        protected Neo.ApplicationFramework.Controls.Script.RenderableCFAdapter Picture1 {
            get {
                return this.AdapterService.CreateAdapter<Neo.ApplicationFramework.Controls.Script.RenderableCFAdapter>(this.m_Picture1);
            }
        }
        
        protected Neo.ApplicationFramework.Controls.Script.ButtonCFAdapter btnStart {
            get {
                return this.AdapterService.CreateAdapter<Neo.ApplicationFramework.Controls.Script.ButtonCFAdapter>(this.m_btnStart);
            }
        }
        
        protected Neo.ApplicationFramework.Controls.Script.TextControlCFAdapter Text4 {
            get {
                return this.AdapterService.CreateAdapter<Neo.ApplicationFramework.Controls.Script.TextControlCFAdapter>(this.m_Text4);
            }
        }
        
        protected Neo.ApplicationFramework.Controls.Script.TextControlCFAdapter Text5 {
            get {
                return this.AdapterService.CreateAdapter<Neo.ApplicationFramework.Controls.Script.TextControlCFAdapter>(this.m_Text5);
            }
        }
        
        protected Neo.ApplicationFramework.Controls.Script.TextControlCFAdapter lblFirmware {
            get {
                return this.AdapterService.CreateAdapter<Neo.ApplicationFramework.Controls.Script.TextControlCFAdapter>(this.m_lblFirmware);
            }
        }
        
        protected Neo.ApplicationFramework.Controls.Script.TextControlCFAdapter Text {
            get {
                return this.AdapterService.CreateAdapter<Neo.ApplicationFramework.Controls.Script.TextControlCFAdapter>(this.m_Text);
            }
        }
        
        protected Neo.ApplicationFramework.Controls.Script.TextControlCFAdapter Text2 {
            get {
                return this.AdapterService.CreateAdapter<Neo.ApplicationFramework.Controls.Script.TextControlCFAdapter>(this.m_Text2);
            }
        }
        
        protected Neo.ApplicationFramework.Controls.Script.RenderableCFAdapter Picture {
            get {
                return this.AdapterService.CreateAdapter<Neo.ApplicationFramework.Controls.Script.RenderableCFAdapter>(this.m_Picture);
            }
        }
        
        private void InitializeComponent() {
            this.brushdynamicsconvertercf1 = new Neo.ApplicationFramework.Common.Dynamics.BrushDynamicsConverterCF();
            Neo.ApplicationFramework.Common.Dynamics.SymbolIntervalMapper symbolintervalmapper1 = new Neo.ApplicationFramework.Common.Dynamics.SymbolIntervalMapper();
            Neo.ApplicationFramework.Common.Dynamics.BrushCFInterval brushcfinterval1 = new Neo.ApplicationFramework.Common.Dynamics.BrushCFInterval();
            Neo.ApplicationFramework.Common.Dynamics.BrushCFInterval brushcfinterval2 = new Neo.ApplicationFramework.Common.Dynamics.BrushCFInterval();
            this.m_Rectangle1 = new Neo.ApplicationFramework.Controls.Controls.RectangleCF();
            this.m_Rectangle = new Neo.ApplicationFramework.Controls.Controls.RectangleCF();
            this.m_Text1 = new Neo.ApplicationFramework.Controls.Controls.Label();
            this.m_Text3 = new Neo.ApplicationFramework.Controls.Controls.Label();
            this.m_Picture1 = new Neo.ApplicationFramework.Controls.Symbol.PictureCF();
            this.m_btnStart = new Neo.ApplicationFramework.Controls.Controls.Button();
            this.m_Text4 = new Neo.ApplicationFramework.Controls.Controls.Label();
            this.m_Text5 = new Neo.ApplicationFramework.Controls.Controls.Label();
            this.m_lblFirmware = new Neo.ApplicationFramework.Controls.Controls.Label();
            this.m_Text = new Neo.ApplicationFramework.Controls.Controls.Label();
            this.m_Text2 = new Neo.ApplicationFramework.Controls.Controls.Label();
            this.m_Picture = new Neo.ApplicationFramework.Controls.Symbol.PictureCF();
            ((System.ComponentModel.ISupportInitialize)(this.m_Text1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_Text3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_Picture1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_Text4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_Text5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_lblFirmware)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_Text)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_Text2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_Picture)).BeginInit();
            this.SuspendLayout();
            // 
            // StartScreen
            // 
            this.Background = new Neo.ApplicationFramework.Common.Graphics.Logic.BrushCF(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.Empty, Neo.ApplicationFramework.Interfaces.FillDirection.None);
            this.BorderStyle = Neo.ApplicationFramework.Interfaces.ScreenBorderStyle.ThreeDBorder;
            this.ControlBox = false;
            // 
            // m_Rectangle1
            // 
            this.m_Rectangle1.BitmapEffect = new Neo.ApplicationFramework.Common.Graphics.Logic.BitmapEffectCF();
            this.m_Rectangle1.BlinkDynamicsValue = false;
            this.m_Rectangle1.EnabledDynamicsValue = true;
            this.m_Rectangle1.Fill = new Neo.ApplicationFramework.Common.Graphics.Logic.BrushCF(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.Empty, Neo.ApplicationFramework.Interfaces.FillDirection.None);
            this.m_Rectangle1.Height = 112;
            this.m_Rectangle1.Left = -14;
            this.m_Rectangle1.Name = "m_Rectangle1";
            this.m_Rectangle1.ScreenOwnerName = "StartScreen";
            this.m_Rectangle1.Stroke = new Neo.ApplicationFramework.Common.Graphics.Logic.BrushCF(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.Empty, Neo.ApplicationFramework.Interfaces.FillDirection.None);
            this.m_Rectangle1.Top = 370;
            this.m_Rectangle1.VisibleDynamicsValue = true;
            this.m_Rectangle1.Width = 813;
            // 
            // m_Rectangle
            // 
            this.m_Rectangle.BitmapEffect = new Neo.ApplicationFramework.Common.Graphics.Logic.BitmapEffectCF();
            this.m_Rectangle.BlinkDynamicsValue = false;
            this.m_Rectangle.EnabledDynamicsValue = true;
            this.m_Rectangle.Fill = new Neo.ApplicationFramework.Common.Graphics.Logic.BrushCF(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.Empty, Neo.ApplicationFramework.Interfaces.FillDirection.None);
            this.m_Rectangle.Height = 128;
            this.m_Rectangle.Left = -12;
            this.m_Rectangle.Name = "m_Rectangle";
            this.m_Rectangle.ScreenOwnerName = "StartScreen";
            this.m_Rectangle.Stroke = new Neo.ApplicationFramework.Common.Graphics.Logic.BrushCF(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.Empty, Neo.ApplicationFramework.Interfaces.FillDirection.None);
            this.m_Rectangle.Top = -2;
            this.m_Rectangle.VisibleDynamicsValue = true;
            this.m_Rectangle.Width = 813;
            // 
            // m_Text1
            // 
            this.m_Text1.BlinkDynamicsValue = false;
            this.m_Text1.EnabledDynamicsValue = true;
            this.m_Text1.FontSizePixels = 46;
            this.m_Text1.Height = 21;
            this.m_Text1.Left = 218;
            this.m_Text1.Name = "m_Text1";
            this.m_Text1.ScreenOwnerName = "StartScreen";
            this.m_Text1.Top = 9;
            this.m_Text1.VisibleDynamicsValue = true;
            this.m_Text1.Width = 120;
            // 
            // m_Text3
            // 
            this.m_Text3.BlinkDynamicsValue = false;
            this.m_Text3.EnabledDynamicsValue = true;
            this.m_Text3.FontSizePixels = 46;
            this.m_Text3.Height = 21;
            this.m_Text3.Left = 175;
            this.m_Text3.Name = "m_Text3";
            this.m_Text3.ScreenOwnerName = "StartScreen";
            this.m_Text3.Top = 64;
            this.m_Text3.VisibleDynamicsValue = true;
            this.m_Text3.Width = 143;
            // 
            // m_Picture1
            // 
            this.m_Picture1.BlinkDynamicsValue = false;
            this.m_Picture1.EnabledDynamicsValue = true;
            this.m_Picture1.Height = 128;
            this.m_Picture1.Left = 21;
            this.m_Picture1.Name = "m_Picture1";
            this.m_Picture1.ScreenOwnerName = "StartScreen";
            this.m_Picture1.Stretch = true;
            this.m_Picture1.SymbolName = "graftel-logo";
            this.m_Picture1.Top = -2;
            this.m_Picture1.VisibleDynamicsValue = true;
            this.m_Picture1.Width = 123;
            // 
            // m_btnStart
            // 
            this.m_btnStart.Background = new Neo.ApplicationFramework.Common.Graphics.Logic.BrushCF(System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227))))), System.Drawing.Color.Empty, Neo.ApplicationFramework.Interfaces.FillDirection.None);
            this.m_btnStart.BlinkDynamicsValue = false;
            this.m_btnStart.Bold = true;
            this.m_btnStart.BorderBrush = new Neo.ApplicationFramework.Common.Graphics.Logic.BrushCF(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))), System.Drawing.Color.Empty, Neo.ApplicationFramework.Interfaces.FillDirection.None);
            this.m_btnStart.BorderThickness = new Neo.ApplicationFramework.Common.Graphics.Logic.ThicknessCF(1D, 1D, 1D, 1D);
            this.m_btnStart.EnabledDynamicsValue = true;
            this.m_btnStart.FontFamily = "Arial";
            this.m_btnStart.FontSizePixels = 26;
            this.m_btnStart.ForceTransparency = true;
            this.m_btnStart.Height = 91;
            this.m_btnStart.IndicatorMargin = null;
            this.m_btnStart.Left = 591;
            this.m_btnStart.Name = "m_btnStart";
            this.m_btnStart.RequiresTransparency = true;
            this.m_btnStart.ScreenOwnerName = "StartScreen";
            this.m_btnStart.StyleName = "Chrome";
            this.m_btnStart.SymbolIntervalMapper = symbolintervalmapper1;
            this.m_btnStart.TextHeight = 32;
            this.m_btnStart.TextValue = 0D;
            this.m_btnStart.TextWidth = 167;
            this.m_btnStart.Top = 377;
            this.m_btnStart.Value = 0D;
            this.m_btnStart.VisibleDynamicsValue = true;
            this.m_btnStart.VisualPropertiesHashCode = -1961266367;
            this.m_btnStart.Width = 173;
            // 
            // m_Text4
            // 
            this.m_Text4.AutoSize = false;
            this.m_Text4.BlinkDynamicsValue = false;
            this.m_Text4.Bold = true;
            this.m_Text4.EnabledDynamicsValue = true;
            this.m_Text4.FontFamily = "Arial";
            this.m_Text4.FontSizePixels = 20;
            this.m_Text4.Height = 51;
            this.m_Text4.Left = 6;
            this.m_Text4.Name = "m_Text4";
            this.m_Text4.ScreenOwnerName = "StartScreen";
            this.m_Text4.Top = 372;
            this.m_Text4.VisibleDynamicsValue = true;
            this.m_Text4.Width = 290;
            // 
            // m_Text5
            // 
            this.m_Text5.AutoSize = false;
            this.m_Text5.BlinkDynamicsValue = false;
            this.m_Text5.BlinkInterval = 2000;
            this.m_Text5.Bold = true;
            brushdynamicsconvertercf1.BrushIntervalMapper.DefaultValue = new Neo.ApplicationFramework.Common.Graphics.Logic.BrushCF(System.Drawing.Color.Green, System.Drawing.Color.Empty, Neo.ApplicationFramework.Interfaces.FillDirection.None);
            brushcfinterval1.Value = new Neo.ApplicationFramework.Common.Graphics.Logic.BrushCF(System.Drawing.Color.Green, System.Drawing.Color.Empty, Neo.ApplicationFramework.Interfaces.FillDirection.None);
            brushcfinterval2.End = 1D;
            brushcfinterval2.Start = 1D;
            brushcfinterval2.Value = new Neo.ApplicationFramework.Common.Graphics.Logic.BrushCF(System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(20)))), ((int)(((byte)(25))))), System.Drawing.Color.Empty, Neo.ApplicationFramework.Interfaces.FillDirection.None);
            brushdynamicsconvertercf1.BrushIntervalMapper.Intervals.Add(brushcfinterval1);
            brushdynamicsconvertercf1.BrushIntervalMapper.Intervals.Add(brushcfinterval2);
            this.m_Text5.EnabledDynamicsValue = true;
            this.m_Text5.FontFamily = "Arial";
            this.m_Text5.FontSizePixels = 40;
            this.m_Text5.Height = 77;
            this.m_Text5.Left = 6;
            this.m_Text5.Name = "m_Text5";
            this.m_Text5.ScreenOwnerName = "StartScreen";
            this.m_Text5.TextHorizontalAlignment = "Center";
            this.m_Text5.Top = 409;
            this.m_Text5.VisibleDynamicsValue = true;
            this.m_Text5.Width = 255;
            // 
            // m_lblFirmware
            // 
            this.m_lblFirmware.AutoSize = false;
            this.m_lblFirmware.BlinkDynamicsValue = false;
            this.m_lblFirmware.Bold = true;
            this.m_lblFirmware.EnabledDynamicsValue = true;
            this.m_lblFirmware.FontFamily = "Arial";
            this.m_lblFirmware.FontSizePixels = 23;
            this.m_lblFirmware.Height = 40;
            this.m_lblFirmware.Left = 265;
            this.m_lblFirmware.Name = "m_lblFirmware";
            this.m_lblFirmware.ScreenOwnerName = "StartScreen";
            this.m_lblFirmware.TextHorizontalAlignment = "Center";
            this.m_lblFirmware.TextVerticalAlignment = "Center";
            this.m_lblFirmware.Top = 374;
            this.m_lblFirmware.VisibleDynamicsValue = true;
            this.m_lblFirmware.Width = 280;
            // 
            // m_Text
            // 
            this.m_Text.AutoSize = false;
            this.m_Text.BlinkDynamicsValue = false;
            this.m_Text.Bold = true;
            this.m_Text.EnabledDynamicsValue = true;
            this.m_Text.FontFamily = "Arial";
            this.m_Text.FontSizePixels = 23;
            this.m_Text.Height = 40;
            this.m_Text.Left = 237;
            this.m_Text.Name = "m_Text";
            this.m_Text.ScreenOwnerName = "StartScreen";
            this.m_Text.TextHorizontalAlignment = "Center";
            this.m_Text.TextVerticalAlignment = "Center";
            this.m_Text.Top = 411;
            this.m_Text.VisibleDynamicsValue = true;
            this.m_Text.Width = 349;
            // 
            // m_Text2
            // 
            this.m_Text2.AutoSize = false;
            this.m_Text2.BlinkDynamicsValue = false;
            this.m_Text2.BlinkInterval = 1500;
            this.m_Text2.EnabledDynamicsValue = true;
            this.m_Text2.FontFamily = "Arial";
            this.m_Text2.FontSizePixels = 20;
            this.m_Text2.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_Text2.Height = 40;
            this.m_Text2.IsBlinkEnabled = true;
            this.m_Text2.Left = 203;
            this.m_Text2.Name = "m_Text2";
            this.m_Text2.ScreenOwnerName = "StartScreen";
            this.m_Text2.TextHorizontalAlignment = "Center";
            this.m_Text2.TextVerticalAlignment = "Center";
            this.m_Text2.Top = 441;
            this.m_Text2.VisibleDynamicsValue = true;
            this.m_Text2.Width = 393;
            // 
            // m_Picture
            // 
            this.m_Picture.BlinkDynamicsValue = false;
            this.m_Picture.EnabledDynamicsValue = true;
            this.m_Picture.Height = 191;
            this.m_Picture.Left = 44;
            this.m_Picture.Name = "m_Picture";
            this.m_Picture.ScreenOwnerName = "StartScreen";
            this.m_Picture.Stretch = true;
            this.m_Picture.SymbolName = "callaway energy center - color";
            this.m_Picture.Top = 147;
            this.m_Picture.VisibleDynamicsValue = true;
            this.m_Picture.Width = 720;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.IsCacheable = true;
            this.Location = new System.Drawing.Point(0, 0);
            this.ModalScreen = true;
            this.Name = "StartScreen";
            this.PopupScreen = false;
            this.ScreenID = null;
            this.ScreenTitle = "";
            this.StyleName = "";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.m_Initialized_StartScreen = true;
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
            if (!m_Initialized_StartScreen) {
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
            this.DrawingPrimitives.Add(this.m_Rectangle1);
            this.DrawingPrimitives.Add(this.m_Rectangle);
            this.DrawingPrimitives.Add(this.m_Text1);
            this.DrawingPrimitives.Add(this.m_Text3);
            this.DrawingPrimitives.Add(this.m_Picture1);
            this.DrawingPrimitives.Add(this.m_btnStart);
            this.DrawingPrimitives.Add(this.m_Text4);
            this.DrawingPrimitives.Add(this.m_Text5);
            this.DrawingPrimitives.Add(this.m_lblFirmware);
            this.DrawingPrimitives.Add(this.m_Text);
            this.DrawingPrimitives.Add(this.m_Text2);
            this.DrawingPrimitives.Add(this.m_Picture);
            ((System.ComponentModel.ISupportInitialize)(this.m_Text1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_Text3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_Picture1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_Text4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_Text5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_lblFirmware)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_Text)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_Text2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_Picture)).EndInit();
        }
        
        private void StartScreen_Action_Opened(object sender, System.EventArgs e) {
            Neo.ApplicationFramework.Generated.Globals.AuditTrailService.LogAction("StartScreen", "Opened", "Set Analog", "Tags.CurrentScreen", "");
            Neo.ApplicationFramework.Generated.Globals.Tags.CurrentScreen.SetAnalog(41);
        }
        
        private void m_btnStart_Action_Click(object sender, System.EventArgs e) {
            Neo.ApplicationFramework.Generated.Globals.AuditTrailService.LogAction("m_btnStart", "Click", "Execute Script", "Buzzer", "");
            Neo.ApplicationFramework.Generated.Globals.Buzzer.Buzz();
            Neo.ApplicationFramework.Generated.Globals.AuditTrailService.LogAction("m_btnStart", "Click", "Show Screen", "MainScreen", "Default", "");
            Neo.ApplicationFramework.Generated.Globals.MainScreen.Show();
            Neo.ApplicationFramework.Generated.Globals.AuditTrailService.LogAction("m_btnStart", "Click", "Set Analog", "Tags.ValveState", "");
            Neo.ApplicationFramework.Generated.Globals.Tags.ValveState.SetAnalog(0);
        }
        
        private void m_Text4_Action_MouseDown(object sender, System.EventArgs e) {
            Neo.ApplicationFramework.Generated.Globals.AuditTrailService.LogAction("m_Text4", "MouseDown", "Execute Script", "Buzzer", "");
            Neo.ApplicationFramework.Generated.Globals.Buzzer.Buzz();
        }
        
        private void m_Text5_Action_MouseDown(object sender, System.EventArgs e) {
            Neo.ApplicationFramework.Generated.Globals.AuditTrailService.LogAction("m_Text5", "MouseDown", "Execute Script", "Buzzer", "");
            Neo.ApplicationFramework.Generated.Globals.Buzzer.Buzz();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private void ApplyLanguageInternal() {
            Neo.ApplicationFramework.Tools.MultiLanguage.MultiLanguageResourceManager resources = new Neo.ApplicationFramework.Tools.MultiLanguage.MultiLanguageResourceManager(typeof(StartScreen));
            this.m_Text1.Text = resources.GetText("StartScreen.Text1.Text", "GRAFTEL MODEL 1401");
            this.m_Text3.Text = resources.GetText("StartScreen.Text3.Text", "LEAKRAGE RATE MONITOR");
            this.m_btnStart.Text = resources.GetText("StartScreen.btnStart.Text", "START");
            this.m_Text4.Text = resources.GetText("StartScreen.Text4.Text", "CALIBRATION DUE DATE");
            this.m_Text5.Text = resources.GetText("StartScreen.Text5.Text", "12/2/2017");
            this.m_Text2.Text = resources.GetText("StartScreen.Text2.Text", "Error! Solenoid Valves Malfunction");
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
            if (!m_Initialized_StartScreen) {
                return;
            }
            base.ApplyLanguageInitialize();
            this.ApplyLanguageInternal();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override void ConnectDataBindings() {
            base.ConnectDataBindings();
            Neo.ApplicationFramework.Common.Data.DynamicBinding dynamicBinding1 = new Neo.ApplicationFramework.Common.Data.DynamicBinding("Text", Neo.ApplicationFramework.Common.Data.DataItemProxyFactory.CreateProxy("Tags.firmware"), "Value", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, new Neo.ApplicationFramework.Common.Dynamics.RawConverterCF("firmware"));
            this.m_lblFirmware.DataBindings.Add(dynamicBinding1);
            this.m_DynamicBindings.Add(dynamicBinding1);
            Neo.ApplicationFramework.Common.Data.DynamicBinding dynamicBinding2 = new Neo.ApplicationFramework.Common.Data.DynamicBinding("VisibleDynamicsValue", Neo.ApplicationFramework.Common.Data.DataItemProxyFactory.CreateProxy("Tags.calDueDateShow"), "Value", true, System.Windows.Forms.DataSourceUpdateMode.Never, Neo.ApplicationFramework.Common.Dynamics.BoolDynamicsConverterCF.TrueValueOne);
            this.m_Text5.DataBindings.Add(dynamicBinding2);
            this.m_DynamicBindings.Add(dynamicBinding2);
            Neo.ApplicationFramework.Common.Data.DynamicBinding dynamicBinding3 = new Neo.ApplicationFramework.Common.Data.DynamicBinding("VisibleDynamicsValue", Neo.ApplicationFramework.Common.Data.DataItemProxyFactory.CreateProxy("Tags.StartScreenErrorMessage"), "Value", true, System.Windows.Forms.DataSourceUpdateMode.Never, Neo.ApplicationFramework.Common.Dynamics.BoolDynamicsConverterCF.TrueValueOne);
            this.m_Text2.DataBindings.Add(dynamicBinding3);
            this.m_DynamicBindings.Add(dynamicBinding3);
            Neo.ApplicationFramework.Common.Data.DynamicBinding dynamicBinding4 = new Neo.ApplicationFramework.Common.Data.DynamicBinding("Text", Neo.ApplicationFramework.Common.Data.DataItemProxyFactory.CreateProxy("Tags.serial"), "Value", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, new Neo.ApplicationFramework.Common.Dynamics.RawConverterCF("zzz"));
            this.m_Text.DataBindings.Add(dynamicBinding4);
            this.m_DynamicBindings.Add(dynamicBinding4);
            Neo.ApplicationFramework.Common.Data.DynamicBinding dynamicBinding5 = new Neo.ApplicationFramework.Common.Data.DynamicBinding("IsBlinkEnabled", Neo.ApplicationFramework.Common.Data.DataItemProxyFactory.CreateProxy("Tags.CalDueDateCheck"), "Value", true, System.Windows.Forms.DataSourceUpdateMode.Never, Neo.ApplicationFramework.Common.Dynamics.BoolDynamicsConverterCF.TrueValueOne);
            this.m_Text5.DataBindings.Add(dynamicBinding5);
            this.m_DynamicBindings.Add(dynamicBinding5);
            Neo.ApplicationFramework.Common.Data.DynamicBinding dynamicBinding6 = new Neo.ApplicationFramework.Common.Data.DynamicBinding("VisibleDynamicsValue", Neo.ApplicationFramework.Common.Data.DataItemProxyFactory.CreateProxy("Tags.calDueDateShow"), "Value", true, System.Windows.Forms.DataSourceUpdateMode.Never, Neo.ApplicationFramework.Common.Dynamics.BoolDynamicsConverterCF.TrueValueOne);
            this.m_Text4.DataBindings.Add(dynamicBinding6);
            this.m_DynamicBindings.Add(dynamicBinding6);
            Neo.ApplicationFramework.Common.Data.DynamicBinding dynamicBinding7 = new Neo.ApplicationFramework.Common.Data.DynamicBinding("EnabledDynamicsValue", Neo.ApplicationFramework.Common.Data.DataItemProxyFactory.CreateProxy("Tags.StartBtnEnable"), "Value", true, System.Windows.Forms.DataSourceUpdateMode.Never, Neo.ApplicationFramework.Common.Dynamics.BoolDynamicsConverterCF.TrueValueOne);
            this.m_btnStart.DataBindings.Add(dynamicBinding7);
            this.m_DynamicBindings.Add(dynamicBinding7);
            Neo.ApplicationFramework.Common.Data.DynamicBinding dynamicBinding8 = new Neo.ApplicationFramework.Common.Data.DynamicBinding("Foreground", Neo.ApplicationFramework.Common.Data.DataItemProxyFactory.CreateProxy("Tags.CalDueDateCheck"), "Value", true, System.Windows.Forms.DataSourceUpdateMode.Never, brushdynamicsconvertercf1);
            this.m_Text5.DataBindings.Add(dynamicBinding8);
            this.m_DynamicBindings.Add(dynamicBinding8);
            Neo.ApplicationFramework.Common.Data.DynamicBinding dynamicBinding9 = new Neo.ApplicationFramework.Common.Data.DynamicBinding("Value", Neo.ApplicationFramework.Common.Data.DataItemProxyFactory.CreateProxy("Tags.calDueDate"), "Value", true, System.Windows.Forms.DataSourceUpdateMode.Never, Neo.ApplicationFramework.Common.Dynamics.VariantValueConverterCF.Default);
            this.m_Text5.DataBindings.Add(dynamicBinding9);
            this.m_DynamicBindings.Add(dynamicBinding9);
        }
    }
}
