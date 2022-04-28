using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;

namespace t2
{
    public partial class Form1 : Form
    {
        string ReceiveData = string.Empty;//
        string TransmitData = string.Empty;//chưa dữ liẹu trừ máy tính ra thiết bị 
        int count = 0;
        int count1 = 0;
        int count2 = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // cho phép ng dùng chọn cổng com 
            serialPort1.PortName = comboBox1.Text;



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //lấy thông tin cổng com từ may tính 
            string[] ports = SerialPort.GetPortNames();
            // đưa cổng com vào combobox
            foreach (string port in ports)
            {
                comboBox1.Items.Add(port);
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // cho phép cổng com hoat động,mở cong com
            // serialPort1.Open();
            //thông báo lỗi khi ng dùng chọn sai
            //+ ng dung quen chon cong com
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Select COM Port.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // đã két nối rồi còn ấn nữa
            else
            {
                try
                {
                    if (serialPort1.IsOpen)
                    {
                        MessageBox.Show("Com Port is connected and readly for use", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        serialPort1.Open();
                        // đổi màu từ đỏ sang xanh 
                        textBox1.BackColor = Color.Green;
                        textBox1.Text = "Conecting....";
                        comboBox1.Enabled = false;// khi ket nối thì khóa combo box
                    }
                }
                //cong com đã bị chiem và sư dung
                catch (Exception)
                {
                    MessageBox.Show("Com Port is not found.Please check your Com or Cable", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            try// ngược lại vs connected
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                    textBox1.BackColor = Color.Red;
                    textBox1.Text = "Disconnected";
                    comboBox1.Enabled = true;// khi ket nối thì khóa combo box
                }
                else
                {
                    MessageBox.Show("Com Port is disconnected", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            //cong com đã bị chiem và sư dung
            catch (Exception)
            {
                MessageBox.Show("Com Port is not found.Please check your Com or Cable", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try// ngược lại vs connected
            {
                if (serialPort1.IsOpen)
                {
                    TransmitData = "@";
                    serialPort1.Write(TransmitData);//gửi đi
                }
                else
                {
                    MessageBox.Show("Com Port is connectìn", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Com Port is not found.Please check your Com or Cable", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try// ngược lại vs connected
            {
                if (serialPort1.IsOpen)
                {
                    TransmitData = "!";
                    serialPort1.Write(TransmitData);//gửi đi
                }
                else
                {
                    MessageBox.Show("Com Port is disconnected", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Com Port is not found.Please check your Com or Cable", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //tao sự kiện để hiển thị led 
            ReceiveData = serialPort1.ReadExisting();
            this.Invoke(new EventHandler(DoUpDate));
        }
        private void DoUpDate(object sender, EventArgs e)
        {
            if(ReceiveData=="d")
            {
                pictureBox1.Image = t2.Properties.Resources.bat;
            }   
            else if(ReceiveData=="c")
            {
                pictureBox1.Image = t2.Properties.Resources.off;

            }
            else if (ReceiveData == "e")
            {
                pictureBox2.Image = t2.Properties.Resources.bat;
            }
            else if (ReceiveData == "f")
            {
                pictureBox2.Image = t2.Properties.Resources.off;
            }
            else if (ReceiveData == "h")
            {
                pictureBox3.Image = t2.Properties.Resources.bat;
            }
            else if (ReceiveData == "g")
            {
                pictureBox3.Image = t2.Properties.Resources.off;

            }
            else if(ReceiveData=="s")
            {
                count++;
                textBox2.Text = count.ToString();// count là số muốn hiển thi thì đổi sang string 
            }
            else if (ReceiveData == "a")
            {
                count1++;
                textBox3.Text = count1.ToString();// count là số muốn hiển thi thì đổi sang string 
            }
            else if (ReceiveData == "b")
            {
                count2++;
                textBox4.Text = count2.ToString();// count là số muốn hiển thi thì đổi sang string 
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // dong giao diện 
            DialogResult answer = MessageBox.Show("Do you want to exit the program", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(answer==DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                if(serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }    
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try// ngược lại vs connected
            {
                if (serialPort1.IsOpen)
                {
                    TransmitData = "#";
                    serialPort1.Write(TransmitData);//gửi đi
                }
                else
                {
                    MessageBox.Show("Com Port is connectìn", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Com Port is not found.Please check your Com or Cable", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try// ngược lại vs connected
            {
                if (serialPort1.IsOpen)
                {
                    TransmitData = "$";
                    serialPort1.Write(TransmitData);//gửi đi
                }
                else
                {
                    MessageBox.Show("Com Port is disconnected", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Com Port is not found.Please check your Com or Cable", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try// ngược lại vs connected
            {
                if (serialPort1.IsOpen)
                {
                    TransmitData = "^";
                    serialPort1.Write(TransmitData);//gửi đi
                }
                else
                {
                    MessageBox.Show("Com Port is connectìn", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Com Port is not found.Please check your Com or Cable", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try// ngược lại vs connected
            {
                if (serialPort1.IsOpen)
                {
                    TransmitData = "&";
                    serialPort1.Write(TransmitData);//gửi đi
                }
                else
                {
                    MessageBox.Show("Com Port is disconnected", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Com Port is not found.Please check your Com or Cable", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
