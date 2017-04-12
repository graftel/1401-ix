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
	
    
    public partial class UnitsAndConversion
    {
		string[] FlowRateUnits = {"sccm","slpm","scfm","scfh","slph"};

		string[] VolFlowRateUnits = {"ccm","lpm","cfm","cfh","lph"};		

		string[] PressureUnits = {"psig","ksi","bar"};
		
		string[] ModeNames = {"AUTO","LOW", "MID", "HIGH"};
		
		string[] GasTypeStr = {"AIR","NITROGEN"};
		
		double[] FlowConvArr = {1.0, 0.001,0.000035315,0.00211888,0.06};		
		
		double[] PressConvArr = {1.0, 0.001, 0.068947573};
		
		double[] GasConv = {1.0, 1.0382};

		public string GetGasTypeStr()
		{
			return GasTypeStr[Globals.Tags.gasType.Value.Int];
		}

		public string GetFlowRateUnits(int selected)
		{
			return FlowRateUnits[selected];
		}

		public string GetVolFlowRateUnits(int selected)
		{
			return VolFlowRateUnits[selected];
		}
		
		public int GetSelectedFlowRateUnit(int meter)
		{
			switch (meter)
			{
				case 0:
					return Globals.Tags.flow_unit_low.Value.Int;
				case 1:
					return Globals.Tags.flow_unit_mid.Value.Int;
				case 2:
					return Globals.Tags.flow_unit_high.Value.Int;
				default:
					return 0;
			}
		}
		
		public int GetFlowDecimal(int selMeter, int selUnit)
		{
			if (selMeter == 0)
			{
				if (selUnit == 0)
				{	
					return (int)Globals.Tags.LowsccmDecimal.Value;
				}
				else if (selUnit == 1)
				{
					return (int)Globals.Tags.LowslpmDecimal.Value;
				}
				else if (selUnit == 2)
				{
					return (int)Globals.Tags.LowscfmDecimal.Value;
				}
				else if (selUnit == 3)
				{
					return (int)Globals.Tags.LowscfhDecimal.Value;
				}
				else
				{
					return 1;
				}
			}
			else if (selMeter == 1)
			{
				if (selUnit == 0)
				{	
					return (int)Globals.Tags.MidsccmDecimal.Value;
				}
				else if (selUnit == 1)
				{
					return (int)Globals.Tags.MidslpmDecimal.Value;
				}
				else if (selUnit == 2)
				{
					return (int)Globals.Tags.MidscfmDecimal.Value;
				}
				else if (selUnit == 3)
				{
					return (int)Globals.Tags.MidscfhDecimal.Value;
				}
				else
				{
					return 1;
				}
			
			}
			else if (selMeter == 2)
			{
				if (selUnit == 0)
				{	
					return (int)Globals.Tags.HighsccmDecimal.Value;
				}
				else if (selUnit == 1)
				{
					return (int)Globals.Tags.HighslpmDecimal.Value;
				}
				else if (selUnit == 2)
				{
					return (int)Globals.Tags.HighscfmDecimal.Value;
				}
				else if (selUnit == 3)
				{
					return (int)Globals.Tags.HighscfhDecimal.Value;
				}
				else
				{
					return 1;
				}
			}
			else
			{
				return 1;
			}
		}
		
		public int GetFlowMaxDecimal(int selMeter, int selUnit)
		{
			if (selMeter == 0)
			{
				if (selUnit == 0)
				{	
					return Globals.Tags.MAX_LOW_SCCM_DECIMAL.Value.Int;
				}
				else if (selUnit == 1)
				{
					return Globals.Tags.MAX_LOW_SLPM_DECIMAL.Value.Int;
				}
				else if (selUnit == 2)
				{
					return Globals.Tags.MAX_LOW_SCFM_DECIMAL.Value.Int;
				}
				else if (selUnit == 3)
				{
					return Globals.Tags.MAX_LOW_SCFH_DECIMAL.Value.Int;
				}
				else
				{
					return 1;
				}
			}
			else if (selMeter == 1)
			{
				if (selUnit == 0)
				{	
					return Globals.Tags.MAX_MID_SCCM_DECIMAL.Value.Int;
				}
				else if (selUnit == 1)
				{
					return Globals.Tags.MAX_MID_SLPM_DECIMAL.Value.Int;
				}
				else if (selUnit == 2)
				{
					return Globals.Tags.MAX_MID_SCFM_DECIMAL.Value.Int;
				}
				else if (selUnit == 3)
				{
					return Globals.Tags.MAX_MID_SCFH_DECIMAL.Value.Int;
				}
				else
				{
					return 1;
				}
			
			}
			else if (selMeter == 2)
			{
				if (selUnit == 0)
				{	
					return Globals.Tags.MAX_HI_SCCM_DECIMAL.Value.Int;
				}
				else if (selUnit == 1)
				{
					return Globals.Tags.MAX_HI_SLPM_DECIMAL.Value.Int;
				}
				else if (selUnit == 2)
				{
					return Globals.Tags.MAX_HI_SCFM_DECIMAL.Value.Int;
				}
				else if (selUnit == 3)
				{
					return Globals.Tags.MAX_HI_SCFH_DECIMAL.Value.Int;
				}
				else
				{
					return 1;
				}
			
			}
			else
			{
				return 1;
			}
		}
		
		public double GetGasCoeff(int selectedGas)
		{
			return GasConv[selectedGas];
		}
		
		public int GetPressDecimal(int selected)
		{
			if (selected == 0)
			{
				return (int)Globals.Tags.psigDecimal.Value;
			}
			else if (selected == 1)
			{
				return (int)Globals.Tags.ksiDecimal.Value;
			}
			else if (selected == 2)
			{
				return (int)Globals.Tags.barDecimal.Value;
			}
			else
			{
				return 0;
			}
		}
		
		public int GetPressMaxDecimal(int selected)
		{
			if (selected == 0)
			{
				return Globals.Tags.MAX_PSIG_DECIMAL.Value.Int;
			}
			else if (selected == 1)
			{
				return Globals.Tags.MAX_KSI_DECIMAL.Value.Int;
			}
			else if (selected == 2)
			{
				return Globals.Tags.MAX_BAR_DECIMAL.Value.Int;
			}
			else
			{
				return 2;
			}
		}

		public string GetPressureUnits(int selected)
		{
			return PressureUnits[selected];
		}
		
		public double FlowConv(double inputValue,int unitIn, int unitOut)
		{	
			double convFactor = FlowConvArr[unitOut]/FlowConvArr[unitIn];
			
			return inputValue * convFactor;
		}
		
		public double PressConv(double inputValue,int unitIn, int unitOut)
		{	
			double convFactor = PressConvArr[unitOut]/PressConvArr[unitIn];
			
			return inputValue * convFactor;
		}
		public string GetModeName(int selMode)
		{
			return ModeNames[selMode];
		}
    }
}
