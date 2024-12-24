using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileClassifier
{
    public partial class CancelForm : Form
    {
        public CancelForm()
        {
            InitializeComponent();

            SetToolTip(radioButtonAllCancel, "現在のファイルと同時にダウンロードされた\r\n全てのファイルの分類をキャンセルする。");
            SetToolTip(radioButtonSingleCancel, "現在処理対象のファイルの分類をキャンセルする。");

            // 前面へ
            this.BringToFront();

            // 初期化処理
            // OKのまま終わったらキャンセルはしない。
            this.DialogResult = DialogResult.OK;
            radioButtonSingleCancel.Checked = true;
        }

        /// <summary>
        /// 二者択一で、もう片方のコントロールは逆にする。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonAllCancel_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonSingleCancel.Checked = !radioButtonAllCancel.Checked;
        }

        /// <summary>
        /// 二者択一で、もう片方のコントロールは逆にする。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonSingleCancel_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonAllCancel.Checked = !radioButtonSingleCancel.Checked;
        }

        /// <summary>
        /// 任意のコントロールにツールチップ（説明）を追加する。<br/>
        /// 共通の設定で出せるように関数化。
        /// </summary>
        /// <param name="control"></param>
        /// <param name="tips"></param>
        private void SetToolTip(Control control, string tips)
        {
            // ToolTipの作成
            var toolTip = new ToolTip();

            toolTip.InitialDelay = ClassifyManager.ttInitialDelay;
            toolTip.ReshowDelay = ClassifyManager.ttReshowDelay; // 再表示までの遅延

            // ToolTipの設定
            toolTip.SetToolTip(control, tips);
        }

        /// <summary>
        /// OK押されたら画面を閉じる。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if ( radioButtonSingleCancel.Checked )
            {
                this.DialogResult = DialogResult.Yes;
            }
            // 全部キャンセルする場合の処理
            else
            {
                this.DialogResult = DialogResult.No;
            }


            this.Close();
        }
    }
}
