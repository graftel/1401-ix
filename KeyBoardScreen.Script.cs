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
    
    
    public partial class KeyBoardScreen
    {
		
		void Button_Click(System.Object sender, System.EventArgs e)
		{
			if (AnalogNumeric.Value.ToString().Contains("\\") || 
				AnalogNumeric.Value.ToString().Contains("/") || 
				AnalogNumeric.Value.ToString().Contains("<") || 
				AnalogNumeric.Value.ToString().Contains(">") || 
				AnalogNumeric.Value.ToString().Contains(":") || 
				AnalogNumeric.Value.ToString().Contains("\"") || 
				AnalogNumeric.Value.ToString().Contains("|") || 
				AnalogNumeric.Value.ToString().Contains("?") || 
				AnalogNumeric.Value.ToString().Contains("*"))
			{
				Globals.Tags.GeneralMessage.Value = "Cannot contain any of the following characters: \\ / < > : \" | ? *";
				Globals.GeneralMsgBox.Show();
			}
			else if (AnalogNumeric.Value.ToString() == "")
			{
				Globals.Tags.GeneralMessage.Value = "Input name Cannot be empty";
				Globals.GeneralMsgBox.Show();
			}
			else
			{
				if ((int)Globals.Tags.SelectType.Value == 0)
				{
					if(CheckRepeat(AnalogNumeric.Value.ToString(),Globals.Tags.strFileNameList.Value.String))
					{
						Globals.Tags.GeneralMessage.Value = "Input name already exists";
						Globals.GeneralMsgBox.Show();
					}
					else
					{
						Globals.Tags.valueChanged.Value = 1;
						Globals.Tags.strFileNameList.Value = Globals.Tags.strFileNameList.Value.String + "," + AnalogNumeric.Value.ToString();
						Globals.KeyBoardScreen.Close();
					}
				}
				else
				{
					if(CheckRepeat(AnalogNumeric.Value.ToString(),Globals.Tags.strTesterInitialList.Value.String))
					{
						Globals.Tags.GeneralMessage.Value = "Input name already exists";
						Globals.GeneralMsgBox.Show();
					}
					else
					{
						Globals.Tags.valueChanged.Value = 1;
						Globals.Tags.strTesterInitialList.Value = Globals.Tags.strTesterInitialList.Value.String + "," + AnalogNumeric.Value.ToString();
						Globals.KeyBoardScreen.Close();
					}
					
					
				}

			}
			
		}
		
		
		private bool CheckRepeat(string input, string toCheck)
		{
			bool result = false;
			
			string[] tmp = toCheck.Split(',');
			
			foreach (string strA in tmp)
			{
				if (input == strA)
				{
					result = true;
				}
			}
			
			return result;
			
		}
		
		
    }
}
