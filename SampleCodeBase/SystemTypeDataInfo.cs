using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp;

namespace SampleCodeBase
{
    public class SystemTypeDataInfo
    {
        public IList<Type> GetSystemTypesList()
        {
            var list = new List<Type>(10);

            list.Add(typeof(byte));
            list.Add(typeof(bool));
            list.Add(typeof(sbyte));
            list.Add(typeof(char));
            list.Add(typeof(short));
            list.Add(typeof(ushort));
            list.Add(typeof(Single));
            list.Add(typeof(UInt16));
            list.Add(typeof(UInt32));
            list.Add(typeof(UInt64));
            list.Add(typeof(float));
            list.Add(typeof(double));
            list.Add(typeof(decimal));
            list.Add(typeof(float));
            list.Add(typeof(string));
            list.Add(typeof(String));
            list.Add(typeof(Char));
            list.Add(typeof(int));
            list.Add(typeof(long));
            list.Add(typeof(DateTime));

            list.Add(typeof(byte?));
            list.Add(typeof(sbyte?));
            list.Add(typeof(bool?));
            list.Add(typeof(char?));
            list.Add(typeof(short?));
            list.Add(typeof(ushort?));
            list.Add(typeof(Single?));
            list.Add(typeof(UInt16?));
            list.Add(typeof(UInt32?));
            list.Add(typeof(UInt64?));
            list.Add(typeof(float?));
            list.Add(typeof(double?));
            list.Add(typeof(decimal?));
            list.Add(typeof(float?));
            list.Add(typeof(Char?));
            list.Add(typeof(int?));
            list.Add(typeof(long?));
            list.Add(typeof(DateTime?));

            list.Add(typeof(byte[]));
            list.Add(typeof(sbyte[]));
            list.Add(typeof(bool[]));
            list.Add(typeof(char[]));
            list.Add(typeof(short[]));
            list.Add(typeof(ushort[]));
            list.Add(typeof(Single[]));
            list.Add(typeof(UInt16[]));
            list.Add(typeof(UInt32[]));
            list.Add(typeof(UInt64[]));
            list.Add(typeof(float[]));
            list.Add(typeof(double[]));
            list.Add(typeof(decimal[]));
            list.Add(typeof(float[]));
            list.Add(typeof(Char[]));
            list.Add(typeof(int[]));
            list.Add(typeof(long[]));
            list.Add(typeof(DateTime[]));

            list.Add(typeof(IList<sbyte>));
            list.Add(typeof(IList<bool>));
            list.Add(typeof(IList<char>));
            list.Add(typeof(IList<short>));
            list.Add(typeof(IList<ushort>));
            list.Add(typeof(IList<Single>));
            list.Add(typeof(IList<UInt16>));
            list.Add(typeof(IList<UInt32>));
            list.Add(typeof(IList<UInt64>));
            list.Add(typeof(IList<float>));
            list.Add(typeof(IList<double>));
            list.Add(typeof(IList<decimal>));
            list.Add(typeof(IList<float>));
            list.Add(typeof(IList<Char>));
            list.Add(typeof(IList<int>));
            list.Add(typeof(IList<long>));
            list.Add(typeof(IList<DateTime>));

            list.Add(typeof(List<sbyte>));
            list.Add(typeof(List<bool>));
            list.Add(typeof(List<char>));
            list.Add(typeof(List<short>));
            list.Add(typeof(List<ushort>));
            list.Add(typeof(List<Single>));
            list.Add(typeof(List<UInt16>));
            list.Add(typeof(List<UInt32>));
            list.Add(typeof(List<UInt64>));
            list.Add(typeof(List<float>));
            list.Add(typeof(List<double>));
            list.Add(typeof(List<decimal>));
            list.Add(typeof(List<float>));
            list.Add(typeof(List<Char>));
            list.Add(typeof(List<int>));
            list.Add(typeof(List<long>));
            list.Add(typeof(List<DateTime>));

            return list;
        }

        public string GetTypesString(IList<Type> types)
        {
            var list = new List<string>(types.Count + 2);

            var prov = new CSharpCodeProvider();
            var codeGenerationOptions = new CodeGeneratorOptions();
            foreach (var type in types)
            {
                var expr = new CodeTypeReferenceExpression(type);
                var sb = new StringBuilder(30);
                var sw = new StringWriter(sb);
                prov.GenerateCodeFromExpression(expr, sw, codeGenerationOptions);
                var typeAlias = sb.ToString();
                sb.Clear();
                var stringLine = $"public static readonly Type {type.Name} = typeof({type.FullName});";
                //var stringLine2 = $"{type.FullName}=>{type.FullName}";
                list.Add(stringLine);
                //list.Add(stringLine2);
            }

            list = list.Distinct().ToList();

            return string.Join(Environment.NewLine, list);
        }
    }
}
