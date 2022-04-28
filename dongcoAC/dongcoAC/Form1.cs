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
namespace dongcoAC
{
    public partial class Form1 : Form
    {
        string ReceiveData = string.Empty;//
        string TransmitData = string.Empty;
        int count1 = 0;
        int count2 = 0;
        int count3 = 0;
        int sw1 = 0;
        int sw2 = 0;
        int sw3 = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.PortName = comboBox1.Text;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (button9.BackColor==Color.White)
            {

                try// ngược lại vs connected
                {
                    if (serialPort1.IsOpen)
                    {
                        TransmitData = "@";
                        serialPort1.Write(TransmitData);//gửi đi
                        button9.BackColor = Color.Yellow;
                    }
                    else
                    {
                        MessageBox.Show("Com Port is connecting", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Com Port is not found.Please check your Com or Cable", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try// ngược lại vs connected
                {
                    if (serialPort1.IsOpen)
                    {
                        TransmitData = "!";
                        serialPort1.Write(TransmitData);//gửi đi
                        button9.BackColor = Color.White;
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
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            serialPort1.PortName = comboBox1.Text;
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            try// ngược lại vs connected
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                    textBox1.BackColor = Color.Red;
                    textBox1.Text = "Disconnected";
                    comboBox1.Enabled = true;// khi ket nối thì khóa combo box
                    if(button9.BackColor==Color.Yellow)
                    {
                        button9.BackColor = Color.White;
                    }
                    if (button11.BackColor == Color.Yellow)
                    {
                        button11.BackColor = Color.White;
                    }
                    if (button10.BackColor == Color.Yellow)
                    {
                        button10.BackColor = Color.White;
                    }
                }
                else
                {
                    MessageBox.Show("Com Port is connecting", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            //cong com đã bị chiem và sư dung
            catch (Exception)
            {
                MessageBox.Show("Com Port is not found.Please check your Com or Cable", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            try// ngược lại vs connected
            {
                if (serialPort1.IsOpen)
                {
                    TransmitData = "<";
                    serialPort1.Write(TransmitData);//gửi đi
                    TransmitData = "|";
                    serialPort1.Write(TransmitData);//gửi đi
                }
                else
                {
                    MessageBox.Show("Com Port is connecting", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                {
                    button5.Enabled = true;
                    button13.Enabled = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Com Port is not found.Please check your Com or Cable", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            try// ngược lại vs connected
            {
                if (serialPort1.IsOpen)
                {
                    TransmitData = "_";
                    serialPort1.Write(TransmitData);//gửi đi
                }
                else
                {
                    MessageBox.Show("Com Port is connecting", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                {
                    button3.Enabled = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Com Port is not found.Please check your Com or Cable", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (button11.BackColor == Color.White)
            {
                try// ngược lại vs connected
                {
                    if (serialPort1.IsOpen)
                    {
                        TransmitData = "#";
                        serialPort1.Write(TransmitData);//gửi đi
                        button11.BackColor = Color.Yellow;
                    }
                    else
                    {
                        MessageBox.Show("Com Port is connecting", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Com Port is not found.Please check your Com or Cable", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                try// ngược lại vs connected
                {
                    if (serialPort1.IsOpen)
                    {
                        TransmitData = "$";
                        serialPort1.Write(TransmitData);//gửi đi
                        button11.BackColor = Color.White;
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

        private void button10_Click(object sender, EventArgs e)
        {
            if (button10.BackColor == Color.White)
            {
                try// ngược lại vs connected
                {
                    if (serialPort1.IsOpen)
                    {
                        TransmitData = "^";
                        serialPort1.Write(TransmitData);//gửi đi
                        button10.BackColor = Color.Yellow;
                    }
                    else
                    {
                        MessageBox.Show("Com Port is connecting", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Com Port is not found.Please check your Com or Cable", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                try// ngược lại vs connected
                {
                    if (serialPort1.IsOpen)
                    {
                        TransmitData = "*";
                        serialPort1.Write(TransmitData);//gửi đi
                        button10.BackColor = Color.White;
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
       

        private void button12_Click(object sender, EventArgs e)
        {
            try// ngược lại vs connected
            {
                if (serialPort1.IsOpen)
                {
                    TransmitData = ",";
                    serialPort1.Write(TransmitData);//gửi đi
                }
                else
                {
                    MessageBox.Show("Com Port is connecting", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                {
                    button3.Enabled = true;
                }
            }
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
                        button3.Enabled = false;
                        TransmitData = "+";
                        serialPort1.Write(TransmitData);//gửi đi
               
                    }
                    else
                    {
                        MessageBox.Show("Com Port is connecting", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    {
                        button6.Enabled = false;
                        button12.Enabled = false;
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
                    TransmitData = ";";
                    serialPort1.Write(TransmitData);//gửi đi
                    TransmitData = ",";
                    serialPort1.Write(TransmitData);//gửi đi
                }
                else
                {
                    MessageBox.Show("Com Port is connecting", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                {
                    button6.Enabled = true;
                    button12.Enabled = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Com Port is not found.Please check your Com or Cable", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            ReceiveData = serialPort1.ReadExisting();
            this.Invoke(new EventHandler(DoUpDate));

        }
        private void DoUpDate(object sender, EventArgs e)
        {
            if(ReceiveData=="d")
             {
                button9.Image = dongcoAC.Properties.Resources.on;
            }
            else if (ReceiveData == "c")
            {
                button9.Image = dongcoAC.Properties.Resources.off;
            }
            else  if(ReceiveData == "g")
             {
                button11.Image = dongcoAC.Properties.Resources.on;
            }
            else if (ReceiveData == "h")
            {
                button11.Image = dongcoAC.Properties.Resources.off;
            }
            else if (ReceiveData == "j")
            {
                button10.Image = dongcoAC.Properties.Resources.on;
            }
            else if (ReceiveData == "k")
            {
                button10.Image = dongcoAC.Properties.Resources.off;
            }
            else if (ReceiveData == "s")
            {
                count1++;
                textBox2.Text = count1.ToString();// count là số muốn hiển thi thì đổi sang string 
            }
            else if (ReceiveData == "a")
            {
                count2++;
                textBox3.Text = count2.ToString();// count là số muốn hiển thi thì đổi sang string 
            }
            else if (ReceiveData == "b")
            {
                count3++;
                textBox4.Text = count3.ToString();// count là số muốn hiển thi thì đổi sang string 
            }
            else if (ReceiveData == "E")
            {
                sw1++;
                textBox5.Text = sw1.ToString();// count là số muốn hiển thi thì đổi sang string 
            }
            else if (ReceiveData == "D")
            {
                sw2++;
                textBox6.Text = sw2.ToString();// count là số muốn hiển thi thì đổi sang string 
            }
            else if (ReceiveData == "F")
            {
                sw3++;
                textBox7.Text = sw3.ToString();// count là số muốn hiển thi thì đổi sang string 
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            try// ngược lại vs connected
            {
                if (serialPort1.IsOpen)
                {
                    TransmitData = ">";
                    serialPort1.Write(TransmitData);//gửi đi
                }
                else
                {
                    MessageBox.Show("Com Port is connecting", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                {
                    button7.Enabled = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Com Port is not found.Please check your Com or Cable", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try// ngược lại vs connected
            {
                if (serialPort1.IsOpen)
                {
                    TransmitData = "|";
                    serialPort1.Write(TransmitData);//gửi đi
                }
                else
                {
                    MessageBox.Show("Com Port is connecting", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                {
                    button7.Enabled = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Com Port is not found.Please check your Com or Cable", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            try// ngược lại vs connected
            {
                if (serialPort1.IsOpen)
                {
                    button7.Enabled = false;
                    TransmitData = "=";
                    serialPort1.Write(TransmitData);//gửi đi

                }
                else
                {
                    MessageBox.Show("Com Port is connecting", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                {
                    button5.Enabled = false;
                    button13.Enabled = false;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Com Port is not found.Please check your Com or Cable", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // dong giao diện 
            DialogResult answer = MessageBox.Show("Do you want to exit the program", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void button9_MouseHover(object sender, EventArgs e)
        {
        }
    }
}
