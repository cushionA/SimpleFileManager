using AtCoder;
using AtCoder.Internal;
using Kzrnm.Competitive.IO;
using MyAtCorderLibrary.Graph;
using System;
using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Numerics;
using MyAtCorderLibrary;

/// <summary>
/// 自作ライブラリの引用し忘れ、名前空間のセットを忘れずに。
/// いやなるべくライブラリでは完全修飾するか？
/// </summary>
internal static class Program
{
    private static void Main(string[] args)
    {
        SourceExpander.Expander.Expand();

        ConsoleWriter writer = new ConsoleWriter();
        ConsoleReader reader = new ConsoleReader();

        int n = reader.Int();

        int[] toys = new int[n];
        int[] boxes = new int[n - 1];
        bool[] boxUse = new bool[n - 1];

        for ( int i = 0; i < toys.Length; i++ )
        {
            toys[i] = reader.Int();
        }

        for ( int i = 0; i < boxes.Length; i++ )
        {
            boxes[i] = reader.Int();
        }

        Array.Sort(boxes);
        Array.Sort(toys);

        int outItem = -1;

        for ( int i = 0; i < toys.Length; i++ )
        {
            int index = Array.BinarySearch(boxes, toys[n - 1 - i]);

            if ( index < 0 )
            {
                index = ~index;
                if ( index == n - 1 )
                {
                    if ( outItem == -1 )
                    {
                        outItem = toys[n - 1 - i];
                        continue;
                    }
                    else
                    {
                        writer.WriteLine(-1);
                        writer.Flush();
                        return;
                    }
                }
            }





            if ( boxUse[index] == false )
            {
                boxUse[index] = true;
            }
            else
            {
                Span<bool> use = boxUse.AsSpan().Slice(index);

                int o = use.Length - 1;
                bool isFind = false;
                for ( int s = 0; s < use.Length; s++ )
                {
                    if ( use[o - s] == false )
                    {
                        use[o - s] = true;
                        isFind = true;
                        break;
                    }
                }

                if ( !isFind )
                {

                    if ( outItem == -1 )
                    {
                        outItem = toys[n - 1 - i];
                    }
                    else
                    {
                        writer.WriteLine(-1);
                        writer.Flush();
                        return;
                    }

                }
            }




        }



        writer.WriteLine(outItem);

        writer.Flush();
    }



}


