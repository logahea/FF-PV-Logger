/*
 * Copyright (c) 2005 National Instruments Corp. All rights reserved
 * EditDate.cs
 * implementation of writing paramter whose type is FF_DATE
 */
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using NationalInstruments.FieldBus;
using NationalInstruments.FieldBus.ExceptionHandler;
using NationalInstruments.FieldBus.ParameterHandler;
using NationalInstruments.FieldBus.ElementHandler;

namespace AdvDemo
{
	/// <summary>
	/// Summary description for EditDate.
	/// </summary>
	public class EditDateForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button ExitButton;
		private System.Windows.Forms.Button WriteButton;
		private System.Windows.Forms.CheckBox summerTimeCheck;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox msecOfDateText;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox minText;
		private System.Windows.Forms.TextBox hourText;
		private System.Windows.Forms.TextBox dayOfMonthText;
		private System.Windows.Forms.TextBox monthText;
		private System.Windows.Forms.TextBox yearText;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private Parameter curParameter;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox TypeText;
		private System.Windows.Forms.TextBox NameText;
		private System.Windows.Forms.Label NameLbl;
		private System.Windows.Forms.Label TypeLbl;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.StatusBar MainStatus;
		private System.Windows.Forms.StatusBarPanel MessageStatus;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel2;
		private Element curElement;
		public EditDateForm(Parameter param, Element element)
		{
			InitializeComponent();
			curElement = element;
			curParameter = param;
		}
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(EditDateForm));
			this.ExitButton = new System.Windows.Forms.Button();
			this.WriteButton = new System.Windows.Forms.Button();
			this.summerTimeCheck = new System.Windows.Forms.CheckBox();
			this.label8 = new System.Windows.Forms.Label();
			this.msecOfDateText = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.minText = new System.Windows.Forms.TextBox();
			this.hourText = new System.Windows.Forms.TextBox();
			this.dayOfMonthText = new System.Windows.Forms.TextBox();
			this.monthText = new System.Windows.Forms.TextBox();
			this.yearText = new System.Windows.Forms.TextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.TypeText = new System.Windows.Forms.TextBox();
			this.NameText = new System.Windows.Forms.TextBox();
			this.NameLbl = new System.Windows.Forms.Label();
			this.TypeLbl = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.MainStatus = new System.Windows.Forms.StatusBar();
			this.MessageStatus = new System.Windows.Forms.StatusBarPanel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.MessageStatus)).BeginInit();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// ExitButton
			// 
			this.ExitButton.Location = new System.Drawing.Point(120, 336);
			this.ExitButton.Name = "ExitButton";
			this.ExitButton.Size = new System.Drawing.Size(56, 24);
			this.ExitButton.TabIndex = 11;
			this.ExitButton.Text = "Close";
			this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
			// 
			// WriteButton
			// 
			this.WriteButton.Location = new System.Drawing.Point(40, 336);
			this.WriteButton.Name = "WriteButton";
			this.WriteButton.Size = new System.Drawing.Size(56, 24);
			this.WriteButton.TabIndex = 10;
			this.WriteButton.Text = "Write";
			this.WriteButton.Click += new System.EventHandler(this.WriteButton_Click);
			// 
			// summerTimeCheck
			// 
			this.summerTimeCheck.Location = new System.Drawing.Point(55, 197);
			this.summerTimeCheck.Name = "summerTimeCheck";
			this.summerTimeCheck.Size = new System.Drawing.Size(144, 16);
			this.summerTimeCheck.TabIndex = 14;
			this.summerTimeCheck.Text = "SummerTime";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label8.Location = new System.Drawing.Point(16, 170);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(31, 16);
			this.label8.TabIndex = 13;
			this.label8.Text = "Msec";
			// 
			// msecOfDateText
			// 
			this.msecOfDateText.Location = new System.Drawing.Point(56, 168);
			this.msecOfDateText.Name = "msecOfDateText";
			this.msecOfDateText.Size = new System.Drawing.Size(144, 20);
			this.msecOfDateText.TabIndex = 12;
			this.msecOfDateText.Text = "";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label7.Location = new System.Drawing.Point(14, 139);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(38, 16);
			this.label7.TabIndex = 11;
			this.label7.Text = "Minute";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label6.Location = new System.Drawing.Point(16, 106);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(29, 16);
			this.label6.TabIndex = 10;
			this.label6.Text = "Hour";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(16, 74);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(24, 16);
			this.label2.TabIndex = 8;
			this.label2.Text = "Day";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(14, 43);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(36, 16);
			this.label3.TabIndex = 7;
			this.label3.Text = "Month";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label9.Location = new System.Drawing.Point(15, 11);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(28, 16);
			this.label9.TabIndex = 6;
			this.label9.Text = "Year";
			// 
			// minText
			// 
			this.minText.Location = new System.Drawing.Point(56, 136);
			this.minText.Name = "minText";
			this.minText.Size = new System.Drawing.Size(144, 20);
			this.minText.TabIndex = 5;
			this.minText.Text = "";
			// 
			// hourText
			// 
			this.hourText.Location = new System.Drawing.Point(56, 104);
			this.hourText.Name = "hourText";
			this.hourText.Size = new System.Drawing.Size(144, 20);
			this.hourText.TabIndex = 4;
			this.hourText.Text = "";
			// 
			// dayOfMonthText
			// 
			this.dayOfMonthText.Location = new System.Drawing.Point(56, 72);
			this.dayOfMonthText.Name = "dayOfMonthText";
			this.dayOfMonthText.Size = new System.Drawing.Size(144, 20);
			this.dayOfMonthText.TabIndex = 2;
			this.dayOfMonthText.Text = "";
			// 
			// monthText
			// 
			this.monthText.Location = new System.Drawing.Point(56, 40);
			this.monthText.Name = "monthText";
			this.monthText.Size = new System.Drawing.Size(144, 20);
			this.monthText.TabIndex = 1;
			this.monthText.Text = "";
			// 
			// yearText
			// 
			this.yearText.Location = new System.Drawing.Point(56, 8);
			this.yearText.Name = "yearText";
			this.yearText.Size = new System.Drawing.Size(144, 20);
			this.yearText.TabIndex = 0;
			this.yearText.Text = "";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.TypeText);
			this.panel1.Controls.Add(this.NameText);
			this.panel1.Controls.Add(this.NameLbl);
			this.panel1.Controls.Add(this.TypeLbl);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(214, 72);
			this.panel1.TabIndex = 28;
			// 
			// TypeText
			// 
			this.TypeText.Location = new System.Drawing.Point(56, 45);
			this.TypeText.Name = "TypeText";
			this.TypeText.ReadOnly = true;
			this.TypeText.Size = new System.Drawing.Size(144, 20);
			this.TypeText.TabIndex = 22;
			this.TypeText.Text = "";
			// 
			// NameText
			// 
			this.NameText.Location = new System.Drawing.Point(56, 13);
			this.NameText.Name = "NameText";
			this.NameText.ReadOnly = true;
			this.NameText.Size = new System.Drawing.Size(144, 20);
			this.NameText.TabIndex = 21;
			this.NameText.Text = "";
			// 
			// NameLbl
			// 
			this.NameLbl.AutoSize = true;
			this.NameLbl.Location = new System.Drawing.Point(11, 17);
			this.NameLbl.Name = "NameLbl";
			this.NameLbl.Size = new System.Drawing.Size(34, 16);
			this.NameLbl.TabIndex = 20;
			this.NameLbl.Text = "Name";
			// 
			// TypeLbl
			// 
			this.TypeLbl.AutoSize = true;
			this.TypeLbl.Location = new System.Drawing.Point(12, 47);
			this.TypeLbl.Name = "TypeLbl";
			this.TypeLbl.Size = new System.Drawing.Size(29, 16);
			this.TypeLbl.TabIndex = 19;
			this.TypeLbl.Text = "Type";
			// 
			// panel4
			// 
			this.panel4.BackColor = System.Drawing.Color.Black;
			this.panel4.Location = new System.Drawing.Point(0, 320);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(216, 1);
			this.panel4.TabIndex = 31;
			// 
			// MainStatus
			// 
			this.MainStatus.Location = new System.Drawing.Point(0, 366);
			this.MainStatus.Name = "MainStatus";
			this.MainStatus.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						  this.MessageStatus});
			this.MainStatus.ShowPanels = true;
			this.MainStatus.Size = new System.Drawing.Size(214, 22);
			this.MainStatus.SizingGrip = false;
			this.MainStatus.TabIndex = 27;
			// 
			// MessageStatus
			// 
			this.MessageStatus.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.MessageStatus.Text = " Ready";
			this.MessageStatus.Width = 214;
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.Black;
			this.panel3.Location = new System.Drawing.Point(1, 79);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(216, 1);
			this.panel3.TabIndex = 30;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.yearText);
			this.panel2.Controls.Add(this.monthText);
			this.panel2.Controls.Add(this.dayOfMonthText);
			this.panel2.Controls.Add(this.label9);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.hourText);
			this.panel2.Controls.Add(this.minText);
			this.panel2.Controls.Add(this.label6);
			this.panel2.Controls.Add(this.label7);
			this.panel2.Controls.Add(this.label8);
			this.panel2.Controls.Add(this.msecOfDateText);
			this.panel2.Controls.Add(this.summerTimeCheck);
			this.panel2.Location = new System.Drawing.Point(0, 91);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(216, 221);
			this.panel2.TabIndex = 29;
			// 
			// EditDateForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(214, 388);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.MainStatus);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.WriteButton);
			this.Controls.Add(this.ExitButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "EditDateForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "EditDate";
			this.Load += new System.EventHandler(this.EditDate_Load);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.MessageStatus)).EndInit();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void EditDate_Load(object sender, System.EventArgs e)
		{
			this.Text = " Edit "+ curElement.Name;
			NameText.Text = curParameter.Name +"." + curElement.Name;
			TypeText.Text = curElement.Type.ToString();
			FBDate d = curElement.Value as FBDate;
			yearText.Text = d.Year.ToString();
			monthText.Text = d.Month.ToString();
			dayOfMonthText.Text = d.DayOfMonth.ToString();
			hourText.Text = d.Hour.ToString();
			minText.Text = d.Minute.ToString();
			msecOfDateText.Text = d.Millisecond.ToString();
			summerTimeCheck.Checked = d.Summertime;
		}

		private void ExitButton_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void WriteButton_Click(object sender, System.EventArgs e)
		{
			MessageStatus.Text=" Writing Object ...";
			FBDate d = curElement.Value as FBDate;
			try
			{
				d.Year = byte.Parse(yearText.Text);
				d.Month = byte.Parse(monthText.Text);
				d.DayOfMonth =byte.Parse(dayOfMonthText.Text);
				d.Hour = byte.Parse(hourText.Text);
				d.Minute = byte.Parse(minText.Text);
				d.Millisecond = int.Parse(msecOfDateText.Text);
				d.Summertime = summerTimeCheck.Checked;
				curParameter.Write();
				MessageStatus.Text += " successful";
			}
			catch(Exception exp)
			{
				MessageStatus.Text = exp.Message;
			}
		}
	}
}
