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
	using System.Collections.Generic;
    using Neo.ApplicationFramework.Tools;
    using Neo.ApplicationFramework.Common.Graphics.Logic;
    using Neo.ApplicationFramework.Controls;
    using Neo.ApplicationFramework.Interfaces;
    using System.IO;
    
    public partial class SelectFileName
    {
		public List<string> text_input = null;
		private int total_pages;
		private int currentPage = 1;
		private Timer CheckInput;
		private int currentStartIndex = 0;
		void SelectFileName_Opened(System.Object sender, System.EventArgs e)
		{
			
			text_input = new List<string>();
			
			UpdateList();
		
			DisplayItems(currentPage);
			
			CheckInput = new Timer();
			CheckInput.Interval = 1000;
			CheckInput.Tick += CheckInputTick;
			CheckInput.Enabled = true;
			
		}
		
		public void UpdateList()
		{
			string[] str_tmp;
			
			text_input.Clear();
			
			Globals.Tags.listSelected.Value = 0;
			
			if ((int)Globals.Tags.SelectType.Value == 0)
			{
				str_tmp = Globals.Tags.strFileNameList.Value.String.Split(',');
			}
			else
			{
				str_tmp = Globals.Tags.strTesterInitialList.Value.String.Split(',');
			}
			
			for (int i = 0; i < str_tmp.Length; i++)
			{
				text_input.Add(str_tmp[i]);
			}
		}
		
		private void CheckInputTick(System.Object sender, System.EventArgs e)
		{
			if ((int)Globals.Tags.valueChanged.Value == 1)
			{
				Globals.Tags.valueChanged.Value = 0;
				
				UpdateList();
					
				DisplayItems(currentPage);
				
			}
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
		
		void btnDel_Click(System.Object sender, System.EventArgs e)
		{
			if (Globals.Tags.listSelected.Value.Int == 0)
			{
				Globals.Tags.GeneralMessage.Value = "Nothing Selected";
				Globals.GeneralMsgBox.Show();
			}
			else
			{
				text_input.RemoveAt(currentStartIndex + Globals.Tags.listSelected.Value.Int - 1);
				
				if ((int)Globals.Tags.SelectType.Value == 0)
				{
					Globals.Tags.strFileNameList.Value = "";
					for(int i = 0;i < text_input.Count; i++)
					{
						Globals.Tags.strFileNameList.Value = Globals.Tags.strFileNameList.Value + text_input[i] + ",";
					}
				}
				else
				{
					Globals.Tags.strTesterInitialList.Value = "";
					for(int i = 0;i < text_input.Count; i++)
					{
						Globals.Tags.strTesterInitialList.Value = Globals.Tags.strTesterInitialList.Value + text_input[i] + ",";
					}
				}

                Globals.Tags.listSelected.Value = 0;
			}
			
			DisplayItems(currentPage);
		}
		
		void btnAdd_Click(System.Object sender, System.EventArgs e)
		{
			Globals.KeyBoardScreen.Show();
		}
		
		void btnImport_Click(System.Object sender, System.EventArgs e)
		{
			if(Directory.Exists("\\Hard Disk"))
			{
				Globals.ImportData.Show();
			}
			else
			{
				Globals.Tags.GeneralMessage.Value = "Please insert a valid USB drive";
				Globals.GeneralMsgBox.Show();
			}
		}
		
		void btnSel_Click(System.Object sender, System.EventArgs e)
		{
			if (Globals.Tags.listSelected.Value == 0)
			{
				Globals.Tags.GeneralMessage.Value = "Nothing Selected";
				Globals.GeneralMsgBox.Show();
			}
			else
			{
				if ((int)Globals.Tags.SelectType.Value == 0)
				{
					Globals.Tags.Selected_FileName.Value = Globals.Tags.listSelectedText.Value;
				}
				else
				{
					Globals.Tags.Selected_TesterInitial.Value = Globals.Tags.listSelectedText.Value;
				}
				Globals.SelectFileName.Close();
			}
		}
		
		void SelectFileName_Closed(System.Object sender, System.EventArgs e)
		{
			CheckInput.Enabled = false;
		}
		
    }
}
