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
        float Tx = 0;
        float Ty = 0;
        float Tz = 0;
        float[] Q;
        float[] M;

        Series Ax_series;
        Series Ay_series;
        Series Az_series;

        public Form1()
        {
            InitializeComponent();

            glControl.InitializeContexts();

            const float SampleTime = 0.02F;
            imu = new MadgwickAHRS(SampleTime);
            Q = new float[4];
            Q[0] = 0;
            Q[1] = 0;
            Q[2] = 0;
            Q[3] = 1;
            M = new float[16];
            M[0] = 1;
            M[1] = 0;
            M[2] = 0;
            M[3] = 0;
            M[4] = 0;
            M[5] = 1;
            M[6] = 0;
            M[7] = 0;
            M[8] = 0;
            M[9] = 0;
            M[10] = 1;
            M[11] = 0;
            M[12] = 0;
            M[13] = 0;
            M[14] = 0;
            M[15] = 1;

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
                    Tx = System.BitConverter.ToSingle(bytes, 28);
                    Ty = System.BitConverter.ToSingle(bytes, 36);
                    Tz = System.BitConverter.ToSingle(bytes, 44);
                    imu.Update(Gx, Gy, Gz, Ax, Ay, Az, Tx, Ty, Tz);
                    Q = imu.Quaternion;
                    M = imu.rotMat();
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
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Gl.glMultMatrixf(M);

            float[][] vertex_list = 
            {
                new float[] {-0.5f, -0.5f, -0.5f},
                new float[]  {0.5f, -0.5f, -0.5f},
                new float[] {-0.5f,  0.5f, -0.5f},
                new float[]  {0.5f,  0.5f, -0.5f},
                new float[] {-0.5f, -0.5f,  0.5f},
                new float[]  {0.5f, -0.5f,  0.5f},
                new float[] {-0.5f,  0.5f,  0.5f},
                new float[]  {0.5f,  0.5f,  0.5f}
            };

            int[][] index_list = 
            {
                new int[] {0, 2, 3, 1},
                new int[] {0, 4, 6, 2},
                new int[] {0, 1, 5, 4},
                new int[] {4, 5, 7, 6},
                new int[] {1, 3, 7, 5},
                new int[] {2, 6, 7, 3}
            };

            float[][] color_list = 
            {
                new float[] {1.0f, 0.0f, 0.0f},
                new float[] {0.0f, 1.0f, 0.0f},
                new float[] {0.0f, 0.0f, 1.0f},
                new float[] {1.0f, 1.0f, 0.0f},
                new float[] {0.0f, 1.0f, 1.0f},
                new float[] {1.0f, 0.0f, 1.0f}
            };

            Gl.glBegin(Gl.GL_QUADS);
            for (int i = 0; i < 6; ++i)// 有六个面，循环六次
            {
                for (int j = 0; j < 4; ++j)     // 每个面有四个顶点，循环四次
                {
                    Gl.glColor3fv(color_list[i]);
                    Gl.glVertex3fv(vertex_list[index_list[i][j]]);
                }
            }
            Gl.glEnd();

        }
    }
}
