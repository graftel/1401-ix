//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Neo.ApplicationFramework.Generated
{
	using Neo.ApplicationFramework.Tools.Actions;
	
	
	public partial class StabSettingHigh : Neo.ApplicationFramework.Tools.Recipe.Recipe
	{
		
		private Neo.ApplicationFramework.Tools.Recipe.RecipeItem m_Stability_HIGH_GREEN;
		
		private Neo.ApplicationFramework.Tools.Recipe.RecipeItem m_Stability_HIGH_ORANGE;
		
		private Neo.ApplicationFramework.Tools.Recipe.RecipeItem m_Stability_HIGH_RED;
		
		public StabSettingHigh()
		{
			this.InitializeComponent();
			this.ApplyLanguageInternal();
		}
		
		public Neo.ApplicationFramework.Tools.Recipe.RecipeItem Stability_HIGH_GREEN
		{
			get
			{
				return this.m_Stability_HIGH_GREEN;
			}
			set
			{
				this.m_Stability_HIGH_GREEN = value;
			}
		}
		
		public Neo.ApplicationFramework.Tools.Recipe.RecipeItem Stability_HIGH_ORANGE
		{
			get
			{
				return this.m_Stability_HIGH_ORANGE;
			}
			set
			{
				this.m_Stability_HIGH_ORANGE = value;
			}
		}
		
		public Neo.ApplicationFramework.Tools.Recipe.RecipeItem Stability_HIGH_RED
		{
			get
			{
				return this.m_Stability_HIGH_RED;
			}
			set
			{
				this.m_Stability_HIGH_RED = value;
			}
		}
		
		private void InitializeComponent()
		{
			this.InitializeObjectCreations();
			this.InitializeBeginInits();
			this.InitializeObjects();
			this.InitializeEndInits();
			this.ConnectDataBindings();
		}
		
		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}
		
		[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
		public override void ConnectDataBindings()
		{
			base.ConnectDataBindings();
		}
		
		private void InitializeObjectCreations()
		{
			this.Stability_HIGH_GREEN = new Neo.ApplicationFramework.Tools.Recipe.RecipeItem();
			this.Stability_HIGH_ORANGE = new Neo.ApplicationFramework.Tools.Recipe.RecipeItem();
			this.Stability_HIGH_RED = new Neo.ApplicationFramework.Tools.Recipe.RecipeItem();
		}
		
		private void InitializeBeginInits()
		{
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
		}
		
		private void InitializeEndInits()
		{
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
		}
		
		private void InitializeObjects()
		{
			this.FieldNames.Add("Current");
			this.FieldNames.Add("Default");
			this.Guid = new System.Guid("a4268166-c45d-4257-9398-10493e7c3a9d");
			this.Stability_HIGH_GREEN.ColumnName = "Stability_HIGH_GREEN";
			this.Stability_HIGH_GREEN.DataConnection = "Tags.Stab_high_green";
			this.Stability_HIGH_GREEN.Name = "Stability_HIGH_GREEN";
			this.Stability_HIGH_GREEN.VisualSortOrder = 0;
			this.Stability_HIGH_ORANGE.ColumnName = "Stability_HIGH_ORANGE";
			this.Stability_HIGH_ORANGE.DataConnection = "Tags.Stab_high_orange";
			this.Stability_HIGH_ORANGE.Name = "Stability_HIGH_ORANGE";
			this.Stability_HIGH_ORANGE.VisualSortOrder = 0;
			this.Stability_HIGH_RED.ColumnName = "Stability_HIGH_RED";
			this.Stability_HIGH_RED.DataConnection = "Tags.Stab_high_red";
			this.Stability_HIGH_RED.Name = "Stability_HIGH_RED";
			this.Stability_HIGH_RED.VisualSortOrder = 0;
			this.RecipeItems.Add(this.Stability_HIGH_GREEN);
			this.RecipeItems.Add(this.Stability_HIGH_ORANGE);
			this.RecipeItems.Add(this.Stability_HIGH_RED);
			this.SchemaVersion = ((long)(13));
			this.TableName = "StabSettingHigh";
		}
		
		[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
		private void ApplyLanguageInternal()
		{
			Neo.ApplicationFramework.Tools.MultiLanguage.MultiLanguageResourceManager resources = new Neo.ApplicationFramework.Tools.MultiLanguage.MultiLanguageResourceManager(typeof(StabSettingHigh));
		}
		
		[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
		protected override void ApplyLanguage()
		{
			this.ApplyLanguageInternal();
			base.ApplyLanguage();
		}
	}
}