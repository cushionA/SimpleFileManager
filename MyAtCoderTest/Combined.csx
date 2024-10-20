using Kzrnm.Competitive.IO;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
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


#region Expanded by https://github.com/kzrnm/SourceExpander
namespace Kzrnm.Competitive.IO{using static Utf8Parser;using M=MethodImplAttribute;using R=ConsoleReader;public class ConsoleReader{protected internal const int BufSize=1<<12;[EditorBrowsable(EditorBrowsableState.Never)]public Stream Input{get;}[EditorBrowsable(EditorBrowsableState.Never)]public Encoding Encoding{get;}internal readonly byte[]buf;internal int pos;internal int len;[M(256)]public ConsoleReader():this(Console.OpenStandardInput(),Console.InputEncoding,BufSize){}[M(256)]public ConsoleReader(Stream input,Encoding encoding):this(input,encoding,BufSize){}[M(256)]public ConsoleReader(Stream input,Encoding encoding,int bufferSize){Input=input;Encoding=encoding;buf=new byte[bufferSize];}[M(256)]private void FillEntireNumber(){if((uint)pos>=(uint)buf.Length)FillNextBuffer();while(buf[pos]<=' ')if( ++pos>=len)FillNextBuffer();if(pos+21>=buf.Length&&buf[^1]>' ')FillEntireNumberImpl();}private void FillEntireNumberImpl(){buf.AsSpan(pos,len-pos).CopyTo(buf);len-=pos;pos=0;var numberOfBytes=Input.Read(buf,len,buf.Length-len);if(numberOfBytes==0)buf[len++]=10;else if(numberOfBytes+len<buf.Length)buf[^1]=10;len+=numberOfBytes;}private void FillNextBuffer(){if((len=Input.Read(buf,0,buf.Length))==0){buf[0]=10;len=1;}else if(len<buf.Length)buf[^1]=10;pos=0;}[M(256)]internal byte ReadByte(){if(pos>=len)FillNextBuffer();return buf[pos++];}[M(256)]public T Read<T>(){if(typeof(T)==typeof(int))return(T)(object)Int();if(typeof(T)==typeof(uint))return(T)(object)UInt();if(typeof(T)==typeof(long))return(T)(object)Long();if(typeof(T)==typeof(ulong))return(T)(object)ULong();if(typeof(T)==typeof(double))return(T)(object)Double();if(typeof(T)==typeof(decimal))return(T)(object)Decimal();if(typeof(T)==typeof(char))return(T)(object)Char();if(typeof(T)==typeof(string))return(T)(object)Ascii();if(typeof(T)==typeof(char[]))return(T)(object)AsciiChars();return Throw<T>();}static T Throw<T>()=>throw new NotSupportedException(typeof(T).Name);[M(256)]public int Int(){FillEntireNumber();TryParse(buf.AsSpan(pos),out int v,out int bc);pos+=bc;return v;}[M(256)]public uint UInt(){FillEntireNumber();TryParse(buf.AsSpan(pos),out uint v,out int bc);pos+=bc;return v;}[M(256)]public long Long(){FillEntireNumber();TryParse(buf.AsSpan(pos),out long v,out int bc);pos+=bc;return v;}[M(256)]public ulong ULong(){FillEntireNumber();TryParse(buf.AsSpan(pos),out ulong v,out int bc);pos+=bc;return v;}[M(256)]public double Double(){FillEntireNumber();TryParse(buf.AsSpan(pos),out double v,out int bc);pos+=bc;return v;}[M(256)]public decimal Decimal(){FillEntireNumber();TryParse(buf.AsSpan(pos),out decimal v,out int bc);pos+=bc;return v;}interface IBlock{bool Ok(byte b);}[System.Diagnostics.CodeAnalysis.SuppressMessage("Style","IDE0079")][System.Diagnostics.CodeAnalysis.SuppressMessage("Style","IDE0251")]struct AC:IBlock{[M(256)]public bool Ok(byte b)=>' '<b;}[System.Diagnostics.CodeAnalysis.SuppressMessage("Style","IDE0079")][System.Diagnostics.CodeAnalysis.SuppressMessage("Style","IDE0251")]struct LB:IBlock{[M(256)]public bool Ok(byte b)=>b!='\n'&&b!='\r';}[M(256)](byte[],int)InnerBlock<T>()where T:struct,IBlock{var bk=new T();var sb=new byte[32];int c=0;byte b;do b=ReadByte();while(b<=' ');do{sb[c++]=b;if(c>=sb.Length)Array.Resize(ref sb,sb.Length<<1);b=ReadByte();}while(bk.Ok(b));return(sb,c);}[M(256)]public string String(){var(sb,c)=InnerBlock<AC>();return Encoding.GetString(sb,0,c);}[M(256)]public string Line(){var(sb,c)=InnerBlock<LB>();return Encoding.GetString(sb,0,c);}[M(256)]public char[]StringChars(){var(sb,c)=InnerBlock<AC>();return Encoding.GetChars(sb,0,c);}[M(256)]public char[]LineChars(){var(sb,c)=InnerBlock<LB>();return Encoding.GetChars(sb,0,c);}[M(256)]public string Ascii()=>new(AsciiChars());[M(256)]public char[]AsciiChars(){var sb=new char[32];int c=0;byte b;do b=ReadByte();while(b<=' ');do{sb[c++]=(char)b;if(c>=sb.Length)Array.Resize(ref sb,sb.Length<<1);b=ReadByte();}while(' '<b);Array.Resize(ref sb,c);return sb;}[M(256)]public char Char(){byte b;do b=ReadByte();while(b<=' ');return(char)b;}[M(256)]public int Int0()=>Int()-1;[M(256)]public uint UInt0()=>UInt()-1;[M(256)]public long Long0()=>Long()-1;[M(256)]public ulong ULong0()=>ULong()-1;[M(256)]public static implicit operator int(R cr)=>cr.Int();[M(256)]public static implicit operator uint(R cr)=>cr.UInt();[M(256)]public static implicit operator long(R cr)=>cr.Long();[M(256)]public static implicit operator ulong(R cr)=>cr.ULong();[M(256)]public static implicit operator double(R cr)=>cr.Double();[M(256)]public static implicit operator decimal(R cr)=>cr.Decimal();[M(256)]public static implicit operator string(R cr)=>cr.Ascii();[M(256)]public static implicit operator char[](R cr)=>cr.AsciiChars();[M(256)]public T[]Repeat<T>(int count){var a=new T[count];for(int i=0;i<a.Length;i++)a[i]=Read<T>();return a;}[M(256)]public void Repeat<T>(Span<T>dst){foreach(ref var b in dst)b=Read<T>();}}}
namespace Kzrnm.Competitive.IO{using M=MethodImplAttribute;using W=ConsoleWriter;public sealed partial class ConsoleWriter:IDisposable{private const int BufSize=1<<12;private readonly StreamWriter sw;[EditorBrowsable(EditorBrowsableState.Never)]public StreamWriter StreamWriter=>sw;public ConsoleWriter():this(Console.OpenStandardOutput(),Console.OutputEncoding){}public ConsoleWriter(Stream output,Encoding encoding):this(output,encoding,BufSize){}public ConsoleWriter(Stream output,Encoding encoding,int bufferSize){sw=new StreamWriter(output,encoding,bufferSize);}[M(256)]public void Flush()=>sw.Flush();[M(256)]public void Dispose()=>Flush();[M(256)]public W Write<T>(T v){sw.Write(v.ToString());return this;}[M(256)]public W WriteLine(){sw.WriteLine();return this;}[M(256)]public W WriteLine<T>(T v){sw.WriteLine(v.ToString());return this;}[M(256)]public W WriteLineJoin(params object[]col)=>WriteMany(' ',col);[M(256)]public W WriteLineJoin<T1,T2>(T1 v1,T2 v2){sw.Write(v1.ToString());sw.Write(' ');sw.WriteLine(v2.ToString());return this;}[M(256)]public W WriteLineJoin<T1,T2,T3>(T1 v1,T2 v2,T3 v3){sw.Write(v1.ToString());sw.Write(' ');sw.Write(v2.ToString());sw.Write(' ');sw.WriteLine(v3.ToString());return this;}[M(256)]public W WriteLineJoin<T1,T2,T3,T4>(T1 v1,T2 v2,T3 v3,T4 v4){sw.Write(v1.ToString());sw.Write(' ');sw.Write(v2.ToString());sw.Write(' ');sw.Write(v3.ToString());sw.Write(' ');sw.WriteLine(v4.ToString());return this;}[M(256)]public W WriteLineJoin<T>(T[]col)=>WriteMany(' ',col);[M(256)]public W WriteLineJoin<T>(IEnumerable<T>col)=>WriteMany(' ',col);[M(256)]public W WriteLineJoin<T1,T2>((T1,T2)tuple)=>WriteLineJoin(tuple.Item1,tuple.Item2);[M(256)]public W WriteLineJoin<T1,T2,T3>((T1,T2,T3)tuple)=>WriteLineJoin(tuple.Item1,tuple.Item2,tuple.Item3);[M(256)]public W WriteLineJoin<T1,T2,T3,T4>((T1,T2,T3,T4)tuple)=>WriteLineJoin(tuple.Item1,tuple.Item2,tuple.Item3,tuple.Item4);[M(256)]public W WriteLineJoin<TTuple>(TTuple tuple)where TTuple:ITuple{var col=new object[tuple.Length];for(int i=0;i<col.Length;i++)col[i]=tuple[i];return WriteLineJoin(col);}[M(256)]public W WriteLines<T>(IEnumerable<T>col)=>WriteMany('\n',col);[M(256)]public W WriteGrid<T>(IEnumerable<IEnumerable<T>>cols){foreach(var col in cols)WriteLineJoin(col);return this;}[M(256)]public W WriteGrid<TTuple>(IEnumerable<TTuple>tuples)where TTuple:ITuple{foreach(var tup in tuples)WriteLineJoin(tup);return this;}[M(256)]private W WriteMany<T>(char sep,IEnumerable<T>col){if(col is T[]a)return WriteMany(sep,(ReadOnlySpan<T>)a);var en=col.GetEnumerator();if(en.MoveNext()){sw.Write(en.Current.ToString());while(en.MoveNext()){sw.Write(sep);sw.Write(en.Current.ToString());}}sw.WriteLine();return this;}}}
namespace Kzrnm.Competitive.IO{using M=MethodImplAttribute;using W=ConsoleWriter;public partial class ConsoleWriter{[M(256)]public W WriteLine(ReadOnlySpan<char>v){sw.WriteLine(v);return this;}[M(256)]public W WriteLineJoin<T>(Span<T>col)=>WriteMany(' ',(ReadOnlySpan<T>)col);[M(256)]public W WriteLineJoin<T>(ReadOnlySpan<T>col)=>WriteMany(' ',col);[M(256)]public W WriteLines<T>(Span<T>col)=>WriteMany('\n',(ReadOnlySpan<T>)col);[M(256)]public W WriteLines<T>(ReadOnlySpan<T>col)=>WriteMany('\n',col);[M(256)]public W WriteGrid<T>(T[,]cols){var width=cols.GetLength(1);for(var s=MemoryMarshal.CreateReadOnlySpan(ref cols[0,0],cols.Length);!s.IsEmpty;s=s[width..])WriteLineJoin(s[..width]);return this;}[M(256)]private W WriteMany<T>(char sep,ReadOnlySpan<T>col){if(col.Length>0){sw.Write(col[0].ToString());foreach(var c in col[1..]){sw.Write(sep);sw.Write(c.ToString());}}sw.WriteLine();return this;}}}
namespace SourceExpander{public class Expander{[Conditional("EXP")]public static void Expand(string inputFilePath=null,string outputFilePath=null,bool ignoreAnyError=true){}public static string ExpandString(string inputFilePath=null,bool ignoreAnyError=true){return "";}}}
#endregion Expanded by https://github.com/kzrnm/SourceExpander
