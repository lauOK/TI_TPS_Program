using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace serialport
{
    public partial class Form1 : Form
    {
        private byte[] data_output = new byte[144];
        private byte[] ReadyToSend, RTS;
        private int SDNumb;
        private int RENumb;
        private byte[] buf = new byte[10];
        private byte flag_to_view = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] baud = { "115200", "128000", "230400", "256000", "460800", "500000" };
            Band.Items.AddRange(baud);
            port_Num.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            //串口默认设置
            port_Num.Text = System.IO.Ports.SerialPort.GetPortNames()[0];
            Band.Text = "500000";
            data_bits.Text = "8";
            crc_bits.Text = "None";
            stop_bits.Text = "1";
            OpenPort.BackColor = Color.ForestGreen;
            Transport.BackColor = Color.ForestGreen;
            OneAddr.Checked = true;
            Addr.SelectedIndex = 0;
            Rref.Text = Data.RREF.ToString();
        }

        private void OpenPort_Click(object sender, EventArgs e)//串口初始化
        {
            if (port_Num.Text == String.Empty)
            {
                MessageBox.Show("请选择端口号！");
            }
            else
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                    label7.Text = "串口已关闭";
                    label7.ForeColor = Color.Red;
                    OpenPort.Text = "打开串口";
                    OpenPort.BackColor = Color.ForestGreen;
                    port_Num.Enabled = true;
                    Band.Enabled = true;
                    data_bits.Enabled = true;
                    crc_bits.Enabled = true;
                    stop_bits.Enabled = true;
                }
                else
                {
                    port_Num.Enabled = false;
                    Band.Enabled = false;
                    data_bits.Enabled = false;
                    crc_bits.Enabled = false;
                    stop_bits.Enabled = false;

                    serialPort1.PortName = port_Num.Text;
                    serialPort1.BaudRate = Convert.ToInt32(Band.Text);
                    serialPort1.DataBits = Convert.ToInt16(data_bits.Text);
                    serialPort1.Parity = System.IO.Ports.Parity.None;

                    if (stop_bits.Text.Equals("1"))
                        serialPort1.StopBits = System.IO.Ports.StopBits.One;
                    else if (stop_bits.Text.Equals("1.5"))
                        serialPort1.StopBits = System.IO.Ports.StopBits.OnePointFive;
                    else if (stop_bits.Text.Equals("2"))
                        serialPort1.StopBits = System.IO.Ports.StopBits.Two;

                    serialPort1.Open();
                    label7.Text = "串口已打开";
                    label7.ForeColor = Color.Green;
                    OpenPort.Text = "关闭串口";
                    OpenPort.BackColor = Color.Firebrick;
                }
            }
        }

        private void Transport_Click(object sender, EventArgs e) //串口发送
        {
            int num;
            if (serialPort1.IsOpen)
            {
                //16进制发送
                string rds = InputBox.Text.Replace(" ", "");//去除输入的空格
                num = (rds.Length - rds.Length % 2) / 2;
                if (rds.Length % 2 == 0) //判断用户输入是否为偶数
                {
                    ReadyToSend = new byte[num];
                    for (int i = 0; i < num; i++)
                    {
                        ReadyToSend[i] = Convert.ToByte(rds.Substring(i * 2, 2), 16);
                    }
                }
                else
                {
                    int k = num + 1;
                    ReadyToSend = new byte[k];
                    for (int i = 0; i < k - 1; i++)
                    {
                        ReadyToSend[i] = Convert.ToByte(rds.Substring(i * 2, 2), 16);
                    }
                    ReadyToSend[k - 1] = Convert.ToByte(rds.Substring(rds.Length - 1, 1), 16);
                }
                RTS = ReadyToSend;
                serialPort1.Write(RTS, 0, RTS.Length);
                SDNumb += RTS.Length;
            }
            else
            {
                MessageBox.Show("串口未开启！");
            }
            label_Tx.Text = "TX:" + SDNumb.ToString() + "Bytes";
        }

        private void TPS_Send_Click(object sender, EventArgs e)//TPS 芯片烧写
        {
            if (serialPort1.IsOpen)
            {
                if (MutilAddr.Checked)
                {
                    Data.addr = 0;
                    for (int i = 0; i < 16; i++)
                    {
                        TPS_UnLock();
                        for (int j = 0; j < 40; j++)
                        {
                            InputBox.Clear();
                            byte len = Data.TPS_write_1byte(Data.addr, Data.EEPaddress[j], Data.EEPvalue[j], ref buf);
                            for (int k = 0; k < len; k++)
                            {
                                InputBox.Text += buf[k].ToString("X2") + " ";
                            }
                            serialPort1.Write(buf, 0, len);
                            SDNumb += len;
                        }
                        TPS_Lock();
                        Data.addr++;
                    }
                }
                else
                {
                    TPS_UnLock();
                    for (int i = 0; i < 40; i++)
                    {
                        InputBox.Clear();
                        byte len = Data.TPS_write_1byte(Data.addr, Data.EEPaddress[i], Data.EEPvalue[i], ref buf);
                        for (int j = 0; j < len; j++)
                        {
                            InputBox.Text += buf[j].ToString("X2") + " ";
                        }
                        serialPort1.Write(buf, 0, len);
                        SDNumb += len;
                    }
                    TPS_Lock();
                }
                Input_Data_Change();
            }
            else
            {
                MessageBox.Show("串口未开启！");
            }
            label_Tx.Text = "TX:" + SDNumb.ToString() + "Bytes";
        }


        private void SerialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            int RecvNum = serialPort1.BytesToRead;
            byte[] RecvBuff = new byte[RecvNum];
            serialPort1.Read(RecvBuff, 0, RecvNum);
            RENumb += RecvNum;
            label_Rx.Text = "RX:" + RENumb.ToString() + "Bytes";

            for (int i = 0; i < RecvNum; i++)
            {
                if (RecvBuff[i] == 0x55)
                {
                    OutputBox.AppendText("\r\n");
                }
                OutputBox.AppendText(RecvBuff[i].ToString("X2") + " ");
            }
            OutputBox.Text = OutputBox.Text.Trim();
            Output_Data_Check();
        }

        private void Clear_RSV_Click(object sender, EventArgs e)//清除接受缓冲区
        {
            OutputBox.Text = null;
            RENumb = 0;
            label_Rx.Text = "RX:0Bytes";
        }

        private void Clear_Tran_Click(object sender, EventArgs e)//清除发送缓冲区
        {
            InputBox.Text = null;
            SDNumb = 0;
            label_Tx.Text = "TX:0Bytes";
        }

        private void InputBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool IsNum = (e.KeyChar >= 48) && (e.KeyChar <= 57);//判断输入是不是数字
            bool IsAplha = (e.KeyChar >= 'A') && (e.KeyChar <= 'F');//判断输入是不是大写字母
            bool Isalpha = (e.KeyChar >= 'a') && (e.KeyChar <= 'f');//判断输入是不是小写字母
            bool Ispermit = e.KeyChar == 8 || e.KeyChar == 32;//判断输入是不是退格和空格
            if (IsNum || IsAplha || Isalpha || Ispermit)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("合法的输入为0-9，a-f，A-F，空格和退格");
            }
        }

        private void DataSet_Click(object sender, EventArgs e)
        {
            new Form2(this).ShowDialog();
        }

        private void TPS_Lock()
        {
            //LOCK           0x61
            //CONF_EEPGATE   0x65
            //CONF_EEPMODE   0x63 bit0
            //CONF_STAYINEEP 0x62 bit7
            //CONF_EEPPROG   0x64 bit2
            byte len = Data.TPS_write_1byte(Data.addr, 0x64, 0x04, ref buf);
            serialPort1.Write(buf, 0, len);
            System.Threading.Thread.Sleep(200);

            len = Data.TPS_write_1byte(Data.addr, 0x62, 0x00, ref buf);
            serialPort1.Write(buf, 0, len);
        }

        private void TPS_UnLock()
        {
            //CLR_REG        0x60 bit4
            //LOCK           0x61 bit4
            //CONF_EEPGATE   0x65
            //CONF_EEPMODE   0x63 bit0
            //CONF_STAYINEEP 0x62 bit7
            //CONF_EEPPROG   0x64 bit2
            byte[] reg = new byte[10] { 0x61, 0x60, 0x65, 0x65, 0x65, 0x65, 0x65, 0x65, 0x63, 0x62 };
            byte[] dat = new byte[10] { 0x00, 0x07, 0x00, 0x02, 0x01, 0x09, 0x02, 0x09, 0x01, 0x80 };

            for (int i = 0; i < 10; i++)
            {
                byte len = Data.TPS_write_1byte(Data.addr, reg[i], dat[i], ref buf);
                serialPort1.Write(buf, 0, len);
                System.Threading.Thread.Sleep(10);
            }
        }

        private void OneAddr_CheckedChanged(object sender, EventArgs e)
        {
            Addr.Enabled = OneAddr.Checked;
            if (OneAddr.Checked)
            {
                MutilAddr.Checked = false;
            }
        }

        private void MutilAddr_CheckedChanged(object sender, EventArgs e)
        {
            if (MutilAddr.Checked)
            {
                OneAddr.Checked = false;
            }
        }

        private void Data_input_Click(object sender, EventArgs e)
        {
            if (Input_path.Text == string.Empty)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "CSV文件|*.csv;*.CSV";
                ofd.ShowDialog();
                Data.path_input = ofd.FileName;
                Input_path.Text = Data.path_input;
            }

            var result = MessageBox.Show(null, "要导入的文件路径为：" + Data.path_input, "导入确认", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                FileStream fs = new FileStream(Data.path_input, FileMode.Open, FileAccess.Read);
                StreamReader sw = new StreamReader(fs);
                sw.ReadLine();//先读一行，去除标题
                for (int i = 0; i < 39; i++)//写入EEP0~38，不导入CRC
                {
                    Data.EEPvalue[i] = Convert.ToByte(sw.ReadLine().Split(',')[1]);
                }
                Data.EEPvalue[39] = Data.CRC(Data.EEPvalue, 39);
                sw.Close();
                fs.Close();

                Data.Ifull_Calcu();
                I_Full.Text = Data.IFULL.ToString("0.000000");
                //Data.flag = false;

                MessageBox.Show("导入完成");
            }
            else
            {
                Input_path.Text = String.Empty;
            }
        }

        private void TPS_Test_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                OutputBox.Clear();
                for (int i = 0; i < 24; i++)
                {
                    byte length = Data.TPS_read_1byte(Data.addr, Data.EEPaddress[i], ref buf);
                    serialPort1.Write(buf, 0, length);
                    System.Threading.Thread.Sleep(10);
                }
            }
            else
            {
                MessageBox.Show("123");
            }
        }

        private void Label_state_double_Click(object sender, EventArgs e)
        {
            flag_to_view++;
            if (flag_to_view == 4)
            {
                DataSet.Visible = !DataSet.Visible;
                flag_to_view = 0;
            }
        }

        private void Addr_SelectedIndexChanged(object sender, EventArgs e)
        {
            Data.addr = Convert.ToByte(Addr.Text);
        }

        private void Input_Data_Change()
        {
            for (int i = 1; i < 13; i++)
            {
                TextBox tb = (TextBox)this.groupBox1.Controls["value" + i.ToString() + "d"];
                tb.Text = ((double)Data.EEPvalue[i - 1] / (double)63 * Data.IFULL).ToString("0.000000");
            }
            for (int i = 13; i < 25; i++)
            {
                TextBox tb = (TextBox)this.groupBox1.Controls["value" + i.ToString() + "p"];
                tb.Text = ((double)Data.EEPvalue[i - 1] / (double)255 * (double)100).ToString("#0.0");
            }
        }

        private void Output_Data_Check()
        {

            string str = OutputBox.Text.Replace("\r\n", "");
            str = str.Replace(" ", "");
            Input_path.Text = str;

            if (str.Length == 192)
            {
                for (int i = 0; i < 96; i++)
                {
                    data_output[i] = Convert.ToByte(str.Substring(i * 2, 2), 16);
                }

                for (int i = 1; i < 25; i++)
                {
                    if (i < 13)
                    {
                        TextBox tb = (TextBox)this.groupBox1.Controls["value" + i.ToString()];
                        tb.Text = ((double)data_output[(i - 1) * 4 + 1] / (double)63 * Data.IFULL).ToString("0.000000");
                    }
                    else
                    {
                        TextBox tb = (TextBox)this.groupBox1.Controls["value" + i.ToString()];
                        tb.Text = ((double)data_output[(i - 1) * 4 + 1] / (double)255 * (double)100).ToString("#0.0");
                    }
                }
            }
        }
    }
}
