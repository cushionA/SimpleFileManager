namespace FileClassifier
{
    partial class CancelForm
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
            if ( disposing && (components != null) )
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
            this.radioButtonSingleCancel = new System.Windows.Forms.RadioButton();
            this.radioButtonAllCancel = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // radioButtonSingleCancel
            // 
            this.radioButtonSingleCancel.AutoSize = true;
            this.radioButtonSingleCancel.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.radioButtonSingleCancel.Location = new System.Drawing.Point(3, 12);
            this.radioButtonSingleCancel.Name = "radioButtonSingleCancel";
            this.radioButtonSingleCancel.Size = new System.Drawing.Size(253, 19);
            this.radioButtonSingleCancel.TabIndex = 0;
            this.radioButtonSingleCancel.TabStop = true;
            this.radioButtonSingleCancel.Text = "現在のファイルの分類をキャンセルする。";
            this.radioButtonSingleCancel.UseVisualStyleBackColor = true;
            this.radioButtonSingleCancel.CheckedChanged += new System.EventHandler(this.radioButtonSingleCancel_CheckedChanged);
            // 
            // radioButtonAllCancel
            // 
            this.radioButtonAllCancel.AutoSize = true;
            this.radioButtonAllCancel.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.radioButtonAllCancel.Location = new System.Drawing.Point(3, 37);
            this.radioButtonAllCancel.Name = "radioButtonAllCancel";
            this.radioButtonAllCancel.Size = new System.Drawing.Size(250, 19);
            this.radioButtonAllCancel.TabIndex = 1;
            this.radioButtonAllCancel.TabStop = true;
            this.radioButtonAllCancel.Text = "全てのファイルの分類をキャンセルする。";
            this.radioButtonAllCancel.UseVisualStyleBackColor = true;
            this.radioButtonAllCancel.CheckedChanged += new System.EventHandler(this.radioButtonAllCancel_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Location = new System.Drawing.Point(189, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(55, 30);
            this.button1.TabIndex = 2;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CancelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 111);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.radioButtonAllCancel);
            this.Controls.Add(this.radioButtonSingleCancel);
            this.Name = "CancelForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButtonSingleCancel;
        private System.Windows.Forms.RadioButton radioButtonAllCancel;
        private System.Windows.Forms.Button button1;
    }
}