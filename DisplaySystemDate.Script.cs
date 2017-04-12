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
    using System.Runtime.InteropServices;
    
    public partial class DisplaySystemDate
    {
		

		//these dll imports go inside the beginning of the class definition
		[DllImport("coredll.dll")]
		private extern static void GetSystemTime(ref SYSTEMTIME lpSystemTime);

		[DllImport("coredll.dll")]
		private extern static uint SetSystemTime(ref SYSTEMTIME lpSystemTime);

		
		private struct SYSTEMTIME 
		{
			public ushort wYear;
			public ushort wMonth; 
			public ushort wDayOfWeek; 
			public ushort wDay; 
			public ushort wHour; 
			public ushort wMinute; 
			public ushort wSecond; 
			public ushort wMilliseconds; 
		}
		
		void DisplaySystemDate_Opened(System.Object sender, System.EventArgs e)
		{
			if (Globals.Tags.IsTouchScreen.Value.Bool)
			{
			
				SYSTEMTIME stime = new SYSTEMTIME();
				GetSystemTime(ref stime);
			
				Globals.Tags.DisplayDay.Value = stime.wDay;
				Globals.Tags.DisplayMonth.Value = stime.wMonth;
				Globals.Tags.DisplayYear.Value = stime.wYear;
			
				Globals.Tags.CurrentDayInMonth.Value = DateTime.DaysInMonth((int)Globals.Tags.DisplayYear.Value, (int)Globals.Tags.DisplayMonth.Value);
			}
		}
		
		
		void DisplaySystemDate_Closed(System.Object sender, System.EventArgs e)
		{
			if (Globals.Tags.IsTouchScreen.Value.Bool)
			{
				SYSTEMTIME systime = new SYSTEMTIME();
				GetSystemTime(ref systime);

				// Set the system clock ahead one hour.
				systime.wMonth = (ushort)Globals.Tags.DisplayMonth.Value;
				systime.wDay = (ushort)Globals.Tags.DisplayDay.Value;
				systime.wYear = (ushort)Globals.Tags.DisplayYear.Value;
				SetSystemTime(ref systime);
			}
			
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
		
		
    }
}
