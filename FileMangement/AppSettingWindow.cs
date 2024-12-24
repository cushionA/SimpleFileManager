using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileClassifier
{
    /// <summary>
    /// アプリデータを設定する画面。無視設定と追加の監視パスだけよ
    /// </summary>
    public partial class AppSettingWindow : SettingTemp
    {
        public AppSettingWindow()
        {
            InitializeComponent();
            CheckListInitialize();
            checkBoxSettingWatch.Checked = ClassifyManager.appSetting.isWatchDL;

            // ツールチップの設定。
            SetToolTip(checkBoxSettingWatch, "ダウンロードフォルダに追加されるファイルを監視するか。");

            // フォーカスを移動。
            checkedListBoxExtension.Focus();
        }

        /// <summary>
        /// 開いてフォーカスする。
        /// </summary>
        public override void OpenWindow()
        {
            base.OpenWindow();
            // フォーカスを移動。
            checkedListBoxExtension.Focus();
        }

        /// <summary>
        /// アプリデータを保存して終了
        /// </summary>
        public override void CloseWindow()
        {
            // 別のデータを設定する際、今のアプリデータが変更されているならセーブする。
            if ( isChange && SettingDialog("現在のアプリ設定を保存しますか？") )
            {
                // 変更を適用してセーブ。
                // 変更を適用してセーブ。
                ClassifyManager.SaveAppSettingData();
            }

            base.CloseWindow();

        }


        /// <summary>
        /// データをセーブする。
        /// </summary>
        public override void SaveSetting()
        {
            // 別のデータを設定する際、今のアプリデータが変更されているならセーブする。
            if ( isChange && SettingDialog("現在のアプリ設定を保存しますか？") )
            {
                // 変更を適用してセーブ。
                // 変更を適用してセーブ。
                ClassifyManager.SaveAppSettingData();
            }

            base.SaveSetting();
        }


        /// <summary>
        /// チェックボックスに値を追加し、チェック状態をデータからとる。
        /// </summary>
        private void CheckListInitialize()
        {
            // 初期化
            checkedListBoxExtension.Items.Clear();

            // 拡張子をチェックリストに設定していく
            // All抜くために1から始める
            for ( int i = 1; i <= (int)FileExtension.others; i++ )
            {
                // intの値をExtensionに変換して入れていく
                checkedListBoxExtension.Items.Add($"{((FileExtension)i).ToString()} ファイル");

                // アプリ設定を反映する
                checkedListBoxExtension.SetItemChecked(i - 1, ClassifyManager.appSetting.CheckIgnoreEx(i));
            }

        }

        /// <summary>
        /// 各チェックボックスにツールチップを表示する。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkedListBoxExtension_MouseMove(object sender, MouseEventArgs e)
        {
            int index = checkedListBoxExtension.IndexFromPoint(e.Location);
            if ( index != -1 )
            {
                // ToolTipのテキストを設定（アイテムによって変更可能）
                SetToolTip(checkedListBoxExtension, $"{ClassifyManager.exDescriptions[(FileExtension)(index + 1)]}の分類を有効にするか。");
            }
            else
            {
                SetToolTip(checkedListBoxExtension, string.Empty); // カーソルがアイテムの上にない場合はToolTipを非表示
            }
        }

        /// <summary>
        /// チェック状態を設定に反映する。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkedListBoxExtension_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // 変更されたアイテムのインデックスを取得
            int index = e.Index;

            // チェックの状態を取得（e.NewValueは最新で更新された状態）
            bool isChecked = (e.NewValue == CheckState.Checked);

            // アプリデータに反映
            ClassifyManager.appSetting.UpdateIgnoreSetting(isChecked, index + 1);

            isChange = true;
        }

        /// <summary>
        /// 監視設定の切り替え
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxSettingWatch_CheckedChanged(object sender, EventArgs e)
        {
            // アプリデータに反映
            ClassifyManager.appSetting.isWatchDL = checkBoxSettingWatch.Checked;

            isChange = true;
        }


    }
}
