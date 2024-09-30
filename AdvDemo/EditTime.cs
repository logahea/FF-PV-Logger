/*
 * Copyright (c) 2005 National Instruments Corp. All rights reserved
 * EditTime.cs
 * implementation of writing paramter whose type is FF_TIME_VALUE
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
	/// Summary description for EditTime.
	/// </summary>
	public class EditTimeForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button ExitButton;
		private System.Windows.Forms.Button WriteButton;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox lowerText;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox upperText;
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		
		private Parameter curParameter;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox TypeText;
		private System.Windows.Forms.TextBox NameText;
		private System.Windows.Forms.Label NameLbl;
		private System.Windows.Forms.Label TypeLbl;
		private System.Windows.Forms.StatusBarPanel MessageStatus;
		private System.Windows.Forms.StatusBar MainStatus;
		private Element curElement;
		public EditTimeForm(Parameter param, Element element)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(EditTimeForm));
			this.ExitButton = new System.Windows.Forms.Button();
			this.WriteButton = new System.Windows.Forms.Button();
			this.label11 = new System.Windows.Forms.Label();
			this.lowerText = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.upperText = new System.Windows.Forms.TextBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.TypeText = new System.Windows.Forms.TextBox();
			this.NameText = new System.Windows.Forms.TextBox();
			this.NameLbl = new System.Windows.Forms.Label();
			this.TypeLbl = new System.Windows.Forms.Label();
			this.MessageStatus = new System.Windows.Forms.StatusBarPanel();
			this.MainStatus = new System.Windows.Forms.StatusBar();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.MessageStatus)).BeginInit();
			this.SuspendLayout();
			// 
			// ExitButton
			// 
			this.ExitButton.Location = new System.Drawing.Point(122, 192);
			this.ExitButton.Name = "ExitButton";
			this.ExitButton.Size = new System.Drawing.Size(56, 24);
			this.ExitButton.TabIndex = 11;
			this.ExitButton.Text = "Close";
			this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
			// 
			// WriteButton
			// 
			this.WriteButton.Location = new System.Drawing.Point(34, 192);
			this.WriteButton.Name = "WriteButton";
			this.WriteButton.Size = new System.Drawing.Size(56, 24);
			this.WriteButton.TabIndex = 10;
			this.WriteButton.Text = "Write";
			this.WriteButton.Click += new System.EventHandler(this.WriteButton_Click);
			// 
			// label11
			// 
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label11.Location = new System.Drawing.Point(14, 42);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(48, 16);
			this.label11.TabIndex = 17;
			this.label11.Text = "Lower";
			// 
			// lowerText
			// 
			this.lowerText.Location = new System.Drawing.Point(56, 40);
			this.lowerText.Name = "lowerText";
			this.lowerText.Size = new System.Drawing.Size(144, 20);
			this.lowerText.TabIndex = 16;
			this.lowerText.Text = "";
			// 
			// label12
			// 
			this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label12.Location = new System.Drawing.Point(14, 10);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(48, 16);
			this.label12.TabIndex = 15;
			this.label12.Text = "Upper";
			// 
			// upperText
			// 
			this.upperText.Location = new System.Drawing.Point(56, 8);
			this.upperText.Name = "upperText";
			this.upperText.Size = new System.Drawing.Size(144, 20);
			this.upperText.TabIndex = 14;
			this.upperText.Text = "";
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
			this.panel2.Controls.Add(this.upperText);
			this.panel2.Controls.Add(this.lowerText);
			this.panel2.Controls.Add(this.label11);
			this.panel2.Controls.Add(this.label12);
			this.panel2.Location = new System.Drawing.Point(0, 91);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(216, 69);
			this.panel2.TabIndex = 29;
			// 
			// panel4
			// 
			this.panel4.BackColor = System.Drawing.Color.Black;
			this.panel4.Location = new System.Drawing.Point(0, 174);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(216, 1);
			this.panel4.TabIndex = 31;
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
			this.panel1.Size = new System.Drawing.Size(218, 72);
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
			// MessageStatus
			// 
			this.MessageStatus.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.MessageStatus.Text = " Ready";
			this.MessageStatus.Width = 218;
			// 
			// MainStatus
			// 
			this.MainStatus.Location = new System.Drawing.Point(0, 226);
			this.MainStatus.Name = "MainStatus";
			this.MainStatus.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						  this.MessageStatus});
			this.MainStatus.ShowPanels = true;
			this.MainStatus.Size = new System.Drawing.Size(218, 22);
			this.MainStatus.SizingGrip = false;
			this.MainStatus.TabIndex = 27;
			// 
			// EditTimeForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(218, 248);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.MainStatus);
			this.Controls.Add(this.WriteButton);
			this.Controls.Add(this.ExitButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "EditTimeForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "EditTime";
			this.Load += new System.EventHandler(this.EditTimeForm_Load);
			this.panel2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.MessageStatus)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void EditTimeForm_Load(object sender, System.EventArgs e)
		{
			this.Text = " Edit "+ curElement.Name;
			NameText.Text = curParameter.Name +"." + curElement.Name;
			TypeText.Text = curElement.Type.ToString();
			FBTime t = curElement.Value as FBTime;
			lowerText.Text = t.Lower.ToString();
			upperText.Text = t.Upper.ToString();
		}

		private void ExitButton_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void WriteButton_Click(object sender, System.EventArgs e)
		{
			MessageStatus.Text=" Writing Object ...";
			FBTime t = curElement.Value as FBTime;
			try
			{
				t.Lower = long.Parse(lowerText.Text);
				t.Upper = long.Parse(upperText.Text);
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
