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
    public partial class Screen1 : Neo.ApplicationFramework.Controls.Controls.Form {
        
        private Neo.ApplicationFramework.Controls.TouchComboBox.TouchComboBoxHostCF m_TouchComboBox;
        
        private Neo.ApplicationFramework.Controls.Controls.AnalogNumeric m_AnalogNumeric;
        
        private Neo.ApplicationFramework.Controls.Controls.AnalogNumeric m_AnalogNumeric1;
        
        private Neo.ApplicationFramework.Controls.Controls.AnalogNumeric m_AnalogNumeric2;
        
        private Neo.ApplicationFramework.Controls.Controls.AnalogNumeric m_AnalogNumeric3;
        
        private Neo.ApplicationFramework.Controls.Controls.Label m_Text;
        
        private Neo.ApplicationFramework.Controls.Controls.Label m_Text1;
        
        private Neo.ApplicationFramework.Controls.Controls.Label m_Text2;
        
        private Neo.ApplicationFramework.Controls.Controls.Label m_Text3;
        
        private Neo.ApplicationFramework.Controls.Controls.Label m_Text4;
        
        private bool m_Initialized_Screen1;
        
        public Screen1() {
            this.InitializeComponent();
            this.ApplyLanguageInitialize();
        }
        
        protected Neo.ApplicationFramework.Controls.Script.TouchComboBoxCFAdapter TouchComboBox {
            get {
                return this.AdapterService.CreateAdapter<Neo.ApplicationFramework.Controls.Script.TouchComboBoxCFAdapter>(this.m_TouchComboBox);
            }
        }
        
        protected Neo.ApplicationFramework.Controls.Script.AnalogNumericCFAdapter AnalogNumeric {
            get {
                return this.AdapterService.CreateAdapter<Neo.ApplicationFramework.Controls.Script.AnalogNumericCFAdapter>(this.m_AnalogNumeric);
            }
        }
        
        protected Neo.ApplicationFramework.Controls.Script.AnalogNumericCFAdapter AnalogNumeric1 {
            get {
                return this.AdapterService.CreateAdapter<Neo.ApplicationFramework.Controls.Script.AnalogNumericCFAdapter>(this.m_AnalogNumeric1);
            }
        }
        
        protected Neo.ApplicationFramework.Controls.Script.AnalogNumericCFAdapter AnalogNumeric2 {
            get {
                return this.AdapterService.CreateAdapter<Neo.ApplicationFramework.Controls.Script.AnalogNumericCFAdapter>(this.m_AnalogNumeric2);
            }
        }
        
        protected Neo.ApplicationFramework.Controls.Script.AnalogNumericCFAdapter AnalogNumeric3 {
            get {
                return this.AdapterService.CreateAdapter<Neo.ApplicationFramework.Controls.Script.AnalogNumericCFAdapter>(this.m_AnalogNumeric3);
            }
        }
        
        protected Neo.ApplicationFramework.Controls.Script.TextControlCFAdapter Text {
            get {
                return this.AdapterService.CreateAdapter<Neo.ApplicationFramework.Controls.Script.TextControlCFAdapter>(this.m_Text);
            }
        }
        
        protected Neo.ApplicationFramework.Controls.Script.TextControlCFAdapter Text1 {
            get {
                return this.AdapterService.CreateAdapter<Neo.ApplicationFramework.Controls.Script.TextControlCFAdapter>(this.m_Text1);
            }
        }
        
        protected Neo.ApplicationFramework.Controls.Script.TextControlCFAdapter Text2 {
            get {
                return this.AdapterService.CreateAdapter<Neo.ApplicationFramework.Controls.Script.TextControlCFAdapter>(this.m_Text2);
            }
        }
        
        protected Neo.ApplicationFramework.Controls.Script.TextControlCFAdapter Text3 {
            get {
                return this.AdapterService.CreateAdapter<Neo.ApplicationFramework.Controls.Script.TextControlCFAdapter>(this.m_Text3);
            }
        }
        
        protected Neo.ApplicationFramework.Controls.Script.TextControlCFAdapter Text4 {
            get {
                return this.AdapterService.CreateAdapter<Neo.ApplicationFramework.Controls.Script.TextControlCFAdapter>(this.m_Text4);
            }
        }
        
        private void InitializeComponent() {
            this.m_TouchComboBox = new Neo.ApplicationFramework.Controls.TouchComboBox.TouchComboBoxHostCF();
            this.m_AnalogNumeric = new Neo.ApplicationFramework.Controls.Controls.AnalogNumeric();
            this.m_AnalogNumeric1 = new Neo.ApplicationFramework.Controls.Controls.AnalogNumeric();
            this.m_AnalogNumeric2 = new Neo.ApplicationFramework.Controls.Controls.AnalogNumeric();
            this.m_AnalogNumeric3 = new Neo.ApplicationFramework.Controls.Controls.AnalogNumeric();
            this.m_Text = new Neo.ApplicationFramework.Controls.Controls.Label();
            this.m_Text1 = new Neo.ApplicationFramework.Controls.Controls.Label();
            this.m_Text2 = new Neo.ApplicationFramework.Controls.Controls.Label();
            this.m_Text3 = new Neo.ApplicationFramework.Controls.Controls.Label();
            this.m_Text4 = new Neo.ApplicationFramework.Controls.Controls.Label();
            ((System.ComponentModel.ISupportInitialize)(this.m_TouchComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_AnalogNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_AnalogNumeric1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_AnalogNumeric2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_AnalogNumeric3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_Text)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_Text1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_Text2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_Text3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_Text4)).BeginInit();
            this.SuspendLayout();
            // 
            // Screen1
            // 
            this.Background = new Neo.ApplicationFramework.Common.Graphics.Logic.BrushCF(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.Empty, Neo.ApplicationFramework.Interfaces.FillDirection.None);
            this.BorderStyle = Neo.ApplicationFramework.Interfaces.ScreenBorderStyle.SingleBorder;
            this.ControlBox = false;
            // 
            // m_TouchComboBox
            // 
            this.m_TouchComboBox.AlternateBackground = new Neo.ApplicationFramework.Common.Graphics.Logic.BrushCF(System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(161)))), ((int)(((byte)(161))))), System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107))))), Neo.ApplicationFramework.Interfaces.FillDirection.VerticalTopToBottom);
            this.m_TouchComboBox.AlternateForeground = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.m_TouchComboBox.ArrowBoxWidth = 30;
            this.m_TouchComboBox.Background = new Neo.ApplicationFramework.Common.Graphics.Logic.BrushCF(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236))))), Neo.ApplicationFramework.Interfaces.FillDirection.VerticalTopToBottom);
            this.m_TouchComboBox.BlinkDynamicsValue = false;
            this.m_TouchComboBox.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.m_TouchComboBox.BorderThickness = 1;
            this.m_TouchComboBox.DelayLoad = false;
            this.m_TouchComboBox.EnabledDynamicsValue = true;
            this.m_TouchComboBox.FontName = "Tahoma";
            this.m_TouchComboBox.FontSize = 12D;
            this.m_TouchComboBox.Foreground = System.Drawing.Color.Black;
            this.m_TouchComboBox.IsSeparatorVisible = true;
            this.m_TouchComboBox.ItemHeight = 30;
            this.m_TouchComboBox.Location = new System.Drawing.Point(59, 85);
            this.m_TouchComboBox.Name = "m_TouchComboBox";
            this.m_TouchComboBox.ScrollBarWidth = 20;
            this.m_TouchComboBox.SelectedBackground = new Neo.ApplicationFramework.Common.Graphics.Logic.BrushCF(System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(136)))), ((int)(((byte)(255))))), System.Drawing.Color.Empty, Neo.ApplicationFramework.Interfaces.FillDirection.None);
            this.m_TouchComboBox.SelectedForeground = System.Drawing.Color.White;
            this.m_TouchComboBox.SelectedItem = null;
            this.m_TouchComboBox.SeparatorColor = System.Drawing.Color.White;
            this.m_TouchComboBox.Size = new System.Drawing.Size(273, 45);
            this.m_TouchComboBox.TabIndex = 2147483647;
            this.m_TouchComboBox.TouchScrollSensitivity = 8;
            this.m_TouchComboBox.VisibleDynamicsValue = true;
            // 
            // m_AnalogNumeric
            // 
            this.m_AnalogNumeric.Background = new Neo.ApplicationFramework.Common.Graphics.Logic.BrushCF(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200))))), Neo.ApplicationFramework.Interfaces.FillDirection.VerticalBottomToTop);
            this.m_AnalogNumeric.BitmapEffect = new Neo.ApplicationFramework.Common.Graphics.Logic.BitmapEffectCF(2, 0, Neo.ApplicationFramework.Common.Graphics.Logic.LightAngle.LowerRight);
            this.m_AnalogNumeric.BlinkDynamicsValue = false;
            this.m_AnalogNumeric.BorderBrush = new Neo.ApplicationFramework.Common.Graphics.Logic.BrushCF(System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185))))), System.Drawing.Color.Empty, Neo.ApplicationFramework.Interfaces.FillDirection.None);
            this.m_AnalogNumeric.BorderThickness = new Neo.ApplicationFramework.Common.Graphics.Logic.ThicknessCF(1D, 1D, 1D, 1D);
            this.m_AnalogNumeric.DisplayFormat = Neo.ApplicationFramework.Interfaces.AnalogNumericDisplayFormat.String;
            this.m_AnalogNumeric.EnabledDynamicsValue = true;
            this.m_AnalogNumeric.FontSizePixels = 20;
            this.m_AnalogNumeric.Height = 46;
            this.m_AnalogNumeric.Left = 417;
            this.m_AnalogNumeric.Name = "m_AnalogNumeric";
            this.m_AnalogNumeric.ScreenOwnerName = "Screen1";
            this.m_AnalogNumeric.Top = 84;
            this.m_AnalogNumeric.VisibleDynamicsValue = true;
            this.m_AnalogNumeric.Width = 269;
            // 
            // m_AnalogNumeric1
            // 
            this.m_AnalogNumeric1.Background = new Neo.ApplicationFramework.Common.Graphics.Logic.BrushCF(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200))))), Neo.ApplicationFramework.Interfaces.FillDirection.VerticalBottomToTop);
            this.m_AnalogNumeric1.BitmapEffect = new Neo.ApplicationFramework.Common.Graphics.Logic.BitmapEffectCF(2, 0, Neo.ApplicationFramework.Common.Graphics.Logic.LightAngle.LowerRight);
            this.m_AnalogNumeric1.BlinkDynamicsValue = false;
            this.m_AnalogNumeric1.BorderBrush = new Neo.ApplicationFramework.Common.Graphics.Logic.BrushCF(System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185))))), System.Drawing.Color.Empty, Neo.ApplicationFramework.Interfaces.FillDirection.None);
            this.m_AnalogNumeric1.BorderThickness = new Neo.ApplicationFramework.Common.Graphics.Logic.ThicknessCF(1D, 1D, 1D, 1D);
            this.m_AnalogNumeric1.DisplayFormat = Neo.ApplicationFramework.Interfaces.AnalogNumericDisplayFormat.String;
            this.m_AnalogNumeric1.EnabledDynamicsValue = true;
            this.m_AnalogNumeric1.FontSizePixels = 20;
            this.m_AnalogNumeric1.Height = 57;
            this.m_AnalogNumeric1.Left = 59;
            this.m_AnalogNumeric1.Name = "m_AnalogNumeric1";
            this.m_AnalogNumeric1.ScreenOwnerName = "Screen1";
            this.m_AnalogNumeric1.Top = 208;
            this.m_AnalogNumeric1.VisibleDynamicsValue = true;
            this.m_AnalogNumeric1.Width = 273;
            // 
            // m_AnalogNumeric2
            // 
            this.m_AnalogNumeric2.Background = new Neo.ApplicationFramework.Common.Graphics.Logic.BrushCF(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200))))), Neo.ApplicationFramework.Interfaces.FillDirection.VerticalBottomToTop);
            this.m_AnalogNumeric2.BitmapEffect = new Neo.ApplicationFramework.Common.Graphics.Logic.BitmapEffectCF(2, 0, Neo.ApplicationFramework.Common.Graphics.Logic.LightAngle.LowerRight);
            this.m_AnalogNumeric2.BlinkDynamicsValue = false;
            this.m_AnalogNumeric2.BorderBrush = new Neo.ApplicationFramework.Common.Graphics.Logic.BrushCF(System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185))))), System.Drawing.Color.Empty, Neo.ApplicationFramework.Interfaces.FillDirection.None);
            this.m_AnalogNumeric2.BorderThickness = new Neo.ApplicationFramework.Common.Graphics.Logic.ThicknessCF(1D, 1D, 1D, 1D);
            this.m_AnalogNumeric2.DisplayFormat = Neo.ApplicationFramework.Interfaces.AnalogNumericDisplayFormat.String;
            this.m_AnalogNumeric2.EnabledDynamicsValue = true;
            this.m_AnalogNumeric2.FontSizePixels = 20;
            this.m_AnalogNumeric2.Height = 57;
            this.m_AnalogNumeric2.Left = 413;
            this.m_AnalogNumeric2.Name = "m_AnalogNumeric2";
            this.m_AnalogNumeric2.ScreenOwnerName = "Screen1";
            this.m_AnalogNumeric2.Top = 208;
            this.m_AnalogNumeric2.VisibleDynamicsValue = true;
            this.m_AnalogNumeric2.Width = 273;
            // 
            // m_AnalogNumeric3
            // 
            this.m_AnalogNumeric3.Background = new Neo.ApplicationFramework.Common.Graphics.Logic.BrushCF(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200))))), Neo.ApplicationFramework.Interfaces.FillDirection.VerticalBottomToTop);
            this.m_AnalogNumeric3.BitmapEffect = new Neo.ApplicationFramework.Common.Graphics.Logic.BitmapEffectCF(2, 0, Neo.ApplicationFramework.Common.Graphics.Logic.LightAngle.LowerRight);
            this.m_AnalogNumeric3.BlinkDynamicsValue = false;
            this.m_AnalogNumeric3.BorderBrush = new Neo.ApplicationFramework.Common.Graphics.Logic.BrushCF(System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185))))), System.Drawing.Color.Empty, Neo.ApplicationFramework.Interfaces.FillDirection.None);
            this.m_AnalogNumeric3.BorderThickness = new Neo.ApplicationFramework.Common.Graphics.Logic.ThicknessCF(1D, 1D, 1D, 1D);
            this.m_AnalogNumeric3.EnabledDynamicsValue = true;
            this.m_AnalogNumeric3.FontSizePixels = 20;
            this.m_AnalogNumeric3.Height = 57;
            this.m_AnalogNumeric3.Left = 234;
            this.m_AnalogNumeric3.Name = "m_AnalogNumeric3";
            this.m_AnalogNumeric3.ScreenOwnerName = "Screen1";
            this.m_AnalogNumeric3.Top = 323;
            this.m_AnalogNumeric3.VisibleDynamicsValue = true;
            this.m_AnalogNumeric3.Width = 273;
            // 
            // m_Text
            // 
            this.m_Text.AutoSize = false;
            this.m_Text.BlinkDynamicsValue = false;
            this.m_Text.EnabledDynamicsValue = true;
            this.m_Text.FontSizePixels = 20;
            this.m_Text.Height = 30;
            this.m_Text.Left = 59;
            this.m_Text.Name = "m_Text";
            this.m_Text.ScreenOwnerName = "Screen1";
            this.m_Text.TextHorizontalAlignment = "Center";
            this.m_Text.TextVerticalAlignment = "Center";
            this.m_Text.Top = 47;
            this.m_Text.VisibleDynamicsValue = true;
            this.m_Text.Width = 273;
            // 
            // m_Text1
            // 
            this.m_Text1.AutoSize = false;
            this.m_Text1.BlinkDynamicsValue = false;
            this.m_Text1.EnabledDynamicsValue = true;
            this.m_Text1.FontSizePixels = 20;
            this.m_Text1.Height = 30;
            this.m_Text1.Left = 413;
            this.m_Text1.Name = "m_Text1";
            this.m_Text1.ScreenOwnerName = "Screen1";
            this.m_Text1.TextHorizontalAlignment = "Center";
            this.m_Text1.TextVerticalAlignment = "Center";
            this.m_Text1.Top = 44;
            this.m_Text1.VisibleDynamicsValue = true;
            this.m_Text1.Width = 273;
            // 
            // m_Text2
            // 
            this.m_Text2.AutoSize = false;
            this.m_Text2.BlinkDynamicsValue = false;
            this.m_Text2.EnabledDynamicsValue = true;
            this.m_Text2.FontSizePixels = 20;
            this.m_Text2.Height = 30;
            this.m_Text2.Left = 59;
            this.m_Text2.Name = "m_Text2";
            this.m_Text2.ScreenOwnerName = "Screen1";
            this.m_Text2.TextHorizontalAlignment = "Center";
            this.m_Text2.TextVerticalAlignment = "Center";
            this.m_Text2.Top = 170;
            this.m_Text2.VisibleDynamicsValue = true;
            this.m_Text2.Width = 273;
            // 
            // m_Text3
            // 
            this.m_Text3.AutoSize = false;
            this.m_Text3.BlinkDynamicsValue = false;
            this.m_Text3.EnabledDynamicsValue = true;
            this.m_Text3.FontSizePixels = 20;
            this.m_Text3.Height = 30;
            this.m_Text3.Left = 413;
            this.m_Text3.Name = "m_Text3";
            this.m_Text3.ScreenOwnerName = "Screen1";
            this.m_Text3.TextHorizontalAlignment = "Center";
            this.m_Text3.TextVerticalAlignment = "Center";
            this.m_Text3.Top = 170;
            this.m_Text3.VisibleDynamicsValue = true;
            this.m_Text3.Width = 273;
            // 
            // m_Text4
            // 
            this.m_Text4.AutoSize = false;
            this.m_Text4.BlinkDynamicsValue = false;
            this.m_Text4.EnabledDynamicsValue = true;
            this.m_Text4.FontSizePixels = 20;
            this.m_Text4.Height = 30;
            this.m_Text4.Left = 234;
            this.m_Text4.Name = "m_Text4";
            this.m_Text4.ScreenOwnerName = "Screen1";
            this.m_Text4.TextHorizontalAlignment = "Center";
            this.m_Text4.TextVerticalAlignment = "Center";
            this.m_Text4.Top = 282;
            this.m_Text4.VisibleDynamicsValue = true;
            this.m_Text4.Width = 273;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.ClientSize = new System.Drawing.Size(762, 431);
            this.IsCacheable = false;
            this.Location = new System.Drawing.Point(18, 10);
            this.ModalScreen = true;
            this.Name = "Screen1";
            this.PopupScreen = true;
            this.ScreenID = null;
            this.ScreenTitle = "Recording Options";
            this.StyleName = "Default";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.m_Initialized_Screen1 = true;
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
            if (!m_Initialized_Screen1) {
                return;
            }
            this.AddControls();
            this.AddDrawingPrimitives();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override void AddControls() {
            this.Controls.Add(this.m_TouchComboBox);
            ((System.ComponentModel.ISupportInitialize)(this.m_TouchComboBox)).EndInit();
            base.AddControls();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override void AddDrawingPrimitives() {
            base.AddDrawingPrimitives();
            this.DrawingPrimitives.Add(this.m_AnalogNumeric);
            this.DrawingPrimitives.Add(this.m_AnalogNumeric1);
            this.DrawingPrimitives.Add(this.m_AnalogNumeric2);
            this.DrawingPrimitives.Add(this.m_AnalogNumeric3);
            this.DrawingPrimitives.Add(this.m_Text);
            this.DrawingPrimitives.Add(this.m_Text1);
            this.DrawingPrimitives.Add(this.m_Text2);
            this.DrawingPrimitives.Add(this.m_Text3);
            this.DrawingPrimitives.Add(this.m_Text4);
            ((System.ComponentModel.ISupportInitialize)(this.m_AnalogNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_AnalogNumeric1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_AnalogNumeric2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_AnalogNumeric3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_Text)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_Text1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_Text2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_Text3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_Text4)).EndInit();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private void ApplyLanguageInternal() {
            Neo.ApplicationFramework.Tools.MultiLanguage.MultiLanguageResourceManager resources = new Neo.ApplicationFramework.Tools.MultiLanguage.MultiLanguageResourceManager(typeof(Screen1));
            this.m_Text.Text = resources.GetText("Screen1.Text.Text", "MODE");
            this.m_Text1.Text = resources.GetText("Screen1.Text1.Text", "LRM ID");
            this.m_Text2.Text = resources.GetText("Screen1.Text2.Text", "TESTER PIN");
            this.m_Text3.Text = resources.GetText("Screen1.Text3.Text", "JOB #");
            this.m_Text4.Text = resources.GetText("Screen1.Text4.Text", "TASK #");
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
            if (!m_Initialized_Screen1) {
                return;
            }
            base.ApplyLanguageInitialize();
            this.ApplyLanguageInternal();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override void ConnectDataBindings() {
            base.ConnectDataBindings();
        }
    }
}
