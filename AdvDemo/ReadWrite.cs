/*
 * Copyright (c) 2005 National Instruments Corp. All rights reserved
 * ReadWrite.cs
 * implementation of listing all the parameters of a definite block, 
 * shows the definite parameter's value and selects the definite parameter to write.
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
	//
	/// </summary>
	/// 
	
	public class ReadWriteForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ListView dataList;
		private System.Windows.Forms.Button editData;
		private System.Windows.Forms.Button readData;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Label label5;
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		/// 


		// variant shared in all the functions in this form
		private Block curBlock = null;
		private Mib curMIB = null;
		private System.Windows.Forms.StatusBar MainStatus;
		private System.Windows.Forms.StatusBarPanel MessageStatus;
		private System.Windows.Forms.ColumnHeader TypeHeader;
		private System.Windows.Forms.ColumnHeader DataHeader;
		private System.Windows.Forms.ColumnHeader NameHeader;
		private System.Windows.Forms.ColumnHeader ParamNameHeader;
		private System.Windows.Forms.ColumnHeader ParamTypeHeader;
		private System.Windows.Forms.ColumnHeader ParamSizeHeader;
		private System.Windows.Forms.ListView paramList;
		private System.Windows.Forms.Button CloseBtn;
		private Parameter curParam;
		
		
		// costumized contruct function to pass in two useful parameter: blockDesc, bloInfo
		public ReadWriteForm(Block block)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			//
			//  
			//
			curBlock = block;
		}

		public ReadWriteForm(Mib mib)
		{
			InitializeComponent();
			curMIB = mib;
		}

		private static string[] MIBParamName= 
		{
			"AP_CLOCK_SYNC_INTERVAL",
			"BOOT_OPERAT_FUNCTIONAL_CLASS",
			"CURRENT_TIME",
			"DEV_ID",
			"DLME_BASIC_CHARACTERISTICS",
			"DLME_BASIC_INFO",
			"DLME_LINK_MASTER_INFO",
			"LINK_SCHEDULE_ACTIVATION",
			"LINK_SCHEDULE_LIST_CHARACTERISTICS",
			"LIVE_LIST_STATUS",
			"LOCAL_TIME_DIFF",
			"MACROCYCLE_DURATION",
			"OPERATIONAL_POWERUP",
			"PD_TAG",
			"PLME_BASIC_CHARACTERISTICS",
			"PLME_BASIC_INFO",
			"PRIMARY_AP_TIME_PUBLISHER",
			"PRIMARY_LINK_MASTER_FLAG",
			"SM_SUPPORT",
			"STACK_CAPABILITIES",
			"T1",
			"T2",
			"T3",
			"TIME_LAST_RCVD",
			"TIME_PUBLISHER_ADDR",
			"VCR_LIST_CHARACTERISTICS",
			"VERSION_OF_SCHEDULE",
		};

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ReadWriteForm));
			this.panel2 = new System.Windows.Forms.Panel();
			this.dataList = new System.Windows.Forms.ListView();
			this.NameHeader = new System.Windows.Forms.ColumnHeader();
			this.TypeHeader = new System.Windows.Forms.ColumnHeader();
			this.DataHeader = new System.Windows.Forms.ColumnHeader();
			this.label3 = new System.Windows.Forms.Label();
			this.editData = new System.Windows.Forms.Button();
			this.readData = new System.Windows.Forms.Button();
			this.panel4 = new System.Windows.Forms.Panel();
			this.paramList = new System.Windows.Forms.ListView();
			this.ParamNameHeader = new System.Windows.Forms.ColumnHeader();
			this.ParamTypeHeader = new System.Windows.Forms.ColumnHeader();
			this.ParamSizeHeader = new System.Windows.Forms.ColumnHeader();
			this.label5 = new System.Windows.Forms.Label();
			this.MainStatus = new System.Windows.Forms.StatusBar();
			this.MessageStatus = new System.Windows.Forms.StatusBarPanel();
			this.CloseBtn = new System.Windows.Forms.Button();
			this.panel2.SuspendLayout();
			this.panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.MessageStatus)).BeginInit();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.Controls.Add(this.dataList);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Location = new System.Drawing.Point(16, 200);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(376, 160);
			this.panel2.TabIndex = 1;
			// 
			// dataList
			// 
			this.dataList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																					   this.NameHeader,
																					   this.TypeHeader,
																					   this.DataHeader});
			this.dataList.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.dataList.FullRowSelect = true;
			this.dataList.GridLines = true;
			this.dataList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.dataList.LabelWrap = false;
			this.dataList.Location = new System.Drawing.Point(0, 16);
			this.dataList.MultiSelect = false;
			this.dataList.Name = "dataList";
			this.dataList.Size = new System.Drawing.Size(376, 144);
			this.dataList.TabIndex = 1;
			this.dataList.View = System.Windows.Forms.View.Details;
			this.dataList.DoubleClick += new System.EventHandler(this.editData_Click);
			// 
			// NameHeader
			// 
			this.NameHeader.Text = "Name";
			this.NameHeader.Width = 106;
			// 
			// TypeHeader
			// 
			this.TypeHeader.Text = "Type";
			this.TypeHeader.Width = 122;
			// 
			// DataHeader
			// 
			this.DataHeader.Text = "Data";
			this.DataHeader.Width = 140;
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Top;
			this.label3.Location = new System.Drawing.Point(0, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(376, 16);
			this.label3.TabIndex = 0;
			this.label3.Text = "Elements";
			// 
			// editData
			// 
			this.editData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.editData.Location = new System.Drawing.Point(15, 376);
			this.editData.Name = "editData";
			this.editData.Size = new System.Drawing.Size(88, 24);
			this.editData.TabIndex = 3;
			this.editData.Text = "Edit Data";
			this.editData.Click += new System.EventHandler(this.editData_Click);
			// 
			// readData
			// 
			this.readData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.readData.Location = new System.Drawing.Point(163, 376);
			this.readData.Name = "readData";
			this.readData.Size = new System.Drawing.Size(88, 24);
			this.readData.TabIndex = 4;
			this.readData.Text = "Read Data";
			this.readData.Click += new System.EventHandler(this.readData_Click);
			// 
			// panel4
			// 
			this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.panel4.Controls.Add(this.paramList);
			this.panel4.Controls.Add(this.label5);
			this.panel4.Location = new System.Drawing.Point(16, 16);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(376, 160);
			this.panel4.TabIndex = 5;
			// 
			// paramList
			// 
			this.paramList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.ParamNameHeader,
																						this.ParamTypeHeader,
																						this.ParamSizeHeader});
			this.paramList.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.paramList.FullRowSelect = true;
			this.paramList.GridLines = true;
			this.paramList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.paramList.LabelWrap = false;
			this.paramList.Location = new System.Drawing.Point(0, 16);
			this.paramList.MultiSelect = false;
			this.paramList.Name = "paramList";
			this.paramList.Size = new System.Drawing.Size(376, 144);
			this.paramList.TabIndex = 6;
			this.paramList.View = System.Windows.Forms.View.Details;
			this.paramList.DoubleClick += new System.EventHandler(this.readData_Click);
			// 
			// ParamNameHeader
			// 
			this.ParamNameHeader.Text = "Name";
			this.ParamNameHeader.Width = 129;
			// 
			// ParamTypeHeader
			// 
			this.ParamTypeHeader.Text = "Type";
			this.ParamTypeHeader.Width = 125;
			// 
			// ParamSizeHeader
			// 
			this.ParamSizeHeader.Text = "Size ( in byte )";
			this.ParamSizeHeader.Width = 96;
			// 
			// label5
			// 
			this.label5.Dock = System.Windows.Forms.DockStyle.Top;
			this.label5.Location = new System.Drawing.Point(0, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(376, 16);
			this.label5.TabIndex = 0;
			this.label5.Text = "Parameters";
			// 
			// MainStatus
			// 
			this.MainStatus.Location = new System.Drawing.Point(0, 414);
			this.MainStatus.Name = "MainStatus";
			this.MainStatus.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						  this.MessageStatus});
			this.MainStatus.ShowPanels = true;
			this.MainStatus.Size = new System.Drawing.Size(406, 22);
			this.MainStatus.SizingGrip = false;
			this.MainStatus.TabIndex = 6;
			// 
			// MessageStatus
			// 
			this.MessageStatus.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.MessageStatus.Text = " Ready";
			this.MessageStatus.Width = 406;
			// 
			// CloseBtn
			// 
			this.CloseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.CloseBtn.Location = new System.Drawing.Point(303, 376);
			this.CloseBtn.Name = "CloseBtn";
			this.CloseBtn.Size = new System.Drawing.Size(88, 24);
			this.CloseBtn.TabIndex = 7;
			this.CloseBtn.Text = "Close";
			this.CloseBtn.Click += new System.EventHandler(this.Close_Click);
			// 
			// ReadWriteForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(406, 436);
			this.Controls.Add(this.CloseBtn);
			this.Controls.Add(this.MainStatus);
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.readData);
			this.Controls.Add(this.editData);
			this.Controls.Add(this.panel2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "ReadWriteForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Read&Write";
			this.Load += new System.EventHandler(this.ReadWriteForm_Load);
			this.panel2.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.MessageStatus)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void ReadWriteForm_Load(object sender, System.EventArgs e)
		{
			paramList.Items.Clear();
			ListViewItem dataItem;
			if(curBlock != null) // Block Parameter
			{
				this.Text = " Read/Write  Block -- " +curBlock.Tag;
				// fill the parameters' names into the ListBox
				foreach (Parameter p in curBlock.Parameters)
				{
					dataItem = new ListViewItem();
					dataItem.Text = p.Name;
					dataItem.SubItems.Add(p.Type.ToString());
					dataItem.SubItems.Add(p.Size.ToString());
					paramList.Items.Add(dataItem);
				}
			}
			else // MIB Parameter
			{
				Parameter p = null;
				this.Text = " Read/Write MIB";
				foreach (string paramName in MIBParamName)
				{
					try
					{
						p = curMIB.ReadParameterByName(paramName);
						dataItem = new ListViewItem();
						dataItem.Text = p.Name;
						dataItem.SubItems.Add(p.Type.ToString());
						dataItem.SubItems.Add(p.Size.ToString());
						paramList.Items.Add(dataItem);
					}
					catch(Exception exp)
					{
						MessageStatus.Text = paramName+ "- "+exp.Message;
					}
						
				}
			}
		}

		

		private void readData_Click(object sender, System.EventArgs e)
		{
			
			string				paramName;
			if(paramList.SelectedItems[0] == null)
			{
				return;
			}
		
			MessageStatus.Text = " Reading Data ... ";

			dataList.Items.Clear();
			dataList.Refresh();
			
			paramName = paramList.SelectedItems[0].Text;
			try
			{
				if(curBlock!=null)
				{
					curParam = curBlock.ReadParameterByName(paramName);
				}
				else
				{
					curParam = curMIB.ReadParameterByName(paramName);
				}
				ListViewItem dataItem;
				switch(curParam.Type)
				{
					case ParameterType.ODT_SIMPLEVAR:
						SimpleVarParameter svp = curParam as SimpleVarParameter;
						dataItem = new ListViewItem();
						dataItem = new ListViewItem();
						dataItem.Text = svp.Element.Name;
						dataItem.SubItems.Add(svp.Element.Type.ToString());
						dataItem.SubItems.Add(svp.Element.ValueString());
						dataList.Items.Add(dataItem);
						break;
//					case ParameterType.ODT_STRUCTTYPE:
//						StructureParameter sp = curParam as StructureParameter;
//						foreach (Element elem in sp.Elements){
//							dataItem = new ListViewItem();
//							dataItem.Text = elem.Name;
//							dataItem.SubItems.Add(elem.Type.ToString());
//							dataItem.SubItems.Add(elem.ValueString());
//							dataList.Items.Add(dataItem);
//						}
//						break;
					case ParameterType.ODT_ARRAY:
						ArrayParameter ap = curParam as ArrayParameter;
						foreach (Element elem in ap.Elements)
						{
							dataItem = new ListViewItem();
							dataItem.Text = elem.Name;
							dataItem.SubItems.Add(elem.Type.ToString());
							dataItem.SubItems.Add(elem.ValueString());
							dataList.Items.Add(dataItem);
						}
						break;
					case ParameterType.ODT_RECORD:
						RecordParameter rp = curParam as RecordParameter;
						foreach (Element elem in rp.Elements)
						{
							dataItem = new ListViewItem();
							dataItem.Text = elem.Name;
							dataItem.SubItems.Add(elem.Type.ToString());
							dataItem.SubItems.Add(elem.ValueString());
							dataList.Items.Add(dataItem);
						}
						break;
					default:
						break;
				}
				MessageStatus.Text += " successful";
			}
			catch(FBException exp)
			{
				MessageStatus.Text = exp.Message;
			}
		}
		
		private void editData_Click(object sender, System.EventArgs e)
		{
			int index = -1;
			foreach (int iter in dataList.SelectedIndices)
			{
				index = iter;
			}
			if (index == -1)
			{
				return;
			}
			Element elem;
			switch(curParam.Type)
			{
				case ParameterType.ODT_SIMPLEVAR:
					SimpleVarParameter svp = curParam as SimpleVarParameter;
					elem = svp.Element;
					break;
//				case ParameterType.ODT_STRUCTTYPE:
//					StructureParameter sp = curParam as StructureParameter;
//					elem = sp.Elements[index];
//					break;
				case ParameterType.ODT_ARRAY:
					ArrayParameter ap = curParam as ArrayParameter;
					elem = ap.Elements[index];
					break;
				case ParameterType.ODT_RECORD:
					RecordParameter rp = curParam as RecordParameter;
					elem = rp.Elements[index];
					break;
				default:
					return;
			}

			switch(elem.Type)
			{
				case ElementType.FF_BOOLEAN:
					EditBoolForm editBool= new EditBoolForm(curParam,elem);
					editBool.ShowDialog();
					break;
				case ElementType.FF_INTEGER8:
				case ElementType.FF_INTEGER16:
				case ElementType.FF_INTEGER32:
				case ElementType.FF_UNSIGNED8:
				case ElementType.FF_UNSIGNED16:
				case ElementType.FF_UNSIGNED32:
					EditIntegerForm editInteger= new EditIntegerForm(curParam,elem);
					editInteger.ShowDialog();
					break;
				case ElementType.FF_FLOAT:
					EditFloatForm editFloat= new EditFloatForm(curParam,elem);
					editFloat.ShowDialog();
					break;
				case ElementType.FF_VISIBLE_STRING:
					EditVisiStringForm editVisiString= new EditVisiStringForm(curParam,elem);
					editVisiString.ShowDialog();
					break;
				case ElementType.FF_OCTET_STRING:
					EditOctetStringForm editOctetString= new EditOctetStringForm(curParam,elem);
					editOctetString.ShowDialog();
					break;
				case ElementType.FF_DATE:
					EditDateForm editDate= new EditDateForm(curParam,elem);
					editDate.ShowDialog();
					break;
				case ElementType.FF_TIMEOFDAY:
				case ElementType.FF_TIME_DIFF:
					EditDayForm editDay= new EditDayForm(curParam,elem);
					editDay.ShowDialog();
					break;
				case ElementType.FF_BIT_STRING:
					EditBitStringForm editBitString= new EditBitStringForm(curParam,elem);
					editBitString.ShowDialog();
					break;
				case ElementType.FF_TIME_VALUE:
					EditTimeForm editTime= new EditTimeForm(curParam,elem);
					editTime.ShowDialog();
					break;
				default:
					MessageStatus.Text=" Unknown parameter type!";
					break;

			}
			
			// refresh subparameter's data
			readData_Click(sender,e);
		}

		private void Close_Click(object sender, System.EventArgs e)
		{
			Close();
		}
	}
}
