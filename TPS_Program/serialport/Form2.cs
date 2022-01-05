﻿using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace serialport
{
    public partial class Form2 : Form
    {
        private Form1 fm1;

        public Form2()
        {
            InitializeComponent();
        }

        public Form2(Form1 f)
        {
            InitializeComponent();
            fm1 = f;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < 41; i++)
            {
                NumericUpDown nud = (NumericUpDown)this.panel2.Controls["value" + i.ToString()];
                nud.Value = Data.EEPvalue[i - 1];
            }
            Data_Refresh();
            CRC_Check();
            this.path2.Text = Data.path_output;
            this.Rref.Text = Data.RREF.ToString();
            this.I_Full.Text = Data.IFULL.ToString();
        }

        private void Sure_Click(object sender, EventArgs e)//确定
        {
            for (int i = 1; i < 41; i++)
            {
                NumericUpDown nud = (NumericUpDown)this.panel2.Controls["value" + i.ToString()];
                Data.EEPvalue[i - 1] = (byte)nud.Value;
            }
            fm1.I_Full.Text = Data.IFULL.ToString("0.000000");
            fm1.tb_devaddr.Text = Data.addr_to_write.ToString();
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)//取消
        {
            this.Close();
        }

        private void Output_Click(object sender, EventArgs e)//导出
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV文件 | *.csv; *.CSV";
            var Diaresult = ofd.ShowDialog();
            if (Diaresult == DialogResult.OK)
            {
                Data.path_output = ofd.FileName;
                this.path2.Text = Data.path_output;

                var result = MessageBox.Show(null, "要导出的文件路径为：" + Data.path_output, "导出确认", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    FileStream fs = new FileStream(Data.path_output, FileMode.Create, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);

                    string col_txt = "ADDRESS" + "," + "VALUE";
                    sw.WriteLine(col_txt);

                    for (int i = 1; i < 41; i++)
                    {
                        string row_txt;
                        NumericUpDown nud = (NumericUpDown)this.panel2.Controls["value" + i.ToString()];
                        row_txt = Data.EEPaddress[i - 1].ToString() + "," + nud.Value.ToString();
                        sw.WriteLine(row_txt);
                    }
                    sw.Flush();
                    sw.Close();
                    fs.Close();
                    MessageBox.Show("导出完成");
                }
            }
        }

        private void RREF_Change(object sender, EventArgs e)//电阻电流计算刷新
        {
            if (this.comboBox43.Text != String.Empty && this.Rref.Text != String.Empty)
            {
                Data.RREF = Convert.ToDouble(Rref.Text);
                Data.IFULL = 1.235 / Convert.ToDouble(Rref.Text) * Convert.ToDouble(comboBox43.Text);
                I_Full.Text = Data.IFULL.ToString("0.000000");
            }

            for (int i = 1; i < 13; i++)
            {
                NumericUpDown nud = (NumericUpDown)(this.panel2.Controls["value" + i.ToString()]);
                TextBox tb = (TextBox)this.panel2.Controls["value" + i.ToString() + "d"];
                tb.Text = (nud.Value / nud.Maximum * Convert.ToDecimal(Data.IFULL)).ToString("0.000000");
            }

            for (int i = 13; i < 25; i++)
            {
                NumericUpDown nud = (NumericUpDown)(this.panel2.Controls["value" + i.ToString()]);
                TextBox tb = (TextBox)this.panel2.Controls["value" + i.ToString() + "p"];
                tb.Text = (nud.Value / nud.Maximum * 100).ToString("#0.0");
            }
        }

        private void IOUT_Change(object sender, EventArgs e)//电流刷新
        {
            NumericUpDown nud = sender as NumericUpDown;
            TextBox tb = (TextBox)this.panel2.Controls[nud.Name + "d"];
            tb.Text = (nud.Value / nud.Maximum * Convert.ToDecimal(Data.IFULL)).ToString("0.000000");
            CRC_Check();
        }

        private void PWMOUT_Change(object sender, EventArgs e)//占空比刷新
        {
            NumericUpDown nud = sender as NumericUpDown;
            TextBox tb = (TextBox)this.panel2.Controls[nud.Name + "p"];
            tb.Text = ((float)(nud.Value / nud.Maximum * 100)).ToString("#0.0");
            CRC_Check();
        }

        //FS0 ComboBox & NumericUpDown Begin
        private void FS0_Change(object sender, EventArgs e)
        {
            FS0_Change_CB();
            CRC_Check();
        }

        private void FS0_CB_Change(object sender, EventArgs e)
        {
            int bit0, bit1, bit2, bit3, bit4, bit5, bit6, bit7, bit8, bit9, bit10, bit11;
            ComboBox CB = sender as ComboBox;

            if (CB.Text == "Enable")
                CB.ForeColor = Color.ForestGreen;
            else
                CB.ForeColor = Color.Red;

            bit0 = this.comboBox12.Text == "Enable" ? 1 : 0;
            bit1 = this.comboBox11.Text == "Enable" ? 1 : 0;
            bit2 = this.comboBox10.Text == "Enable" ? 1 : 0;
            bit3 = this.comboBox9.Text == "Enable" ? 1 : 0;
            bit4 = this.comboBox8.Text == "Enable" ? 1 : 0;
            bit5 = this.comboBox7.Text == "Enable" ? 1 : 0;
            bit6 = this.comboBox6.Text == "Enable" ? 1 : 0;
            bit7 = this.comboBox5.Text == "Enable" ? 1 : 0;
            bit8 = this.comboBox4.Text == "Enable" ? 1 : 0;
            bit9 = this.comboBox3.Text == "Enable" ? 1 : 0;
            bit10 = this.comboBox2.Text == "Enable" ? 1 : 0;
            bit11 = this.comboBox1.Text == "Enable" ? 1 : 0;

            this.value25.Value = bit7 << 7 | bit6 << 6 | bit5 << 5 | bit4 << 4 | bit3 << 3 | bit2 << 2 | bit1 << 1 | bit0;
            this.value26.Value = bit11 << 3 | bit10 << 2 | bit9 << 1 | bit8;
        }

        private void FS0_Change_CB()
        {
            byte temp;
            temp = Convert.ToByte(this.value25.Value);
            this.comboBox12.SelectedIndex = (temp & 1) == 1 ? 0 : 1;
            this.comboBox11.SelectedIndex = (temp & 2) == 2 ? 0 : 1;
            this.comboBox10.SelectedIndex = (temp & 4) == 4 ? 0 : 1;
            this.comboBox9.SelectedIndex = (temp & 8) == 8 ? 0 : 1;
            this.comboBox8.SelectedIndex = (temp & 16) == 16 ? 0 : 1;
            this.comboBox7.SelectedIndex = (temp & 32) == 32 ? 0 : 1;
            this.comboBox6.SelectedIndex = (temp & 64) == 64 ? 0 : 1;
            this.comboBox5.SelectedIndex = (temp & 128) == 128 ? 0 : 1;
            temp = Convert.ToByte(this.value26.Value);
            this.comboBox4.SelectedIndex = (temp & 1) == 1 ? 0 : 1;
            this.comboBox3.SelectedIndex = (temp & 2) == 2 ? 0 : 1;
            this.comboBox2.SelectedIndex = (temp & 4) == 4 ? 0 : 1;
            this.comboBox1.SelectedIndex = (temp & 8) == 8 ? 0 : 1;
        }

        //FS1 ComboBox & NumericUpDown  Begin
        private void FS1_Change(object sender, EventArgs e)
        {
            FS1_Change_CB();
            CRC_Check();
        }

        private void FS1_CB_Change(object sender, EventArgs e)
        {
            int bit0, bit1, bit2, bit3, bit4, bit5, bit6, bit7, bit8, bit9, bit10, bit11;
            ComboBox CB = sender as ComboBox;

            if (CB.Text == "Enable")
                CB.ForeColor = Color.ForestGreen;
            else
                CB.ForeColor = Color.Red;

            bit0 = this.comboBox13.Text == "Enable" ? 1 : 0;
            bit1 = this.comboBox14.Text == "Enable" ? 1 : 0;
            bit2 = this.comboBox15.Text == "Enable" ? 1 : 0;
            bit3 = this.comboBox16.Text == "Enable" ? 1 : 0;
            bit4 = this.comboBox17.Text == "Enable" ? 1 : 0;
            bit5 = this.comboBox18.Text == "Enable" ? 1 : 0;
            bit6 = this.comboBox19.Text == "Enable" ? 1 : 0;
            bit7 = this.comboBox20.Text == "Enable" ? 1 : 0;
            bit8 = this.comboBox21.Text == "Enable" ? 1 : 0;
            bit9 = this.comboBox22.Text == "Enable" ? 1 : 0;
            bit10 = this.comboBox23.Text == "Enable" ? 1 : 0;
            bit11 = this.comboBox24.Text == "Enable" ? 1 : 0;

            this.value27.Value = bit7 << 7 | bit6 << 6 | bit5 << 5 | bit4 << 4 | bit3 << 3 | bit2 << 2 | bit1 << 1 | bit0;
            this.value28.Value = bit11 << 3 | bit10 << 2 | bit9 << 1 | bit8;
        }

        private void FS1_Change_CB()
        {
            byte temp;
            temp = Convert.ToByte(this.value27.Value);
            this.comboBox13.SelectedIndex = (temp & 1) == 1 ? 0 : 1;
            this.comboBox14.SelectedIndex = (temp & 2) == 2 ? 0 : 1;
            this.comboBox15.SelectedIndex = (temp & 4) == 4 ? 0 : 1;
            this.comboBox16.SelectedIndex = (temp & 8) == 8 ? 0 : 1;
            this.comboBox17.SelectedIndex = (temp & 16) == 16 ? 0 : 1;
            this.comboBox18.SelectedIndex = (temp & 32) == 32 ? 0 : 1;
            this.comboBox19.SelectedIndex = (temp & 64) == 64 ? 0 : 1;
            this.comboBox20.SelectedIndex = (temp & 128) == 128 ? 0 : 1;
            temp = Convert.ToByte(this.value28.Value);
            this.comboBox21.SelectedIndex = (temp & 1) == 1 ? 0 : 1;
            this.comboBox22.SelectedIndex = (temp & 2) == 2 ? 0 : 1;
            this.comboBox23.SelectedIndex = (temp & 4) == 4 ? 0 : 1;
            this.comboBox24.SelectedIndex = (temp & 8) == 8 ? 0 : 1;
        }

        //Diagnostic ComboBox & NumericUpDown Begin
        private void Diagnostic_Change(object sender, EventArgs e)
        {
            Diagnostic_Change_CB();
            CRC_Check();
        }

        private void Diagnostic_CB_Change(object sender, EventArgs e)
        {
            int bit0, bit1, bit2, bit3, bit4, bit5, bit6, bit7, bit8, bit9, bit10, bit11;
            ComboBox CB = sender as ComboBox;

            if (CB.Text == "Enable")
                CB.ForeColor = Color.ForestGreen;
            else
                CB.ForeColor = Color.Red;

            bit0 = this.comboBox25.Text == "Enable" ? 1 : 0;
            bit1 = this.comboBox26.Text == "Enable" ? 1 : 0;
            bit2 = this.comboBox27.Text == "Enable" ? 1 : 0;
            bit3 = this.comboBox28.Text == "Enable" ? 1 : 0;
            bit4 = this.comboBox29.Text == "Enable" ? 1 : 0;
            bit5 = this.comboBox30.Text == "Enable" ? 1 : 0;
            bit6 = this.comboBox31.Text == "Enable" ? 1 : 0;
            bit7 = this.comboBox32.Text == "Enable" ? 1 : 0;
            bit8 = this.comboBox33.Text == "Enable" ? 1 : 0;
            bit9 = this.comboBox34.Text == "Enable" ? 1 : 0;
            bit10 = this.comboBox35.Text == "Enable" ? 1 : 0;
            bit11 = this.comboBox36.Text == "Enable" ? 1 : 0;

            this.value29.Value = bit7 << 7 | bit6 << 6 | bit5 << 5 | bit4 << 4 | bit3 << 3 | bit2 << 2 | bit1 << 1 | bit0;
            this.value30.Value = bit11 << 3 | bit10 << 2 | bit9 << 1 | bit8;
        }

        private void Diagnostic_Change_CB()
        {
            byte temp;
            temp = Convert.ToByte(this.value29.Value);
            this.comboBox25.SelectedIndex = (temp & 1) == 1 ? 0 : 1;
            this.comboBox26.SelectedIndex = (temp & 2) == 2 ? 0 : 1;
            this.comboBox27.SelectedIndex = (temp & 4) == 4 ? 0 : 1;
            this.comboBox28.SelectedIndex = (temp & 8) == 8 ? 0 : 1;
            this.comboBox29.SelectedIndex = (temp & 16) == 16 ? 0 : 1;
            this.comboBox30.SelectedIndex = (temp & 32) == 32 ? 0 : 1;
            this.comboBox31.SelectedIndex = (temp & 64) == 64 ? 0 : 1;
            this.comboBox32.SelectedIndex = (temp & 128) == 128 ? 0 : 1;
            temp = Convert.ToByte(this.value30.Value);
            this.comboBox33.SelectedIndex = (temp & 1) == 1 ? 0 : 1;
            this.comboBox34.SelectedIndex = (temp & 2) == 2 ? 0 : 1;
            this.comboBox35.SelectedIndex = (temp & 4) == 4 ? 0 : 1;
            this.comboBox36.SelectedIndex = (temp & 8) == 8 ? 0 : 1;
        }

        //EEPM6 Change  Begin
        private void EEPM6_Change(object sender, EventArgs e)
        {
            EEPM6_Change_CB();
            CRC_Check();
        }
        private void EEPM6_CB_Change(object sender, EventArgs e)
        {
            int bit0_3, bit4, bit6;

            if (this.comboBox39.SelectedIndex == -1)
                bit0_3 = 0;
            else
                bit0_3 = this.comboBox39.SelectedIndex;

            bit4 = this.comboBox38.Text == "Enable" ? 1 : 0;
            bit6 = this.comboBox37.Text == "4.4" ? 1 : 0;

            this.value31.Value = bit6 << 6 | bit4 << 4 | bit0_3;

            Data.addr_to_write = bit0_3;
        }

        private void EEPM6_Change_CB()
        {
            byte temp;
            temp = Convert.ToByte(this.value31.Value);

            this.comboBox37.SelectedIndex = (temp & 64) == 64 ? 1 : 0;
            this.comboBox38.SelectedIndex = (temp & 16) == 16 ? 0 : 1;
            this.comboBox39.SelectedIndex = (temp & 15);
        }

        //EEPM7 Change  Begin
        private void EEPM7_Change(object sender, EventArgs e)
        {
            EEPM7_Change_CB();
            CRC_Check();
        }
        private void EEPM7_CB_Change(object sender, EventArgs e)
        {
            int bit0_1, bit2, bit3, bit4_7;

            if (this.comboBox43.SelectedIndex == -1)
                bit0_1 = 0;
            else
                bit0_1 = this.comboBox43.SelectedIndex;

            bit2 = this.comboBox42.Text == "One Fail All Fail" ? 1 : 0;
            bit3 = this.comboBox41.Text == "Enable" ? 1 : 0;

            if (this.comboBox40.SelectedIndex == -1)
                bit4_7 = 0;
            else
                bit4_7 = this.comboBox40.SelectedIndex;

            this.value32.Value = bit4_7 << 4 | bit3 << 3 | bit2 << 2 | bit0_1;

            ComboBox cb = sender as ComboBox;
            if (cb.Name == "comboBox43")
            {
                if (this.comboBox43.Text != String.Empty && this.Rref.Text != String.Empty)
                {
                    Data.RREF = Convert.ToDouble(Rref.Text);
                    Data.IFULL = 1.235 / Convert.ToDouble(Rref.Text) * Convert.ToDouble(comboBox43.Text);
                    I_Full.Text = Data.IFULL.ToString("0.000000");
                }
            }
        }

        private void EEPM7_Change_CB()
        {
            byte temp;
            temp = Convert.ToByte(this.value32.Value);

            this.comboBox40.SelectedIndex = (temp & 0xf0) >> 4;
            this.comboBox41.SelectedIndex = (temp & 8) == 8 ? 0 : 1;
            this.comboBox42.SelectedIndex = (temp & 4) == 4 ? 0 : 1;
            this.comboBox43.SelectedIndex = temp & 3;
        }

        //EEPM8 Change  Begin
        private void EEPM8_Change(object sender, EventArgs e)
        {
            EEPM8_Change_CB();
            CRC_Check();
        }
        private void EEPM8_CB_Change(object sender, EventArgs e)
        {
            int bit0_3, bit4_6;

            if (this.comboBox45.SelectedIndex == -1)
                bit0_3 = 0;
            else
                bit0_3 = this.comboBox45.SelectedIndex;

            if (this.comboBox44.SelectedIndex == -1)
                bit4_6 = 0;
            else
                bit4_6 = this.comboBox44.SelectedIndex;

            this.value33.Value = bit4_6 << 4 | bit0_3;
        }

        private void EEPM8_Change_CB()
        {
            byte temp;
            temp = Convert.ToByte(this.value33.Value);

            this.comboBox44.SelectedIndex = (temp & 0x70) >> 4;
            this.comboBox45.SelectedIndex = temp & 15;
        }

        //EEPM9 Change  Begin
        private void EEPM9_Change(object sender, EventArgs e)
        {
            EEPM9_Change_CB();
            CRC_Check();
        }
        private void EEPM9_CB_Change(object sender, EventArgs e)
        {
            int bit0_3, bit4_7;

            if (this.comboBox47.SelectedIndex == -1)
                bit0_3 = 0;
            else
                bit0_3 = this.comboBox47.SelectedIndex;

            if (this.comboBox46.SelectedIndex == -1)
                bit4_7 = 0;
            else
                bit4_7 = this.comboBox46.SelectedIndex;

            this.value34.Value = bit4_7 << 4 | bit0_3;
        }

        private void EEPM9_Change_CB()
        {
            byte temp;
            temp = Convert.ToByte(this.value34.Value);

            this.comboBox46.SelectedIndex = (temp & 0xF0) >> 4;
            this.comboBox47.SelectedIndex = temp & 15;
        }

        //EEPM10 Change  Begin
        private void EEPM10_Change(object sender, EventArgs e)
        {
            EEPM10_Change_CB();
            CRC_Check();
        }
        private void EEPM10_CB_Change(object sender, EventArgs e)
        {
            int bit0_3, bit4_7;

            if (this.comboBox49.SelectedIndex == -1)
                bit0_3 = 0;
            else
                bit0_3 = this.comboBox49.SelectedIndex;

            if (this.comboBox48.SelectedIndex == -1)
                bit4_7 = 0;
            else
                bit4_7 = this.comboBox48.SelectedIndex;

            this.value35.Value = bit4_7 << 4 | bit0_3;
        }

        private void EEPM10_Change_CB()
        {
            byte temp;
            temp = Convert.ToByte(this.value35.Value);

            this.comboBox48.SelectedIndex = (temp & 0xF0) >> 4;
            this.comboBox49.SelectedIndex = temp & 15;
        }

        //EEPM11 Change  Begin
        private void EEPM11_Change(object sender, EventArgs e)
        {
            EEPM11_Change_CB();
            CRC_Check();
        }
        private void EEPM11_CB_Change(object sender, EventArgs e)
        {
            int bit0, bit1, bit2, bit3, bit4, bit5, bit6, bit7;
            ComboBox CB = sender as ComboBox;

            if (CB.Text == "1")
                CB.ForeColor = Color.ForestGreen;
            else
                CB.ForeColor = Color.Red;

            bit0 = this.comboBox54.Text == "1" ? 1 : 0;
            bit1 = this.comboBox55.Text == "1" ? 1 : 0;
            bit2 = this.comboBox56.Text == "1" ? 1 : 0;
            bit3 = this.comboBox57.Text == "1" ? 1 : 0;
            bit4 = this.comboBox50.Text == "1" ? 1 : 0;
            bit5 = this.comboBox51.Text == "1" ? 1 : 0;
            bit6 = this.comboBox52.Text == "1" ? 1 : 0;
            bit7 = this.comboBox53.Text == "1" ? 1 : 0;

            this.value36.Value = bit7 << 7 | bit6 << 6 | bit5 << 5 | bit4 << 4 | bit3 << 3 | bit2 << 2 | bit1 << 1 | bit0;
        }

        private void EEPM11_Change_CB()
        {
            byte temp;
            temp = Convert.ToByte(this.value36.Value);

            this.comboBox54.SelectedIndex = (temp & 1) == 1 ? 1 : 0;
            this.comboBox55.SelectedIndex = (temp & 2) == 2 ? 1 : 0;
            this.comboBox56.SelectedIndex = (temp & 4) == 4 ? 1 : 0;
            this.comboBox57.SelectedIndex = (temp & 8) == 8 ? 1 : 0;
            this.comboBox50.SelectedIndex = (temp & 16) == 16 ? 1 : 0;
            this.comboBox51.SelectedIndex = (temp & 32) == 32 ? 1 : 0;
            this.comboBox52.SelectedIndex = (temp & 64) == 64 ? 1 : 0;
            this.comboBox53.SelectedIndex = (temp & 128) == 128 ? 1 : 0;
        }

        //EEPM12_14 Change  Begin
        private void EEPM12_14_Change(object sender, EventArgs e)
        {
            CRC_Check();
        }

        private void Data_Refresh()
        {
            FS0_Change_CB();
            FS1_Change_CB();
            Diagnostic_Change_CB();
            EEPM6_Change_CB();
            EEPM7_Change_CB();
            EEPM8_Change_CB();
            EEPM9_Change_CB();
            EEPM10_Change_CB();
            EEPM11_Change_CB();
        }

        private void CRC_Check()
        {
            byte[] temp = new byte[39];
            for (int i = 0; i < 39; i++)
            {
                NumericUpDown nud = (NumericUpDown)this.panel2.Controls["value" + (i + 1).ToString()];
                temp[i] = Convert.ToByte(nud.Value);
            }
            this.value40.Value = Data.CRC(temp, 39);
        }

        //MouseHover Begin
        private void Current_MouseHover(object sender, EventArgs e)
        {
            Label lb = sender as Label;

            ToolTip toolTip = new ToolTip();

            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 200;
            toolTip.ReshowDelay = 500;
            toolTip.ShowAlways = true;
            toolTip.SetToolTip(lb, "设定通道电流");
        }

        private void DutyCycle_MouseHover(object sender, EventArgs e)
        {
            Label lb = sender as Label;

            ToolTip toolTip = new ToolTip();

            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 200;
            toolTip.ReshowDelay = 500;
            toolTip.ShowAlways = true;
            toolTip.SetToolTip(lb, "设定通道占空比");
        }

        private void Failsafe_MouseHover(object sender, EventArgs e)
        {
            Label lb = sender as Label;

            ToolTip toolTip = new ToolTip();

            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 200;
            toolTip.ReshowDelay = 500;
            toolTip.ShowAlways = true;
            if (lb.Text == "EEPM0")
            {
                toolTip.SetToolTip(lb, "设定FAIL SAFE 0 通道0-7");
            }
            else if (lb.Text == "EEPM1")
            {
                toolTip.SetToolTip(lb, "设定FAIL SAFE 0 通道8-11");
            }
            else if (lb.Text == "EEPM2")
            {
                toolTip.SetToolTip(lb, "设定FAIL SAFE 1 通道0-7");
            }
            else if (lb.Text == "EEPM3")
            {
                toolTip.SetToolTip(lb, "设定FAIL SAFE 1 通道8-11");
            }
            else if (lb.Text == "EEP_FS0")
            {
                toolTip.SetToolTip(lb, "FAIL SAFE 0 通道0-11");
            }
            else if (lb.Text == "EEP_FS1")
            {
                toolTip.SetToolTip(lb, "FAIL SAFE 1 通道0-11");
            }
        }

        private void Diagen_MouseHover(object sender, EventArgs e)
        {
            Label lb = sender as Label;

            ToolTip toolTip = new ToolTip();

            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 200;
            toolTip.ReshowDelay = 500;
            toolTip.ShowAlways = true;
            if (lb.Text == "EEPM4")
            {
                toolTip.SetToolTip(lb, "设定诊断使能 通道0-7");
            }
            else if (lb.Text == "EEPM5")
            {
                toolTip.SetToolTip(lb, "设定诊断使能 通道8-11");
            }
            else if (lb.Text == "DIAGEN")
            {
                toolTip.SetToolTip(lb, "设定诊断使能 通道0-11");
            }
        }

        private void Others_MouseHover(object sender, EventArgs e)
        {
            Label lb = sender as Label;

            ToolTip toolTip = new ToolTip();

            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 200;
            toolTip.ReshowDelay = 500;
            toolTip.ShowAlways = true;
            if (lb.Text == "EEPM15")
            {
                toolTip.SetToolTip(lb, "只读 CRC校验值");
            }
            else
            {
                toolTip.SetToolTip(lb, "详见以下各项详细设定");
            }
        }

        private void NULL_MouseHover(object sender, EventArgs e)
        {
            Label lb = sender as Label;

            ToolTip toolTip = new ToolTip();

            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 200;
            toolTip.ReshowDelay = 500;
            toolTip.ShowAlways = true;
            toolTip.SetToolTip(lb, "保留位，无需设置");
        }

        private void Multi_MouseHover(object sender, EventArgs e)
        {
            Label lb = sender as Label;

            ToolTip toolTip = new ToolTip();

            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 200;
            toolTip.ReshowDelay = 500;
            toolTip.ShowAlways = true;
            switch (lb.Text)
            {
                case "EEP_LDO (V)": toolTip.SetToolTip(lb, "EEPM6，LDO输出电压设置"); break;
                case "EEP_EXPEN": toolTip.SetToolTip(lb, "EEPM6，PWM发生器指数调光使能"); break;
                case "EEP_DEVADDR": toolTip.SetToolTip(lb, "EEPM6，芯片从地址设置"); break;
                case "EEP_PWMFREQ (Hz)": toolTip.SetToolTip(lb, "EEPM7，PWM频率选择"); break;
                case "EEP_INTADDR": toolTip.SetToolTip(lb, "EEPM7，芯片从地址选择由外部引脚或内部寄存器配置"); break;
                case "EEP_OFAF": toolTip.SetToolTip(lb, "EEPM7，One Fail Others On/One Fail All Fail"); break;
                case "EEP_FLTIMEOUT": toolTip.SetToolTip(lb, "EEPM8，FlexWire超时设置"); break;
                case "EEP_ADCLOWSYPTH (V)": toolTip.SetToolTip(lb, "EEPM8，ADC电源监视阈值设定"); break;
                case "EEP_ODIOUT": toolTip.SetToolTip(lb, "EEPM9，按需诊断输出电流设置"); break;
                case "EEP_INITTIMER": toolTip.SetToolTip(lb, "EEPM9，按需诊断脉冲宽度设置"); break;
                case "EEP_ODPW": toolTip.SetToolTip(lb, "EEPM10，看门狗时钟设置"); break;
                case "EEP_WDTIMER": toolTip.SetToolTip(lb, "EEPM10，初始化时钟设置"); break;
                case "EEP_ADCSHORTTH": toolTip.SetToolTip(lb, "EEPM11，ADC短路检测阈值设定"); break;
                case "EEP_REFRANCE": toolTip.SetToolTip(lb, "EEPM7，参考电流系数"); break;
            }
        }
    }
}
