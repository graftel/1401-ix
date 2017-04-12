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
	using System.Text;
	using System.Collections.Generic;
	using Neo.ApplicationFramework.Tools.MessageLibrary;
    
    public partial class DiagScreen
    {
		private int giFlowMeterIndex = 0;
		private int giPressSensorIndex = 0;
		private int giSolenoidValveIndex = 0;
		private int giCurrentDiagIndex = 0;
		private Timer tmrProgress;
		
		void DiagScreen_Opened(System.Object sender, System.EventArgs e)
		{
			tmrProgress = new Timer();
			tmrProgress.Interval = 500;
			tmrProgress.Tick += PROGRESS_TICK;
			tmrProgress.Enabled = false;
			
			if (Globals.Tags.GetDiagResult.Value.Bool == false)
			{
				
				tmrProgress.Enabled = true;
				// Initial Status
/*				lblMsgSmall1.Visible = true;
				lblMsgSmall2.Visible = false;
				lblMsgSmall3.Visible = false;
			
				pbDiag1.Visible = true;
				pbDiag2.Visible = false;
				pbDiag3.Visible = false;
			
				lblMsgBig1.Visible = false;
				lblMsgBig2.Visible = false;
				lblMsgBig3.Visible = false;
			
				picDiag1.Visible = false;
				picDiag2.Visible = false;
				picDiag3.Visible = false;
			
				btnDetail1.IsEnabled = false;
				btnDetail2.IsEnabled = false;
				btnDetail3.IsEnabled = false;
			
				LoadGif1.Visible = true;
				LoadGif2.Visible = false;
				LoadGif3.Visible = false;
			
				btnSave.IsEnabled = false;
*/
			
				for (int i = 0; i < Globals.Comm.FlowMeters.Count; i++)
				{
					Globals.Comm.FlowMeters[i].ResetPara();
				}
			
				for (int i = 0; i < Globals.Comm.PressSensors.Count; i++)
				{
					Globals.Comm.PressSensors[i].ResetPara();
				}
			
				for (int i = 0; i < Globals.Comm.SolenoidValves.Count; i++)
				{
					Globals.Comm.SolenoidValves[i].ResetDiagResult();
				}
			
			
			
				Globals.Tags.DiagStage.Value = 0;
				giFlowMeterIndex = 0;
				giPressSensorIndex = 0;
				giSolenoidValveIndex = 0;
				Globals.Tags.DiagProgressBar1.Value = 0;
				Globals.Tags.DiagProgressBar2.Value = 0;
				Globals.Tags.DiagProgressBar3.Value = 0;
				//	Globals.Tags.DiagProgress.Value = 6;
				// To do	
				//		Globals.Comm.DiagPoll();
				Globals.Tags.GetDiagResult.Value = true;
			}
		}
		
		
		private void PROGRESS_TICK(Object myObject, EventArgs myEventArgs) 
		{
			//UI management
			bool isConnected = true;
			int iNumWarnings = 0;
			switch(Globals.Tags.DiagStage.Value.Int)
			{
				case 0:   // check flow meter
					Globals.Tags.DiagProgressBar1.Value = Globals.Tags.DiagProgressBar1.Value.Int + 3;
					
					
					if (Globals.Comm.FlowMeters[giFlowMeterIndex].GetDataStatus() == DataStatus.NotAvailable)
					{
						Globals.Comm.FlowMeters[giFlowMeterIndex].RequestData();
					}
					else
					{
						if (Globals.Comm.FlowMeters[giFlowMeterIndex].iParaResult[giCurrentDiagIndex].para_result == ParaStatus.NotAvailable)
						{
							Globals.Comm.FlowMeters[giFlowMeterIndex].RequestPara(giCurrentDiagIndex);
						}
						else
						{
							if (giCurrentDiagIndex < Globals.Comm.FlowMeters[giFlowMeterIndex].GetParaCount() - 1)
							{
								giCurrentDiagIndex++;
							}
							else
							{
								giFlowMeterIndex++;
								giCurrentDiagIndex = 0;    // Test finish
								
								if (giFlowMeterIndex == Globals.Comm.FlowMeters.Count)
								{
									Globals.Tags.DiagStage.Value++;
								}
							}
						}
					}
					
					if (Globals.Tags.DiagProgressBar1.Value.Int >= 100)
					{
						Globals.Tags.DiagStage.Value++;
						giCurrentDiagIndex = 0;
					}
					else if (Globals.Tags.DiagProgressBar1.Value.Int > 100 * (giFlowMeterIndex + 1) / Globals.Comm.FlowMeters.Count )
					{
						giFlowMeterIndex++;
						giCurrentDiagIndex = 0;
					}
					break;
				case 1:    // update ui
					// First Check connectivity
					isConnected = true;
					string sFlowMeterMsg = "";
					iNumWarnings = 0;
					
					for (int i = 0; i < Globals.Comm.FlowMeters.Count; i++)
					{
						if (Globals.Comm.FlowMeters[i].iRegResult[0].para_result == ParaStatus.NotAvailable)
						{
							isConnected = isConnected && false;
							
							sFlowMeterMsg = sFlowMeterMsg + Globals.Comm.FlowMeters[i].sName + " "; 
						}
						iNumWarnings = iNumWarnings + Globals.Comm.FlowMeters[i].CountTotalWarnings();
					}
					
					if (isConnected)
					{
						
						//Check warnings
						if(iNumWarnings == 0)
						{
							Globals.Tags.DiagPic1.Value = 1;
							sFlowMeterMsg = "Flow Meters OK";
						}
						else
						{	Globals.Tags.DiagPic1.Value = 2;
							sFlowMeterMsg = "Flow Meters have " + iNumWarnings.ToString() + " warnings!"; 
						}
					}
					else
					{
						Globals.Tags.DiagPic1.Value = 0;
						sFlowMeterMsg = sFlowMeterMsg + "Meter(s) Disconnected";
					}
					
					Globals.Tags.DiagMsg7.Value = sFlowMeterMsg;
					giPressSensorIndex = 0;
					giCurrentDiagIndex = 0;
					
					/*
					
					lblMsgSmall1.Visible = false;
					lblMsgSmall2.Visible = true;
					lblMsgSmall3.Visible = false;
			
					pbDiag1.Visible = false;
					pbDiag2.Visible = true;
					pbDiag3.Visible = false;
			
					lblMsgBig1.Visible = true;
					lblMsgBig2.Visible = false;
					lblMsgBig3.Visible = false;
			
					picDiag1.Visible = true;
					picDiag2.Visible = false;
					picDiag3.Visible = false;
			
					LoadGif1.Visible = false;
					LoadGif2.Visible = true;
					LoadGif3.Visible = false;		
					*/
					Globals.Tags.DiagStage.Value++;
					break;
				case 2:	// Check pressure sensors
					Globals.Tags.DiagProgressBar2.Value = Globals.Tags.DiagProgressBar2.Value.Int + 1;
					
					if (Globals.Comm.PressSensors[giPressSensorIndex].pResult[giCurrentDiagIndex].para_result == ParaStatus.NotAvailable)
					{
						Globals.Comm.PressSensors[giPressSensorIndex].RequestPara_ASC(giCurrentDiagIndex);
					}
					else
					{
						if (giCurrentDiagIndex < Globals.Comm.PressSensors[giPressSensorIndex].GetParaCount() - 1)
						{
							giCurrentDiagIndex++;
						}
						else
						{
							//Move to new sensor
							giPressSensorIndex++;
							giCurrentDiagIndex = 0;
							
							if(giPressSensorIndex == Globals.Comm.PressSensors.Count)
							{
								Globals.Tags.DiagStage.Value++;			//Finish
								giCurrentDiagIndex = 0;
							}
						}
					}
					
					if (Globals.Tags.DiagProgressBar2.Value.Int >= 100)
					{
						Globals.Tags.DiagStage.Value++;			// Time out 
						giCurrentDiagIndex = 0;
					}
					else if (Globals.Tags.DiagProgressBar2.Value.Int > 100 * (giPressSensorIndex + 1) / Globals.Comm.PressSensors.Count )
					{
						giPressSensorIndex++;	 // current sensor timeout
						giCurrentDiagIndex = 0;
					}
					
					break;
				case 3:  // update press sensors ui
					isConnected = true;
					string sPressSensorMsg = "";
					iNumWarnings = 0;
					
					for (int i = 0; i < Globals.Comm.PressSensors.Count; i++)
					{
						if (Globals.Comm.PressSensors[i].pResult[0].para_result == ParaStatus.NotAvailable)
						{
							isConnected = isConnected && false;
							
							sPressSensorMsg = sPressSensorMsg + Globals.Comm.PressSensors[i].sName + " "; 
						}
						iNumWarnings = iNumWarnings + Globals.Comm.PressSensors[i].CountTotalWarnings();
					}
					
					if (isConnected)
					{
						
						//Check warnings
						if(iNumWarnings == 0)
						{
							Globals.Tags.DiagPic2.Value = 1;
							sPressSensorMsg = "Pressure Sensors OK";
						}
						else
						{	Globals.Tags.DiagPic2.Value = 2;
							sPressSensorMsg = "Pressure Sensors have " + iNumWarnings.ToString() + " warnings!"; 
						}
					}
					else
					{
						Globals.Tags.DiagPic2.Value = 0;
						sPressSensorMsg = sPressSensorMsg + "Sensor(s) Disconnected";
					}
					
					Globals.Tags.DiagMsg8.Value = sPressSensorMsg;
					giSolenoidValveIndex = 0;
					giCurrentDiagIndex = 0;
					Globals.Tags.DiagStage.Value++;
					
					/*
					lblMsgSmall1.Visible = false;
					lblMsgSmall2.Visible = false;
					lblMsgSmall3.Visible = true;
			
					pbDiag1.Visible = false;
					pbDiag2.Visible = false;
					pbDiag3.Visible = true;
			
					lblMsgBig1.Visible = true;
					lblMsgBig2.Visible = true;
					lblMsgBig3.Visible = false;
			
					picDiag1.Visible = true;
					picDiag2.Visible = true;
					picDiag3.Visible = false;
			
					LoadGif1.Visible = false;
					LoadGif2.Visible = false;
					LoadGif3.Visible = true;	
					*/
					break;
				case 4:
					Globals.Tags.DiagProgressBar3.Value = Globals.Tags.DiagProgressBar3.Value.Int + 1;
					
					if (Globals.Comm.SolenoidValves[giSolenoidValveIndex].solenoidResult[giCurrentDiagIndex].para_result == ParaStatus.NotAvailable)
					{
						Globals.Comm.SolenoidValves[giSolenoidValveIndex].RequestPara(giCurrentDiagIndex);
					}
					else
					{
						if (giCurrentDiagIndex < Globals.Comm.SolenoidValves[giSolenoidValveIndex].GetParaCount() - 1)
						{
							giCurrentDiagIndex++;
						}
						else
						{
							//Move to new sensor
							giSolenoidValveIndex++;
							giCurrentDiagIndex = 0;
							
							if (giSolenoidValveIndex == Globals.Comm.SolenoidValves.Count)
							{
								Globals.Tags.DiagStage.Value++;				// Time out 
								giCurrentDiagIndex = 0;
							}
						}
					}
					
					if (Globals.Tags.DiagProgressBar3.Value.Int >= 100)
					{
						Globals.Tags.DiagStage.Value++;				// Time out 
						giCurrentDiagIndex = 0;
					}
					else if (Globals.Tags.DiagProgressBar3.Value.Int > 100 * (giSolenoidValveIndex + 1) / Globals.Comm.SolenoidValves.Count )
					{
						giSolenoidValveIndex++;	 // current sensor timeout
						giCurrentDiagIndex = 0;
					}
					
					break;
				case 5:
					isConnected = true;
					string sMsg = "";
					iNumWarnings = 0;
					
					for (int i = 0; i < Globals.Comm.SolenoidValves.Count; i++)
					{
						if (Globals.Comm.SolenoidValves[i].solenoidResult[0].para_result == ParaStatus.NotAvailable)
						{
							isConnected = isConnected && false;
							
							sMsg = sMsg + Globals.Comm.SolenoidValves[i].sName + " "; 
						}
						iNumWarnings = iNumWarnings + Globals.Comm.SolenoidValves[i].CountTotalWarnings();
					}
					
					if (isConnected)
					{
						
						//Check warnings
						if(iNumWarnings == 0)
						{
							Globals.Tags.DiagPic3.Value = 1;
							sMsg = "Solenoid Valves OK";
						}
						else
						{	Globals.Tags.DiagPic3.Value = 2;
							sMsg = "Solenoid Valves have " + iNumWarnings.ToString() + " warnings!"; 
						}
					}
					else
					{
						Globals.Tags.DiagPic3.Value = 0;
						sMsg = sMsg + "Valve(s) Disconnected";
					}
					
					Globals.Tags.DiagMsg9.Value = sMsg;
					tmrProgress.Enabled = false;
					
					/*
					lblMsgSmall1.Visible = false;
					lblMsgSmall2.Visible = false;
					lblMsgSmall3.Visible = false;
			
					pbDiag1.Visible = false;
					pbDiag2.Visible = false;
					pbDiag3.Visible = false;
			
					lblMsgBig1.Visible = true;
					lblMsgBig2.Visible = true;
					lblMsgBig3.Visible = true;
			
					picDiag1.Visible = true;
					picDiag2.Visible = true;
					picDiag3.Visible = true;
			
					LoadGif1.Visible = false;
					LoadGif2.Visible = false;
					LoadGif3.Visible = false;
					
					
							
					btnDetail1.IsEnabled = true;
					btnDetail2.IsEnabled = true;
					btnDetail3.IsEnabled = true;
					
					btnSave.IsEnabled = true;
					*/
					break;
			}
			
		}
		
		void Button11_Click(System.Object sender, System.EventArgs e)
		{
			tmrProgress.Enabled = false;
			Globals.Tags.GetDiagResult.Value = false;
		}
		
		string GetResult(ParaResult re)
		{
			if (re.para_result == ParaStatus.NotAvailable)
			{
				return "-";
			}
			else if ((re.para_result == ParaStatus.Warning))
			{
				return re.para_value.ToString() + "(Warning: Out of range)";
			}
			else
			{
				return re.para_value.ToString();
			}
		}
		
		string GetStatus(ParaResult re)
		{
			if (re.para_result == ParaStatus.NotAvailable)
			{
				return "Not Connected";
			}
			else if ((re.para_result == ParaStatus.Warning))
			{
				return "Warning: Voltage out of range";
			}
			else
			{
				return "OK";
			}
		}
		
		void btnSave_Click(System.Object sender, System.EventArgs e)
		{
		
			if (Globals.Tags.USBStatus.Value.Int == 0)
			{
				Globals.Tags.GeneralMessage.Value = "Please insert a valid USB drive";
				Globals.GeneralMsgBox.Show();
			}
			else
			{
				Save();
			}
			
			
		}
		
		
		void Save()
		{
			string path;
			string dt, dt_normal;
			DateTime currentDateTime;
			string DateFormat, TimeFormat;
			string WriteLine;
			StreamWriter swUSB;
		
			currentDateTime = DateTime.Now;
			
			DateFormat = Globals.Tags.DateFormat.Value.String;
			TimeFormat = Globals.Tags.TimeFormat.Value.String;
			
			dt = currentDateTime.ToString(DateFormat.Replace('/','-') + "_" + TimeFormat.Replace(':','-'));
			dt_normal = currentDateTime.ToString("MM/dd/yyyy HH:mm:ss");
			path = "\\Hard Disk\\" + "DiagnosticReport_" + dt + ".csv";
			
			WriteLine = "Flow Meter Info\r\n";
			WriteLine += "Details,Flow Meter(Low),Flow Meter(Mid),Flow Meter(High)\r\n";
			
			WriteLine += "Pressure," + GetResult(Globals.Comm.FlowMeters[0].iRegResult[0]) + "," 
									 + GetResult(Globals.Comm.FlowMeters[1].iRegResult[0]) + "," 
									 + GetResult(Globals.Comm.FlowMeters[2].iRegResult[0]) + "\r\n";
			
			WriteLine += "Temperature," + GetResult(Globals.Comm.FlowMeters[0].iRegResult[1]) + "," 
										+ GetResult(Globals.Comm.FlowMeters[1].iRegResult[1]) + "," 
										+ GetResult(Globals.Comm.FlowMeters[2].iRegResult[1]) + "\r\n";
			
			WriteLine += "Vol Flow Rate," + GetResult(Globals.Comm.FlowMeters[0].iRegResult[2]) + "," 
										  + GetResult(Globals.Comm.FlowMeters[1].iRegResult[2]) + ","
										  + GetResult(Globals.Comm.FlowMeters[2].iRegResult[2]) + "\r\n";
			
			WriteLine += "Mass Flow Rate," + GetResult(Globals.Comm.FlowMeters[0].iRegResult[3]) + "," 
										   + GetResult(Globals.Comm.FlowMeters[1].iRegResult[3]) + ","
										   + GetResult(Globals.Comm.FlowMeters[2].iRegResult[3]) + "\r\n";
			
			WriteLine += "Register 8," + GetResult(Globals.Comm.FlowMeters[0].iParaResult[0]) + "," 
									   + GetResult(Globals.Comm.FlowMeters[1].iParaResult[0]) + ","
									   + GetResult(Globals.Comm.FlowMeters[2].iParaResult[0]) + "\r\n";
			
			WriteLine += "Register 10," + GetResult(Globals.Comm.FlowMeters[0].iParaResult[1]) + "," 
										+ GetResult(Globals.Comm.FlowMeters[1].iParaResult[1]) + ","
										+ GetResult(Globals.Comm.FlowMeters[2].iParaResult[1]) + "\r\n";
			
			WriteLine += "Register 31," + GetResult(Globals.Comm.FlowMeters[0].iParaResult[2]) + "," 
										+ GetResult(Globals.Comm.FlowMeters[1].iParaResult[2]) + ","
										+ GetResult(Globals.Comm.FlowMeters[2].iParaResult[2]) + "\r\n";
			
			WriteLine += "Serial Number," + GetResult(Globals.Comm.FlowMeters[0].iParaResult[3]) + "," 
										  + GetResult(Globals.Comm.FlowMeters[1].iParaResult[3]) + ","
										  + GetResult(Globals.Comm.FlowMeters[2].iParaResult[3]) + "\r\n\r\n";
			WriteLine += "Pressure Sensors Info\r\n";
			WriteLine += "Details,Inlet Pressure Meter,Test Pressure Meter\r\n";
			WriteLine += "Pressure," + GetResult(Globals.Comm.PressSensors[0].pResult[0]) + "," 
				+ GetResult(Globals.Comm.PressSensors[1].pResult[0]) + "\r\n";	
			WriteLine += "Temperature," + GetResult(Globals.Comm.PressSensors[0].pResult[1]) + "," 
				+ GetResult(Globals.Comm.PressSensors[1].pResult[1]) + "\r\n";	
			WriteLine += "Error Register," + GetResult(Globals.Comm.PressSensors[0].pResult[6]) + "," 
				+ GetResult(Globals.Comm.PressSensors[1].pResult[6]) + "\r\n";	
			WriteLine += "Pressure Status," + GetResult(Globals.Comm.PressSensors[0].pResult[4]) + "," 
				+ GetResult(Globals.Comm.PressSensors[1].pResult[4]) + "\r\n";	
			WriteLine += "Temperature Status," + GetResult(Globals.Comm.PressSensors[0].pResult[5]) + "," 
				+ GetResult(Globals.Comm.PressSensors[1].pResult[5]) + "\r\n";	
			WriteLine += "Serial Number," + GetResult(Globals.Comm.PressSensors[0].pResult[7]) + "," 
				+ GetResult(Globals.Comm.PressSensors[1].pResult[7]) + "\r\n\r\n";	
			
			
			WriteLine += "Solenoid Valves Info\r\n";
			WriteLine += "Details,Valve(Low),Valve(Mid),Valve(High)\r\n";
			WriteLine += "Status," + GetStatus(Globals.Comm.SolenoidValves[0].solenoidResult[0]) + "," 
								   + GetStatus(Globals.Comm.SolenoidValves[1].solenoidResult[0]) + "," 
								   + GetStatus(Globals.Comm.SolenoidValves[2].solenoidResult[0]) + "\r\n";
			
			WriteLine += "Open Voltage," + GetResult(Globals.Comm.SolenoidValves[0].solenoidResult[0]) + "," 
										 + GetResult(Globals.Comm.SolenoidValves[1].solenoidResult[0]) + "," 
										 + GetResult(Globals.Comm.SolenoidValves[2].solenoidResult[0]) + "\r\n";
			
			WriteLine += "Close Voltage," + GetResult(Globals.Comm.SolenoidValves[0].solenoidResult[1]) + "," 
									      + GetResult(Globals.Comm.SolenoidValves[1].solenoidResult[1]) + "," 
										  + GetResult(Globals.Comm.SolenoidValves[2].solenoidResult[1]) + "\r\n\r\n";

			WriteLine += "Max Values\r\n";
			WriteLine += "Name,Date,Time,Value\r\n";
			WriteLine += "Low Range Pressure," 
				+ Globals.Tags.DiagMaxValueFlow11Time.Value.DateTime.ToString("MM/dd/yyyy") + ","									
				+ Globals.Tags.DiagMaxValueFlow11Time.Value.DateTime.ToString("HH:mm:ss") + ","
				+ Globals.Tags.DiagMaxValueFlow11.Value.Double.ToString() + "\r\n";
			WriteLine += "Low Range Temperature," 
				+ Globals.Tags.DiagMaxValueFlow12Time.Value.DateTime.ToString("MM/dd/yyyy") + ","
				+ Globals.Tags.DiagMaxValueFlow12Time.Value.DateTime.ToString("HH:mm:ss") + ","
				+ Globals.Tags.DiagMaxValueFlow12.Value.Double.ToString() + "\r\n";
			WriteLine += "Low Range Vol Flow Rate," 
				+ Globals.Tags.DiagMaxValueFlow13Time.Value.DateTime.ToString("MM/dd/yyyy") + ","									
				+ Globals.Tags.DiagMaxValueFlow13Time.Value.DateTime.ToString("HH:mm:ss") + ","
				+ Globals.Tags.DiagMaxValueFlow13.Value.Double.ToString() + "\r\n";
			WriteLine += "Low Range Mass Flow Rate," 
				+ Globals.Tags.DiagMaxValueFlow14Time.Value.DateTime.ToString("MM/dd/yyyy") + ","
				+ Globals.Tags.DiagMaxValueFlow14Time.Value.DateTime.ToString("HH:mm:ss") + ","
				+ Globals.Tags.DiagMaxValueFlow14.Value.Double.ToString() + "\r\n";
			
			WriteLine += "High Range Pressure," 
				+ Globals.Tags.DiagMaxValueFlow21Time.Value.DateTime.ToString("MM/dd/yyyy") + ","									
				+ Globals.Tags.DiagMaxValueFlow21Time.Value.DateTime.ToString("HH:mm:ss") + ","
				+ Globals.Tags.DiagMaxValueFlow21.Value.Double.ToString() + "\r\n";
			WriteLine += "High Range Temperature," 
				+ Globals.Tags.DiagMaxValueFlow22Time.Value.DateTime.ToString("MM/dd/yyyy") + ","
				+ Globals.Tags.DiagMaxValueFlow22Time.Value.DateTime.ToString("HH:mm:ss") + ","
				+ Globals.Tags.DiagMaxValueFlow22.Value.Double.ToString() + "\r\n";
			WriteLine += "High Range Vol Flow Rate," 
				+ Globals.Tags.DiagMaxValueFlow23Time.Value.DateTime.ToString("MM/dd/yyyy") + ","									
				+ Globals.Tags.DiagMaxValueFlow23Time.Value.DateTime.ToString("HH:mm:ss") + ","
				+ Globals.Tags.DiagMaxValueFlow23.Value.Double.ToString() + "\r\n";
			WriteLine += "High Range Mass Flow Rate," 
				+ Globals.Tags.DiagMaxValueFlow24Time.Value.DateTime.ToString("MM/dd/yyyy") + ","
				+ Globals.Tags.DiagMaxValueFlow24Time.Value.DateTime.ToString("HH:mm:ss") + ","
				+ Globals.Tags.DiagMaxValueFlow24.Value.Double.ToString() + "\r\n";
			
			WriteLine += "Inlet Pressure," 
				+ Globals.Tags.DiagMaxValuePress1Time.Value.DateTime.ToString("MM/dd/yyyy") + ","
				+ Globals.Tags.DiagMaxValuePress1Time.Value.DateTime.ToString("HH:mm:ss") + ","
				+ Globals.Tags.DiagMaxValuePress1.Value.Double.ToString() + "\r\n";
			
			WriteLine += "Outlet Pressure," 
				+ Globals.Tags.DiagMaxValuePress2Time.Value.DateTime.ToString("MM/dd/yyyy") + ","
				+ Globals.Tags.DiagMaxValuePress2Time.Value.DateTime.ToString("HH:mm:ss") + ","
				+ Globals.Tags.DiagMaxValuePress2.Value.Double.ToString() + "\r\n";
			
			WriteLine += "\r\nSolenoid Cycles\r\n";
			WriteLine += "Solenoid Cycle(Low)," + Globals.Tags.SolenoidCountA.Value.Int.ToString() + "\r\n";
			WriteLine += "Solenoid Cycle(Mid)," + Globals.Tags.SolenoidCountB.Value.Int.ToString() + "\r\n";
			WriteLine += "Solenoid Cycle(High)," + Globals.Tags.SolenoidCountC.Value.Int.ToString() + "\r\n";
			
			bool isSaved = false;
			try
			{
				swUSB = new StreamWriter(path, true, Encoding.ASCII);
				swUSB.Write(WriteLine);	
				swUSB.Close();
				isSaved = true;
			}
			catch
			{
				isSaved = false;
			}
			

			if (isSaved)
			{

				Globals.Tags.GeneralMessage.Value = "Diagnostics result saved successfully on the USB drive";
				Globals.GeneralMsgBox.Show();
			}
			else
			{
				Globals.Tags.GeneralMessage.Value = "Diagnostics result saved failed, please try to use other USB drive";
				Globals.GeneralMsgBox.Show();
			}
			
		}
		
		void DiagScreen_Closed(System.Object sender, System.EventArgs e)
		{
			tmrProgress.Enabled = false;
		}
		

		
		
    }
}
