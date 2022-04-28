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
using System.Threading;

namespace bai8_sw
{
    public partial class Form1 : Form
    {
        string ReceiveData = String.Empty;
        string TransmitData = String.Empty;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

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
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            ReceiveData = serialPort1.ReadExisting();
            this.Invoke(new EventHandler(DoUpDate));
        }
        private void DoUpDate(object sender, EventArgs e)
        {

            if (ReceiveData == "A")
            {
                textBox3.BackColor = Color.Lime;
                textBox3.Text = "IS OPEN..";
            }
            else if (ReceiveData == "S")
            {
                textBox3.BackColor = Color.Yellow;
                textBox3.Text = "IS CLOSE..";
            }
            else if (ReceiveData == "D")
            {
                textBox3.BackColor = Color.Red;
                textBox3.Text = "PAUSE";
            }
            else if (ReceiveData == "G")
            {
                textBox3.BackColor = Color.Turquoise;
                textBox3.Text = "OPEN_OK";
            }
            else if (ReceiveData == "H")
            {
                textBox3.BackColor = Color.Turquoise;
                textBox3.Text = "CLOSE_OK";
            }
            else if (ReceiveData == "O")
            {
                textBox2.BackColor = Color.Yellow;
            }
            else if (ReceiveData == "F")
            {
                textBox2.BackColor = Color.Black;
            }
            else if (ReceiveData == "C")
            {
                textBox4.BackColor = Color.Lime;
                textBox4.Text = "ON";
            }
            else if (ReceiveData == "V")
            {
                textBox4.BackColor = Color.Red;
                textBox4.Text = "OFF";
            }
            else if (ReceiveData == "Q" || ReceiveData == "W")
            {
                textBox3.Text = "Waiting 5 s";
                textBox3.BackColor = Color.White;
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
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == " ")
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
            try
            {
                if (serialPort1.IsOpen)
                {
                    if (textBox3.Text == "OPEN_OK")
                    {
                        MessageBox.Show("The door has been opened.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        textBox3.Text = "Waiting 5 s";
                        textBox3.BackColor = Color.White;
                        TransmitData = "!";
                        serialPort1.Write(TransmitData);
                    }
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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    if (textBox3.Text == "CLOSE_OK")
                    {
                        MessageBox.Show("The door has been closed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                          textBox3.Text = "Waiting 5 s";
                          textBox3.BackColor = Color.White;
                          TransmitData = "@";
                          serialPort1.Write(TransmitData);
                            
                    }
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

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    if (textBox3.Text == "OPEN_OK")
                    {
                        MessageBox.Show("The door has been opened.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (textBox3.Text == "CLOSE_OK")
                    {
                        MessageBox.Show("The door has been closed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        TransmitData = "#";
                        serialPort1.Write(TransmitData);
                    }
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
