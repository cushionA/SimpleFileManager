namespace FileClassifier
{
    partial class ClassifySettingWindow
    {
        private System.Windows.Forms.TextBox textBoxClassifyName;
        private System.Windows.Forms.Label labelClassifyName;
        private System.Windows.Forms.Label labelExtensionSelect;
        private System.Windows.Forms.Label labelDefaultName;
        private System.Windows.Forms.CheckBox checkBoxUseExtension;
        private System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.Label labelFilePath;
        private System.Windows.Forms.TextBox textBoxPathDisplay;
        private System.Windows.Forms.Button buttonPathSet;
        private System.Windows.Forms.CheckBox checkBoxAllPathSet;
        private System.Windows.Forms.ComboBox comboBoxExtensionSelect;
        private System.Windows.Forms.Label labelFileNameHandle;
        private System.Windows.Forms.ComboBox comboBoxDateHandle;
        private System.Windows.Forms.Label labelDateHandle;
        private System.Windows.Forms.CheckBox checkBoxJapaneseCheck;
        private System.Windows.Forms.ComboBox comboBoxFileNameHandle;
        private System.Windows.Forms.CheckBox checkBoxReplaceSetting;

        private void InitializeComponent()
        {
            this.textBoxClassifyName = new System.Windows.Forms.TextBox();
            this.labelClassifyName = new System.Windows.Forms.Label();
            this.labelExtensionSelect = new System.Windows.Forms.Label();
            this.labelDefaultName = new System.Windows.Forms.Label();
            this.checkBoxUseExtension = new System.Windows.Forms.CheckBox();
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.labelFilePath = new System.Windows.Forms.Label();
            this.textBoxPathDisplay = new System.Windows.Forms.TextBox();
            this.buttonPathSet = new System.Windows.Forms.Button();
            this.checkBoxAllPathSet = new System.Windows.Forms.CheckBox();
            this.comboBoxExtensionSelect = new System.Windows.Forms.ComboBox();
            this.labelFileNameHandle = new System.Windows.Forms.Label();
            this.comboBoxDateHandle = new System.Windows.Forms.ComboBox();
            this.labelDateHandle = new System.Windows.Forms.Label();
            this.checkBoxJapaneseCheck = new System.Windows.Forms.CheckBox();
            this.comboBoxFileNameHandle = new System.Windows.Forms.ComboBox();
            this.checkBoxReplaceSetting = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBoxClassifyName
            // 
            this.textBoxClassifyName.Font = new System.Drawing.Font("MS UI Gothic", 14F);
            this.textBoxClassifyName.Location = new System.Drawing.Point(140, 50);
            this.textBoxClassifyName.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxClassifyName.MaxLength = 25;
            this.textBoxClassifyName.Name = "textBoxClassifyName";
            this.textBoxClassifyName.Size = new System.Drawing.Size(435, 26);
            this.textBoxClassifyName.TabIndex = 0;
            this.textBoxClassifyName.Leave += new System.EventHandler(this.textBoxClassifyName_Leave);
            // 
            // labelClassifyName
            // 
            this.labelClassifyName.AutoSize = true;
            this.labelClassifyName.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold);
            this.labelClassifyName.Location = new System.Drawing.Point(140, 25);
            this.labelClassifyName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelClassifyName.Name = "labelClassifyName";
            this.labelClassifyName.Size = new System.Drawing.Size(273, 22);
            this.labelClassifyName.TabIndex = 1;
            this.labelClassifyName.Text = "・設定の名前（上限25文字）";
            // 
            // labelExtensionSelect
            // 
            this.labelExtensionSelect.AutoSize = true;
            this.labelExtensionSelect.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold);
            this.labelExtensionSelect.Location = new System.Drawing.Point(140, 95);
            this.labelExtensionSelect.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelExtensionSelect.Name = "labelExtensionSelect";
            this.labelExtensionSelect.Size = new System.Drawing.Size(193, 22);
            this.labelExtensionSelect.TabIndex = 2;
            this.labelExtensionSelect.Text = "・設定区分切り替え";
            // 
            // labelDefaultName
            // 
            this.labelDefaultName.AutoSize = true;
            this.labelDefaultName.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold);
            this.labelDefaultName.Location = new System.Drawing.Point(140, 160);
            this.labelDefaultName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDefaultName.Name = "labelDefaultName";
            this.labelDefaultName.Size = new System.Drawing.Size(301, 22);
            this.labelDefaultName.TabIndex = 3;
            this.labelDefaultName.Text = "・デフォルトで使用するファイル名";
            // 
            // checkBoxUseExtension
            // 
            this.checkBoxUseExtension.AutoSize = true;
            this.checkBoxUseExtension.Location = new System.Drawing.Point(240, 127);
            this.checkBoxUseExtension.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxUseExtension.Name = "checkBoxUseExtension";
            this.checkBoxUseExtension.Size = new System.Drawing.Size(184, 16);
            this.checkBoxUseExtension.TabIndex = 4;
            this.checkBoxUseExtension.Text = "この拡張子の設定を有効化する。";
            this.checkBoxUseExtension.UseVisualStyleBackColor = true;
            this.checkBoxUseExtension.CheckedChanged += new System.EventHandler(this.checkBoxUseExtension_Change);
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Font = new System.Drawing.Font("MS UI Gothic", 13F);
            this.textBoxFileName.Location = new System.Drawing.Point(140, 190);
            this.textBoxFileName.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.Size = new System.Drawing.Size(218, 25);
            this.textBoxFileName.TabIndex = 5;
            this.textBoxFileName.Text = "ファイル名";
            this.textBoxFileName.Leave += new System.EventHandler(this.textBoxFileName_Leave);
            // 
            // labelFilePath
            // 
            this.labelFilePath.AutoSize = true;
            this.labelFilePath.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelFilePath.Location = new System.Drawing.Point(140, 235);
            this.labelFilePath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFilePath.Name = "labelFilePath";
            this.labelFilePath.Size = new System.Drawing.Size(203, 21);
            this.labelFilePath.TabIndex = 7;
            this.labelFilePath.Text = "・保存先のファイルパス";
            // 
            // textBoxPathDisplay
            // 
            this.textBoxPathDisplay.Cursor = System.Windows.Forms.Cursors.No;
            this.textBoxPathDisplay.Font = new System.Drawing.Font("MS UI Gothic", 10.5F);
            this.textBoxPathDisplay.Location = new System.Drawing.Point(140, 260);
            this.textBoxPathDisplay.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPathDisplay.Name = "textBoxPathDisplay";
            this.textBoxPathDisplay.ReadOnly = true;
            this.textBoxPathDisplay.Size = new System.Drawing.Size(257, 21);
            this.textBoxPathDisplay.TabIndex = 8;
            this.textBoxPathDisplay.Text = "右のボタンで設定してください。";
            this.textBoxPathDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // buttonPathSet
            // 
            this.buttonPathSet.Font = new System.Drawing.Font("MS UI Gothic", 10F);
            this.buttonPathSet.Location = new System.Drawing.Point(401, 260);
            this.buttonPathSet.Margin = new System.Windows.Forms.Padding(2);
            this.buttonPathSet.Name = "buttonPathSet";
            this.buttonPathSet.Size = new System.Drawing.Size(45, 21);
            this.buttonPathSet.TabIndex = 9;
            this.buttonPathSet.Text = "設定";
            this.buttonPathSet.UseVisualStyleBackColor = true;
            this.buttonPathSet.Click += new System.EventHandler(this.buttonPathSet_Click);
            this.buttonPathSet.Leave += new System.EventHandler(this.buttonPathSet_Leave);
            // 
            // checkBoxAllPathSet
            // 
            this.checkBoxAllPathSet.AutoSize = true;
            this.checkBoxAllPathSet.Location = new System.Drawing.Point(450, 264);
            this.checkBoxAllPathSet.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxAllPathSet.Name = "checkBoxAllPathSet";
            this.checkBoxAllPathSet.Size = new System.Drawing.Size(123, 16);
            this.checkBoxAllPathSet.TabIndex = 10;
            this.checkBoxAllPathSet.Text = "全体の設定を使用。";
            this.checkBoxAllPathSet.UseVisualStyleBackColor = true;
            this.checkBoxAllPathSet.CheckedChanged += new System.EventHandler(this.checkBoxAllPathSet_CheckedChanged);
            // 
            // comboBoxExtensionSelect
            // 
            this.comboBoxExtensionSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxExtensionSelect.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.comboBoxExtensionSelect.FormattingEnabled = true;
            this.comboBoxExtensionSelect.Location = new System.Drawing.Point(140, 120);
            this.comboBoxExtensionSelect.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxExtensionSelect.Name = "comboBoxExtensionSelect";
            this.comboBoxExtensionSelect.Size = new System.Drawing.Size(95, 24);
            this.comboBoxExtensionSelect.TabIndex = 11;
            this.comboBoxExtensionSelect.SelectedIndexChanged += new System.EventHandler(this.comboBoxExtensionSelect_Changed);
            // 
            // labelFileNameHandle
            // 
            this.labelFileNameHandle.AutoSize = true;
            this.labelFileNameHandle.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold);
            this.labelFileNameHandle.Location = new System.Drawing.Point(140, 300);
            this.labelFileNameHandle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFileNameHandle.Name = "labelFileNameHandle";
            this.labelFileNameHandle.Size = new System.Drawing.Size(264, 22);
            this.labelFileNameHandle.TabIndex = 12;
            this.labelFileNameHandle.Text = "・元のファイル名の処理設定";
            // 
            // comboBoxDateHandle
            // 
            this.comboBoxDateHandle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDateHandle.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.comboBoxDateHandle.FormattingEnabled = true;
            this.comboBoxDateHandle.Location = new System.Drawing.Point(140, 405);
            this.comboBoxDateHandle.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxDateHandle.Name = "comboBoxDateHandle";
            this.comboBoxDateHandle.Size = new System.Drawing.Size(120, 24);
            this.comboBoxDateHandle.TabIndex = 13;
            this.comboBoxDateHandle.SelectedIndexChanged += new System.EventHandler(this.comboBoxDateHandle_Changed);
            // 
            // labelDateHandle
            // 
            this.labelDateHandle.AutoSize = true;
            this.labelDateHandle.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelDateHandle.Location = new System.Drawing.Point(140, 375);
            this.labelDateHandle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDateHandle.Name = "labelDateHandle";
            this.labelDateHandle.Size = new System.Drawing.Size(358, 21);
            this.labelDateHandle.TabIndex = 14;
            this.labelDateHandle.Text = "・現在の日付のファイル名組み込み設定";
            // 
            // checkBoxJapaneseCheck
            // 
            this.checkBoxJapaneseCheck.AutoSize = true;
            this.checkBoxJapaneseCheck.Location = new System.Drawing.Point(286, 336);
            this.checkBoxJapaneseCheck.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxJapaneseCheck.Name = "checkBoxJapaneseCheck";
            this.checkBoxJapaneseCheck.Size = new System.Drawing.Size(190, 16);
            this.checkBoxJapaneseCheck.TabIndex = 15;
            this.checkBoxJapaneseCheck.Text = "日本語を含むファイル名のみ使用。";
            this.checkBoxJapaneseCheck.UseVisualStyleBackColor = true;
            this.checkBoxJapaneseCheck.CheckedChanged += new System.EventHandler(this.checkBoxJapaneseCheck_Changed);
            // 
            // comboBoxFileNameHandle
            // 
            this.comboBoxFileNameHandle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFileNameHandle.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.comboBoxFileNameHandle.FormattingEnabled = true;
            this.comboBoxFileNameHandle.Location = new System.Drawing.Point(140, 330);
            this.comboBoxFileNameHandle.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxFileNameHandle.Name = "comboBoxFileNameHandle";
            this.comboBoxFileNameHandle.Size = new System.Drawing.Size(142, 24);
            this.comboBoxFileNameHandle.TabIndex = 16;
            this.comboBoxFileNameHandle.SelectedIndexChanged += new System.EventHandler(this.comboBoxFileNameHandle_Changed);
            // 
            // checkBoxReplaceSetting
            // 
            this.checkBoxReplaceSetting.AutoSize = true;
            this.checkBoxReplaceSetting.Location = new System.Drawing.Point(360, 195);
            this.checkBoxReplaceSetting.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxReplaceSetting.Name = "checkBoxReplaceSetting";
            this.checkBoxReplaceSetting.Size = new System.Drawing.Size(217, 16);
            this.checkBoxReplaceSetting.TabIndex = 17;
            this.checkBoxReplaceSetting.Text = "ファイル名に置き換え文字列を使用する。";
            this.checkBoxReplaceSetting.UseVisualStyleBackColor = true;
            this.checkBoxReplaceSetting.CheckedChanged += new System.EventHandler(this.checkBoxReplaceSetting_Changed);
            // 
            // ClassifySettingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBoxDateHandle);
            this.Controls.Add(this.labelDateHandle);
            this.Controls.Add(this.comboBoxFileNameHandle);
            this.Controls.Add(this.checkBoxJapaneseCheck);
            this.Controls.Add(this.labelFileNameHandle);
            this.Controls.Add(this.buttonPathSet);
            this.Controls.Add(this.checkBoxAllPathSet);
            this.Controls.Add(this.labelFilePath);
            this.Controls.Add(this.textBoxPathDisplay);
            this.Controls.Add(this.checkBoxReplaceSetting);
            this.Controls.Add(this.textBoxFileName);
            this.Controls.Add(this.labelDefaultName);
            this.Controls.Add(this.checkBoxUseExtension);
            this.Controls.Add(this.labelExtensionSelect);
            this.Controls.Add(this.comboBoxExtensionSelect);
            this.Controls.Add(this.labelClassifyName);
            this.Controls.Add(this.textBoxClassifyName);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ClassifySettingWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}