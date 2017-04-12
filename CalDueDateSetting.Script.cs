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
    
    
    public partial class CalDueDateSetting
    {
		
		void CalDueDateSetting_Opened(System.Object sender, System.EventArgs e)
		{
			DateTime dueDate = Globals.Tags.calDueDatePers.Value.DateTime;
			
			Globals.Tags.DisplayDay.Value = dueDate.Day;
			Globals.Tags.DisplayMonth.Value = dueDate.Month;
			Globals.Tags.DisplayYear.Value = dueDate.Year;
			
			Globals.Tags.CurrentDayInMonth.Value = DateTime.DaysInMonth((int)Globals.Tags.DisplayYear.Value, (int)Globals.Tags.DisplayMonth.Value);
		}
		
		void Button7_Click(System.Object sender, System.EventArgs e)
		{
			if ((int)Globals.Tags.DisplayMonth.Value < 12)
			{
				Globals.Tags.DisplayMonth.Value = (int)Globals.Tags.DisplayMonth.Value + 1;
			}
			else if ((int)Globals.Tags.DisplayMonth.Value == 12)
			{
				Globals.Tags.DisplayMonth.Value = 1;
				if ((int)Globals.Tags.DisplayYear.Value < 2100)
				{
					Globals.Tags.DisplayYear.Value = (int)Globals.Tags.DisplayYear.Value + 1;
				}
				else if ((int)Globals.Tags.DisplayYear.Value == 2100)
				{
					Globals.Tags.DisplayYear.Value = 2000;
				}
			}
			
			Globals.Tags.CurrentDayInMonth.Value = DateTime.DaysInMonth((int)Globals.Tags.DisplayYear.Value, (int)Globals.Tags.DisplayMonth.Value);
		}
		
		void Button_Click(System.Object sender, System.EventArgs e)
		{
			if ((int)Globals.Tags.DisplayMonth.Value > 1)
			{
				Globals.Tags.DisplayMonth.Value = (int)Globals.Tags.DisplayMonth.Value - 1;
			}
			else if ((int)Globals.Tags.DisplayMonth.Value == 1)
			{
				Globals.Tags.DisplayMonth.Value = 12;
				if ((int)Globals.Tags.DisplayYear.Value > 2000)
				{
					Globals.Tags.DisplayYear.Value = (int)Globals.Tags.DisplayYear.Value - 1;
				}
				else if ((int)Globals.Tags.DisplayYear.Value == 2000)
				{
					Globals.Tags.DisplayYear.Value = 2100;
				}
			}
			
			Globals.Tags.CurrentDayInMonth.Value = DateTime.DaysInMonth((int)Globals.Tags.DisplayYear.Value, (int)Globals.Tags.DisplayMonth.Value);
		}
		
		void Button1_Click(System.Object sender, System.EventArgs e)
		{
			if ((int)Globals.Tags.DisplayDay.Value < (int)Globals.Tags.CurrentDayInMonth.Value)
			{
				Globals.Tags.DisplayDay.Value = (int)Globals.Tags.DisplayDay.Value + 1;
			}
			else if ((int)Globals.Tags.DisplayDay.Value == (int)Globals.Tags.CurrentDayInMonth.Value)
			{
				Globals.Tags.DisplayDay.Value = 1;
				if ((int)Globals.Tags.DisplayMonth.Value < 12)
				{
					Globals.Tags.DisplayMonth.Value = (int)Globals.Tags.DisplayMonth.Value + 1;
				}
				else if ((int)Globals.Tags.DisplayMonth.Value == 12)
				{
					Globals.Tags.DisplayMonth.Value = 1;
					if ((int)Globals.Tags.DisplayYear.Value < 2100)
					{
						Globals.Tags.DisplayYear.Value = (int)Globals.Tags.DisplayYear.Value + 1;
					}
					else if ((int)Globals.Tags.DisplayYear.Value == 2100)
					{
						Globals.Tags.DisplayYear.Value = 2000;
					}
				}
			}
			
			Globals.Tags.CurrentDayInMonth.Value = DateTime.DaysInMonth((int)Globals.Tags.DisplayYear.Value, (int)Globals.Tags.DisplayMonth.Value);
		}
		
		void Button2_Click(System.Object sender, System.EventArgs e)
		{
			if ((int)Globals.Tags.DisplayDay.Value > 1)
			{
				Globals.Tags.DisplayDay.Value = (int)Globals.Tags.DisplayDay.Value - 1;
			}
			else if ((int)Globals.Tags.DisplayDay.Value == 1)
			{
				
				if ((int)Globals.Tags.DisplayMonth.Value > 1)
				{
					Globals.Tags.DisplayMonth.Value = (int)Globals.Tags.DisplayMonth.Value - 1;
				}
				else if ((int)Globals.Tags.DisplayMonth.Value == 1)
				{
					Globals.Tags.DisplayMonth.Value = 12;
					if ((int)Globals.Tags.DisplayYear.Value > 2000)
					{
						Globals.Tags.DisplayYear.Value = (int)Globals.Tags.DisplayYear.Value - 1;
					}
					else if ((int)Globals.Tags.DisplayYear.Value == 2000)
					{
						Globals.Tags.DisplayYear.Value = 2100;
					}
				}
				
				Globals.Tags.CurrentDayInMonth.Value = DateTime.DaysInMonth((int)Globals.Tags.DisplayYear.Value, (int)Globals.Tags.DisplayMonth.Value);
				Globals.Tags.DisplayDay.Value = (int)Globals.Tags.CurrentDayInMonth.Value;
			}
			
		}
		
		void Button3_Click(System.Object sender, System.EventArgs e)
		{
			if ((int)Globals.Tags.DisplayYear.Value < 2100)
			{
				Globals.Tags.DisplayYear.Value = (int)Globals.Tags.DisplayYear.Value + 1;
			}
			else if ((int)Globals.Tags.DisplayYear.Value == 2100)
			{
				Globals.Tags.DisplayYear.Value = 2000;
			}
			
			Globals.Tags.CurrentDayInMonth.Value = DateTime.DaysInMonth((int)Globals.Tags.DisplayYear.Value, (int)Globals.Tags.DisplayMonth.Value);
		}
		
		void Button4_Click(System.Object sender, System.EventArgs e)
		{
			if ((int)Globals.Tags.DisplayYear.Value > 2000)
			{
				Globals.Tags.DisplayYear.Value = (int)Globals.Tags.DisplayYear.Value - 1;
			}
			else if ((int)Globals.Tags.DisplayYear.Value == 2000)
			{
				Globals.Tags.DisplayYear.Value = 2100;
			}
			
			Globals.Tags.CurrentDayInMonth.Value = DateTime.DaysInMonth((int)Globals.Tags.DisplayYear.Value, (int)Globals.Tags.DisplayMonth.Value);
		}
		

		
		void CalDueDateSetting_Closed(System.Object sender, System.EventArgs e)
		{
			DateTime tmpDate = new DateTime(Globals.Tags.DisplayYear.Value.Int,Globals.Tags.DisplayMonth.Value.Int,Globals.Tags.DisplayDay.Value.Int);
			
			Globals.Tags.calDueDatePers.Value = tmpDate;

			
			Globals.Tags.calDueDate.Value = Globals.Tags.calDueDatePers.Value.DateTime.ToString("MM/dd/yyyy");
			
			if (Globals.Tags.SystemTagDateTime.Value.DateTime.Year > Globals.Tags.calDueDatePers.Value.DateTime.Year)
			{
				Globals.Tags.calDueDateIndi.Value = 1;
			}
			else if (Globals.Tags.SystemTagDateTime.Value.DateTime.Year < Globals.Tags.calDueDatePers.Value.DateTime.Year)
			{
				Globals.Tags.calDueDateIndi.Value = 0;
			}
			else if (Globals.Tags.SystemTagDateTime.Value.DateTime.Year == Globals.Tags.calDueDatePers.Value.DateTime.Year)
			{
				if (Globals.Tags.SystemTagDateTime.Value.DateTime.Month > Globals.Tags.calDueDatePers.Value.DateTime.Month)
				{
					Globals.Tags.calDueDateIndi.Value = 1;
				}
				else if (Globals.Tags.SystemTagDateTime.Value.DateTime.Month < Globals.Tags.calDueDatePers.Value.DateTime.Month)
				{
					Globals.Tags.calDueDateIndi.Value = 0;
				}
				else if (Globals.Tags.SystemTagDateTime.Value.DateTime.Month == Globals.Tags.calDueDatePers.Value.DateTime.Month)
				{
					if (Globals.Tags.SystemTagDateTime.Value.DateTime.Day >= Globals.Tags.calDueDatePers.Value.DateTime.Day)
					{
						Globals.Tags.calDueDateIndi.Value = 1;
					}
					else if (Globals.Tags.SystemTagDateTime.Value.DateTime.Day < Globals.Tags.calDueDatePers.Value.DateTime.Day)
					{
						Globals.Tags.calDueDateIndi.Value = 0;
					}
					
				}
			}
			
			Globals.PersistentVariables.SaveRecipe("Current",false);
		}
		
		void Button21_Click(System.Object sender, System.EventArgs e)
		{
			Globals.PersistentVariables.SaveRecipe("Current",false);
		}
		
		void Button5_Click(System.Object sender, System.EventArgs e)
		{
			if (Globals.Tags.calDueDateShow.Value.Int == 1)
			{
				Globals.Tags.calDueDateShow.Value = 0;
			}
			else
			{
				Globals.Tags.calDueDateShow.Value = 1;
			}
			
			Globals.PersistentVariables.SaveRecipe("Current",false);
		}
		
    }
}
