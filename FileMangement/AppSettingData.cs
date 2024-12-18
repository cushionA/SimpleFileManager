using System.Collections.Generic;
using System.Windows.Documents;

namespace FileClassifier
{
    /// <summary>
    /// アプリケーションの挙動を設定するデータ。<br/>
    /// 
    /// けど任意で選択したファイルにも分類をできるように
    /// あとダウンロードフォルダ以外も監視できるようにする。
    /// じどうかんしをオンオフきりかえられるように？　オフの場合は任意起動のファイル分類のみになる。
    /// あと特定の拡張子を無視できるように
    /// 
    /// 拡張子の無視設定は自動監視の場合だけ
    /// 
    /// </summary>
    public class AppSettingData
    {
        /// <summary>
        /// ファイル監視時に無視する拡張子の集合。
        /// ボタンを押すと設定される。
        /// Otherもここでやるかー
        /// </summary>
        /// <summary>
        /// どの拡張子の設定が有効なのかを設定するビット演算用。
        /// </summary>
        public ulong ignoreExtBit { get; set; } = 0;


        /// <summary>
        /// 五個まで追加で監視する、なんらかの出力先パスを記録できる。<br/>
        /// パス設定コントロールの横にパス削除ボタンを置いて空文字列を入れられるように。
        /// </summary>
        public List<string> exWatchPath { get; set; } = new List<string>();

        /// <summary>
        /// ダウンロードを監視するかどうか。
        /// </summary>
        public bool isWatchDL = true;

        /// <summary>
        /// 対応する拡張子のボタンが押された時に設定の有効/無効を切り替える。<br/>
        /// 無視設定をオンにする
        /// all の設定は変えられない。というかボタンを用意しないまず。ボタンにバインドするのは1からにしよう。
        /// </summary>
        /// <param name="isEnable">真なら無視設定をオフにする。押されている状態になる</param>
        /// <param name="targetExtension">無視設定を操作する対象の番号。拡張子の列挙子の値でいいよ</param>
        public void UpdateIgnoreSetting(bool isEnable, int targetExtension)
        {
            // 無視設定有効化する。
            if ( !isEnable )
            {
                ignoreExtBit |= ((ulong)1 << targetExtension);
            }
            // 反転ビットと&演算子で特定のビットフラグを消す。
            else
            {
                ignoreExtBit &= ~((ulong)1 << targetExtension);
            }
        }

        /// <summary>
        /// ある拡張子が無視設定がなければ真を返す<br/>
        /// そうでなければ偽を返す。
        /// </summary>
        /// <param name="targetExtension">対象になる拡張子のビットフラグの番号。0以上で頼む</param>
        /// <returns>設定データ。</returns>
        public bool CheckIgnoreEx(int targetExtension)
        {
            // ある拡張子の無視設定がない、または引数0(ALL)なら無視しない。
            if ( targetExtension == 0 || (ignoreExtBit & ((ulong)1 << targetExtension)) == 0 )
            {
                return true;
            }

            // 有効なら無視する設定がある。
            return false;
        }

    }
}
