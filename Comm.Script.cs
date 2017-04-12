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
	using System.IO.Ports;
	using System.IO;
	using Neo.ApplicationFramework.Tools.MessageLibrary;
	using System.Collections.Generic;
	
	public partial class Comm
	{
		public SerialPort port232;
		public SerialPort port485;
		private Timer tmr232;
		private Timer tmr485;
		private Timer tmrExpire;
		public List<AlicatFlowMeter> FlowMeters;
		public List<TrafagPressureSensor> PressSensors;
		public List<SolenoidValveController> SolenoidValves;
		public XBeeModule XBee;

		private byte[] mPacket;
		private int[] mCheckHeader = {0,0,0,0};
		private int[] mCheckHeaderFix = {255,255,255,255};
	//	private bool bZeroEnable;
		private const int MAX_FRAME_DATA_SIZE = 256;
		private const int XB_START_BYTE = 0x7e;
		private const int PRESS_START_BYTE = 0x7f;
		private const int SOLENOID_START_BYTE = 0x80;
		private byte[] pData;
		private int iExpireCount = 0;
		Random rnd_num;
		//	private int valve_control_time_out = 0;
		public void Inilialize()
		{
			
			port232 = new SerialPort("COM2", 19200, Parity.None, 8, StopBits.One);
			port485 = new SerialPort("COM1", 57600, Parity.None, 8, StopBits.One);
//			port232 = new SerialPort("COM3", 19200, Parity.None, 8, StopBits.One);
//			port485 = new SerialPort("COM8", 57600, Parity.None, 8, StopBits.One);
			port485.DtrEnable = true;
//			port485.RtsEnable = true;
//			port485.Handshake = Handshake.None;
			tmr232 = new Timer();
			tmr485 = new Timer();
			tmrExpire = new Timer();
			rnd_num = new Random();
			tmr232.Interval = 600;
			tmr485.Interval = 1000;
			tmrExpire.Interval = 1000;
			mPacket = new byte[MAX_FRAME_DATA_SIZE];
			pData = new byte[MAX_FRAME_DATA_SIZE];
			tmrExpire.Tick += new EventHandler(EXPIRE_TICK);
			tmrExpire.Enabled = true;
			
			tmr232.Tick += new EventHandler(RS232_TICK);
			tmr485.Tick += new EventHandler(RS485_TICK);
			
		//	bZeroEnable = false;
			port232.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(Receive_232);
			port485.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(Receive_485);
				
			
			FlowMeters = new List<AlicatFlowMeter>();
			PressSensors = new List<TrafagPressureSensor>();
			SolenoidValves = new List<SolenoidValveController>();	
			
			FlowMeters.Add(new AlicatFlowMeter(
				Globals.TextLibrary.FlowMeterName.Messages[0].Message,
				port232,
				Globals.Tags.meter_unit_low.Value.String,
				Globals.TextLibrary.FlowMeterAddr.Messages[0].Message,
				Globals.Tags.LowRangeMin.Value.Double,
				Globals.Tags.LowRangeMax.Value.Double));
			
			FlowMeters.Add(new AlicatFlowMeter(
				Globals.TextLibrary.FlowMeterName.Messages[1].Message,
				port232,
				Globals.Tags.meter_unit_mid.Value.String,
				Globals.TextLibrary.FlowMeterAddr.Messages[1].Message,
				Globals.Tags.MidRangeMin.Value.Double,
				Globals.Tags.MidRangeMax.Value.Double));

			FlowMeters.Add(new AlicatFlowMeter(
				Globals.TextLibrary.FlowMeterName.Messages[2].Message,
				port232,
				Globals.Tags.meter_unit_high.Value.String,
				Globals.TextLibrary.FlowMeterAddr.Messages[2].Message,
				Globals.Tags.HighRangeMin.Value.Double,
				Globals.Tags.HighRangeMax.Value.Double));
			
			PressSensors.Add(new TrafagPressureSensor(
				Globals.TextLibrary.PressSensorName.Messages[0].Message,
				port485,
				Globals.Tags.PressUnitInlet.Value.String,
				Globals.TextLibrary.PressSensorAddr.Messages[0].Message,
				-1.0,
				Globals.Tags.Inlet_Press_Max.Value));
			
			PressSensors.Add(new TrafagPressureSensor(
				Globals.TextLibrary.PressSensorName.Messages[1].Message,
				port485,
				Globals.Tags.PressUnitTest.Value.String,
				Globals.TextLibrary.PressSensorAddr.Messages[1].Message,
				-1.0,
				Globals.Tags.Test_Press_Max.Value));
				
			SolenoidValves.Add(new SolenoidValveController(
				Globals.TextLibrary.SolenoidValveName.Messages[0].Message,
				port485,
				Globals.TextLibrary.SolenoidValveAddr.Messages[0].Message));

			SolenoidValves.Add(new SolenoidValveController(
				Globals.TextLibrary.SolenoidValveName.Messages[1].Message,
				port485,
				Globals.TextLibrary.SolenoidValveAddr.Messages[1].Message));
			
			SolenoidValves.Add(new SolenoidValveController(
				Globals.TextLibrary.SolenoidValveName.Messages[2].Message,
				port485,
				Globals.TextLibrary.SolenoidValveAddr.Messages[2].Message));	
			
			XBee = new XBeeModule("XBeeWiFi",port485);
			
			try
			{
				port232.Open();
				port485.Open();
				Globals.Tags.IsTouchScreen.Value = true;
			}
			catch
			{

                Stop();
				Globals.Tags.StartBtnEnable.Value = 1;
				MessageBox.Show("Cannot open comports, enter demo mode!");	
				Globals.Tags.IsTouchScreen.Value = false;
			}
			

			
		}
		
		public void Start()
		{
			tmr232.Enabled = true;
			tmr485.Enabled = true;
		}
		
		public void Stop()
		{
			tmr485.Enabled = false;
			tmr232.Enabled = false;
		}
		
		public void End()
		{
			port232.Close();
			port232.Close();
		}
		
		private void EXPIRE_TICK(Object myObject, EventArgs myEventArgs) 
		{
			if (Globals.Tags.CurrentScreen.Value.Int == 60 &&
				Globals.Tags.AutoCalStatus.Value.Int == 1)
			{
				iExpireCount++;
				
				if (iExpireCount > 5)
				{
					Globals.Tags.AutoCalStatus.Value = 0;
				}
				
			}
		}
		
		private void RS232_TICK(Object myObject, EventArgs myEventArgs) 
		{
			if (Globals.Tags.DemoModeOnOff.Value == 1)
			{
				if (Globals.Tags.DemoModeFlowRateLow.Value < Globals.Tags.LowRangeMax.Value &&
					Globals.Tags.DemoModeFlowRateHigh.Value >= Globals.Tags.LowRangeMin.Value)
				{
					Globals.Tags.DemoModeFlowRateLow.Value += rnd_num.NextDouble() * 5;
				}
				else
				{
					Globals.Tags.DemoModeFlowRateLow.Value = Globals.Tags.LowRangeMin.Value;
				}
				
				if (Globals.Tags.DemoModeFlowRateMid.Value < Globals.Tags.MidRangeMax.Value &&
					Globals.Tags.DemoModeFlowRateHigh.Value >= Globals.Tags.MidRangeMin.Value)
				{
					Globals.Tags.DemoModeFlowRateMid.Value += rnd_num.NextDouble() / 10;
				}
				else
				{
					Globals.Tags.DemoModeFlowRateMid.Value = Globals.Tags.MidRangeMin.Value;
				}
				
				if (Globals.Tags.DemoModeFlowRateHigh.Value < Globals.Tags.HighRangeMax.Value &&
					Globals.Tags.DemoModeFlowRateHigh.Value >= Globals.Tags.HighRangeMin.Value)
				{
					Globals.Tags.DemoModeFlowRateHigh.Value += rnd_num.NextDouble() * 10;
				}
				else
				{
					Globals.Tags.DemoModeFlowRateHigh.Value = Globals.Tags.HighRangeMin.Value;
				}
				
				PressSensors[1].dPressure+=0.5;
				
				Globals.CalAndUpdate.UpdateTestPressureTag();
			}
			
			
			if (Globals.Tags.CurrentScreen.Value == 23)
			{
				switch((int)Globals.Tags.tmr232_control.Value)
				{
					case 0:
						if (Globals.Tags.DemoModeOnOff.Value == 1)
						{
							FlowMeters[0].dMassFlowRate = Globals.Tags.DemoModeFlowRateLow.Value;
							Globals.CalAndUpdate.UpdateFlowRateTag();
						}
						else
						{	
							FlowMeters[0].RequestData();
						}

						
						Globals.Tags.tmr232_control.Value++;
						break;
					case 1:
						if (Globals.Tags.DemoModeOnOff.Value == 1)
						{
							FlowMeters[1].dMassFlowRate = Globals.Tags.DemoModeFlowRateMid.Value;
							Globals.CalAndUpdate.UpdateFlowRateTag();
						}
						else
						{
							FlowMeters[1].RequestData();
						}
						Globals.Tags.tmr232_control.Value++;
						break;
					case 2:
						if (Globals.Tags.DemoModeOnOff.Value == 1)
						{
							FlowMeters[2].dMassFlowRate = Globals.Tags.DemoModeFlowRateHigh.Value;
							Globals.CalAndUpdate.UpdateFlowRateTag();
						}
						else
						{
							FlowMeters[2].RequestData();
						}
						

						
						Globals.Tags.tmr232_control.Value = 0;
						break;						
					case 3:
						FlowMeters[0].Zero();
				//		bZeroEnable = true;
						Globals.Tags.tmr232_control.Value = 0;
						break;
					case 4:
						FlowMeters[1].Zero();
				//		bZeroEnable = true;
						Globals.Tags.tmr232_control.Value = 0;
						break;
					case 5:
						FlowMeters[2].Zero();
				//		bZeroEnable = true;
						Globals.Tags.tmr232_control.Value = 0;
						break;
					case 6: // get serial number
						FlowMeters[0].RequestPara(3);
						Globals.Tags.tmr232_control.Value++;
						break;
					case 7: // get serial number
						FlowMeters[1].RequestPara(3);
						Globals.Tags.tmr232_control.Value++;
						break;
					case 8: // get serial number
						FlowMeters[2].RequestPara(3);
						Globals.Tags.tmr232_control.Value = 0;
						break;
				}
			}
		}
		
		private void Receive_232(Object myObject, System.IO.Ports.SerialDataReceivedEventArgs e)
		{
			string strRcv = "";
			int i = 0;
			bool isError = false;
			try
			{
				strRcv = port232.ReadTo("\r");
			}
			catch
			{
				isError = true;
			}
			
			if (!isError)
			{

			//	Globals.Tags.debugstring2.Value = strRcv;

		   //	port485.Write("EXT=" + strRcv + "\r");

				if (strRcv.StartsWith("A"))
				{
					i = 0;
				}
				else if (strRcv.StartsWith("B"))
				{
					i = 1;
				}
				else if (strRcv.StartsWith("C"))
				{
					i = 2;
				}
				
				FlowMeters[i].Receive(strRcv);	

				if ((int)Globals.Tags.CurrentScreen.Value == 23)
				{
					
					switch(i)
					{
						case 0:

							if (FlowMeters[i].iRegResult[0].para_value > Globals.Tags.DiagMaxValueFlow11.Value.Double)
							{
								Globals.Tags.DiagMaxValueFlow11.Value = FlowMeters[i].iRegResult[0].para_value;
								Globals.Tags.DiagMaxValueFlow11Time.Value = DateTime.Now;
								Globals.PersistentVariables.SaveRecipe("Current",false);
							}

							if (FlowMeters[i].iRegResult[1].para_value > Globals.Tags.DiagMaxValueFlow12.Value.Double)
							{
								Globals.Tags.DiagMaxValueFlow12.Value = FlowMeters[i].iRegResult[1].para_value;
								Globals.Tags.DiagMaxValueFlow12Time.Value = DateTime.Now;
								Globals.PersistentVariables.SaveRecipe("Current",false);
							}
								
							if (FlowMeters[i].GetVolFlowRate() > Globals.Tags.DiagMaxValueFlow13.Value.Double)
							{
								Globals.Tags.DiagMaxValueFlow13.Value = FlowMeters[i].GetVolFlowRate();
								Globals.Tags.DiagMaxValueFlow13Time.Value = DateTime.Now;
								Globals.PersistentVariables.SaveRecipe("Current",false);
							}
								
							if (FlowMeters[i].GetMassFlowRate() > Globals.Tags.DiagMaxValueFlow14.Value.Double)
							{
								Globals.Tags.DiagMaxValueFlow14.Value = FlowMeters[i].GetMassFlowRate();
								Globals.Tags.DiagMaxValueFlow14Time.Value = DateTime.Now;
								Globals.PersistentVariables.SaveRecipe("Current",false);
							}

							if ((int)Globals.Tags.selMeter.Value == 0)
							{
								Globals.CalAndUpdate.UpdateFlowRateTag();
							}
							break;
						case 1:

								
							if (Math.Abs(Globals.Tags.RawFlowRateMid.Value.Double) < Globals.Tags.HighRangeZeroBand.Value.Double * Globals.Tags.MidRangeMax.Value.Double / 100)
							{
								Globals.Tags.RawFlowRateMid.Value = 0;
							}
								
							if (FlowMeters[i].iRegResult[0].para_value > Globals.Tags.DiagMaxValueFlow21.Value.Double)
							{
								Globals.Tags.DiagMaxValueFlow21.Value = FlowMeters[i].iRegResult[0].para_value;
								Globals.Tags.DiagMaxValueFlow21Time.Value = DateTime.Now;
								Globals.PersistentVariables.SaveRecipe("Current",false);
							}

							if (FlowMeters[i].iRegResult[1].para_value > Globals.Tags.DiagMaxValueFlow22.Value.Double)
							{
								Globals.Tags.DiagMaxValueFlow22.Value = FlowMeters[i].iRegResult[1].para_value;
								Globals.Tags.DiagMaxValueFlow22Time.Value = DateTime.Now;
								Globals.PersistentVariables.SaveRecipe("Current",false);
							}
								
							if (FlowMeters[i].GetVolFlowRate() > Globals.Tags.DiagMaxValueFlow23.Value.Double)
							{
								Globals.Tags.DiagMaxValueFlow23.Value = FlowMeters[i].GetVolFlowRate();
								Globals.Tags.DiagMaxValueFlow23Time.Value = DateTime.Now;
								Globals.PersistentVariables.SaveRecipe("Current",false);
							}
								
							if (FlowMeters[i].GetMassFlowRate() > Globals.Tags.DiagMaxValueFlow24.Value.Double)
							{
								Globals.Tags.DiagMaxValueFlow24.Value = FlowMeters[i].GetMassFlowRate();
								Globals.Tags.DiagMaxValueFlow24Time.Value = DateTime.Now;
								Globals.PersistentVariables.SaveRecipe("Current",false);
							}
								
							if ((int)Globals.Tags.selMeter.Value == 1)
							{
								Globals.CalAndUpdate.UpdateFlowRateTag();
							}
							break;
						case 2:

								
							if (Math.Abs(Globals.Tags.RawFlowRateHigh.Value.Double) < Globals.Tags.HighRangeZeroBand.Value.Double * Globals.Tags.MidRangeMax.Value.Double / 100)
							{
								Globals.Tags.RawFlowRateHigh.Value = 0;
							}
								
							if (FlowMeters[i].iRegResult[0].para_value > Globals.Tags.DiagMaxValueFlow31.Value.Double)
							{
								Globals.Tags.DiagMaxValueFlow31.Value = FlowMeters[i].iRegResult[0].para_value;
								Globals.Tags.DiagMaxValueFlow31Time.Value = DateTime.Now;
								Globals.PersistentVariables.SaveRecipe("Current",false);
							}

							if (FlowMeters[i].iRegResult[1].para_value > Globals.Tags.DiagMaxValueFlow32.Value.Double)
							{
								Globals.Tags.DiagMaxValueFlow32.Value = FlowMeters[i].iRegResult[1].para_value;
								Globals.Tags.DiagMaxValueFlow32Time.Value = DateTime.Now;
								Globals.PersistentVariables.SaveRecipe("Current",false);
							}
								
							if (FlowMeters[i].GetVolFlowRate() > Globals.Tags.DiagMaxValueFlow33.Value.Double)
							{
								Globals.Tags.DiagMaxValueFlow33.Value = FlowMeters[i].GetVolFlowRate();
								Globals.Tags.DiagMaxValueFlow33Time.Value = DateTime.Now;
								Globals.PersistentVariables.SaveRecipe("Current",false);
							}
								
							if (FlowMeters[i].GetMassFlowRate() > Globals.Tags.DiagMaxValueFlow34.Value.Double)
							{
								Globals.Tags.DiagMaxValueFlow34.Value = FlowMeters[i].GetMassFlowRate();
								Globals.Tags.DiagMaxValueFlow34Time.Value = DateTime.Now;
								Globals.PersistentVariables.SaveRecipe("Current",false);
							}
								
							if ((int)Globals.Tags.selMeter.Value == 2)
							{
								Globals.CalAndUpdate.UpdateFlowRateTag();
							}
							break;
					}

				}
					
			}
			
		}
		
		private void RS485_TICK(Object myObject, EventArgs myEventArgs) 
		{	
			
			if (Globals.Tags.CurrentScreen.Value == 41 ||
                Globals.Tags.CurrentScreen.Value == 23 || 
				(Globals.Tags.CurrentScreen.Value >= 25 && Globals.Tags.CurrentScreen.Value <= 28))
			{
				switch((int)Globals.Tags.tmr485_control.Value)
				{
					case 0:
						SolenoidValves[0].Close_ASC();
						if (Globals.Tags.SolenoidCountA.Value.Int < Globals.Tags.MAXSOLENOIDCOUNT.Value.Int)
						{
							Globals.Tags.SolenoidCountA.Value++;
						}
						Globals.Tags.tmr485_control.Value++;
						break;
					case 1:
						SolenoidValves[1].Close_ASC();
						if (Globals.Tags.SolenoidCountB.Value.Int < Globals.Tags.MAXSOLENOIDCOUNT.Value.Int)
						{
							Globals.Tags.SolenoidCountB.Value++;
						}
						Globals.Tags.tmr485_control.Value++;
						break;
					case 2:
						SolenoidValves[2].Close_ASC();
						if (Globals.Tags.SolenoidCountC.Value.Int < Globals.Tags.MAXSOLENOIDCOUNT.Value.Int)
						{
							Globals.Tags.SolenoidCountC.Value++;
						}
						Globals.Tags.tmr485_control.Value = 0;
						break;
					case 4:
						if (Globals.Tags.DemoModeOnOff.Value == 1)
						{
							PressSensors[0].dPressure = rnd_num.NextDouble() + 110;
						}
						else
						{
							PressSensors[0].SendToPort(PressRequestType.Read, PressDataType.Pressure);
						}
						Globals.Tags.tmr485_control.Value++;

						if(Globals.Tags.InletPressIndicator.Value == 1)
						{
							Globals.CalAndUpdate.UpdateInletPressureTag();
						}
						else
						{
							Globals.CalAndUpdate.UpdateTestPressureTag();
						}
						if (Globals.Tags.wifiStreaming.Value == 1)
						{
							Globals.Tags.gTimerCount.Value++;
					//		XBee.SendMainScreenData();
							if (Globals.Tags.gTimerCount.Value >= 60)
							{
								Globals.Tags.gTimerCount.Value = 0;
								Globals.Tags.wifiStreaming.Value = 0;
								Globals.Tags.RemoteDesktopIcon.Value = 0;
							}
						}
						break;
					case 5:
						if (Globals.Tags.DemoModeOnOff.Value == 1)
						{
							PressSensors[1].dPressure = rnd_num.NextDouble() + 8;
						}
						else
						{
							PressSensors[1].SendToPort(PressRequestType.Read, PressDataType.Pressure);
						}
						Globals.Tags.tmr485_control.Value = 4;
						break;
					case 6:
						SolenoidValves[0].Close_ASC();
						if (Globals.Tags.SolenoidCountA.Value.Int < Globals.Tags.MAXSOLENOIDCOUNT.Value.Int)
						{
							Globals.Tags.SolenoidCountA.Value++;
						}
						Globals.Tags.tmr485_control.Value = 4;
						break;
					case 7:
						SolenoidValves[1].Close_ASC();
						if (Globals.Tags.SolenoidCountB.Value.Int < Globals.Tags.MAXSOLENOIDCOUNT.Value.Int)
						{
							Globals.Tags.SolenoidCountB.Value++;
						}
						Globals.Tags.tmr485_control.Value = 4;
						break;
					case 8:
						SolenoidValves[2].Close_ASC();
						
						if (Globals.Tags.SolenoidCountC.Value.Int < Globals.Tags.MAXSOLENOIDCOUNT.Value.Int)
						{
							Globals.Tags.SolenoidCountC.Value++;
						}
						Globals.Tags.tmr485_control.Value = 4;
						break;
					case 9:
						SolenoidValves[0].Open_ASC();
						if (Globals.Tags.SolenoidCountA.Value.Int < Globals.Tags.MAXSOLENOIDCOUNT.Value.Int)
						{
							Globals.Tags.SolenoidCountA.Value++;
						}
						Globals.Tags.tmr485_control.Value = 4;
						break;
					case 10:
						SolenoidValves[1].Open_ASC();
						if (Globals.Tags.SolenoidCountB.Value.Int < Globals.Tags.MAXSOLENOIDCOUNT.Value.Int)
						{
							Globals.Tags.SolenoidCountB.Value++;
						}
						Globals.Tags.tmr485_control.Value = 4;
						break;
					case 11:
						SolenoidValves[2].Open_ASC();
						if (Globals.Tags.SolenoidCountC.Value.Int < Globals.Tags.MAXSOLENOIDCOUNT.Value.Int)
						{
							Globals.Tags.SolenoidCountC.Value++;
						}
						Globals.Tags.tmr485_control.Value = 4;
						break;
					case 12:
						PressSensors[0].Zero_ASC();
						Globals.Tags.tmr485_control.Value = 4;
						break;
					case 13:
						PressSensors[1].Zero_ASC();
						Globals.Tags.tmr485_control.Value = 4;
						break;
					case 14:		// Send Device Data
						Globals.Tags.tmr232_control.Value = 6;
						Globals.Tags.tmr485_control.Value++;
						break;
					case 15:
						PressSensors[0].RequestPara_ASC(7);
						Globals.Tags.tmr485_control.Value++;
						break;
					case 16:
						PressSensors[1].RequestPara_ASC(7);
						Globals.Tags.tmr485_control.Value++;
						break;
					case 17: // serial number
						pData[0] = 0x01;
						pData[1] = 0x01;
		//				XBee.SendFormatPacket(Globals.Tags.serial.Value.String, 2, pData);
						Globals.Tags.tmr485_control.Value++;
						break;
					case 18: // Firmware number
						pData[0] = 0x01;
						pData[1] = 0x02;
			//			XBee.SendFormatPacket(Globals.Tags.firmware.Value.String, 2, pData);
						Globals.Tags.tmr485_control.Value++;
						break;
					case 19: //  number of flow meters
						pData[0] = 0x01;
						pData[1] = 0x03;
			//			XBee.SendFormatPacket((byte)Globals.Comm.FlowMeters.Count, 2, pData);
						Globals.Tags.tmr485_control.Value++;
						break;
					case 20: // number of pressure sensors
						pData[0] = 0x01;
						pData[1] = 0x04;
			//			XBee.SendFormatPacket((byte)Globals.Comm.PressSensors.Count, 2, pData);
						Globals.Tags.tmr485_control.Value++;
						break;
					case 21: // number of solenoid vavles
						pData[0] = 0x01;
						pData[1] = 0x05;
			//			XBee.SendFormatPacket((byte)Globals.Comm.SolenoidValves.Count, 2, pData);
						Globals.Tags.tmr485_control.Value++;
						break;
					case 22:
						pData[0] = 0x05;
						pData[1] = 0x00;
						pData[2] = 0x00;
						pData[3] = 0x07;
			//			XBee.SendFormatPacket((float)Globals.Comm.FlowMeters[(int)pData[2]].fSerialNum,4,pData);
						Globals.Tags.tmr485_control.Value++;
						break;
					case 23:
						pData[0] = 0x05;
						pData[1] = 0x00;
						pData[2] = 0x01;
						pData[3] = 0x07;
			//			XBee.SendFormatPacket((float)Globals.Comm.FlowMeters[(int)pData[2]].fSerialNum,4,pData);
						Globals.Tags.tmr485_control.Value++;
						break;
					case 24:
						pData[0] = 0x05;
						pData[1] = 0x00;
						pData[2] = 0x02;
						pData[3] = 0x07;
			//			XBee.SendFormatPacket((float)Globals.Comm.FlowMeters[(int)pData[2]].fSerialNum,4,pData);
						Globals.Tags.tmr485_control.Value++;
						break;
					case 25:
						pData[0] = 0x05;
						pData[1] = 0x00;
						pData[2] = 0x00;
						pData[3] = 0x0a;
			//			XBee.SendFormatPacket((float)Globals.Tags.LowRangeMin.Value.Double,4,pData);
						Globals.Tags.tmr485_control.Value++;
						break;
					case 26:
						pData[0] = 0x05;
						pData[1] = 0x00;
						pData[2] = 0x01;
						pData[3] = 0x0a;
		//				XBee.SendFormatPacket((float)Globals.Tags.MidRangeMin.Value.Double,4,pData);
						Globals.Tags.tmr485_control.Value++;
						break;
					case 27:
						pData[0] = 0x05;
						pData[1] = 0x00;
						pData[2] = 0x02;
						pData[3] = 0x0a;
		//				XBee.SendFormatPacket((float)Globals.Tags.HighRangeMin.Value.Double,4,pData);
						Globals.Tags.tmr485_control.Value++;
						break;
					case 28:
						pData[0] = 0x05;
						pData[1] = 0x00;
						pData[2] = 0x00;
						pData[3] = 0x0b;
		//				XBee.SendFormatPacket((float)Globals.Tags.LowRangeMax.Value.Double,4,pData);
						Globals.Tags.tmr485_control.Value++;
						break;
					case 29:
						pData[0] = 0x05;
						pData[1] = 0x00;
						pData[2] = 0x01;
						pData[3] = 0x0b;
	//					XBee.SendFormatPacket((float)Globals.Tags.MidRangeMax.Value.Double,4,pData);
						Globals.Tags.tmr485_control.Value++;
						break;
					case 30:
						pData[0] = 0x05;
						pData[1] = 0x00;
						pData[2] = 0x02;
						pData[3] = 0x0b;
	//					XBee.SendFormatPacket((float)Globals.Tags.HighRangeMax.Value.Double,4,pData);
						Globals.Tags.tmr485_control.Value++;
						break;
					case 31:
						pData[0] = 0x05;
						pData[1] = 0x00;
						pData[2] = 0x00;
						pData[3] = 0x0c;
	//					XBee.SendFormatPacket((byte)Globals.Tags.meter_unit_low.Value.Int,4,pData);
						Globals.Tags.tmr485_control.Value++;
						break;
					case 32:
						pData[0] = 0x05;
						pData[1] = 0x00;
						pData[2] = 0x01;
						pData[3] = 0x0c;
	//					XBee.SendFormatPacket((byte)Globals.Tags.meter_unit_mid.Value.Int,4,pData);
						Globals.Tags.tmr485_control.Value++;
						break;
					case 33:
						pData[0] = 0x05;
						pData[1] = 0x00;
						pData[2] = 0x02;
						pData[3] = 0x0c;
	//					XBee.SendFormatPacket((byte)Globals.Tags.meter_unit_high.Value.Int,4,pData);
						Globals.Tags.tmr485_control.Value++;
						break;
					case 34:
						pData[0] = 0x05;
						pData[1] = 0x01;
						pData[2] = 0x00;
						pData[3] = 0x07;
	//					XBee.SendFormatPacket(Globals.Comm.PressSensors[(int)pData[2]].uiSerialNum,4,pData);
						Globals.Tags.tmr485_control.Value++;
						break;
					case 35:
						pData[0] = 0x05;
						pData[1] = 0x01;
						pData[2] = 0x01;
						pData[3] = 0x07;
	//					XBee.SendFormatPacket(Globals.Comm.PressSensors[(int)pData[2]].uiSerialNum,4,pData);
						Globals.Tags.tmr485_control.Value++;
						break;
					case 36:
						pData[0] = 0x05;
						pData[1] = 0x01;
						pData[2] = 0x00;
						pData[3] = 0x08;
	//					XBee.SendFormatPacket((float)0.0,4,pData);
						Globals.Tags.tmr485_control.Value++;
						break;
					case 37:
						pData[0] = 0x05;
						pData[1] = 0x01;
						pData[2] = 0x01;
						pData[3] = 0x08;
	//					XBee.SendFormatPacket((float)0.0,4,pData);
						Globals.Tags.tmr485_control.Value++;
						break;
					case 38:
						pData[0] = 0x05;
						pData[1] = 0x01;
						pData[2] = 0x00;
						pData[3] = 0x09;
//						XBee.SendFormatPacket((float)Globals.Tags.Inlet_Press_Max.Value.Double,4,pData);
						Globals.Tags.tmr485_control.Value++;
						break;
					case 39:
						pData[0] = 0x05;
						pData[1] = 0x01;
						pData[2] = 0x01;
						pData[3] = 0x09;
	//					XBee.SendFormatPacket((float)Globals.Tags.Test_Press_Max.Value.Double,4,pData);
						Globals.Tags.tmr485_control.Value++;
						break;
					
					case 40:
						pData[0] = 0x05;
						pData[1] = 0x01;
						pData[2] = 0x00;
						pData[3] = 0x0a;
	//					XBee.SendFormatPacket((byte)Globals.Tags.press_meter_unit.Value.Double,4,pData);
						Globals.Tags.tmr485_control.Value++;
						break;
					case 41:
						pData[0] = 0x05;
						pData[1] = 0x01;
						pData[2] = 0x01;
						pData[3] = 0x0a;
	//					XBee.SendFormatPacket((byte)Globals.Tags.press_meter_unit.Value.Double,4,pData);
						Globals.Tags.tmr485_control.Value++;
						break;
					

					case 42:
						pData[0] = 0x05;
						pData[1] = 0x02;
						pData[2] = 0x00;
						pData[3] = 0x00;
	//					XBee.SendFormatPacket((byte)Globals.Comm.SolenoidValves[(int)pData[2]].currentStatus,4,pData);
						Globals.Tags.tmr485_control.Value++;
						break;
					case 43:
						pData[0] = 0x05;
						pData[1] = 0x02;
						pData[2] = 0x01;
						pData[3] = 0x00;
//						XBee.SendFormatPacket((byte)Globals.Comm.SolenoidValves[(int)pData[2]].currentStatus,4,pData);
						Globals.Tags.tmr485_control.Value++;
						break;
					case 44:
						pData[0] = 0x05;
						pData[1] = 0x02;
						pData[2] = 0x02;
						pData[3] = 0x00;
//						XBee.SendFormatPacket((byte)Globals.Comm.SolenoidValves[(int)pData[2]].currentStatus,4,pData);
						Globals.Tags.tmr485_control.Value++;
						break;
					
					case 45:
						pData[0] = 0x05;
						pData[1] = 0x02;
						pData[2] = 0x00;
						pData[3] = 0x01;
//						XBee.SendFormatPacket((float)Globals.Comm.SolenoidValves[(int)pData[2]].openVoltage,4,pData);
						Globals.Tags.tmr485_control.Value++;
						break;
					case 46:
						pData[0] = 0x05;
						pData[1] = 0x02;
						pData[2] = 0x01;
						pData[3] = 0x01;
//						XBee.SendFormatPacket((float)Globals.Comm.SolenoidValves[(int)pData[2]].openVoltage,4,pData);
						Globals.Tags.tmr485_control.Value++;
						break;
					case 47:
						pData[0] = 0x05;
						pData[1] = 0x02;
						pData[2] = 0x02;
						pData[3] = 0x01;
//						XBee.SendFormatPacket((float)Globals.Comm.SolenoidValves[(int)pData[2]].openVoltage,4,pData);
						Globals.Tags.tmr485_control.Value++;
						break;
					
					case 48:
						pData[0] = 0x05;
						pData[1] = 0x02;
						pData[2] = 0x00;
						pData[3] = 0x02;
//						XBee.SendFormatPacket((float)Globals.Comm.SolenoidValves[(int)pData[2]].closeVoltage,4,pData);
						Globals.Tags.tmr485_control.Value++;
						break;
					case 49:
						pData[0] = 0x05;
						pData[1] = 0x02;
						pData[2] = 0x01;
//						pData[3] = 0x02;
//						XBee.SendFormatPacket((float)Globals.Comm.SolenoidValves[(int)pData[2]].closeVoltage,4,pData);
						Globals.Tags.tmr485_control.Value++;
						break;
					case 50:
						pData[0] = 0x05;
						pData[1] = 0x02;
						pData[2] = 0x02;
						pData[3] = 0x02;
//						XBee.SendFormatPacket((float)Globals.Comm.SolenoidValves[(int)pData[2]].closeVoltage,4,pData);
						Globals.Tags.tmr485_control.Value++;
						break;
					case 51:
						pData[0] = 0x07;
						pData[1] = 0x04;
//						XBee.SendFormatPacket((float)Globals.Comm.SolenoidValves[(int)pData[2]].closeVoltage,4,pData);
						Globals.Tags.tmr485_control.Value = 4;
						break;
					
				}
			}
			
		}
		
		private void Receive_485(Object myObject, System.IO.Ports.SerialDataReceivedEventArgs e)
		{
			string strRcv = "";
			bool isError = false;
			try
			{
				strRcv = port485.ReadTo("\r\n");
			}
			catch
			{
				isError = true;
			}
			
			if (!isError)
			{
				
				if (strRcv.StartsWith("E") && Globals.Tags.CurrentScreen.Value.Int == 60)
				{
					// Reset expire timer
					iExpireCount = 0;
					Globals.Tags.AutoCalStatus.Value = 1;
					
					
					if (strRcv.StartsWith("ESRTA"))
					{
						Globals.Tags.FlowMeterReadTag.Value = 0;
						port485.Write("EXT=FLOWOUT=A\r");
					}
					else if (strRcv.StartsWith("ESRTB"))
					{
						Globals.Tags.FlowMeterReadTag.Value = 1;
						port485.Write("EXT=FLOWOUT=B\r");
					}
					else if (strRcv.StartsWith("ESRTC"))
					{
						Globals.Tags.FlowMeterReadTag.Value = 2;
						port485.Write("EXT=FLOWOUT=C\r");
					}
					else if (strRcv.StartsWith("EGENR"))
					{
						FlowMeters[Globals.Tags.FlowMeterReadTag.Value.Int].RequestData();
					}
					else if (strRcv.StartsWith("EGSG=AIR"))
					{
						Globals.Tags.gasType.Value = 0;
						port485.Write("EXT=FLOWGAS=AIR\r");
					}
					else if (strRcv.StartsWith("EGSG=N2"))
					{
						Globals.Tags.gasType.Value = 1;
						port485.Write("EXT=FLOWGAS=N2\r");
					}
					else if (strRcv.StartsWith("EARF"))
					{
						FlowMeters[0].RequestData();
					}
					else if (strRcv.StartsWith("EAZR"))
					{
						FlowMeters[0].Zero();
					}
					else if (strRcv.StartsWith("EARS25"))
					{
						FlowMeters[0].RequestPara(4);
					}
					else if (strRcv.StartsWith("EARS100"))
					{
						FlowMeters[0].RequestPara(5);
					}
					else if (strRcv.StartsWith("EASS25="))
					{
						int equal_pos = strRcv.IndexOf('=');
						
						string sub = strRcv.Substring(equal_pos + 1);
						
						sub = sub.Trim();
						
						double value_in = 0;
						
						try{
							value_in = Double.Parse(sub);
						}
						catch{
							value_in = -1;
						}
						
						if (value_in != -1)
						{
							FlowMeters[0].RequestChange(4,value_in);	
						}
						
					}
					else if (strRcv.StartsWith("EASS100="))
					{
						int equal_pos = strRcv.IndexOf('=');
						
						string sub = strRcv.Substring(equal_pos + 1);
						
						sub = sub.Trim();
						
						double value_in = 0;
						
						try{
							value_in = Double.Parse(sub);
						}
						catch{
							value_in = -1;
						}
						
						if (value_in != -1)
						{
							FlowMeters[0].RequestChange(5,value_in);	
						}
					}
					else if (strRcv.StartsWith("EBRF"))
					{
						FlowMeters[1].RequestData();
					}
					else if (strRcv.StartsWith("EBZR"))
					{
						FlowMeters[1].Zero();
					}
					else if (strRcv.StartsWith("EBRS25"))
					{
						FlowMeters[1].RequestPara(4);
					}
					else if (strRcv.StartsWith("EBRS100"))
					{
						FlowMeters[1].RequestPara(5);
					}
					else if (strRcv.StartsWith("EBSS25="))
					{
						int equal_pos = strRcv.IndexOf('=');
						
						string sub = strRcv.Substring(equal_pos + 1);
						
						sub = sub.Trim();
						
						double value_in = 0;
						
						try{
							value_in = Double.Parse(sub);
						}
						catch{
							value_in = -1;
						}
						
						if (value_in != -1)
						{
							FlowMeters[1].RequestChange(4,value_in);	
						}
						
					}
					else if (strRcv.StartsWith("EBSS100="))
					{
						int equal_pos = strRcv.IndexOf('=');
						
						string sub = strRcv.Substring(equal_pos + 1);
						
						sub = sub.Trim();
						
						double value_in = 0;
						
						try{
							value_in = Double.Parse(sub);
						}
						catch{
							value_in = -1;
						}
						
						if (value_in != -1)
						{
							FlowMeters[1].RequestChange(5,value_in);	
						}
					}
					else if (strRcv.StartsWith("ECRF"))
					{
						FlowMeters[2].RequestData();
					}
					else if (strRcv.StartsWith("ECZR"))
					{
						FlowMeters[2].Zero();
					}
					else if (strRcv.StartsWith("ECRS25"))
					{
						FlowMeters[2].RequestPara(4);
					}
					else if (strRcv.StartsWith("ECRS100"))
					{
						FlowMeters[2].RequestPara(5);
					}
					else if (strRcv.StartsWith("ECSS25="))
					{
						int equal_pos = strRcv.IndexOf('=');
						
						string sub = strRcv.Substring(equal_pos + 1);
						
						sub = sub.Trim();
						
						double value_in = 0;
						
						try{
							value_in = Double.Parse(sub);
						}
						catch{
							value_in = -1;
						}
						
						if (value_in != -1)
						{
							FlowMeters[2].RequestChange(4,value_in);	
						}
						
					}
					else if (strRcv.StartsWith("ECSS100="))
					{
						int equal_pos = strRcv.IndexOf('=');
						
						string sub = strRcv.Substring(equal_pos + 1);
						
						sub = sub.Trim();
						
						double value_in = 0;
						
						try{
							value_in = Double.Parse(sub);
						}
						catch{
							value_in = -1;
						}
						
						if (value_in != -1)
						{
							FlowMeters[2].RequestChange(5,value_in);	
						}
					}
					else if (strRcv.StartsWith("EOPENA"))
					{
						SolenoidValves[0].Open_ASC();
					}
					else if (strRcv.StartsWith("ECLOSEA"))
					{
						SolenoidValves[0].Close_ASC();
					}
					else if (strRcv.StartsWith("EOPENB"))
					{
						SolenoidValves[1].Open_ASC();
					}
					else if (strRcv.StartsWith("ECLOSEB"))
					{
						SolenoidValves[1].Close_ASC();
					}
					else if (strRcv.StartsWith("EOPENC"))
					{
						SolenoidValves[2].Open_ASC();
					}
					else if (strRcv.StartsWith("ECLOSEC"))
					{
						SolenoidValves[2].Close_ASC();
					}
				}
				else
				{
					if (Globals.Tags.CurrentScreen.Value.Int == 60)
					{
						port485.Write("EXT=" + strRcv + "\r");
					}
					
					if (strRcv.StartsWith("1"))
					{
						PressSensors[0].Receive(strRcv);
						
						if (PressSensors[0].GetPress() > Globals.Tags.DiagMaxValuePress1.Value.Double)
						{
							Globals.Tags.DiagMaxValuePress1.Value = PressSensors[0].GetPress();
							Globals.Tags.DiagMaxValuePress1Time.Value = DateTime.Now;
							Globals.PersistentVariables.SaveRecipe("Current",false);
						}

						Globals.CalAndUpdate.UpdateInletPressureTag();
					}
					else if (strRcv.StartsWith("2"))
					{
						PressSensors[1].Receive(strRcv);
						if (PressSensors[1].GetPress() > Globals.Tags.DiagMaxValuePress2.Value.Double)
						{
							Globals.Tags.DiagMaxValuePress2.Value = PressSensors[1].GetPress();
							Globals.Tags.DiagMaxValuePress2Time.Value = DateTime.Now;
							Globals.PersistentVariables.SaveRecipe("Current",false);
						}
						if (Globals.Tags.InletPressIndicator.Value == 0)
						{
							Globals.CalAndUpdate.UpdateTestPressureTag();
						}
					}
					else if (strRcv.StartsWith("openA") || strRcv.StartsWith("closeA"))
					{
						SolenoidValves[0].Receive(strRcv);
					}
					else if (strRcv.StartsWith("openB") || strRcv.StartsWith("closeB"))
					{
						SolenoidValves[1].Receive(strRcv);
					}
					else if (strRcv.StartsWith("openC") || strRcv.StartsWith("closeC"))
					{
						SolenoidValves[2].Receive(strRcv);
					}
				}

				
				
			}
			
		}
		
		static int getPacketLength(int msbL, int lsbL)
		{
			return ((msbL << 8) & 0xff) + (lsbL & 0xff);
		}
 
		static bool ArraysEqual<T>(T[] a1, T[] a2)
		{
			if (ReferenceEquals(a1, a2))
				return true;

			if (a1 == null || a2 == null)
				return false;

			if (a1.Length != a2.Length)
				return false;

			EqualityComparer<T> comparer = EqualityComparer<T>.Default;
			for (int i = 0; i < a1.Length; i++)
			{
				if (!comparer.Equals(a1[i], a2[i])) return false;
			}
			return true;
		}
		
		
	}
}
