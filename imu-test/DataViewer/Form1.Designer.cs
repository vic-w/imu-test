namespace WindowsFormsApplication1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_Ax = new System.Windows.Forms.TextBox();
            this.tb_Ay = new System.Windows.Forms.TextBox();
            this.tb_Az = new System.Windows.Forms.TextBox();
            this.data_receiver = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Accelerometer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "x";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(189, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "y";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(358, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "z";
            // 
            // tb_Ax
            // 
            this.tb_Ax.Location = new System.Drawing.Point(43, 33);
            this.tb_Ax.Name = "tb_Ax";
            this.tb_Ax.Size = new System.Drawing.Size(100, 20);
            this.tb_Ax.TabIndex = 4;
            // 
            // tb_Ay
            // 
            this.tb_Ay.Location = new System.Drawing.Point(215, 33);
            this.tb_Ay.Name = "tb_Ay";
            this.tb_Ay.Size = new System.Drawing.Size(100, 20);
            this.tb_Ay.TabIndex = 4;
            // 
            // tb_Az
            // 
            this.tb_Az.Location = new System.Drawing.Point(384, 33);
            this.tb_Az.Name = "tb_Az";
            this.tb_Az.Size = new System.Drawing.Size(100, 20);
            this.tb_Az.TabIndex = 4;
            // 
            // udp_server
            // 
            this.data_receiver.WorkerReportsProgress = true;
            this.data_receiver.DoWork += new System.ComponentModel.DoWorkEventHandler(this.udp_server_DoWork);
            this.data_receiver.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.udp_server_ProgressChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 205);
            this.Controls.Add(this.tb_Az);
            this.Controls.Add(this.tb_Ay);
            this.Controls.Add(this.tb_Ax);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Sensor Data Viewer";
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
    }
}

