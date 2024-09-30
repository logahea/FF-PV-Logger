using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using NationalInstruments.FieldBus;
using NationalInstruments.FieldBus.ExceptionHandler;
using NationalInstruments.FieldBus.ElementHandler;
using NationalInstruments.FieldBus.ParameterHandler;
namespace AdvDemo
{
	/// <summary>
	/// Summary description for Property.
	/// </summary>
	public class PropertyForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListView PropertyList;
		private System.Windows.Forms.ColumnHeader NameHeader;
		private System.Windows.Forms.ColumnHeader ValueHeader;
		private FBObject fbObj;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PropertyForm(FBObject fbObj)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.fbObj = fbObj;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PropertyForm));
			this.PropertyList = new System.Windows.Forms.ListView();
			this.NameHeader = new System.Windows.Forms.ColumnHeader();
			this.ValueHeader = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// PropertyList
			// 
			this.PropertyList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						   this.NameHeader,
																						   this.ValueHeader});
			this.PropertyList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PropertyList.FullRowSelect = true;
			this.PropertyList.GridLines = true;
			this.PropertyList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.PropertyList.Location = new System.Drawing.Point(0, 0);
			this.PropertyList.MultiSelect = false;
			this.PropertyList.Name = "PropertyList";
			this.PropertyList.Size = new System.Drawing.Size(310, 292);
			this.PropertyList.TabIndex = 0;
			this.PropertyList.View = System.Windows.Forms.View.Details;
			// 
			// NameHeader
			// 
			this.NameHeader.Text = "Name";
			this.NameHeader.Width = 141;
			// 
			// ValueHeader
			// 
			this.ValueHeader.Text = "Value";
			this.ValueHeader.Width = 165;
			// 
			// PropertyForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(310, 292);
			this.Controls.Add(this.PropertyList);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PropertyForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Property";
			this.Load += new System.EventHandler(this.PropertyForm_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void PropertyForm_Load(object sender, System.EventArgs e)
		{
			ListViewItem dataItem;
			if(fbObj is Link)
			{
				this.Text = "Link Property";
				Link link = fbObj as Link;
				dataItem = PropertyList.Items.Add("ID");
				dataItem.SubItems.Add(link.Id);
				dataItem = PropertyList.Items.Add("Tag");
				dataItem.SubItems.Add(link.Tag);
				dataItem = PropertyList.Items.Add("Type");
				dataItem.SubItems.Add(link.Type.ToString());
			}
			else if(fbObj is Device)
			{
				this.Text = "Device Property";
				Device dev = fbObj as Device;
				dataItem = PropertyList.Items.Add("ID");
				dataItem.SubItems.Add(dev.Id);
				dataItem = PropertyList.Items.Add("Tag");
				dataItem.SubItems.Add(dev.Tag);
				dataItem = PropertyList.Items.Add("Node Address");
				dataItem.SubItems.Add(dev.NodeAddress.ToString());
				dataItem = PropertyList.Items.Add("Flags");
				dataItem.SubItems.Add(dev.Flags.ToString());

				if(fbObj is HseDevice)
				{
					this.Text = "HSE Device Property";
					HseDevice hseDev = fbObj as HseDevice;
					dataItem = PropertyList.Items.Add("IP Address");
					dataItem.SubItems.Add(hseDev.IPAddress.ToString());
					dataItem = PropertyList.Items.Add("Device Index");
					dataItem.SubItems.Add(hseDev.DeviceIndex.ToString());
					dataItem = PropertyList.Items.Add("Max Device Index");
					dataItem.SubItems.Add(hseDev.MaxDeviceIndex.ToString());
					dataItem = PropertyList.Items.Add("HSE Repeat Time");
					dataItem.SubItems.Add(hseDev.HseRepeatTime.ToString());
					dataItem = PropertyList.Items.Add("State");
					dataItem.SubItems.Add(hseDev.State.ToString());
					dataItem = PropertyList.Items.Add("Type");
					dataItem.SubItems.Add(hseDev.Type.ToString());
					dataItem = PropertyList.Items.Add("Device Redundancy State");
					dataItem.SubItems.Add(hseDev.DeviceRedundancyState.ToString());
					dataItem = PropertyList.Items.Add("Duplicate Detection State");
					dataItem.SubItems.Add(hseDev.DuplicateDetectionState.ToString());
					dataItem = PropertyList.Items.Add("LAN Redundancy Port");
					dataItem.SubItems.Add(hseDev.LanRedundancyPort.ToString());
					dataItem = PropertyList.Items.Add("Annunciation Version Number");
					dataItem.SubItems.Add(hseDev.AnnunciationVersionNumber.ToString());
					dataItem = PropertyList.Items.Add("HSE Device Version Number");
					dataItem.SubItems.Add(hseDev.HseDeviceVersionNumber.ToString());
					dataItem = PropertyList.Items.Add("Num H1 Ports");
					dataItem.SubItems.Add(hseDev.NumberOfH1Ports.ToString());
					for(int i=0;i<hseDev.NumberOfH1Ports;i++)
					{
						dataItem = PropertyList.Items.Add("H1 Version List - "+i);
						dataItem.SubItems.Add(hseDev.H1VersionList[i].ToString());
					}
				}
			}
			else if(fbObj is Vfd)
			{
				this.Text = "VFD Property";
				Vfd vfd = fbObj as Vfd;
				dataItem = PropertyList.Items.Add("Tag");
				dataItem.SubItems.Add(vfd.Tag);
				dataItem = PropertyList.Items.Add("Vendor");
				dataItem.SubItems.Add(vfd.Vendor);
				dataItem = PropertyList.Items.Add("Model");
				dataItem.SubItems.Add(vfd.Model);
				dataItem = PropertyList.Items.Add("Revision");
				dataItem.SubItems.Add(vfd.Revision);
				dataItem = PropertyList.Items.Add("OD Version");
				dataItem.SubItems.Add(vfd.ODVersion.ToString());
				dataItem = PropertyList.Items.Add("Number of Transducer Blocks");
				dataItem.SubItems.Add(vfd.NumberOfTransducerBlocks.ToString());
				dataItem = PropertyList.Items.Add("Number of Function Blocks");
				dataItem.SubItems.Add(vfd.NumberOfFunctionBlocks.ToString());
				dataItem = PropertyList.Items.Add("Number of Action Objects");
				dataItem.SubItems.Add(vfd.NumberOfActionObjects.ToString());
				dataItem = PropertyList.Items.Add("Number of Link Objects");
				dataItem.SubItems.Add(vfd.NumberOfLinkObjects.ToString());
				dataItem = PropertyList.Items.Add("Number of Alert Objects");
				dataItem.SubItems.Add(vfd.NumberOfAlertObjects.ToString());
				dataItem = PropertyList.Items.Add("Number of Trend Objects");
				dataItem.SubItems.Add(vfd.NumberOfTrendObjects.ToString());
				dataItem = PropertyList.Items.Add("Number of Domain Objects");
				dataItem.SubItems.Add(vfd.NumberOfDomainObjects.ToString());
				dataItem = PropertyList.Items.Add("Number of Total Objects");
				dataItem.SubItems.Add(vfd.NumberOfTotalObjects.ToString());
			}
			else if(fbObj is Block)
			{
				this.Text = "Block Property";
				Block block = fbObj as Block;
				dataItem = PropertyList.Items.Add("Tag");
				dataItem.SubItems.Add(block.Tag);
				dataItem = PropertyList.Items.Add("Start Index");
				dataItem.SubItems.Add(block.StartIndex.ToString());
				dataItem = PropertyList.Items.Add("DD Name");
				dataItem.SubItems.Add(block.DDName.ToString());
				dataItem = PropertyList.Items.Add("DD Item");
				dataItem.SubItems.Add(block.DDItem.ToString());
				dataItem = PropertyList.Items.Add("DD Revision");
				dataItem.SubItems.Add(block.DDRevision.ToString());
				dataItem = PropertyList.Items.Add("Profile");
				dataItem.SubItems.Add(block.Profile.ToString());
				dataItem = PropertyList.Items.Add("Profile Revision");
				dataItem.SubItems.Add(block.ProfileRevision.ToString());
				dataItem = PropertyList.Items.Add("Execution Time");
				dataItem.SubItems.Add(block.ExecutionTime.ToString());
				dataItem = PropertyList.Items.Add("Period Execution");
				dataItem.SubItems.Add(block.PeriodExecution.ToString());
				dataItem = PropertyList.Items.Add("Number of Parameters");
				dataItem.SubItems.Add(block.NumberOfParameters.ToString());
				dataItem = PropertyList.Items.Add("Next FB");
				dataItem.SubItems.Add(block.NextBlockToExecute.ToString());
				dataItem = PropertyList.Items.Add("Start View Index");
				dataItem.SubItems.Add(block.StartViewIndex.ToString());
				dataItem = PropertyList.Items.Add("Number of View3");
				dataItem.SubItems.Add(block.NumberOfView3.ToString());
				dataItem = PropertyList.Items.Add("Number of View4");
				dataItem.SubItems.Add(block.NumberOfView4.ToString());
				dataItem = PropertyList.Items.Add("Ord Num");
				dataItem.SubItems.Add(block.OrdinalNumber.ToString());
				dataItem = PropertyList.Items.Add("Type");
				dataItem.SubItems.Add(block.Type.ToString());

			}
		}
	}
}
