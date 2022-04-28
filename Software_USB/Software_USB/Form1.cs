using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsbLibrary;

namespace Software_USB
{
    public partial class Form1 : Form
    {
        byte[] readbuff = new byte[4];// SỐ BIT
        byte[] writebuff = new byte[4];
        int count1 = 0;
        int count2 = 0;
        int count3 = 0;
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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            usbHidPort1.VendorId = 0x0408;
            usbHidPort1.ProductId = 0x0001;
            //ktra usb đc kết nối chưa
            usbHidPort1.CheckDevicePresent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult answer = MessageBox.Show("DO YOU WANT TO EXIT THE PROGRAM ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(answer==DialogResult.No)
            {
                e.Cancel = true;
            }
            writebuff[1] = (byte)'!';
            usbHidPort1.SpecifiedDevice.SendData(writebuff);
            writebuff[2] = (byte)'!';
            usbHidPort1.SpecifiedDevice.SendData(writebuff);
            writebuff[3] = (byte)'!';
            usbHidPort1.SpecifiedDevice.SendData(writebuff);
        }
        // nhận sự kiện từ bên ngoài 
        private void usbHidPort1_OnDataRecieved(object sender, DataRecievedEventArgs args)
        {
            if (InvokeRequired)
            {
                try
                {
                    Invoke(new DataRecievedEventHandler(usbHidPort1_OnDataRecieved), new object[] { sender, args });
                }
                catch
                { }
            }
            else
            {
                if (usbHidPort1.SpecifiedDevice != null)
                {
                    readbuff = args.data;
                    if (readbuff[1] == 'A')
                    {
                        button1.BackColor = Color.Yellow;
                        pictureBox1.Image = Software_USB.Properties.Resources.leddbat;
                    }
                    else if (readbuff[1] == 'B')
                    {
                        button1.BackColor = Color.PeachPuff;
                        pictureBox1.Image = Software_USB.Properties.Resources.ledonn;
                    }
                    if (readbuff[2] == 'A')
                    {
                        button2.BackColor = Color.Yellow;
                        pictureBox2.Image = Software_USB.Properties.Resources.leddbat;
                    }
                    else if (readbuff[2] == 'B')
                    {
                        button2.BackColor = Color.PeachPuff;
                        pictureBox2.Image = Software_USB.Properties.Resources.ledonn;
                    }
                    if (readbuff[3] == 'A')
                    {
                        button3.BackColor = Color.Yellow;
                        pictureBox3.Image = Software_USB.Properties.Resources.leddbat;
                    }
                    else if (readbuff[3] == 'B')
                    {
                        button3.BackColor = Color.PeachPuff;
                        pictureBox3.Image = Software_USB.Properties.Resources.ledonn;
                    }
                    if(readbuff[1]=='S')
                    {
                        count1++;
                        textBox4.Text = count1.ToString();
                    }
                    else if (readbuff[1] == 'Z')
                    {
                        count2++;
                        textBox2.Text = count2.ToString();
                    }
                    else if (readbuff[1] == 'X')
                    {
                        count3++;
                        textBox3.Text = count3.ToString();
                    }
                }
            }
        }

                private void usbHidPort1_OnDataSend(object sender, EventArgs e)
        {

        }

        private void usbHidPort1_OnDeviceArrived(object sender, EventArgs e)
        {

        }

        private void usbHidPort1_OnDeviceRemoved(object sender, EventArgs e)
        {

        }

        private void usbHidPort1_OnSpecifiedDeviceArrived(object sender, EventArgs e)
        {
            // để kêt nôi voi usb
            textBox1.Text = " Connected ";
            textBox1.BackColor = Color.Lime;
            pictureBox1.Image = Software_USB.Properties.Resources.ledonn;
            pictureBox2.Image = Software_USB.Properties.Resources.ledonn;
            pictureBox3.Image = Software_USB.Properties.Resources.ledonn;
        }

        private void usbHidPort1_OnSpecifiedDeviceRemoved(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(usbHidPort1_OnDeviceRemoved), new object[] { sender, e });
            }
            else
            {
                textBox1.Text = " Disconnected ";
                textBox1.BackColor = Color.Red;
                pictureBox1.Image = Software_USB.Properties.Resources.ledonn;
                pictureBox2.Image = Software_USB.Properties.Resources.ledonn;
                pictureBox3.Image = Software_USB.Properties.Resources.ledonn;
                button1.BackColor = Color.PeachPuff;
                button2.BackColor = Color.PeachPuff;
                button3.BackColor = Color.PeachPuff;
                
                   

            }
        }
        // Kich hoat sự kiẹn USB
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            usbHidPort1.RegisterHandle(Handle);
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            usbHidPort1.ParseMessages(ref m);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.BackColor == Color.PeachPuff)
            {
                if (usbHidPort1.SpecifiedDevice != null)
                {
                    writebuff[1] = (byte)'@';
                    usbHidPort1.SpecifiedDevice.SendData(writebuff);
                }
                else
                {
                    MessageBox.Show("Device not found. please reconnect USB device to use.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (usbHidPort1.SpecifiedDevice != null)
                {
                    writebuff[1] = (byte)'!';
                    usbHidPort1.SpecifiedDevice.SendData(writebuff);
                }
                else
                {
                    MessageBox.Show("Device not found. please reconnect USB device to use.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }    

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.BackColor == Color.PeachPuff)
            {
                if (usbHidPort1.SpecifiedDevice != null)
                {
                    writebuff[2] = (byte)'@';
                    usbHidPort1.SpecifiedDevice.SendData(writebuff);
                }
                else
                {
                    MessageBox.Show("Device not found. please reconnect USB device to use.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (usbHidPort1.SpecifiedDevice != null)
                {
                    writebuff[2] = (byte)'!';
                    usbHidPort1.SpecifiedDevice.SendData(writebuff);
                }
                else
                {
                    MessageBox.Show("Device not found. please reconnect USB device to use.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.BackColor == Color.PeachPuff)
            {
                if (usbHidPort1.SpecifiedDevice != null)
                {
                    writebuff[3] = (byte)'@';
                    usbHidPort1.SpecifiedDevice.SendData(writebuff);
                }
                else
                {
                    MessageBox.Show("Device not found. please reconnect USB device to use.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (usbHidPort1.SpecifiedDevice != null)
                {
                    writebuff[3] = (byte)'!';
                    usbHidPort1.SpecifiedDevice.SendData(writebuff);
                }
                else
                {
                    MessageBox.Show("Device not found. please reconnect USB device to use.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }
    }
}
