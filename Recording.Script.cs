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
	
	public partial class Recording
	{
		public string path, pathLocal, pathIndex;
		public string dt, dt_normal;
		public DateTime currentDateTime;
		public string DateFormat, TimeFormat;
		string WriteLine;
		int PressUnitRec;
		StreamWriter swUSB, swLocal, swIndex;
		

		public void CreatNewFile()
		{
			if (Globals.Tags.SystemTagAvailableStorage.Value < 5)
			{
				if (Directory.Exists("\\FlashDrive\\Project\\Project Files\\Recordings\\"))
				{
					System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo("\\FlashDrive\\Project\\Project Files\\Recordings\\");
					foreach (System.IO.FileInfo file in dir.GetFiles())
					{
						try{
							file.Delete();
						}
						catch
						{
						}
					}
					
				}
			}

			currentDateTime = DateTime.Now;
			
			DateFormat = Globals.Tags.DateFormat.Value.String;
			TimeFormat = Globals.Tags.TimeFormat.Value.String;
			
			dt = currentDateTime.ToString(DateFormat.Replace('/','-') + "_" + TimeFormat.Replace(':','-'));
			dt_normal = currentDateTime.ToString("MM/dd/yyyy HH:mm:ss");
			path = "\\Hard Disk\\" + Globals.Tags.Selected_FileName.Value + "_" + Globals.Tags.Selected_TesterInitial.Value + "_" + dt + ".csv";
			pathLocal = "\\FlashDrive\\Project\\Project Files\\Recordings";
			
			if (Directory.Exists(pathLocal) == false)
			{
				Directory.CreateDirectory(pathLocal);
			}
			
			Globals.Tags.currentDataSet.Value = 0;
			
			pathLocal = pathLocal + "\\" + dt + ".csv";
			Globals.Tags.RcrdTotalSeconds.Value = 0;
			Globals.Tags.RcrdTotalTimes.Value = 0;
			//path = "\\Hard Disk\\aaaaaaaa.csv";
			try
			{
		//		FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.Write);
		//		fs.Close();
				swUSB = new StreamWriter(path, true, Encoding.ASCII);
				swLocal = new StreamWriter(pathLocal, true, Encoding.ASCII);
				if (Globals.Tags.popRcrdShow.Value == 0)
				{
					WriteLine = "";
				}
				else
				{
					WriteLine = "Gas Type," + Globals.UnitsAndConversion.GetGasTypeStr() + "\r\n";
					WriteLine = WriteLine + "Cal Due," + Globals.Tags.calDueDate.Value.String + "\r\n";
					WriteLine = WriteLine + "LRM ID," + Globals.Tags.popStrLRMID.Value.String + "\r\n";
					WriteLine = WriteLine + "Tester PIN," + Globals.Tags.popStrTesterPIN.Value.String + "\r\n";
					WriteLine = WriteLine + "Job #," + Globals.Tags.popStrJobNum.Value.String + "\r\n";
					WriteLine = WriteLine + "Task #," + Globals.Tags.popStrTaskNum.Value.String + "\r\n";
					WriteLine = WriteLine + "Comment," + Globals.Tags.popStrComment.Value.String + "\r\n";
					WriteLine = WriteLine + "," + Globals.Tags.popStrComment1.Value.String + "\r\n";
					WriteLine = WriteLine + "," + Globals.Tags.popStrComment2.Value.String + "\r\n";
					WriteLine = WriteLine + "," + Globals.Tags.popStrComment3.Value.String + "\r\n\r\n";
				}
				
				WriteLine = WriteLine + "Date,Time,Gas Type,Inlet Pressure,Test Pressure,Meter,Flow Rate,Unit\r\n";
				WriteLine = WriteLine + ",,,(" + 
					Globals.UnitsAndConversion.GetPressureUnits((int)Globals.Tags.PressUnit.Value) + 
					"),(" + 
					Globals.UnitsAndConversion.GetPressureUnits((int)Globals.Tags.PressUnit.Value) + 
					"),,,\r\n";
				
				PressUnitRec = 	(int)Globals.Tags.PressUnit.Value;
				swUSB.Write(WriteLine);
				swLocal.Write(WriteLine);
				
			}
			catch
			{
				Globals.Tags.RcrdStatus.Value = 0;
				Globals.Tags.MainDisplayMessage.Value = 16;
			}
		}
	
		public void RecordDataPoint()
		{	try
			{
				//sw = new StreamWriter(path, true, Encoding.ASCII);
				WriteLine = DateTime.Now.ToString(DateFormat) + "," +
							DateTime.Now.ToString(TimeFormat) + "," + 
							Globals.TextLibrary.GasType.Messages[Globals.Tags.gasType.Value.Int].Message + "," + // Gas Type
				
							Globals.UnitsAndConversion.PressConv(Globals.Tags.RawInletPressure.Value,(int)Globals.Tags.press_meter_unit.Value,PressUnitRec).ToString("F" + Globals.UnitsAndConversion.GetPressDecimal(PressUnitRec).ToString()) + "," +
			
							Globals.UnitsAndConversion.PressConv(Globals.Tags.RawTestPressure.Value,(int)Globals.Tags.press_meter_unit.Value,PressUnitRec).ToString("F" + Globals.UnitsAndConversion.GetPressDecimal(PressUnitRec).ToString()) + "," +
				
							Globals.TextLibrary.FlowMeterName.Messages[Globals.Tags.selMeter.Value.Int].Message.ToUpper() + "," +// Meter
				
							Globals.Tags.MainFlowRateDisplayStr.Value.String + "," + 
				
							Globals.Tags.MainFlowUnitBtn.Value.ToString()+ "\r\n";
				//WriteLine = "something\r\n";

				swUSB.Write(WriteLine);
				swLocal.Write(WriteLine);
				
				Globals.Tags.currentDataSet.Value++;
			}
			catch
			{
				Globals.Tags.RcrdStatus.Value = 0;
				Globals.Tags.MainDisplayMessage.Value = 17;
			}
		}
		public void CloseDataFile()
		{
			try
			{
				swUSB.Close();
				swLocal.Close();
			}
			catch
			{
				Globals.Tags.RcrdStatus.Value = 0;
				Globals.Tags.MainDisplayMessage.Value = 18;
			}
			TimeSpan diff;
			diff = DateTime.Now - currentDateTime;
			string duration;
			
			if (diff.TotalSeconds >= 60)
			{
				if (diff.TotalMinutes >= 60)
				{
					duration = diff.TotalHours.ToString("F0") + " hr(s)";
				}
				else
				{
					duration = diff.TotalMinutes.ToString("F0") + " min(s)";
				}
			}
			else
			{
				if (diff.TotalSeconds <= 1)
				{
					duration = "1 sec";
				}
				else
				{
					duration = diff.TotalSeconds.ToString("F0") + " secs";
				}
			}
			
			try
			{
				pathIndex = "\\FlashDrive\\Project\\Project Files\\Recordings\\Rrcd_Index.csv";
				swIndex = new StreamWriter(pathIndex, true, Encoding.ASCII);
				WriteLine = pathLocal + "," + dt_normal + "," + duration + "\r\n";
				swIndex.Write(WriteLine);
				swIndex.Close();
			}
			catch
			{
				
			}
			
		}

		
    }
}
