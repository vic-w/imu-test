using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using Tao.OpenGl;
using Tao.Platform.Windows;

namespace imu_test
{
    public partial class mainForm : Form
    {
        Thread udp;

        public mainForm()
        {
            InitializeComponent();
            glControl.InitializeContexts();

            textBox1.Text = "111";

            udp = new Thread(udp_server);
            udp.IsBackground = true;
            udp.Start();
        }

        ~mainForm()
        {
            //udp.Abort();
        }

        private void glControl_Paint(object sender, PaintEventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glLoadIdentity();
            Gl.glRotated(20, 0, 0, 1);
            Gl.glBegin(Gl.GL_TRIANGLES);
            Gl.glColor3f(1.0f, 0.0f, 0.0f);
            Gl.glVertex2d(0.0, 0.0);
            Gl.glColor3f(0.0f, 1.0f, 0.0f);
            Gl.glVertex2d(1.0, 0.0);
            Gl.glColor3f(0.0f, 0.0f, 1.0f);
            Gl.glVertex2d(0.5, 0.867);
            Gl.glEnd();
        }

        void udp_server()
        {
            while (true)
            {
                if (textBox1.Text == "111")
                {
                    textBox1.Text = "222";
                }
                else
                {
                    textBox1.Text = "111";
                }
                Thread.Sleep(1000);
            }
        }

        private void Form1_Load(object sender, EventArgs e) 
        { 
            t1 = new Thread(new ThreadStart(BackgroundProcess)); 
            t1.Start(); //开始 
        } 
        delegate void aa() 
            private void BackgroundProcess() 
            { // 将委托实例化 
                aa a= delegate() 
                { 
                    for (int i = 0; i < 50; i++) 
                    { 
                        listBox1.Items.Add("Iterations: " + i.ToString()); 
                        Thread.Sleep(300); 
                        listBox1.Refresh(); 
                    } 
                }; 
                listBox1.Invoke(a); 
            }
    }
}
