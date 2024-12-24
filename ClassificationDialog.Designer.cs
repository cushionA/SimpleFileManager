using System.Windows.Forms;

namespace FileClassifier
{
    partial class ClassificationDialog : Form
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
            this.ComboBoxClassify = new System.Windows.Forms.ComboBox();
            this.SelectButton = new System.Windows.Forms.Button();
            this.textBoxClassify = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labeloriginalFileHeader = new System.Windows.Forms.Label();
            this.labelOriginalFileName = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ComboBoxClassify
            // 
            this.ComboBoxClassify.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ComboBoxClassify.DropDownHeight = 110;
            this.ComboBoxClassify.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxClassify.Font = new System.Drawing.Font("MS UI Gothic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ComboBoxClassify.IntegralHeight = false;
            this.ComboBoxClassify.ItemHeight = 40;
            this.ComboBoxClassify.Location = new System.Drawing.Point(10, 95);
            this.ComboBoxClassify.Name = "ComboBoxClassify";
            this.ComboBoxClassify.Size = new System.Drawing.Size(317, 46);
            this.ComboBoxClassify.TabIndex = 0;
            // 
            // SelectButton
            // 
            this.SelectButton.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SelectButton.ForeColor = System.Drawing.Color.Black;
            this.SelectButton.Location = new System.Drawing.Point(255, 165);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(74, 34);
            this.SelectButton.TabIndex = 1;
            this.SelectButton.Text = "OK";
            this.SelectButton.UseVisualStyleBackColor = true;
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // textBoxClassify
            // 
            this.textBoxClassify.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxClassify.Location = new System.Drawing.Point(10, 105);
            this.textBoxClassify.MaxLength = 25;
            this.textBoxClassify.Name = "textBoxClassify";
            this.textBoxClassify.Size = new System.Drawing.Size(317, 23);
            this.textBoxClassify.TabIndex = 2;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelDescription.ForeColor = System.Drawing.Color.Black;
            this.labelDescription.Location = new System.Drawing.Point(12, 62);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(304, 21);
            this.labelDescription.TabIndex = 3;
            this.labelDescription.Text = "置き換える文字を入力してください。";
            // 
            // labeloriginalFileHeader
            // 
            this.labeloriginalFileHeader.AutoSize = true;
            this.labeloriginalFileHeader.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labeloriginalFileHeader.ForeColor = System.Drawing.SystemColors.MenuText;
            this.labeloriginalFileHeader.Location = new System.Drawing.Point(5, 10);
            this.labeloriginalFileHeader.Name = "labeloriginalFileHeader";
            this.labeloriginalFileHeader.Size = new System.Drawing.Size(126, 15);
            this.labeloriginalFileHeader.TabIndex = 4;
            this.labeloriginalFileHeader.Text = "分類対象ファイル：";
            // 
            // labelOriginalFileName
            // 
            this.labelOriginalFileName.AutoSize = true;
            this.labelOriginalFileName.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelOriginalFileName.ForeColor = System.Drawing.Color.Black;
            this.labelOriginalFileName.Location = new System.Drawing.Point(30, 30);
            this.labelOriginalFileName.Name = "labelOriginalFileName";
            this.labelOriginalFileName.Size = new System.Drawing.Size(0, 13);
            this.labelOriginalFileName.TabIndex = 5;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonCancel.ForeColor = System.Drawing.Color.Black;
            this.buttonCancel.Location = new System.Drawing.Point(16, 164);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 35);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "キャンセル";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // ClassificationDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 211);
            this.ControlBox = false;
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelOriginalFileName);
            this.Controls.Add(this.labeloriginalFileHeader);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.textBoxClassify);
            this.Controls.Add(this.SelectButton);
            this.Controls.Add(this.ComboBoxClassify);
            this.ForeColor = System.Drawing.Color.Coral;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClassificationDialog";
            this.Text = "分類";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ComboBoxClassify;
        private System.Windows.Forms.Button SelectButton;
        private TextBox textBoxClassify;
        private Label labelDescription;
        private Label labeloriginalFileHeader;
        private Label labelOriginalFileName;
        private Button buttonCancel;
    }
}