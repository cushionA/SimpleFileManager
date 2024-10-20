using Kzrnm.Competitive.IO;
using MyAtCorderLibrary.Graph;
internal static class Program
{
    /// <summary>
    /// https://atcoder.jp/contests/typical90/tasks/typical90_m
    /// 無向グラフで 頂点0からk 頂点kからn-1 と、頂点k(0≦k≦N-1）を経由したパスを求める問題。<br/>
    /// 無向グラフでは kからn-1とn-1からkの距離は同じなので、頂点0から全頂点、頂点n-1から全頂点への距離を求めることで簡単に求められる。
    /// </summary>
    /// <param name="args"></param>
    private static void SimpleGraphExample(string[] args)
    {
        SourceExpander.Expander.Expand();

        ConsoleWriter writer = new ConsoleWriter();
        ConsoleReader reader = new ConsoleReader();

        int n = reader.Int();
        int m = reader.Int();

        SimpleGraph<int> graph = new SimpleGraph<int>(true, n);

        for ( int i = 0; i < m; i++ )
        {
            int s = reader.Int() - 1;
            int t = reader.Int() - 1;
            int d = reader.Int();

            graph.AddEdge(s, t, d);
        }

        Span<int> toN = graph.GetMinPathToAllVertex(0);
        Span<int> toZero = graph.GetMinPathToAllVertex(n - 1);

        for ( int i = 0; i < n; i++ )
        {
            writer.WriteLine(toN[i] + toZero[i]);
        }

        writer.Flush();
    }



}

