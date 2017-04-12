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
    
    
	public partial class TrendAdvanced_T7A
	{
		
		int[] span_values = {30, 60, 300, 600, 1800, 3600};
		
		#region Y-Scale Buttons	
		
		//Zoom in trend Y-axis
		void btnZoomIn_Click(System.Object sender, System.EventArgs e)
		{
			double newYmax = Globals.Tags.GraphMax.Value - 5;
			double newYmin = Globals.Tags.GraphMin.Value + 5;
			if(newYmin < newYmax)
			{
				Globals.Tags.GraphMin.Value += 5;
				Globals.Tags.GraphMax.Value -= 5;
			}
		}
		
		//Zoom out trend Y-axis
		void btnZoomOut_Click(System.Object sender, System.EventArgs e)
		{
			if(Globals.Tags.GraphMax.Value < 200)
			{
				Globals.Tags.GraphMin.Value -= 5;
				Globals.Tags.GraphMax.Value += 5;
			}
		}
		
		//Pan down trend Y-axis
		void btnPanDown_Click(System.Object sender, System.EventArgs e)
		{
			if(Globals.Tags.GraphMin.Value > -100)
			{
				Globals.Tags.GraphMin.Value-=5;
				Globals.Tags.GraphMax.Value-=5;
			}
		}
		
		//Pan up trend Y-axis
		void btnPanUp_Click(System.Object sender, System.EventArgs e)
		{
			if(Globals.Tags.GraphMax.Value < 200)
			{
				Globals.Tags.GraphMin.Value+=5;
				Globals.Tags.GraphMax.Value+=5;
			}
		}
		
		//Restore trend Y-axis to default values
		void btnRestore_Click(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.GraphMin.Value = 0;
			Globals.Tags.GraphMax.Value = 100;
		}
		#endregion
		
		#region Time-Scale buttons
		
		//Set the trend in History Mode
		void btnPause_Click(System.Object sender, System.EventArgs e)
		{
			Trend1.ShowHistory("On");
			Globals.Tags.TrendButtonsEnabled.Value = true;
		}
		
		//Leave History Mode
		void btnPlay_Click(System.Object sender, System.EventArgs e)
		{
			Trend1.ShowHistory("Off");
			Globals.Tags.TrendButtonsEnabled.Value = false;
		}
		
		//Move to latest samples in trend database
		void btnLastSample_Click(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.Offset.Value = 0;
			Trend1.ShowHistory("Off");
			Trend1.ShowHistory("On");
		}
		
		//25% of time range backwards in time
		void btnBack25Percent_Click(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.Offset.Value += Globals.Tags.span.Value/4;
		}
		
		//100% of time range backwards in time
		void btnBack100Percent_Click(System.Object sender, System.EventArgs e)
		{
			double offset = Globals.Tags.span.Value;
			Globals.Tags.Offset.Value += offset;
		}
		
		//25% of time range forward in time
		void btnForward25Percent_Click(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.Offset.Value -= Globals.Tags.span.Value/4;
			if(Globals.Tags.Offset.Value < 0)
			{
				Globals.Tags.Offset.Value = 0;
			}
		}
		
		//100% of time range backwards in time
		void btnForward100Percent_Click(System.Object sender, System.EventArgs e)
		{
			double offset = Globals.Tags.span.Value;
			Globals.Tags.Offset.Value -= offset;
			if(Globals.Tags.Offset.Value < 0)
			{
				Globals.Tags.Offset.Value = 0;
			}
		}	 
		#endregion
			
		#region Legend button
		//Show trend legend
		void btnLegend_Click(System.Object sender, System.EventArgs e)
		{
			Trend1.ShowLegend(100,100);
		}		
		#endregion
		
		//Restore trend parameters/offset when leaving the screen
		
		void TrendAdvanced_T7A_Closed(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.TrendButtonsEnabled.Value = false;
			Globals.Tags.Offset.Value = 0;
			Globals.Tags.GraphMin.Value = 0;
			Globals.Tags.GraphMax.Value = 100;
		}
		
		void btnCancel_Click(System.Object sender, System.EventArgs e)
		{
			
		}
		
		void TrendAdvanced_T7A_Opened(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.Offset.Value = 0;
			
			if (Globals.Tags.span.Value == 0)
			{	
				Globals.Tags.span.Value = 300;
			}
		}
		
		void btnSwitchSpan_Click(System.Object sender, System.EventArgs e)
		{
			
			for (int i = 0; i < span_values.Length; i++)
			{
				if (Globals.Tags.span.Value == span_values[i])
				{
					if (i == span_values.Length - 1)
					{
						Globals.Tags.span.Value = span_values[0];
					}
					else
					{
						Globals.Tags.span.Value = span_values[i + 1];
					}
					
					break;
				}
			}
			
		}
	}
}