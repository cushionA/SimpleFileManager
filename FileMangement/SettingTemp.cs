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
    /// <summary>
    /// 予定されている設定画面。<br/>
    /// 分類設定、アプリ設定、範囲削除（任意の拡張子にチェックつけて、コンボボックスかな？　それで、任意の期間使用されてないファイルを消せるようにする。対象は分類パスとして利用されてるフォルダだけ。）。
    /// 範囲削除とはいえ、イメージは削除、じゃなくてそのフォルダに「廃棄」フォルダを作成して移動させる感じ。
    /// </summary>
    public partial class SettingTemp : UserControl
    {
        public SettingTemp()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 設定を変更しているか、というフラグ。
        /// </summary>
        protected bool isChange = false;

        #region Publicメソッド。

        /// <summary>
        /// ある画面を閉じるときの処理。
        /// 保存とかしとこう。
        /// </summary>
        public virtual void OpenWindow()
        {
            // 開くよ
            ControlEnableTurn(this, true);
        }

        /// <summary>
        /// ある画面を閉じるときの処理。
        /// 保存とかしとこう。
        /// </summary>
        public virtual void CloseWindow()
        {
            // 閉じるよ。
            ControlEnableTurn(this, false);

            isChange = false;
        }

        /// <summary>
        /// 設定データ保存
        /// </summary>
        public virtual void SaveSetting()
        {
            isChange = false;
        }


        #endregion Publicメソッド。


        /// <summary>
        /// コントロールの有効、無効を切り替える。<br/>
        /// 非表示、表示までやる。
        /// </summary>
        protected void ControlEnableTurn(Control control, bool isEnable)
        {
            control.Enabled = isEnable;
            control.Visible = isEnable;
        }

        /// <summary>
        /// 任意のコントロールにツールチップ（説明）を追加する。<br/>
        /// 共通の設定で出せるように関数化。
        /// </summary>
        /// <param name="control"></param>
        /// <param name="tips"></param>
        public void SetToolTip(Control control, string tips)
        {
            // ToolTipの作成
            var toolTip = new ToolTip();

            toolTip.InitialDelay = ClassifyManager.ttInitialDelay;
            toolTip.ReshowDelay = ClassifyManager.ttReshowDelay; // 再表示までの遅延

            // ToolTipの設定
            toolTip.SetToolTip(control, tips);
        }

        /// <summary>
        /// メッセージボックスのラッパー関数。
        /// </summary>
        /// <param name="message"></param>
        /// <param name="caption"></param>
        /// <param name="type"></param>
        /// <param name="icon"></param>
        /// <returns></returns>
        protected bool SettingDialog(string message, string caption = "確認", MessageBoxButtons type = MessageBoxButtons.OKCancel, MessageBoxIcon icon = MessageBoxIcon.Question)
        {
            return ClassifyManager.MyDialogBox(this.Parent.FindForm(), message, caption, type, icon);
        }

    }
}
