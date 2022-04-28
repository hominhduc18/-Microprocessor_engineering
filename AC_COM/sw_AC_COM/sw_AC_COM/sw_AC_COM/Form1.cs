using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;

namespace sw_AC_COM
{
    public partial class Form1 : Form
    {
        string ReceiveData = String.Empty;
        string TransmitData = String.Empty;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();

            foreach (string port in ports)
            {
                comboBox1.Items.Add(port);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.PortName = comboBox1.Text;
        }
        private void button12_Click(object sender, EventArgs e)
        {
            if (button12.Enabled == true)
            {
                try
                {
                    if (serialPort1.IsOpen)
                    {
                        TransmitData = "*";
                        serialPort1.Write(TransmitData);
                        button12.Enabled = false;
                        button6.Enabled = true;
                        button8.Enabled = true;
                        TransmitData = ")";
                        serialPort1.Write(TransmitData);
                    }
                    else
                    {
                        MessageBox.Show("COM Port is Disconnected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("COM Port is not found. Please check your COM or Cable.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.BackColor == Color.Gainsboro)
            {
                try
                {
                    if (serialPort1.IsOpen)
                    {
                        TransmitData = "#";
                        serialPort1.Write(TransmitData);
                        button4.BackColor = Color.Yellow;
                    }
                    else
                    {
                        MessageBox.Show("COM Port is Disconnected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("COM Port is not found. Please check your COM or Cable.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    if (serialPort1.IsOpen)
                    {
                        TransmitData = "$";
                        serialPort1.Write(TransmitData);
                        button4.BackColor = Color.Gainsboro;
                    }
                    else
                    {
                        MessageBox.Show("COM Port is Disconnected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("COM Port is not found. Please check your COM or Cable.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Select COM Port.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    if (serialPort1.IsOpen)
                    {
                        MessageBox.Show("COM Port is connected and ready for use.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        serialPort1.Open();
                        textBox1.BackColor = Color.Green;
                        textBox1.Text = "Connecting..";
                        comboBox1.Enabled = false;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("COM Port is not found. Please check your COM or Cable.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                    textBox1.BackColor = Color.Red;
                    textBox1.Text = "Disconnected!";
                    comboBox1.Enabled = true;                    
                }
                else
                {
                    MessageBox.Show("COM Port is Disconnected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("COM Port is not found. Please check your COM or Cable.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.BackColor == Color.Gainsboro)
            {
                try
                {
                    if (serialPort1.IsOpen)
                    {
                        TransmitData = "!";
                        serialPort1.Write(TransmitData);
                        button3.BackColor = Color.Yellow;

                    }
                    else
                    {
                        MessageBox.Show("COM Port is Disconnected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("COM Port is not found. Please check your COM or Cable.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    if (serialPort1.IsOpen)
                    {
                        TransmitData = "@";
                        serialPort1.Write(TransmitData);
                        button3.BackColor = Color.Gainsboro;

                    }
                    else
                    {
                        MessageBox.Show("COM Port is Disconnected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("COM Port is not found. Please check your COM or Cable.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.BackColor == Color.Gainsboro)
            {
                try
                {
                    if (serialPort1.IsOpen)
                    {
                        TransmitData = "%";
                        serialPort1.Write(TransmitData);
                        button5.BackColor = Color.Yellow;
                    }
                    else
                    {
                        MessageBox.Show("COM Port is Disconnected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("COM Port is not found. Please check your COM or Cable.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    if (serialPort1.IsOpen)
                    {
                        TransmitData = "^";
                        serialPort1.Write(TransmitData);
                        button5.BackColor = Color.Gainsboro;
                    }
                    else
                    {
                        MessageBox.Show("COM Port is Disconnected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("COM Port is not found. Please check your COM or Cable.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            ReceiveData = serialPort1.ReadExisting();
            this.Invoke(new EventHandler(DoUpDate));
        }

        private void DoUpDate(object sender, EventArgs e)
        {
            if (ReceiveData == "q")
            {
                button3.Image = sw_AC_COM.Properties.Resources.DEN_SANG;
                button3.BackColor = Color.Yellow;
            }
            else if (ReceiveData == "w")
            {
                button3.Image = sw_AC_COM.Properties.Resources.DEN_TAT;
                button3.BackColor = Color.Gainsboro;
            }
            else if (ReceiveData == "e")
            {
                button4.Image = sw_AC_COM.Properties.Resources.DEN_SANG;
                button4.BackColor = Color.Yellow;
            }
            else if (ReceiveData == "r")
            {
                button4.Image = sw_AC_COM.Properties.Resources.DEN_TAT;
                button4.BackColor = Color.Gainsboro;
            }
            else if (ReceiveData == "t")
            {
                button5.Image = sw_AC_COM.Properties.Resources.DEN_SANG;
                button5.BackColor = Color.Yellow;
            }
            else if (ReceiveData == "y")
            {
                button5.Image = sw_AC_COM.Properties.Resources.DEN_TAT;
                button5.BackColor = Color.Gainsboro;
            }
            else if (ReceiveData == "c")
            {
                button6.Image = sw_AC_COM.Properties.Resources.thuan11;              
            }
            else if (ReceiveData == "v")
            {              
                button8.Image = sw_AC_COM.Properties.Resources.nghich11;
                if(button12.Enabled == false)
                {
                    button8.Image = sw_AC_COM.Properties.Resources.nghich1;
                    button6.Enabled = false;
                    button8.Enabled = false;
                    Thread.Sleep(7000);
                    button6.Enabled = true;
                    button8.Enabled = true;

                }    

            }
            else if (ReceiveData == "x")
            {                
                button6.Image = sw_AC_COM.Properties.Resources.thuan1;
                button8.Image = sw_AC_COM.Properties.Resources.nghich1;
            }
            else if (ReceiveData == "m")
            {
                button7.Image = sw_AC_COM.Properties.Resources.thuan11;
            }
            else if (ReceiveData == "l")
            {
                button10.Image = sw_AC_COM.Properties.Resources.nghich11;
                if (button9.Enabled == false)
                {

                    button10.Image = sw_AC_COM.Properties.Resources.nghich1;
                    button7.Enabled = false;
                    button10.Enabled = false;
                    Thread.Sleep(7000);
                    button7.Enabled = true;
                    button10.Enabled = true;
                }
            }
            else if (ReceiveData == "n")
            {
                button7.Image = sw_AC_COM.Properties.Resources.thuan1;
                button10.Image = sw_AC_COM.Properties.Resources.nghich1;
            }
            else if(ReceiveData == "A")
            {
                pictureBox5.Image = sw_AC_COM.Properties.Resources.ON;
            }
            else if (ReceiveData == "S")
            {
                pictureBox5.Image = sw_AC_COM.Properties.Resources.OFF;
            }
            else if (ReceiveData == "D")
            {
                pictureBox4.Image = sw_AC_COM.Properties.Resources.ON;
            }
            else if (ReceiveData == "F")
            {
                pictureBox4.Image = sw_AC_COM.Properties.Resources.OFF;
            }
            else if (ReceiveData == "G")
            {
                pictureBox3.Image = sw_AC_COM.Properties.Resources.ON;
            }
            else if (ReceiveData == "H")
            {
                pictureBox3.Image = sw_AC_COM.Properties.Resources.OFF;
            }
            else if (ReceiveData == "1")
            {
                pictureBox8.Image = sw_AC_COM.Properties.Resources.ON;
            }
            else if (ReceiveData == "2")
            {
                pictureBox8.Image = sw_AC_COM.Properties.Resources.OFF;
            }
            else if (ReceiveData == "3")
            {
                pictureBox7.Image = sw_AC_COM.Properties.Resources.ON;
            }
            else if (ReceiveData == "4")
            {
                pictureBox7.Image = sw_AC_COM.Properties.Resources.OFF;
            }
            else if (ReceiveData == "5")
            {
                pictureBox6.Image = sw_AC_COM.Properties.Resources.ON;
            }
            else if (ReceiveData == "6")
            {
                pictureBox6.Image = sw_AC_COM.Properties.Resources.OFF;
            }
        }

        
        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                   
                    TransmitData = "&";
                    serialPort1.Write(TransmitData);
                    button12.Enabled = true;
                    button6.Enabled = false;
                    TransmitData = ")";
                    serialPort1.Write(TransmitData);
                }
                else
                {
                    MessageBox.Show("COM Port is Disconnected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("COM Port is not found. Please check your COM or Cable.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (button9.Enabled == true)
            {
                try
                {
                    if (serialPort1.IsOpen)
                    {
                        TransmitData = "+";
                        serialPort1.Write(TransmitData);
                        button9.Enabled = false;
                        button7.Enabled = true;
                        button10.Enabled = true;
                        TransmitData = ">";
                        serialPort1.Write(TransmitData);
                    }
                    else
                    {
                        MessageBox.Show("COM Port is Disconnected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("COM Port is not found. Please check your COM or Cable.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    TransmitData = "_";
                    serialPort1.Write(TransmitData);
                    button9.Enabled = true;
                    button10.Enabled = false;
                    TransmitData = "<";
                    serialPort1.Write(TransmitData);
                }
                else
                {
                    MessageBox.Show("COM Port is Disconnected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("COM Port is not found. Please check your COM or Cable.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    TransmitData = "_";
                    serialPort1.Write(TransmitData);
                    button9.Enabled = true;
                    button7.Enabled = false;
                    TransmitData = ">";
                    serialPort1.Write(TransmitData);
                }
                else
                {
                    MessageBox.Show("COM Port is Disconnected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("COM Port is not found. Please check your COM or Cable.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult answer = MessageBox.Show("Do you want to exit the program?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {

                    TransmitData = "&";
                    serialPort1.Write(TransmitData);
                    button12.Enabled = true;
                    button8.Enabled = false;
                    TransmitData = "(";
                    serialPort1.Write(TransmitData);                                                      
                }
                else
                {
                    MessageBox.Show("COM Port is Disconnected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("COM Port is not found. Please check your COM or Cable.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
