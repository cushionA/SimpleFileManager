using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileClassifier
{
    public partial class ExtraPathSetter : SettingTemp
    {

        /// <summary>
        /// コンボボックスの最後尾に表示する文字列。
        /// </summary>
        const string addExplanation = "新規パスを追加。";

        public ExtraPathSetter()
        {
            InitializeComponent();

            SetToolTip(comboBoxPathIndex, "設定対象の変更、追加を行う。");
            SetToolTip(textBoxPathDisplay, "ここに表示されるフォルダにファイルが追加されると分類処理を開始する。");
            SetToolTip(buttonPathSet, "使用するフォルダを設定できる。");
            SetToolTip(buttonRemovePath, "設定中のパスを削除できる。");

            // コンボボックスの初期化
            ComboBoxPathIndexInitialize();
        }

        /// <summary>
        /// アプリ設定から初期化する。
        /// </summary>
        private void ComboBoxPathIndexInitialize()
        {

            for ( int i = 0; i < ClassifyManager.appSetting.exWatchPath.Count; i++ )
            {
                comboBoxPathIndex.Items.Add($"設定{i + 1}");
            }

            // 新規追加用のボックスを追加して選択する。
            comboBoxPathIndex.Items.Add(addExplanation);
            comboBoxPathIndex.SelectedIndex = comboBoxPathIndex.Items.Count - 1;
        }

        /// <summary>
        /// 新規追加中なら戻る。<br/>
        /// 新規追加中じゃなければ、つまりコンボボックス選択時に最後尾だったらボタン自体無効化する。<br/>
        /// 設定、ボタンを追加、にかきかえてもいいかも
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRemovePath_Click(object sender, EventArgs e)
        {
            // ダイアログでOK来たら削除
            if ( ClassifyManager.MyDialogBox(this.Parent.FindForm(), $"フォルダ設定{comboBoxPathIndex.SelectedIndex + 1}を削除してもよろしいですか？", "監視パス削除確認", MessageBoxButtons.OKCancel) )
            {
                // 監視もやめさせないと。
                string removePath = ClassifyManager.appSetting.exWatchPath[comboBoxPathIndex.SelectedIndex];
                ClassifyManager.watchController.RemovePath(removePath);
                ClassifyManager.appSetting.exWatchPath.RemoveAt(comboBoxPathIndex.SelectedIndex);
            }
            else
            {
                return;
            }

            // アイテムを消して設定しなおし。
            comboBoxPathIndex.Items.Clear();

            // 設定変更に合わせて初期化する。
            ComboBoxPathIndexInitialize();

        }

        /// <summary>
        /// ファイルパス設定ボタンが押された時の処理。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPathSet_Click(object sender, EventArgs e)
        {

            // 追加処理かどうか。追加でなければ既存パスから。
            bool isAdd = comboBoxPathIndex.SelectedIndex == comboBoxPathIndex.Items.Count - 1;

            // 値がちゃんと帰ってきたときだけ設定する
            string newPath = ClassifyManager.SelectPathDialog();

            if ( newPath == string.Empty )
            {
                return;
            }
            else if ( ClassifyManager.appSetting.exWatchPath.Contains(newPath) )
            {
                ClassifyManager.MyDialogBox(this.Parent.FindForm(), $"選択したパス：{newPath} は既に存在しています", "パス設定エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {

                // コンボボックスの要素を追加。
                // 追加、設定変更時に監視処理の変更必要では？
                // コントロールを閉じる時に一括でやるか？　セーブと一緒に
                if ( isAdd )
                {
                    // 設定を追加して、さらに監視も開始
                    ClassifyManager.appSetting.exWatchPath.Add(newPath);
                    ClassifyManager.watchController.AddPath(newPath);

                    comboBoxPathIndex.Items[comboBoxPathIndex.SelectedIndex] = $"設定{comboBoxPathIndex.SelectedIndex + 1}";
                    comboBoxPathIndex.Items.Add(addExplanation);
                    //comboBoxPathIndex.SelectedIndex = comboBoxPathIndex.Items.Count - 1;
                }
                else
                {
                    // 入れ替え（削除）対象のパスを取得
                    string removePath = ClassifyManager.appSetting.exWatchPath[comboBoxPathIndex.SelectedIndex];
                    // 古いパスの監視を停止して、新しいパスで監視を始める。
                    if ( newPath != removePath )
                    {
                        ClassifyManager.watchController.RemovePath(removePath);
                        ClassifyManager.watchController.AddPath(newPath);
                    }
                    ClassifyManager.appSetting.exWatchPath[comboBoxPathIndex.SelectedIndex] = newPath;
                }

                // テキストボックスを更新。
                textBoxPathDisplay.Text = newPath;
            }
        }

        /// <summary>
        /// 設定対象切り替えコンボボックスの切り替わり時の処理。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxPathIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            // もし最後尾の要素なら新規追加処理
            if ( comboBoxPathIndex.SelectedIndex == comboBoxPathIndex.Items.Count - 1 )
            {
                // データを呼び出す。
                textBoxPathDisplay.Text = string.Empty;
                buttonRemovePath.Enabled = false;
                buttonRemovePath.Visible = false;

                // もし限界に達しているなら追加ボタンを消す
                bool isLimit = !(comboBoxPathIndex.Items.Count - 1 == ClassifyManager.exPathLimit);

                buttonRemovePath.Enabled = isLimit;
                buttonRemovePath.Visible = isLimit;

            }

            // 既存の要素なら編集・削除処理
            else
            {
                // データを呼び出す。
                textBoxPathDisplay.Text = ClassifyManager.appSetting.exWatchPath[comboBoxPathIndex.SelectedIndex];
                buttonRemovePath.Enabled = true;
                buttonRemovePath.Visible = true;

                buttonRemovePath.Enabled = true;
                buttonRemovePath.Visible = true;

            }
        }


    }
}
