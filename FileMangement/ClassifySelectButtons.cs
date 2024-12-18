using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace FileClassifier
{
    public partial class ClassifySelectButtons : UserControl
    {

        #region 定義

        /// <summary>
        /// 複数ボタンを使う人が実装するインターフェース。
        /// </summary>
        public interface IMultiButtonUser
        {
            /// <summary>
            /// 押されたボタンの番号を返す。
            /// </summary>
            /// <param name="pushIndex"></param>
            void GetButtonPush(int pushIndex);
        }

        #endregion

        private Button[] selectButtons = new Button[10];

        /// <summary>
        /// このマルチボタンを使用する親オブジェクト
        /// </summary>
        public IMultiButtonUser parent;

        /// <summary>
        /// コンストラク
        /// ボタンを配列に格納し、タイマー開始する。
        /// </summary>
        public ClassifySelectButtons()
        {
            InitializeComponent();

            // 配列の要素にボタンを代入
            for ( int i = 0; i < selectButtons.Length; i++ )
            {
                // ボタンの名前を動的に生成
                string buttonName = "button" + (i + 1).ToString();

                // フォームからボタンを取得し、配列に格納
                selectButtons[i] = (Button)this.Controls.Find(buttonName, true)[0];

                // 共通イベントハンドラを登録。
                selectButtons[i].Click += new System.EventHandler(this.ButtonClickEvent);
            }

        }

        /// <summary>
        /// マルチボタン共通の押した時のイベント。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClickEvent(object sender, EventArgs e)
        {
            // 何番目のボタンが押されたかを確認して親に返す。
            int index = Array.IndexOf(selectButtons, (Button)sender);

            parent.GetButtonPush(index);

            // 役目を終えたら消える。
            this.Enabled = false;
        }

        /// <summary>
        /// 有効時にToolTipを変更する。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClassifySelectButtons_EnabledChanged(object sender, EventArgs e)
        {
            // 有効時はTooltipを設定しなおす。
            if ( this.Enabled == true )
            {
                for ( int i = 0; i < selectButtons.Length; i++ )
                {
                    SetToolTip(selectButtons[i], i);
                }

                Visible = true;
            }
            // 無効化されたら visibleも消す
            else
            {
                this.Visible = false;
            }
        }



        /// <summary>
        /// 任意のコントロールにツールチップ（説明）を追加する。<br/>
        /// 一律の文言でやります。
        /// </summary>
        /// <param name="control"></param>
        /// <param name="tips"></param>
        public void SetToolTip(Control control, int num)
        {
            // ToolTipの作成
            var toolTip = new ToolTip();

            toolTip.InitialDelay = ClassifyManager.ttInitialDelay;
            toolTip.ReshowDelay = ClassifyManager.ttReshowDelay; // 再表示までの遅延

            // ToolTipの設定
            toolTip.SetToolTip(control, $"{num + 1}番目の分類設定 \r\n設定名：「{ClassifyManager.classifierDataArray[num].ClassifyName}」を編集する");
        }


    }
}
