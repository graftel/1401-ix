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
    
    
    public partial class NozzleCheckConfig
    {
		Timer pressCount;
		
		private int count = 0;
		
		private int selected = 0;
		
		private double increment;
		
		private Timer tmrCalculator;
		
		private double setValue = 0;
		
		private int request = 0;
		
		void NozzleCheckConfig_Opened(System.Object sender, System.EventArgs e)
		{
			tmrCalculator = new Timer();
			tmrCalculator.Enabled = false;
			tmrCalculator.Interval = 500;
			tmrCalculator.Tick += CAL_TICK;
			
			pressCount = new Timer();
			
			pressCount.Tick += pressCountTick;
			
			pressCount.Interval = 200;
			
			pressCount.Enabled = false;
			
			Validate();
			
		}
		
		private void CAL_TICK(Object myObject, EventArgs myEventArgs) 
		{
			if (Globals.Tags.Status_CalculatorScr.Value.Bool == false)
			{
				try{
					setValue = Double.Parse(Globals.Tags.Enter_Value.Value.String);
				}
				catch
				{
					setValue = 0;
				}
				
				switch(request)
				{
					case 0:
						Globals.Tags.nozzleReferenceFlowLow.Value = 
							Globals.UnitsAndConversion.FlowConv(setValue, Globals.Tags.nozzleFlowUnit.Value.Int, (int)Globals.Comm.FlowMeters[request].iMeterUnit);
						break;
					case 1:
						Globals.Tags.nozzleReferenceFlowMid.Value = 
							Globals.UnitsAndConversion.FlowConv(setValue, Globals.Tags.nozzleFlowUnit.Value.Int, (int)Globals.Comm.FlowMeters[request].iMeterUnit);
						break;
					case 2:
						Globals.Tags.nozzleReferenceFlowHigh.Value = 
							Globals.UnitsAndConversion.FlowConv(setValue, Globals.Tags.nozzleFlowUnit.Value.Int, (int)Globals.Comm.FlowMeters[request].iMeterUnit);
						break;
				}
				
				Globals.PersistentVariables.SaveRecipe("Current",false);
				tmrCalculator.Enabled = false;
				
				Validate();
			}
		}
		
		private void pressCountTick(System.Object sender, System.EventArgs e)
		{
			count++;

			if (count >= 0 && count < 20)
			{
				increment = 0.1;
			}
			else if (count >= 20 && count < 40)
			{
				increment = 1;
			}
			else if (count >= 40 && count < 60)
			{
				increment = 5;
			}
			else
			{
				increment = 50;
			}
				
			
			switch(selected)
			{
				case 0:
					Globals.Tags.nozzleErrorLimit.Value = Globals.Tags.nozzleErrorLimit.Value - increment;
					break;
				case 1:
					Globals.Tags.nozzleErrorLimit.Value = Globals.Tags.nozzleErrorLimit.Value + increment;
					break;
				case 2:
					Globals.Tags.nozzleReferenceFlowLow.Value = Globals.Tags.nozzleReferenceFlowLow.Value - increment * 10.0;
					break;
				case 3:
					Globals.Tags.nozzleReferenceFlowLow.Value = Globals.Tags.nozzleReferenceFlowLow.Value + increment * 10.0;
					break;
				case 4:
					Globals.Tags.nozzleReferenceFlowMid.Value = Globals.Tags.nozzleReferenceFlowMid.Value - increment / 100.0;
					break;
				case 5:
					Globals.Tags.nozzleReferenceFlowMid.Value = Globals.Tags.nozzleReferenceFlowMid.Value + increment / 100.0;
					break;
				case 6:
					Globals.Tags.nozzleReferenceFlowHigh.Value = Globals.Tags.nozzleReferenceFlowHigh.Value - increment;
					break;
				case 7:
					Globals.Tags.nozzleReferenceFlowHigh.Value = Globals.Tags.nozzleReferenceFlowHigh.Value + increment;
					break;
			}
			Validate();			
		}
		
		void btnErrorInc_Click(System.Object sender, System.EventArgs e)
		{
			count = 0;
			Globals.Tags.nozzleErrorLimit.Value = Globals.Tags.nozzleErrorLimit.Value + 0.01;
			Validate();
		}
		
		void btnErrorInc_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			count = 0;
			pressCount.Enabled = true;
			selected = 1;
		}
		
		void btnErrorInc_MouseUp(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			pressCount.Enabled = false;
		}
		
		void btnErrorDec_Click(System.Object sender, System.EventArgs e)
		{
			count = 0;
			Globals.Tags.nozzleErrorLimit.Value = Globals.Tags.nozzleErrorLimit.Value - 0.01;
			Validate();
		}
		
		void btnErrorDec_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			count = 0;
			pressCount.Enabled = true;
			selected = 0;
		}
		
		void btnErrorDec_MouseUp(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			pressCount.Enabled = false;
		}
		
		void btnRefLowInc_Click(System.Object sender, System.EventArgs e)
		{
			count = 0;
			Globals.Tags.nozzleReferenceFlowLow.Value = Globals.Tags.nozzleReferenceFlowLow.Value + 0.01;
			Validate();
		}
		
		void btnRefLowInc_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			count = 0;
			pressCount.Enabled = true;
			selected = 3;
		}
		
		void btnRefLowInc_MouseUp(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			pressCount.Enabled = false;
		}
		
		void btnRefLowDec_Click(System.Object sender, System.EventArgs e)
		{
			count = 0;
			Globals.Tags.nozzleReferenceFlowLow.Value = Globals.Tags.nozzleReferenceFlowLow.Value - 0.01;
			Validate();
		}
		
		void btnRefLowDec_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			count = 0;
			pressCount.Enabled = true;
			selected = 2;
		}
		
		void btnRefLowDec_MouseUp(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			pressCount.Enabled = false;
		}
		
		void btnRefMidDec_Click(System.Object sender, System.EventArgs e)
		{
			count = 0;
			Globals.Tags.nozzleReferenceFlowMid.Value = Globals.Tags.nozzleReferenceFlowMid.Value - 0.01;
			Validate();
		}
		
		void btnRefMidDec_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			count = 0;
			pressCount.Enabled = true;
			selected = 4;
		}
		
		void btnRefMidDec_MouseUp(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			pressCount.Enabled = false;
		}
		
		void btnRefMidInc_Click(System.Object sender, System.EventArgs e)
		{
			count = 0;
			Globals.Tags.nozzleReferenceFlowMid.Value = Globals.Tags.nozzleReferenceFlowMid.Value + 0.01;
			Validate();
		}
		
		void btnRefMidInc_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			count = 0;
			pressCount.Enabled = true;
			selected = 5;
		}
		
		void btnRefMidInc_MouseUp(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			pressCount.Enabled = false;
		}
		
		void btnRefHighInc_Click(System.Object sender, System.EventArgs e)
		{
			count = 0;
			Globals.Tags.nozzleReferenceFlowHigh.Value = Globals.Tags.nozzleReferenceFlowHigh.Value + 0.01;
			Validate();
		}
		
		void btnRefHighInc_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			count = 0;
			pressCount.Enabled = true;
			selected = 7;
		}
		
		void btnRefHighInc_MouseUp(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			pressCount.Enabled = false;
		}
		
		void btnRefHighDec_Click(System.Object sender, System.EventArgs e)
		{
			count = 0;
			Globals.Tags.nozzleReferenceFlowHigh.Value = Globals.Tags.nozzleReferenceFlowHigh.Value - 0.01;
			Validate();
		}
		
		void btnRefHighDec_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			count = 0;
			pressCount.Enabled = true;
			selected = 6;
		}
		
		void btnRefHighDec_MouseUp(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			pressCount.Enabled = false;
		}
		
		private void Validate()
		{

			if (Globals.Tags.nozzleErrorLimit.Value.Double <= 0.01)
			{
				Globals.Tags.nozzleErrorLimit.Value = 0.01;
			}
			else if (Globals.Tags.nozzleErrorLimit.Value.Double >= 100.00)
			{
				Globals.Tags.nozzleErrorLimit.Value = 100.00;
			}

			
			if (Globals.Tags.nozzleReferenceFlowLow.Value.Double <= 0.01)
			{
				Globals.Tags.nozzleReferenceFlowLow.Value = 0.01;
			}
			else if (Globals.Tags.nozzleReferenceFlowLow.Value.Double >= Globals.Tags.LowRangeMax.Value.Double)
			{
				Globals.Tags.nozzleReferenceFlowLow.Value = Globals.Tags.LowRangeMax.Value.Double;
			}
			
			if (Globals.Tags.nozzleReferenceFlowMid.Value.Double <= Globals.Tags.MidRangeMin.Value.Double)
			{
				Globals.Tags.nozzleReferenceFlowMid.Value = Globals.Tags.MidRangeMin.Value.Double;
			}
			else if (Globals.Tags.nozzleReferenceFlowMid.Value.Double >= Globals.Tags.MidRangeMax.Value.Double)
			{
				Globals.Tags.nozzleReferenceFlowMid.Value = Globals.Tags.MidRangeMax.Value.Double;
			}
			
			if (Globals.Tags.nozzleReferenceFlowHigh.Value.Double <= Globals.Tags.HighRangeMin.Value.Double)
			{
				Globals.Tags.nozzleReferenceFlowHigh.Value = Globals.Tags.HighRangeMin.Value.Double;
			}
			else if (Globals.Tags.nozzleReferenceFlowHigh.Value.Double >= Globals.Tags.HighRangeMax.Value.Double)
			{
				Globals.Tags.nozzleReferenceFlowHigh.Value = Globals.Tags.HighRangeMax.Value.Double;
			}
			
			Globals.PersistentVariables.SaveRecipe("Current",false);
			
			Globals.Tags.nozzleErrorLimitDisplay.Value = Globals.Tags.nozzleErrorLimit.Value.Double.ToString("F2");
			
			Globals.Tags.nozzleReferenceFlowLowDisplay.Value = 	
				Globals.CalAndUpdate.ConvertNumberToStr(
				Globals.UnitsAndConversion.FlowConv(
				Globals.Tags.nozzleReferenceFlowLow.Value.Double,
				(int)Globals.Comm.FlowMeters[0].iMeterUnit,
				Globals.Tags.nozzleFlowUnit.Value.Int)
				, 
				Globals.UnitsAndConversion.GetFlowDecimal(0, Globals.Tags.nozzleFlowUnit.Value.Int)) + " " + Globals.UnitsAndConversion.GetFlowRateUnits(Globals.Tags.nozzleFlowUnit.Value.Int); 
			
			Globals.Tags.nozzleReferenceFlowMidDisplay.Value = 	
				Globals.CalAndUpdate.ConvertNumberToStr(
				Globals.UnitsAndConversion.FlowConv(
				Globals.Tags.nozzleReferenceFlowMid.Value.Double,
				(int)Globals.Comm.FlowMeters[1].iMeterUnit,
				Globals.Tags.nozzleFlowUnit.Value.Int)
				, 
				Globals.UnitsAndConversion.GetFlowDecimal(1, Globals.Tags.nozzleFlowUnit.Value.Int)) + " " + Globals.UnitsAndConversion.GetFlowRateUnits(Globals.Tags.nozzleFlowUnit.Value.Int); 
			
			Globals.Tags.nozzleReferenceFlowHighDisplay.Value = 	
				Globals.CalAndUpdate.ConvertNumberToStr(
				Globals.UnitsAndConversion.FlowConv(
				Globals.Tags.nozzleReferenceFlowHigh.Value.Double,
				(int)Globals.Comm.FlowMeters[2].iMeterUnit,
				Globals.Tags.nozzleFlowUnit.Value.Int)
				, 
				Globals.UnitsAndConversion.GetFlowDecimal(2, Globals.Tags.nozzleFlowUnit.Value.Int)) + " " + Globals.UnitsAndConversion.GetFlowRateUnits(Globals.Tags.nozzleFlowUnit.Value.Int); 
			
			
//			Globals.Tags.nozzleReferenceFlowLowDisplay.Value = Globals.Tags.nozzleReferenceFlowLow.Value.Double.ToString("F2") + " " + Globals.UnitsAndConversion.GetFlowRateUnits((int)Globals.Comm.FlowMeters[0].iMeterUnit);
			
//			Globals.Tags.nozzleReferenceFlowMidDisplay.Value = Globals.Tags.nozzleReferenceFlowMid.Value.Double.ToString("F2") + " " + Globals.UnitsAndConversion.GetFlowRateUnits((int)Globals.Comm.FlowMeters[1].iMeterUnit);
			
//			Globals.Tags.nozzleReferenceFlowHighDisplay.Value = Globals.Tags.nozzleReferenceFlowHigh.Value.Double.ToString("F2") + " " + Globals.UnitsAndConversion.GetFlowRateUnits((int)Globals.Comm.FlowMeters[2].iMeterUnit);
			
			

			
		}
		
		void btnErrorTypeNext_Click(System.Object sender, System.EventArgs e)
		{
			if (Globals.Tags.nozzleErrorType.Value.String == "%RDG")
			{
				Globals.Tags.nozzleErrorType.Value = "%FS";
			}
			else if (Globals.Tags.nozzleErrorType.Value.String == "%FS")
			{
				Globals.Tags.nozzleErrorType.Value = "%RDG";
			}
			else
			{
				Globals.Tags.nozzleErrorType.Value = "%FS";
			}
			
			Globals.PersistentVariables.SaveRecipe("Current",false);
		}
		
		void btnErrorTypePrev_Click(System.Object sender, System.EventArgs e)
		{
			if (Globals.Tags.nozzleErrorType.Value.String == "%RDG")
			{
				Globals.Tags.nozzleErrorType.Value = "%FS";
			}
			else if (Globals.Tags.nozzleErrorType.Value.String == "%FS")
			{
				Globals.Tags.nozzleErrorType.Value = "%RDG";
			}
			else
			{
				Globals.Tags.nozzleErrorType.Value = "%FS";
			}
			
			Globals.PersistentVariables.SaveRecipe("Current",false);
		}
		
		void Picture_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Globals.Tags.CalculatorTargetScr.Value = 0;
			Globals.Tags.Enter_Value.Value = Globals.UnitsAndConversion.FlowConv(
				Globals.Tags.nozzleReferenceFlowLow.Value.Double,
				(int)Globals.Comm.FlowMeters[0].iMeterUnit,
				Globals.Tags.nozzleFlowUnit.Value.Int);
			tmrCalculator.Enabled = true;
			request = 0;
			Globals.popCalculator.Show();
			
		}
		
		void Picture1_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Globals.Tags.CalculatorTargetScr.Value = 0;
			Globals.Tags.Enter_Value.Value = Globals.UnitsAndConversion.FlowConv(
				Globals.Tags.nozzleReferenceFlowMid.Value.Double,
				(int)Globals.Comm.FlowMeters[1].iMeterUnit,
				Globals.Tags.nozzleFlowUnit.Value.Int);
			tmrCalculator.Enabled = true;
			request = 1;
			Globals.popCalculator.Show();
		}
		
		void Picture2_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Globals.Tags.CalculatorTargetScr.Value = 0;
			Globals.Tags.Enter_Value.Value = Globals.UnitsAndConversion.FlowConv(
				Globals.Tags.nozzleReferenceFlowHigh.Value.Double,
				(int)Globals.Comm.FlowMeters[2].iMeterUnit,
				Globals.Tags.nozzleFlowUnit.Value.Int);
			tmrCalculator.Enabled = true;
			request = 2;
			Globals.popCalculator.Show();
		}
    }
}
