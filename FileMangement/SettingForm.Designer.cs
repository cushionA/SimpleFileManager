namespace FileClassifier
{
    partial class SettingForm
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

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Button buttonClassifySelect;
            System.Windows.Forms.Button buttonAppSettingSelect;
            System.Windows.Forms.Button buttonSave;
            this.classifySelectButtons = new FileClassifier.ClassifySelectButtons();
            this.classifySettingWindow = new FileClassifier.ClassifySettingWindow();
            this.appSettingWindow = new FileClassifier.AppSettingWindow();
            buttonClassifySelect = new System.Windows.Forms.Button();
            buttonAppSettingSelect = new System.Windows.Forms.Button();
            buttonSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonClassifySelect
            // 
            buttonClassifySelect.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            buttonClassifySelect.Location = new System.Drawing.Point(3, 5);
            buttonClassifySelect.Name = "buttonClassifySelect";
            buttonClassifySelect.Size = new System.Drawing.Size(46, 174);
            buttonClassifySelect.TabIndex = 1;
            buttonClassifySelect.Text = "ファイル分類設定";
            buttonClassifySelect.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            buttonClassifySelect.UseVisualStyleBackColor = false;
            buttonClassifySelect.Click += new System.EventHandler(this.buttonClassifySelect_Click);
            // 
            // buttonAppSettingSelect
            // 
            buttonAppSettingSelect.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            buttonAppSettingSelect.Location = new System.Drawing.Point(3, 185);
            buttonAppSettingSelect.Name = "buttonAppSettingSelect";
            buttonAppSettingSelect.Size = new System.Drawing.Size(46, 174);
            buttonAppSettingSelect.TabIndex = 2;
            buttonAppSettingSelect.Text = "　アプリ設定";
            buttonAppSettingSelect.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            buttonAppSettingSelect.UseVisualStyleBackColor = false;
            buttonAppSettingSelect.Click += new System.EventHandler(this.buttonAppSettingSelect_Click);
            // 
            // classifySelectButtons
            // 
            this.classifySelectButtons.BackColor = System.Drawing.Color.Transparent;
            this.classifySelectButtons.Location = new System.Drawing.Point(35, 0);
            this.classifySelectButtons.Name = "classifySelectButtons";
            this.classifySelectButtons.Size = new System.Drawing.Size(133, 279);
            this.classifySelectButtons.TabIndex = 5;
            // 
            // classifySettingWindow
            // 
            this.classifySettingWindow.Location = new System.Drawing.Point(40, 5);
            this.classifySettingWindow.Margin = new System.Windows.Forms.Padding(2);
            this.classifySettingWindow.Name = "classifySettingWindow";
            this.classifySettingWindow.Size = new System.Drawing.Size(715, 770);
            this.classifySettingWindow.TabIndex = 4;
            // 
            // appSettingWindow
            // 
            this.appSettingWindow.Location = new System.Drawing.Point(56, 0);
            this.appSettingWindow.Name = "appSettingWindow";
            this.appSettingWindow.Size = new System.Drawing.Size(716, 720);
            this.appSettingWindow.TabIndex = 6;
            // 
            // buttonSave
            // 
            buttonSave.Font = new System.Drawing.Font("ＭＳ ゴシック", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            buttonSave.Location = new System.Drawing.Point(4, 365);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new System.Drawing.Size(126, 120);
            buttonSave.TabIndex = 7;
            buttonSave.Text = "設定保存";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 516);
            this.Controls.Add(buttonSave);
            this.Controls.Add(this.classifySelectButtons);
            this.Controls.Add(this.classifySettingWindow);
            this.Controls.Add(buttonClassifySelect);
            this.Controls.Add(buttonAppSettingSelect);
            this.Controls.Add(this.appSettingWindow);
            this.Name = "SettingForm";
            this.Text = "設定ウインドウ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingForm_FormClosing);
            this.Click += new System.EventHandler(this.SettingForm_FormClick);
            this.ResumeLayout(false);

        }

        #endregion
        private ClassifySettingWindow classifySettingWindow;
        private ClassifySelectButtons classifySelectButtons;
        private AppSettingWindow appSettingWindow;
    }
}

