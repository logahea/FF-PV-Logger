/*
 * Copyright (c) 2005 National Instruments Corp. All rights reserved
 * Main.cs
 * implementation of handling the initial steps before read or write parameters
 */

/* This example aims to demonstrate how to use CM APIs with C# under .NET framework.
 * NationalInstruments.fbus must be referenced which contains CM APIs.
 * This assembly is composed by twelve files.
 * Main.cs handles the initial steps before read or write parameters.
 * ReadWrite.cs lists all the parameters of a definite block, shows the definite parameter's value and selects the definite parameter to write.
 * Ten files whose names begin with Edit handle the function of writing paramter depending on the paramter's type.  
 */
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using NationalInstruments.FieldBus;
using NationalInstruments.FieldBus.ExceptionHandler;

namespace AdvDemo
{
	/// <summary>
	/// Summary description for MainForm.
	/// </summary>
	/// 
	
	public class MainForm : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components;
		/// <summary>
		/// 
		/// </summary>

		// variant shared in all the functions in this form
		private Session    mainSession = new Session();
		private System.Windows.Forms.StatusBar MainStatus;
		private System.Windows.Forms.StatusBarPanel TimerStatus;
		private System.Windows.Forms.Timer Timer;
		private System.Windows.Forms.StatusBarPanel MessageStatus;
		private System.Windows.Forms.ContextMenu MainPop;
		private System.Windows.Forms.MenuItem MenuOpen;
		private System.Windows.Forms.MenuItem MenuClose;
		private System.Windows.Forms.MainMenu MainMenu;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem ExitMenu;
		private System.Windows.Forms.MenuItem AboutMenu;
		private System.Windows.Forms.ImageList MainImageList;
		private System.Windows.Forms.MenuItem MenuWaitAlert;
		private System.Windows.Forms.MenuItem MenuWaitTrend;
		private System.Windows.Forms.Button btnSession;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Button btnLink;
		private System.Windows.Forms.Button btnDevice;
		private System.Windows.Forms.Button btnBlock;
		private System.Windows.Forms.TreeView MainTree;

		private enum NodeType
		{
			LinkNode, DeviceNode,FBAPNode,MIBNode,BlockNode
		}
		public MainForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			TimerStatus.Text = 	DateTime.Now.ToLocalTime().ToString();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainForm));
			this.btnSession = new System.Windows.Forms.Button();
			this.btnExit = new System.Windows.Forms.Button();
			this.btnLink = new System.Windows.Forms.Button();
			this.btnDevice = new System.Windows.Forms.Button();
			this.btnBlock = new System.Windows.Forms.Button();
			this.MainStatus = new System.Windows.Forms.StatusBar();
			this.MessageStatus = new System.Windows.Forms.StatusBarPanel();
			this.TimerStatus = new System.Windows.Forms.StatusBarPanel();
			this.Timer = new System.Windows.Forms.Timer(this.components);
			this.MainTree = new System.Windows.Forms.TreeView();
			this.MainPop = new System.Windows.Forms.ContextMenu();
			this.MenuOpen = new System.Windows.Forms.MenuItem();
			this.MenuClose = new System.Windows.Forms.MenuItem();
			this.MenuWaitAlert = new System.Windows.Forms.MenuItem();
			this.MenuWaitTrend = new System.Windows.Forms.MenuItem();
			this.MainImageList = new System.Windows.Forms.ImageList(this.components);
			this.MainMenu = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.ExitMenu = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.AboutMenu = new System.Windows.Forms.MenuItem();
			((System.ComponentModel.ISupportInitialize)(this.MessageStatus)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TimerStatus)).BeginInit();
			this.SuspendLayout();
			// 
			// btnSession
			// 
			this.btnSession.AccessibleDescription = resources.GetString("btnSession.AccessibleDescription");
			this.btnSession.AccessibleName = resources.GetString("btnSession.AccessibleName");
			this.btnSession.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnSession.Anchor")));
			this.btnSession.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSession.BackgroundImage")));
			this.btnSession.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnSession.Dock")));
			this.btnSession.Enabled = ((bool)(resources.GetObject("btnSession.Enabled")));
			this.btnSession.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnSession.FlatStyle")));
			this.btnSession.Font = ((System.Drawing.Font)(resources.GetObject("btnSession.Font")));
			this.btnSession.Image = ((System.Drawing.Image)(resources.GetObject("btnSession.Image")));
			this.btnSession.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnSession.ImageAlign")));
			this.btnSession.ImageIndex = ((int)(resources.GetObject("btnSession.ImageIndex")));
			this.btnSession.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnSession.ImeMode")));
			this.btnSession.Location = ((System.Drawing.Point)(resources.GetObject("btnSession.Location")));
			this.btnSession.Name = "btnSession";
			this.btnSession.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnSession.RightToLeft")));
			this.btnSession.Size = ((System.Drawing.Size)(resources.GetObject("btnSession.Size")));
			this.btnSession.TabIndex = ((int)(resources.GetObject("btnSession.TabIndex")));
			this.btnSession.Text = resources.GetString("btnSession.Text");
			this.btnSession.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnSession.TextAlign")));
			this.btnSession.Visible = ((bool)(resources.GetObject("btnSession.Visible")));
			this.btnSession.Click += new System.EventHandler(this.Session_Click);
			// 
			// btnExit
			// 
			this.btnExit.AccessibleDescription = resources.GetString("btnExit.AccessibleDescription");
			this.btnExit.AccessibleName = resources.GetString("btnExit.AccessibleName");
			this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnExit.Anchor")));
			this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
			this.btnExit.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnExit.Dock")));
			this.btnExit.Enabled = ((bool)(resources.GetObject("btnExit.Enabled")));
			this.btnExit.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnExit.FlatStyle")));
			this.btnExit.Font = ((System.Drawing.Font)(resources.GetObject("btnExit.Font")));
			this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
			this.btnExit.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnExit.ImageAlign")));
			this.btnExit.ImageIndex = ((int)(resources.GetObject("btnExit.ImageIndex")));
			this.btnExit.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnExit.ImeMode")));
			this.btnExit.Location = ((System.Drawing.Point)(resources.GetObject("btnExit.Location")));
			this.btnExit.Name = "btnExit";
			this.btnExit.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnExit.RightToLeft")));
			this.btnExit.Size = ((System.Drawing.Size)(resources.GetObject("btnExit.Size")));
			this.btnExit.TabIndex = ((int)(resources.GetObject("btnExit.TabIndex")));
			this.btnExit.Text = resources.GetString("btnExit.Text");
			this.btnExit.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnExit.TextAlign")));
			this.btnExit.Visible = ((bool)(resources.GetObject("btnExit.Visible")));
			this.btnExit.Click += new System.EventHandler(this.Exit_Click);
			// 
			// btnLink
			// 
			this.btnLink.AccessibleDescription = resources.GetString("btnLink.AccessibleDescription");
			this.btnLink.AccessibleName = resources.GetString("btnLink.AccessibleName");
			this.btnLink.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnLink.Anchor")));
			this.btnLink.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLink.BackgroundImage")));
			this.btnLink.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnLink.Dock")));
			this.btnLink.Enabled = ((bool)(resources.GetObject("btnLink.Enabled")));
			this.btnLink.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnLink.FlatStyle")));
			this.btnLink.Font = ((System.Drawing.Font)(resources.GetObject("btnLink.Font")));
			this.btnLink.Image = ((System.Drawing.Image)(resources.GetObject("btnLink.Image")));
			this.btnLink.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnLink.ImageAlign")));
			this.btnLink.ImageIndex = ((int)(resources.GetObject("btnLink.ImageIndex")));
			this.btnLink.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnLink.ImeMode")));
			this.btnLink.Location = ((System.Drawing.Point)(resources.GetObject("btnLink.Location")));
			this.btnLink.Name = "btnLink";
			this.btnLink.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnLink.RightToLeft")));
			this.btnLink.Size = ((System.Drawing.Size)(resources.GetObject("btnLink.Size")));
			this.btnLink.TabIndex = ((int)(resources.GetObject("btnLink.TabIndex")));
			this.btnLink.Text = resources.GetString("btnLink.Text");
			this.btnLink.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnLink.TextAlign")));
			this.btnLink.Visible = ((bool)(resources.GetObject("btnLink.Visible")));
			this.btnLink.Click += new System.EventHandler(this.Link_Click);
			// 
			// btnDevice
			// 
			this.btnDevice.AccessibleDescription = resources.GetString("btnDevice.AccessibleDescription");
			this.btnDevice.AccessibleName = resources.GetString("btnDevice.AccessibleName");
			this.btnDevice.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnDevice.Anchor")));
			this.btnDevice.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDevice.BackgroundImage")));
			this.btnDevice.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnDevice.Dock")));
			this.btnDevice.Enabled = ((bool)(resources.GetObject("btnDevice.Enabled")));
			this.btnDevice.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnDevice.FlatStyle")));
			this.btnDevice.Font = ((System.Drawing.Font)(resources.GetObject("btnDevice.Font")));
			this.btnDevice.Image = ((System.Drawing.Image)(resources.GetObject("btnDevice.Image")));
			this.btnDevice.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnDevice.ImageAlign")));
			this.btnDevice.ImageIndex = ((int)(resources.GetObject("btnDevice.ImageIndex")));
			this.btnDevice.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnDevice.ImeMode")));
			this.btnDevice.Location = ((System.Drawing.Point)(resources.GetObject("btnDevice.Location")));
			this.btnDevice.Name = "btnDevice";
			this.btnDevice.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnDevice.RightToLeft")));
			this.btnDevice.Size = ((System.Drawing.Size)(resources.GetObject("btnDevice.Size")));
			this.btnDevice.TabIndex = ((int)(resources.GetObject("btnDevice.TabIndex")));
			this.btnDevice.Text = resources.GetString("btnDevice.Text");
			this.btnDevice.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnDevice.TextAlign")));
			this.btnDevice.Visible = ((bool)(resources.GetObject("btnDevice.Visible")));
			this.btnDevice.Click += new System.EventHandler(this.Device_Click);
			// 
			// btnBlock
			// 
			this.btnBlock.AccessibleDescription = resources.GetString("btnBlock.AccessibleDescription");
			this.btnBlock.AccessibleName = resources.GetString("btnBlock.AccessibleName");
			this.btnBlock.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnBlock.Anchor")));
			this.btnBlock.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBlock.BackgroundImage")));
			this.btnBlock.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnBlock.Dock")));
			this.btnBlock.Enabled = ((bool)(resources.GetObject("btnBlock.Enabled")));
			this.btnBlock.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnBlock.FlatStyle")));
			this.btnBlock.Font = ((System.Drawing.Font)(resources.GetObject("btnBlock.Font")));
			this.btnBlock.Image = ((System.Drawing.Image)(resources.GetObject("btnBlock.Image")));
			this.btnBlock.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnBlock.ImageAlign")));
			this.btnBlock.ImageIndex = ((int)(resources.GetObject("btnBlock.ImageIndex")));
			this.btnBlock.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnBlock.ImeMode")));
			this.btnBlock.Location = ((System.Drawing.Point)(resources.GetObject("btnBlock.Location")));
			this.btnBlock.Name = "btnBlock";
			this.btnBlock.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnBlock.RightToLeft")));
			this.btnBlock.Size = ((System.Drawing.Size)(resources.GetObject("btnBlock.Size")));
			this.btnBlock.TabIndex = ((int)(resources.GetObject("btnBlock.TabIndex")));
			this.btnBlock.Text = resources.GetString("btnBlock.Text");
			this.btnBlock.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnBlock.TextAlign")));
			this.btnBlock.Visible = ((bool)(resources.GetObject("btnBlock.Visible")));
			this.btnBlock.Click += new System.EventHandler(this.Block_Click);
			// 
			// MainStatus
			// 
			this.MainStatus.AccessibleDescription = resources.GetString("MainStatus.AccessibleDescription");
			this.MainStatus.AccessibleName = resources.GetString("MainStatus.AccessibleName");
			this.MainStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("MainStatus.Anchor")));
			this.MainStatus.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MainStatus.BackgroundImage")));
			this.MainStatus.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("MainStatus.Dock")));
			this.MainStatus.Enabled = ((bool)(resources.GetObject("MainStatus.Enabled")));
			this.MainStatus.Font = ((System.Drawing.Font)(resources.GetObject("MainStatus.Font")));
			this.MainStatus.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("MainStatus.ImeMode")));
			this.MainStatus.Location = ((System.Drawing.Point)(resources.GetObject("MainStatus.Location")));
			this.MainStatus.Name = "MainStatus";
			this.MainStatus.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						  this.MessageStatus,
																						  this.TimerStatus});
			this.MainStatus.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("MainStatus.RightToLeft")));
			this.MainStatus.ShowPanels = true;
			this.MainStatus.Size = ((System.Drawing.Size)(resources.GetObject("MainStatus.Size")));
			this.MainStatus.SizingGrip = false;
			this.MainStatus.TabIndex = ((int)(resources.GetObject("MainStatus.TabIndex")));
			this.MainStatus.Text = resources.GetString("MainStatus.Text");
			this.MainStatus.Visible = ((bool)(resources.GetObject("MainStatus.Visible")));
			// 
			// MessageStatus
			// 
			this.MessageStatus.Alignment = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("MessageStatus.Alignment")));
			this.MessageStatus.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.MessageStatus.Icon = ((System.Drawing.Icon)(resources.GetObject("MessageStatus.Icon")));
			this.MessageStatus.MinWidth = ((int)(resources.GetObject("MessageStatus.MinWidth")));
			this.MessageStatus.Text = resources.GetString("MessageStatus.Text");
			this.MessageStatus.ToolTipText = resources.GetString("MessageStatus.ToolTipText");
			this.MessageStatus.Width = ((int)(resources.GetObject("MessageStatus.Width")));
			// 
			// TimerStatus
			// 
			this.TimerStatus.Alignment = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("TimerStatus.Alignment")));
			this.TimerStatus.Icon = ((System.Drawing.Icon)(resources.GetObject("TimerStatus.Icon")));
			this.TimerStatus.MinWidth = ((int)(resources.GetObject("TimerStatus.MinWidth")));
			this.TimerStatus.Text = resources.GetString("TimerStatus.Text");
			this.TimerStatus.ToolTipText = resources.GetString("TimerStatus.ToolTipText");
			this.TimerStatus.Width = ((int)(resources.GetObject("TimerStatus.Width")));
			// 
			// Timer
			// 
			this.Timer.Enabled = true;
			this.Timer.Interval = 1000;
			this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
			// 
			// MainTree
			// 
			this.MainTree.AccessibleDescription = resources.GetString("MainTree.AccessibleDescription");
			this.MainTree.AccessibleName = resources.GetString("MainTree.AccessibleName");
			this.MainTree.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("MainTree.Anchor")));
			this.MainTree.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MainTree.BackgroundImage")));
			this.MainTree.ContextMenu = this.MainPop;
			this.MainTree.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("MainTree.Dock")));
			this.MainTree.Enabled = ((bool)(resources.GetObject("MainTree.Enabled")));
			this.MainTree.Font = ((System.Drawing.Font)(resources.GetObject("MainTree.Font")));
			this.MainTree.FullRowSelect = true;
			this.MainTree.ImageIndex = ((int)(resources.GetObject("MainTree.ImageIndex")));
			this.MainTree.ImageList = this.MainImageList;
			this.MainTree.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("MainTree.ImeMode")));
			this.MainTree.Indent = ((int)(resources.GetObject("MainTree.Indent")));
			this.MainTree.ItemHeight = ((int)(resources.GetObject("MainTree.ItemHeight")));
			this.MainTree.Location = ((System.Drawing.Point)(resources.GetObject("MainTree.Location")));
			this.MainTree.Name = "MainTree";
			this.MainTree.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("MainTree.RightToLeft")));
			this.MainTree.SelectedImageIndex = ((int)(resources.GetObject("MainTree.SelectedImageIndex")));
			this.MainTree.Size = ((System.Drawing.Size)(resources.GetObject("MainTree.Size")));
			this.MainTree.TabIndex = ((int)(resources.GetObject("MainTree.TabIndex")));
			this.MainTree.Text = resources.GetString("MainTree.Text");
			this.MainTree.Visible = ((bool)(resources.GetObject("MainTree.Visible")));
			this.MainTree.DoubleClick += new System.EventHandler(this.MainTree_DoubleClick);
			this.MainTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.MainTree_AfterSelect);
			// 
			// MainPop
			// 
			this.MainPop.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.MenuOpen,
																					this.MenuClose,
																					this.MenuWaitAlert,
																					this.MenuWaitTrend});
			this.MainPop.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("MainPop.RightToLeft")));
			this.MainPop.Popup += new System.EventHandler(this.MainPop_Popup);
			// 
			// MenuOpen
			// 
			this.MenuOpen.Enabled = ((bool)(resources.GetObject("MenuOpen.Enabled")));
			this.MenuOpen.Index = 0;
			this.MenuOpen.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("MenuOpen.Shortcut")));
			this.MenuOpen.ShowShortcut = ((bool)(resources.GetObject("MenuOpen.ShowShortcut")));
			this.MenuOpen.Text = resources.GetString("MenuOpen.Text");
			this.MenuOpen.Visible = ((bool)(resources.GetObject("MenuOpen.Visible")));
			// 
			// MenuClose
			// 
			this.MenuClose.Enabled = ((bool)(resources.GetObject("MenuClose.Enabled")));
			this.MenuClose.Index = 1;
			this.MenuClose.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("MenuClose.Shortcut")));
			this.MenuClose.ShowShortcut = ((bool)(resources.GetObject("MenuClose.ShowShortcut")));
			this.MenuClose.Text = resources.GetString("MenuClose.Text");
			this.MenuClose.Visible = ((bool)(resources.GetObject("MenuClose.Visible")));
			// 
			// MenuWaitAlert
			// 
			this.MenuWaitAlert.Enabled = ((bool)(resources.GetObject("MenuWaitAlert.Enabled")));
			this.MenuWaitAlert.Index = 2;
			this.MenuWaitAlert.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("MenuWaitAlert.Shortcut")));
			this.MenuWaitAlert.ShowShortcut = ((bool)(resources.GetObject("MenuWaitAlert.ShowShortcut")));
			this.MenuWaitAlert.Text = resources.GetString("MenuWaitAlert.Text");
			this.MenuWaitAlert.Visible = ((bool)(resources.GetObject("MenuWaitAlert.Visible")));
			this.MenuWaitAlert.Click += new System.EventHandler(this.MenuWaitAlert_Click);
			// 
			// MenuWaitTrend
			// 
			this.MenuWaitTrend.Enabled = ((bool)(resources.GetObject("MenuWaitTrend.Enabled")));
			this.MenuWaitTrend.Index = 3;
			this.MenuWaitTrend.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("MenuWaitTrend.Shortcut")));
			this.MenuWaitTrend.ShowShortcut = ((bool)(resources.GetObject("MenuWaitTrend.ShowShortcut")));
			this.MenuWaitTrend.Text = resources.GetString("MenuWaitTrend.Text");
			this.MenuWaitTrend.Visible = ((bool)(resources.GetObject("MenuWaitTrend.Visible")));
			this.MenuWaitTrend.Click += new System.EventHandler(this.MenuWaitTrend_Click);
			// 
			// MainImageList
			// 
			this.MainImageList.ImageSize = ((System.Drawing.Size)(resources.GetObject("MainImageList.ImageSize")));
			this.MainImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("MainImageList.ImageStream")));
			this.MainImageList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// MainMenu
			// 
			this.MainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuItem1,
																					 this.menuItem2});
			this.MainMenu.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("MainMenu.RightToLeft")));
			// 
			// menuItem1
			// 
			this.menuItem1.Enabled = ((bool)(resources.GetObject("menuItem1.Enabled")));
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.ExitMenu});
			this.menuItem1.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuItem1.Shortcut")));
			this.menuItem1.ShowShortcut = ((bool)(resources.GetObject("menuItem1.ShowShortcut")));
			this.menuItem1.Text = resources.GetString("menuItem1.Text");
			this.menuItem1.Visible = ((bool)(resources.GetObject("menuItem1.Visible")));
			// 
			// ExitMenu
			// 
			this.ExitMenu.Enabled = ((bool)(resources.GetObject("ExitMenu.Enabled")));
			this.ExitMenu.Index = 0;
			this.ExitMenu.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("ExitMenu.Shortcut")));
			this.ExitMenu.ShowShortcut = ((bool)(resources.GetObject("ExitMenu.ShowShortcut")));
			this.ExitMenu.Text = resources.GetString("ExitMenu.Text");
			this.ExitMenu.Visible = ((bool)(resources.GetObject("ExitMenu.Visible")));
			// 
			// menuItem2
			// 
			this.menuItem2.Enabled = ((bool)(resources.GetObject("menuItem2.Enabled")));
			this.menuItem2.Index = 1;
			this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.AboutMenu});
			this.menuItem2.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuItem2.Shortcut")));
			this.menuItem2.ShowShortcut = ((bool)(resources.GetObject("menuItem2.ShowShortcut")));
			this.menuItem2.Text = resources.GetString("menuItem2.Text");
			this.menuItem2.Visible = ((bool)(resources.GetObject("menuItem2.Visible")));
			// 
			// AboutMenu
			// 
			this.AboutMenu.Enabled = ((bool)(resources.GetObject("AboutMenu.Enabled")));
			this.AboutMenu.Index = 0;
			this.AboutMenu.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("AboutMenu.Shortcut")));
			this.AboutMenu.ShowShortcut = ((bool)(resources.GetObject("AboutMenu.ShowShortcut")));
			this.AboutMenu.Text = resources.GetString("AboutMenu.Text");
			this.AboutMenu.Visible = ((bool)(resources.GetObject("AboutMenu.Visible")));
			// 
			// MainForm
			// 
			this.AccessibleDescription = resources.GetString("$this.AccessibleDescription");
			this.AccessibleName = resources.GetString("$this.AccessibleName");
			this.AutoScaleBaseSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScaleBaseSize")));
			this.AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
			this.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMargin")));
			this.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMinSize")));
			this.BackColor = System.Drawing.SystemColors.Control;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = ((System.Drawing.Size)(resources.GetObject("$this.ClientSize")));
			this.Controls.Add(this.MainTree);
			this.Controls.Add(this.MainStatus);
			this.Controls.Add(this.btnBlock);
			this.Controls.Add(this.btnDevice);
			this.Controls.Add(this.btnLink);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.btnSession);
			this.Enabled = ((bool)(resources.GetObject("$this.Enabled")));
			this.Font = ((System.Drawing.Font)(resources.GetObject("$this.Font")));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode")));
			this.Location = ((System.Drawing.Point)(resources.GetObject("$this.Location")));
			this.MaximizeBox = false;
			this.MaximumSize = ((System.Drawing.Size)(resources.GetObject("$this.MaximumSize")));
			this.Menu = this.MainMenu;
			this.MinimumSize = ((System.Drawing.Size)(resources.GetObject("$this.MinimumSize")));
			this.Name = "MainForm";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
			this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
			this.Text = resources.GetString("$this.Text");
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.Closed += new System.EventHandler(this.Exit_Click);
			((System.ComponentModel.ISupportInitialize)(this.MessageStatus)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TimerStatus)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}

		private void Session_Click(object sender, System.EventArgs e)
		{
			MainTree.Nodes.Clear();
			MessageStatus.Text = " Open session ...";
			try
			{
				mainSession.Close();
				mainSession.Open();

				MainTree.BeginUpdate();
				MainTree.Nodes.Clear();
				TreeNode tmpNode = null;
				foreach (Link link in mainSession.Links)
				{
					tmpNode = MainTree.Nodes.Add(link.Tag);
					tmpNode.Tag = NodeType.LinkNode;
					tmpNode.ImageIndex = (int)link.Type;
					tmpNode.SelectedImageIndex = tmpNode.ImageIndex;
				}		

				MainTree.EndUpdate();
				MessageStatus.Text += " successful";
			}
			catch(FBException exp)
			{
				MessageStatus.Text = exp.Message;
				mainSession.Close();
			}
		}

		private void Exit_Click(object sender, System.EventArgs e)
		{
			mainSession.Close();
			Application.Exit();
		}

		private void Link_Click(object sender, System.EventArgs e)
		{
			TreeNode node = MainTree.SelectedNode;
			if((node == null)||((NodeType)node.Tag!=NodeType.LinkNode))
			{
				return;
			}
			node.Nodes.Clear();

			MessageStatus.Text = " Open Link "+node.Text+" ...";

			try
			{
				Link link = mainSession.GetLinkByTag(node.Text);
				link.Close();
				link.Open();

				MainTree.BeginUpdate();
				TreeNode tmpNode = null;
				foreach (Device device in link.Devices)
				{
					tmpNode = node.Nodes.Add(device.Tag);
					tmpNode.Tag = NodeType.DeviceNode;
				}
				MainTree.EndUpdate();
				node.Expand();
				MessageStatus.Text +=  " successful";
			}
			catch(FBException exp)
			{
				MessageStatus.Text = exp.Message;
			}
			
		}
		private void LinkClose(object  sender, System.EventArgs e)
		{
			TreeNode node = MainTree.SelectedNode;
			if((node==null)||((NodeType)node.Tag!=NodeType.LinkNode))
			{
				return;
			}
			try
			{
				MessageStatus.Text = " Close Link "+node.Text+" ...";
				Link link = mainSession.GetLinkByTag(node.Text);
				link.Close();
				MessageStatus.Text += " successful";
			}
			catch(Exception exp)
			{
				MessageStatus.Text = exp.Message;
			}
			finally
			{
				node.Nodes.Clear();
			}

		}
		private void Device_Click(object sender, System.EventArgs e)
		{
			TreeNode node = MainTree.SelectedNode;
			TreeNode subNode = null;
			if((node == null)||((NodeType)node.Tag!=NodeType.DeviceNode))
			{
				return;
			}
			node.Nodes.Clear();

			MessageStatus.Text =" Open Physical Device "+node.Text+" ...";
			
			try
			{
				Device device = mainSession.GetLinkByTag(node.Parent.Text).GetDeviceByTag(node.Text);
				device.Close();
				device.Open();
				MainTree.BeginUpdate();
				TreeNode tmpNode = null;
				tmpNode = node.Nodes.Add("MIB");
				tmpNode.Tag = NodeType.MIBNode;
				tmpNode.ImageIndex = 8;
				tmpNode.SelectedImageIndex = tmpNode.ImageIndex;

				foreach (Vfd vfd in device.Vfds)
				{
					vfd.Close();
					vfd.Open();
					subNode = node.Nodes.Add(vfd.Tag);
					subNode.Tag = NodeType.FBAPNode;
					subNode.ImageIndex = 8;
					subNode.SelectedImageIndex = subNode.ImageIndex;

					foreach (Block block in vfd.Blocks)
					{
						tmpNode = subNode.Nodes.Add(block.Tag);
						tmpNode.Tag = NodeType.BlockNode;
						int index = 0;
						switch((BlockType)block.Type)
						{
							case BlockType.ResouceBlock:
								index = 9;
								break;
							case BlockType.FunctionBlock:
								index = 10;
								break;
							case BlockType.TransducerBlock:
								index = 11;
								break;
						}
						tmpNode.ImageIndex = index;
						tmpNode.SelectedImageIndex = tmpNode.ImageIndex;

					}
				}
				MainTree.EndUpdate();
				node.ExpandAll();
				MessageStatus.Text += " successful";
			}
			catch(FBException exp)
			{
				MessageStatus.Text = exp.Message;
			}
		}


		private void DeviceClose(object sender, System.EventArgs e)
		{
			TreeNode node = MainTree.SelectedNode;
			if((node==null)||((NodeType)node.Tag!=NodeType.DeviceNode))
			{
				return;
			}
			TreeNode tmpNode = null;
			try
			{
				MessageStatus.Text = " Close Device "+node.Text+" ...";
				tmpNode = node.Parent;
				Link link = mainSession.GetLinkByTag(tmpNode.Text);
				Device device = link.GetDeviceByTag(node.Text);
				device.Close();
				MessageStatus.Text += " successful";
			}
			catch(Exception exp)
			{
				MessageStatus.Text = exp.Message;
			}
			finally
			{
				node.Nodes.Clear();
			}
		}

		private void MainForm_Load(object sender, System.EventArgs e)
		{
			MenuOpen.Click += new System.EventHandler(this.Link_Click);
			MenuOpen.Click += new System.EventHandler(this.Device_Click);
			MenuOpen.Click += new System.EventHandler(this.Block_Click);
			MenuOpen.Click += new System.EventHandler( this.MIB_Click);
			MenuClose.Click += new System.EventHandler(this.LinkClose);
			MenuClose.Click += new System.EventHandler(this.DeviceClose);

			btnSession.PerformClick();
		}
		
		private void MIB_Click(object sender, System.EventArgs e)
		{
			TreeNode node = MainTree.SelectedNode;
			if((node == null)||((NodeType)node.Tag!=NodeType.MIBNode))
			{
				return;
			}
			string blockTag = "";
			blockTag = node.Text;
			TreeNode tmpNode = node.Parent.Parent;
			
			MessageStatus.Text=" Open MIB  ...";
			try
			{
				Mib mib = mainSession.GetLinkByTag(tmpNode.Text).GetDeviceByTag(node.Parent.Text).Mib;
				MessageStatus.Text += " successful";
				ReadWriteForm reWr = new ReadWriteForm(mib);
				reWr.ShowDialog();
			}
			catch(FBException exp)
			{
				MessageStatus.Text  = exp.Message;
			}		
		}

		

		private void Block_Click(object sender, System.EventArgs e)
		{
			TreeNode node = MainTree.SelectedNode;
			if((node == null)||((NodeType)node.Tag!=NodeType.BlockNode))
			{
				return;
			}
			string blockTag = "";
			blockTag = node.Text;
			
			MessageStatus.Text=" Open Block "+node.Text+" ...";
			try
			{
				Block block = mainSession.GetLinkByTag(node.Parent.Parent.Parent.Text).GetDeviceByTag(node.Parent.Parent.Text).GetVfdByTag(node.Parent.Text).GetBlockByTag(node.Text);
				block.Close();
				block.Open();
				MessageStatus.Text += " successful";
				ReadWriteForm reWr = new ReadWriteForm(block);
				reWr.ShowDialog();
			}
			catch(FBException exp)
			{
				MessageStatus.Text  = exp.Message;
			}		
		}

		private void Timer_Tick(object sender, System.EventArgs e)
		{
			TimerStatus.Text = 	DateTime.Now.ToLocalTime().ToString();
		}

		private void MainPop_Popup(object sender, System.EventArgs e)
		{
			TreeNode node = MainTree.SelectedNode;
			if(node == null)
			{
				foreach (MenuItem mi in MainPop.MenuItems)
				{
					mi.Visible = false;
				}
			}
			else
			{
				foreach(MenuItem mi in MainPop.MenuItems)
				{
					mi.Visible = true;
				}
				switch ((NodeType)node.Tag)
				{
					case NodeType.LinkNode:
						if(node.Nodes.Count == 0)
						{
							MenuOpen.Text = "Open Link";
							MenuClose.Enabled = false;
						}
						else
						{
							MenuOpen.Text = "Update Link";
							MenuClose.Enabled = true;
						}
						MenuClose.Text = "Close Link";
						break;
					case NodeType.DeviceNode:
						if(node.Nodes.Count == 0)
						{
							MenuOpen.Text = "Open Device";
							MenuClose.Enabled = false;
						}
						else
						{
							MenuOpen.Text = "Update Device";
							MenuClose.Enabled = true;
						}				
						MenuClose.Text = "Close Device";
						break;
					case NodeType.BlockNode:
						MenuOpen.Text = "Open Block";
						MenuClose.Visible = false;
						break;
					case NodeType.MIBNode:
						MenuOpen.Text = "Open MIB";
						MenuClose.Visible = false;
						MenuWaitAlert.Visible = false;
						MenuWaitTrend.Visible = false;
						break;
					case NodeType.FBAPNode:
						MenuOpen.Visible = false;
						MenuClose.Visible = false;
						break;
				}
			}
		}

		private void MainTree_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			btnLink.Enabled = false;
			btnDevice.Enabled = false;
			btnBlock.Enabled = false;
			TreeNode node = MainTree.SelectedNode;
			switch((NodeType)node.Tag)
			{
				case NodeType.LinkNode:
					btnLink.Enabled = true;
					break;
				case NodeType.DeviceNode:
					btnDevice.Enabled = true;
					break;
				case NodeType.BlockNode:
					btnBlock.Enabled = true;
					break;
			}
		}

		private void MainTree_DoubleClick(object sender, System.EventArgs e)
		{
			TreeNode node = MainTree.SelectedNode;
			if(node == null)
			{
				return;
			}
			FBObject fbObj = null;
			switch((NodeType)node.Tag)
			{
				case NodeType.LinkNode:
					fbObj = mainSession.GetLinkByTag(node.Text);
					break;
				case NodeType.DeviceNode:
					fbObj = mainSession.GetLinkByTag(node.Parent.Text).GetDeviceByTag(node.Text);
					break;
				case NodeType.MIBNode:
					return;
				case NodeType.FBAPNode:
					fbObj = mainSession.GetLinkByTag(node.Parent.Parent.Text).GetDeviceByTag(node.Parent.Text).GetVfdByTag(node.Text);
					break;
				case NodeType.BlockNode:
					fbObj = mainSession.GetLinkByTag(node.Parent.Parent.Parent.Text).GetDeviceByTag(node.Parent.Parent.Text).GetVfdByTag(node.Parent.Text).GetBlockByTag(node.Text);
					break;
			}
			PropertyForm propertyForm = new PropertyForm(fbObj);
			propertyForm.ShowDialog();
			//Todo Change
			node.ExpandAll();
		}

		private void MenuWaitAlert_Click(object sender, System.EventArgs e)
		{
			TreeNode node = MainTree.SelectedNode;
			if(node == null)
			{
				return;
			}
			FBObject fbObj = null;
			switch((NodeType)node.Tag)
			{
				case NodeType.LinkNode:
					fbObj = mainSession.GetLinkByTag(node.Text);
					break;
				case NodeType.DeviceNode:
					fbObj = mainSession.GetLinkByTag(node.Parent.Text).GetDeviceByTag(node.Text);
					break;
				case NodeType.MIBNode:
					return;
				case NodeType.FBAPNode:
					fbObj = mainSession.GetLinkByTag(node.Parent.Parent.Text).GetDeviceByTag(node.Parent.Text).GetVfdByTag(node.Text);
					break;
				case NodeType.BlockNode:
					fbObj = mainSession.GetLinkByTag(node.Parent.Parent.Parent.Text).GetDeviceByTag(node.Parent.Parent.Text).GetVfdByTag(node.Parent.Text).GetBlockByTag(node.Text);
					break;
			}
			fbObj.Open();
			WaitAlertForm waitAlertForm = new WaitAlertForm(fbObj);
			waitAlertForm.ShowDialog();
		}

		private void MenuWaitTrend_Click(object sender, System.EventArgs e)
		{
			TreeNode node = MainTree.SelectedNode;
			if(node == null)
			{
				return;
			}
			FBObject fbObj = null;
			switch((NodeType)node.Tag)
			{
				case NodeType.LinkNode:
					fbObj = mainSession.GetLinkByTag(node.Text);
					break;
				case NodeType.DeviceNode:
					fbObj = mainSession.GetLinkByTag(node.Parent.Text).GetDeviceByTag(node.Text);
					break;
				case NodeType.MIBNode:
					return;
				case NodeType.FBAPNode:
					fbObj = mainSession.GetLinkByTag(node.Parent.Parent.Text).GetDeviceByTag(node.Parent.Text).GetVfdByTag(node.Text);
					break;
				case NodeType.BlockNode:
					fbObj = mainSession.GetLinkByTag(node.Parent.Parent.Parent.Text).GetDeviceByTag(node.Parent.Parent.Text).GetVfdByTag(node.Parent.Text).GetBlockByTag(node.Text);
					break;
			}
			fbObj.Open();
			WaitTrendForm waitTrendForm = new WaitTrendForm(fbObj);
			waitTrendForm.ShowDialog();
		}
	
	
	}
}
