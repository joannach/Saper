namespace Saper
{
    partial class HighscoreForm
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
            this.m_listView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.m_button_ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_listView
            // 
            this.m_listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.m_listView.Location = new System.Drawing.Point(37, 12);
            this.m_listView.Name = "m_listView";
            this.m_listView.Size = new System.Drawing.Size(255, 377);
            this.m_listView.TabIndex = 0;
            this.m_listView.UseCompatibleStateImageBehavior = false;
            this.m_listView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Czas";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Gracz";
            // 
            // m_button_ok
            // 
            this.m_button_ok.Location = new System.Drawing.Point(117, 409);
            this.m_button_ok.Name = "m_button_ok";
            this.m_button_ok.Size = new System.Drawing.Size(75, 23);
            this.m_button_ok.TabIndex = 1;
            this.m_button_ok.Text = "OK";
            this.m_button_ok.UseVisualStyleBackColor = true;
            this.m_button_ok.Click += new System.EventHandler(this.m_button_ok_Click);
            // 
            // HighscoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 460);
            this.Controls.Add(this.m_button_ok);
            this.Controls.Add(this.m_listView);
            this.Name = "HighscoreForm";
            this.Text = "HighscoreForm";
            this.Load += new System.EventHandler(this.HighscoreForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView m_listView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button m_button_ok;
    }
}