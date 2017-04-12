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
    
    public partial class SelectData
    {
		public List<string> text_input = null;
		public List<string> file_path = null;
		public List<int> file_type = null;
		private int total_pages;
		private int currentPage = 1;
		private int currentStartIndex = 0;
		
		
		void SelectData_Opened(System.Object sender, System.EventArgs e)
		{	
			Globals.Tags.listSelected.Value = 0;
			text_input = new List<string>();
			file_path = new List<string>();
			file_type = new List<int>();
			
			if (File.Exists("\\FlashDrive\\Project\\Project Files\\Recordings\\Rrcd_Index.csv"))
			{
				var reader = new StreamReader(File.OpenRead("\\FlashDrive\\Project\\Project Files\\Recordings\\Rrcd_Index.csv"));
				while (!reader.EndOfStream)
				{
					var line = reader.ReadLine();
					string[] strTmp = line.Split(',');
				
					if (strTmp.Length == 3)
					{
						file_path.Add(strTmp[0]);
						text_input.Add("Start Time: " + strTmp[1] + " Duration: " + strTmp[2]);
					}
				}
			}
		
			DisplayItems(currentPage);
		}
		
		void DisplayItems(int currentPageNum)
		{
			int start_entry,end_entry,count;
		

			
			if (text_input.Count % 7 == 0)
			{
				total_pages = (text_input.Count / 7);
			}
			else
			{
				total_pages = (text_input.Count / 7) + 1;
			}
			
			if (currentPageNum > total_pages)
			{
				currentPageNum = total_pages;
			}
			
			tbName1.Text = "";
			tbName2.Text = "";
			tbName3.Text = "";
			tbName4.Text = "";
			tbName5.Text = "";
			tbName6.Text = "";
			tbName7.Text = "";
			
			tbName1.Visible = false;
			tbName2.Visible = false;
			tbName3.Visible = false;
			tbName4.Visible = false;
			tbName5.Visible = false;
			tbName6.Visible = false;
			tbName7.Visible = false;
			
			if (text_input.Count == 0)	
			{
				btnPrev.IsEnabled = false;
				btnNext.IsEnabled = false;
				lblPage.Text = "Page 1/1";
				return;
			}
			
			lblPage.Text = "Page " + currentPageNum.ToString() + "/" + total_pages.ToString();
			
			if (currentPageNum == total_pages)
			{
				btnNext.IsEnabled = false;
			}
			else
			{
				btnNext.IsEnabled = true;
			}
			
			
			
			if (currentPageNum == 1) 
			{
				btnPrev.IsEnabled = false;
			}
			else
			{
				btnPrev.IsEnabled = true;
			}
			
			
			
			if (text_input.Count > 0)
			{
				start_entry = (currentPageNum - 1) * 7;
				currentStartIndex = start_entry;
				if (text_input.Count < start_entry + 7)
				{
					end_entry = text_input.Count;
				}
				else
				{
					end_entry = (currentPageNum) * 7;
				}
				
				count = 1;
				
				for (int i = start_entry; i < end_entry; i++)
				{
					switch(count)
					{
						case 1: 
							tbName1.Text = text_input[i];
							tbName1.Visible = true;
							break;
						case 2:
							tbName2.Text = text_input[i];
							tbName2.Visible = true;
							break;
						case 3:
							tbName3.Text = text_input[i];
							tbName3.Visible = true;
							break;
						case 4:
							tbName4.Text = text_input[i];
							tbName4.Visible = true;
							break;
						case 5:
							tbName5.Text = text_input[i];
							tbName5.Visible = true;
							break;
						case 6:
							tbName6.Text = text_input[i];
							tbName6.Visible = true;
							break;
						case 7:
							tbName7.Text = text_input[i];
							tbName7.Visible = true;
							break;
					}
					
					count++;			
				}
				
			}
			
		}
		
		void btnNext_Click(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.listSelected.Value = 0;
			currentPage++;
			DisplayItems(currentPage);
		}
		
		void btnPrev_Click(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.listSelected.Value = 0;
			currentPage--;
			DisplayItems(currentPage);
		}
		
		void tbName1_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (Globals.Tags.listSelected.Value == 1)
			{
				Globals.Tags.listSelected.Value = 0;
			}
			else
			{
				Globals.Tags.listSelected.Value = 1;
				Globals.Tags.listSelectedText.Value = tbName1.Text;
			}
		}
		
		void tbName2_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (Globals.Tags.listSelected.Value == 2)
			{
				Globals.Tags.listSelected.Value = 0;
			}
			else
			{
				Globals.Tags.listSelected.Value = 2;
				Globals.Tags.listSelectedText.Value = tbName2.Text;
			}
		}
		
		void tbName3_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (Globals.Tags.listSelected.Value == 3)
			{
				Globals.Tags.listSelected.Value = 0;
			}
			else
			{
				Globals.Tags.listSelected.Value = 3;
				Globals.Tags.listSelectedText.Value = tbName3.Text;
			}
		}
		
		void tbName4_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (Globals.Tags.listSelected.Value == 4)
			{
				Globals.Tags.listSelected.Value = 0;
			}
			else
			{
				Globals.Tags.listSelected.Value = 4;
				Globals.Tags.listSelectedText.Value = tbName4.Text;
			}
		}
		
		void tbName5_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (Globals.Tags.listSelected.Value == 5)
			{
				Globals.Tags.listSelected.Value = 0;
			}
			else
			{
				Globals.Tags.listSelected.Value = 5;
				Globals.Tags.listSelectedText.Value = tbName5.Text;
			}
		}
		
		void tbName6_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (Globals.Tags.listSelected.Value == 6)
			{
				Globals.Tags.listSelected.Value = 0;
			}
			else
			{
				Globals.Tags.listSelected.Value = 6;
				Globals.Tags.listSelectedText.Value = tbName6.Text;
			}
		}
		
		void tbName7_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (Globals.Tags.listSelected.Value == 7)
			{
				Globals.Tags.listSelected.Value = 0;
			}
			else
			{
				Globals.Tags.listSelected.Value = 7;
				Globals.Tags.listSelectedText.Value = tbName7.Text;
			}
		}
		
		void Button_Click(System.Object sender, System.EventArgs e)
		{
			if (File.Exists("\\FlashDrive\\Project\\Project Files\\Recordings\\Rrcd_Index.csv"))
			{
				if (Globals.Tags.listSelected.Value == 0)
				{
					Globals.Tags.GeneralMessage.Value = "Nothing Selected";
					Globals.GeneralMsgBox.Show();
				}
				else
				{
					Globals.Tags.LeakRateDataFileName.Value = file_path[currentStartIndex + Globals.Tags.listSelected.Value - 1];
					Globals.FlowRateDisplay.Show();
				}
				
				
			}
		}
		
    }
}
