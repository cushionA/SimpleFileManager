using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace FileClassifier
{
    #region 定義

    /// <summary>
    /// ファイル名をどう使うか。
    /// </summary>
    public enum FileNameSetting
    {
        /// <summary>
        /// 元のファイル名を使わない。
        /// </summary>
        使用しない,

        /// <summary>
        /// デフォルト名の前につける。
        /// </summary>
        前につける,

        /// <summary>
        /// デフォルト名の後につける。
        /// </summary>
        後につける,

        /// <summary>
        /// 置き換え文字列にする。
        /// </summary>
        置き換え文字列にする,

        /// <summary>
        /// 全部使う。
        /// </summary>
        そのまま使用する
    }

    /// <summary>
    /// 日付使用設定。
    /// </summary>
    public enum DateUseSetting
    {
        使用しない,
        年のみ使用,
        年月を使用,
        年月日を使用
    }


    /// <summary>
    /// 分類の設定データ。<br/>
    /// 拡張子ごとに保持できる。拡張子ごとに保存パス指定できるようにする？
    /// 対応してない拡張子のデータはAllでやるか。
    /// </summary>
    [Serializable]
    public class ClassifySettingData
    {
        /// <summary>
        /// ファイルのデフォルト名。<br/>
        /// もしこれが入れられてない場合は分類名で。
        /// </summary>
        public string DefaultName { get; set; }

        /// <summary>
        /// 置き換え文字列。<br/>
        /// ＠を置いた場所に挿入される。
        /// </summary>
        public string ReplaceString { get; set; }

        /// <summary>
        /// 元のファイル名をどう使うか。
        /// </summary>
        public FileNameSetting NameSetting { get; set; }

        /// <summary>
        /// 置き換え文字を入力するかどうか。<br/>
        /// ファイル名の置き換えとは競合しちゃうな。<br/>
        /// </summary>
        public bool UseReplace { get; set; }

        /// <summary>
        /// 日本語のファイル名だった場合のみファイル名使用設定を適用する。
        /// </summary>
        public bool IsJapaneseNameUse { get; set; }

        /// <summary>
        /// 今日の日付をファイル名の最後に入れるか。
        /// </summary>
        public DateUseSetting UseDateSetting { get; set; }

        /// <summary>
        /// 特定の拡張子でのみ使うファイルパス。<br/>
        /// 入れなければない。
        /// </summary>
        public string ExtensionFilePath { get; set; }

        /// <summary>
        /// 全体設定の保存パスを使うかどうか。<br/>
        /// </summary>
        public bool UseAllPath { get; set; }

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public ClassifySettingData() { }

        /// <summary>
        /// コンストラクタではデフォルトのファイル名を設定する。<br/>
        /// 拡張子情報が all の場合は分類名だけ。
        /// </summary>
        public ClassifySettingData(string classifyName, int extension)
        {
            if ( extension == 0 )
            {
                DefaultName = $"{classifyName}_ファイル";
            }
            else
            {
                FileExtension ex = (FileExtension)extension;

                // 列挙子と分類名を混ぜたデフォルトのファイル名にする。
                DefaultName = $"{classifyName}_{ex.ToString()}";
            }

        }

        public bool IsOriginalFileNameReplace(string fileName)
        {
            if ( NameSetting == FileNameSetting.置き換え文字列にする )
            {
                if ( IsJapaneseNameUse )
                {
                    return Regex.IsMatch(fileName, ClassifyManager.JapaneseRegex, RegexOptions.ECMAScript);
                }
                return true;
            }

            return false;
        }

        /// <summary>
        /// この設定を使用してリネームしたファイル名を返す。
        /// </summary>
        /// <param name="fileName">元のファイル名。拡張子を除く</param>
        /// <returns>新規ファイル名</returns>
        public string ReturnFileName(string fileName, string replaceStr, string allPath)
        {
            // 全体パスを使うか、そして全体パスが存在するかどうかで処理が分岐
            string filePath = UseAllPath && !string.IsNullOrEmpty(allPath) ? allPath : ExtensionFilePath;

            StringBuilder builder = new StringBuilder();

            // ファイル名を使わないか、置き換え文字列があるか、ファイル名が日本語じゃないなら使わない場合。
            if ( !String.IsNullOrEmpty(replaceStr) )
            {
                builder.Append(DefaultName);
                builder.Replace("@", replaceStr);
            }
            else if ( NameSetting == FileNameSetting.使用しない || (IsJapaneseNameUse && !Regex.IsMatch(fileName, ClassifyManager.JapaneseRegex, RegexOptions.ECMAScript)) )
            {
                builder.Append(DefaultName);

            }
            else
            {
                if ( NameSetting == FileNameSetting.置き換え文字列にする )
                {
                    builder.Append(DefaultName);

                    // ファイルの置き換え文字を置き換える。
                    // 任意で置き換え文字を入力できるオプションはどうする。
                    // 置き換え文字は設定できるようにする？
                    builder.Replace("@", Path.GetFileNameWithoutExtension(fileName));

                }
                else if ( NameSetting == FileNameSetting.後につける )
                {
                    builder.Append(DefaultName);
                    builder.Append(Path.GetFileNameWithoutExtension(fileName));
                }
                else if ( NameSetting == FileNameSetting.前につける )
                {
                    builder.Append(Path.GetFileNameWithoutExtension(fileName));
                    builder.Append(DefaultName);
                }
                else if ( NameSetting == FileNameSetting.そのまま使用する )
                {
                    builder.Append(Path.GetFileNameWithoutExtension(fileName));
                }
            }

            // 今の日付を末尾に使うか
            if ( UseDateSetting != DateUseSetting.使用しない )
            {
                builder.Append("_");

                if ( UseDateSetting == DateUseSetting.年のみ使用 )
                {
                    builder.Append(DateTime.Now.ToString("yyyy年"));
                }
                else if ( UseDateSetting == DateUseSetting.年月を使用 )
                {
                    builder.Append(DateTime.Now.ToString("yyyy年MM月"));
                }
                else if ( UseDateSetting == DateUseSetting.年月日を使用 )
                {
                    builder.Append(DateTime.Now.ToLongDateString());
                }
            }

            // 残ってる@は消す
            builder.Replace("@", string.Empty);

            // 保存予定パスを作成して既に存在するかチェック。
            String path = $"{filePath}\\{builder}";
            string extension = Path.GetExtension(fileName);

            // 既にファイル名が存在してるなら
            if ( File.Exists($"{path}{extension}") )
            {
                int index = 0;

                // 同名のファイルが存在する限り、数字を追加して新しいファイル名を生成
                while ( true )
                {
                    index++;

                    // 存在しない名前を見つけたら終わり。
                    if ( !File.Exists($"{path}_{index}{extension}") )
                    {
                        // 拡張子も加える
                        builder.Append($"_{index}");
                        break;
                    }
                }
            }

            builder.Append(extension);



            // 作成した名前を返す
            return Path.Combine(filePath, builder.ToString());
        }

    }

    #endregion 定義

    /// <summary>
    /// 分類データ。<br/>
    /// 指定されたファイルを分類して配置しなおすためのデータ。<br/>
    /// 基本的にはあるファイルを移動させる、という挙動を担保する。<br/>
    /// ダウンロードで追加されたファイル以外にも任意で実行できるように。<br/>
    /// 基本的にこいつは十個までしか作れんようにする？
    /// </summary>
    [XmlRoot("ClassifierData")]
    [Serializable]
    public class ClassifierData
    {
        /// <summary>
        /// 分類につける名称。<br/>
        /// 画面に表示される。
        /// </summary>
        public string ClassifyName { get; set; }

        /// <summary>
        /// 分類のID。<br/>
        /// ソートに利用する。<br/>
        /// </summary>
        public int ClassifyID { get; set; }

        /// <summary>
        /// どの拡張子の設定が有効なのかを設定するビット演算用。
        /// </summary>
        public ulong ExtensionsBit { get; set; }

        /// <summary>
        /// 拡張子ごとに設定を持つ。<br/>
        /// でもインスタンスを作成するのはその設定が参照された時か、設定画面を開いた時。
        /// </summary>
        public ClassifySettingData[] ExSetting { get; set; }

        /// <summary>
        /// 初期化済みか、というフラグ。
        /// セーブ時に真になる。
        /// </summary>
        public bool isInitialize { get; set; }

        /// <summary>
        /// IDだけ入れてデフォルトの状態にする。
        /// </summary>
        /// <param name="ID">何番目の分類データかということ</param>
        public ClassifierData(int id)
        {
            // 初期設定
            ClassifyName = $"分類設定{id}";
            ClassifyID = id;

            // otherの分も加えてやる
            ExSetting = new ClassifySettingData[ClassifyManager.ExtensionsCount + 1];

            // allの設定データだけ作成する。
            ExSetting[0] = new ClassifySettingData(ClassifyName, 0);
            ExtensionsBit = 0;
            ExSetting[0].ExtensionFilePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
        }

        public ClassifierData()
        {

        }

        /// <summary>
        /// 対応する拡張子のボタンが押された時に設定の有効/無効を切り替える。<br/>
        /// all の設定は変えられない。というかボタンを用意しないまず。ボタンにバインドするのは1からにしよう。
        /// </summary>
        public void UpdateExtensionsSetting(bool isEnable, int targetBit)
        {
            // 有効化する。
            if ( isEnable )
            {
                ExtensionsBit |= ((ulong)1 << targetBit);
            }
            // 反転ビットと&演算子で特定のビットフラグを消す。
            else
            {
                ExtensionsBit &= ~((ulong)1 << targetBit);
            }
        }

        /// <summary>
        /// ある拡張子の設定が有効であればその設定を返す。<br/>
        /// そうでなければ all を返す。
        /// </summary>
        /// <param name="targetBit">対象になる拡張子のビットフラグの番号。0以上で頼む</param>
        /// <returns>設定データ。</returns>
        public ClassifySettingData ReturnSetting(int targetBit)
        {
            // ある拡張子のビットフラグが無効、または0(all)なら全体設定を返す。
            if ( targetBit == 0 || (ExtensionsBit & ((ulong)1 << targetBit)) == 0 )
            {
                return ExSetting[0];
            }

            // 有効なら該当する拡張子の設定を返す。
            else
            {
                // もしまだデータがなければ作成してから返すように。
                if ( ExSetting[targetBit] == null )
                {
                    ExSetting[targetBit] = new ClassifySettingData(ClassifyName, targetBit);
                }

                return ExSetting[targetBit];

            }
        }

    }
}
