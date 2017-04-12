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
    
    
    public partial class RcrdTime
    {
		private int countH = 0;
		private int countM = 0;
		private int countS = 0;
		private int countMaoDash = 0;
		
		
		void RcrdTime_Opened(System.Object sender, System.EventArgs e)
		{
			Updatelbl();
		}
		
		
		void Updatelbl()
		{
			
			try
			{
				lblCurrentTime.Text = DateTime.Now.ToString(Globals.Tags.TimeFormat.Value.String);
			}
			catch
			{
				lblCurrentTime.Text = Globals.Tags.TimeFormat.Value.String.ToUpper();
			}
			lblTimeFormat.Text = Globals.Tags.TimeFormat.Value.String.ToUpper();
            
			countH = 0;
			countM = 0;
			countS = 0;
			countMaoDash = 0;


			for (int i = 0; i < Globals.Tags.TimeFormat.Value.String.Length; i++)
			{
				if (Globals.Tags.TimeFormat.Value.String[i] == 'H')
				{
					countH ++;
				}
				else if (Globals.Tags.TimeFormat.Value.String[i] == 'm')
				{
					countM ++;
				}
				else if (Globals.Tags.TimeFormat.Value.String[i] == 's')
				{
					countS ++;
				}
				else if (Globals.Tags.TimeFormat.Value.String[i] == ':')
				{
					countMaoDash ++;
				}
				else if (Globals.Tags.TimeFormat.Value.String[i] == '-')
				{
					countMaoDash ++;
				}
				
			}
			if (countH == 2)
			{
				btnH.IsEnabled = false;
			}
			else
			{
				btnH.IsEnabled = true;
			}
			
			if (countM == 2)
			{
				btnM.IsEnabled = false;
			}
			else
			{
				btnM.IsEnabled = true;
			}
			
			if (countS == 2)
			{
				btnS.IsEnabled = false;
			}
			else
			{
				btnS.IsEnabled = true;
			}
			
			if (countMaoDash == 2)
			{
				btnMao.IsEnabled = false;
				btnDash.IsEnabled = false;
			}
			else
			{
				btnMao.IsEnabled = true;
				btnDash.IsEnabled = true;
			}
		
		}
		
		void btnM_Click(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.TimeFormat.Value = Globals.Tags.TimeFormat.Value + "m";
			Updatelbl();
		}
		
		void btnH_Click(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.TimeFormat.Value = Globals.Tags.TimeFormat.Value + "H";
			Updatelbl();
		}
		
		void btnS_Click(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.TimeFormat.Value = Globals.Tags.TimeFormat.Value + "s";
			Updatelbl();
		}
		
		void btnMao_Click(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.TimeFormat.Value = Globals.Tags.TimeFormat.Value + ":";
			Updatelbl();
		}
		
		void btnDash_Click(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.TimeFormat.Value = Globals.Tags.TimeFormat.Value + "-";
			Updatelbl();
		}
		
		void btnClear_Click(System.Object sender, System.EventArgs e)
		{
			lblCurrentTime.Text = "";
			
			Globals.Tags.TimeFormat.Value = "";
			
			lblTimeFormat.Text = "";
			
			btnH.IsEnabled = true;
			btnM.IsEnabled = true;
			btnS.IsEnabled = true;
			btnMao.IsEnabled = true;
			btnDash.IsEnabled = true;
			
			countH = 0;
			countM = 0;
			countS = 0;
			countMaoDash = 0;
		}
		
		void btnBack_Click(System.Object sender, System.EventArgs e)
		{
			string tmp;
			tmp = Globals.Tags.TimeFormat.Value;
			
			if (tmp.Length > 0)
			{
				tmp = tmp.Substring(0,tmp.Length - 1);
			
				Globals.Tags.TimeFormat.Value = tmp;
			
				Updatelbl();
			}
		}
		
		void RcrdTime_Closed(System.Object sender, System.EventArgs e)
		{
			Updatelbl();
			if (countH == 0 || countH == 1 || countM == 0 || countS == 0)
			{
				Globals.Tags.TimeFormat.Value = "HH:mm:ss";
			}
			Globals.PersistentVariables.SaveRecipe("Current",false);
		}
		
    }
}
