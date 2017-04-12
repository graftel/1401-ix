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
    
    
    public partial class SolenoidValveControl
    {
		private Timer tmrValve;
		private int valve_control_time_out = 0;
	//	private double dSwitchCriteria = 0;
		public void Initialized()
		{
			tmrValve = new Timer();
			tmrValve.Interval = 1000;
			tmrValve.Tick += new EventHandler(VALVE_TICK);
			
			tmrValve.Enabled = true;
		}
		
		private bool Check_supply()
		{
			if (Globals.Tags.RawInletPressure.Value > Globals.Tags.Min_Supply.Value.Double * Globals.Tags.Inlet_Press_Max.Value.Double / 100)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private bool CheckNoFlow(int selMeter)
		{
			bool result = true;
			
			switch(selMeter)
			{
				case 0:
					if (Globals.Tags.RawFlowRateLow.Value < Globals.Tags.NoFlowConditionLow.Value.Double * Globals.Tags.LowRangeMax.Value.Double / 100)
					{
						result = true;
					}
					else
					{
						result = false;
					}
					break;
				case 1:
					if (Globals.Tags.RawFlowRateMid.Value < Globals.Tags.NoFlowConditionMid.Value.Double * Globals.Tags.MidRangeMax.Value.Double / 100)
					{
						result = true;
					}
					else
					{
						result = false;
					}
					break;
				case 2:
					if (Globals.Tags.RawFlowRateHigh.Value < Globals.Tags.NoFlowConditionHigh.Value.Double * Globals.Tags.HighRangeMax.Value.Double / 100)
					{
						result = true;
					}
					else
					{
						result = false;
					}
					break;
			}
			return result;
			
		}
		
		private void VALVE_TICK(Object myObject, EventArgs myEventArgs) 
		{
			if ((int)Globals.Tags.CurrentScreen.Value == 41) //Start Screen
			{
				if (Globals.Comm.SolenoidValves[0].currentStatus == ValveStatus.Unknown
					|| Globals.Comm.SolenoidValves[1].currentStatus == ValveStatus.Unknown
					|| Globals.Comm.SolenoidValves[2].currentStatus == ValveStatus.Unknown)
				{
					valve_control_time_out++;
				}
				else
				{    // all closed
					Globals.Tags.tmr485_control.Value = 3;
					if (Globals.Tags.StartBtnEnable.Value == 0)
					{
						Globals.Tags.StartBtnEnable.Value = 1;
					}
				}
				
				if (valve_control_time_out > 5)
				{
					valve_control_time_out = 0;
					//Time out, enable start button and show warning message
					if (Globals.Tags.StartBtnEnable.Value == 0)
					{
						Globals.Tags.StartBtnEnable.Value = 1;
					}

					if (Globals.Tags.StartScreenErrorMessage.Value == 0)
					{
						Globals.Tags.StartScreenErrorMessage.Value = 1;
					}
				}
			}
			else if ((int)Globals.Tags.CurrentScreen.Value == 23) // Main Screen
			{
				if ((int)Globals.Tags.selMode.Value == 0) // Auto mode
				{
//					if (Check_supply())    // Has supply > 2 psig
//					{

						if (Globals.Tags.ValveState.Value.Int == 0)
						{    //Open High and wait for flow, Reset Switch criteria
							//dSwitchCriteria = 0;
							if ((int)Globals.Tags.selMeter.Value != 2)
							{
								Globals.Tags.selMeter.Value = 2;	
								Globals.DrawScreen.DrawMainScreen((int)Globals.Tags.selMeter.Value);
							}
							if (Globals.Comm.SolenoidValves[2].currentStatus == ValveStatus.Open)
							{
								Globals.Tags.ValveState.Value = Globals.Tags.ValveState.Value.Int + 1;
							}
							else
							{
								Globals.Tags.tmr485_control.Value = 11;
							}
						}
						else if (Globals.Tags.ValveState.Value.Int == 1)
						{    //if flow meter other than high is open, close it
							if (Globals.Comm.SolenoidValves[0].currentStatus == ValveStatus.Open)
							{
								Globals.Tags.tmr485_control.Value = 6;
							}
							else if (Globals.Comm.SolenoidValves[1].currentStatus == ValveStatus.Open)
							{
								Globals.Tags.tmr485_control.Value = 7;
							}
							else if (Globals.Comm.SolenoidValves[0].currentStatus == ValveStatus.Close && 
									 Globals.Comm.SolenoidValves[1].currentStatus == ValveStatus.Close)
							{
								Globals.Tags.ValveState.Value = Globals.Tags.ValveState.Value.Int + 1;
							}
						}
						else if (Globals.Tags.ValveState.Value.Int > 1 && Globals.Tags.ValveState.Value.Int <= 40)
						{
							if (CheckNoFlow(2))
							{
								if (Globals.Tags.ValveState.Value.Int == 40)
								{
									Globals.Tags.ValveState.Value = 0;
								}
								else
								{
									Globals.Tags.ValveState.Value = Globals.Tags.ValveState.Value.Int + 1;
								}
							}
							else
							{
								Globals.Tags.ValveState.Value = 41;
							}
						}
						else if (Globals.Tags.ValveState.Value.Int == 41)    //Flow incoming, check flow rate and auto select
						{
						//	if (Globals.Tags.RawFlowRateLow.Value.Double > Globals.Tags.LowRangeMax.Value.Double * ( 1 + Globals.Tags.gfSwitchPer.Value.Double / 100) && (int)Globals.Tags.selMeter.Value == 0)
							if (Globals.Tags.RawFlowRateLow.Value.Double > Globals.Tags.LowRangeMax.Value.Double  && (int)Globals.Tags.selMeter.Value == 0)
							{
								if (Globals.Tags.gfSwitchPerLowMid.Value.Double < Globals.Tags.MAXSWITCHPERLIMIT.Value.Double)
								{
									Globals.Tags.gfSwitchPerLowMid.Value += Globals.Tags.SWITCHPERINCREMENT.Value.Double;
								}
								
								Globals.Tags.giPrevOpenMeter.Value = 0;
								Globals.Tags.selMeter.Value = 1;
								Globals.DrawScreen.DrawMainScreen(1);
								Globals.Tags.lblSwitchVisible.Value = 1;
								Globals.Tags.ValveState.Value = Globals.Tags.ValveState.Value.Int + 1;
							}
							else if (Globals.Tags.RawFlowRateMid.Value < Globals.Tags.MidRangeMin.Value * (1 - Globals.Tags.gfSwitchPer.Value.Double / 100) && (int)Globals.Tags.selMeter.Value == 1)
							{
								if (Globals.Tags.gfSwitchPerLowMid.Value.Double < Globals.Tags.MAXSWITCHPERLIMIT.Value.Double)
								{
									Globals.Tags.gfSwitchPerLowMid.Value += Globals.Tags.SWITCHPERINCREMENT.Value.Double;
								}
								
								Globals.Tags.giPrevOpenMeter.Value = 1;
								Globals.Tags.selMeter.Value = 0;
								Globals.DrawScreen.DrawMainScreen(0);
								Globals.Tags.lblSwitchVisible.Value = 1;
								Globals.Tags.ValveState.Value = Globals.Tags.ValveState.Value.Int + 1;
							}
						//	else if (Globals.Tags.RawFlowRateMid.Value > Globals.Tags.MidRangeMax.Value * (1 + Globals.Tags.gfSwitchPer.Value.Double / 100) && (int)Globals.Tags.selMeter.Value == 1)
							else if (Globals.Tags.RawFlowRateMid.Value > Globals.Tags.MidRangeMax.Value  && (int)Globals.Tags.selMeter.Value == 1)
							{
								if (Globals.Tags.gfSwitchPerMidHigh.Value.Double < Globals.Tags.MAXSWITCHPERLIMIT.Value.Double)
								{
									Globals.Tags.gfSwitchPerMidHigh.Value += Globals.Tags.SWITCHPERINCREMENT.Value.Double;
								}
									
								Globals.Tags.giPrevOpenMeter.Value = 1;
								Globals.Tags.selMeter.Value = 2;
								Globals.DrawScreen.DrawMainScreen(2);
								Globals.Tags.lblSwitchVisible.Value = 1;
								Globals.Tags.ValveState.Value = Globals.Tags.ValveState.Value.Int + 1;
							}
							else if (Globals.Tags.RawFlowRateHigh.Value < Globals.Tags.HighRangeMin.Value * (1 - Globals.Tags.gfSwitchPer.Value.Double / 100) && (int)Globals.Tags.selMeter.Value == 2)
							{
								if (Globals.Tags.gfSwitchPer.Value.Double < Globals.Tags.MAXSWITCHPERLIMIT.Value.Double)
								{
									Globals.Tags.gfSwitchPer.Value += Globals.Tags.SWITCHPERINCREMENT.Value.Double;
								}
								
								Globals.Tags.giPrevOpenMeter.Value = 2;
								Globals.Tags.selMeter.Value = 1;
								Globals.DrawScreen.DrawMainScreen(1);
								Globals.Tags.lblSwitchVisible.Value = 1;
								Globals.Tags.ValveState.Value = Globals.Tags.ValveState.Value.Int + 1;
							}
							else if (Globals.Tags.RawFlowRateLow.Value.Double < Globals.Tags.LowRangeMax.Value.Double * ( 1 - Globals.Tags.gfSwitchPerLowMid.Value.Double / 100) && (int)Globals.Tags.selMeter.Value == 0)
							{
								Globals.Tags.gfSwitchPerLowMid.Value = 0;
							}
							else if (Globals.Tags.RawFlowRateMid.Value > Globals.Tags.MidRangeMin.Value * (1 + Globals.Tags.gfSwitchPerLowMid.Value.Double / 100) && (int)Globals.Tags.selMeter.Value == 1)
							{
								Globals.Tags.gfSwitchPerLowMid.Value = 0;		
							}
							else if (Globals.Tags.RawFlowRateMid.Value < Globals.Tags.MidRangeMax.Value * (1 - Globals.Tags.gfSwitchPerMidHigh.Value.Double / 100) && (int)Globals.Tags.selMeter.Value == 1)
							{
								Globals.Tags.gfSwitchPerMidHigh.Value = 0;		
							}
							else if (Globals.Tags.RawFlowRateHigh.Value > Globals.Tags.HighRangeMax.Value * (1 + Globals.Tags.gfSwitchPerMidHigh.Value.Double / 100) && (int)Globals.Tags.selMeter.Value == 2)
							{
								Globals.Tags.gfSwitchPerMidHigh.Value = 0;		
							}
						}
						else if (Globals.Tags.ValveState.Value.Int == 42)
						{
							if (Globals.Comm.SolenoidValves[Globals.Tags.selMeter.Value.Int].currentStatus == ValveStatus.Open)
							{
								Globals.Tags.ValveState.Value = Globals.Tags.ValveState.Value.Int + 1;
							}
							else
							{
								Globals.Tags.tmr485_control.Value = (int)Globals.Tags.selMeter.Value + 9;   //Open selected meter
							}
						}
						else if (Globals.Tags.ValveState.Value.Int == 43)   // Close previously open valve
						{
							if (Globals.Comm.SolenoidValves[Globals.Tags.giPrevOpenMeter.Value.Int].currentStatus == ValveStatus.Close)
							{
								Globals.Tags.ValveState.Value = Globals.Tags.ValveState.Value.Int + 1;
							}
							else
							{
								Globals.Tags.tmr485_control.Value = Globals.Tags.giPrevOpenMeter.Value.Int + 6; //close selected meter
							}
							
						}
						else if (Globals.Tags.ValveState.Value.Int >= 44 && Globals.Tags.ValveState.Value.Int <= 46)
						{
							Globals.Tags.ValveState.Value = Globals.Tags.ValveState.Value.Int + 1;
						}
						else if (Globals.Tags.ValveState.Value.Int >= 47 && Globals.Tags.ValveState.Value.Int <= 63)
						{
							if ( Globals.Comm.FlowMeters[Globals.Tags.selMeter.Value.Int].GetErrorPercentage() < AlicatFlowMeter.dSwitchStabCriteria)
							{
								Globals.Tags.ValveState.Value = 64;
							}
							else
							{
								Globals.Tags.ValveState.Value = Globals.Tags.ValveState.Value.Int + 1;
							}
							
						}
						else if (Globals.Tags.ValveState.Value.Int == 64) // Verify Switch
						{				
							if (Globals.Comm.SolenoidValves[Globals.Tags.selMeter.Value.Int].currentStatus == ValveStatus.Open && 
								Globals.Comm.SolenoidValves[Globals.Tags.giPrevOpenMeter.Value.Int].currentStatus == ValveStatus.Close)
							{
								Globals.Tags.lblSwitchVisible.Value = 0;
								Globals.Tags.ValveState.Value = 41;
							}
							else
							{
								Globals.Tags.ValveState.Value = 42;
							}
						
						}
						
					}
//					else                //No supply, close all, hide switching label
//					{
//						if (Globals.Comm.SolenoidValves[0].currentStatus != ValveStatus.Close)
//						{
//							Globals.Tags.tmr485_control.Value = 6;
//						}
//						else if (Globals.Comm.SolenoidValves[1].currentStatus != ValveStatus.Close)
//						{
//							Globals.Tags.tmr485_control.Value = 7;
//						}
//						else if (Globals.Comm.SolenoidValves[2].currentStatus != ValveStatus.Close)
//						{
//							Globals.Tags.tmr485_control.Value = 8;
//						}

//						if (Globals.Tags.ValveState.Value.Int != 0)
//						{
//							Globals.Tags.ValveState.Value = 0;
//						}

//						if ((int)Globals.Tags.lblSwitchVisible.Value == 1)
//						{
//							Globals.Tags.lblSwitchVisible.Value = 0;
//						}
						
						
//					}
//				}
				else   // Manual mode
				{
					
					
					if ((int)Globals.Tags.lblSwitchVisible.Value == 1)
					{
						Globals.Tags.lblSwitchVisible.Value = 0;
					}
					

					if (Globals.Tags.ValveState.Value.Int == 0)
					{
							// Verify the meter is really opened.
						if (Globals.Comm.SolenoidValves[Globals.Tags.selMeter.Value.Int].currentStatus == ValveStatus.Open)
						{
							Globals.Tags.ValveState.Value = Globals.Tags.ValveState.Value.Int + 1;
						}
						else
						{
							Globals.Tags.tmr485_control.Value = Globals.Tags.selMeter.Value.Int + 9;   //Open selected meter
						}
						
					}
					else if (Globals.Tags.ValveState.Value.Int == 1)
					{
						// Verify the other meter is really closed.
						
						switch (Globals.Tags.selMeter.Value.Int)
						{
							case 0:
								if (Globals.Comm.SolenoidValves[1].currentStatus == ValveStatus.Open)
								{
									Globals.Tags.tmr485_control.Value = 7;
								}
								else if (Globals.Comm.SolenoidValves[2].currentStatus == ValveStatus.Open)
								{
									Globals.Tags.tmr485_control.Value = 8;
								}
								else if (Globals.Comm.SolenoidValves[1].currentStatus == ValveStatus.Close &&
										 Globals.Comm.SolenoidValves[2].currentStatus == ValveStatus.Close)
								{
									Globals.Tags.ValveState.Value = Globals.Tags.ValveState.Value.Int + 1;
								}
								break;
							case 1:
								if (Globals.Comm.SolenoidValves[0].currentStatus == ValveStatus.Open)
								{
									Globals.Tags.tmr485_control.Value = 6;
								}
								else if (Globals.Comm.SolenoidValves[2].currentStatus == ValveStatus.Open)
								{
									Globals.Tags.tmr485_control.Value = 8;
								}
								else if (Globals.Comm.SolenoidValves[0].currentStatus == ValveStatus.Close &&
									Globals.Comm.SolenoidValves[2].currentStatus == ValveStatus.Close)
								{
									Globals.Tags.ValveState.Value = Globals.Tags.ValveState.Value.Int + 1;
								}
								break;
							case 2:
								if (Globals.Comm.SolenoidValves[0].currentStatus == ValveStatus.Open)
								{
									Globals.Tags.tmr485_control.Value = 6;
								}
								else if (Globals.Comm.SolenoidValves[1].currentStatus == ValveStatus.Open)
								{
									Globals.Tags.tmr485_control.Value = 7;
								}
								else if (Globals.Comm.SolenoidValves[0].currentStatus == ValveStatus.Close &&
									Globals.Comm.SolenoidValves[1].currentStatus == ValveStatus.Close)
								{
									Globals.Tags.ValveState.Value = Globals.Tags.ValveState.Value.Int + 1;
								}
								break;
						}
						
					}
					else if (Globals.Tags.ValveState.Value.Int == 2)   // Verify
					{
						switch((int)Globals.Tags.selMeter.Value)
						{
							case 0:
								if (Globals.Comm.SolenoidValves[0].currentStatus == ValveStatus.Open &&
									Globals.Comm.SolenoidValves[1].currentStatus == ValveStatus.Close &&
									Globals.Comm.SolenoidValves[2].currentStatus == ValveStatus.Close)
								{
									Globals.Tags.ValveState.Value = 3;
								}
								else
								{
									Globals.Tags.ValveState.Value = 0;
								}
								break;
							case 1: 
								if (Globals.Comm.SolenoidValves[0].currentStatus == ValveStatus.Close &&
									Globals.Comm.SolenoidValves[1].currentStatus == ValveStatus.Open &&
									Globals.Comm.SolenoidValves[2].currentStatus == ValveStatus.Close)
								{
									Globals.Tags.ValveState.Value = 3;
								}
								else
								{
									Globals.Tags.ValveState.Value = 0;
								}
								break;
							case 2:
								if (Globals.Comm.SolenoidValves[0].currentStatus == ValveStatus.Close &&
									Globals.Comm.SolenoidValves[1].currentStatus == ValveStatus.Close &&
									Globals.Comm.SolenoidValves[2].currentStatus == ValveStatus.Open)
								{
									Globals.Tags.ValveState.Value = 3;
								}
								else
								{
									Globals.Tags.ValveState.Value = 0;
								}
								break;
						}
					}
					
				}
					
					
					
			}
			else if (Globals.Tags.CurrentScreen.Value.Int >= 25 && Globals.Tags.CurrentScreen.Value.Int <= 28) // Quick Fill Screen 0
			{
				if (Globals.Comm.SolenoidValves[0].currentStatus != ValveStatus.Close)
				{
					Globals.Tags.tmr485_control.Value = 6;
				}
				else if (Globals.Comm.SolenoidValves[1].currentStatus != ValveStatus.Close)
				{
					Globals.Tags.tmr485_control.Value = 7;
				}
				else if (Globals.Comm.SolenoidValves[2].currentStatus != ValveStatus.Open)
				{
					Globals.Tags.tmr485_control.Value = 11;
				}
				
			}
			
			
			
			
		}

			
		}
		
		
	
}
