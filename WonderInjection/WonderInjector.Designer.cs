using System;
using System.Windows.Forms;

namespace WonderInjection
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tp_Injection = new System.Windows.Forms.TabPage();
            this.btn_WCInject = new System.Windows.Forms.Button();
            this.btn_WCDelete = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.nud_SlotWCInjection = new System.Windows.Forms.NumericUpDown();
            this.btn_BrowseWCInject = new System.Windows.Forms.Button();
            this.tb_WCInjection = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btn_Inject = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nud_CountInjection = new System.Windows.Forms.NumericUpDown();
            this.nud_SlotInjection = new System.Windows.Forms.NumericUpDown();
            this.nud_BoxInjection = new System.Windows.Forms.NumericUpDown();
            this.btn_BrowseInject = new System.Windows.Forms.Button();
            this.tb_FileInjection = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tp_SaveDump = new System.Windows.Forms.TabPage();
            this.label100 = new System.Windows.Forms.Label();
            this.btn_SFDumpSave = new System.Windows.Forms.Button();
            this.btn_SFBrowse = new System.Windows.Forms.Button();
            this.tb_SaveFile = new System.Windows.Forms.TextBox();
            this.tp_Credits = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tb_IP = new System.Windows.Forms.TextBox();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.btn_Disconnect = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.ofd_Injection = new System.Windows.Forms.OpenFileDialog();
            this.ofd_WCInjection = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.tp_Injection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_SlotWCInjection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_CountInjection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_SlotInjection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_BoxInjection)).BeginInit();
            this.tp_SaveDump.SuspendLayout();
            this.tp_Credits.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tp_Injection);
            this.tabControl1.Controls.Add(this.tp_SaveDump);
            this.tabControl1.Controls.Add(this.tp_Credits);
            this.tabControl1.Font = new System.Drawing.Font("Hylia Serif Beta", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(6, 44);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(437, 306);
            this.tabControl1.TabIndex = 0;
            // 
            // tp_Injection
            // 
            this.tp_Injection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tp_Injection.Controls.Add(this.btn_WCInject);
            this.tp_Injection.Controls.Add(this.btn_WCDelete);
            this.tp_Injection.Controls.Add(this.label7);
            this.tp_Injection.Controls.Add(this.nud_SlotWCInjection);
            this.tp_Injection.Controls.Add(this.btn_BrowseWCInject);
            this.tp_Injection.Controls.Add(this.tb_WCInjection);
            this.tp_Injection.Controls.Add(this.label12);
            this.tp_Injection.Controls.Add(this.btn_Inject);
            this.tp_Injection.Controls.Add(this.btn_Delete);
            this.tp_Injection.Controls.Add(this.label10);
            this.tp_Injection.Controls.Add(this.label9);
            this.tp_Injection.Controls.Add(this.label3);
            this.tp_Injection.Controls.Add(this.nud_CountInjection);
            this.tp_Injection.Controls.Add(this.nud_SlotInjection);
            this.tp_Injection.Controls.Add(this.nud_BoxInjection);
            this.tp_Injection.Controls.Add(this.btn_BrowseInject);
            this.tp_Injection.Controls.Add(this.tb_FileInjection);
            this.tp_Injection.Controls.Add(this.label13);
            this.tp_Injection.Location = new System.Drawing.Point(4, 22);
            this.tp_Injection.Name = "tp_Injection";
            this.tp_Injection.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Injection.Size = new System.Drawing.Size(429, 280);
            this.tp_Injection.TabIndex = 0;
            this.tp_Injection.Text = "Injection";
            // 
            // btn_WCInject
            // 
            this.btn_WCInject.Location = new System.Drawing.Point(10, 253);
            this.btn_WCInject.Name = "btn_WCInject";
            this.btn_WCInject.Size = new System.Drawing.Size(410, 23);
            this.btn_WCInject.TabIndex = 17;
            this.btn_WCInject.Text = "Inject";
            this.btn_WCInject.UseVisualStyleBackColor = true;
            this.btn_WCInject.Click += new System.EventHandler(this.btn_WCInject_Click);
            // 
            // btn_WCDelete
            // 
            this.btn_WCDelete.Location = new System.Drawing.Point(345, 218);
            this.btn_WCDelete.Name = "btn_WCDelete";
            this.btn_WCDelete.Size = new System.Drawing.Size(75, 23);
            this.btn_WCDelete.TabIndex = 16;
            this.btn_WCDelete.Text = "Delete";
            this.btn_WCDelete.UseVisualStyleBackColor = true;
            this.btn_WCDelete.Click += new System.EventHandler(this.btn_WCDelete_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 203);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Slot:";
            // 
            // nud_SlotWCInjection
            // 
            this.nud_SlotWCInjection.Location = new System.Drawing.Point(10, 218);
            this.nud_SlotWCInjection.Maximum = new decimal(new int[] {
            48,
            0,
            0,
            0});
            this.nud_SlotWCInjection.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_SlotWCInjection.Name = "nud_SlotWCInjection";
            this.nud_SlotWCInjection.Size = new System.Drawing.Size(36, 21);
            this.nud_SlotWCInjection.TabIndex = 14;
            this.nud_SlotWCInjection.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nud_SlotWCInjection.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_SlotWCInjection.ValueChanged += new System.EventHandler(this.nud_SlotWCInjection_ValueChanged);
            // 
            // btn_BrowseWCInject
            // 
            this.btn_BrowseWCInject.Location = new System.Drawing.Point(345, 174);
            this.btn_BrowseWCInject.Name = "btn_BrowseWCInject";
            this.btn_BrowseWCInject.Size = new System.Drawing.Size(75, 23);
            this.btn_BrowseWCInject.TabIndex = 13;
            this.btn_BrowseWCInject.Text = "Browse";
            this.btn_BrowseWCInject.UseVisualStyleBackColor = true;
            this.btn_BrowseWCInject.Click += new System.EventHandler(this.btn_BrowseWCInject_Click);
            // 
            // tb_WCInjection
            // 
            this.tb_WCInjection.Location = new System.Drawing.Point(10, 175);
            this.tb_WCInjection.Name = "tb_WCInjection";
            this.tb_WCInjection.Size = new System.Drawing.Size(329, 21);
            this.tb_WCInjection.TabIndex = 12;
            this.tb_WCInjection.TextChanged += new System.EventHandler(this.tb_WCInjection_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 159);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "WC6/WC7 File:";
            // 
            // btn_Inject
            // 
            this.btn_Inject.Location = new System.Drawing.Point(10, 117);
            this.btn_Inject.Name = "btn_Inject";
            this.btn_Inject.Size = new System.Drawing.Size(410, 23);
            this.btn_Inject.TabIndex = 10;
            this.btn_Inject.Text = "Inject";
            this.btn_Inject.UseVisualStyleBackColor = true;
            this.btn_Inject.Click += new System.EventHandler(this.btn_Inject_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Location = new System.Drawing.Point(345, 81);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(75, 23);
            this.btn_Delete.TabIndex = 9;
            this.btn_Delete.Text = "Delete";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(92, 68);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Count:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(49, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Slot:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Box:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // nud_CountInjection
            // 
            this.nud_CountInjection.Location = new System.Drawing.Point(95, 83);
            this.nud_CountInjection.Maximum = new decimal(new int[] {
            960,
            0,
            0,
            0});
            this.nud_CountInjection.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_CountInjection.Name = "nud_CountInjection";
            this.nud_CountInjection.Size = new System.Drawing.Size(36, 21);
            this.nud_CountInjection.TabIndex = 5;
            this.nud_CountInjection.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_CountInjection.ValueChanged += new System.EventHandler(this.nud_CountInjection_ValueChanged);
            // 
            // nud_SlotInjection
            // 
            this.nud_SlotInjection.Location = new System.Drawing.Point(52, 83);
            this.nud_SlotInjection.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nud_SlotInjection.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_SlotInjection.Name = "nud_SlotInjection";
            this.nud_SlotInjection.Size = new System.Drawing.Size(37, 21);
            this.nud_SlotInjection.TabIndex = 4;
            this.nud_SlotInjection.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nud_SlotInjection.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_SlotInjection.ValueChanged += new System.EventHandler(this.nud_SlotInjection_ValueChanged);
            // 
            // nud_BoxInjection
            // 
            this.nud_BoxInjection.Location = new System.Drawing.Point(10, 83);
            this.nud_BoxInjection.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.nud_BoxInjection.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_BoxInjection.Name = "nud_BoxInjection";
            this.nud_BoxInjection.Size = new System.Drawing.Size(36, 21);
            this.nud_BoxInjection.TabIndex = 3;
            this.nud_BoxInjection.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nud_BoxInjection.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_BoxInjection.ValueChanged += new System.EventHandler(this.nud_BoxInjection_ValueChanged);
            // 
            // btn_BrowseInject
            // 
            this.btn_BrowseInject.Location = new System.Drawing.Point(345, 39);
            this.btn_BrowseInject.Name = "btn_BrowseInject";
            this.btn_BrowseInject.Size = new System.Drawing.Size(75, 23);
            this.btn_BrowseInject.TabIndex = 2;
            this.btn_BrowseInject.Text = "Browse";
            this.btn_BrowseInject.UseVisualStyleBackColor = true;
            this.btn_BrowseInject.Click += new System.EventHandler(this.btn_BrowseInject_Click);
            // 
            // tb_FileInjection
            // 
            this.tb_FileInjection.Location = new System.Drawing.Point(10, 40);
            this.tb_FileInjection.Name = "tb_FileInjection";
            this.tb_FileInjection.Size = new System.Drawing.Size(329, 21);
            this.tb_FileInjection.TabIndex = 1;
            this.tb_FileInjection.TextChanged += new System.EventHandler(this.tb_FileInjection_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "PK6/PK7 File:";
            this.label13.Click += new System.EventHandler(this.label3_Click);
            // 
            // tp_SaveDump
            // 
            this.tp_SaveDump.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tp_SaveDump.Controls.Add(this.label100);
            this.tp_SaveDump.Controls.Add(this.btn_SFDumpSave);
            this.tp_SaveDump.Controls.Add(this.btn_SFBrowse);
            this.tp_SaveDump.Controls.Add(this.tb_SaveFile);
            this.tp_SaveDump.Location = new System.Drawing.Point(4, 22);
            this.tp_SaveDump.Name = "tp_SaveDump";
            this.tp_SaveDump.Padding = new System.Windows.Forms.Padding(3);
            this.tp_SaveDump.Size = new System.Drawing.Size(429, 280);
            this.tp_SaveDump.TabIndex = 1;
            this.tp_SaveDump.Text = "Save File";
            // 
            // label100
            // 
            this.label100.AutoSize = true;
            this.label100.Font = new System.Drawing.Font("Hylia Serif Beta", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label100.Location = new System.Drawing.Point(115, 183);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(206, 32);
            this.label100.TabIndex = 3;
            this.label100.Text = "COMING SOON!";
            // 
            // btn_SFDumpSave
            // 
            this.btn_SFDumpSave.Enabled = false;
            this.btn_SFDumpSave.Location = new System.Drawing.Point(6, 70);
            this.btn_SFDumpSave.Name = "btn_SFDumpSave";
            this.btn_SFDumpSave.Size = new System.Drawing.Size(414, 56);
            this.btn_SFDumpSave.TabIndex = 2;
            this.btn_SFDumpSave.Text = "Dump Save Ram";
            this.btn_SFDumpSave.UseVisualStyleBackColor = true;
            // 
            // btn_SFBrowse
            // 
            this.btn_SFBrowse.Enabled = false;
            this.btn_SFBrowse.Location = new System.Drawing.Point(345, 41);
            this.btn_SFBrowse.Name = "btn_SFBrowse";
            this.btn_SFBrowse.Size = new System.Drawing.Size(75, 23);
            this.btn_SFBrowse.TabIndex = 1;
            this.btn_SFBrowse.Text = "Browse";
            this.btn_SFBrowse.UseVisualStyleBackColor = true;
            // 
            // tb_SaveFile
            // 
            this.tb_SaveFile.Location = new System.Drawing.Point(6, 43);
            this.tb_SaveFile.Name = "tb_SaveFile";
            this.tb_SaveFile.Size = new System.Drawing.Size(333, 21);
            this.tb_SaveFile.TabIndex = 0;
            // 
            // tp_Credits
            // 
            this.tp_Credits.Controls.Add(this.richTextBox1);
            this.tp_Credits.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tp_Credits.Location = new System.Drawing.Point(4, 22);
            this.tp_Credits.Name = "tp_Credits";
            this.tp_Credits.Size = new System.Drawing.Size(429, 280);
            this.tp_Credits.TabIndex = 2;
            this.tp_Credits.Text = "Credits";
            this.tp_Credits.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.richTextBox1.Location = new System.Drawing.Point(2, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(424, 274);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "@Kaphotics for the base code borrowed from PKHeX.\nwww.projectpokemon.com\nhttps://" +
    "github.com/kwsch/PKHeX\n\n@Arch9SK7 for GUI https://github.com/Arch9SK7\n\nAlso all " +
    "others for save file and ntr RE work.";
            // 
            // tb_IP
            // 
            this.tb_IP.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tb_IP.Font = new System.Drawing.Font("Hylia Serif Beta", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_IP.Location = new System.Drawing.Point(168, 12);
            this.tb_IP.Name = "tb_IP";
            this.tb_IP.Size = new System.Drawing.Size(100, 21);
            this.tb_IP.TabIndex = 0;
            this.tb_IP.Text = "192.168.0.14";
            this.tb_IP.TextChanged += new System.EventHandler(this.tb_IP_TextChanged);
            // 
            // btn_Connect
            // 
            this.btn_Connect.Font = new System.Drawing.Font("Hylia Serif Beta", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Connect.Location = new System.Drawing.Point(274, 11);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(75, 23);
            this.btn_Connect.TabIndex = 5;
            this.btn_Connect.Text = "Connect";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // btn_Disconnect
            // 
            this.btn_Disconnect.Font = new System.Drawing.Font("Hylia Serif Beta", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Disconnect.Location = new System.Drawing.Point(355, 11);
            this.btn_Disconnect.Name = "btn_Disconnect";
            this.btn_Disconnect.Size = new System.Drawing.Size(75, 23);
            this.btn_Disconnect.TabIndex = 29;
            this.btn_Disconnect.Text = "Disconnect";
            this.btn_Disconnect.UseVisualStyleBackColor = true;
            this.btn_Disconnect.Click += new System.EventHandler(this.btn_Disconnect_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(126, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "3DS IP";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Hylia Serif Beta", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Wonder";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Hylia Serif Beta", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(67, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Injector";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(381, 349);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(44, 13);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Ver. 0.5";
            // 
            // ofd_Injection
            // 
            this.ofd_Injection.FileName = "Pokemon.pk7";
            // 
            // ofd_WCInjection
            // 
            this.ofd_WCInjection.FileName = "WC.wc7";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 362);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_Disconnect);
            this.Controls.Add(this.btn_Connect);
            this.Controls.Add(this.tb_IP);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Wonder Injector";
            this.tabControl1.ResumeLayout(false);
            this.tp_Injection.ResumeLayout(false);
            this.tp_Injection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_SlotWCInjection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_CountInjection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_SlotInjection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_BoxInjection)).EndInit();
            this.tp_SaveDump.ResumeLayout(false);
            this.tp_SaveDump.PerformLayout();
            this.tp_Credits.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tp_Injection;
        private System.Windows.Forms.TabPage tp_SaveDump;
        private System.Windows.Forms.TabPage tp_Credits;
        private System.Windows.Forms.Button btn_WCInject;
        private System.Windows.Forms.Button btn_WCDelete;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nud_SlotWCInjection;
        private System.Windows.Forms.Button btn_BrowseWCInject;
        private System.Windows.Forms.TextBox tb_WCInjection;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btn_Inject;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nud_CountInjection;
        private System.Windows.Forms.NumericUpDown nud_SlotInjection;
        private System.Windows.Forms.NumericUpDown nud_BoxInjection;
        private System.Windows.Forms.Button btn_BrowseInject;
        private System.Windows.Forms.TextBox tb_FileInjection;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tb_IP;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.Button btn_Disconnect;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label100;
        private System.Windows.Forms.Button btn_SFDumpSave;
        private System.Windows.Forms.Button btn_SFBrowse;
        private System.Windows.Forms.TextBox tb_SaveFile;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private OpenFileDialog ofd_Injection;
        private OpenFileDialog ofd_WCInjection;
    }
}

