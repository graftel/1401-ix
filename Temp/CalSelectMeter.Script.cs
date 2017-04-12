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
    
    
    public partial class CalSelectMeter
    {
		private Timer tmrPoll;
		
		void CalSelectMeter_Opened(System.Object sender, System.EventArgs e)
		{
			tmrPoll = new Timer();
			tmrPoll.Interval = 500;
			tmrPoll.Enabled = true;
			tmrPoll.Tick += POLL_TICK;
			
			lblSerialNum.Text = "";
			DisplaySelectedMeter();
			
		}
		
		private void POLL_TICK(Object myObject, EventArgs myEventArgs) 
		{
			if (Globals.Tags.calSelMeter.Value < Globals.Comm.FlowMeters.Count)
			{
				if (Globals.Comm.FlowMeters[Globals.Tags.calSelMeter.Value].iParaResult[3].para_result == ParaStatus.NotAvailable)
				{
					Globals.Comm.FlowMeters[Globals.Tags.calSelMeter.Value].RequestPara(3);
				}
				else
				{
					if (lblSerialNum.Text == "")
					{
						lblSerialNum.Text = Globals.Comm.FlowMeters[Globals.Tags.calSelMeter.Value].sSerialNum;
					}
				}
			}
			else
			{
				if (Globals.Comm.PressSensors[Globals.Tags.calSelMeter.Value - Globals.Comm.FlowMeters.Count].pResult[7].para_result == ParaStatus.NotAvailable)
				{
					Globals.Comm.PressSensors[Globals.Tags.calSelMeter.Value - Globals.Comm.FlowMeters.Count].RequestPara_ASC(7);
				}
				else
				{
					if (lblSerialNum.Text == "")
					{
						lblSerialNum.Text = Globals.Comm.PressSensors[Globals.Tags.calSelMeter.Value - Globals.Comm.FlowMeters.Count].sSerialNum;
					}
				}
			}
		}
		
		void btnSelectMeter_Click(System.Object sender, System.EventArgs e)
		{
			// Toggle between meters
			Globals.Tags.calSelMeter.Value = Globals.Tags.calSelMeter.Value.Int + 1;
			
			if (Globals.Tags.calSelMeter.Value == Globals.Comm.FlowMeters.Count + Globals.Comm.PressSensors.Count)
			{
				Globals.Tags.calSelMeter.Value = 0;
			}
			
			lblSerialNum.Text = "";
			DisplaySelectedMeter();

			
		}
		
		void DisplaySelectedMeter()
		{
			if (Globals.Tags.calSelMeter.Value < Globals.Comm.FlowMeters.Count)
			{
				btnSelectMeter.Text = Globals.Comm.FlowMeters[Globals.Tags.calSelMeter.Value].sName.ToUpper() + " RANGE FLOW METER";
				Globals.Tags.calRawDisplayEnable.Value = 1;
			
			}
			else
			{
				btnSelectMeter.Text = Globals.Comm.PressSensors[Globals.Tags.calSelMeter.Value - Globals.Comm.FlowMeters.Count].sName.ToUpper() + " PRESSURE METER";
				Globals.Tags.calRawDisplayEnable.Value = 0;
			}
		}
		
		void CalSelectMeter_Closed(System.Object sender, System.EventArgs e)
		{
			tmrPoll.Enabled = false;
		}
    }
}
