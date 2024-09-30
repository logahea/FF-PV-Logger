using System;
using System.Text;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using NationalInstruments.FieldBus;
using NationalInstruments.FieldBus.ExceptionHandler;
using System.Threading;

namespace AdvDemo
{
	/// <summary>
	/// Summary description for WaitTrendForm.
	/// </summary>
	public class WaitTrendForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListView TrendInfo;
      private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button CloseBtn;
		private FBObject waiter;
      private ColumnHeader columnHeader1;
      private ColumnHeader columnHeader2;
      private ColumnHeader columnHeader3;
      private ColumnHeader columnHeader4;
      private ColumnHeader columnHeader5;
      private ColumnHeader columnHeader6;
      private ColumnHeader columnHeader7;
      private ColumnHeader columnHeader8;
		private Thread waitThread = null;
		public WaitTrendForm(FBObject waiter)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.waiter = waiter;
			waitThread = new Thread(new ThreadStart(WaitTrendThread));
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaitTrendForm));
            this.TrendInfo = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CloseBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TrendInfo
            // 
            this.TrendInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.TrendInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.TrendInfo.FullRowSelect = true;
            this.TrendInfo.GridLines = true;
            this.TrendInfo.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.TrendInfo.HideSelection = false;
            this.TrendInfo.Location = new System.Drawing.Point(0, 0);
            this.TrendInfo.MultiSelect = false;
            this.TrendInfo.Name = "TrendInfo";
            this.TrendInfo.Size = new System.Drawing.Size(495, 258);
            this.TrendInfo.TabIndex = 0;
            this.TrendInfo.UseCompatibleStateImageBehavior = false;
            this.TrendInfo.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Trend Type";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Device Tag";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Block Tag";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Parameter Name";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Sample Type";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Last Update";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Status";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Trend Data";
            // 
            // CloseBtn
            // 
            this.CloseBtn.Location = new System.Drawing.Point(230, 268);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(106, 27);
            this.CloseBtn.TabIndex = 1;
            this.CloseBtn.Text = "Close";
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // WaitTrendForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(495, 267);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.TrendInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WaitTrendForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Wait Trend ...";
            this.Load += new System.EventHandler(this.WaitTrendForm_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void WaitTrendThread()
		{
			while(true)
			{
				try
				{
					Trend trend = waiter.WaitTrend();

					TrendInfo.BeginUpdate();
					// Refresh the trend data
               ListViewItem dataItem = TrendInfo.Items.Add(trend.Type.ToString());

               dataItem.SubItems.Add(trend.DeviceTag);
			
					dataItem.SubItems.Add(trend.BlockTag);
			
					dataItem.SubItems.Add(trend.ParameterName);
			
					dataItem.SubItems.Add(trend.SampleType.ToString());
			
					dataItem.SubItems.Add(trend.LastUpdate.Lower.ToString()+":"+trend.LastUpdate.Upper.ToString());
			
					StringBuilder sb = new StringBuilder();
					foreach (Byte state in trend.Status)
					{
						sb.Append(state.ToString()+",");
					}
					dataItem.SubItems.Add(sb.ToString());
			
					StringBuilder sb1 = new StringBuilder();
					switch(trend.Type)
					{
						case TrendType.TREND_FLOAT:
							foreach(float v in (trend.Data as float[]))
							{
								sb1.Append(v.ToString()+",");
							}
							break;
						case TrendType.TREND_BITSTRING:
						case TrendType.TREND_DISCRETE:
							foreach(byte v in (trend.Data as byte[]))
							{
								sb1.Append(v.ToString()+",");
							}
							break;				
					}
					dataItem.SubItems.Add(sb1.ToString());
				}
				catch(Exception ex)
				{
					Console.WriteLine(ex);
					break;
				}
				finally
				{
					TrendInfo.EndUpdate();
				}
			}

		}
			
		private void CloseBtn_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void WaitTrendForm_Load(object sender, System.EventArgs e)
		{
			waitThread.Start();
		}



	}
}
