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
    
	public partial class popPasscode
	{
		
		void popPasscode_Opened(System.Object sender, System.EventArgs e)
		{
			
			Globals.Tags.Enter_pwd.Value = "";
		}
		
		void btnPass0_Click(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.Enter_pwd.Value = Globals.Tags.Enter_pwd.Value + "0";
		}
		
		void btnPass1_Click(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.Enter_pwd.Value = Globals.Tags.Enter_pwd.Value + "1";
		}
		
		void btnPass2_Click(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.Enter_pwd.Value = Globals.Tags.Enter_pwd.Value + "2";
		}
		
		void btnPass3_Click(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.Enter_pwd.Value = Globals.Tags.Enter_pwd.Value + "3";
		}
		
		void btnPass4_Click(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.Enter_pwd.Value = Globals.Tags.Enter_pwd.Value + "4";
		}
		
		void btnPass5_Click(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.Enter_pwd.Value = Globals.Tags.Enter_pwd.Value + "5";
		}
		
		void btnPass6_Click(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.Enter_pwd.Value = Globals.Tags.Enter_pwd.Value + "6";
		}
		
		void btnPass7_Click(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.Enter_pwd.Value = Globals.Tags.Enter_pwd.Value + "7";
		}
		
		void btnPass8_Click(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.Enter_pwd.Value = Globals.Tags.Enter_pwd.Value + "8";
		}
		
		void btnPass9_Click(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.Enter_pwd.Value = Globals.Tags.Enter_pwd.Value + "9";
		}
		
		void btnPassEnter_Click(System.Object sender, System.EventArgs e)
		{
			if (Globals.Tags.Enter_pwd.Value == Globals.Tags.firmware.Value.String)
			{
				Globals.CalScreen.Show();
			}
			else
			{
				Globals.popWrongPasscode.Show();
			}
		}
		
		void btnPassDel_Click(System.Object sender, System.EventArgs e)
		{
			if (Globals.Tags.Enter_pwd.Value != "")
			{
				string temp = Globals.Tags.Enter_pwd.Value;
				temp = temp.Remove(temp.Length - 1, 1);
				Globals.Tags.Enter_pwd.Value = temp;
			}
		}

	}

}
