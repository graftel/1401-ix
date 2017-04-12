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
    
    
    public partial class CalAndUpdate
    {
		double err = 0;
		double temp_low, temp_mid, temp_high;
	//	double dStab = 0;
		public void UpdateFlowRateTag()
		{

			switch((int)Globals.Tags.selMeter.Value)
			{
				case 0:

					Globals.Tags.RawPrevFlowRateLow.Value = Globals.Tags.RawFlowRateLow.Value;
					Globals.Tags.RawFlowRateLow.Value = Globals.Comm.FlowMeters[0].GetFlowRate();
								
					if (Math.Abs(Globals.Tags.RawFlowRateLow.Value.Double) < Globals.Tags.LowRangeZeroBand.Value.Double * Globals.Tags.LowRangeMax.Value.Double / 100)
					{
						Globals.Tags.RawFlowRateLow.Value = 0;
					}

					err = System.Math.Abs((Globals.Tags.RawFlowRateLow.Value - Globals.Tags.RawPrevFlowRateLow.Value) * 100 / Globals.Tags.LowRangeMax.Value);
					if (err < Globals.Tags.FilterUpperLimitLow.Value)
					{
						temp_low = (10.0 - Globals.Tags.FilterResponseLow.Value) / 10.0 * Globals.Tags.RawFlowRateLow.Value + (Globals.Tags.FilterResponseLow.Value / 10.0) * Globals.Tags.RawPrevFlowRateLow.Value;
					}
					else
					{
						temp_low = Globals.Tags.RawFlowRateLow.Value;
					}
					if (Globals.Tags.bStabEnable.Value.Bool)
					{
					//	if (Globals.Tags.bStabEnableAlt.Value.Bool)
					//	{
							if (err >= 0 && err < Globals.Tags.Stab_low_green.Value)
							{
								Globals.Tags.iLinearMeterColor.Value = 0;
							}
							else if (err >= Globals.Tags.Stab_low_green.Value && err < Globals.Tags.Stab_low_orange.Value)
							{
								Globals.Tags.iLinearMeterColor.Value = 1;
							}
							else if (err >= Globals.Tags.Stab_low_orange.Value && err < Globals.Tags.Stab_low_red.Value)
							{
								Globals.Tags.iLinearMeterColor.Value = 2;
							}
							else if (err >= Globals.Tags.Stab_low_red.Value && err < 100)
							{
								Globals.Tags.iLinearMeterColor.Value = 3;
							}	
					//	}
					//	Globals.Tags.bStabEnableAlt.Value = !Globals.Tags.bStabEnableAlt.Value;
					}
					else
					{
						Globals.Tags.iLinearMeterColor.Value = 4;
					}
					
					if ((int)Globals.Tags.selMode.Value == 1 &&  Globals.Tags.RawFlowRateLow.Value.Double > Globals.Tags.LowRangeMax.Value.Double)
					{
						Globals.Tags.MainOverRangeEnable.Value = 1;	
						Globals.Tags.MainDisplayMeter.Value = 100;
						Globals.Tags.iLinearMeterColor.Value = 2;
						
					}
					else
					{
						
						Globals.Tags.MainDisplayMeter.Value = temp_low * 100 / Globals.Tags.LowRangeMax.Value.Double;

						Globals.Tags.MainOverRangeEnable.Value = 0;	
						Globals.Tags.MainFlowRateDisplay.Value = Globals.UnitsAndConversion.FlowConv(temp_low,(int)Globals.Tags.meter_unit_low.Value,(int)Globals.Tags.flow_unit_low.Value) 
							* Globals.UnitsAndConversion.GetGasCoeff((int)Globals.Tags.gasType.Value);

						if (Globals.Tags.MainFlowRateDisplay.Value.Double < 0)
						{
							Globals.Tags.BackFlowIndicator.Value = 1;
						}
						else
						{
							Globals.Tags.BackFlowIndicator.Value = 0;
						}
						
						
						
						Globals.Tags.MainFlowRateDecimal.Value = Globals.UnitsAndConversion.GetFlowDecimal(0,(int)Globals.Tags.flow_unit_low.Value);	
						
						
						if (Globals.Tags.MainFlowRateDecimal.Value.Int > 5)
						{
							Globals.Tags.longDecimal.Value = 1;
						}
						else
						{
							Globals.Tags.longDecimal.Value = 0;
						}
						
						
						Globals.Tags.MainFlowRateDisplayStr.Value = ConvertNumberToStr(Globals.Tags.MainFlowRateDisplay.Value.Double, Globals.Tags.MainFlowRateDecimal.Value.Int);
						
					}
					if ((int)Globals.Tags.MainUnderRangeEnable.Value == 1)
					{
						Globals.Tags.MainUnderRangeEnable.Value = 0;
					}

					if (Globals.Tags.BackFlowIndicator.Value.Int == 1)
					{
						if (Globals.Tags.MainDisplayBlink.Value.Int == 0)
						{
							Globals.Tags.MainDisplayBlink.Value = 1;
						}
					}
					else
					{
						if (Globals.Tags.MainDisplayBlink.Value.Int == 1)
						{
							Globals.Tags.MainDisplayBlink.Value = 0;
						}
					}
					break;
				case 1:
									
					Globals.Tags.RawPrevFlowRateMid.Value = Globals.Tags.RawFlowRateMid.Value;
					Globals.Tags.RawFlowRateMid.Value = Globals.Comm.FlowMeters[1].GetFlowRate();
					
					err = System.Math.Abs((Globals.Tags.RawFlowRateMid.Value - Globals.Tags.RawPrevFlowRateMid.Value) * 100 / Globals.Tags.MidRangeMax.Value);
					if (err < Globals.Tags.FilterUpperLimitMid.Value)
					{
						temp_mid = (10.0 - Globals.Tags.FilterResponseMid.Value) / 10.0 * Globals.Tags.RawFlowRateMid.Value + (Globals.Tags.FilterResponseMid.Value / 10.0) * Globals.Tags.RawPrevFlowRateMid.Value;
					}
					else
					{
						temp_mid = Globals.Tags.RawFlowRateMid.Value;
					}
					if (Globals.Tags.bStabEnable.Value.Bool)
					{
						//if (Globals.Tags.bStabEnableAlt.Value.Bool)
						//{
							if (err >= 0 && err < Globals.Tags.Stab_mid_green.Value)
							{
								Globals.Tags.iLinearMeterColor.Value = 0;
							}
							else if (err >= Globals.Tags.Stab_mid_green.Value && err < Globals.Tags.Stab_mid_orange.Value)
							{
								Globals.Tags.iLinearMeterColor.Value = 1;
							}
							else if (err >= Globals.Tags.Stab_mid_orange.Value && err < Globals.Tags.Stab_mid_red.Value)
							{
								Globals.Tags.iLinearMeterColor.Value = 2;
							}
							else if (err >= Globals.Tags.Stab_mid_red.Value && err < 100)
							{
								Globals.Tags.iLinearMeterColor.Value = 3;
							}
							
						//}
						//Globals.Tags.bStabEnableAlt.Value = !Globals.Tags.bStabEnableAlt.Value;
					}
					else
					{
						Globals.Tags.iLinearMeterColor.Value = 4;
					}
					
					if (Globals.Tags.RawFlowRateMid.Value.Double > Globals.Tags.MidRangeMax.Value.Double)
					{
						Globals.Tags.MainOverRangeEnable.Value = 1;	
						Globals.Tags.MainUnderRangeEnable.Value = 0;
						Globals.Tags.MainDisplayMeter.Value = 100;
						Globals.Tags.iLinearMeterColor.Value = 2;
					}
					else 
					{
						if (temp_mid < Globals.Tags.MidRangeMin.Value && temp_mid >= 0 && Globals.Tags.selMode.Value.Int != 0)
						{
							Globals.Tags.MainOverRangeEnable.Value = 0;	
							Globals.Tags.MainUnderRangeEnable.Value = 1;
						}
						else
						{
							Globals.Tags.MainUnderRangeEnable.Value = 0;
						}
						
						Globals.Tags.MainDisplayMeter.Value = (temp_mid - Globals.Tags.MidRangeMin.Value.Double) * 100 / (Globals.Tags.MidRangeMax.Value.Double - Globals.Tags.MidRangeMin.Value.Double);
						Globals.Tags.MainOverRangeEnable.Value = 0;	
						Globals.Tags.MainFlowRateDisplay.Value = Globals.UnitsAndConversion.FlowConv(temp_mid,(int)Globals.Tags.meter_unit_mid.Value,(int)Globals.Tags.flow_unit_mid.Value) 
							* Globals.UnitsAndConversion.GetGasCoeff((int)Globals.Tags.gasType.Value);
					

						if (Globals.Tags.MainFlowRateDisplay.Value.Double < 0)
						{
							Globals.Tags.BackFlowIndicator.Value = 1;
						}
						else
						{
							Globals.Tags.BackFlowIndicator.Value = 0;
						}
						
						Globals.Tags.MainFlowRateDecimal.Value = Globals.UnitsAndConversion.GetFlowDecimal(1,Globals.Tags.flow_unit_mid.Value.Int);
						
						if (Globals.Tags.MainFlowRateDecimal.Value.Int > 5)
						{
							Globals.Tags.longDecimal.Value = 1;
						}
						else
						{
							Globals.Tags.longDecimal.Value = 0;
						}
						
						
						Globals.Tags.MainFlowRateDisplayStr.Value = ConvertNumberToStr(Globals.Tags.MainFlowRateDisplay.Value.Double, Globals.Tags.MainFlowRateDecimal.Value.Int);

						
					}
					
					
					if (Globals.Tags.BackFlowIndicator.Value.Int == 1 || Globals.Tags.MainUnderRangeEnable.Value.Int == 1)
					{
						if (Globals.Tags.MainDisplayBlink.Value.Int == 0)
						{
							Globals.Tags.MainDisplayBlink.Value = 1;
						}
					}
					else
					{
						if (Globals.Tags.MainDisplayBlink.Value.Int == 1)
						{
							Globals.Tags.MainDisplayBlink.Value = 0;
						}
					}
					break;
				case 2:
									
					Globals.Tags.RawPrevFlowRateHigh.Value = Globals.Tags.RawFlowRateHigh.Value;
					Globals.Tags.RawFlowRateHigh.Value = Globals.Comm.FlowMeters[2].GetFlowRate();
					
					err = System.Math.Abs((Globals.Tags.RawFlowRateHigh.Value - Globals.Tags.RawPrevFlowRateHigh.Value) * 100 / Globals.Tags.HighRangeMax.Value);
					if (err < Globals.Tags.FilterUpperLimitHigh.Value)
					{
						temp_high = (10.0 - Globals.Tags.FilterResponseHigh.Value) / 10.0 * Globals.Tags.RawFlowRateHigh.Value + (Globals.Tags.FilterResponseHigh.Value / 10.0) * Globals.Tags.RawPrevFlowRateHigh.Value;
					}
					else
					{
						temp_high = Globals.Tags.RawFlowRateHigh.Value;
					}
					if (Globals.Tags.bStabEnable.Value.Bool)
					{
						//if (Globals.Tags.bStabEnableAlt.Value.Bool)
						//{
						if (err >= 0 && err < Globals.Tags.Stab_high_green.Value)
						{
							Globals.Tags.iLinearMeterColor.Value = 0;
						}
						else if (err >= Globals.Tags.Stab_high_green.Value && err < Globals.Tags.Stab_high_orange.Value)
						{
							Globals.Tags.iLinearMeterColor.Value = 1;
						}
						else if (err >= Globals.Tags.Stab_high_orange.Value && err < Globals.Tags.Stab_high_red.Value)
						{
							Globals.Tags.iLinearMeterColor.Value = 2;
						}
						else if (err >= Globals.Tags.Stab_high_red.Value && err < 100)
						{
							Globals.Tags.iLinearMeterColor.Value = 3;
						}
							
						//}
						//Globals.Tags.bStabEnableAlt.Value = !Globals.Tags.bStabEnableAlt.Value;
					}
					else
					{
						Globals.Tags.iLinearMeterColor.Value = 4;
					}
					
					if (Globals.Tags.RawFlowRateHigh.Value.Double > Globals.Tags.HighRangeMax.Value.Double)
					{
						Globals.Tags.MainOverRangeEnable.Value = 1;	
						Globals.Tags.MainUnderRangeEnable.Value = 0;
						Globals.Tags.MainDisplayMeter.Value = 100;
						Globals.Tags.iLinearMeterColor.Value = 2;
					}
					else 
					{
						if (temp_high < Globals.Tags.HighRangeMin.Value && temp_high >= 0 && Globals.Tags.selMode.Value.Int != 0)
						{
							Globals.Tags.MainOverRangeEnable.Value = 0;	
							Globals.Tags.MainUnderRangeEnable.Value = 1;
						}
						else
						{
							Globals.Tags.MainUnderRangeEnable.Value = 0;
						}
						
						Globals.Tags.MainDisplayMeter.Value = (temp_high - Globals.Tags.HighRangeMin.Value.Double) * 100 / (Globals.Tags.HighRangeMax.Value.Double - Globals.Tags.HighRangeMin.Value.Double);
						Globals.Tags.MainOverRangeEnable.Value = 0;	
						Globals.Tags.MainFlowRateDisplay.Value = Globals.UnitsAndConversion.FlowConv(temp_high,(int)Globals.Tags.meter_unit_high.Value,(int)Globals.Tags.flow_unit_high.Value) 
							* Globals.UnitsAndConversion.GetGasCoeff((int)Globals.Tags.gasType.Value);
					

						if (Globals.Tags.MainFlowRateDisplay.Value.Double < 0)
						{
							Globals.Tags.BackFlowIndicator.Value = 1;
						}
						else
						{
							Globals.Tags.BackFlowIndicator.Value = 0;
						}
						
						Globals.Tags.MainFlowRateDecimal.Value = Globals.UnitsAndConversion.GetFlowDecimal(2,Globals.Tags.flow_unit_high.Value.Int);
						
						if (Globals.Tags.MainFlowRateDecimal.Value.Int > 5)
						{
							Globals.Tags.longDecimal.Value = 1;
						}
						else
						{
							Globals.Tags.longDecimal.Value = 0;
						}
						
						Globals.Tags.MainFlowRateDisplayStr.Value = ConvertNumberToStr(Globals.Tags.MainFlowRateDisplay.Value.Double, Globals.Tags.MainFlowRateDecimal.Value.Int);

					}
					
					
					if (Globals.Tags.BackFlowIndicator.Value.Int == 1 || Globals.Tags.MainUnderRangeEnable.Value.Int == 1)
					{
						if (Globals.Tags.MainDisplayBlink.Value.Int == 0)
						{
							Globals.Tags.MainDisplayBlink.Value = 1;
						}
					}
					else
					{
						if (Globals.Tags.MainDisplayBlink.Value.Int == 1)
						{
							Globals.Tags.MainDisplayBlink.Value = 0;
						}
					}
					break;
				}
			

		}
		public void UpdateTestPressureTag()
		{
			
			Globals.Tags.RawTestPressure.Value = Globals.Comm.PressSensors[1].GetPress();
			
			if (Math.Abs(Globals.Tags.RawTestPressure.Value.Double) < Globals.Tags.TestPressZeroBand.Value.Double * Globals.Tags.Test_Press_Max.Value.Double / 100)
			{
				Globals.Tags.RawTestPressure.Value = 0;
			}
			
			Globals.Tags.MainPressDisplay.Value = Globals.UnitsAndConversion.PressConv(Globals.Tags.RawTestPressure.Value.Double,(int)Globals.Tags.press_meter_unit.Value,(int)Globals.Tags.PressUnit.Value);
			Globals.Tags.MainTestPressDisplay.Value  = Globals.UnitsAndConversion.PressConv(Globals.Tags.RawTestPressure.Value.Double,(int)Globals.Tags.press_meter_unit.Value,(int)Globals.Tags.PressUnit.Value);

			switch (Globals.Tags.PressUnit.Value.Int)
			{
				case 0:
					Globals.Tags.MainPressDecimal.Value = Globals.Tags.psigDecimal.Value;
					break;
				case 1:
					Globals.Tags.MainPressDecimal.Value = Globals.Tags.ksiDecimal.Value;
					break;
				case 2:
					Globals.Tags.MainPressDecimal.Value = Globals.Tags.barDecimal.Value;
					break;
			}

			if (Globals.Tags.MainPressDisplay.Value.Double < 0)
			{
				Globals.Tags.IsNegativePress.Value = 1;
			}
			else
			{
				Globals.Tags.IsNegativePress.Value = 0;
			}

			if (Globals.Tags.RawTestPressure.Value.Double >  Globals.Tags.Test_Press_Max.Value.Double)
			{
				Globals.Tags.MainDisplayMessage.Value = 20;	
			}

			Globals.Tags.PressReadingFull.Value = Globals.Tags.MainPressDisplay.Value.Double.ToString("F" + Globals.Tags.MainPressDecimal.Value.Int.ToString()) + " " + Globals.UnitsAndConversion.GetPressureUnits(Globals.Tags.PressUnit.Value.Int);
			
			Globals.Tags.MainPressDisplayStr.Value = ConvertNumberToStr(Globals.Tags.MainPressDisplay.Value.Double, Globals.Tags.MainPressDecimal.Value.Int);
		}
		
		public void UpdateInletPressureTag()
		{
			Globals.Tags.RawInletPressure.Value = Globals.Comm.PressSensors[0].GetPress();
			
			Globals.Tags.MainInletPressDisplay.Value  = Globals.UnitsAndConversion.PressConv(Globals.Tags.RawInletPressure.Value.Double,(int)Globals.Tags.PressUnitTest.Value,(int)Globals.Tags.PressUnit.Value);
			if (Math.Abs(Globals.Tags.RawInletPressure.Value.Double) < Globals.Tags.InletPressZeroBand.Value.Double * Globals.Tags.Inlet_Press_Max.Value.Double / 100)
			{
				Globals.Tags.RawInletPressure.Value = 0;
			}
			if (Globals.Tags.InletPressIndicator.Value == 1)
			{
				Globals.Tags.MainPressDisplay.Value = Globals.UnitsAndConversion.PressConv(Globals.Tags.RawInletPressure.Value.Double,(int)Globals.Tags.PressUnitInlet.Value,(int)Globals.Tags.PressUnit.Value);
				
				Globals.Tags.MainPressDisplayStr.Value = ConvertNumberToStr(Globals.Tags.MainPressDisplay.Value.Double, Globals.Tags.MainPressDecimal.Value.Int);
			}

			if (Globals.Tags.RawInletPressure.Value.Double > Globals.Tags.Inlet_Press_Max.Value.Double)
			{
				Globals.Tags.MainDisplayMessage.Value = 19;	
			}
		}
		
		
		public string ConvertNumberToStr(double input_value, int decimal_places)
		{
			string out_str;
			
	//		if (decimal_places <= 5)
	//		{
	//			out_str = input_value.ToString("F" + decimal_places.ToString());
	//		}
	//		else
	//		{
	//			out_str = input_value.ToString("0.000E+0");
	//		}
			
			out_str = input_value.ToString("F" + decimal_places.ToString());
			
			return out_str;
		}
    }
}
