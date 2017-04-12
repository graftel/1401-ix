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
    
    
    public partial class RcrdDate
    {
		private int countM = 0;
		private int countD = 0;
		private int countY = 0;
		private int countSlashDash = 0;
		
		void RcrdDate_Opened(System.Object sender, System.EventArgs e)
		{
			Updatelbl();
		}
		
		
		void Updatelbl()
		{
			
			lblCurrentDate.Text = DateTime.Now.ToString(Globals.Tags.DateFormat.Value.String);
			lblFormat.Text = Globals.Tags.DateFormat.Value.String.ToUpper();
            
			countM = 0;
            countD = 0;
            countY = 0;
            countSlashDash = 0;


			for (int i = 0; i < Globals.Tags.DateFormat.Value.String.Length; i++)
			{
				if (Globals.Tags.DateFormat.Value.String[i] == 'M')
				{
					countM ++;
				}
				else if (Globals.Tags.DateFormat.Value.String[i] == 'y')
				{
					countY ++;
				}
				else if (Globals.Tags.DateFormat.Value.String[i] == 'd')
				{
					countD ++;
				}
				else if (Globals.Tags.DateFormat.Value.String[i] == '/')
				{
					countSlashDash ++;
				}
				else if (Globals.Tags.DateFormat.Value.String[i] == '-')
				{
					countSlashDash ++;
				}
				
			}
			if (countM == 2)
			{
				btnM.IsEnabled = false;
			}
			else
			{
				btnM.IsEnabled = true;
			}
			
			if (countD == 2)
			{
				btnD.IsEnabled = false;
			}
			else
			{
				btnD.IsEnabled = true;
			}
			
			if (countY == 4)
			{
				btnY.IsEnabled = false;
			}
			else
			{
				btnY.IsEnabled = true;
			}
			
			if (countSlashDash == 2)
			{
				btnSlash.IsEnabled = false;
				btnDash.IsEnabled = false;
			}
			else
			{
				btnSlash.IsEnabled = true;
				btnDash.IsEnabled = true;
			}
		
		}
		
		void btnM_Click(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.DateFormat.Value = Globals.Tags.DateFormat.Value + "M";
			Updatelbl();
		}
		
		void btnD_Click(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.DateFormat.Value = Globals.Tags.DateFormat.Value + "d";
			Updatelbl();
		}
		
		void btnDash_Click(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.DateFormat.Value = Globals.Tags.DateFormat.Value + "-";
			Updatelbl();
		}
		
		void btnSlash_Click(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.DateFormat.Value = Globals.Tags.DateFormat.Value + "/";
			Updatelbl();
		}
		
		void btnY_Click(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.DateFormat.Value = Globals.Tags.DateFormat.Value + "y";
			Updatelbl();
		}
		
		void btnClear_Click(System.Object sender, System.EventArgs e)
		{
			lblCurrentDate.Text = "";
			
			Globals.Tags.DateFormat.Value = "";
			
			lblFormat.Text = "";
			
			btnM.IsEnabled = true;
			btnD.IsEnabled = true;
			btnY.IsEnabled = true;
			btnSlash.IsEnabled = true;
			btnDash.IsEnabled = true;
			
			countM = 0;
			countD = 0;
			countY = 0;
			countSlashDash = 0;
		}
		
		void btnBack_Click(System.Object sender, System.EventArgs e)
		{
			string tmp;
			tmp = Globals.Tags.DateFormat.Value;
			
			if (tmp.Length > 0)
			{
				tmp = tmp.Substring(0,tmp.Length - 1);
			
				Globals.Tags.DateFormat.Value = tmp;
			
				Updatelbl();
			}
		}
		
		void RcrdDate_Closed(System.Object sender, System.EventArgs e)
		{
			Updatelbl();
			if (countM == 0 || countD == 0 || countY ==0)
			{
				Globals.Tags.DateFormat.Value = "MM/dd/yyyy";
			}
			
			Globals.PersistentVariables.SaveRecipe("Current",false);
		}
		
		
    }
}
