using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Markup;
using System.Xml.Linq;

namespace FileClassifier
{
    /// <summary>
    /// UserControl1.xaml の相互作用ロジック<br/>
    /// 
    /// 分類設定をする画面。<br></br>
    /// 必要な要素は上から
    /// 
    /// 分類名設定テキストボックス＋説明ラベル
    /// 分類使用パス＋説明ラベル（いらなくね？　分類のデフォ設定はALLでやりゃいいじゃん）（具体的な設定は全部拡張子部分でやるか）
    /// 拡張子設定のコンボボックス＋説明ラベル。
    /// 拡張子個別設定の有効/無効のチェックボックス（ALLではつかわない）
    /// 拡張子ごとの設定（ファイルのデフォルト名、元ファイル名をどう使うか、日本語のみ使うか、置き換え文字使うか、）
    /// 
    /// 日本語のみ使うか、はチェックボックス。置き換え文字の設定がオンなら@が置き換えられる。
    /// 
    /// </summary>
    public partial class ClassifySettingWindow : SettingTemp
    {

        /// <summary>
        /// データ設定。
        /// </summary>
        private ClassifierData useData;

        /// <summary>
        /// 現在設定中の分類データが何番目かということ。
        /// </summary>
        private int setDataIndex;

        /// <summary>
        /// useData の中の拡張子設定のどれを使うか、の設定をする。
        /// </summary>
        private int useExIndex;

        /// <summary>
        /// コンストラクタで色々設定。<br/>
        /// した後にInitializeData() を呼び出してやる。<br/>
        /// ユーザーコントロールを生成した後、分類ボタンを切り替えるたびにデータを設定してUIを更新。
        /// </summary>
        public ClassifySettingWindow()
        {
            InitializeComponent();


            SetToolTip(textBoxClassifyName, "分類データの名称を設定する。");
            SetToolTip(comboBoxExtensionSelect, "選択した拡張子、ファイルの種別ごとの設定ができる。\r\nALLは全体設定で、個別設定がない拡張子全般に適用される。");
            SetToolTip(checkBoxUseExtension, "現在の拡張子（ファイル種別）の設定を有効にする。\r\n無効の場合、この種類のファイルに対してはALLの設定が適用される。");
            SetToolTip(textBoxFileName, "デフォルトのファイル名を決定する。\r\nファイルを分類した際、自動でその名前がファイルに設定される。");
            SetToolTip(checkBoxReplaceSetting, "置き換え文字を使用するか。\r\n置き換え文字とは、ファイル名に @ を含めることで、任意の文字列を入力してその@の位置に挿入することができる機能。\r\n例) @サンプル → 置き換えサンプル　「置き換え」と「@」が置き換えられた");
            SetToolTip(textBoxPathDisplay, "選択したフォルダに分類対象のファイルを移動させる。");
            SetToolTip(buttonPathSet, "使用するフォルダを設定するボタン。");
            SetToolTip(checkBoxAllPathSet, "チェックするとALL の設定と同じ場所にファイルを保存する。");
            SetToolTip(comboBoxFileNameHandle, "元のファイル名を分類後の名前にどう組み込むかを設定する。");
            SetToolTip(checkBoxJapaneseCheck, "元のファイル名を分類後のファイル名に組み込む際、日本語を含む名前のみ使用するかを設定する。");
            SetToolTip(comboBoxDateHandle, "今日の日付をファイル名の末尾に組み込むかどうかを設定する。");

            #region コンボボックスのアイテム初期化

            // コンボボックスに列挙子の文字列を入れていく
            ComboBoxEnumSet(comboBoxExtensionSelect, typeof(FileExtension), (int)FileExtension.others);
            ComboBoxEnumSet(comboBoxFileNameHandle, typeof(FileNameSetting), (int)FileNameSetting.そのまま使用する);
            ComboBoxEnumSet(comboBoxDateHandle, typeof(DateUseSetting), (int)DateUseSetting.年月日を使用);

            #endregion コンボボックスのアイテム初期化

            // 最初の分類設定データから見ていく。
            InitializeData(0);
        }


        #region UI操作

        /// <summary>
        /// コンボボックスに列挙型の列挙子のデータを追加してやる。
        /// </summary>
        /// <param name="box"></param>
        /// <param name="type"></param>
        /// <param name="lastValue">最後の要素の値。これに1足すと全体の値に</param>
        private void ComboBoxEnumSet(ComboBox box, Type type, int lastValue)
        {
            lastValue++;

            // 文字列を列挙子にするDictionaryを作る。
            for ( int i = 0; i < lastValue; i++ )
            {
                box.Items.Add(Enum.ToObject(type, i));
            }
        }


        /// <summary>
        /// 分類データ設定ウィンドウを初期化する。<br/>
        /// ユーザーコントロール表示の際と、設定対象分類データの切り替え時に呼ばれる。<br/>
        /// どの分類データを使用するか、を設定しないとダメだね。<br/>
        /// </summary>
        /// <param name="settingIndex">設定インデックス。これでデータを選んで設定する。</param>
        public void InitializeData(int settingIndex)
        {
            // 別のデータを設定する際、今の分類データが変更されているならセーブする。
            // このコントロールを閉じる時にも同様のセーブ処理をする。
            if ( isChange )
            {
                // 変更を適用してセーブ。
                ClassifyManager.classifierDataArray[setDataIndex] = useData;
                ClassifyManager.ClassifyDataSave(setDataIndex);

                isChange = false;
            }

            // 設定データのインデックスを取得。
            setDataIndex = settingIndex;

            // 最初は拡張子データをオールで設定する。
            useData = ClassifyManager.classifierDataArray[settingIndex];

            // 分類データに属する部分をUIに反映する。
            textBoxClassifyName.Text = useData?.ClassifyName;

            // 最初はAll拡張子の設定をする
            comboBoxExtensionSelect.SelectedIndex = 0;

            // 拡張子ごとの設定部分を初期化。
            ChangeSettingExtension((int)FileExtension.All);

        }

        /// <summary>
        /// 設定する拡張子を変更する。<br/>
        /// 基本的に拡張子コンボボックスが切り替わった時のイベントで呼ばれる。
        /// </summary>
        private void ChangeSettingExtension(int newExIndex)
        {
            // 新しい拡張子のデータを設定する。
            useExIndex = newExIndex;

            // 設定がなければ作る。
            if ( useData.ExSetting[useExIndex] == null )
            {
                useData.ExSetting[useExIndex] = new ClassifySettingData(useData.ClassifyName, useExIndex);
            }

            ClassifySettingData exData = useData.ExSetting[useExIndex];


            // 拡張子の設定を反映。
            comboBoxExtensionSelect.SelectedIndex = useExIndex;
            textBoxFileName.Text = exData.DefaultName;

            // ここでチェックされてなくても、ファイル名を置き換え文字列にする場合は置き換え文字列する
            checkBoxReplaceSetting.Checked = exData.UseReplace;

            // コンボボックス。
            comboBoxFileNameHandle.SelectedIndex = (int)exData.NameSetting;
            checkBoxJapaneseCheck.Checked = exData.IsJapaneseNameUse;

            comboBoxDateHandle.SelectedIndex = (int)exData.UseDateSetting;

            // 共通初期化処理。ALLの場合は非表示にするコントロールを入れる。
            bool allEx = useExIndex == (int)FileExtension.All;
            ControlEnableTurn(checkBoxUseExtension, !allEx);
            ControlEnableTurn(checkBoxAllPathSet, !allEx);

            // こいつには拡張子の文字列を入れる。
            // 最初は常にAllから始めるから設定の必要がない。
            // こいつの切り替わりでこのメソッドが動くわけだしな。
            //comboBoxExtensionSelect.SelectedText = 

            // 使用するパス
            textBoxPathDisplay.Text = exData.ExtensionFilePath;

            // 設定が有効か無効かを判断する
            checkBoxUseExtension.Checked = (useData.ReturnSetting(useExIndex) == exData);

            // 何も設定ないならAllから引っ張ってくる。
            textBoxFileName.Text = !string.IsNullOrEmpty(exData.DefaultName) ? exData.DefaultName : useData.ExSetting[(int)FileExtension.All].DefaultName;

            // 置き換え文字を使うかの設定を反映する。
            checkBoxReplaceSetting.Checked = exData.UseReplace;

            //　ファイルパスをテキストボックスに入れる。
            // そもそも編集不能の見せテキストボックスなのでこちらの設定は不要。
            // ボタンの方を切り替えるか。
            // 一応Allの時はこっちにならないようにする
            if ( exData.UseAllPath && newExIndex != 0 )
            {
                checkBoxAllPathSet.Checked = true;

            }
            else
            {
                checkBoxAllPathSet.Checked = false;
            }

            // ファイル名をどう扱うかをUIに反映。
            comboBoxFileNameHandle.SelectedIndex = (int)exData.NameSetting;

            // 日本語のみ使うかどうかを設定に反映。
            checkBoxJapaneseCheck.Checked = exData.IsJapaneseNameUse;

            // 日付の使用設定。
            comboBoxDateHandle.SelectedIndex = (int)exData.UseDateSetting;

        }

        #endregion

        /// <summary>
        /// 閉じる時の処理。
        /// データを保存する。
        /// </summary>
        public override void CloseWindow()
        {

            // 別のデータを設定する際、今の分類データが変更されているならセーブする。
            if ( isChange && SettingDialog("現在の分類設定を保存しますか？") )
            {
                // 変更を適用してセーブ。
                ClassifyManager.classifierDataArray[setDataIndex] = useData;
                ClassifyManager.ClassifyDataSave(setDataIndex);
            }

            base.CloseWindow();
        }

        public override void OpenWindow()
        {
            base.OpenWindow();

            // 分類名のテキストボックスにフォーカスから。
            textBoxClassifyName.Focus();
        }

        /// <summary>
        /// データをセーブする。
        /// </summary>
        public override void SaveSetting()
        {
            // 別のデータを設定する際、今の分類データが変更されているならセーブする。
            if ( isChange && SettingDialog("現在の分類設定を保存しますか？") )
            {
                // 変更を適用してセーブ。
                ClassifyManager.classifierDataArray[setDataIndex] = useData;
                ClassifyManager.ClassifyDataSave(setDataIndex);
            }
            base.SaveSetting();
        }


        #region データ変動イベント

        /// <summary>
        /// 分類名のテキストボックスからフォーカスが離れた場合、分類データに値をセットする。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxClassifyName_Leave(object sender, EventArgs e)
        {
            // もし同じなら値の入れ替え処理はしない。
            if ( useData.ClassifyName == textBoxClassifyName.Text )
            {
                return;
            }

            useData.ClassifyName = textBoxClassifyName.Text;
            isChange = true;
        }

        /// <summary>
        /// 設定拡張子変更イベント。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxExtensionSelect_Changed(object sender, EventArgs e)
        {

            // 設定拡張子変更
            ChangeSettingExtension(comboBoxExtensionSelect.SelectedIndex);
        }

        /// <summary>
        /// 拡張子の有効/無効設定を切り替える。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxUseExtension_Change(object sender, EventArgs e)
        {
            // 有効/無効設定を切り替える。
            useData.UpdateExtensionsSetting(checkBoxUseExtension.Checked, useExIndex);

            isChange = true;
        }

        /// <summary>
        /// デフォルト名が変更された時の処理。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxFileName_Leave(object sender, EventArgs e)
        {
            // もし同じなら値の入れ替え処理はしない。
            if ( useData.ExSetting[useExIndex].DefaultName == textBoxFileName.Text )
            {
                return;
            }

            useData.ExSetting[useExIndex].DefaultName = textBoxFileName.Text;
            isChange = true;
        }

        /// <summary>
        /// 置き換え文字列を使うかどうかの設定。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxReplaceSetting_Changed(object sender, EventArgs e)
        {

            // 設定を切り替える。
            useData.ReturnSetting(useExIndex).UseReplace = checkBoxReplaceSetting.Checked;
            isChange = true;
        }

        /// <summary>
        /// パス設定ボタンから離れた時のイベント。<br/>
        /// ちょっとこのあたりは特殊
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPathSet_Leave(object sender, EventArgs e)
        {
            // もし同じなら値の入れ替え処理はしない。
            // また、ボタンが無効化されてる、つまり全体パス使用設定がオンの時もこのイベントは呼ばない。
            if ( useData.ExSetting[useExIndex].ExtensionFilePath == textBoxPathDisplay.Text || buttonPathSet.Enabled == false )
            {
                return;
            }

            useData.ExSetting[useExIndex].ExtensionFilePath = textBoxPathDisplay.Text;
            isChange = true;
        }

        /// <summary>
        /// 全体パス使用設定が切り替わった際の処理。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxAllPathSet_CheckedChanged(object sender, EventArgs e)
        {
            // 全体パス使用時
            if ( checkBoxAllPathSet.Checked )
            {
                // テキストボックスのパスの表示は変えずにデータだけ入れ替えて、ボタンを無効化
                useData.ExSetting[useExIndex].UseAllPath = true;
            }

            //全体パス仕様解除時
            else
            {
                // テキストボックスの表示パスをデータに戻して、ボタンを有効化
                useData.ExSetting[useExIndex].UseAllPath = false;
            }

            isChange = true;
        }

        /// <summary>
        /// 元のファイルの扱いの設定が変わった時の処理。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxFileNameHandle_Changed(object sender, EventArgs e)
        {

            // 設定変更
            useData.ExSetting[useExIndex].NameSetting = (FileNameSetting)comboBoxFileNameHandle.SelectedIndex;
            isChange = true;
        }

        /// <summary>
        /// ファイル名使用の際に日本語のみ使う設定が変わった時の処理。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxJapaneseCheck_Changed(object sender, EventArgs e)
        {
            // 設定を切り替える。
            useData.ExSetting[useExIndex].IsJapaneseNameUse = checkBoxJapaneseCheck.Checked;
            isChange = true;
        }

        /// <summary>
        /// 日付の扱い設定が切り替わった際の処理。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxDateHandle_Changed(object sender, EventArgs e)
        {
            // 設定変更
            useData.ExSetting[useExIndex].UseDateSetting = (DateUseSetting)comboBoxDateHandle.SelectedIndex;
            isChange = true;
        }

        /// <summary>
        /// ファイルパス設定ボタンが押された時の処理。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPathSet_Click(object sender, EventArgs e)
        {

            // 値がちゃんと帰ってきたときだけ設定する
            string newPath = ClassifyManager.SelectPathDialog();

            if ( newPath != string.Empty )
            {
                // 設定変更
                useData.ExSetting[useExIndex].ExtensionFilePath = newPath;
                textBoxPathDisplay.Text = newPath;
                isChange = true;
            }
        }

        #endregion　データ変動イベント


    }
}
