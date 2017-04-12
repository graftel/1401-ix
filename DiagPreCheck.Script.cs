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
    
    
    public partial class DiagPreCheck
    {
		private Timer tmrProgress;
		private int gStage;
		void DiagPreCheck_Opened(System.Object sender, System.EventArgs e)
		{
			tmrProgress = new Timer();
			tmrProgress.Interval = 500;
			tmrProgress.Tick += PROGRESS_TICK;
			tmrProgress.Enabled = true;
			
			gStage = 0;
			
	//		Globals.Tags.SolenoidValveStatusLow.Value = 0;
//			Globals.Tags.SolenoidValveStatusMid.Value = 0;
//			Globals.Tags.SolenoidValveStatusQuick.Value = 0;
			Globals.Tags.DiagProgress.Value = 0;
			Globals.Tags.DiagMsg1.Value = "";
			Globals.Tags.DiagMsg2.Value = "";
			Globals.Tags.DiagMsg3.Value = "";
			
		//	Globals.Comm.DiagPoll();	 To do
		}
		
		private void PROGRESS_TICK(Object myObject, EventArgs myEventArgs) 
		{
			if (Globals.Tags.DiagProgress.Value.Int < 99)
			{
				Globals.Tags.DiagProgress.Value = Globals.Tags.DiagProgress.Value.Int + 1;
				lblPrg.Text = Globals.Tags.DiagProgress.Value.Int.ToString() + " %";
			}
			
			PerformTask(gStage);
		}
		
		private void PerformTask(int stage)
		{
			//stage 0
			switch(stage)
			{
				case 0: 
					if (Globals.Tags.DiagProgress.Value.Int >= 30)
					{
						prgGroup.Visible = false;
						lblMsg.Text = "Please check the connections of solenoid valves" 
							+ Environment.NewLine 
							+ Environment.NewLine 
							+ "Press 'Continue' to proceed";
						btnContinue.Visible = true;
						btnBack.Visible = true;
						Globals.Tags.DiagProgress.Value = 0;
						tmrProgress.Enabled = false;
					}
					else
					{
						if (Globals.Comm.SolenoidValves[0].currentStatus != ValveStatus.Open)
						{
							Globals.Comm.SolenoidValves[0].Open_ASC();
						}
						else if (Globals.Comm.SolenoidValves[1].currentStatus != ValveStatus.Open)
						{
							Globals.Comm.SolenoidValves[1].Open_ASC();
						}
						else if (Globals.Comm.SolenoidValves[2].currentStatus != ValveStatus.Open)
						{
							Globals.Comm.SolenoidValves[2].Open_ASC();
						}
						else if (Globals.Comm.SolenoidValves[0].currentStatus == ValveStatus.Open &&
							Globals.Comm.SolenoidValves[1].currentStatus == ValveStatus.Open &&
							Globals.Comm.SolenoidValves[2].currentStatus == ValveStatus.Open)
						{
							Globals.Comm.FlowMeters[0].ResetPara();
							Globals.Comm.FlowMeters[1].ResetPara();
							Globals.Comm.FlowMeters[2].ResetPara();
							Globals.Comm.PressSensors[1].ResetDataStatus();
							Globals.Tags.DiagProgress.Value = 30;
							gStage++;
						}
					}
					break;
				case 1:
					if (Globals.Tags.DiagProgress.Value.Int >= 99)
					{
						prgGroup.Visible = false;
						lblMsg.Text = "Please check the connections of flow meters/pressure sensors" 
							+ Environment.NewLine 
							+ Environment.NewLine 
							+ "Press 'Continue' to proceed";
						btnContinue.Visible = true;
						btnBack.Visible = true;
						Globals.Tags.DiagProgress.Value = 0;
						tmrProgress.Enabled = false;
					}
					else
					{
						if (Globals.Comm.FlowMeters[0].GetDataStatus() != DataStatus.Available)
						{
							Globals.Comm.FlowMeters[0].RequestData();
						}
						else if (Globals.Comm.FlowMeters[1].GetDataStatus() != DataStatus.Available)
						{
							Globals.Comm.FlowMeters[1].RequestData();
						}
						else if (Globals.Comm.FlowMeters[2].GetDataStatus() != DataStatus.Available)
						{
							Globals.Comm.FlowMeters[2].RequestData();
						}
						else if (Globals.Comm.PressSensors[1].GetDataStatus() != DataStatus.Available)
						{
							Globals.Comm.PressSensors[1].SendToPort(PressRequestType.Read, PressDataType.Pressure);
						}
						else if (Globals.Comm.FlowMeters[0].GetDataStatus() == DataStatus.Available &&
							Globals.Comm.FlowMeters[1].GetDataStatus() == DataStatus.Available &&
							Globals.Comm.PressSensors[1].GetDataStatus() == DataStatus.Available)
						{
							if (Globals.Comm.FlowMeters[0].GetFlowRate() < Globals.Tags.NoFlowConditionLow.Value.Double * Globals.Comm.FlowMeters[0].dMaxFlow / 100.00 &&
								Globals.Comm.FlowMeters[1].GetFlowRate() < Globals.Tags.NoFlowConditionMid.Value.Double * Globals.Comm.FlowMeters[1].dMaxFlow / 100.00 &&
								Globals.Comm.FlowMeters[2].GetFlowRate() < Globals.Tags.NoFlowConditionHigh.Value.Double * Globals.Comm.FlowMeters[2].dMaxFlow / 100.00 &&
								Globals.Comm.PressSensors[1].GetPress() < Globals.Tags.NoTestPressCondition.Value) 
							{
							
								// Automatically disappear
								tmrProgress.Enabled = false;
								Globals.DiagPreCheck.Close();
								Globals.Tags.GetDiagResult.Value = false;
								Globals.DiagScreen.Show();
							}
							else
							{
								prgGroup.Visible = false;
								lblMsg.Text = "Warning! System is pressurized" 
									+ Environment.NewLine 
									+ Environment.NewLine 
									+ "Press 'Continue' to proceed"
									+ Environment.NewLine
									+ "Caution, results may be inaccurate";
								btnContinue.Visible = true;
								btnBack.Visible = true;
								Globals.Tags.DiagProgress.Value = 0;
								tmrProgress.Enabled = false;
							}
						
						
						}
					}
					break;
			}
			
		}
		
		void btnContinue_Click(System.Object sender, System.EventArgs e)
		{
			tmrProgress.Enabled = false;
			Globals.Tags.GetDiagResult.Value = false;
			Globals.DiagPreCheck.Close();
			Globals.DiagScreen.Show();
		}
		
		void DiagPreCheck_Closed(System.Object sender, System.EventArgs e)
		{
			tmrProgress.Enabled = false;
		}
		
		void btnBack_Click(System.Object sender, System.EventArgs e)
		{
			Globals.DiagPreCheck.Close();
			Globals.DiagScreen1.Show();
		}
    }
}
