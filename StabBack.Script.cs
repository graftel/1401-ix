//--------------------------------------------------------------
// Press F1 to get help about using script.
// To access an object that is not located in the current class, start the call with Globals.
// When using events and timers be cautious not to generate memoryleaks,
// please see the help for more information.
//---------------------------------------------------------------

namespace Neo.ApplicationFramework.Generated
{
    using System.Windows.Forms;
    using System;
    using System.Drawing;
    using Neo.ApplicationFramework.Tools;
    using Neo.ApplicationFramework.Common.Graphics.Logic;
    using Neo.ApplicationFramework.Controls;
    using Neo.ApplicationFramework.Interfaces;
    
    
    public partial class StabBack
    {
		
		void StabBack_Opened(System.Object sender, System.EventArgs e)
		{
			if (Globals.Tags.bStabEnable.Value.Bool)
			{
				Globals.Tags.StabONOFF.Value = 0;
			}
			else
			{
				Globals.Tags.StabONOFF.Value = 1;
			}
		}
		
		void btnON_Click(System.Object sender, System.EventArgs e)
		{
			if (Globals.Tags.bStabEnable.Value.Bool)
			{
				Globals.Tags.bStabEnable.Value = false;
				Globals.Tags.StabONOFF.Value = 1;
			}
			else
			{
				Globals.Tags.bStabEnable.Value = true;
				Globals.Tags.StabONOFF.Value = 0;
			}
			
			Globals.PersistentVariables.SaveRecipe("Current",false);
			
		}
		
		void Button21_Click(System.Object sender, System.EventArgs e)
		{
			Globals.PersistentVariables.SaveRecipe("Current",false);
		}
    }
}
