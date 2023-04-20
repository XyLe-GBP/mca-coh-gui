namespace mca_coh_gui
{
    partial class FormProgress
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
            this.components = new System.ComponentModel.Container();
            this.label_Progress = new System.Windows.Forms.Label();
            this.progressBar_MainProgress = new System.Windows.Forms.ProgressBar();
            this.label_log1 = new System.Windows.Forms.Label();
            this.label_log2 = new System.Windows.Forms.Label();
            this.timer_interval = new System.Windows.Forms.Timer(this.components);
            this.label_log3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_Progress
            // 
            this.label_Progress.Location = new System.Drawing.Point(12, 9);
            this.label_Progress.Name = "label_Progress";
            this.label_Progress.Size = new System.Drawing.Size(560, 39);
            this.label_Progress.TabIndex = 0;
            this.label_Progress.Text = "ProgressLabel";
            this.label_Progress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar_MainProgress
            // 
            this.progressBar_MainProgress.Location = new System.Drawing.Point(12, 51);
            this.progressBar_MainProgress.Name = "progressBar_MainProgress";
            this.progressBar_MainProgress.Size = new System.Drawing.Size(560, 13);
            this.progressBar_MainProgress.TabIndex = 1;
            // 
            // label_log1
            // 
            this.label_log1.AutoSize = true;
            this.label_log1.Location = new System.Drawing.Point(12, 67);
            this.label_log1.Name = "label_log1";
            this.label_log1.Size = new System.Drawing.Size(61, 15);
            this.label_log1.TabIndex = 2;
            this.label_log1.Text = "LogLabel1";
            // 
            // label_log2
            // 
            this.label_log2.AutoSize = true;
            this.label_log2.Location = new System.Drawing.Point(12, 97);
            this.label_log2.Name = "label_log2";
            this.label_log2.Size = new System.Drawing.Size(61, 15);
            this.label_log2.TabIndex = 3;
            this.label_log2.Text = "LogLabel2";
            // 
            // timer_interval
            // 
            this.timer_interval.Tick += new System.EventHandler(this.Timer_interval_Tick);
            // 
            // label_log3
            // 
            this.label_log3.AutoSize = true;
            this.label_log3.Location = new System.Drawing.Point(12, 112);
            this.label_log3.Name = "label_log3";
            this.label_log3.Size = new System.Drawing.Size(61, 15);
            this.label_log3.TabIndex = 4;
            this.label_log3.Text = "LogLabel3";
            // 
            // FormProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 136);
            this.ControlBox = false;
            this.Controls.Add(this.label_log3);
            this.Controls.Add(this.label_log2);
            this.Controls.Add(this.label_log1);
            this.Controls.Add(this.progressBar_MainProgress);
            this.Controls.Add(this.label_Progress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormProgress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormProgress";
            this.Load += new System.EventHandler(this.FormProgress_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label_Progress;
        private ProgressBar progressBar_MainProgress;
        private Label label_log1;
        private Label label_log2;
        private System.Windows.Forms.Timer timer_interval;
        private Label label_log3;
    }
}