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
            components = new System.ComponentModel.Container();
            label_Progress = new Label();
            progressBar_MainProgress = new ProgressBar();
            label_log1 = new Label();
            label_log2 = new Label();
            timer_interval = new System.Windows.Forms.Timer(components);
            label_log3 = new Label();
            button_Abort = new Button();
            SuspendLayout();
            // 
            // label_Progress
            // 
            label_Progress.Location = new Point(12, 9);
            label_Progress.Name = "label_Progress";
            label_Progress.Size = new Size(560, 39);
            label_Progress.TabIndex = 0;
            label_Progress.Text = "ProgressLabel";
            label_Progress.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // progressBar_MainProgress
            // 
            progressBar_MainProgress.Location = new Point(12, 51);
            progressBar_MainProgress.Name = "progressBar_MainProgress";
            progressBar_MainProgress.Size = new Size(560, 13);
            progressBar_MainProgress.TabIndex = 1;
            // 
            // label_log1
            // 
            label_log1.AutoSize = true;
            label_log1.Location = new Point(12, 67);
            label_log1.Name = "label_log1";
            label_log1.Size = new Size(61, 15);
            label_log1.TabIndex = 2;
            label_log1.Text = "LogLabel1";
            // 
            // label_log2
            // 
            label_log2.AutoSize = true;
            label_log2.Location = new Point(12, 97);
            label_log2.Name = "label_log2";
            label_log2.Size = new Size(61, 15);
            label_log2.TabIndex = 3;
            label_log2.Text = "LogLabel2";
            // 
            // timer_interval
            // 
            timer_interval.Tick += Timer_interval_Tick;
            // 
            // label_log3
            // 
            label_log3.AutoSize = true;
            label_log3.Location = new Point(12, 112);
            label_log3.Name = "label_log3";
            label_log3.Size = new Size(61, 15);
            label_log3.TabIndex = 4;
            label_log3.Text = "LogLabel3";
            // 
            // button_Abort
            // 
            button_Abort.Location = new Point(497, 112);
            button_Abort.Name = "button_Abort";
            button_Abort.Size = new Size(75, 23);
            button_Abort.TabIndex = 5;
            button_Abort.Text = "Abort";
            button_Abort.UseVisualStyleBackColor = true;
            button_Abort.Click += button_Abort_Click;
            // 
            // FormProgress
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 146);
            ControlBox = false;
            Controls.Add(button_Abort);
            Controls.Add(label_log3);
            Controls.Add(label_log2);
            Controls.Add(label_log1);
            Controls.Add(progressBar_MainProgress);
            Controls.Add(label_Progress);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FormProgress";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormProgress";
            Load += FormProgress_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_Progress;
        private ProgressBar progressBar_MainProgress;
        private Label label_log1;
        private Label label_log2;
        private System.Windows.Forms.Timer timer_interval;
        private Label label_log3;
        private Button button_Abort;
    }
}