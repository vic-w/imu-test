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
using System.Windows.Forms.DataVisualization.Charting;
using AHRS;
using Tao.OpenGl;
using Tao.Platform.Windows;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        MadgwickAHRS imu;
        float r;

        int x;
        float Ax = 0;
        float Ay = 0;
        float Az = 0;
        float Gx = 0;
        float Gy = 0;
        float Gz = 0;
        double Tx = 0;
        double Ty = 0;
        double Tz = 0;
        float[] Q = new float[4];

        Series Ax_series;
        Series Ay_series;
        Series Az_series;

        public Form1()
        {
            InitializeComponent();

            glControl.InitializeContexts();

            const float SampleTime = 0.02F;
            imu = new MadgwickAHRS(SampleTime);
            Q[0] = 0;
            Q[1] = 0;
            Q[2] = 0;
            Q[3] = 1;
            r = 0;
            x = 0;
            data_receiver.RunWorkerAsync();

            Ax_series = new Series("Ax");
            Ax_series.ChartType = SeriesChartType.Line;
            Ay_series = new Series("Ay");
            Ay_series.ChartType = SeriesChartType.Line;
            Az_series = new Series("Az");
            Az_series.ChartType = SeriesChartType.Line;

            chartAcc.Series.Clear();
            chartAcc.Series.Add(Ax_series);
            chartAcc.Series.Add(Ay_series);
            chartAcc.Series.Add(Az_series);

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
                    Gx = System.BitConverter.ToSingle(bytes, 16);
                    Gy = System.BitConverter.ToSingle(bytes, 20);
                    Gz = System.BitConverter.ToSingle(bytes, 24);
                    Tx = System.BitConverter.ToDouble(bytes, 28);
                    Ty = System.BitConverter.ToDouble(bytes, 36);
                    Tz = System.BitConverter.ToDouble(bytes, 44);
                    imu.Update(Gx, Gy, Gz, Ax, Ay, Az);
                    Q = imu.Quaternion;
                    data_receiver.ReportProgress(0);
                    x++;
                }
            }
        }

        private void udp_server_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!this.IsDisposed)
            {
                tb_Ax.Text = Ax.ToString();
                tb_Ay.Text = Ay.ToString();
                tb_Az.Text = Az.ToString();

                tbQ0.Text = Q[0].ToString();
                tbQ1.Text = Q[1].ToString();
                tbQ2.Text = Q[2].ToString();
                tbQ3.Text = Q[3].ToString();

                chartAcc.Series[0].Points.Add(Ax);
                chartAcc.Series[1].Points.Add(Ay);
                chartAcc.Series[2].Points.Add(Az);

                if (chartAcc.Series[0].Points.Count > 500)
                {
                    chartAcc.Series[0].Points.RemoveAt(0);
                    chartAcc.Series[1].Points.RemoveAt(0);
                    chartAcc.Series[2].Points.RemoveAt(0);
                }
                glControl.Invalidate();
            }
        }

        private void glControl_Paint(object sender, PaintEventArgs e)
        {
            r += 0.01F;
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glLoadIdentity();
            Gl.glRotated(-Q[0]*180/3.14F, Q[1], Q[2], Q[3]);
            //Gl.glRotated(90, 0, 0, 1);
            Gl.glBegin(Gl.GL_TRIANGLES);
            Gl.glColor3f(1.0f, 0.0f, 0.0f);
            Gl.glVertex2d(0.0, 0.0);
            Gl.glColor3f(0.0f, 1.0f, 0.0f);
            Gl.glVertex2d(1.0, 0.0);
            Gl.glColor3f(0.0f, 0.0f, 1.0f);
            Gl.glVertex2d(0.5, 0.867);
            Gl.glEnd();
        }
    }
}
