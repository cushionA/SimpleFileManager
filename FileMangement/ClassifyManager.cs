using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace FileClassifier
{
    #region 定義

    /// <summary>
    /// ファイルの拡張子を示す列挙型。<br/>
    /// そのまま文字列にも変換できる。
    /// </summary>
    public enum FileExtension
    {
        /// <summary>
        /// すべてのファイル<br/>
        /// </summary>
        All = 0,

        /// <summary>
        /// テキストファイル
        /// </summary>
        txt,

        /// <summary>
        /// JPEG画像ファイル
        /// </summary>
        jpg,

        /// <summary>
        /// PNG画像ファイル
        /// </summary>
        png,

        /// <summary>
        /// GIF画像ファイル
        /// </summary>
        gif,

        /// <summary>
        /// BMP画像ファイル
        /// </summary>
        bmp,

        /// <summary>
        /// TIFF画像ファイル
        /// </summary>
        tiff,

        /// <summary>
        /// PDFファイル
        /// </summary>
        pdf,

        /// <summary>
        /// Microsoft Word文書
        /// </summary>
        docx,

        /// <summary>
        /// Microsoft Excelスプレッドシート
        /// </summary>
        xlsx,

        /// <summary>
        /// Microsoft PowerPointプレゼンテーション
        /// </summary>
        pptx,

        /// <summary>
        /// ZIP圧縮ファイル
        /// </summary>
        zip,

        /// <summary>
        /// RAR圧縮ファイル
        /// </summary>
        rar,

        /// <summary>
        /// HTMLファイル
        /// </summary>
        html,

        /// <summary>
        /// CSSファイル
        /// </summary>
        css,

        /// <summary>
        /// JavaScriptファイル
        /// </summary>
        js,

        /// <summary>
        /// CSVファイル
        /// </summary>
        csv,

        /// <summary>
        /// XMLファイル
        /// </summary>
        xml,

        /// <summary>
        /// JSONファイル
        /// </summary>
        json,

        /// <summary>
        /// 音声ファイル（MP3）
        /// </summary>
        mp3,

        /// <summary>
        /// 音声ファイル（WAV）
        /// </summary>
        wav,

        /// <summary>
        /// 動画ファイル（MP4）
        /// </summary>
        mp4,

        /// <summary>
        /// 動画ファイル（AVI）
        /// </summary>
        avi,

        /// <summary>
        /// 動画ファイル（MKV）
        /// </summary>
        mkv,

        /// <summary>
        /// 動画ファイル（MOV）
        /// </summary>
        mov,

        /// <summary>
        /// フォントファイル（TTF）
        /// </summary>
        ttf,

        /// <summary>
        /// フォントファイル（OTF）
        /// </summary>
        otf,

        /// <summary>
        /// バイナリファイル
        /// </summary>
        bin,

        /// <summary>
        /// 設定ファイル（INI）
        /// </summary>
        ini,

        /// <summary>
        /// シェルスクリプト（SH）
        /// </summary>
        sh,

        /// <summary>
        /// バッチファイル（BAT）
        /// </summary>
        bat,

        /// <summary>
        /// アーカイブファイル（TAR）
        /// </summary>
        tar,

        /// <summary>
        /// Gzip圧縮ファイル（GZ）
        /// </summary>
        gz,

        /// <summary>
        /// ISOイメージファイル
        /// </summary>
        iso,

        /// <summary>
        /// Markdownファイル（MD）
        /// </summary>
        md,

        /// <summary>
        /// 仮想ディスクファイル（VMDK）
        /// </summary>
        vmdk,

        /// <summary>
        /// Adobe Illustratorファイル（AI）
        /// </summary>
        ai,

        /// <summary>
        /// Adobe Photoshopファイル（PSD）
        /// </summary>
        psd,

        /// <summary>
        /// プレーンテキストファイル（LOG）
        /// </summary>
        log,

        /// <summary>
        /// スプレッドシート（ODS）
        /// </summary>
        ods,

        /// <summary>
        /// Microsoft Accessデータベース（ACCDB）
        /// </summary>
        accdb,

        /// <summary>
        /// Microsoft Publisherファイル（PUB）
        /// </summary>
        pub,

        /// <summary>
        /// テンプレートファイル（DOTX）
        /// </summary>
        dotx,

        /// <summary>
        /// Apple Pagesファイル（PAGES）
        /// </summary>
        pages,

        /// <summary>
        /// Apple Numbersファイル（NUMBERS）
        /// </summary>
        numbers,

        /// <summary>
        /// Apple Keynoteファイル（KEY）
        /// </summary>
        key,

        /// <summary>
        /// C言語ソースファイル（C）
        /// </summary>
        c,

        /// <summary>
        /// C#言語ソースファイル（C）
        /// </summary>
        cs,
        /// <summary>
        /// C++ソースファイル（CPP）
        /// </summary>
        cpp,

        /// <summary>
        /// Pythonスクリプトファイル（PY）
        /// </summary>
        py,

        /// <summary>
        /// Rubyスクリプトファイル（RB）
        /// </summary>
        rb,

        /// <summary>
        /// PHPスクリプトファイル（PHP）
        /// </summary>
        php,

        /// <summary>
        /// SQLデータベーススクリプトファイル（SQL）
        /// </summary>
        sql,

        /// <summary>
        /// Latexファイル（TEX）
        /// </summary>
        tex,

        /// <summary>
        /// 3Dモデルファイル（OBJ）
        /// </summary>
        obj,

        /// <summary>
        /// 3Dモデルファイル（FBX）
        /// </summary>
        fbx,

        /// <summary>
        /// 圧縮ファイル（7Z）
        /// </summary>
        sevenz,

        /// <summary>
        /// 登録外の拡張子
        /// </summary>
        others
    }

    #endregion 定義

    /// <summary>
    /// アプリで扱うデータを用意するクラス。<br/>
    /// </summary>
    internal static class ClassifyManager
    {

        #region DLLの宣言



        #endregion

        #region コンストラクタ

        /// <summary>
        /// 静的コンストラクタでデータを作成する。
        /// </summary>
        static ClassifyManager()
        {
            // 文字列を列挙子にするDictionaryを作る。
            // othersの分を除いて
            for ( int i = 0; i <= (int)FileExtension.others; i++ )
            {
                FileExtension extension = (FileExtension)i;

                // コンマと結合させて拡張子文字列を作ってキーに。
                fileExtensionConverter.Add($".{extension.ToString()}", extension);
            }

            // 対応する拡張子の数を取得。Others の分を除く
            ExtensionsCount = (int)FileExtension.others - 1;

            // AppDataフォルダのパスを取得。アプリのデータを保存できる場所
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            //string appDataPath = Path.Combine(Application.StartupPath, "AppData");

            // アプリ専用のフォルダ名を指定
            savePath = Path.Combine(appDataPath, appName);

            iconPath = Path.Combine("C:\\Program Files\\zabuton\\SimpleFileManager", "mainIcon.ico");

            // フォルダを作成
            Directory.CreateDirectory(savePath);

            // 分類データ配列を初期化
            classifierDataArray = new ClassifierData[maxClassifyCount];

            // シングルトンの初期化
            watchController = new FileWatchController();

        }

        #endregion

        #region アプリの定数

        #region public定数

        /// <summary>
        /// アプリケーション名。
        /// </summary>
        public const string appName = "SimpleFileManager";

        /// <summary>
        /// 日本語チェックの正規表現に使う。
        /// </summary>
        public const string JapaneseRegex = @"[\u3040-\u309F\u30A0-\u30FF\u4E00-\u9FAF]";

        /// <summary>
        /// 対応している拡張子の数。
        /// すなわち拡張子の列挙子の数(から Allと othersを引いた数)
        /// </summary>
        public static readonly int ExtensionsCount;

        /// <summary>
        /// 拡張子の説明文字列。
        /// </summary>
        public static readonly Dictionary<FileExtension, string> exDescriptions = new Dictionary<FileExtension, string>
    {
        { FileExtension.All, "すべてのファイル" },
        { FileExtension.txt, "テキストファイル" },
        { FileExtension.jpg, "JPEG画像ファイル" },
        { FileExtension.png, "PNG画像ファイル" },
        { FileExtension.gif, "GIF画像ファイル" },
        { FileExtension.bmp, "BMP画像ファイル" },
        { FileExtension.tiff, "TIFF画像ファイル" },
        { FileExtension.pdf, "PDFファイル" },
        { FileExtension.docx, "Microsoft Word文書" },
        { FileExtension.xlsx, "Microsoft Excelスプレッドシート" },
        { FileExtension.pptx, "Microsoft PowerPointプレゼンテーション" },
        { FileExtension.zip, "ZIP圧縮ファイル" },
        { FileExtension.rar, "RAR圧縮ファイル" },
        { FileExtension.html, "HTMLファイル" },
        { FileExtension.css, "CSSファイル" },
        { FileExtension.js, "JavaScriptファイル" },
        { FileExtension.csv, "CSVファイル" },
        { FileExtension.xml, "XMLファイル" },
        { FileExtension.json, "JSONファイル" },
        { FileExtension.mp3, "音声ファイル（MP3）" },
        { FileExtension.wav, "音声ファイル（WAV）" },
        { FileExtension.mp4, "動画ファイル（MP4）" },
        { FileExtension.avi, "動画ファイル（AVI）" },
        { FileExtension.mkv, "動画ファイル（MKV）" },
        { FileExtension.mov, "動画ファイル（MOV）" },
        { FileExtension.ttf, "TrueTypeフォントファイル" },
        { FileExtension.otf, "OpenTypeフォントファイル" },
        { FileExtension.bin, "バイナリファイル" },
        { FileExtension.ini, "設定ファイル（INI）" },
        { FileExtension.sh, "シェルスクリプト（SH）" },
        { FileExtension.bat, "バッチファイル（BAT）" },
        { FileExtension.tar, "アーカイブファイル（TAR）" },
        { FileExtension.gz, "Gzip圧縮ファイル（GZ）" },
        { FileExtension.iso, "ISOイメージファイル" },
        { FileExtension.md, "Markdownファイル（MD）" },
        { FileExtension.vmdk, "仮想ディスクファイル（VMDK）" },
        { FileExtension.ai, "Adobe Illustratorファイル（AI）" },
        { FileExtension.psd, "Adobe Photoshopファイル（PSD）" },
        { FileExtension.log, "ログファイル（LOG）" },
        { FileExtension.ods, "OpenDocumentスプレッドシート（ODS）" },
        { FileExtension.accdb, "Microsoft Accessデータベース（ACCDB）" },
        { FileExtension.pub, "Microsoft Publisherファイル（PUB）" },
        { FileExtension.dotx, "Wordテンプレートファイル（DOTX）" },
        { FileExtension.pages, "Apple Pagesファイル（PAGES）" },
        { FileExtension.numbers, "Apple Numbersファイル（NUMBERS）" },
        { FileExtension.key, "Apple Keynoteファイル（KEY）" },
        { FileExtension.c, "C言語ソースファイル（C）" },
        { FileExtension.cpp, "C++ソースファイル（CPP）" },
        { FileExtension.py, "Pythonスクリプトファイル（PY）" },
        { FileExtension.rb, "Rubyスクリプトファイル（RB）" },
        { FileExtension.php, "PHPスクリプトファイル（PHP）" },
        { FileExtension.sql, "SQLデータベーススクリプトファイル（SQL）" },
        { FileExtension.tex, "LaTeXファイル（TEX）" },
        { FileExtension.obj, "3Dモデルファイル（OBJ）" },
        { FileExtension.fbx, "3Dモデルファイル（FBX）" },
        { FileExtension.sevenz, "7-Zip圧縮ファイル（7Z）" },
            {FileExtension.others, "ソフトが対応していない拡張子のファイル"  }
    };

        /// <summary>
        /// 一時ファイルの拡張子を除外するためのハッシュセット。
        /// </summary>
        public static HashSet<string> tempExcludeHash = new HashSet<string>
{
    // 一般的な一時ファイル拡張子
    ".tmp", ".swp", ".bak", ".~*", ".crdownload", ".part", ".lock",

    // その他の拡張子 (ご自身の環境に合わせて追加)
    ".psd.tmp", ".xcf.tmp", ".avi.tmp", ".mp4.tmp", ".zip.part",

    // ブラウザ関連
    ".download", // その他のブラウザで利用される一時ファイル

    // 特定のアプリケーションで生成される一時ファイル
    // 例: Adobe製品
    ".idlk", ".tmp", // InDesign
    ".ps", // Photoshop

    // その他、ご自身の環境でよく見かける一時ファイル拡張子
};

        /// <summary>
        /// アイコンのパス
        /// </summary>
        public static readonly string iconPath;

        /// <summary>
        /// 追加できる監視パスの数。
        /// </summary>
        public static int exPathLimit = 20;



        #region toolTip設定。

        /// <summary>
        /// 表示されるまでの時間。<br/>
        /// 0.8秒
        /// </summary>
        public const int ttInitialDelay = 800;

        /// <summary>
        /// 別のコントロールにカーソルが移動した時、そのTTが表示されるまでの時間。<br/>
        /// 0.6秒
        /// </summary>
        public const int ttReshowDelay = 600;

        #endregion

        #region メッセージボックス

        public const uint MB_OK = 0x00000000;
        public const uint MB_OKCANCEL = 0x00000001;

        #endregion

        #endregion

        #region private定数

        /// <summary>
        /// アプリデータを保存するパス
        /// </summary>
        private static readonly string savePath;

        /// <summary>
        /// 分類データの数の上限
        /// </summary>
        private static readonly int maxClassifyCount = 10;


        /// <summary>
        /// 拡張子文字列から本アプリケーションで利用できる列挙型データに変換する。<br/>
        /// GetExtensionByStr() メソッドからしかアクセスはしない。
        /// </summary>
        private static readonly Dictionary<string, FileExtension> fileExtensionConverter = new Dictionary<string, FileExtension>();

        #endregion

        #endregion

        #region シングルトン

        /// <summary>
        /// 監視用のコントローラー
        /// </summary>
        public static FileWatchController watchController;

        #endregion シングルトン

        #region  アプリ設定データ

        /// <summary>
        /// 分類設定データ。<br/>
        /// 最初に読み込んで、最後に保存する。
        /// </summary>
        //public static ClassifierDataCollection classifyDataBox;
        public static ClassifierData[] classifierDataArray;

        /// <summary>
        /// アプリの挙動の設定データ。
        /// </summary>
        public static AppSettingData appSetting;

        #endregion アプリ設定データ

        #region 保存関連メソッド

        /// <summary>
        /// 外部から読んでデータを用意する。
        /// </summary>
        public static void LoadData()
        {
            // データをロード。
            LoadAllClassifyData();
            LoadAppSetting();
        }

        #region 分類データの読み書き

        /// <summary>
        /// 分類データの保存の実行メソッド。<br/>
        /// </summary>
        /// <param name="index">セーブするデータの番号</param>
        /// <param name="serializer">nullでなければ新規作成。使いまわせるようにする。</param>
        public static void ClassifyDataSave(int index, XmlSerializer serializer = null)
        {
            if ( serializer == null )
            {
                serializer = new XmlSerializer(typeof(ClassifierData));
            }

            using ( StreamWriter writer = new StreamWriter(Path.Combine(savePath, $"classifyData{index}.xml")) )
            {
                try
                {
                    classifierDataArray[index].isInitialize = true;
                    serializer.Serialize(writer, classifierDataArray[index]);
                }
                catch ( DirectoryNotFoundException ex )
                {
                    System.Windows.Forms.MessageBox.Show($"エラー: 保存先のディレクトリが見つかりません。詳細: {ex.Message}", "ディレクトリ未発見", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // エラー出して終了。
                catch ( IOException ex )
                {
                    System.Windows.Forms.MessageBox.Show($"エラー: 入出力エラーが発生しました。詳細: {ex.Message}", "入出力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }

            }
        }

        /// <summary>
        /// 現状の分類データを全部保存する。
        /// </summary>
        private static void SaveAllClassifyData()
        {

            XmlSerializer serializer = new XmlSerializer(typeof(ClassifierData));

            for ( int i = 0; i < classifierDataArray.Length; i++ )
            {
                ClassifyDataSave(i, serializer);
            }
        }

        /// <summary>
        /// 分類データをロードする。
        /// </summary>
        /// <returns></returns>
        private static void LoadAllClassifyData()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ClassifierData));

            // 分類データを全部ロードする。
            for ( int i = 0; i < maxClassifyCount; i++ )
            {
                ClassifyDataLoad(i, serializer);
            }
        }

        /// <summary>
        /// 分類データのロードの実行メソッド。<br/>
        /// </summary>
        /// <param name="index">ロードするデータの番号</param>
        /// <param name="serializer">nullでなければ新規作成。使いまわせるようにする。</param>
        public static void ClassifyDataLoad(int index, XmlSerializer serializer = null)
        {
            if ( serializer == null )
            {
                serializer = new XmlSerializer(typeof(ClassifierData));
            }
            string xmlPath = Path.Combine(savePath, $"classifyData{index}.xml");

            // ロード対象の配列要素の参照を取得する。
            ClassifierData loadData;

            // xmlファイルがあるなら読み込む
            if ( File.Exists(xmlPath) )
            {
                // ファイル読み込みが失敗した場合の例外設定。
                try
                {
                    using ( StreamReader reader = new StreamReader(Path.Combine(savePath, xmlPath)) )
                    {
                        loadData = (ClassifierData)serializer.Deserialize(reader);
                    }
                }
                catch ( IOException ex )
                {
                    System.Windows.Forms.MessageBox.Show($"エラー: 分類データの読み込みエラーが発生しました。詳細: {ex.Message}", "入出力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loadData = null;
                }
            }
            else
            {
                // 新しい分類データオブジェクトを作成
                loadData = new ClassifierData(index);
            }

            // ここでNullなら新しく作る。
            if ( loadData == null )
            {
                // 新しい分類データオブジェクトを作成
                loadData = new ClassifierData(index);

                loadData.isInitialize = false;

                // XMLファイルとしてシリアライズして保存
                using ( StreamWriter writer = new StreamWriter(xmlPath) )
                {
                    // streamWriterで書きこめば作れる。
                    serializer.Serialize(writer, loadData);
                }
            }

            classifierDataArray[index] = loadData;

        }


        #endregion 分類データの保存

        #region アプリ設定データの保存メソッド

        /// <summary>
        /// 現状の分類データを保存する。<br/>
        /// アプリ終了前、あと編集したら絶対に呼ぶ。
        /// </summary>
        public static void SaveAppSettingData()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(AppSettingData));

            using ( StreamWriter writer = new StreamWriter(Path.Combine(savePath, "settingData.xml")) )
            {
                serializer.Serialize(writer, appSetting);
            }
        }

        /// <summary>
        /// 分類データをロードする。
        /// </summary>
        private static void LoadAppSetting()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(AppSettingData));

            string xmlPath = Path.Combine(savePath, "settingData.xml");

            appSetting = null;

            // xmlファイルがあるなら読み込む
            if ( File.Exists(xmlPath) )
            {
                // ファイル読み込みが失敗した場合の例外設定。
                try
                {
                    using ( StreamReader reader = new StreamReader(Path.Combine(savePath, xmlPath)) )
                    {
                        appSetting = (AppSettingData)serializer.Deserialize(reader);
                    }
                }
                catch ( IOException ex )
                {
                    System.Windows.Forms.MessageBox.Show($"エラー: アプリ設定の読み込みエラーが発生しました。詳細: {ex.Message}", "入出力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    appSetting = null;
                }
            }

            // ここでNullなら新しく作る。
            if ( appSetting == null )
            {
                // 新しいAppSettingDataオブジェクトを作成
                appSetting = new AppSettingData();

                // XMLファイルとしてシリアライズして保存
                using ( StreamWriter writer = new StreamWriter(xmlPath) )
                {
                    // streamWriterで書きこめば作れる。
                    serializer.Serialize(writer, appSetting);
                }
            }
        }

        #endregion アプリ設定データの保存メソッド

        #endregion 保存関連メソッド

        #region 拡張子関連の処理

        /// <summary>
        /// 拡張子の文字列から、このアプリの対応拡張子としてのデータを獲得する。
        /// </summary>
        /// <param name="exStr">拡張子の文字列</param>
        /// <returns>拡張子データ</returns>
        public static FileExtension GetExtensionByStr(string exStr)
        {
            if ( fileExtensionConverter.ContainsKey(exStr) )
            {
                return fileExtensionConverter[exStr];
            }
            else
            {
                return FileExtension.others;
            }
        }

        #endregion

        #region 汎用メソッド

        /// <summary>
        /// 何かの処理をやる時、本当にそれでいいかを確認する。
        /// </summary>
        /// <param name="selectIndex"></param>
        /// <returns></returns>
        public static bool MyDialogBox(Form parent, string message, string caption, MessageBoxButtons type = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Question)
        {

            // ダイアログボックスの表示
            DialogResult result = MessageBox.Show(parent, message, caption, type, icon);

            // ユーザーの選択に応じた処理
            if ( result == DialogResult.OK || result == DialogResult.Yes )
            {
                return true;
            }
            else if ( result == DialogResult.No || result == DialogResult.Cancel )
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// ファイルパス取得用メソッド。
        /// </summary>
        /// <param name="initialPath">最初に画面で開くパス</param>
        /// <returns>string:選択されたファイルのフルパス キャンセル時はEmpty</returns>
        public static string SelectPathDialog()
        {
            string path = string.Empty;

            // フォルダ選択ダイアログを作成
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "選択したいフォルダを指定してください";

            // ダイアログを表示し、ユーザーがOKを押した場合
            if ( dialog.ShowDialog() == DialogResult.OK )
            {
                path = dialog.SelectedPath;

            }

            // 有効なパスならパスにする。
            if ( Directory.Exists(path) )
            {
                // 選択されたフォルダのパスを使用
                System.Windows.Forms.MessageBox.Show("選択されたフォルダ: " + path);
                return path;
            }


            // 選択されたフォルダのパスがない場合
            System.Windows.Forms.MessageBox.Show("選択されたフォルダは存在しません: " + path);
            return string.Empty;
        }



        #endregion 汎用メソッド

    }
}
