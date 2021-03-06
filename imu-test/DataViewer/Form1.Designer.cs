﻿namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_Ax = new System.Windows.Forms.TextBox();
            this.tb_Ay = new System.Windows.Forms.TextBox();
            this.tb_Az = new System.Windows.Forms.TextBox();
            this.data_receiver = new System.ComponentModel.BackgroundWorker();
            this.chartAcc = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tbQ0 = new System.Windows.Forms.TextBox();
            this.tbQ1 = new System.Windows.Forms.TextBox();
            this.tbQ3 = new System.Windows.Forms.TextBox();
            this.tbQ2 = new System.Windows.Forms.TextBox();
            this.glControl = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.tbSampleTime = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartAcc)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Accelerometer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "x";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(189, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "y";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(358, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "z";
            // 
            // tb_Ax
            // 
            this.tb_Ax.Location = new System.Drawing.Point(43, 30);
            this.tb_Ax.Name = "tb_Ax";
            this.tb_Ax.Size = new System.Drawing.Size(100, 21);
            this.tb_Ax.TabIndex = 4;
            // 
            // tb_Ay
            // 
            this.tb_Ay.Location = new System.Drawing.Point(215, 30);
            this.tb_Ay.Name = "tb_Ay";
            this.tb_Ay.Size = new System.Drawing.Size(100, 21);
            this.tb_Ay.TabIndex = 4;
            // 
            // tb_Az
            // 
            this.tb_Az.Location = new System.Drawing.Point(384, 30);
            this.tb_Az.Name = "tb_Az";
            this.tb_Az.Size = new System.Drawing.Size(100, 21);
            this.tb_Az.TabIndex = 4;
            // 
            // data_receiver
            // 
            this.data_receiver.WorkerReportsProgress = true;
            this.data_receiver.DoWork += new System.ComponentModel.DoWorkEventHandler(this.udp_server_DoWork);
            this.data_receiver.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.udp_server_ProgressChanged);
            // 
            // chartAcc
            // 
            chartArea1.AxisX.Maximum = 500D;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisY.Interval = 1D;
            chartArea1.AxisY.Maximum = 2D;
            chartArea1.AxisY.Minimum = -2D;
            chartArea1.Name = "ChartArea1";
            this.chartAcc.ChartAreas.Add(chartArea1);
            this.chartAcc.Location = new System.Drawing.Point(43, 72);
            this.chartAcc.Name = "chartAcc";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "Ax";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Name = "Ay";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Name = "Az";
            this.chartAcc.Series.Add(series1);
            this.chartAcc.Series.Add(series2);
            this.chartAcc.Series.Add(series3);
            this.chartAcc.Size = new System.Drawing.Size(501, 96);
            this.chartAcc.TabIndex = 5;
            this.chartAcc.Text = "chartAcc";
            // 
            // tbQ0
            // 
            this.tbQ0.Location = new System.Drawing.Point(43, 203);
            this.tbQ0.Name = "tbQ0";
            this.tbQ0.Size = new System.Drawing.Size(100, 21);
            this.tbQ0.TabIndex = 6;
            // 
            // tbQ1
            // 
            this.tbQ1.Location = new System.Drawing.Point(163, 203);
            this.tbQ1.Name = "tbQ1";
            this.tbQ1.Size = new System.Drawing.Size(100, 21);
            this.tbQ1.TabIndex = 6;
            // 
            // tbQ3
            // 
            this.tbQ3.Location = new System.Drawing.Point(405, 203);
            this.tbQ3.Name = "tbQ3";
            this.tbQ3.Size = new System.Drawing.Size(100, 21);
            this.tbQ3.TabIndex = 6;
            // 
            // tbQ2
            // 
            this.tbQ2.Location = new System.Drawing.Point(285, 203);
            this.tbQ2.Name = "tbQ2";
            this.tbQ2.Size = new System.Drawing.Size(100, 21);
            this.tbQ2.TabIndex = 6;
            // 
            // glControl
            // 
            this.glControl.AccumBits = ((byte)(0));
            this.glControl.AutoCheckErrors = false;
            this.glControl.AutoFinish = false;
            this.glControl.AutoMakeCurrent = true;
            this.glControl.AutoSwapBuffers = true;
            this.glControl.BackColor = System.Drawing.Color.Black;
            this.glControl.ColorBits = ((byte)(32));
            this.glControl.DepthBits = ((byte)(16));
            this.glControl.Location = new System.Drawing.Point(46, 244);
            this.glControl.Name = "glControl";
            this.glControl.Size = new System.Drawing.Size(269, 264);
            this.glControl.StencilBits = ((byte)(0));
            this.glControl.TabIndex = 7;
            this.glControl.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl_Paint);
            // 
            // tbSampleTime
            // 
            this.tbSampleTime.Location = new System.Drawing.Point(456, 487);
            this.tbSampleTime.Name = "tbSampleTime";
            this.tbSampleTime.Size = new System.Drawing.Size(100, 21);
            this.tbSampleTime.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(454, 472);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "Sample Period";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 520);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbSampleTime);
            this.Controls.Add(this.glControl);
            this.Controls.Add(this.tbQ2);
            this.Controls.Add(this.tbQ3);
            this.Controls.Add(this.tbQ1);
            this.Controls.Add(this.tbQ0);
            this.Controls.Add(this.chartAcc);
            this.Controls.Add(this.tb_Az);
            this.Controls.Add(this.tb_Ay);
            this.Controls.Add(this.tb_Ax);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Sensor Data Viewer";
            ((System.ComponentModel.ISupportInitialize)(this.chartAcc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_Ax;
        private System.Windows.Forms.TextBox tb_Ay;
        private System.Windows.Forms.TextBox tb_Az;
        private System.ComponentModel.BackgroundWorker data_receiver;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAcc;
        private System.Windows.Forms.TextBox tbQ0;
        private System.Windows.Forms.TextBox tbQ1;
        private System.Windows.Forms.TextBox tbQ3;
        private System.Windows.Forms.TextBox tbQ2;
        private Tao.Platform.Windows.SimpleOpenGlControl glControl;
        private System.Windows.Forms.TextBox tbSampleTime;
        private System.Windows.Forms.Label label5;
    }
}

