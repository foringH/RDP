using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSTSCLib;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            try
            {
                var client = (IMsRdpClient7)rdp.GetOcx();
                client.RemoteProgram2.RemoteProgramMode = true;
                ((MSTSCLib.IMsRdpClientAdvancedSettings5)rdp.AdvancedSettings).DisplayConnectionBar = true;
                ((MSTSCLib.IMsRdpClientAdvancedSettings5)rdp.AdvancedSettings).ConnectionBarShowPinButton = true;
                ((MSTSCLib.IMsRdpClientAdvancedSettings5)rdp.AdvancedSettings).BitmapVirtualCache32BppSize = 48;
                ((MSTSCLib.IMsRdpClientAdvancedSettings5)rdp.AdvancedSettings).ConnectionBarShowRestoreButton = false;
                ((MSTSCLib.IMsRdpClientAdvancedSettings5)rdp.AdvancedSettings).ConnectionBarShowMinimizeButton = true;

                ((MSTSCLib.IMsRdpClientAdvancedSettings5)rdp.AdvancedSettings).EnableWindowsKey = 1;
                ((MSTSCLib.IMsRdpClientAdvancedSettings5)rdp.AdvancedSettings).GrabFocusOnConnect = true;
                ((MSTSCLib.IMsRdpClientAdvancedSettings5)rdp.AdvancedSettings).RedirectDrives = true;
                ((MSTSCLib.IMsRdpClientAdvancedSettings5)rdp.AdvancedSettings).RedirectClipboard = true;
                ((MSTSCLib.IMsRdpClientAdvancedSettings5)rdp.AdvancedSettings).RedirectPrinters = true;
                ((MSTSCLib.IMsRdpClientAdvancedSettings5)rdp.AdvancedSettings).RedirectPOSDevices = true;

                rdp.Server = textBox1.Text;
                rdp.UserName = textBox2.Text;
                IMsTscNonScriptable secured = (IMsTscNonScriptable)rdp.GetOcx();
                secured.ClearTextPassword = textBox3.Text;
                rdp.FullScreenTitle = "Full Screen";
                rdp.SecuredSettings.FullScreen = 1;
                rdp.SecuredSettings.StartProgram = @"c:\windows\System32\calc.exe";
                rdp.Connect();


                /*
                rdp.Server = textBox1.Text;
                rdp.UserName = textBox2.Text;

                IMsTscNonScriptable secured = (IMsTscNonScriptable)rdp.GetOcx();
                secured.ClearTextPassword = textBox3.Text;

                //Controls.Add(rdp);
               // rdp.BringToFront();
               // this.BringToFront();
               // rdp.Parent = TerminalTabPage;
               // this.Parent = TerminalTabPage;
                //rdp.AllowDrop = true;
                rdp.FullScreenTitle = "hello";
               



                //rdp.SecuredSettings.StartProgram = "C:\\Program Files (x86)\\Notepad++ notepad++.exe";
                //rdp.AdvancedSettings.PluginDlls = "tswindowclipper.dll";


                //rdp.Dock = DockStyle.Fill;
                //rdp.Visible = false;

                

                rdp.Connect();
               */
    Console.WriteLine("connected & status" + rdp.Connected + " PRINTING the object"+ secured.ToString());

                
                //rdp.ShowPropertyPages();
                //rdp.Visible = false;

                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Error Connecting", "Error connecting to remote desktop " + textBox1.Text + " Error: " + Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Check if connected before disconnecting
            if (rdp.Connected.ToString() == "1")
            { 
                Console.WriteLine("disconnected");
                rdp.Disconnect();
                
            }
            //rdp.Disconnect();
        }
    }
}
