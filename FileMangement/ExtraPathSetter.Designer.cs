namespace FileClassifier
{
    partial class ExtraPathSetter
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if ( disposing && (components != null) )
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPathDisplay = new System.Windows.Forms.TextBox();
            this.buttonPathSet = new System.Windows.Forms.Button();
            this.comboBoxPathIndex = new System.Windows.Forms.ComboBox();
            this.buttonRemovePath = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(-2, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "・監視対象フォルダ設定";
            // 
            // textBoxPathDisplay
            // 
            this.textBoxPathDisplay.Cursor = System.Windows.Forms.Cursors.No;
            this.textBoxPathDisplay.Font = new System.Drawing.Font("MS UI Gothic", 10.5F);
            this.textBoxPathDisplay.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.textBoxPathDisplay.Location = new System.Drawing.Point(13, 70);
            this.textBoxPathDisplay.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPathDisplay.Name = "textBoxPathDisplay";
            this.textBoxPathDisplay.ReadOnly = true;
            this.textBoxPathDisplay.Size = new System.Drawing.Size(260, 21);
            this.textBoxPathDisplay.TabIndex = 1;
            this.textBoxPathDisplay.TabStop = false;
            this.textBoxPathDisplay.Text = "右のボタンで設定してください。";
            this.textBoxPathDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // buttonPathSet
            // 
            this.buttonPathSet.Font = new System.Drawing.Font("MS UI Gothic", 10F);
            this.buttonPathSet.Location = new System.Drawing.Point(277, 70);
            this.buttonPathSet.Margin = new System.Windows.Forms.Padding(2);
            this.buttonPathSet.Name = "buttonPathSet";
            this.buttonPathSet.Size = new System.Drawing.Size(45, 21);
            this.buttonPathSet.TabIndex = 2;
            this.buttonPathSet.Text = "設定";
            this.buttonPathSet.UseVisualStyleBackColor = true;
            this.buttonPathSet.Click += new System.EventHandler(this.buttonPathSet_Click);
            // 
            // comboBoxPathIndex
            // 
            this.comboBoxPathIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPathIndex.Font = new System.Drawing.Font("MS UI Gothic", 13F);
            this.comboBoxPathIndex.FormattingEnabled = true;
            this.comboBoxPathIndex.Location = new System.Drawing.Point(14, 40);
            this.comboBoxPathIndex.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxPathIndex.Name = "comboBoxPathIndex";
            this.comboBoxPathIndex.Size = new System.Drawing.Size(202, 25);
            this.comboBoxPathIndex.TabIndex = 1;
            this.comboBoxPathIndex.SelectedIndexChanged += new System.EventHandler(this.comboBoxPathIndex_SelectedIndexChanged);
            // 
            // buttonRemovePath
            // 
            this.buttonRemovePath.Font = new System.Drawing.Font("MS UI Gothic", 10F);
            this.buttonRemovePath.Location = new System.Drawing.Point(326, 70);
            this.buttonRemovePath.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRemovePath.Name = "buttonRemovePath";
            this.buttonRemovePath.Size = new System.Drawing.Size(45, 21);
            this.buttonRemovePath.TabIndex = 3;
            this.buttonRemovePath.Text = "削除";
            this.buttonRemovePath.UseVisualStyleBackColor = true;
            this.buttonRemovePath.Click += new System.EventHandler(this.buttonRemovePath_Click);
            // 
            // ExtraPathSetter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonRemovePath);
            this.Controls.Add(this.comboBoxPathIndex);
            this.Controls.Add(this.buttonPathSet);
            this.Controls.Add(this.textBoxPathDisplay);
            this.Controls.Add(this.label1);
            this.Name = "ExtraPathSetter";
            this.Size = new System.Drawing.Size(390, 102);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPathDisplay;
        private System.Windows.Forms.Button buttonPathSet;
        private System.Windows.Forms.ComboBox comboBoxPathIndex;
        private System.Windows.Forms.Button buttonRemovePath;
    }
}
