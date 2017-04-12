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
	using System.IO;
    
    public partial class RcrdFileName
    {
		
		void Button14_Click(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.SelectType.Value = 0;
			Globals.SelectFileName.Show();
		}
		
		void Button15_Click(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.SelectType.Value = 1;
			Globals.SelectFileName.Show();
		}
		
		void RcrdFileName_Closed(System.Object sender, System.EventArgs e)
		{
			Globals.PersistentVariables.SaveRecipe("Current",false);
		}
		
		void Button17_Click(System.Object sender, System.EventArgs e)
		{
			if(Directory.Exists("\\Hard Disk"))
			{
				Globals.ShowFile.Show();
			}
			else
			{
				Globals.Tags.GeneralMessage.Value = "Please insert a valid USB drive";
				Globals.GeneralMsgBox.Show();
			}
		}
		
		
    }
}
