namespace magister
{
    partial class Form2
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
            this.proc = new System.Windows.Forms.StatusStrip();
            this.Time = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.proc.SuspendLayout();
            this.SuspendLayout();
            // 
            // proc
            // 
            this.proc.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.proc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Time,
            this.toolStripStatusLabel2});
            this.proc.Location = new System.Drawing.Point(20, 264);
            this.proc.Name = "proc";
            this.proc.Size = new System.Drawing.Size(763, 22);
            this.proc.TabIndex = 0;
            this.proc.Text = "proc";
            this.proc.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
            // 
            // Time
            // 
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(34, 17);
            this.Time.Text = "Time";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 306);
            this.Controls.Add(this.proc);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.proc.ResumeLayout(false);
            this.proc.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip proc;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripStatusLabel Time;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
    }
}