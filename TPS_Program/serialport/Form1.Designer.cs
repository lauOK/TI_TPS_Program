namespace serialport
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Clear_Tran = new System.Windows.Forms.Button();
            this.DataSet = new System.Windows.Forms.Button();
            this.Clear_RSV = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label_Rx = new System.Windows.Forms.Label();
            this.label_Tx = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.OutputBox = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.MutilAddr = new System.Windows.Forms.CheckBox();
            this.Addr = new System.Windows.Forms.ComboBox();
            this.EEP_Program = new System.Windows.Forms.Button();
            this.Transport = new System.Windows.Forms.Button();
            this.OneAddr = new System.Windows.Forms.CheckBox();
            this.InputBox = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.port_Num = new System.Windows.Forms.ComboBox();
            this.Band = new System.Windows.Forms.ComboBox();
            this.data_bits = new System.Windows.Forms.ComboBox();
            this.crc_bits = new System.Windows.Forms.ComboBox();
            this.stop_bits = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.OpenPort = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Input_path = new System.Windows.Forms.TextBox();
            this.Data_input = new System.Windows.Forms.Button();
            this.TPS_Test = new System.Windows.Forms.Button();
            this.I_Full = new System.Windows.Forms.TextBox();
            this.label_Ifull = new System.Windows.Forms.Label();
            this.Rref = new System.Windows.Forms.TextBox();
            this.label_REF = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.TPS_Test);
            this.panel2.Controls.Add(this.Clear_Tran);
            this.panel2.Controls.Add(this.DataSet);
            this.panel2.Controls.Add(this.Clear_RSV);
            this.panel2.Location = new System.Drawing.Point(6, 256);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(180, 137);
            this.panel2.TabIndex = 1;
            // 
            // Clear_Tran
            // 
            this.Clear_Tran.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Clear_Tran.Location = new System.Drawing.Point(12, 37);
            this.Clear_Tran.Name = "Clear_Tran";
            this.Clear_Tran.Size = new System.Drawing.Size(154, 30);
            this.Clear_Tran.TabIndex = 3;
            this.Clear_Tran.Text = "清除发送";
            this.Clear_Tran.UseVisualStyleBackColor = true;
            this.Clear_Tran.Click += new System.EventHandler(this.Clear_Tran_Click);
            // 
            // DataSet
            // 
            this.DataSet.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.DataSet.Location = new System.Drawing.Point(12, 99);
            this.DataSet.Margin = new System.Windows.Forms.Padding(2);
            this.DataSet.Name = "DataSet";
            this.DataSet.Size = new System.Drawing.Size(154, 30);
            this.DataSet.TabIndex = 9;
            this.DataSet.Text = "参数设置";
            this.DataSet.UseVisualStyleBackColor = true;
            this.DataSet.Visible = false;
            this.DataSet.Click += new System.EventHandler(this.DataSet_Click);
            // 
            // Clear_RSV
            // 
            this.Clear_RSV.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Clear_RSV.Location = new System.Drawing.Point(12, 6);
            this.Clear_RSV.Name = "Clear_RSV";
            this.Clear_RSV.Size = new System.Drawing.Size(154, 30);
            this.Clear_RSV.TabIndex = 2;
            this.Clear_RSV.Text = "清除接收";
            this.Clear_RSV.UseVisualStyleBackColor = true;
            this.Clear_RSV.Click += new System.EventHandler(this.Clear_RSV_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.label_Rx);
            this.panel4.Controls.Add(this.label_Tx);
            this.panel4.Location = new System.Drawing.Point(6, 463);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(519, 31);
            this.panel4.TabIndex = 3;
            // 
            // label_Rx
            // 
            this.label_Rx.AutoSize = true;
            this.label_Rx.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Rx.Location = new System.Drawing.Point(351, 2);
            this.label_Rx.Name = "label_Rx";
            this.label_Rx.Size = new System.Drawing.Size(118, 24);
            this.label_Rx.TabIndex = 2;
            this.label_Rx.Text = "RX:0Bytes";
            // 
            // label_Tx
            // 
            this.label_Tx.AutoSize = true;
            this.label_Tx.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Tx.Location = new System.Drawing.Point(188, 2);
            this.label_Tx.Name = "label_Tx";
            this.label_Tx.Size = new System.Drawing.Size(118, 24);
            this.label_Tx.TabIndex = 1;
            this.label_Tx.Text = "TX:0Bytes";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(9, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 24);
            this.label7.TabIndex = 0;
            this.label7.Text = "串口已关闭";
            this.label7.DoubleClick += new System.EventHandler(this.Label_state_double_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.OutputBox);
            this.panel5.Location = new System.Drawing.Point(194, 7);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(331, 243);
            this.panel5.TabIndex = 4;
            // 
            // OutputBox
            // 
            this.OutputBox.Font = new System.Drawing.Font("宋体", 15F);
            this.OutputBox.Location = new System.Drawing.Point(4, 3);
            this.OutputBox.Multiline = true;
            this.OutputBox.Name = "OutputBox";
            this.OutputBox.ReadOnly = true;
            this.OutputBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.OutputBox.Size = new System.Drawing.Size(327, 240);
            this.OutputBox.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.MutilAddr);
            this.panel6.Controls.Add(this.Addr);
            this.panel6.Controls.Add(this.EEP_Program);
            this.panel6.Controls.Add(this.Transport);
            this.panel6.Controls.Add(this.OneAddr);
            this.panel6.Controls.Add(this.InputBox);
            this.panel6.Location = new System.Drawing.Point(194, 256);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(331, 137);
            this.panel6.TabIndex = 5;
            // 
            // MutilAddr
            // 
            this.MutilAddr.AutoSize = true;
            this.MutilAddr.Font = new System.Drawing.Font("宋体", 12F);
            this.MutilAddr.Location = new System.Drawing.Point(222, 105);
            this.MutilAddr.Name = "MutilAddr";
            this.MutilAddr.Size = new System.Drawing.Size(90, 20);
            this.MutilAddr.TabIndex = 11;
            this.MutilAddr.Text = "遍历刷写";
            this.MutilAddr.UseVisualStyleBackColor = true;
            this.MutilAddr.CheckedChanged += new System.EventHandler(this.MutilAddr_CheckedChanged);
            // 
            // Addr
            // 
            this.Addr.Enabled = false;
            this.Addr.FormattingEnabled = true;
            this.Addr.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.Addr.Location = new System.Drawing.Point(116, 105);
            this.Addr.Name = "Addr";
            this.Addr.Size = new System.Drawing.Size(91, 20);
            this.Addr.TabIndex = 12;
            this.Addr.SelectedIndexChanged += new System.EventHandler(this.Addr_SelectedIndexChanged);
            // 
            // EEP_Program
            // 
            this.EEP_Program.BackColor = System.Drawing.Color.ForestGreen;
            this.EEP_Program.Font = new System.Drawing.Font("宋体", 12F);
            this.EEP_Program.Location = new System.Drawing.Point(187, 49);
            this.EEP_Program.Name = "EEP_Program";
            this.EEP_Program.Size = new System.Drawing.Size(144, 42);
            this.EEP_Program.TabIndex = 2;
            this.EEP_Program.Text = "刷写";
            this.EEP_Program.UseVisualStyleBackColor = false;
            this.EEP_Program.Click += new System.EventHandler(this.TPS_Send_Click);
            // 
            // Transport
            // 
            this.Transport.Font = new System.Drawing.Font("宋体", 12F);
            this.Transport.Location = new System.Drawing.Point(4, 49);
            this.Transport.Name = "Transport";
            this.Transport.Size = new System.Drawing.Size(144, 42);
            this.Transport.TabIndex = 1;
            this.Transport.Text = "发送";
            this.Transport.UseVisualStyleBackColor = true;
            this.Transport.Click += new System.EventHandler(this.Transport_Click);
            // 
            // OneAddr
            // 
            this.OneAddr.AutoSize = true;
            this.OneAddr.Font = new System.Drawing.Font("宋体", 12F);
            this.OneAddr.Location = new System.Drawing.Point(5, 105);
            this.OneAddr.Name = "OneAddr";
            this.OneAddr.Size = new System.Drawing.Size(106, 20);
            this.OneAddr.TabIndex = 10;
            this.OneAddr.Text = "单地址刷写";
            this.OneAddr.UseVisualStyleBackColor = true;
            this.OneAddr.CheckedChanged += new System.EventHandler(this.OneAddr_CheckedChanged);
            // 
            // InputBox
            // 
            this.InputBox.Font = new System.Drawing.Font("宋体", 15F);
            this.InputBox.Location = new System.Drawing.Point(4, 9);
            this.InputBox.Multiline = true;
            this.InputBox.Name = "InputBox";
            this.InputBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.InputBox.Size = new System.Drawing.Size(327, 37);
            this.InputBox.TabIndex = 0;
            this.InputBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InputBox_KeyPress);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPort1_DataReceived);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "串口";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(3, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "波特率";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(3, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "数据位";
            // 
            // port_Num
            // 
            this.port_Num.Cursor = System.Windows.Forms.Cursors.Default;
            this.port_Num.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.port_Num.FormattingEnabled = true;
            this.port_Num.Location = new System.Drawing.Point(61, 5);
            this.port_Num.Name = "port_Num";
            this.port_Num.Size = new System.Drawing.Size(103, 32);
            this.port_Num.TabIndex = 3;
            // 
            // Band
            // 
            this.Band.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Band.FormattingEnabled = true;
            this.Band.Location = new System.Drawing.Point(61, 43);
            this.Band.Name = "Band";
            this.Band.Size = new System.Drawing.Size(103, 32);
            this.Band.TabIndex = 4;
            // 
            // data_bits
            // 
            this.data_bits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.data_bits.FormattingEnabled = true;
            this.data_bits.Items.AddRange(new object[] {
            "8"});
            this.data_bits.Location = new System.Drawing.Point(61, 81);
            this.data_bits.Name = "data_bits";
            this.data_bits.Size = new System.Drawing.Size(103, 32);
            this.data_bits.TabIndex = 5;
            // 
            // crc_bits
            // 
            this.crc_bits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.crc_bits.FormattingEnabled = true;
            this.crc_bits.Items.AddRange(new object[] {
            "None"});
            this.crc_bits.Location = new System.Drawing.Point(61, 119);
            this.crc_bits.Name = "crc_bits";
            this.crc_bits.Size = new System.Drawing.Size(103, 32);
            this.crc_bits.TabIndex = 6;
            // 
            // stop_bits
            // 
            this.stop_bits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stop_bits.FormattingEnabled = true;
            this.stop_bits.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.stop_bits.Location = new System.Drawing.Point(61, 157);
            this.stop_bits.Name = "stop_bits";
            this.stop_bits.Size = new System.Drawing.Size(103, 32);
            this.stop_bits.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(3, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 21);
            this.label4.TabIndex = 8;
            this.label4.Text = "校验位";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(3, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 21);
            this.label5.TabIndex = 9;
            this.label5.Text = "停止位";
            // 
            // OpenPort
            // 
            this.OpenPort.BackColor = System.Drawing.Color.ForestGreen;
            this.OpenPort.Location = new System.Drawing.Point(10, 200);
            this.OpenPort.Name = "OpenPort";
            this.OpenPort.Size = new System.Drawing.Size(154, 35);
            this.OpenPort.TabIndex = 10;
            this.OpenPort.Text = "打开串口";
            this.OpenPort.UseVisualStyleBackColor = false;
            this.OpenPort.Click += new System.EventHandler(this.OpenPort_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.OpenPort);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.stop_bits);
            this.panel1.Controls.Add(this.crc_bits);
            this.panel1.Controls.Add(this.data_bits);
            this.panel1.Controls.Add(this.Band);
            this.panel1.Controls.Add(this.port_Num);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(6, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(180, 243);
            this.panel1.TabIndex = 0;
            // 
            // Input_path
            // 
            this.Input_path.BackColor = System.Drawing.Color.White;
            this.Input_path.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Input_path.Location = new System.Drawing.Point(6, 399);
            this.Input_path.Name = "Input_path";
            this.Input_path.ReadOnly = true;
            this.Input_path.Size = new System.Drawing.Size(409, 29);
            this.Input_path.TabIndex = 7;
            this.Input_path.Click += new System.EventHandler(this.InputPath_Click);
            // 
            // Data_input
            // 
            this.Data_input.BackColor = System.Drawing.Color.ForestGreen;
            this.Data_input.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Data_input.Location = new System.Drawing.Point(432, 395);
            this.Data_input.Name = "Data_input";
            this.Data_input.Size = new System.Drawing.Size(93, 36);
            this.Data_input.TabIndex = 6;
            this.Data_input.Text = "数据导入";
            this.Data_input.UseVisualStyleBackColor = false;
            this.Data_input.Click += new System.EventHandler(this.Data_input_Click);
            // 
            // TPS_Test
            // 
            this.TPS_Test.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TPS_Test.Location = new System.Drawing.Point(12, 68);
            this.TPS_Test.Name = "TPS_Test";
            this.TPS_Test.Size = new System.Drawing.Size(154, 30);
            this.TPS_Test.TabIndex = 10;
            this.TPS_Test.Text = "测试";
            this.TPS_Test.UseVisualStyleBackColor = true;
            this.TPS_Test.Click += new System.EventHandler(this.TPS_Test_Click);
            // 
            // I_Full
            // 
            this.I_Full.Location = new System.Drawing.Point(318, 434);
            this.I_Full.Name = "I_Full";
            this.I_Full.ReadOnly = true;
            this.I_Full.Size = new System.Drawing.Size(87, 21);
            this.I_Full.TabIndex = 390;
            // 
            // label_Ifull
            // 
            this.label_Ifull.AutoSize = true;
            this.label_Ifull.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Ifull.Location = new System.Drawing.Point(224, 436);
            this.label_Ifull.Name = "label_Ifull";
            this.label_Ifull.Size = new System.Drawing.Size(88, 19);
            this.label_Ifull.TabIndex = 389;
            this.label_Ifull.Text = "I FULL(mA)";
            // 
            // Rref
            // 
            this.Rref.Location = new System.Drawing.Point(112, 434);
            this.Rref.Name = "Rref";
            this.Rref.ReadOnly = true;
            this.Rref.Size = new System.Drawing.Size(87, 21);
            this.Rref.TabIndex = 388;
            // 
            // label_REF
            // 
            this.label_REF.AutoSize = true;
            this.label_REF.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_REF.Location = new System.Drawing.Point(12, 435);
            this.label_REF.Name = "label_REF";
            this.label_REF.Size = new System.Drawing.Size(97, 19);
            this.label_REF.TabIndex = 387;
            this.label_REF.Text = "REF （KΩ）";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(537, 498);
            this.Controls.Add(this.I_Full);
            this.Controls.Add(this.label_Ifull);
            this.Controls.Add(this.Rref);
            this.Controls.Add(this.label_REF);
            this.Controls.Add(this.Input_path);
            this.Controls.Add(this.Data_input);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "SeriaPort";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.TextBox OutputBox;
        private System.Windows.Forms.Button Transport;
        private System.Windows.Forms.TextBox InputBox;
        private System.Windows.Forms.Button Clear_RSV;
        private System.Windows.Forms.Button Clear_Tran;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox port_Num;
        private System.Windows.Forms.ComboBox Band;
        private System.Windows.Forms.ComboBox data_bits;
        private System.Windows.Forms.ComboBox crc_bits;
        private System.Windows.Forms.ComboBox stop_bits;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button OpenPort;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_Rx;
        private System.Windows.Forms.Label label_Tx;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button DataSet;
        private System.Windows.Forms.Button EEP_Program;
        private System.Windows.Forms.CheckBox MutilAddr;
        public System.Windows.Forms.ComboBox Addr;
        private System.Windows.Forms.CheckBox OneAddr;
        private System.Windows.Forms.TextBox Input_path;
        private System.Windows.Forms.Button Data_input;
        private System.Windows.Forms.Button TPS_Test;
        private System.Windows.Forms.Label label_Ifull;
        private System.Windows.Forms.TextBox Rref;
        private System.Windows.Forms.Label label_REF;
        public System.Windows.Forms.TextBox I_Full;
    }
}

