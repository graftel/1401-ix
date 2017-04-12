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
    
    
    public partial class NozzleCheckValue
    {
		private Timer tmrPoll;
	//	private int iFlowUnit;
	//	private int iPressUnit;
		
		void NozzleCheckValue_Opened(System.Object sender, System.EventArgs e)
		{
	//		iFlowUnit = 0;
	//		iPressUnit = 0;
			tmrPoll = new Timer();
			tmrPoll.Interval = 500;
			tmrPoll.Enabled = true;
			tmrPoll.Tick += POLL_TICK;
		}
		
		private void POLL_TICK(Object myObject, EventArgs myEventArgs) 
		{
			if (Globals.Comm.SolenoidValves[Globals.Tags.SettingSel.Value.Int - 1].currentStatus != ValveStatus.Open)
			{
				Globals.Comm.SolenoidValves[Globals.Tags.SettingSel.Value.Int - 1].Open_ASC();
			}
			else
			{
				for (int i = 0; i < Globals.Comm.SolenoidValves.Count; i++)
				{
					if (i != Globals.Tags.SettingSel.Value.Int - 1 &&
						Globals.Comm.SolenoidValves[i].currentStatus != ValveStatus.Close)
					{
						Globals.Comm.SolenoidValves[i].Close_ASC();						
						return;
					}
				}
				
				Globals.Comm.FlowMeters[Globals.Tags.SettingSel.Value.Int - 1].RequestData();
				
				Globals.Tags.nozzleMeterFlowRate.Value = 
					Globals.CalAndUpdate.ConvertNumberToStr(
					Globals.UnitsAndConversion.FlowConv(
					Globals.Comm.FlowMeters[Globals.Tags.SettingSel.Value.Int - 1].GetMassFlowRate(),
					(int)Globals.Comm.FlowMeters[Globals.Tags.SettingSel.Value.Int - 1].iMeterUnit,
					Globals.Tags.nozzleFlowUnit.Value.Int)
					, 
					Globals.UnitsAndConversion.GetFlowDecimal(Globals.Tags.SettingSel.Value.Int - 1, Globals.Tags.nozzleFlowUnit.Value.Int)); 
				

				Globals.Tags.nozzleMeterPressure.Value = 
					Globals.CalAndUpdate.ConvertNumberToStr(
					Globals.UnitsAndConversion.PressConv(
					Globals.Comm.FlowMeters[Globals.Tags.SettingSel.Value.Int - 1].GetPressure(),
					0,
					Globals.Tags.nozzlePressUnit.Value.Int)
					, 
					Globals.UnitsAndConversion.GetPressDecimal(Globals.Tags.nozzlePressUnit.Value.Int)); 
				
				
				Globals.Tags.nozzleTestPressure.Value = 
					Globals.CalAndUpdate.ConvertNumberToStr(
					Globals.UnitsAndConversion.PressConv(
					Globals.Tags.nozzleReferencePressure.Value.Double,
					0,
					Globals.Tags.nozzlePressUnit.Value.Int)
					, 
					Globals.UnitsAndConversion.GetPressDecimal(Globals.Tags.nozzlePressUnit.Value.Int)); 
				
				double dFlowError = 0.0;
				
				switch (Globals.Tags.SettingSel.Value.Int)
				{
					case 1:
						if (Globals.Tags.nozzleErrorType.Value.String == "%FS")
						{
							dFlowError = 100 * Math.Abs((Globals.Comm.FlowMeters[Globals.Tags.SettingSel.Value.Int - 1].GetMassFlowRate() - Globals.Tags.nozzleReferenceFlowLow.Value.Double) / Globals.Tags.LowRangeMax.Value.Double);
							Globals.Tags.nozzleFlowError.Value = Globals.CalAndUpdate.ConvertNumberToStr(dFlowError,2) + " %FS";
						}
						else if (Globals.Tags.nozzleErrorType.Value.String == "%RDG")
						{
							dFlowError = 100 * Math.Abs((Globals.Comm.FlowMeters[Globals.Tags.SettingSel.Value.Int - 1].GetMassFlowRate() - Globals.Tags.nozzleReferenceFlowLow.Value.Double) / Globals.Tags.nozzleReferenceFlowLow.Value.Double);
							Globals.Tags.nozzleFlowError.Value = Globals.CalAndUpdate.ConvertNumberToStr(dFlowError,2) + " %RDG";
						}
						
						
						if (dFlowError > Globals.Tags.nozzleErrorLimit.Value.Double)
						{
							Globals.Tags.nozzleErrorColor.Value = 1;
						}
						else
						{
							Globals.Tags.nozzleErrorColor.Value = 0;	
						}
						
						Globals.Tags.nozzleExpectFlowRate.Value = 
							Globals.CalAndUpdate.ConvertNumberToStr(
							Globals.UnitsAndConversion.FlowConv(
								Globals.Tags.nozzleReferenceFlowLow.Value.Double,
							(int)Globals.Comm.FlowMeters[Globals.Tags.SettingSel.Value.Int - 1].iMeterUnit,
							Globals.Tags.nozzleFlowUnit.Value.Int)
							, 
							Globals.UnitsAndConversion.GetFlowDecimal(Globals.Tags.SettingSel.Value.Int - 1, Globals.Tags.nozzleFlowUnit.Value.Int)); 
						break;
					case 2:
						if (Globals.Tags.nozzleErrorType.Value.String == "%FS")
						{
							dFlowError = 100 * Math.Abs((Globals.Comm.FlowMeters[Globals.Tags.SettingSel.Value.Int - 1].GetMassFlowRate() - Globals.Tags.nozzleReferenceFlowMid.Value.Double) / Globals.Tags.MidRangeMax.Value.Double);
							Globals.Tags.nozzleFlowError.Value = Globals.CalAndUpdate.ConvertNumberToStr(dFlowError,2) + " %FS";
						}
						else if (Globals.Tags.nozzleErrorType.Value.String == "%RDG")
						{
							dFlowError = 100 * Math.Abs((Globals.Comm.FlowMeters[Globals.Tags.SettingSel.Value.Int - 1].GetMassFlowRate() - Globals.Tags.nozzleReferenceFlowMid.Value.Double) / Globals.Tags.nozzleReferenceFlowMid.Value.Double);
							Globals.Tags.nozzleFlowError.Value = Globals.CalAndUpdate.ConvertNumberToStr(dFlowError,2) + " %RDG";
						}
					
						if (dFlowError > Globals.Tags.nozzleErrorLimit.Value.Double)
						{
							Globals.Tags.nozzleErrorColor.Value = 1;
						}
						else
						{
							Globals.Tags.nozzleErrorColor.Value = 0;	
						}
						
						Globals.Tags.nozzleExpectFlowRate.Value = 
							Globals.CalAndUpdate.ConvertNumberToStr(
							Globals.UnitsAndConversion.FlowConv(
							Globals.Tags.nozzleReferenceFlowMid.Value.Double,
							(int)Globals.Comm.FlowMeters[Globals.Tags.SettingSel.Value.Int - 1].iMeterUnit,
							Globals.Tags.nozzleFlowUnit.Value.Int)
							, 
							Globals.UnitsAndConversion.GetFlowDecimal(Globals.Tags.SettingSel.Value.Int - 1, Globals.Tags.nozzleFlowUnit.Value.Int)); 
						
						break;
					case 3:
						if (Globals.Tags.nozzleErrorType.Value.String == "%FS")
						{
							dFlowError = 100 * Math.Abs((Globals.Comm.FlowMeters[Globals.Tags.SettingSel.Value.Int - 1].GetMassFlowRate() - Globals.Tags.nozzleReferenceFlowHigh.Value.Double) / Globals.Tags.HighRangeMax.Value.Double);
							Globals.Tags.nozzleFlowError.Value = Globals.CalAndUpdate.ConvertNumberToStr(dFlowError,2) + " %FS";
						}
						else if (Globals.Tags.nozzleErrorType.Value.String == "%RDG")
						{
							dFlowError = 100 * Math.Abs((Globals.Comm.FlowMeters[Globals.Tags.SettingSel.Value.Int - 1].GetMassFlowRate() - Globals.Tags.nozzleReferenceFlowHigh.Value.Double) / Globals.Tags.nozzleReferenceFlowHigh.Value.Double);
							Globals.Tags.nozzleFlowError.Value = Globals.CalAndUpdate.ConvertNumberToStr(dFlowError,2) + " %RDG";
						}
						
						if (dFlowError > Globals.Tags.nozzleErrorLimit.Value.Double)
						{
							Globals.Tags.nozzleErrorColor.Value = 1;
						}
						else
						{
							Globals.Tags.nozzleErrorColor.Value = 0;	
						}
						
						Globals.Tags.nozzleExpectFlowRate.Value = 
							Globals.CalAndUpdate.ConvertNumberToStr(
							Globals.UnitsAndConversion.FlowConv(
							Globals.Tags.nozzleReferenceFlowHigh.Value.Double,
							(int)Globals.Comm.FlowMeters[Globals.Tags.SettingSel.Value.Int - 1].iMeterUnit,
							Globals.Tags.nozzleFlowUnit.Value.Int)
							, 
							Globals.UnitsAndConversion.GetFlowDecimal(Globals.Tags.SettingSel.Value.Int - 1, Globals.Tags.nozzleFlowUnit.Value.Int)); 
						break;
				}
				
			
			}
			
		}
		
		void btnUnit_Click(System.Object sender, System.EventArgs e)
		{
			if (Globals.Tags.nozzleFlowUnit.Value.Int > 2)
			{
				Globals.Tags.nozzleFlowUnit.Value = 0;
			}
			else
			{
				Globals.Tags.nozzleFlowUnit.Value++;
			}
			
			btnUnit.Text = Globals.UnitsAndConversion.GetFlowRateUnits(Globals.Tags.nozzleFlowUnit.Value.Int);
			
			Globals.PersistentVariables.SaveRecipe("Current",false);
		}
		
		void Button3_Click(System.Object sender, System.EventArgs e)
		{
			if (Globals.Tags.nozzlePressUnit.Value.Int > 1)
			{
				Globals.Tags.nozzlePressUnit.Value = 0;
			}
			else
			{
				Globals.Tags.nozzlePressUnit.Value++;
			}
			Button3.Text = Globals.UnitsAndConversion.GetPressureUnits(Globals.Tags.nozzlePressUnit.Value.Int);
			
			Globals.PersistentVariables.SaveRecipe("Current",false);
		}
		
		void NozzleCheckValue_Closed(System.Object sender, System.EventArgs e)
		{
			tmrPoll.Enabled = false;
		}
    }
}
