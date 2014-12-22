using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Tao.OpenGl;
using Tao.Platform.Windows;

namespace imu_test
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
            glControl.InitializeContexts();
        }

        private void glControl_Paint(object sender, PaintEventArgs e)
        {
           Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
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
