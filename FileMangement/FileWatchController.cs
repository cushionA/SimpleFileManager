using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileClassifier
{
    /// <summary>
    /// ファイル監視クラス。<br/>
    /// 内部の処理に関わらず、パスの追加と削除という一貫したインターフェイスでファイル監視を行う。</br>
    /// 他OSへの対応や監視処理自体の変更に柔軟にするためにカプセル化
    /// </summary>
    internal class FileWatchController : IDisposable
    {


        #region 監視実行用基底クラス定義

        /// <summary>
        /// 監視用の基底クラス。<br/>
        /// Disposeと監視用メソッドを実装する。<br/>
        /// あとこのFileWatcherへの報告用メソッドもね
        /// </summary>
        public abstract class FileWatcher : IDisposable
        {

            /// <summary>
            /// 監視するフォルダのパス
            /// </summary>
            protected readonly string watchPath;

            /// <summary>
            /// ファイル監視機能のインスタンス。<br/>
            /// 報告のために持ってる。でもシングルトンにするかも。
            /// </summary>
            protected FileWatchController controller;

            /// <summary>
            /// コンストラクタで監視先のパスと、FileWatcherへの参照を受け取る。
            /// </summary>
            public FileWatcher(string path, FileWatchController controller)
            {
                this.watchPath = path;
                this.controller = controller;
            }

            /// <summary>
            /// 監視停止とインスタンス破棄。
            /// 実装を強制。
            /// </summary>
            public abstract void Dispose();

            /// <summary>
            /// ファイルの変更があった時に報告するメソッド。<br/>
            /// 各Watcher側で変更を取得したら呼び出す。
            /// </summary>
            /// <param name="changePath">変更されたファイルのパス</param>
            /// <returns>返り値がtrueなら全キャンセル。</returns>
            protected bool ReportNewFile(string changePath)
            {
                return controller.GetReport(changePath);
            }

        }

        /// <summary>
        /// FileSystemWatcherクラスを利用した実装例。
        /// </summary>
        public class FSEventWatcher : FileWatcher
        {
            /// <summary>
            /// 監視用のイベントハンドラクラスのフィールド
            /// </summary>
            FileSystemWatcher watchHandler;

            #region コンストラクタ

            /// <summary>
            /// コンストラクタで監視イベントを始める。
            /// </summary>
            /// <param name="path"></param>
            /// <param name="controller"></param>
            public FSEventWatcher(string path, FileWatchController controller) : base(path, controller)
            {
                watchHandler = new FileSystemWatcher
                {
                    Path = watchPath,
                    Filter = "*.*",
                    NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite,
                    IncludeSubdirectories = false
                };
                // 監視しているフォルダ（ダウンロード）でファイルが作成されたら発動するイベント。
                watchHandler.Created += OnFileCreated;
                watchHandler.EnableRaisingEvents = true;
            }

            #endregion

            #region publicメソッド

            /// <summary>
            /// 監視を停止してインスタンスを破棄。
            /// </summary>
            public override void Dispose()
            {
                watchHandler.Dispose();
            }

            #endregion

            #region イベントハンドラ用のメソッド

            /// <summary>
            /// ファイルが作られた時、新規ファイルが監視に引っかかった時の処理。<br/>
            /// 拡張子を確認したりする。
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void OnFileCreated(object sender, FileSystemEventArgs e)
            {
                // 移動ファイルを除外する処理
                // 新規作成（ダウンロード）以外は弾く
                if ( e.ChangeType == WatcherChangeTypes.Created )
                {
                    // キャンセルの時、イベントを差し止める？
                    bool isCancel = ReportNewFile(e.FullPath);
                }

            }

            #endregion



        }


        #endregion

        /// <summary>
        /// 0はダウンロード。<br/>
        /// 設定画面で削除・追加する。これに対応する番号としては、1から5を追加パスのコントロールに内部で番号を持たせるか？<br/>
        /// 設定画面から消したり停止させたりできる。
        /// </summary>
        private Dictionary<string, FileWatcher> watchers = new Dictionary<string, FileWatcher>();

        #region Publicメソッド

        /// <summary>
        /// 追加するパス
        /// </summary>
        /// <param name="path"></param>
        public void AddPath(string path)
        {
            // 重複したパスは拒否
            if ( watchers.ContainsKey(path) )
            {
                return;
            }


            // 監視機能インスタンスをプラットフォームなどの条件ごとに作る。
            FileWatcher watcher = null;

            //#if WINDOWS
            // 監視用インスタンスを作成する。
            // WindowsではReadDirectoryChangesW のDLLを利用した監視を行う。
            watcher = new ReadDirectoryWatcher(path, this);
            //#endif

            // インスタンスがなければ無効
            if ( watcher == null )
            {
                return;
            }

            // 監視に追加
            watchers.Add(path, watcher);

        }

        /// <summary>
        /// パスの削除処理
        /// </summary>
        /// <param name="path"></param>
        public void RemovePath(string path)
        {
            // 含んでないパスは拒否
            if ( !watchers.ContainsKey(path) )
            {
                return;
            }

            // 破棄して削除
            watchers[path].Dispose();
            watchers.Remove(path);

        }

        /// <summary>
        /// 全監視オブジェクトをDisposeする
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Dispose()
        {
            foreach ( var watcher in watchers.Values )
            {
                watcher.Dispose();
            }
        }


        #endregion Publicメソッド


        #region privateメソッド


        #region ファイル監視処理


        #region 監視イベント

        /// <summary>
        /// 監視インスタンスからのファイル変更を受け取るメソッド。
        /// </summary>
        /// <param name="createPath">新規作成されたファイルのパス</param>
        /// <returns>返り値が真の時全キャンセル。</returns>
        public bool GetReport(string createPath)
        {
            // 拡張子を取得し、ついでに弾く対象の拡張子であるかを見る。
            FileExtension extension = ClassifyManager.GetExtensionByStr(Path.GetExtension(createPath));

            // アプリの対象外拡張子のファイルを監視しない場合は弾く。
            if ( !ClassifyManager.appSetting.CheckIgnoreEx((int)extension) )
            {
                return false;
            }

            // 分類画面を表示
            using ( ClassificationDialog dialog = new ClassificationDialog(createPath, extension) )
            {
                // ウィンドウをカーソルの位置に近い位置に配置
                // マウスカーソルの位置を取得
                var cursorPosition = Control.MousePosition;
                dialog.StartPosition = FormStartPosition.Manual;
                dialog.Location = new System.Drawing.Point(cursorPosition.X, cursorPosition.Y);

                // モーダルで表示
                // 結果がNoであれば全キャンセル
                return dialog.ShowDialog() == DialogResult.No;
            }
        }

        #endregion 監視イベント

        #endregion

        #endregion



    }
}
