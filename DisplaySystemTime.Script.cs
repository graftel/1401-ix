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
    
    public partial class DisplaySystemTime
    {
		//these dll imports go inside the beginning of the class definition
		[DllImport("coredll.dll")]
		private extern static void GetSystemTime(ref SYSTEMTIME lpSystemTime);

		[DllImport("coredll.dll")]
		private extern static uint SetSystemTime(ref SYSTEMTIME lpSystemTime);

	//	private Timer tmrTimeControl;
		SYSTEMTIME stime;
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
		
		void DisplaySystemTime_Opened(System.Object sender, System.EventArgs e)
		{
			if (Globals.Tags.IsTouchScreen.Value.Bool)
			{
				int aHour;
			
			
				stime = new SYSTEMTIME();
				GetSystemTime(ref stime);
			
				aHour = (int)stime.wHour;
				if (aHour < 5)
				{
					aHour = 19 + aHour;
				}
				else
				{
					aHour = aHour - 5;
				}
				Globals.Tags.DisplayHour.Value = aHour;
				Globals.Tags.DisplayMinute.Value = (int)stime.wMinute;
				Globals.Tags.DisplaySecond.Value = (int)stime.wSecond;
			}
		}
		
		
		void DisplaySystemTime_Closed(System.Object sender, System.EventArgs e)
		{
			if (Globals.Tags.IsTouchScreen.Value.Bool)
			{
				int aHour;
			
				SYSTEMTIME systime = new SYSTEMTIME();
				GetSystemTime(ref systime);

				// Set the system clock ahead one hour.
			
				aHour = (int)Globals.Tags.DisplayHour.Value;
				if (aHour < 19)
				{
					aHour = aHour + 5;
				}
				else
				{
					aHour = aHour - 19;
				}
			
				systime.wHour = (ushort)aHour;
				systime.wMinute = (ushort)Globals.Tags.DisplayMinute.Value;
				systime.wSecond = (ushort)Globals.Tags.DisplaySecond.Value;
				SetSystemTime(ref systime);
			}
		}
		
		void btnHourAdd_Click(System.Object sender, System.EventArgs e)
		{
			//			tmrTimeControl.Enabled = false;
			if ((int)Globals.Tags.DisplayHour.Value < 23)
			{
				Globals.Tags.DisplayHour.Value = (int)Globals.Tags.DisplayHour.Value + 1;
			}
			else if ((int)Globals.Tags.DisplayHour.Value == 23)
			{
				Globals.Tags.DisplayHour.Value = 0;
			}
		}
		
		void btnHourSub_Click(System.Object sender, System.EventArgs e)
		{
			//			tmrTimeControl.Enabled = false;
			if ((int)Globals.Tags.DisplayHour.Value > 0)
			{
				Globals.Tags.DisplayHour.Value = (int)Globals.Tags.DisplayHour.Value - 1;
			}
			else if ((int)Globals.Tags.DisplayHour.Value == 0)
			{
				Globals.Tags.DisplayHour.Value = 23;
			}
		}
		
		void btnMinAdd_Click(System.Object sender, System.EventArgs e)
		{
			//			tmrTimeControl.Enabled = false;
			if ((int)Globals.Tags.DisplayMinute.Value < 59)
			{
				Globals.Tags.DisplayMinute.Value = (int)Globals.Tags.DisplayMinute.Value + 1;
			}
			else if ((int)Globals.Tags.DisplayMinute.Value == 59)
			{
				Globals.Tags.DisplayMinute.Value = 0;
			}
		}
		
		void btnMinSub_Click(System.Object sender, System.EventArgs e)
		{
			//			tmrTimeControl.Enabled = false;
			if ((int)Globals.Tags.DisplayMinute.Value > 0)
			{
				Globals.Tags.DisplayMinute.Value = (int)Globals.Tags.DisplayMinute.Value - 1;
			}
			else if ((int)Globals.Tags.DisplayMinute.Value == 0)
			{
				Globals.Tags.DisplayMinute.Value = 59;
			}
		}
		
		void btnSecAdd_Click(System.Object sender, System.EventArgs e)
		{
			//			tmrTimeControl.Enabled = false;
			if ((int)Globals.Tags.DisplaySecond.Value < 59)
			{
				Globals.Tags.DisplaySecond.Value = (int)Globals.Tags.DisplaySecond.Value + 1;
			}
			else if ((int)Globals.Tags.DisplaySecond.Value == 59)
			{
				Globals.Tags.DisplaySecond.Value = 0;
			}
		}
		
		void btnSecSub_Click(System.Object sender, System.EventArgs e)
		{
			//			tmrTimeControl.Enabled = false;
			if ((int)Globals.Tags.DisplaySecond.Value > 0)
			{
				Globals.Tags.DisplaySecond.Value = (int)Globals.Tags.DisplaySecond.Value - 1;
			}
			else if ((int)Globals.Tags.DisplaySecond.Value == 0)
			{
				Globals.Tags.DisplaySecond.Value = 59;
			}
		}
		
		
		
    }
}
