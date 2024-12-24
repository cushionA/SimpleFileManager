using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FileClassifier.ClassifySelectButtons;

namespace FileClassifier
{
    public partial class SettingForm : Form, IMultiButtonUser
    {

        /// <summary>
        /// 現在開いている設定ウィンドウ。<br/>
        /// 画面切り替えの時、あるいは設定ウィンドウを閉じる際はCloseWindowを呼んでやる。
        /// ボタンにカーソルを合わせるとどの設定をいじるか、のボタンが展開されるようにするか。
        /// それが済んだら監視処理の描きなおしと（）設定変更時に監視が変更されるようにな
        /// あと分類処理のところに無視設定を入れるよ
        /// </summary>
        private SettingTemp nowWindow;

        public SettingForm()
        {
            InitializeComponent();
            classifySelectButtons.parent = this;

            // 初期化。
            nowWindow = classifySettingWindow;
            nowWindow.OpenWindow();

            appSettingWindow.Enabled = false;
            appSettingWindow.Visible = false;

            classifySelectButtons.Enabled = false;

            // 選択ボタンを消すための処理
            classifySettingWindow.Click += new EventHandler(SettingForm_FormClick);
            appSettingWindow.Click += new EventHandler(SettingForm_FormClick);

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>
        /// アプリ設定を開始する。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAppSettingSelect_Click(object sender, EventArgs e)
        {

            // 選択ボタンを閉じる
            classifySelectButtons.Enabled = false;

            // すでにアプリ設定開いてるなら戻る。
            if ( nowWindow is AppSettingWindow )
            {
                return;
            }

            // 閉じてから新しくウインドウを開く。
            nowWindow.CloseWindow();
            nowWindow = appSettingWindow;
            nowWindow.OpenWindow();


        }

        /// <summary>
        /// ボタン押されたら子ボタン出すようにする。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClassifySelect_Click(object sender, EventArgs e)
        {
            // 押されるたびに反転。
            bool setEnable = !classifySelectButtons.Enabled;
            classifySelectButtons.Enabled = setEnable;
        }

        /// <summary>
        /// 閉じる時のイベント。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            nowWindow.CloseWindow();
        }

        /// <summary>
        /// クリック時のイベント。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingForm_FormClick(object sender, EventArgs e)
        {

            // 選択ボタンの外に出てクリックしていたら非表示にする
            classifySelectButtons.Enabled = false;
        }

        /// <summary>
        /// 子ボタンから報告を受けるよ。
        /// そしてウインドウ切り替え。
        /// </summary>
        /// <param name="pushIndex"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void GetButtonPush(int pushIndex)
        {


            // 閉じてから新しくウインドウを開く。
            nowWindow.CloseWindow();
            nowWindow = classifySettingWindow;
            nowWindow.OpenWindow();


            // 設定画面をインデックスに従って更新。
            classifySettingWindow.InitializeData(pushIndex);

        }

        /// <summary>
        /// セーブする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            nowWindow.SaveSetting();
        }

    }
}
