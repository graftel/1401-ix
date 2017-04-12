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
    
    
    public partial class DrawScreen
    {
		int[] default_meter_units = new int[3];
		double[] MinFlow = new double[3];
		double[] MaxFlow = new double[3];
		int selFlowUnit;
		int decimal_place;
		
		public void DrawMainScreen(int selMeter)
		{
			
			default_meter_units[0] = (int)Globals.Tags.meter_unit_low.Value;
			default_meter_units[1] = (int)Globals.Tags.meter_unit_mid.Value;
			default_meter_units[2] = (int)Globals.Tags.meter_unit_high.Value;
			MinFlow[0] = Globals.Tags.LowRangeMin.Value;
			MinFlow[1] = Globals.Tags.MidRangeMin.Value;
			MinFlow[2] = Globals.Tags.HighRangeMin.Value;
			MaxFlow[0] = Globals.Tags.LowRangeMax.Value;
			MaxFlow[1] = Globals.Tags.MidRangeMax.Value;
			MaxFlow[2] = Globals.Tags.HighRangeMax.Value;
		
			
			switch(selMeter)
			{
				case 0:
					selFlowUnit = (int)Globals.Tags.flow_unit_low.Value;
					Globals.Tags.Main_Screen_Title.Value = Globals.UnitsAndConversion.GetModeName(selMeter + 1) + " Range - ";
					decimal_place = Globals.UnitsAndConversion.GetFlowDecimal(selMeter,selFlowUnit);
					
					if (decimal_place > 4)
					{
						decimal_place = 4;
					}
					//Globals.Tags.MainDisplayScale1.Value = Globals.UnitsAndConversion.FlowConv(Globals.Tags.LowRangeMin.Value.Double,Globals.Tags.meter_unit_low.Value.Int,selFlowUnit).ToString("F" + Globals.UnitsAndConversion.GetFlowDecimal(selMeter,selFlowUnit).ToString());
					Globals.Tags.MainDisplayScale1.Value = "0";
					Globals.Tags.MainDisplayScale2.Value = Globals.UnitsAndConversion.FlowConv(((Globals.Tags.LowRangeMin.Value.Double + Globals.Tags.LowRangeMax.Value.Double)/2),Globals.Tags.meter_unit_low.Value.Int,selFlowUnit).ToString("F" + decimal_place.ToString());
					Globals.Tags.MainDisplayScale3.Value = Globals.UnitsAndConversion.FlowConv(Globals.Tags.LowRangeMax.Value.Double,Globals.Tags.meter_unit_low.Value.Int,selFlowUnit).ToString("F" + decimal_place.ToString());
					break;
				case 1:
					selFlowUnit = (int)Globals.Tags.flow_unit_mid.Value;
					Globals.Tags.Main_Screen_Title.Value = Globals.UnitsAndConversion.GetModeName(selMeter + 1) + " Range - ";

					decimal_place = Globals.UnitsAndConversion.GetFlowDecimal(selMeter,selFlowUnit);
					
					if (decimal_place > 4)
					{
						decimal_place = 4;
					}
					
					Globals.Tags.MainDisplayScale1.Value = Globals.UnitsAndConversion.FlowConv(Globals.Tags.MidRangeMin.Value.Double,Globals.Tags.meter_unit_mid.Value.Int,selFlowUnit).ToString("F" + decimal_place.ToString());
					Globals.Tags.MainDisplayScale2.Value = Globals.UnitsAndConversion.FlowConv(((Globals.Tags.MidRangeMin.Value.Double + Globals.Tags.MidRangeMax.Value.Double)/2),Globals.Tags.meter_unit_mid.Value.Int,selFlowUnit).ToString("F" + decimal_place.ToString());
					Globals.Tags.MainDisplayScale3.Value = Globals.UnitsAndConversion.FlowConv(Globals.Tags.MidRangeMax.Value.Double,Globals.Tags.meter_unit_mid.Value.Int,selFlowUnit).ToString("F" + decimal_place.ToString());
					break;
				case 2:
					selFlowUnit = (int)Globals.Tags.flow_unit_high.Value;
					Globals.Tags.Main_Screen_Title.Value = Globals.UnitsAndConversion.GetModeName(selMeter + 1) + " Range - ";

					decimal_place = Globals.UnitsAndConversion.GetFlowDecimal(selMeter,selFlowUnit);
					
					if (decimal_place > 4)
					{
						decimal_place = 4;
					}
					
					Globals.Tags.MainDisplayScale1.Value = Globals.UnitsAndConversion.FlowConv(Globals.Tags.HighRangeMin.Value.Double,Globals.Tags.meter_unit_high.Value.Int,selFlowUnit).ToString("F" + decimal_place.ToString());
					Globals.Tags.MainDisplayScale2.Value = Globals.UnitsAndConversion.FlowConv(((Globals.Tags.HighRangeMin.Value.Double + Globals.Tags.HighRangeMax.Value.Double)/2),Globals.Tags.meter_unit_high.Value.Int,selFlowUnit).ToString("F" + decimal_place.ToString());
					Globals.Tags.MainDisplayScale3.Value = Globals.UnitsAndConversion.FlowConv(Globals.Tags.HighRangeMax.Value.Double,Globals.Tags.meter_unit_high.Value.Int,selFlowUnit).ToString("F" + decimal_place.ToString());
				
					break;
			}
			string minFormat;
			
			if (selMeter == 0)
			{
				minFormat = "F0";
			}
			else
			{
				minFormat = "F" + Globals.UnitsAndConversion.GetFlowDecimal(selMeter,selFlowUnit).ToString();	
			}

			if (Globals.Tags.MainDisplayScale3.Value.String.Length > 7)
			{
				Globals.Tags.MainScaleLongSize.Value = 1;
			}
			else
			{
				Globals.Tags.MainScaleLongSize.Value = 0;
			}
			

			Globals.Tags.MainFlowRateDecimal.Value = Globals.UnitsAndConversion.GetFlowDecimal(selMeter,selFlowUnit);
			Globals.Tags.MainFlowUnitBtn.Value = Globals.UnitsAndConversion.GetFlowRateUnits(selFlowUnit);
			Globals.Tags.Main_Screen_Title.Value = Globals.Tags.Main_Screen_Title.Value + "FROM " + Globals.UnitsAndConversion.FlowConv(MinFlow[selMeter],default_meter_units[selMeter],selFlowUnit).ToString(minFormat) + " TO " + Globals.UnitsAndConversion.FlowConv(MaxFlow[selMeter],default_meter_units[selMeter],selFlowUnit).ToString("F" + Globals.UnitsAndConversion.GetFlowDecimal(selMeter,selFlowUnit).ToString()) + " " + Globals.UnitsAndConversion.GetFlowRateUnits(selFlowUnit);
			
			Globals.Tags.MainRangeMinDisplay.Value = Globals.UnitsAndConversion.FlowConv(MinFlow[selMeter],default_meter_units[selMeter],selFlowUnit);
			Globals.Tags.MainRangeMaxDisplay.Value = Globals.UnitsAndConversion.FlowConv(MaxFlow[selMeter],default_meter_units[selMeter],selFlowUnit);

		}


    }
}
