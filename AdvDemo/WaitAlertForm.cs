using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using NationalInstruments.FieldBus.ExceptionHandler;
using NationalInstruments.FieldBus;
using System.Threading;

namespace AdvDemo
{
	/// <summary>
	/// Summary description for WaitAlertForm.
	/// </summary>
	public class WaitAlertForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button CloseBtn;
		private System.Windows.Forms.Button AckBtn;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button WaitBtn;
		private System.Windows.Forms.ListView AlertInfo;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.NumericUpDown Priority;
		private FBObject waiter;
		private Thread waitThread = null;
        private ColumnHeader columnHeader8;
        private Button WaitAlert2;
        private bool isWaitAlert2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public WaitAlertForm(FBObject waiter)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
			this.waiter = waiter;
			
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaitAlertForm));
            this.AlertInfo = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CloseBtn = new System.Windows.Forms.Button();
            this.AckBtn = new System.Windows.Forms.Button();
            this.Priority = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.WaitBtn = new System.Windows.Forms.Button();
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.WaitAlert2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Priority)).BeginInit();
            this.SuspendLayout();
            // 
            // AlertInfo
            // 
            this.AlertInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.AlertInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.AlertInfo.FullRowSelect = true;
            this.AlertInfo.GridLines = true;
            this.AlertInfo.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.AlertInfo.Location = new System.Drawing.Point(0, 0);
            this.AlertInfo.Name = "AlertInfo";
            this.AlertInfo.Size = new System.Drawing.Size(513, 224);
            this.AlertInfo.TabIndex = 0;
            this.AlertInfo.UseCompatibleStateImageBehavior = false;
            this.AlertInfo.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Type";
            this.columnHeader1.Width = 85;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Device Tag";
            this.columnHeader2.Width = 74;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Block Tag";
            this.columnHeader3.Width = 65;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Name";
            this.columnHeader4.Width = 70;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Priority";
            this.columnHeader5.Width = 48;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Subcode";
            this.columnHeader6.Width = 59;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Key";
            this.columnHeader7.Width = 44;
            // 
            // CloseBtn
            // 
            this.CloseBtn.Location = new System.Drawing.Point(405, 239);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(80, 24);
            this.CloseBtn.TabIndex = 1;
            this.CloseBtn.Text = "Close";
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // AckBtn
            // 
            this.AckBtn.Location = new System.Drawing.Point(310, 239);
            this.AckBtn.Name = "AckBtn";
            this.AckBtn.Size = new System.Drawing.Size(80, 24);
            this.AckBtn.TabIndex = 2;
            this.AckBtn.Text = "Acknowledge";
            this.AckBtn.Click += new System.EventHandler(this.AckBtn_Click);
            // 
            // Priority
            // 
            this.Priority.Location = new System.Drawing.Point(51, 241);
            this.Priority.Name = "Priority";
            this.Priority.Size = new System.Drawing.Size(48, 20);
            this.Priority.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 244);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Priority";
            // 
            // WaitBtn
            // 
            this.WaitBtn.Location = new System.Drawing.Point(120, 239);
            this.WaitBtn.Name = "WaitBtn";
            this.WaitBtn.Size = new System.Drawing.Size(80, 24);
            this.WaitBtn.TabIndex = 2;
            this.WaitBtn.Text = "Wait Alert";
            this.WaitBtn.Click += new System.EventHandler(this.WaitBtn_Click);
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Value";
            // 
            // WaitAlert2
            // 
            this.WaitAlert2.Location = new System.Drawing.Point(215, 239);
            this.WaitAlert2.Name = "WaitAlert2";
            this.WaitAlert2.Size = new System.Drawing.Size(80, 24);
            this.WaitAlert2.TabIndex = 2;
            this.WaitAlert2.Text = "Wait Alert 2";
            this.WaitAlert2.Click += new System.EventHandler(this.WaitAlert2_Click);
            // 
            // WaitAlertForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(513, 268);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Priority);
            this.Controls.Add(this.AckBtn);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.AlertInfo);
            this.Controls.Add(this.WaitAlert2);
            this.Controls.Add(this.WaitBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WaitAlertForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Wait Alert Ready";
            ((System.ComponentModel.ISupportInitialize)(this.Priority)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void CloseBtn_Click(object sender, System.EventArgs e)
		{
			Close();
		}

        private void WaitAlertOperater(byte priority)
        {
            Alert alertData = waiter.WaitAlert(priority);
            ListViewItem dataItem = AlertInfo.Items.Add(alertData.Type.ToString());
            dataItem.SubItems.Add(alertData.DeviceTag);
            dataItem.SubItems.Add(alertData.BlockTag);
            dataItem.SubItems.Add(alertData.Name);
            dataItem.SubItems.Add(alertData.Priority.ToString());
            dataItem.SubItems.Add(alertData.SubCode.ToString());
            dataItem.SubItems.Add(alertData.Key.ToString());

            switch (alertData.Type)
            {
                case AlertType.ALERT_ANALOG:
                    dataItem.SubItems.Add(((Single)(alertData.Data)).ToString());
                    break;
                case AlertType.ALERT_DISCRETE:
                    dataItem.SubItems.Add(((Byte)(alertData.Data)).ToString());
                    break;
                case AlertType.ALERT_UPDATE:
                    dataItem.SubItems.Add(((Int16)(alertData.Data)).ToString());
                    break;
                default:
                    dataItem.SubItems.Add("");
                    break;
            }
        }

        private void WaitAlert2Operater(byte priority)
        {
            Alert alertData = waiter.WaitAlert2(priority);
            ListViewItem dataItem = AlertInfo.Items.Add(alertData.Type.ToString());
            dataItem.SubItems.Add(alertData.DeviceTag);
            dataItem.SubItems.Add(alertData.BlockTag);
            dataItem.SubItems.Add(alertData.Name);
            dataItem.SubItems.Add(alertData.Priority.ToString());
            dataItem.SubItems.Add(alertData.SubCode.ToString());
            dataItem.SubItems.Add(alertData.Key.ToString());

            switch (alertData.Type)
            {
                case AlertType.ALERT_ANALOG:
                    dataItem.SubItems.Add(((AnalogAlertData)(alertData.Data)).Value.ToString());
                    break;
                case AlertType.ALERT_DISCRETE:
                    dataItem.SubItems.Add(((DiscreteAlertData)(alertData.Data)).Value.ToString());
                    break;
                case AlertType.ALERT_UPDATE:
                    dataItem.SubItems.Add(((UpdateAlertData)(alertData.Data)).RelativeIndex.ToString());
                    break;
                case AlertType.ALERT_STANDARD_DIAGNOSTICS:
                    dataItem.SubItems.Add(((StandardDiagnosticsAlertData)(alertData.Data)).Value.ToString());
                    break;
                default:
                    dataItem.SubItems.Add("");
                    break;
            }
        }

		private void WaitAlertThread()
		{
			try
			{
				//this.Text = "Waiting Alert ... ";
				AlertInfo.BeginUpdate();
				WaitBtn.Enabled = false;
                WaitAlert2.Enabled = false;
				Priority.Enabled = false;
                if (isWaitAlert2)
                {
                    WaitAlert2Operater((byte)Priority.Value);
                }
                else
                {
                    WaitAlertOperater((byte)Priority.Value);
                }
			}
			catch(Exception)
			{
			}
			finally
			{
				WaitBtn.Enabled = true;
                WaitAlert2.Enabled = true;
				Priority.Enabled = true;
				AlertInfo.EndUpdate();
				this.Text = "Wait Alert Ready";
			}
		}

		private void WaitBtn_Click(object sender, System.EventArgs e)
		{
            isWaitAlert2 = false;
            waitThread = new Thread(new ThreadStart(WaitAlertThread));
            
			waitThread.Start();
		}

		private void AckBtn_Click(object sender, System.EventArgs e)
		{
			if(AlertInfo.SelectedItems.Count == 0)
			{
				return;
			}
			AckBtn.Enabled = false;
			WaitBtn.Enabled = false;
			Priority.Enabled = false;
			foreach(ListViewItem dataItem in AlertInfo.SelectedItems)
			{
				try
				{
					waiter.AcknowledgeAlarm(dataItem.SubItems[1].Text+"."+dataItem.SubItems[2].Text);
				}
				catch(Exception)
				{
				}
				finally
				{
					AlertInfo.Items.Remove(dataItem);
				}
			}
			AckBtn.Enabled = true;
			WaitBtn.Enabled = true;
			Priority.Enabled = true;
		}

        private void WaitAlert2_Click(object sender, EventArgs e)
        {
            isWaitAlert2 = true;
            waitThread = new Thread(new ThreadStart(WaitAlertThread));
            waitThread.Start();
        }
	}
}
