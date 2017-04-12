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
    
    
    public partial class DisplayBacklight
    {
		
		void DisplayBacklight_Opened(System.Object sender, System.EventArgs e)
		{
			if ((int)Globals.Tags.ScreenSaver.Value == 1)
			{
				CheckBox.Checked = true;
			}
			else
			{
				CheckBox.Checked = false;
			}
		}
		
		void CheckBox_Click(System.Object sender, System.EventArgs e)
		{
			if (CheckBox.Checked)
			{
				Globals.Tags.ScreenSaver.Value = 1;
				Core.Api.Service.ServiceContainerCF.GetService<Neo.ApplicationFramework.Interfaces.IBacklightService>().SetBacklightTimout(Globals.Tags.ScreenSaverTimeout.Value.Int * 60);
				Core.Api.Service.ServiceContainerCF.GetService<Neo.ApplicationFramework.Interfaces.IBacklightService>().SetAutomaticallyTurnOfBacklight(true);
			}
			else
			{
				Core.Api.Service.ServiceContainerCF.GetService<Neo.ApplicationFramework.Interfaces.IBacklightService>().TurnBacklightOn();
				Core.Api.Service.ServiceContainerCF.GetService<Neo.ApplicationFramework.Interfaces.IBacklightService>().SetAutomaticallyTurnOfBacklight(false);
				Globals.Tags.ScreenSaver.Value = 0;
			}
		}
		
		void DisplayBacklight_Closed(System.Object sender, System.EventArgs e)
		{
			Globals.PersistentVariables.SaveRecipe("Current",false);
		}
		
		void Button4_Click(System.Object sender, System.EventArgs e)
		{
			if ((int)Globals.Tags.ScreenSaverTimeout.Value > 1)
			{
				Globals.Tags.ScreenSaverTimeout.Value = (int)Globals.Tags.ScreenSaverTimeout.Value - 1;
				Core.Api.Service.ServiceContainerCF.GetService<Neo.ApplicationFramework.Interfaces.IBacklightService>().SetBacklightTimout(Globals.Tags.ScreenSaverTimeout.Value.Int * 60);
			}
		}
		
		void Button3_Click(System.Object sender, System.EventArgs e)
		{
			if ((int)Globals.Tags.ScreenSaverTimeout.Value < 10000)
			{
				Globals.Tags.ScreenSaverTimeout.Value = (int)Globals.Tags.ScreenSaverTimeout.Value + 1;
				Core.Api.Service.ServiceContainerCF.GetService<Neo.ApplicationFramework.Interfaces.IBacklightService>().SetBacklightTimout(Globals.Tags.ScreenSaverTimeout.Value.Int * 60);
			}
		}
		
		void AnalogNumeric1_ValueChanged(System.Object sender, Neo.ApplicationFramework.Interfaces.Events.ValueChangedEventArgs e)
		{
			Core.Api.Service.ServiceContainerCF.GetService<Neo.ApplicationFramework.Interfaces.IBacklightService>().SetBacklightTimout(Globals.Tags.ScreenSaverTimeout.Value.Int * 60);
		}
	
    }
}
