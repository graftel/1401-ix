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
	using System.Collections.Generic;
	using System.IO;
	using Neo.ApplicationFramework.Tools.MessageLibrary;
	using System.Reflection;
	using Neo.ApplicationFramework.Controls.Script;
	
    public partial class FlowRateDisplay
    {
		List<string> colTime;
		List<double> colInletPress;    //  unit psig
		List<double> colTestPress;	   //  unit psig
		List<double> colFlowRate;	   //  unit sccm
		List<string> colMeter;
		private string headerDate;
		private string headerGasType;
		private int pressUnit = 0;
		private int flowRateUnit = 0;
		private int pageIndex = 1;
		private int total_pages;
		private int currentStartIndex = 0;
		private int curFlowRateUnit = 0;
		void FlowRateDisplay_Opened(System.Object sender, System.EventArgs e)
		{
			colInletPress = new List<double>();
			colTestPress = new List<double>();
			colFlowRate = new List<double>();
			colTime = new List<string>();
			colMeter = new List<string>();
			
			if (File.Exists(Globals.Tags.LeakRateDataFileName.Value.String))
			{
				if (ReadLeakRateFile())
				{
					GenerateHeader();
					DisplayData(pageIndex);
				}
				else
				{
					Globals.Tags.GeneralMessage.Value = "Error reading file, please check on your USB drive!";
					Globals.GeneralMsgBox.Show();
				}
			}
			else
			{
				Globals.Tags.GeneralMessage.Value = "Cannot open file, please check on your USB drive!";
				Globals.GeneralMsgBox.Show();
			}
		}
		
		private void GenerateHeader()
		{
			// Generate Header
			
			if ((int)Globals.Tags.selMeter.Value == 0)
			{
				curFlowRateUnit = (int)Globals.Tags.flow_unit_low.Value;
			}
			else if ((int)Globals.Tags.selMeter.Value == 1)
			{
				curFlowRateUnit = (int)Globals.Tags.flow_unit_mid.Value;
			}
			
			Header2.Text = "Inlet P(" + Globals.TextLibrary.PressureUnit.Messages[(int)Globals.Tags.PressUnit.Value].Message + ")";
			Header3.Text = "Test P(" + Globals.TextLibrary.PressureUnit.Messages[(int)Globals.Tags.PressUnit.Value].Message + ")";
			Header4.Text = "Flow Rate(" + Globals.TextLibrary.FlowUnit.Messages[curFlowRateUnit].Message + ")";
			lblDate.Text = "Date: " + headerDate;
			lblGasType.Text = "Gas Type: " + headerGasType;
		}
		
		private void DisplayData(int currentPage)
		{
			int start_entry,end_entry, row;
		
			if (colTime.Count % 6 == 0)
			{
				total_pages = (colTime.Count / 6);
			}
			else
			{
				total_pages = (colTime.Count / 6) + 1;
			}
			
			if (currentPage > total_pages)
			{
				currentPage = total_pages;
			}
			
			for (int i = 0; i < 5; i++)
			{
				for (int j = 0; j < 6; j++)
				{
					TextControlCFAdapter currentTextBox = GetTextBox("m_lblData" + i.ToString() + j.ToString());
					currentTextBox.Text = "";
				}
			}
			
			if (colTime.Count == 0)	
			{
				btnPrev.IsEnabled = false;
				btnNext.IsEnabled = false;
				lblPage.Text = "Page 1/1";
				return;
			}
			
			lblPage.Text = "Page " + currentPage.ToString() + "/" + total_pages.ToString();
			
			if (currentPage == total_pages)
			{
				btnNext.IsEnabled = false;
			}
			else
			{
				btnNext.IsEnabled = true;
			}
			
			
			
			if (currentPage == 1) 
			{
				btnPrev.IsEnabled = false;
			}
			else
			{
				btnPrev.IsEnabled = true;
			}
			
			if (colTime.Count > 0)
			{
				start_entry = (currentPage - 1) * 6;
				currentStartIndex = start_entry;
				if (colTime.Count < start_entry + 6)
				{
					end_entry = colTime.Count;
				}
				else
				{
					end_entry = (currentPage) * 6;
				}
				
				row = 0;
				
				TextControlCFAdapter CurrentTxtBox;
				for (int i = start_entry; i < end_entry; i++)
				{
					CurrentTxtBox = GetTextBox("m_lblData0" + row.ToString()); 
					CurrentTxtBox.Text = colTime[i];
					
					CurrentTxtBox = GetTextBox("m_lblData1" + row.ToString()); 
					CurrentTxtBox.Text = colInletPress[i].ToString("F" + Globals.UnitsAndConversion.GetPressDecimal((int)Globals.Tags.PressUnit.Value).ToString());
					
					CurrentTxtBox = GetTextBox("m_lblData2" + row.ToString()); 
					CurrentTxtBox.Text = colTestPress[i].ToString("F" + Globals.UnitsAndConversion.GetPressDecimal((int)Globals.Tags.PressUnit.Value).ToString());
					
					
					
					if ((int)Globals.Tags.selMeter.Value == 0)
					{
						curFlowRateUnit = (int)Globals.Tags.flow_unit_low.Value;
					}
					else if ((int)Globals.Tags.selMeter.Value == 1)
					{
						curFlowRateUnit = (int)Globals.Tags.flow_unit_mid.Value;
					}
						
					
					CurrentTxtBox = GetTextBox("m_lblData3" + row.ToString()); 
					CurrentTxtBox.Text = colFlowRate[i].ToString("F" + Globals.UnitsAndConversion.GetFlowDecimal((int)Globals.Tags.selMeter.Value,curFlowRateUnit).ToString());
					
					CurrentTxtBox = GetTextBox("m_lblData4" + row.ToString()); 
					CurrentTxtBox.Text = colMeter[i];
					
					row++;			
				}
				
			}
			
			
		}
		
		private bool ReadLeakRateFile()
		{
			var reader = new StreamReader(File.OpenRead(Globals.Tags.LeakRateDataFileName.Value.String));

			int numRow = 0;
			bool GetDate = false;
			bool GetGas = false;
			
			while (!reader.EndOfStream)
			{
				var line = reader.ReadLine();
				string[] items = line.Split(',');
				
				if (items.Length == 8)
				{	
					if (numRow == 0)
					{
						if (!items[2].Contains("Gas Type"))
						{
							return false;
						}
					}	
					else if (numRow == 1)
					{
						if (items[3].Contains(Globals.TextLibrary.PressureUnit.Messages[0].Message))
						{
							pressUnit = 0;
						}
						else if (items[3].Contains(Globals.TextLibrary.PressureUnit.Messages[1].Message))
						{
							pressUnit = 1;
						}
						else if (items[3].Contains(Globals.TextLibrary.PressureUnit.Messages[2].Message))
						{
							pressUnit = 2;
						}
					}
					else if (numRow >= 2)
					{
						if (!GetDate)
						{
							headerDate = items[0];
							GetDate = true;
						}
						if (!GetGas)
						{
							headerGasType = items[2];
							GetGas = true;
						}
						
						colTime.Add(items[1]);
						
						double tmpInlet, tmpTest, tmpFlowRate;
						
						try
						{
							tmpInlet = Double.Parse(items[3]);
						}
						catch
						{
							tmpInlet = 0;
						}
						
						try
						{
							tmpTest = Double.Parse(items[4]);
						}
						catch
						{
							tmpTest = 0;
						}
						
						tmpInlet = Globals.UnitsAndConversion.PressConv(tmpInlet, pressUnit, (int)Globals.Tags.PressUnit.Value);					
						tmpTest = Globals.UnitsAndConversion.PressConv(tmpTest, pressUnit, (int)Globals.Tags.PressUnit.Value);					
						colInletPress.Add(tmpInlet);
						colTestPress.Add(tmpTest);
						
						colMeter.Add(items[5]);
						
						try
						{
							tmpFlowRate = Double.Parse(items[6]);
						}
						catch
						{
							tmpFlowRate = 0;
						}
						
						for (int i = 0; i < 4; i++)
						{
							if (items[7].Contains(Globals.TextLibrary.FlowUnit.Messages[i].Message))
							{
								flowRateUnit = i;
							}
						}
						
						if ((int)Globals.Tags.selMeter.Value == 0)
						{
							tmpFlowRate = Globals.UnitsAndConversion.FlowConv(tmpFlowRate, flowRateUnit, (int)Globals.Tags.flow_unit_low.Value);
						}
						else if ((int)Globals.Tags.selMeter.Value == 1)
						{
							tmpFlowRate = Globals.UnitsAndConversion.FlowConv(tmpFlowRate, flowRateUnit, (int)Globals.Tags.flow_unit_mid.Value);
						}
						else if ((int)Globals.Tags.selMeter.Value == 2)
						{
							tmpFlowRate = Globals.UnitsAndConversion.FlowConv(tmpFlowRate, flowRateUnit, (int)Globals.Tags.flow_unit_high.Value);
						}
						
						colFlowRate.Add(tmpFlowRate);
						
					}
				
				}
				
				numRow++;
			}
			
			return true;
		}
		
		public TextControlCFAdapter GetTextBox(string txtName){
			//Get the type of this screen
			Type FormType = this.GetType();
         
			//Get the field from the type
			FieldInfo field = FormType.GetField(txtName,BindingFlags.NonPublic | BindingFlags.Instance);
			if( field != null ){
             
				//Use the instance of this screen to get the instance of the field
				Neo.ApplicationFramework.Controls.Controls.Label lb;
				lb = (Neo.ApplicationFramework.Controls.Controls.Label) field.GetValue(this);
               
				//Cast the Label into a Text control. This code was pulled from the TQTERM_A7 function and can be
				//found in the cs file associated with this screen.
				TextControlCFAdapter myTxt;
				myTxt = this.AdapterService.CreateAdapter<Neo.ApplicationFramework.Controls.Script.TextControlCFAdapter>(lb);
				return myTxt;
			}
			return null;
		}
		
		void btnPrev_Click(System.Object sender, System.EventArgs e)
		{
			pageIndex--;
			DisplayData(pageIndex);
		}
		
		void btnNext_Click(System.Object sender, System.EventArgs e)
		{
			pageIndex++;
			DisplayData(pageIndex);
		}
		
    }
}
