using System;

namespace FileClassifier
{
    partial class AppSettingWindow
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
            this.labelExIgnoreSet = new System.Windows.Forms.Label();
            this.checkedListBoxExtension = new System.Windows.Forms.CheckedListBox();
            this.extraPathSetter1 = new FileClassifier.ExtraPathSetter();
            this.labelDownloadSetting = new System.Windows.Forms.Label();
            this.checkBoxSettingWatch = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // labelExIgnoreSet
            // 
            this.labelExIgnoreSet.AutoSize = true;
            this.labelExIgnoreSet.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelExIgnoreSet.Location = new System.Drawing.Point(96, 34);
            this.labelExIgnoreSet.Name = "labelExIgnoreSet";
            this.labelExIgnoreSet.Size = new System.Drawing.Size(304, 21);
            this.labelExIgnoreSet.TabIndex = 1;
            this.labelExIgnoreSet.Text = "・拡張子別の自動分類有効設定";
            // 
            // checkedListBoxExtension
            // 
            this.checkedListBoxExtension.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.checkedListBoxExtension.FormattingEnabled = true;
            this.checkedListBoxExtension.Location = new System.Drawing.Point(100, 70);
            this.checkedListBoxExtension.MultiColumn = true;
            this.checkedListBoxExtension.Name = "checkedListBoxExtension";
            this.checkedListBoxExtension.Size = new System.Drawing.Size(510, 225);
            this.checkedListBoxExtension.TabIndex = 2;
            this.checkedListBoxExtension.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxExtension_ItemCheck);
            //this.checkedListBoxExtension.MouseMove += new System.Windows.Forms.MouseEventHandler(this.checkedListBoxExtension_MouseMove);
            // 
            // extraPathSetter1
            // 
            this.extraPathSetter1.Location = new System.Drawing.Point(100, 317);
            this.extraPathSetter1.Name = "extraPathSetter1";
            this.extraPathSetter1.Size = new System.Drawing.Size(390, 102);
            this.extraPathSetter1.TabIndex = 3;
            this.extraPathSetter1.Click += new System.EventHandler((object o, EventArgs e) => this.isChange = false);
            // 
            // labelDownloadSetting
            // 
            this.labelDownloadSetting.AutoSize = true;
            this.labelDownloadSetting.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelDownloadSetting.Location = new System.Drawing.Point(96, 437);
            this.labelDownloadSetting.Name = "labelDownloadSetting";
            this.labelDownloadSetting.Size = new System.Drawing.Size(274, 21);
            this.labelDownloadSetting.TabIndex = 4;
            this.labelDownloadSetting.Text = "・ダウンロードフォルダ監視設定";
            // 
            // checkBoxSettingWatch
            // 
            this.checkBoxSettingWatch.AutoSize = true;
            this.checkBoxSettingWatch.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.checkBoxSettingWatch.Location = new System.Drawing.Point(105, 469);
            this.checkBoxSettingWatch.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxSettingWatch.Name = "checkBoxSettingWatch";
            this.checkBoxSettingWatch.Size = new System.Drawing.Size(295, 20);
            this.checkBoxSettingWatch.TabIndex = 18;
            this.checkBoxSettingWatch.Text = "ダウンロードしたファイルを自動で分類する。";
            this.checkBoxSettingWatch.UseVisualStyleBackColor = true;
            this.checkBoxSettingWatch.CheckedChanged += new System.EventHandler(this.checkBoxSettingWatch_CheckedChanged);
            // 
            // AppSettingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBoxSettingWatch);
            this.Controls.Add(this.labelDownloadSetting);
            this.Controls.Add(this.extraPathSetter1);
            this.Controls.Add(this.checkedListBoxExtension);
            this.Controls.Add(this.labelExIgnoreSet);
            this.Name = "AppSettingWindow";
            this.Size = new System.Drawing.Size(716, 720);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelExIgnoreSet;
        private System.Windows.Forms.CheckedListBox checkedListBoxExtension;
        private ExtraPathSetter extraPathSetter1;
        private System.Windows.Forms.Label labelDownloadSetting;
        private System.Windows.Forms.CheckBox checkBoxSettingWatch;
    }
}
