
namespace MatrixTable
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
            this.button1 = new System.Windows.Forms.Button();
            this.ucMatrixTable1 = new MatrixTable.UCMatrixTable();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(52, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ucMatrixTable1
            // 
            this.ucMatrixTable1.ColumnNames = new string[] {
        "1a",
        "2b",
        "3c",
        "4d",
        "5e",
        "6f",
        "7g",
        "8h",
        "9i",
        "10j"};
            this.ucMatrixTable1.Location = new System.Drawing.Point(134, 71);
            this.ucMatrixTable1.Margin = new System.Windows.Forms.Padding(0);
            this.ucMatrixTable1.Name = "ucMatrixTable1";
            this.ucMatrixTable1.NoCols = 10;
            this.ucMatrixTable1.NoRows = 10;
            this.ucMatrixTable1.RowNames = new string[] {
        "1",
        "2",
        "3",
        "4",
        "5",
        "6",
        "7",
        "8",
        "9",
        "10"};
            this.ucMatrixTable1.Size = new System.Drawing.Size(1026, 566);
            this.ucMatrixTable1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 646);
            this.Controls.Add(this.ucMatrixTable1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private UCMatrixTable ucMatrixTable1;
    }
}

