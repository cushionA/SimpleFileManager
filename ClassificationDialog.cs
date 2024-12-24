using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace FileClassifier
{
    /// <summary>
    /// 分類画面。
    /// 仕様として、ここではどの分類にするかを選ぶコンボボックスがある。
    /// このコンボボックスは展開すると横幅が分類の文字数に応じて広がる。
    /// そしてダウンロードしたフォルダの名前や拡張子を表示する。
    /// OKボタンを押すと次の画面に遷移する。
    /// 次の画面では「○○を分類：として保存しました」的なのを出す
    /// でもファイル名決定に関する設定があればテキストボックスを表示する
    /// そのテキストボックスではデフォルトのファイル名をコピーしたりできる。
    /// 
    /// これはダウンロードされた時に起動する。
    /// けど任意で選択したファイルにも分類をできるように
    /// あとダウンロードフォルダ以外も監視できるようにする。
    /// じどうかんしをオンオフきりかえられるように？　オフの場合は任意起動のファイル分類のみになる。
    /// あと特定の拡張子を無視できるように
    /// 
    /// やること
    /// 確認ダイアログを出す
    /// 設定画面を作る
    /// パス生成をブレイク入れて見る
    /// 
    /// 結果が No の場合だけ全キャンセル。
    /// 
    /// </summary>
    public partial class ClassificationDialog : Form
    {

        /// <summary>
        /// 分類設定。リポジトリから引っ張って来てね
        /// </summary>
        private ClassifierData[] classifierSetting;

        /// <summary>
        /// 保存されたファイルのパス。
        /// </summary>
        private string usePath;

        private FileExtension useExtension;

        /// <summary>
        /// コンボボックスのアイテムと分類設定内の番号の対応辞書。
        /// </summary>
        Dictionary<string, int> indexDic = new Dictionary<string, int>();

        /// <summary>
        /// 初期化のコントラクタ。
        /// </summary>
        /// <param name="filePath">ファイルのパス</param>
        /// <param name="extension">使用する設定を選ぶため</param>
        public ClassificationDialog(string filePath, FileExtension extension)
        {
            usePath = filePath;
            useExtension = extension;

            // UIの初期化
            InitializeComponent();

            // 置き換え文字用テキストボックスを非活性に。
            textBoxClassify.Enabled = false;
            textBoxClassify.Visible = false;
            labelDescription.Text = "使用する設定を選んでください。";

            // 元のファイル名を表示。
            labelOriginalFileName.Text = Path.GetFileName(usePath);

            // 分類設定の反映。
            ClassifyDataSet();

            // ツールチップ設定。
            SetToolTip(textBoxClassify, "置き換え文字列を設定する。\r\n置き換え文字列：ファイル名に@が含まれている場合、その位置に挿入する文字列。");

            SetToolTip(ComboBoxClassify, "使用する分類設定を選択する。\r\n分類設定：取得したファイルをどのフォルダに移動させるか、といったファイル整理に使用する設定。");

            SetToolTip(buttonCancel, "分類処理をキャンセルする。");

            // 最前面に表示
            this.TopMost = true;

            // 初期値
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 分類データをセットする。
        /// </summary>
        private void ClassifyDataSet()
        {
            // リポジトリから設定の参照をもらう。
            classifierSetting = ClassifyManager.classifierDataArray;

            // コンボボックスの初期化。
            // 分類データを読み取る。
            // これはリポジトリで管理するか。
            // 
            ComboBoxClassify.Items.Clear();

            ComboBoxClassify.Text = "ファイルを分類してください。";
            ComboBoxClassify.DropDownHeight = ComboBoxClassify.Height * 4;

            // 初期表示はこれ
            ComboBoxClassify.Text = "設定を選んでください。";

            // コンボボックスに各データの名前を表示する。
            for ( int i = 0; i < classifierSetting.Length; i++ )
            {
                // 初期化済みなら追加
                if ( classifierSetting[i].isInitialize )
                {
                    // 対応表とコンボボックスのアイテムを追加。
                    ComboBoxClassify.Items.Add(classifierSetting[i].ClassifyName);
                    indexDic.Add(classifierSetting[i].ClassifyName, i);
                }
            }

            // 有効なデータがないなら
            if ( ComboBoxClassify.Items.Count == 0 )
            {
                MessageBox.Show($"エラー: 有効な設定がありません。\r\n詳細: 設定画面で有効な分類データを作成してください。", "設定エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // 画面を破棄
                this.Close();
                return;
            }

            // DrawItemイベントを設定
            ComboBoxClassify.DrawItem += ComboBox_DrawItem;

            // フォーカスする。
            ComboBoxClassify.Focus();
        }

        /// <summary>
        /// OKボタンを押されたら分類を実行する。<br/>
        /// もし置き換え文字列が必要ならテキストボックスを出す。
        /// 置き換え文字列が必要な場合は置き換え文字列を得るためにテキストボックスを出す。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectButton_Click(object sender, System.EventArgs e)
        {
            string newFilePath;

            int selectIndex = ComboBoxClassify.SelectedIndex < 0 ? 0 : ComboBoxClassify.SelectedIndex;
            int index = indexDic[(string)ComboBoxClassify.SelectedItem];

            // テキストボックスがない場合。
            if ( textBoxClassify.Enabled == false )
            {
                // 選ばれてなければゼロで。
                // あるいは選択してくださいってダイアログ出すか？


                ClassifierData useData = classifierSetting[index];

                // ほんとにこれでいいか確認をする。
                // ダメなら戻る。
                if ( ClassifyManager.MyDialogBox(this, $"分類設定：{ComboBoxClassify.Items[index].ToString()} を選択してよろしいですか？", "分類設定確認", MessageBoxButtons.OKCancel) == false )
                {
                    ComboBoxClassify.Focus();
                    return;
                }

                // 拡張子ごとの設定を取る。
                ClassifySettingData exSetting = useData.ReturnSetting((int)useExtension);

                string fileName = Path.GetFileName(usePath);

                bool isNameUse = exSetting.IsOriginalFileNameReplace(fileName);

                // 置き換えを使う場合はテキストボックスを出す。
                if ( exSetting.UseReplace || isNameUse )
                {
                    // コンボボックス隠して
                    ComboBoxClassify.Enabled = false;
                    ComboBoxClassify.Visible = false;
                    textBoxClassify.Enabled = true;
                    textBoxClassify.Visible = true;
                    textBoxClassify.Focus();

                    // 元のファイル名を使用するなら置き換え文字列ボックスに入れる。
                    if ( isNameUse )
                    {
                        textBoxClassify.Text = Path.GetFileNameWithoutExtension(usePath);
                    }

                    // 説明も切り替える。
                    labelDescription.Text = "置き換える文字を入力してください。";
                    return;
                }

                // ファイル名、置き換え文字列、拡張子ごとのファイルパスを送る。
                // パスと結合したファイル名が返ってくる。
                newFilePath = exSetting.ReturnFileName(fileName, string.Empty, useData.ExSetting[0].ExtensionFilePath);

            }
            else
            {

                ClassifierData useData = classifierSetting[index];

                // 拡張子ごとの設定を取る。
                ClassifySettingData exSetting = useData.ReturnSetting((int)useExtension);

                // ファイル名、置き換え文字列、拡張子ごとのファイルパスを送る。
                // パスと結合したファイル名が返ってくる。
                // 置き換え文字にはここで入力したテキストを入れる。
                newFilePath = exSetting.ReturnFileName(Path.GetFileName(usePath), textBoxClassify.Text, useData.ExSetting[0].ExtensionFilePath);
            }

            try
            {
                // 分類設定でファイルを移動
                File.Move(usePath, newFilePath);

                // ここの改行は定数にしてプラットフォームごとに変えるべきかも。
                ClassifyManager.MyDialogBox(this, $"ファイル分類が完了しました。 \r\n移動先：{newFilePath}", "分類成功");
            }
            // 移動先が存在しないときのエラー処理。
            // ダイアログでも出すか。
            catch ( DirectoryNotFoundException ex )
            {
                ClassifyManager.MyDialogBox(this, $"エラー: 移動先のディレクトリが見つかりません。\r\n詳細: {ex.Message}", "移動先パスエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // 画面を破棄しないといけないのでここでは普通に例外処理。
                this.Close();
            }
        }

        /// <summary>
        /// カスタムの描画処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            // アイテムが無効な場合は戻る
            if ( e.Index < 0 )
                return;

            // アイテムのテキストを取得
            string itemText = ComboBoxClassify.Items[e.Index].ToString();

            // 背景を描画
            e.DrawBackground();

            // フォントサイズの調整
            float maxWidth = ComboBoxClassify.Width - 20; // コンボボックスの幅から余白を引く
            float fontSize = 20f; // 初期フォントサイズ
            Font tempFont = new Font("Arial", fontSize); // フォントを初期化

            while ( TextRenderer.MeasureText(itemText, tempFont).Width > maxWidth && fontSize > 5 )
            {
                fontSize--; // フォントサイズを小さくする
                tempFont.Dispose(); // 前のフォントを破棄
                tempFont = new Font("Arial", fontSize); // 新しいフォントを作成
            }

            // 最終フォントを使用
            using ( Font itemFont = new Font("Arial", fontSize) )
            {
                Brush textBrush = Brushes.Black; // テキストの色を設定
                                                 // アイテムのテキストを中央に配置して描画
                Rectangle textBounds = new Rectangle(e.Bounds.X, e.Bounds.Y + (e.Bounds.Height - itemFont.Height) / 2, e.Bounds.Width, itemFont.Height);
                e.Graphics.DrawString(itemText, itemFont, textBrush, textBounds.X, textBounds.Y);
            }

            e.DrawFocusRectangle(); // フォーカス矩形を描画（必要な場合）
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
        /// キャンセル処理。
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, System.EventArgs e)
        {
            using ( CancelForm cancelDialog = new CancelForm() )
            {
                // ボタンの位置に出す。
                cancelDialog.StartPosition = FormStartPosition.Manual;

                // ボタンの位置を取得
                Point buttonLocation = buttonCancel.Location;
                // 親フォームの位置を取得
                Point parentLocation = this.Location;

                // 新しいフォームの位置を計算
                cancelDialog.Location = new Point(parentLocation.X + buttonLocation.X, parentLocation.Y + buttonLocation.Y + buttonCancel.Height);
                cancelDialog.TopMost = true;

                DialogResult result = cancelDialog.ShowDialog();

                // OK以外なら画面を閉じる。
                if ( result == DialogResult.Yes || result == DialogResult.No )
                {
                    this.DialogResult = result;
                    // キャンセル表示してね
                    ClassifyManager.MyDialogBox(this, "分類処理をキャンセルしました。", "キャンセル", MessageBoxButtons.OK, icon: MessageBoxIcon.Stop);
                    this.Close();
                }

            }

        }
    }
}