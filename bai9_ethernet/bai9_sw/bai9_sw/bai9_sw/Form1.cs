using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace bai9_sw
{
    public partial class Form1 : Form
    {
        IPEndPoint ipe;
        Socket server;
        Socket client;
        byte[] datasend = new byte[1];
        byte[] datareceive = new byte[1];
        
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult answer = MessageBox.Show("Do you want to exit the program?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(answer == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                try
                {
                    server.Close();
                    client.Close();
                } catch(Exception) {}
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int n = Int32.Parse(textBox5.Text); //lay gia tri cua textbox
                int n1 = Int32.Parse(textBox6.Text);
                int n2 = Int32.Parse(textBox7.Text);
                int n3 = Int32.Parse(textBox8.Text);
                if (n > 255 || n1 > 255 || n2 > 255 || n3 > 255)
                {
                    MessageBox.Show("value should not exceed 255 !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else 
                {
                    string ip = textBox5.Text.Trim() + "." + textBox6.Text.Trim() + "." + textBox7.Text.Trim() + "." + textBox8.Text.Trim();
                    int port = int.Parse(textBox9.Text.Trim());
                    ipe = new IPEndPoint(IPAddress.Parse(ip), port);
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                    server.Bind(ipe);

                    server.Listen(10);

                    client = server.Accept();
                    textBox1.BackColor = Color.Lime;
                    textBox1.Text = "Connected with: " + client.RemoteEndPoint.ToString();

                    Thread thread = new Thread(Receive);
                    thread.IsBackground = true;
                    thread.Start();
                } 
                    
            }
            catch(Exception)
            {
                MessageBox.Show("check the connection again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                server.Close();
                client.Close();
                textBox1.BackColor = Color.Red;
                textBox1.Text = "Disconnected!";
            }
            catch (Exception)
            {
                MessageBox.Show("check the connection again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RUN_S1_Click(object sender, EventArgs e)
        {
            try
            {
                datasend = Encoding.ASCII.GetBytes("!");
                client.Send(datasend, datasend.Length, SocketFlags.None);
            }
            catch (Exception)
            {
                MessageBox.Show("check the connection again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void STOP_S1_Click(object sender, EventArgs e)
        {
            try
            {
                datasend = Encoding.ASCII.GetBytes("#");
                client.Send(datasend, datasend.Length, SocketFlags.None);
            }
            catch (Exception)
            {
                MessageBox.Show("check the connection again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RUN_S2_Click(object sender, EventArgs e)
        {
            try
            {
                datasend = Encoding.ASCII.GetBytes("@");
                client.Send(datasend, datasend.Length, SocketFlags.None);
            }
            catch (Exception)
            {
                MessageBox.Show("check the connection again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void STOP_S2_Click(object sender, EventArgs e)
        {
            try
            {
                datasend = Encoding.ASCII.GetBytes("$");
                client.Send(datasend, datasend.Length, SocketFlags.None);
            }
            catch (Exception)
            {
                MessageBox.Show("check the connection again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Receive()
        {
            try
            {
                while(true)
                {
                    int temp = client.Receive(datareceive);
                    string s = Encoding.ASCII.GetString(datareceive, 0, temp);
                    if(s == "A")
                    {
                        textBox3.BackColor = Color.Lime;
                        textBox3.Text = "RUNNING";
                    }
                    else if (s == "a")
                    {
                        textBox3.BackColor = Color.Red;
                        textBox3.Text = "STOPPING";
                    }
                    else if (s == "B")
                    {
                        textBox2.BackColor = Color.Lime;
                        textBox2.Text = "RUNNING";
                    }
                    else if (s == "b")
                    {
                        textBox2.BackColor = Color.Red;
                        textBox2.Text = "STOPPING";
                    }
                }         
            }
            catch (Exception)
            {
                client.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                RUN_S1.Enabled = true;
                STOP_S1.Enabled = true;
                RUN_S2.Enabled = true;
                STOP_S2.Enabled = true;
                datasend = Encoding.ASCII.GetBytes("&");
                client.Send(datasend, datasend.Length, SocketFlags.None);
                button4.BackColor = Color.Yellow;
                button3.BackColor = Color.Gainsboro;

            }
            catch (Exception)
            {
                MessageBox.Show("check the connection again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                RUN_S1.Enabled = false;
                STOP_S1.Enabled = false;
                RUN_S2.Enabled = false;
                STOP_S2.Enabled = false;
                button3.BackColor = Color.Yellow;
                button4.BackColor = Color.Gainsboro;
            }
            catch (Exception)
            {
                MessageBox.Show("check the connection again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //chỉ cho phép nhập số
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
