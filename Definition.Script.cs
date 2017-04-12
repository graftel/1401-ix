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
	using System.IO.Ports;
	using System.Collections.Generic;
	//	using System.Threading;
	using System.Text;
	
	public enum FlowUnits
	{
		sccm,
		slpm,
		scfm,
		scfh,
		slph
	}


	
	public enum DataStatus
	{
		NotAvailable,
		Timeout,
		Available
	}
	
	public enum ParaStatus
	{
		NotAvailable,
		Pass,
		Warning,
	}
	
	public struct ParaResult
	{
		public ParaStatus para_result;
		public double para_value;
		
		public void Reset()
		{
			para_result = ParaStatus.NotAvailable;
			para_value = 0.0;
		}
	}
	
	public class Meter
	{
		public string sName {get ; set; }
		protected SerialPort mPort;
		protected string sAddr;
		public double dMeterReading;
			
		public Meter ()
		{	
		}
		
		public Meter(string inName, SerialPort inPort)
		{
			mPort = inPort;
			this.sName = inName;
		}
	}
	
	public class Controller
	{
		public string sName {get; set; }
		protected SerialPort mPort;
		protected string sAddr;
	}
	
	public class AlicatFlowMeter : Meter
	{
		public double dPreMassFlowRate;
		public double dMassFlowRate;
		public double dVolFlowRate;
		public double dPressure;
		public double dTemp;
		public string sManufacturer = "Alicat";
		public FlowUnits iMeterUnit = FlowUnits.sccm;
		public string sSerialNum;
		public float fSerialNum;
		public double dMaxFlow;
		public double dMinFlow;
		// Diagnostic Definitions
		public const int iParaCount = 9;
		public const int iRegCount = 4;
		private int[] iParaIndex = {8,10,31,76,26,43,41,33,34};
		// 8 Health of Absolute Pressure Sensor
		// 10 Health of Differential Pressure Sensor
		// 31 Tera indicator
		// 76 Serial Number
		private double[] dRegUpLimit;
		private double[] dRegLowLimit;
		private int[] iUpperLimit = {62000, 62000, 1000, 99999999, Int32.MaxValue,Int32.MaxValue,Int32.MaxValue,Int32.MaxValue,Int32.MaxValue};
		private int[] iLowerLimit = {1000,  1000 ,-1000,        0, Int32.MinValue,Int32.MinValue,Int32.MinValue,Int32.MinValue,Int32.MinValue};
		// -1 not applicable
		public ParaResult[] iParaResult;
		public ParaResult[] iRegResult;
		private DataStatus eDataStatus = DataStatus.NotAvailable;
		public const double dSwitchStabCriteria = 0.1;
	
		//		private int iSentTimeout = 10000; //ms
		
		//		private Timer tTimeout;     // To do rewrite timeout scheme
		
		public AlicatFlowMeter(string inName, SerialPort inPort, string inFlowUnit, string inAddr, double MinFlow, double MaxFlow)
		{
			this.mPort = inPort;
			this.sName = inName;
			//	this.iMeterUnit = inMeterUnit;
			this.sAddr = inAddr;
			this.dMaxFlow = MaxFlow;
			this.dMinFlow = MinFlow;

			dRegUpLimit = new double[4];
			dRegLowLimit = new double[4];
			
			dRegUpLimit[0] = 120.0;
			dRegUpLimit[1] = 100.0;
			dRegUpLimit[2] = MaxFlow;
			dRegUpLimit[3] = MaxFlow;
				
			dRegLowLimit[0] = 10.0;
			dRegLowLimit[1] = -50.0;
			dRegLowLimit[2] = -MaxFlow;
			dRegLowLimit[3] = -MaxFlow;
					
			if (inFlowUnit.Contains("0"))
			{
				this.iMeterUnit = FlowUnits.sccm;
			}
			else if (inFlowUnit.Contains("1"))
			{
				this.iMeterUnit = FlowUnits.slpm;
			}
			else if (inFlowUnit.Contains("2"))
			{
				this.iMeterUnit = FlowUnits.scfm;
			}
			else if (inFlowUnit.Contains("3"))
			{
				this.iMeterUnit = FlowUnits.scfh;
			}
			else if (inFlowUnit.Contains("4"))
			{
				this.iMeterUnit = FlowUnits.slph;
			}
			else
			{
				this.iMeterUnit = FlowUnits.sccm;
			}
			//	tTimeout = new Timer();
			//	tTimeout.Interval = iSentTimeout;
			//	tTimeout.Tick += TIMEOUT_TICK;
			iParaResult = new ParaResult[iParaCount];
			iRegResult = new ParaResult[iRegCount];
		}
		
		//	private void TIMEOUT_TICK(Object myObject, EventArgs myEventArgs)
		//		{
		//			eDataStatus = DataStatus.Timeout;
		//			tTimeout.Enabled = false;
		//		}
		
		public void RequestData()
		{
			eDataStatus = DataStatus.NotAvailable;
			//			tTimeout.Enabled = true;
			if (Globals.Tags.IsTouchScreen.Value.Bool)
			{
				mPort.Write(sAddr + "\r");
			}
		}
		
		public bool CheckZero()
		{
			if (dMassFlowRate < 0.005 * dMaxFlow)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool CheckZeroPass()
		{
			if (dMassFlowRate < 0.005 * dMaxFlow)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
		public void Zero()
		{
			if (Globals.Tags.IsTouchScreen.Value.Bool)
			{
				mPort.Write(sAddr + "$$V\r");
			}
		}
		
		public void RequestChange(int paraIndex, double inputValue)
		{
			string strValue = inputValue.ToString("F0");
			
			if (Globals.Tags.IsTouchScreen.Value.Bool)
			{
				mPort.Write(sAddr + "$$W" + iParaIndex[paraIndex].ToString() + "=" + strValue + "\r");
			}
		}
		
		public void RequestPara(int paraIndex)
		{
			//			tTimeout.Enabled = true;
			if (Globals.Tags.IsTouchScreen.Value.Bool)
			{
				mPort.Write(sAddr + "$$R" + iParaIndex[paraIndex].ToString() + "\r");
			}
		}

		public DataStatus GetDataStatus()
		{
			return eDataStatus;
		}
		public void ResetPara()
		{
			//dDiagResult = {0,0,0,0iParaIndex

			for (int i = 0; i < iParaCount; i++)
			{
				iParaResult[i].Reset();
			}

			for (int i = 0; i < iRegCount; i++)
			{
				iRegResult[i].Reset();
			}
			
			eDataStatus = DataStatus.NotAvailable;
			
		}
		
		public ParaResult GetDiagResult(int iIndex)
		{
			return iParaResult[iIndex];
		}
		
		public ParaResult GetRegResult(int iIndex)
		{
			return iRegResult[iIndex];
		}
		
		public double GetFlowRate()
		{
			return dMassFlowRate;
		}
		public int GetParaCount()
		{
			return iParaCount;
		}

		

		public bool CheckMassFlowRate()
		{
			if (dMassFlowRate <= dMaxFlow)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public int CountTotalWarnings()
		{
			int iTotalWarnings = 0;
			for (int i = 0; i < iRegCount; i++)
			{
				if (iRegResult[i].para_result == ParaStatus.Warning)
				{
					iTotalWarnings++;
				}
			}
		
			for (int i = 0; i < iParaCount; i++)
			{
				if (iParaResult[i].para_result == ParaStatus.Warning)
				{
					iTotalWarnings++;
				}
			}
			
			return iTotalWarnings++;
			
		}
		
		public bool CheckVolFlowRate()
		{
			if (dVolFlowRate <= dMaxFlow)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
		public double GetPreFlowRate()
		{
			return dPreMassFlowRate;
		}

		public double GetVolFlowRate()
		{
			return dVolFlowRate;
		}
		
		public double GetMassFlowRate()
		{
			return dMassFlowRate;
		}
		
		public double GetPressure()
		{
			return dPressure;
		}

		public double GetTemp()
		{
			return dTemp;
		}
		
		public double GetErrorPercentage()
		{
			return 	Math.Abs(dPreMassFlowRate - dMassFlowRate) * 100 / dMaxFlow;
		}
		
		public bool CheckPressure()
		{
			if (dPressure > 10 && dPressure < 120)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
		public bool CheckTemp()
		{
			if (dTemp > 100)
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		public void Receive(string strInput)
		{
			// only receive data match address
			if (strInput.StartsWith(sAddr))
			{
				eDataStatus = DataStatus.Available;
				
				string[] split_data = strInput.Split(' ');
				
				List<string> data = new List<string>();
						
				foreach (string str in split_data)
				{
					if(!String.IsNullOrEmpty(str))
					{
						data.Add(str);
					}
				}
				
				if (data.Count >= 4)
				{
					//					tTimeout.Enabled = false;
					eDataStatus = DataStatus.Available;
					if (data.Contains("="))  //diagnostic data or calibration data
					{
						int parse_index;
						
						try{
							parse_index = Int32.Parse(data[1]);
						}
						catch
						{
							parse_index = 0;
						}

						Globals.Comm.port485.Write("EXT=" + strInput + "\r");

						for (int i = 0; i < iParaCount; i++)
						{
							if (parse_index == iParaIndex[i])
							{
								int out_value = 0;

								bool IsGetValue = true;
								try
								{
									out_value = Int32.Parse(data[3]);
								}
								catch
								{
									IsGetValue = false;
								}
								
								if (IsGetValue)
								{
									ParaResult result = new ParaResult();
									
									
									if (out_value >= iLowerLimit[i] && out_value <= iUpperLimit[i])
									{
										result.para_result = ParaStatus.Pass;
										result.para_value = out_value;
									}
									else
									{
										result.para_result = ParaStatus.Warning;
										result.para_value = out_value;
									}
									
									iParaResult[i] = result;
									
									if (parse_index == 76)
									{
										fSerialNum = (float)out_value;
										this.sSerialNum = result.para_value.ToString();
									}
									else if (parse_index == 26)
									{
										switch(sAddr)
										{
											case "A":
												Globals.Tags.LowFlowSpan25.Value = result.para_value;
												break;
											case "B":
												Globals.Tags.MidFlowSpan25.Value = result.para_value;
												break;
											case "C":
												Globals.Tags.HighFlowSpan25.Value = result.para_value;
												break;
										}
									}
									else if (parse_index == 43)
									{
										switch(sAddr)
										{
											case "A":
												Globals.Tags.LowFlowSpan100.Value = result.para_value;
												break;
											case "B":
												Globals.Tags.MidFlowSpan100.Value = result.para_value;
												break;
											case "C":
												Globals.Tags.HighFlowSpan100.Value = result.para_value;
												break;
										}
									}
								}
								
							}
						}
					}
					
					if (data.Count >= 5) // regular data
					{
					
						for (int i = 1; i < 5; i++)
						{
							double out_value = 0.0;

							try
							{
								out_value = Double.Parse(data[i]);
							}
							catch
							{
								out_value = 0;
							}
							
							if (out_value >= dRegLowLimit[i-1] && out_value <= dRegUpLimit[i-1])
							{
								iRegResult[i-1].para_result = ParaStatus.Pass;
								iRegResult[i-1].para_value = out_value;
							}
							else
							{
								iRegResult[i-1].para_result = ParaStatus.Warning;
								iRegResult[i-1].para_value = out_value;
							}
							
							switch (i)
							{
								case 1:
									dPressure = out_value;
									break;
								case 2:
									dTemp = out_value;
									break;
								case 3:
									dVolFlowRate = out_value;
									break;
								case 4:
									dPreMassFlowRate = dMassFlowRate;
									dMassFlowRate = out_value;
									break;
							}

							
							
							if (Globals.Tags.CurrentScreen.Value.Int == 60)
							{
								
								string str_out_flow = "";
								double dOutVolFlowRate = 0;
								double dOutMassFlowRate = 0;
								

								
								switch (sAddr)
								{
									case "A":		
										dOutVolFlowRate = Globals.UnitsAndConversion.FlowConv(dVolFlowRate, Globals.Tags.meter_unit_low.Value.Int,0) * Globals.UnitsAndConversion.GetGasCoeff(Globals.Tags.gasType.Value.Int);
										dOutMassFlowRate =  Globals.UnitsAndConversion.FlowConv(dMassFlowRate, Globals.Tags.meter_unit_low.Value.Int,0) * Globals.UnitsAndConversion.GetGasCoeff(Globals.Tags.gasType.Value.Int);
										Globals.Tags.RawFlowRateLow.Value = dOutMassFlowRate;
										Globals.Tags.CalFlowRateLow.Value = dOutMassFlowRate.ToString("F2") + "sccm";
										break;
									case "B":
										dOutVolFlowRate = Globals.UnitsAndConversion.FlowConv(dVolFlowRate, Globals.Tags.meter_unit_mid.Value.Int,0) * Globals.UnitsAndConversion.GetGasCoeff(Globals.Tags.gasType.Value.Int);
										dOutMassFlowRate = Globals.UnitsAndConversion.FlowConv(dMassFlowRate, Globals.Tags.meter_unit_mid.Value.Int,0) * Globals.UnitsAndConversion.GetGasCoeff(Globals.Tags.gasType.Value.Int);
										Globals.Tags.RawFlowRateMid.Value = dOutMassFlowRate;
										Globals.Tags.CalFlowRateMid.Value = dOutMassFlowRate.ToString("F2") + "sccm";
										break;
									case "C":
										dOutVolFlowRate = Globals.UnitsAndConversion.FlowConv(dVolFlowRate, Globals.Tags.meter_unit_high.Value.Int,0) * Globals.UnitsAndConversion.GetGasCoeff(Globals.Tags.gasType.Value.Int);
										dOutMassFlowRate = Globals.UnitsAndConversion.FlowConv(dMassFlowRate, Globals.Tags.meter_unit_high.Value.Int,0) * Globals.UnitsAndConversion.GetGasCoeff(Globals.Tags.gasType.Value.Int);
										Globals.Tags.RawFlowRateHigh.Value = dOutMassFlowRate;
										Globals.Tags.CalFlowRateHigh.Value = dOutMassFlowRate.ToString("F2") + "sccm";
										break;
								}
								

								
								str_out_flow = sAddr + " " + dPressure.ToString("F2") + " " + dTemp.ToString("F2") + " " + dOutVolFlowRate.ToString("F3") + " " + dOutMassFlowRate.ToString("F3");
								
								Globals.Comm.port485.Write("EXT=" + str_out_flow + "\r");
							}
							
						}
					}
					
					
					
					
				}
				
			}
		}
		
	}
	
	public enum PressRequestType
	{
		Read,
		Set
	}
	
	public enum PressDataType
	{
		Pressure,
		Temperature,
		Span,
		Offset,
		PressureStatus,
		TemperatureStatus,
		Error,
		SerialNum
	}
	public enum PressUnits
	{
		psig,
		ksi,
		bar
	}
	
	public class TrafagPressureSensor : Meter
	{
		private double dPrePressure = 0.0;
		public double dPressure = 0.0;
		public string sManufacturer = "Trafag";
		private double dTemp = 0.0;
		private double dSpan = 0.0;
		private double dOffset = 0.0;
		private double dMinPress = 0.0;
		private double dMaxPress = 0.0;
		private double dPressZero = 0.0;
		public PressUnits iUnit = PressUnits.psig;
		private string sZero = "ZR";
		private string[] sRequestType = {"R","S"};
		private byte[] cmdRequestType = {0x40, 0x22};
		private string[] sDataType = {"P","T","S","O","PS","TS","E","SN"};
		private byte cmdRead = 0x40;
		private byte cmdWrite = 0x22;
		private byte[] cmd1 = {0x30,0x61,0x01};
		private byte[] cmd2 = {0x30,0x61,0x02};
		private byte[] cmd3 = {0x26,0x61,0x01};
		private byte[] cmd4 = {0x27,0x61,0x01};
		private byte[] cmd5 = {0x50,0x61,0x01};
		private byte[] cmd6 = {0x50,0x61,0x02};
		private byte[] cmd7 = {0x01,0x10,0x00};
		private byte[] cmd8 = {0x18,0x10,0x04};
		private byte unitID;
		private byte[] cmdSave = {0x22,0x10,0x10,0x01,0x73,0x61,0x76,0x65};
		private byte[] cmdZero = {0x22,0x25,0x61,0x01,0x7a,0x65,0x72,0x6f};
		
		private List<byte[]> sCmdList;
		public double[] dResult = {0.0,0.0,0.0,0.0,0.0,0.0,0.0,0.0};
		public ParaResult[] pResult;
		public const int iParaCount = 8;
		private double[] dMaxValue = {200, 200, Double.MaxValue, Double.MaxValue, 0,0,0,UInt32.MaxValue};
		private double[] dMinValue = {-5, -50, Double.MinValue, Double.MinValue, 0,0,0, UInt32.MinValue};
		private DataStatus eDataStatus = DataStatus.NotAvailable;
		//		private Timer tTimeout;
		//		private int iSentTimeout = 2000; //ms
		public string sSerialNum;
		public float fSerialNum;
		public uint uiSerialNum;
		private List<double> PressureData;
		const int MAX_DATA_SIZE = 500;
		private const int PACKET_HEADER = 0x82;
		public TrafagPressureSensor(string inName, SerialPort inPort, string inUnit, string inAddr, double inMinPress, double inMaxPress)
		{
			this.mPort = inPort;
			this.sName = inName;
			this.sAddr = inAddr;
			unitID = (byte)Int16.Parse(inAddr);
			this.dMaxPress = inMaxPress;
			this.dMinPress = inMinPress;
			
			this.dMaxValue[0] = inMaxPress;
			this.dMinValue[0] = inMinPress;
			
			PressureData = new List<double>();
			sCmdList = new List<byte[]>();
		
			sCmdList.Add(cmd1);
			sCmdList.Add(cmd2);
			sCmdList.Add(cmd3);
			sCmdList.Add(cmd4);
			sCmdList.Add(cmd5);
			sCmdList.Add(cmd6);
			sCmdList.Add(cmd7);
			sCmdList.Add(cmd8);
			
			pResult = new ParaResult[iParaCount];
			
			if (inUnit.Contains("0"))
			{
				this.iUnit = PressUnits.psig;
			}
			else if (inUnit.Contains("1"))
			{
				this.iUnit = PressUnits.ksi;
			}
			else if (inUnit.Contains("2"))
			{
				this.iUnit = PressUnits.bar;
			}
			else
			{
				this.iUnit = PressUnits.psig;
			}
					
			//			tTimeout = new Timer();
			//			tTimeout.Interval = iSentTimeout;
			//			tTimeout.Tick += TIMEOUT_TICK;
			
		}


		
		//		private void TIMEOUT_TICK(Object myObject, EventArgs myEventArgs)
		//		{
		//			eDataStatus = DataStatus.Timeout;
		//			tTimeout.Enabled = false;
		//		}
		
		public DataStatus GetDataStatus()
		{
			return eDataStatus;
		}
		
		public void ResetDataStatus()
		{
			eDataStatus = DataStatus.NotAvailable;
		}

		public void ResetPara()
		{
			//dDiagResult = {0,0,0,0iParaIndex
			
			for(int i = 0; i < iParaCount; i++)
			{
				pResult[i].Reset();
			}
			
		}

		public int CountTotalWarnings()
		{
			int iTotalWarnings = 0;
			
			for (int i = 0; i < iParaCount; i++)
			{
				if (pResult[i].para_result == ParaStatus.Warning)
				{
					iTotalWarnings++;
				}
			}
			
			return iTotalWarnings++;
			
		}

		public int GetParaCount()
		{
			return iParaCount;
		}

		public void RequestPara_HEX(int paraIndex)
		{
			//			pResult[paraIndex].para_result = ParaStatus.NotAvailable;
			if (Globals.Tags.IsTouchScreen.Value.Bool)
			{
				//	mPort.Write(sAddr + "R" + sDataType[paraIndex] + "\r");
				
				SendPressCmd(sCmdList[paraIndex]);
				
			}
		}
		
		public void RequestPara_ASC(int paraIndex)
		{
			//			pResult[paraIndex].para_result = ParaStatus.NotAvailable;
			if (Globals.Tags.IsTouchScreen.Value.Bool)
			{
				mPort.Write(sAddr + "R" + sDataType[paraIndex] + "\r");
				
				//SendPressCmd(sCmdList[paraIndex]);
				
			}
		}
			
		private void SendPressCmd(byte[] cmd)
		{
			byte[] bPressCmd = new byte[13];
			int _checksum = 0;
			
			bPressCmd[0] = PACKET_HEADER;
			bPressCmd[1] = 0x00;
			bPressCmd[2] = 0x09;
			bPressCmd[3] = unitID;
			bPressCmd[4] = cmdRead;
			
			for(int i = 0; i < 3; i++)
			{
				bPressCmd[5 + i] = cmd[i];
			}
			
			for(int i = 0; i < 4; i++)
			{
				bPressCmd[8 + i] = 0x00;
			}
			
			for (int i = 3; i < 12; i++)
			{
				_checksum += bPressCmd[i];
			}
			
			_checksum = 0xff - _checksum & 0xff;
			
			bPressCmd[12] = (byte)_checksum;
			
			mPort.Write(bPressCmd,0,13);
			
		}	

		private void SendGenPressCmd(byte[] cmd)
		{
			byte[] bPressCmd = new byte[13];
			int _checksum = 0;
			
			bPressCmd[0] = PACKET_HEADER;
			bPressCmd[1] = 0x00;
			bPressCmd[2] = 0x09;
			bPressCmd[3] = unitID;
			
			for(int i = 0; i < 8; i++)
			{
				bPressCmd[4 + i] = cmd[i];
			}
			
			for (int i = 3; i < 12; i++)
			{
				_checksum += bPressCmd[i];
			}
			
			_checksum = 0xff - _checksum & 0xff;
			
			bPressCmd[12] = (byte)_checksum;
			
			mPort.Write(bPressCmd,0,13);
		}
		
		private void SendPressCmd(byte[] cmd, double dataIn)
		{
			byte[] bPressCmd = new byte[13];
			int _checksum = 0;
			
			bPressCmd[0] = PACKET_HEADER;
			bPressCmd[1] = 0x00;
			bPressCmd[2] = 0x09;
			bPressCmd[3] = unitID;
			bPressCmd[4] = cmdWrite;
			
			for(int i = 0; i < 3; i++)
			{
				bPressCmd[5 + i] = cmd[i];
			}
			
			float fData = (float)dataIn;
			byte[] bFData = BitConverter.GetBytes(fData);
			
			for(int i = 0; i < 4; i++)
			{
				bPressCmd[8 + i] = bFData[i];
			}
			
			for (int i = 3; i < 12; i++)
			{
				_checksum += bPressCmd[i];
			}
			
			_checksum = 0xff - _checksum & 0xff;
			
			bPressCmd[12] = (byte)_checksum;
			
			mPort.Write(bPressCmd,0,13);
			
		}	
		
		public double GetPress()
		{
			return dPressure - dPressZero;
		}
		
		public double GetDiff()
		{
			return System.Math.Abs(dPressure - dPrePressure);
		}
		
		public void SendToPort(PressRequestType requestType, PressDataType dataType)
		{
			eDataStatus = DataStatus.NotAvailable;
			//			tTimeout.Enabled = true;
			if (Globals.Tags.IsTouchScreen.Value.Bool)
			{
				mPort.Write(sAddr + sRequestType[(int)requestType] + sDataType[(int)dataType] + "\r");
				//SendPressCmd(sCmdList[(int)dataType]);
			}
		}

		public bool CheckZero()
		{
			if (dPressure < 0.005 * dMaxPress)
			{
				return true;
			}
			else
			{
				return false;
			}
		}		
		
		public bool CheckZeroPass()
		{
			if (dPressure < 0.005 * dMaxPress)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public void Zero_ASC()
		{
			if (Globals.Tags.IsTouchScreen.Value.Bool)
			{
				mPort.Write(sAddr + sZero + "\r");
			}
		}
		
		public void Zero_HEX()
		{
			if (Globals.Tags.IsTouchScreen.Value.Bool)
			{
				//			mPort.Write(sAddr + sZero + "\r");
				SendGenPressCmd(cmdZero);
			}
		}
		
		public void SaveAllSetting_HEX()
		{
			if (Globals.Tags.IsTouchScreen.Value.Bool)
			{
				//			mPort.Write(sAddr + sZero + "\r");
				SendGenPressCmd(cmdSave);
			}
		}
		
		public double GetPressSTD()
		{
			double exp_value = 0;
			if (PressureData.Count == 0)
			{
				return -1;
			}
			else
			{	
				double sum = 0;
				double exp_sum = 0;
				double avg = 0;
				
				for (int i = 0; i < PressureData.Count; i++)
				{
					sum += PressureData[i];
				}
				
				avg = sum / (double)PressureData.Count;
				
				for (int i = 0; i < PressureData.Count; i++)
				{
					exp_sum += Math.Pow(PressureData[i] - avg,2);
				}
				
				exp_value = Math.Sqrt(exp_sum / (double)PressureData.Count);
			}
			
			return exp_value;
		}

		public void ClearPressureData()
		{
			PressureData.Clear();
		}
		
		public void RequestChange_HEX(int iDataType, double dataIn)
		{
			if (Globals.Tags.IsTouchScreen.Value.Bool)
			{
				//	mPort.Write(sAddr + sRequestType[(int)PressRequestType.Set] + sDataType[iDataType] + "=" + DoubleToHex(dataIn) + "\r");
				SendPressCmd(sCmdList[iDataType],dataIn);
			}
		}

		public void RequestChange_ASC(int iDataType, double dataIn)
		{
			if (Globals.Tags.IsTouchScreen.Value.Bool)
			{
				mPort.Write(sAddr + sRequestType[(int)PressRequestType.Set] + sDataType[iDataType] + "=" + DoubleToHex(dataIn) + "\r");
			}
		}
		
		public void Receive(byte[] mPacket, int len)
		{
			if (mPacket[1] == 0x4F || mPacket[1] == 0x43)
			{
				for(int i = 0; i < sCmdList.Count; i++)
				{
					if (mPacket[2] == sCmdList[i][0] &&
						mPacket[3] == sCmdList[i][1] && 
						mPacket[4] == sCmdList[i][2])
					{
						eDataStatus = DataStatus.Available;
						
						byte[] pressSensorData = new byte[4];
						
						for(int j = 0; j < 4; j++)
						{
							pressSensorData[j] = mPacket[5 + j];
						}
						

						if (i == 7)
						{
							dResult[i] = BitConverter.ToUInt32(pressSensorData,0);
							uiSerialNum = BitConverter.ToUInt32(pressSensorData,0);
							fSerialNum = ((float)dResult[i]);
							sSerialNum = dResult[i].ToString();
							
						}
						else
						{
							dResult[i] = BitConverter.ToSingle(pressSensorData,0);
						}
					
						pResult[i].para_value = dResult[i];
					
						if (dResult[i] >= dMinValue[i] && dResult[i] <= dMaxValue[i])
						{
							pResult[i].para_result = ParaStatus.Pass;
						}
						else
						{
							pResult[i].para_result = ParaStatus.Warning;
						}
						
						switch(i)
						{
							case 0:
								dPrePressure = dPressure;
								dPressure = dResult[i];
								if (PressureData.Count > MAX_DATA_SIZE)
								{
									PressureData.Clear();
								}
								else
								{
									PressureData.Add(dResult[i]);
								}
								break;
							case 1:
								dTemp = dResult[i];
								break;
							case 2:
								dSpan = dResult[i];
								break;
							case 3:
								dOffset = dResult[i];
								break;
							
						}
						
					}
				}
			}
			else if (mPacket[1] == 0x60)
			{
				
			}
		}
		
		public void Receive(string strInput)
		{
			int equal_pos = strInput.IndexOf('=');
			
			int header_pos = strInput.LastIndexOf(sAddr, equal_pos);

			int str_length = equal_pos - header_pos;

			if (equal_pos != -1 && header_pos != -1 && str_length > 0)
			{
				string toComp = strInput.Substring(header_pos, str_length);
				
				for (int i = 0; i < sDataType.Length; i++)
				{
					if (toComp == sAddr + sRequestType[0] + sDataType[i])
					{
						eDataStatus = DataStatus.Available;
						//						tTimeout.Enabled = false;
					
						string d1 = strInput.Substring(equal_pos + 1,8);
						if (i == 7)
						{
							dResult[i] = Hex16ToDecimal10(d1, true);
							sSerialNum = dResult[i].ToString();
						}
						else
						{
							dResult[i] = HexToDouble(d1,true);
						}
					
						pResult[i].para_value = dResult[i];
					
						if (dResult[i] >= dMinValue[i] && dResult[i] <= dMaxValue[i])
						{
							pResult[i].para_result = ParaStatus.Pass;
						}
						else
						{
							pResult[i].para_result = ParaStatus.Warning;
						}
					
						switch(i)
						{
							case 0:
								dPrePressure = dPressure;
								dPressure = dResult[i];
								if (PressureData.Count > MAX_DATA_SIZE)
								{
									PressureData.Clear();
								}
								else
								{
									PressureData.Add(dResult[i]);
								}
								break;
							case 1:
								dTemp = dResult[i];
								break;
							case 2:
								dSpan = dResult[i];
								break;
							case 3:
								dOffset = dResult[i];
								break;
							
						}

						break;
					}
				}
				
			}

		
			
		}
		
		private double Hex16ToDecimal10(string strInput, bool isRev)
		{
			UInt32 out_value = 0;
			
			string strParse = "";
			
			if (isRev)
			{
				for (int i = 0; i < strInput.Length / 2; i++)
				{
					strParse = strParse + strInput.Substring((strInput.Length / 2 - 1 - i) * 2, 2);
				}
			}
			else
			{
				strParse = strInput;
			}
			
			try
			{
				out_value = UInt32.Parse(strParse, System.Globalization.NumberStyles.HexNumber);
			}
			catch
			{
				out_value = 0;
			}
			
			return (double)out_value;
		}

		private string DoubleToHex(double dInput)
		{
			// To do
			string strOut = "";
			
			float fInput = (float)dInput;
			
			byte[] byte_data = BitConverter.GetBytes(fInput);
			
			for (int i = 0; i < byte_data.Length; i++)
			{
				strOut = strOut + byte_data[i].ToString("X2");
			}
			
			return strOut;
		}

		private double HexToDouble(string strInput, bool isRev)
		{
			int NumberChars = strInput.Length;
			string[] conv = new String[4]; 
			double out_value;
			if (NumberChars != 8)
			{
				out_value = 0;
			}
			else
			{
				if (isRev)
				{
					for (int i = 0; i < 4; i++)
					{
						conv[i] = strInput.Substring(i * 2,2);
						
					}
				}
				else
				{
					for (int i = 0; i < 4; i++)
					{
						conv[i] = strInput.Substring(6 - i * 2,2);
					}
				}
				
				byte[] temp_bytes = new byte[4];
				for (int i = 0; i < 4; i ++)
				{
					temp_bytes[i] = Convert.ToByte(conv[i],16);
				}
				
				try
				{
					out_value = BitConverter.ToSingle(temp_bytes, 0);
				}
				catch
				{
					out_value = 0;
				}
				
			}
			
			return out_value;
		}
		
	}
	
	public enum ValveStatus{
		Unknown,
		Open,
		Close
	}
	
	public class SolenoidValveController : Controller
	{
		public ValveStatus currentStatus;
		private short iStatus;
		public double openVoltage;
		public double closeVoltage;
		private string sOpenCmd = "open";
		private string sCloseCmd = "close";
		private string[] sRequestData = {"measopen","measclose"};
		public const int iParaCount = 2;
		public ParaResult[] solenoidResult;
		private double[] dMaxValue = {30,30};
		private int iID = 0;
		private double[] dMinValue = {12,12};
		private const int PACKET_HEADER = 0x83;
		private const int BYTE_NUL = 0x00;
		public SolenoidValveController(string inName, SerialPort inPort, string inAddr)
		{
			this.mPort = inPort;
			this.sName = inName;
			this.sAddr = inAddr;
			//this.iID = Int32.Parse(inAddr);
			
			this.currentStatus = ValveStatus.Unknown;
			this.iStatus = 0;
			this.openVoltage = 0.0;
			this.closeVoltage = 0.0;
			
			solenoidResult = new ParaResult[2];
		}

		public double GetOpenVoltage()
		{
			return openVoltage;
		}		
		
		public double GetCloseVoltage()
		{
			return closeVoltage;
		}

		public short GetStatus()
		{
			return iStatus;
		}
		
		public void Open_ASC()
		{
			if (Globals.Tags.IsTouchScreen.Value.Bool)
			{
				mPort.Write(sOpenCmd + sAddr + "\r");
			}
		}
		
		public void Close_ASC()
		{
			if (Globals.Tags.IsTouchScreen.Value.Bool)
			{
				mPort.Write(sCloseCmd + sAddr + "\r");
			}
		}
		
		public void Open_HEX()
		{
			if (Globals.Tags.IsTouchScreen.Value.Bool)
			{
				byte[] bSoleCmd = new Byte[6];
				int _checkSum = 0;
				//			for (int i = 0; i < 4; i++)
				//			{
				//				bAtCmd[i] = 0xff;
				//			}
				bSoleCmd[0] = PACKET_HEADER;
				bSoleCmd[1] = BYTE_NUL;
				bSoleCmd[2] = 0x02;
				bSoleCmd[3] = (byte)iID;
				bSoleCmd[4] = 0x00;
			
				for (int i = 3; i < 5; i++)
				{
					_checkSum += bSoleCmd[i];
				}
			
				_checkSum = 0xff - _checkSum & 0xff;
				bSoleCmd[5] = (byte)_checkSum;
			
				mPort.Write(bSoleCmd,0,6);
				
				currentStatus = ValveStatus.Open;
			}
		}
		
		public void Close_HEX()
		{
			if (Globals.Tags.IsTouchScreen.Value.Bool)
			{
				byte[] bSoleCmd = new Byte[6];
				int _checkSum = 0;
				//			for (int i = 0; i < 4; i++)
				//			{
				//				bAtCmd[i] = 0xff;
				//			}
				bSoleCmd[0] = PACKET_HEADER;
				bSoleCmd[1] = BYTE_NUL;
				bSoleCmd[2] = 0x02;
				bSoleCmd[3] = (byte)iID;
				bSoleCmd[4] = 0x01;
			
				for (int i = 3; i < 5; i++)
				{
					_checkSum += bSoleCmd[i];
				}
			
				_checkSum = 0xff - _checkSum & 0xff;
				bSoleCmd[5] = (byte)_checkSum;
			
				mPort.Write(bSoleCmd,0,6);

				currentStatus = ValveStatus.Close;
			}
		}

		public int CountTotalWarnings()
		{
			int iTotalWarnings = 0;
			
			for (int i = 0; i < iParaCount; i++)
			{
				if (solenoidResult[i].para_result == ParaStatus.Warning)
				{
					iTotalWarnings++;
				}
			}
			
			return iTotalWarnings++;
			
		}

		public void ResetDiagResult()
		{
			
			for (int i = 0; i < iParaCount; i++)
			{
				solenoidResult[i].Reset();
			}
		}
		
		public int GetParaCount()
		{
			return iParaCount;
		}

		public void RequestPara(int index)
		{
			solenoidResult[index].Reset();
			if (Globals.Tags.IsTouchScreen.Value.Bool)
			{
				switch(index)
				{
					case 0:
						Open_ASC();
						break;
					case 1:
						Close_ASC();
						break;
				}
			}
		}
		
		public void MeasOpenVoltage()
		{
			if (Globals.Tags.IsTouchScreen.Value.Bool)
			{
				Open_ASC();
			}
		}
		
		public void MeasCloseVoltage()
		{
			if (Globals.Tags.IsTouchScreen.Value.Bool)
			{
				Close_ASC();
			}
		}
		
		private float GetVoltageFromBytes(byte[] mPacket, int len)
		{
			float result = 0;
			
			if (len > 5)
			{
				byte[] vol = new byte[4];

				for (int i = 0; i < 4; i++)
				{
					vol[i] = mPacket[i + 2];
				}
			
				result = BitConverter.ToSingle(vol,0);
			}
			
			return result;
			
		}

		public void Receive(byte[] mPacket, int len)
		{
			int dataType = 0;
			if (len > 0)
			{
				dataType = mPacket[1];
			}
			
			switch(dataType)
			{
				case 0x00:
					openVoltage = GetVoltageFromBytes(mPacket, len);
					iStatus = 1;
					currentStatus = ValveStatus.Open;
					if (openVoltage >= dMinValue[0] && openVoltage < dMaxValue[0])
					{
						solenoidResult[0].para_result = ParaStatus.Pass;
						
					}
					else
					{
						solenoidResult[0].para_result = ParaStatus.Warning;
					}
					solenoidResult[0].para_value = openVoltage;
					break;
				case 0x01:
					closeVoltage = GetVoltageFromBytes(mPacket, len);
					iStatus = 2;
					currentStatus = ValveStatus.Close;
					if (closeVoltage >= dMinValue[1] && closeVoltage < dMaxValue[1])
					{
						solenoidResult[1].para_result = ParaStatus.Pass;
					
					}
					else
					{
						solenoidResult[1].para_result = ParaStatus.Warning;
					}
					solenoidResult[1].para_value = closeVoltage;
					break;
			}		
			
			/*
			if (strInput.StartsWith("7E"))
			{
				int length = Convert.ToInt32(strInput.Substring(2, 4), 16);

				// Verify checksum
				string strData = strInput.Substring(6, length * 2);
				string checksm = strInput.Substring(6 + length * 2, 2);
				if (checksm == CalCheckSum(strData))
				{
					switch (strInput.Substring(6, 2))
					{
						case "88":  // AT command response
							ReceiveATcmd(strData,length);
							break;
						case "8A":  // modem status
							ReceiveModemStatus(strData);
							break;
						case "B0":  // Receive IPv4 Response 
							ReceivePacket(strData,length);
							break;
					}
				}



			}
			*/
		}

		
		public void Receive(string strInput)
		{

			if (strInput.Contains(sOpenCmd + sAddr + "="))
			{
				currentStatus = ValveStatus.Open;

				switch(sAddr)
				{
					case "A":
						Globals.Tags.LowSolenoidStatus.Value = 1;
						break;
					case "B":
						Globals.Tags.MidSolenoidStatus.Value = 1;
						break;
					case "C":
						Globals.Tags.HighSolenoidStatus.Value = 1;
						break;
				}

				iStatus =1;
				int equal_pos = strInput.IndexOf('=');
					
				string d1 = strInput.Substring(equal_pos + 1, strInput.Length - equal_pos - 1);
					
				double tmp;
					
				try
				{
					tmp = Double.Parse(d1);
				}
				catch
				{
					tmp = 0;
				}
				if (tmp >= dMinValue[0] && tmp < dMaxValue[0])
				{
					solenoidResult[0].para_result = ParaStatus.Pass;
					
				}
				else
				{
					solenoidResult[0].para_result = ParaStatus.Warning;
				}
				Globals.Tags.SystemBatteryVoltage.Value = tmp;
				solenoidResult[0].para_value = tmp;
				openVoltage = tmp; 
				Globals.Tags.globalVoltage.Value = tmp;
			}
			else if (strInput.Contains(sCloseCmd + sAddr + "="))
			{
				currentStatus = ValveStatus.Close;
				
				switch(sAddr)
				{
					case "A":
						Globals.Tags.LowSolenoidStatus.Value = 0;
						break;
					case "B":
						Globals.Tags.MidSolenoidStatus.Value = 0;
						break;
					case "C":
						Globals.Tags.HighSolenoidStatus.Value = 0;
						break;
				}
				
				iStatus = 2;
				int equal_pos = strInput.IndexOf('=');
					
				string d1 = strInput.Substring(equal_pos + 1, strInput.Length - equal_pos - 1);

				double tmp;
					
				try
				{
					tmp = Double.Parse(d1);
				}
				catch
				{
					tmp = 0;
				}
				if (tmp >= dMinValue[1] && tmp < dMaxValue[1])
				{
					solenoidResult[1].para_result = ParaStatus.Pass;
				}
				else
				{
					solenoidResult[1].para_result = ParaStatus.Warning;
				}
				Globals.Tags.SystemBatteryVoltage.Value = tmp;
				solenoidResult[1].para_value = tmp;
				closeVoltage = tmp; 
				Globals.Tags.globalVoltage.Value = tmp;
			}
				
				
		}
		
		
		
	}
	
	
	public class ATcmd
	{
		public string mName {get;set;}
		public byte[] mRawData;
		public int mRawDataLen;
		private const int MAX_DATA_SIZE = 256;
		public double dValue {get; set;}
		public byte bStatus;
		public DataStatus dataStatus; 
		public ATcmd(string inName)
		{
			this.mName = inName;
			mRawData = new byte[MAX_DATA_SIZE];
			mRawDataLen = 0;
			dataStatus = DataStatus.NotAvailable;
		}
	}

	public class SSIDInfo
	{
		public string mSSID { get; set; }
		public string mSecurity { get; set; }
		public int mSignalStrengh { get; set; }
		public byte mbSecurity {get; set;}
		public int mTrueSignalStrengh { get; set; }
		public int mChannel {get; set; }
		
		public SSIDInfo(byte[] rawData, int len)
		{
			mSSID = System.Text.Encoding.ASCII.GetString(rawData, 4, len - 4);
			mbSecurity = rawData[2];
			mChannel = (int)rawData[1];
			switch(rawData[2])
			{
				case 0x00:
					mSecurity = "Open";
					break;
				case 0x01:
					mSecurity =  "WPA";
					break;
				case 0x02:
					mSecurity = "WPA2";
					break;
				case 0x03:
					mSecurity =  "WEP";
					break;
				default:
					mSecurity = "Unknown";
					break;
			}

			mSignalStrengh = (int)rawData[3];
			mSignalStrengh *= 2;
			mTrueSignalStrengh = mSignalStrengh;
			
			if (mSignalStrengh >= 0 && mSignalStrengh < 25)
			{
				mSignalStrengh = 0;
			}
			else if (mSignalStrengh >= 25 && mSignalStrengh < 50)
			{
				mSignalStrengh = 1;
			}
			else if (mSignalStrengh >= 50 && mSignalStrengh < 75)
			{
				mSignalStrengh = 2;
			}
			else if (mSignalStrengh >= 75 && mSignalStrengh < 200)
			{
				mSignalStrengh = 3;
			}
			else
			{
				mSignalStrengh = 0;
			}
		}
	}
	
	public class ModemStatus
	{
		public byte currentStatus;
		private byte[] statuslist = { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x0b, 0x0c, 0x0d, 0x11, 0x80, 0x82, 0x83, 0x84, 0x87, 0x88, 0x8a, 0x8e };
		private string[] description = {"Hardware reset",                                   
			"Watchdog timer reset",
			"Joined network (routers and end devices)",
			"Disassociated",
			"Configuration error/synchronization",
			"Coordinator realignment",
			"Coordinator started",
			"Network security key updated",
			"Network woke up",
			"Network went to sleep",
			"Voltage supply limit exceeded(PRO S2B only)",
			"Modem configuration changed while join in progress",
			"Stack error(80+)",
			"Send/join command issued without connecting from AP",
			"Access point not found",
			"PSK not configured",
			"SSID not found",
			"Fail to join with security enabled",
			"Invalid Channel",
			"Fail to join access point"};

		public string GetDescription()
		{
			for (int i = 0; i < statuslist.Length; i++)
			{
				if (currentStatus == statuslist[i])
				{
					return description[i];
				}
			}

			return "";
		}
		public ModemStatus()
		{

		}
           
	}
	
	public class XBeeModule
	{

		private byte[] mTargetIPAddr;
		private byte[] mDesPort;
		private byte[] mSrcPort;
		private byte mProtocol;
		public string sName {get ; set; }
		protected SerialPort mSerial;
		public List<ATcmd> atCmdSets;		
		private string[] strATcmd = {"ID","AH","IP","CE","MA","TM","SH","SL","DL","DE","C0","MY","MK","GW","EE","PK","AI","LM","%V","TP","WH","SO","SM","SP","ST","AS","PL","CH","BR", "NR", "AC", "WR", "FR"};
		private int[] accessLevel = {  0 ,  0 ,  0 ,  0 ,  0 ,  0 ,  1 ,  1 ,  0 ,  0 ,  0 ,  0 ,  0 ,  0 ,  0 ,  2 ,  1 ,  1 ,  1 ,  1 ,  0 ,  0 ,  0 ,  0 ,  0 ,  1 ,  0 ,  1 ,  0 ,   0 ,   0 ,   0 ,  0};
		// 0 = read and write, 1 read only, 2 write only
		private const int AT_CMD_TX = 0x08;
		private const int IPV4_TX = 0x20;
		private const int IPV4_RX = 0xb0;
		private const int MODEM_STATUS = 0x8a;
		private const int AT_CMD_RX = 0x88;
		private const int REMOTE_AT_CMD_TX = 0x07;
		private const int REMOTE_AT_CMD_RX = 0x87;
		private const int PACKET_HEADER = 0x81;
		private const int BYTE_NUL = 0x00;
		public ModemStatus modemStatus;
		public List<SSIDInfo> ssidInfo;
		private Timer tmrExtraPull;
		//		private int iTimeoutCount;

		public XBeeModule(string inName, SerialPort inSerial)
		{
			mSerial = inSerial;
			this.sName = inName;
			atCmdSets = new List<ATcmd>();
			for( int i = 0; i < strATcmd.Length; i++)
			{
				atCmdSets.Add(new ATcmd(strATcmd[i]));
			}

			modemStatus = new ModemStatus();
			ssidInfo = new List<SSIDInfo>();
			mTargetIPAddr = new byte[4];
			mDesPort = new byte[2];
			mSrcPort = new byte[2];
			tmrExtraPull = new Timer();
			tmrExtraPull.Interval = 500;
			tmrExtraPull.Tick += new EventHandler(tmrExtraPull_TICK);
			tmrExtraPull.Enabled = false;

		}

		private void tmrExtraPull_TICK(Object myObject, EventArgs myEventArgs) 
		{

		}
		
		public ATcmd GetATcmd(string strCmd)
		{
			return atCmdSets.Find(x => x.mName == strCmd);
				
		}
		
		public void SendReadCmd(string cmdID)
		{
			byte[] bAtCmd = new Byte[12];
			int _checkSum = 0;
			//			for (int i = 0; i < 4; i++)
			//			{
			//				bAtCmd[i] = 0xff;
			//			}
			bAtCmd[0] = PACKET_HEADER;
			bAtCmd[1] = BYTE_NUL;
			bAtCmd[2] = 0x04;
			bAtCmd[3] = AT_CMD_TX;
			bAtCmd[4] = 0x01;
			bAtCmd[5] = (byte)cmdID[0];
			bAtCmd[6] = (byte)cmdID[1];
			
			for (int i = 3; i < 7; i++)
			{
				_checkSum += bAtCmd[i];
			}
			
			_checkSum = 0xff - _checkSum & 0xff;
			bAtCmd[7] = (byte)_checkSum;
			
			mSerial.Write(bAtCmd,0,8);
		}
		
		public void SendReadCmd(int cmdIndex)
		{
			string cmdID = strATcmd[cmdIndex];
			SendReadCmd(cmdID);
		}
		public string GetAIStatus(byte AIReading)
		{
			switch(AIReading)
			{
				case 0x00:
					return "Connected to AP";
				case 0x01:
					return "Initialization in progress";
				case 0x02:
					return "Wait to scan";
				case 0x13:
					return "Not setup up";
				case 0x23:
					return "SSID not configured";
				case 0x24:
					return "Invalid password";
				case 0x27:
				case 0x40:
					return "Wrong password";
				case 0x41:
					return "Waiting for DHCP";
				case 0x42:
					return "Setting up ports";
				case 0xff:
					return "Scanning in progress";
				default:
					int errorcode = (int)AIReading;
					return "Unknown Status: Code " + errorcode.ToString();
			}
		}
		public void SendWriteCmd(string cmdID, byte[] inputHexValue, int inputLen)
		{
			int total_length = inputLen + 8;
			int data_length = inputLen + 4;
			byte[] bAtCmd = new Byte[total_length];
			byte[] bLen = new Byte[2];

			intToBytes(data_length, bLen);

			int _checkSum = 0;


			bAtCmd[0] = PACKET_HEADER;
			bAtCmd[1] = bLen[0];
			bAtCmd[2] = bLen[1];
			bAtCmd[3] = AT_CMD_TX;
			bAtCmd[4] = 0x01;
			bAtCmd[5] = (byte)cmdID[0];
			bAtCmd[6] = (byte)cmdID[1];

			for (int i = 7; i < total_length - 1; i++)
			{
				bAtCmd[i] = inputHexValue[i - 7];
			}

			for (int i = 3; i < total_length - 1; i++)
			{
				_checkSum += bAtCmd[i];
			}

			_checkSum = 0xff - _checkSum & 0xff;
			bAtCmd[total_length - 1] = (byte)_checkSum;
			
			mSerial.Write(bAtCmd,0,total_length);
			
		}
		
		public void SendWriteCmd(int cmdIndex, byte[] inputHexValue, int inputLen)
		{
			string cmdID = strATcmd[cmdIndex];
			SendWriteCmd(cmdID,inputHexValue,inputLen);
		}

		//		public bool WaitForWriteAtCmd(string atCmd, byte[] inputHexValue, int inputLen)      //must use in thread to prevent frozen
		//		{
		//			int retry_count = 0;
		//			const int RETRY_TIMES = 2;
		//			int MAX_RETRY_TIME = 100;
		//			int time_retry_count;
		//			
		//			while (retry_count < RETRY_TIMES)
		//			{
		//				retry_count++;
		//				SendWriteCmd(atCmd, inputHexValue, inputLen);
		//				GetATcmd(atCmd).dataStatus = DataStatus.NotAvailable;
		//				time_retry_count = 0;
		//				while(GetATcmd(atCmd).dataStatus == DataStatus.NotAvailable)
		//				{
		//					//waiting for response
		//					time_retry_count++;
		//					Thread.Sleep(1);
		//					if (time_retry_count>MAX_RETRY_TIME)
		//					{
		//						break;
		//					}
		//				}
		//				
		//				if (GetATcmd(atCmd).dataStatus == DataStatus.Available)
		//				{
		//					break;
		//				}	
		//				
		//			}
		//			
		//			if (GetATcmd(atCmd).dataStatus == DataStatus.NotAvailable)
		//			{
		//				return false;
		//			}
		//			else
		//			{
		//				return true;
		//			}
		//		}
		
		
		//		public bool WaitForAtCmd(string atCmd)      //must use in thread to prevent frozen
		//		{
		//			int retry_count = 0;
		//			const int RETRY_TIMES = 5;
		//			int MAX_RETRY_TIME = 100;
		//			int time_retry_count;
		//			
		//			if (atCmd == "AS")
		//			{
		//				MAX_RETRY_TIME = 500;
		//			}
		//			
		//			while (retry_count < RETRY_TIMES)
		//			{
		//				retry_count++;
		//				SendReadCmd(atCmd);
		//				GetATcmd(atCmd).dataStatus = DataStatus.NotAvailable;
		//				time_retry_count = 0;
		//				while(GetATcmd(atCmd).dataStatus == DataStatus.NotAvailable)
		//				{
		//					//waiting for response
		//					time_retry_count++;
		//					Thread.Sleep(1);
		//					if (time_retry_count>MAX_RETRY_TIME)
		//					{
		//						break;
		//					}
		//				}
		//				
		//				if (GetATcmd(atCmd).dataStatus == DataStatus.Available)
		//				{
		//					break;
		//				}	
		//				
		//			}
		//			
		//			if (GetATcmd(atCmd).dataStatus == DataStatus.NotAvailable)
		//			{
		//				return false;
		//			}
		//			else
		//			{
		//				return true;
		//			}
		//		}

		public void SendPacket(byte[] bIPaddr, byte[] bDesPort, byte[] bSrcPort, byte bPro, byte bFrameID, byte[] bPacket, int pLen)
		{
			int data_length = pLen + 12;
			int packet_length = data_length + 4;
			byte[] bData = new Byte[packet_length];
			byte[] bLen = new Byte[2];

			intToBytes(data_length, bLen);

			int _checkSum = 0;

			bData[0] = PACKET_HEADER;
			bData[1] = bLen[0];
			bData[2] = bLen[1];
			bData[3] = IPV4_TX;
			bData[4] = bFrameID;

			for (int i = 5; i < 9; i++)
			{
				bData[i] = bIPaddr[i - 5];
			}


			for (int i = 9; i < 11; i++)
			{
				bData[i] = bDesPort[i - 9];
			}


			for (int i = 11; i < 13; i++)
			{
				bData[i] = bSrcPort[i - 11];
			}

			bData[13] = bPro;
			bData[14] = 0x00;
			
			for (int i = 15; i < packet_length - 1; i++)
			{
				bData[i] = bPacket[i - 15];
			}

			for (int i = 3; i < packet_length - 1; i++)
			{
				_checkSum += bData[i];
			}

			_checkSum = 0xff - _checkSum & 0xff;
			bData[packet_length - 1] = (byte)_checkSum;
			
			mSerial.Write(bData,0,packet_length);
			
		}
		
		private void intToBytes(int val, byte[] b)
		{
			b[0] = (byte)((val >> 8) & 0xff);
			b[1] = (byte)(val & 0xff);
		}

		public void Receive(byte[] mPacket, int len)
		{
			int dataType = 0;
			if (len > 0)
			{
				dataType = mPacket[0];
			}
			
			switch(dataType)
			{
				case AT_CMD_RX:
					ReceiveATcmd(mPacket,len);
					
					break;
				case IPV4_RX:
					ReceivePacket(mPacket, len);
					//				Globals.Tags.debugstring1.Value = DateTime.Now.ToString("hh:mm:ss") + " IP received";
					break;
				case MODEM_STATUS:
					modemStatus.currentStatus = (byte)mPacket[1];
					break;
			}		
			
			/*
			if (strInput.StartsWith("7E"))
			{
				int length = Convert.ToInt32(strInput.Substring(2, 4), 16);

				// Verify checksum
				string strData = strInput.Substring(6, length * 2);
				string checksm = strInput.Substring(6 + length * 2, 2);
				if (checksm == CalCheckSum(strData))
				{
					switch (strInput.Substring(6, 2))
					{
						case "88":  // AT command response
							ReceiveATcmd(strData,length);
							break;
						case "8A":  // modem status
							ReceiveModemStatus(strData);
							break;
						case "B0":  // Receive IPv4 Response 
							ReceivePacket(strData,length);
							break;
					}
				}



			}
			*/
		}
		
		public void ReceiveATcmd(byte[] mData, int len)
		{

			bool bExist = false;
			
			char atCmd1 = (char)mData[2];
			
			char atCmd2 = (char)mData[3];
			
			string atCmd = string.Concat(atCmd1,atCmd2);
			
			//		Globals.Tags.debugstring1.Value = DateTime.Now.ToString("hh:mm:ss") + " " + atCmd + " received";
			
			ATcmd getAtCmd = atCmdSets.Find(x => x.mName == atCmd);
			
			getAtCmd.bStatus = mData[4];

			Array.Clear(getAtCmd.mRawData, 0, getAtCmd.mRawData.Length);

			for (int i = 5; i < len; i++)
			{
				getAtCmd.mRawData[i - 5] = mData[i];
			}
			
			getAtCmd.mRawDataLen = len - 5;
			getAtCmd.dataStatus = DataStatus.Available;
			
			if (atCmd == "AS" && len > 5)
			{
				SSIDInfo tmpSSID = new SSIDInfo(getAtCmd.mRawData, len - 5);
				
				for(int i = 0; i < ssidInfo.Count;i++)
				{
					if (tmpSSID.mSSID == ssidInfo[i].mSSID &&
						tmpSSID.mChannel == ssidInfo[i].mChannel)
					{
						bExist = true;
					}
				}
				if (bExist == false)
				{
					ssidInfo.Add(tmpSSID);
				}
			}
		}
		
		public void SendForceCloseConnection()
		{
			byte[] sendData = new byte[2];
			
			sendData[0] = 0x07;
			sendData[1] = 0x02;
			
			Globals.Tags.RemoteDesktopIcon.Value = 0;
			Globals.Tags.wifiStreaming.Value = 0;
			
			SendRawBytePacket(sendData);
		}
		
		public void SendMainScreenData()
		{
			Globals.CalAndUpdate.UpdateFlowRateTag();

			byte[] pData = new byte[1];
			
			pData[0] = 0x04;

			byte[] mainData = new byte[27];
					
			if (Globals.Tags.selMode.Value == 0)
			{
				if (Globals.Tags.selMeter.Value == 0)
				{
					mainData[0] = 0x00;
				}
				else if (Globals.Tags.selMeter.Value == 1)
				{
					mainData[0] = 0x01;
				}
				else if (Globals.Tags.selMeter.Value == 2)
				{
					mainData[0] = 0x02;
				}
						
			}
			else if (Globals.Tags.selMode.Value == 1)
			{
				mainData[0] = 0x03;
			}
			else if (Globals.Tags.selMode.Value == 2)
			{
				mainData[0] = 0x04;
			}
			else if (Globals.Tags.selMode.Value == 3)
			{
				mainData[0] = 0x05;
			}
					
			mainData[1] = (byte)Globals.Tags.gasType.Value.Int;
					
			if (Globals.Tags.selMeter.Value == 0)
			{
				mainData[2] = (byte)Globals.Tags.flow_unit_low.Value.Int;
			}
			else if (Globals.Tags.selMeter.Value == 1)
			{
				mainData[2] = (byte)Globals.Tags.flow_unit_mid.Value.Int;
			}
			else if (Globals.Tags.selMeter.Value == 2)
			{
				mainData[2] = (byte)Globals.Tags.flow_unit_high.Value.Int;
			}
					
		
			mainData[3] = (byte)Globals.Tags.MainFlowRateDecimal.Value.Int;
				
			mainData[4] = (byte)Globals.Tags.iLinearMeterColor.Value.Int;
				
			mainData[5] = (byte)Globals.Tags.PressUnit.Value.Int;

			mainData[6] = (byte)Globals.Tags.MainPressDecimal.Value.Int;
					
			byte[] bFlowRate = BitConverter.GetBytes((float)Globals.Tags.MainFlowRateDisplay.Value.Double);
				
			byte[] bRangeMin = BitConverter.GetBytes((float)Globals.Tags.MainRangeMinDisplay.Value);
					
			byte[] bRangeMax = BitConverter.GetBytes((float)Globals.Tags.MainRangeMaxDisplay.Value);

			Globals.Tags.RawTestPressure.Value = Globals.Comm.PressSensors[1].GetPress();
					
			Globals.Tags.MainTestPressDisplay.Value  = Globals.UnitsAndConversion.PressConv(Globals.Tags.RawTestPressure.Value.Double,(int)Globals.Tags.press_meter_unit.Value,(int)Globals.Tags.PressUnit.Value);

			Globals.Tags.RawInletPressure.Value = Globals.Comm.PressSensors[0].GetPress();
			
			Globals.Tags.MainInletPressDisplay.Value  = Globals.UnitsAndConversion.PressConv(Globals.Tags.RawInletPressure.Value.Double,(int)Globals.Tags.press_meter_unit.Value,(int)Globals.Tags.PressUnit.Value);

			byte[] bInletPress = BitConverter.GetBytes((float)Globals.Tags.MainInletPressDisplay.Value.Double);
			byte[] bTestPress = BitConverter.GetBytes((float)Globals.Tags.MainTestPressDisplay.Value.Double);
					
			for (int i = 0; i < 4; i++)
			{
				mainData[i + 7] = bRangeMin[i];
				mainData[i + 11] = bRangeMax[i];
				mainData[i + 15] = bFlowRate[i];
				mainData[i + 19] = bInletPress[i];
				mainData[i + 23] = bTestPress[i];
			}
			SendBytePacket(mainData,1,pData);
		}
		
		public void ReceivePacket(byte[] mData, int len)
		{
			int selUnit;
			for (int i = 0; i < 4; i++)
			{
				mTargetIPAddr[i] = mData[i + 1];
			}
			
			for (int i = 0; i < 2; i++)
			{
				mDesPort[i] = mData[i + 5];
			}
			
			for (int i = 0; i < 2; i++)
			{
				mSrcPort[i] = mData[i + 7];
			}
			
			mProtocol = mData[9];
			
			byte[] pData = new byte[len - 11];
			byte singeByte = 0x00;
			int dataLen = len - 11;
			
			for (int i = 0; i < len - 11; i++)
			{
				pData[i] = mData[i + 11];
			}
			
			if (mProtocol == 0x01)
			{
				Globals.Tags.RemoteDesktopIcon.Value = 1;
				Globals.Tags.gTimerCount.Value = 0;
			}
			// Check Wifi Interface Doc for Explanations
			switch (pData[0])
			{
				case 0x01:   // LRM Info
					switch (pData[1])
					{
						case 0x00:  // LRM serial
							pData[1] = 0x01;	// prevent echo
							SendFormatPacket(Globals.Tags.serial.Value.String, 2, pData);
							break;
						case 0x02:  // LRM firmware
							SendFormatPacket(Globals.Tags.firmware.Value.String, 2, pData);
							break;
						case 0x03:  // LRM number of flow meters
							SendFormatPacket((byte)Globals.Comm.FlowMeters.Count, 2, pData);
							break;
						case 0x04:  // number of pressure sensors
							SendFormatPacket((byte)Globals.Comm.PressSensors.Count, 2, pData);
							break;
						case 0x05:  // number of solenoid valves 
							SendFormatPacket((byte)Globals.Comm.SolenoidValves.Count, 2, pData);
							break;
					}
					
					
					//					if (pData.Length == 12)
					//					{	
					//						if (pData[1] == 0x00 &&
					//							pData[2] == 0x47 &&
					//							pData[3] == 0x72 &&
					//							pData[4] == 0x61 &&
					//							pData[5] == 0x66 &&
					//							pData[6] == 0x74 &&
					//							pData[7] == 0x65 &&
					//							pData[8] == 0x6c &&
					//							pData[9] == 0x4c &&
					//							pData[10] == 0x52 &&
					//							pData[11] == 0x4d)
					//						{
					//							pData[1] = 0x01;
					//							SendFormatPacket(Globals.Tags.serial.Value.String, 2, pData);
					//						}
					//						
					//					}
					break;
				case 0x02:   // Read/Change screen
					switch (pData[1])
					{
						case 0x00:
							byte screenID;
							screenID = (byte)Globals.Tags.CurrentScreen.Value.Int;
							SendBytePacket(screenID,2,pData);
							break;
						case 0x01:
							if (pData.Length == 3)
							{
								switch(pData[2])
								{
									case 0x01:
										Globals.BuzzerConfig.Show();
										break;
									case 0x02:
										Globals.CalAdjust.Show();
										break;
									case 0x03:
										Globals.CalDueDateSetting.Show();
										break;
									case 0x04:
										Globals.CalInstruction.Show();
										break;
									case 0x05:
										Globals.CalSelectMeter.Show();
										break;
									case 0x06:
										Globals.CalSetCalDate.Show();
										break;
									case 0x07:
										Globals.DiagPreCheck.Show();
										break;
									case 0x08:
										Globals.DiagReportFlow.Show();
										break;
									case 0x09:
										Globals.DiagReportPress.Show();
										break;
									case 0x10:
										Globals.DiagReportSolenoid.Show();
										break;
									case 0x11:
										Globals.DiagScreen1.Show();
										break;
									case 0x12:
										Globals.DiagScreen.Show();
										break;
									case 0x13:
										Globals.DisplayBacklight.Show();
										break;
									case 0x14:
										Globals.DisplayDecimals.Show();
										break;
									case 0x15:
										Globals.DisplaySystemDate.Show();
										break;
									case 0x16:
										Globals.DisplaySystemTime.Show();
										break;
									case 0x17:
										Globals.FilterHigh.Show();
										break;
									case 0x18:
										Globals.FilterLow.Show();
										break;
									case 0x19:
										Globals.FilterMid.Show();
										break;
									case 0x20:
										Globals.FlowRateDisplay.Show();
										break;
									case 0x21:
										Globals.ImportData.Show();
										break;
									case 0x22:
										Globals.KeyBoardScreen.Show();
										break;
									case 0x23:
										Globals.MainScreen.Show();
										break;
									case 0x24:
										Globals.popPasscode.Show();
										break;
									case 0x25:
										Globals.QucikFillScreen0.Show();
										break;
									case 0x26:
										Globals.QuickFillScreen1.Show();
										break;
									case 0x27:
										Globals.QuickFillScreen2.Show();
										break;
									case 0x28:
										Globals.QuickFillScreen3.Show();
										break;
									case 0x29:
										Globals.QuickFillSetting.Show();
										break;
									case 0x30:
										Globals.RcrdDate.Show();
										break;
									case 0x31:
										Globals.RcrdFileName.Show();
										break;
									case 0x32:
										Globals.RcrdInterval.Show();
										break;
									case 0x33:
										Globals.RcrdTime.Show();
										break;
									case 0x34:
										Globals.SelectData.Show();
										break;
									case 0x35:
										Globals.SelectFileName.Show();
										break;
									case 0x36:
										Globals.SettingScreen.Show();
										break;
									case 0x37:
										Globals.SettingScreenMore.Show();
										break;
									case 0x38:
										Globals.ShowFile.Show();
										break;
									case 0x39:
										Globals.StabLow.Show();
										break;
									case 0x40:
										Globals.StabMid.Show();
										break;
									case 0x41:
										Globals.StartScreen.Show();
										break;
									case 0x42:
										Globals.WifiAdvanceSetup.Show();
										break;
									case 0x43:
										Globals.WifiConnectToAP.Show();
										break;
									case 0x44:
										Globals.WifiEnterPassword.Show();
										break;
									case 0x45:
										Globals.WifiManualSetup.Show();
										break;
									case 0x46:
										Globals.WifiQuickSetup.Show();
										break;
									case 0x47:
										Globals.wifiSearchSSID.Show();
										break;
									case 0x48:
										Globals.WifiSetting.Show();
										break;
									case 0x49:
										Globals.WifiSetupSoftAP.Show();
										break;
									case 0x50:
										Globals.WifiSoftAPSetup.Show();
										break;
								}
							}
							break;
					}
					break;
				case 0x03:   // LRM parameters
					if (pData.Length == 3)   // Read Request
					{
						if (pData[1] == 0x00)
						{
						
							switch (pData[2])
							{
								case 0x00:    // Cal Due Date 
									byte[] CalDueDateData = new byte[4];
									byte[] yearData;
									int yearTmp = Globals.Tags.calDueDatePers.Value.DateTime.Year;
									int monthTmp = Globals.Tags.calDueDatePers.Value.DateTime.Month;
									int dayTmp = Globals.Tags.calDueDatePers.Value.DateTime.Day;
									
									yearData = BitConverter.GetBytes((short)yearTmp);
									
									CalDueDateData[0] = (byte)dayTmp; // day
									CalDueDateData[1] = (byte)monthTmp; // month
									CalDueDateData[2] = yearData[0]; // year byte 1
									CalDueDateData[3] = yearData[1]; // year byte 2
									
									SendBytePacket(CalDueDateData,3,pData);
									
									break;
								case 0x01:    // mode
									if (Globals.Tags.selMode.Value == 0)
									{
										if (Globals.Tags.selMeter.Value == 0)
										{
											singeByte = 0x00;
										}
										else if (Globals.Tags.selMeter.Value == 1)
										{
											singeByte = 0x02;
										}
						
									}
									else if (Globals.Tags.selMode.Value == 1)
									{
										singeByte = 0x03;
									}
									else if (Globals.Tags.selMode.Value == 2)
									{
										singeByte = 0x05;
									}
									SendBytePacket(singeByte,3,pData);
									break;
								case 0x02:	 // Air type
									singeByte = (byte)Globals.Tags.gasType.Value.Int;
									SendBytePacket(singeByte,3,pData);
									break;
								case 0x03:
									byte[] bFlowRateUnits = new byte[3];
									bFlowRateUnits[0] = (byte)Globals.Tags.flow_unit_low.Value.Int;
									bFlowRateUnits[1] = 0xFF;
									bFlowRateUnits[2] = (byte)Globals.Tags.flow_unit_mid.Value.Int;
									SendBytePacket(bFlowRateUnits,3,pData);
									break;
								case 0x04:   // Pressure unit
									singeByte = (byte)Globals.Tags.PressUnit.Value.Int;
									SendBytePacket(singeByte,3,pData);
									break;
								case 0x05:   // Flow Units Decimals
									byte[] bFlowUnitDecimals = new byte[12];
									bFlowUnitDecimals[0] = (byte)Globals.Tags.LowsccmDecimal.Value.Int; 
									bFlowUnitDecimals[1] = (byte)Globals.Tags.LowslpmDecimal.Value.Int; 
									bFlowUnitDecimals[2] = (byte)Globals.Tags.LowscfmDecimal.Value.Int; 
									bFlowUnitDecimals[3] = (byte)Globals.Tags.LowscfhDecimal.Value.Int; 
									bFlowUnitDecimals[4] = 0xFF;
									bFlowUnitDecimals[5] = 0xFF;
									bFlowUnitDecimals[6] = 0xFF;
									bFlowUnitDecimals[7] = 0xFF;
									bFlowUnitDecimals[8] = (byte)Globals.Tags.MidsccmDecimal.Value.Int; 
									bFlowUnitDecimals[9] = (byte)Globals.Tags.MidslpmDecimal.Value.Int; 
									bFlowUnitDecimals[10] = (byte)Globals.Tags.MidscfmDecimal.Value.Int; 
									bFlowUnitDecimals[11] = (byte)Globals.Tags.MidscfhDecimal.Value.Int;
									
									SendBytePacket(bFlowUnitDecimals,3,pData);
									break;
								case 0x06:   // Pressure decimal
									byte[] bPressUnitDecimals = new byte[3];
									bPressUnitDecimals[0] = (byte)Globals.Tags.psigDecimal.Value.Int;
									bPressUnitDecimals[1] = (byte)Globals.Tags.ksiDecimal.Value.Int;
									bPressUnitDecimals[2] = (byte)Globals.Tags.barDecimal.Value.Int;
									
									SendBytePacket(bPressUnitDecimals,3,pData);
									break;
								case 0x07:  // Filter Setting
									byte[] bFilterSetting = new byte[6];
									bFilterSetting[0] = (byte)Globals.Tags.FilterResponseLow.Value.Int;
									bFilterSetting[1] = (byte)Globals.Tags.FilterUpperLimitLow.Value.Int;
									bFilterSetting[2] = (byte)Globals.Tags.FilterResponseMid.Value.Int;
									bFilterSetting[3] = (byte)Globals.Tags.FilterUpperLimitMid.Value.Int;
									bFilterSetting[4] = (byte)Globals.Tags.FilterResponseHigh.Value.Int;
									bFilterSetting[5] = (byte)Globals.Tags.FilterUpperLimitHigh.Value.Int;
									
									SendBytePacket(bFilterSetting,3,pData);
									break;
								case 0x08: // Stability Setting
									byte[] bStabilitySetting = new byte[36];
									
									byte[] bLowStabGreen 	= BitConverter.GetBytes((float)Globals.Tags.Stab_low_green.Value.Double);
									byte[] bLowStabOrange 	= BitConverter.GetBytes((float)Globals.Tags.Stab_low_orange.Value.Double);
									byte[] bLowStabRed 		= BitConverter.GetBytes((float)Globals.Tags.Stab_low_red.Value.Double);
									byte[] bMidStabGreen 	= BitConverter.GetBytes((float)Globals.Tags.Stab_mid_green.Value.Double);
									byte[] bMidStabOrange 	= BitConverter.GetBytes((float)Globals.Tags.Stab_mid_orange.Value.Double);
									byte[] bMidStabRed 		= BitConverter.GetBytes((float)Globals.Tags.Stab_mid_red.Value.Double);
									byte[] bHiStabGreen 	= BitConverter.GetBytes((float)Globals.Tags.Stab_high_green.Value.Double);
									byte[] bHiStabOrange 	= BitConverter.GetBytes((float)Globals.Tags.Stab_high_orange.Value.Double);
									byte[] bHiStabRed 		= BitConverter.GetBytes((float)Globals.Tags.Stab_high_red.Value.Double);

							
									for (int i = 0; i < 4; i++)
									{
										bStabilitySetting[i] 		= bLowStabGreen[i];
										bStabilitySetting[i + 4] 	= bLowStabOrange[i];
										bStabilitySetting[i + 8] 	= bLowStabRed[i];
										bStabilitySetting[i + 12] 	= bMidStabGreen[i];
										bStabilitySetting[i + 16] 	= bMidStabOrange[i];
										bStabilitySetting[i + 20] 	= bMidStabRed[i];
										bStabilitySetting[i + 24] 	= bHiStabGreen[i];
										bStabilitySetting[i + 28] 	= bHiStabOrange[i];
										bStabilitySetting[i + 32] 	= bHiStabRed[i];
									}
									
									SendBytePacket(bStabilitySetting,3,pData);
									
									break;						
								
								
								
							}
						
						} 
							
					}
					else if (pData.Length == 4)  // Write Single Byte
					{
						if (pData[1] == 0x01) 
						{
							switch (pData[2])
							{
								case 0x01:    // Set mode
									if (pData[3] != 0xff)
									{
										if (pData[3] == 0x00 || 
											pData[3] == 0x01 || 
											pData[3] == 0x02)
										{
											Globals.Tags.selMode.Value = 0;
										}
										else if (pData[3] == 0x03)
										{
											Globals.Tags.selMode.Value = 1;
											Globals.Tags.selMeter.Value = Globals.Tags.selMode.Value - 1;
											Globals.DrawScreen.DrawMainScreen(Globals.Tags.selMode.Value.Int-1);
										}
										else if (pData[3] == 0x05)
										{
											Globals.Tags.selMode.Value = 2;
											Globals.Tags.selMeter.Value = Globals.Tags.selMode.Value - 1;
											Globals.DrawScreen.DrawMainScreen(Globals.Tags.selMode.Value.Int-1);
										}
									
										Globals.CalAndUpdate.UpdateFlowRateTag();
										Globals.Tags.ValveState.Value = 0;
									}
									break;
								case 0x02:   // set air type
									if (pData[3] != 0xff)
									{
										Globals.Tags.gasType.Value = (int)pData[3];
										Globals.CalAndUpdate.UpdateFlowRateTag();
									}
									break;
								case 0x03:
									switch(Globals.Tags.selMeter.Value.Int)
									{
										case 0:
											Globals.Tags.flow_unit_low.Value = (int)pData[3];
											break;
										case 1:
											Globals.Tags.flow_unit_mid.Value = (int)pData[3];
											break;
									}
									Globals.DefaultSettings.SaveRecipe("Default_Setting",false);
									Globals.DrawScreen.DrawMainScreen(Globals.Tags.selMeter.Value.Int);
									Globals.CalAndUpdate.UpdateFlowRateTag();
									break;
								case 0x04:
									if (pData[3] != 0xff)
									{
										Globals.Tags.PressUnit.Value = (int)pData[3];
										Globals.CalAndUpdate.UpdateTestPressureTag();
										Globals.DefaultSettings.SaveRecipe("Default_Setting",false);
									}
									break;
								case 0x09:
									switch(Globals.Tags.selMode.Value.Int)
									{
										case 0:
											if (Globals.Comm.PressSensors[1].CheckZero())
											{
												Globals.Tags.tmr485_control.Value = 13;
												Globals.Tags.MainDisplayMessage.Value = 3;

											}
											else
											{
												Globals.Tags.MainDisplayMessage.Value = 13;
											}
											break;
										case 1:
											if (Globals.Comm.FlowMeters[0].CheckZero())
											{
												Globals.Tags.tmr232_control.Value = 3;
												Globals.Tags.MainDisplayMessage.Value = 1;

											}
											else
											{
												Globals.Tags.MainDisplayMessage.Value = 11;
											}
											break;
										case 2:
											if (Globals.Comm.FlowMeters[1].CheckZero())
											{
												Globals.Tags.tmr232_control.Value = 4;
												Globals.Tags.MainDisplayMessage.Value = 21;

											}
											else
											{
												Globals.Tags.MainDisplayMessage.Value = 23;
											}
											break;
										case 3:
											if (Globals.Comm.FlowMeters[2].CheckZero())
											{
												Globals.Tags.tmr232_control.Value = 5;
												Globals.Tags.MainDisplayMessage.Value = 2;

											}
											else
											{
												Globals.Tags.MainDisplayMessage.Value = 12;
											}
											break;
				
									}
									break;
									
							}
								
						}
					}
					else if (pData.Length == 6)   // Write Flow rate unit/ Pressure decimal
					{
						if (pData[1] == 0x01) 
						{
							switch (pData[2])
							{
								case 0x03:
									Globals.Tags.flow_unit_low.Value = (int)pData[3];
									Globals.Tags.flow_unit_mid.Value = (int)pData[5];
									
									Globals.DefaultSettings.SaveRecipe("Default_Setting",false);
									Globals.DrawScreen.DrawMainScreen(Globals.Tags.selMeter.Value.Int);
									Globals.CalAndUpdate.UpdateFlowRateTag();
									break;
								case 0x06:
									if (pData[3] != 0xff)
									{
										Globals.Tags.psigDecimal.Value = (int)pData[3];
									}
									
									if (pData[4] != 0xff)
									{
										Globals.Tags.ksiDecimal.Value = (int)pData[4];
									}
									
									if (pData[5] != 0xff)
									{
										Globals.Tags.barDecimal.Value = (int)pData[5];
									}
							
									Globals.DecimalSettings.SaveRecipe("Current",false);
									break;
							}
						}
						
					}
					else if (pData.Length == 7)  // write cal due date
					{
						
					}
					else if (pData.Length == 9)
					{
						if (pData[1] == 0x01) 
						{
							switch (pData[2])
							{
								case 0x07:
									if (pData[3] != 0xff)
									{
										Globals.Tags.FilterResponseLow.Value = (int)pData[3];
									}
									
									if (pData[4] != 0xff)
									{
										Globals.Tags.FilterUpperLimitLow.Value = (int)pData[4];
									}
									
									if (pData[5] != 0xff)
									{
										Globals.Tags.FilterResponseMid.Value = (int)pData[5];
									}
									
									if (pData[6] != 0xff)
									{
										Globals.Tags.FilterUpperLimitMid.Value = (int)pData[6];
									}
									
									if (pData[7] != 0xff)
									{
										Globals.Tags.FilterResponseHigh.Value = (int)pData[7];
									}
									
									if (pData[8] != 0xff)
									{
										Globals.Tags.FilterUpperLimitHigh.Value = (int)pData[8];
									}
									
									Globals.FilterSettingLow.SaveRecipe("Current",false);
									
									break;


								
							}
						}
					}
					else if (pData.Length == 15)
					{
						if (pData[1] == 0x01) 
						{
							switch (pData[2])
							{
								case 0x05:
									if (pData[3] != 0xff)
									{
										Globals.Tags.LowsccmDecimal.Value = (int)pData[3];
									}
									
									if (pData[4] != 0xff)
									{
										Globals.Tags.LowslpmDecimal.Value = (int)pData[4];
									}
									
									
									if (pData[5] != 0xff)
									{
										Globals.Tags.LowslpmDecimal.Value = (int)pData[5];
									}
									
									
									if (pData[6] != 0xff)
									{
										Globals.Tags.LowslpmDecimal.Value = (int)pData[6];
									}
								
									if (pData[11] != 0xff)
									{
										Globals.Tags.MidsccmDecimal.Value = (int)pData[12];	
									}
									
									if (pData[12] != 0xff)
									{
										Globals.Tags.MidslpmDecimal.Value = (int)pData[12];	
									}
									
									if (pData[13] != 0xff)
									{
										Globals.Tags.MidscfmDecimal.Value = (int)pData[12];	
									}
									
									if (pData[14] != 0xff)
									{
										Globals.Tags.MidscfhDecimal.Value = (int)pData[12];	
									}
									
									Globals.DecimalSettings.SaveRecipe("Current",false);
									
									break;
							}
						}
					}
					else if (pData.Length == 39)
					{
						if (pData[1] == 0x01) 
						{
							switch (pData[2])
							{
								case 0x08:
									if (pData[3] != 0xff &&
										pData[4] != 0xff && 
										pData[5] != 0xff &&
										pData[6] != 0xff)
									{
										Globals.Tags.Stab_low_green.Value = BitConverter.ToSingle(pData,3);
										
									}
									
									if (pData[7] != 0xff &&
										pData[8] != 0xff && 
										pData[9] != 0xff &&
										pData[10] != 0xff)
									{
										Globals.Tags.Stab_low_orange.Value = BitConverter.ToSingle(pData,7);
									}
									
									if (pData[11] != 0xff &&
										pData[12] != 0xff && 
										pData[13] != 0xff &&
										pData[14] != 0xff)
									{
										Globals.Tags.Stab_low_red.Value = BitConverter.ToSingle(pData,11);
									}
									
									
							
									Globals.StabSettingLow.SaveRecipe("Current",false);	
									
									
									if (pData[27] != 0xff &&
										pData[28] != 0xff && 
										pData[29] != 0xff &&
										pData[30] != 0xff)
									{
										Globals.Tags.Stab_mid_green.Value = BitConverter.ToSingle(pData,27);
									}

									if (pData[31] != 0xff &&
										pData[32] != 0xff && 
										pData[33] != 0xff &&
										pData[34] != 0xff)
									{
										Globals.Tags.Stab_mid_orange.Value = BitConverter.ToSingle(pData,31);
									}

									if (pData[35] != 0xff &&
										pData[36] != 0xff && 
										pData[37] != 0xff &&
										pData[38] != 0xff)
									{
										Globals.Tags.Stab_mid_red.Value = BitConverter.ToSingle(pData,35);
									}
									
									Globals.StabSettingMid.SaveRecipe("Current",false);	
									break;
							}
						}
					}
					break;
				case 0x04:	// Main screen display   

					SendMainScreenData();
					break; 
				case 0x05:	// Device Paramaters
					switch(pData[1])
					{
						case 0x00:	 // flow meters
							switch(pData[3])
							{
								case 0x00:	 // pressure		
									SendFormatPacket((float)Globals.Comm.FlowMeters[(int)pData[2]].dPressure,4,pData);
									break;
								case 0x01:   // temp
									SendFormatPacket((float)Globals.Comm.FlowMeters[(int)pData[2]].dTemp,4,pData);
									break;
								case 0x02:
									SendFormatPacket((float)Globals.Comm.FlowMeters[(int)pData[2]].dVolFlowRate,4,pData);
									break;
								case 0x03:
									SendFormatPacket((float)Globals.Comm.FlowMeters[(int)pData[2]].dMassFlowRate,4,pData);
									break;
								case 0x07:
									SendFormatPacket((float)Globals.Comm.FlowMeters[(int)pData[2]].fSerialNum,4,pData);
									break;
								case 0x0a:
									if (pData[2] == 0x00)
									{
										SendFormatPacket((float)Globals.Tags.LowRangeMin.Value.Double,4,pData);
									}
									else if (pData[2] == 0x01)
									{
										SendFormatPacket((float)Globals.Tags.MidRangeMin.Value.Double,4,pData);
									}
									break;
								case 0x0b:
									if (pData[2] == 0x00)
									{
										SendFormatPacket((float)Globals.Tags.LowRangeMax.Value.Double,4,pData);
									}
									else if (pData[2] == 0x01)
									{
										SendFormatPacket((float)Globals.Tags.MidRangeMax.Value.Double,4,pData);
									}
									break;
								case 0x0c:
									if (pData[2] == 0x00)
									{
										SendFormatPacket((byte)Globals.Tags.meter_unit_low.Value.Int,4,pData);
									}
									else if (pData[2] == 0x01)
									{
										SendFormatPacket((byte)Globals.Tags.meter_unit_mid.Value.Int,4,pData);
									}
									break;
							}
							break;
						case 0x01:   // Pressure sensors
							switch(pData[3])
							{
								case 0x00:	 //pressure
									SendFormatPacket((float)Globals.Comm.PressSensors[(int)pData[2]].dPressure,4,pData);
									break;
								case 0x01:
									break;
								case 0x07:
									SendFormatPacket(Globals.Comm.PressSensors[(int)pData[2]].fSerialNum,4,pData);
									break;
								case 0x08:
									SendFormatPacket((float)0.0,4,pData);
									break;
								case 0x09:
									if (pData[2] == 0x00)
									{
										SendFormatPacket((float)Globals.Tags.Inlet_Press_Max.Value.Double,4,pData);
									}
									else if (pData[2] == 0x01)
									{
										SendFormatPacket((float)Globals.Tags.Test_Press_Max.Value.Double,4,pData);
									}
									break;
								case 0x0a:
									SendFormatPacket((byte)Globals.Tags.press_meter_unit.Value.Double,4,pData);
									break;
							}
							break;
						
						case 0x02:   // Solenoid sensors
							switch(pData[3])
							{
								case 0x00:
									SendFormatPacket((byte)Globals.Comm.SolenoidValves[(int)pData[2]].currentStatus,4,pData);
									break;
								case 0x01:
									SendFormatPacket((float)Globals.Comm.SolenoidValves[(int)pData[2]].openVoltage,4,pData);
									break;
								case 0x02:
									SendFormatPacket((float)Globals.Comm.SolenoidValves[(int)pData[2]].closeVoltage,4,pData);
									break;
							}
							break;
					}
					break;
				case 0x06:
					switch(pData[1])
					{
						case 0x00:  // Switch Flow Unit


                            



							switch (Globals.Tags.selMeter.Value.Int)
							{
								case 0:
									selUnit = (int)Globals.Tags.flow_unit_low.Value;
									selUnit++;
									if (selUnit > 3)
									{
										selUnit = 0;
									}
									Globals.Tags.flow_unit_low.Value = selUnit;
									break;
								case 1:
									selUnit = (int)Globals.Tags.flow_unit_mid.Value;
									selUnit++;
									if (selUnit > 3)
									{
										selUnit = 0;
									}
									Globals.Tags.flow_unit_mid.Value = selUnit;
									break;
								case 2:
									selUnit = (int)Globals.Tags.flow_unit_high.Value;
									selUnit++;
									if (selUnit > 3)
									{
										selUnit = 0;
									}
									Globals.Tags.flow_unit_high.Value = selUnit;
									break;
							}
							Globals.DefaultSettings.SaveRecipe("Default_Setting",false);
							Globals.DrawScreen.DrawMainScreen(Globals.Tags.selMeter.Value.Int);
							break;
						case 0x01:  // Switch Pressure Unit
							if (Globals.Tags.PressUnit.Value > 1)
							{
								Globals.Tags.PressUnit.Value = 0;
							}
							else
							{
								Globals.Tags.PressUnit.Value = Globals.Tags.PressUnit.Value.Int + 1;
							}
				
							Globals.CalAndUpdate.UpdateTestPressureTag();
							Globals.DefaultSettings.SaveRecipe("Default_Setting",false);
							break;
						case 0x02:	// switch Mode
							Globals.Tags.selMode.Value++;
							if (Globals.Tags.selMode.Value > 3)
							{
								Globals.Tags.selMode.Value = 0;
							}
							//	Button7.Text = Globals.UnitsAndConversion.GetModeName(selMode);
							if (Globals.Tags.selMode.Value != 0)
							{
								Globals.Tags.selMeter.Value = Globals.Tags.selMode.Value - 1;
								Globals.DrawScreen.DrawMainScreen(Globals.Tags.selMode.Value-1);
							}
			
							//		ShowZeroButtonText();
							Globals.CalAndUpdate.UpdateFlowRateTag();	
							Globals.Tags.ValveState.Value = 0;	
							break;

					}
					break;
				case 0x07:
					switch(pData[1])
					{
						case 0x00:
							Globals.Tags.wifiStreaming.Value = 1;
							Globals.Tags.gTimerCount.Value = 0;
							Globals.Tags.RemoteDesktopIcon.Value = 1;
							break;
						case 0x01:
							Globals.Tags.wifiStreaming.Value = 0;
							Globals.Tags.RemoteDesktopIcon.Value = 0;
							break;
						case 0x02:  // force disconnect, implement in client
							break;
						case 0x03:	// start device data
							Globals.Tags.tmr485_control.Value = 14;
							break;
					}
					break;

			}
			
		}
		
		public void SendRawBytePacket(byte[] inData)
		{
			SendPacket(mTargetIPAddr,mSrcPort,mDesPort,mProtocol,0x00,inData,inData.Length);
		}
		
		public void SendBytePacket(byte inData, int preLen, byte[] preData)
		{
			byte[] sendData = new byte[1 + preLen];
			
			for (int i = 0; i < preLen; i++)
			{
				sendData[i] = preData[i];
			}
			
			sendData[preLen] = inData;
			
			SendPacket(mTargetIPAddr,mSrcPort,mDesPort,mProtocol,0x00,sendData,sendData.Length);
			
		}
		
		public void SendBytePacket(byte[] inData, int preLen, byte[] preData)
		{
			byte[] sendData = new byte[inData.Length + preLen];
			
			for (int i = 0; i < preLen; i++)
			{
				sendData[i] = preData[i];
			}
			
			for (int i = preLen; i < sendData.Length; i++)
			{
				sendData[i] = inData[i - preLen];
			}
			
			SendPacket(mTargetIPAddr,mSrcPort,mDesPort,mProtocol,0x00,sendData,sendData.Length);
			
		}
		public void SendFormatPacket(string strInput, int preLen, byte[] preData)
		{
			byte[] pSerial = Encoding.ASCII.GetBytes(strInput);
			byte[] sendData = new byte[pSerial.Length + preLen];
			
			for (int i = 0; i < preLen; i++)
			{
				sendData[i] = preData[i];
			}				
			for(int i = preLen; i < sendData.Length; i++)
			{
				sendData[i] = pSerial[i - preLen]; 
			}
							
			SendPacket(mTargetIPAddr,mSrcPort,mDesPort,mProtocol,0x00,sendData,sendData.Length);
		}
		
		public void SendFormatPacket(double dInput, int preLen, byte[] preData)
		{
			byte[] pSerial = BitConverter.GetBytes(dInput); 
			byte[] sendData = new byte[pSerial.Length + preLen];
			
			for (int i = 0; i < preLen; i++)
			{
				sendData[i] = preData[i];
			}				
			for(int i = preLen; i < sendData.Length; i++)
			{
				sendData[i] = pSerial[i - preLen]; 
			}
							
			SendPacket(mTargetIPAddr,mSrcPort,mDesPort,mProtocol,0x00,sendData,sendData.Length);	
		}
		
		public void SendFormatPacket(float dInput, int preLen, byte[] preData)
		{
			byte[] pSerial = BitConverter.GetBytes(dInput); 
			byte[] sendData = new byte[pSerial.Length + preLen];
			
			for (int i = 0; i < preLen; i++)
			{
				sendData[i] = preData[i];
			}				
			for(int i = preLen; i < sendData.Length; i++)
			{
				sendData[i] = pSerial[i - preLen]; 
			}
							
			SendPacket(mTargetIPAddr,mSrcPort,mDesPort,mProtocol,0x00,sendData,sendData.Length);	
		}
		
				
		public void SendFormatPacket(short dInput, int preLen, byte[] preData)
		{
			byte[] pSerial = BitConverter.GetBytes(dInput); 
			byte[] sendData = new byte[pSerial.Length + preLen];
			
			for (int i = 0; i < preLen; i++)
			{
				sendData[i] = preData[i];
			}				
			for(int i = preLen; i < sendData.Length; i++)
			{
				sendData[i] = pSerial[i - preLen]; 
			}
							
			SendPacket(mTargetIPAddr,mSrcPort,mDesPort,mProtocol,0x00,sendData,sendData.Length);	
		}
		
		public void SendFormatPacket(int dInput, int preLen, byte[] preData)
		{
			byte[] pSerial = BitConverter.GetBytes(dInput); 
			byte[] sendData = new byte[pSerial.Length + preLen];
			
			for (int i = 0; i < preLen; i++)
			{
				sendData[i] = preData[i];
			}				
			for(int i = preLen; i < sendData.Length; i++)
			{
				sendData[i] = pSerial[i - preLen]; 
			}
							
			SendPacket(mTargetIPAddr,mSrcPort,mDesPort,mProtocol,0x00,sendData,sendData.Length);	
		}
		
		public void SendFormatPacket(uint dInput, int preLen, byte[] preData)
		{
			byte[] pSerial = BitConverter.GetBytes(dInput); 
			byte[] sendData = new byte[pSerial.Length + preLen];
			
			for (int i = 0; i < preLen; i++)
			{
				sendData[i] = preData[i];
			}				
			for(int i = preLen; i < sendData.Length; i++)
			{
				sendData[i] = pSerial[i - preLen]; 
			}
							
			SendPacket(mTargetIPAddr,mSrcPort,mDesPort,mProtocol,0x00,sendData,sendData.Length);	
		}
		
		public void ReceiveModemStatus(string strInput)
		{
			
		}
		
		public string CalCheckSum(string strInput)
		{
			int bCheckSumTotal = 0;
			int tmp;

			if (strInput.Length % 2 == 0)
			{
				for (int i = 0; i < strInput.Length / 2; i++)
				{
					tmp = Convert.ToInt32(strInput.Substring(i * 2, 2),16);
					bCheckSumTotal = bCheckSumTotal + tmp;
				}

				bCheckSumTotal = bCheckSumTotal & 0xFF;

				bCheckSumTotal = 0xFF - bCheckSumTotal;

				return bCheckSumTotal.ToString("X2");
			}
			else
			{
				return "err";
			}

		}
		
		
			
	}

	/*
	public class SerialManager
	{
		private SerialPort mPort;
		Queue<string> serQue;
		private int mInterval = 100; // ms
		private const int conInt = 100; // ms
		private const int minInt = 30; // ms
		private const int maxInt = 100; // ms
		private const int maxHolds = 10;
		private const int minHolds = 1;
		private double coefK, coefB;
		private Timer tmrSerial;
		//		private int preQueCount;
		//		private int curQueCount;
		//		private int diff;
		public SerialManager(SerialPort inPort)
		{
			mPort = inPort;
			serQue = new Queue<string>();
			tmrSerial = new Timer();
			tmrSerial.Interval = mInterval;
			tmrSerial.Tick += new EventHandler(SERIAL_TICK);
			tmrSerial.Enabled = true;
			coefK = (double)(minInt - maxInt) / (double)(maxHolds - minHolds);
			coefB = (double)(maxInt) - coefK;
		}
		
		public void AddQue(string cmd)
		{
			serQue.Enqueue(cmd);
		}
		
		private void SERIAL_TICK(Object myObject, EventArgs myEventArgs) 
		{
			if (serQue.Count > 0)
			{

				mInterval = (int)(coefK * (double)serQue.Count + coefB);
				
				if (mInterval < minInt)
				{
					mInterval = minInt;
				}
				else if (mInterval > maxInt)
				{
					mInterval = maxInt;
				}
				tmrSerial.Interval = mInterval;
				
				mPort.Write(serQue.Dequeue());
			}
		}
	}
	*/
	
	public partial class Definition
	{


	}
}
