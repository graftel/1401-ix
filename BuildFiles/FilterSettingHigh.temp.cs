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
	
	
	public partial class FilterSettingHigh : Neo.ApplicationFramework.Tools.Recipe.Recipe
	{
		
		private Neo.ApplicationFramework.Tools.Recipe.RecipeItem m_Filter_High_UpperLimit;
		
		private Neo.ApplicationFramework.Tools.Recipe.RecipeItem m_Filter_High_Response;
		
		public FilterSettingHigh()
		{
			this.InitializeComponent();
			this.ApplyLanguageInternal();
		}
		
		public Neo.ApplicationFramework.Tools.Recipe.RecipeItem Filter_High_UpperLimit
		{
			get
			{
				return this.m_Filter_High_UpperLimit;
			}
			set
			{
				this.m_Filter_High_UpperLimit = value;
			}
		}
		
		public Neo.ApplicationFramework.Tools.Recipe.RecipeItem Filter_High_Response
		{
			get
			{
				return this.m_Filter_High_Response;
			}
			set
			{
				this.m_Filter_High_Response = value;
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
			this.Filter_High_UpperLimit = new Neo.ApplicationFramework.Tools.Recipe.RecipeItem();
			this.Filter_High_Response = new Neo.ApplicationFramework.Tools.Recipe.RecipeItem();
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
			this.Guid = new System.Guid("16b2c28d-9b4a-49ac-b8e6-07903d4c0ee7");
			this.Filter_High_UpperLimit.ColumnName = "Filter_High_UpperLimit";
			this.Filter_High_UpperLimit.DataConnection = "Tags.FilterUpperLimitHigh";
			this.Filter_High_UpperLimit.Name = "Filter_High_UpperLimit";
			this.Filter_High_UpperLimit.VisualSortOrder = 1;
			this.Filter_High_Response.ColumnName = "Filter_High_Response";
			this.Filter_High_Response.DataConnection = "Tags.FilterResponseHigh";
			this.Filter_High_Response.Name = "Filter_High_Response";
			this.Filter_High_Response.VisualSortOrder = 2;
			this.RecipeItems.Add(this.Filter_High_UpperLimit);
			this.RecipeItems.Add(this.Filter_High_Response);
			this.SchemaVersion = ((long)(7));
			this.TableName = "FilterSettingHigh";
		}
		
		[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
		private void ApplyLanguageInternal()
		{
			Neo.ApplicationFramework.Tools.MultiLanguage.MultiLanguageResourceManager resources = new Neo.ApplicationFramework.Tools.MultiLanguage.MultiLanguageResourceManager(typeof(FilterSettingHigh));
		}
		
		[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
		protected override void ApplyLanguage()
		{
			this.ApplyLanguageInternal();
			base.ApplyLanguage();
		}
	}
}
