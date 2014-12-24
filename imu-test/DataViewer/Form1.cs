using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        int x;
        float Ax = 0;
        float Ay = 0;
        float Az = 0;

        public Form1()
        {
            InitializeComponent();
            x = 0;
            data_receiver.RunWorkerAsync();

        }

        private void udp_server_DoWork(object sender, DoWorkEventArgs e)
        {
            const int listenPort = 22222;
            UdpClient listener = new UdpClient(listenPort);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, listenPort);

            while (true)
            {
                while (true)
                {
                    byte[] bytes = listener.Receive(ref groupEP);
                    string s = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
                    Ax = System.BitConverter.ToSingle(bytes, 4);
                    Ay = System.BitConverter.ToSingle(bytes, 8);
                    Az = System.BitConverter.ToSingle(bytes, 12);
                    data_receiver.ReportProgress(0);
                    x++;
                }
            }
        }

        private void udp_server_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            tb_Ax.Text = Ax.ToString();
            tb_Ay.Text = Ay.ToString();
            tb_Az.Text = Az.ToString();
        }
    }
}
