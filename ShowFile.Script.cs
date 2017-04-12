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
    
    public partial class ShowFile
    {
		public List<string> text_input = null;
		public List<string> file_path = null;
		public List<int> file_type = null;
		private int total_pages;
		private int currentPage = 1;
		private string currentDir;
		private string rootDir;
		private int selectedIndex = 0;
		private int currentStartIndex = 0;
		private int currentLayer = 0;
		private bool canGoUp;
		void ShowFile_Opened(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.listSelected.Value = 0;
			text_input = new List<string>();
			file_path = new List<string>();
			file_type = new List<int>();
			rootDir = "\\Hard Disk\\";
			
			DisplayCurrentDir(rootDir);
			canGoUp = false;
		}
		
		void DisplayCurrentDir(string path)
		{
			text_input.Clear();
			file_path.Clear();
			Globals.Tags.listSelected.Value = 0;
			currentDir = path;
			
			string [] dirEntries = Directory.GetDirectories(path);
			string [] fileEntries = Directory.GetFiles(path, "*.csv");
			
			foreach(string dirName in dirEntries)
			{
				string[] tmp;
				file_path.Add(dirName);
				tmp = dirName.Split('\\');
				text_input.Add("<Dir>  " + tmp[tmp.Length - 1]);
				file_type.Add(0);
			}
			
			foreach(string fileName in fileEntries)
			{
				string[] tmp;
				file_path.Add(fileName);
				tmp = fileName.Split('\\');
				text_input.Add(tmp[tmp.Length - 1]);
				file_type.Add(1);
			}
			
			DisplayItems(currentPage);
			
		}
		
			
		void btnOK_Click(System.Object sender, System.EventArgs e)
		{
			if (Globals.Tags.listSelected.Value == 0)
			{
				Globals.Tags.GeneralMessage.Value = "Nothing Selected";
				Globals.GeneralMsgBox.Show();
			}
			else
			{
				if (file_type[selectedIndex] == 0)
				{
					DisplayCurrentDir(file_path[selectedIndex]);
					currentLayer++;
					canGoUp = true;
					//btnUp.IsEnabled = true;
				}
				else
				{
					Globals.Tags.LeakRateDataFileName.Value = file_path[selectedIndex];
					Globals.FlowRateDisplay.Show();
				}
			}
		}
		
		void btnUp_Click(System.Object sender, System.EventArgs e)
		{
			if (canGoUp)
			{
				int last_index = currentDir.LastIndexOf('\\');
				string dirPath = currentDir.Substring(0,last_index);
			
				DisplayCurrentDir(dirPath);
				currentLayer--;
				if (currentLayer == 0)
				{
					canGoUp = false;
					//	btnUp.IsEnabled = false;
				}
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
				selectedIndex = currentStartIndex + 6;
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
				selectedIndex = currentStartIndex + 5;
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
				selectedIndex = currentStartIndex + 4;
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
				selectedIndex = currentStartIndex + 3;
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
				selectedIndex = currentStartIndex + 2;
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
				selectedIndex = currentStartIndex + 1;
			}
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
				selectedIndex = currentStartIndex;
			}
		}
		
		void btnNext_Click(System.Object sender, System.EventArgs e)
		{
			currentPage++;
			DisplayItems(currentPage);
		}
		
		void btnPrev_Click(System.Object sender, System.EventArgs e)
		{
			currentPage--;
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
		
		void btnCancel_Click(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.valueChanged.Value = 1;
			Globals.ShowFile.Close();
		}
		
		private bool CheckRepeat(string input, string toCheck)
		{
			bool result = false;
			
			string[] tmp = toCheck.Split(',');
			
			foreach (string strA in tmp)
			{
				if (input == strA)
				{
					result = true;
				}
			}
			
			return result;
			
		}

		
	}
}
