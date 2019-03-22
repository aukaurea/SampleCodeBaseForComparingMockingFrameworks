using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleNamespaceExample
{
    public static class DoubleNamespaceClass1
    {
        public static int GetDuplicatesCount(string entries, out string result)
        {
            var listOfLines = entries.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            var sameLinePossible = 0;
            result = string.Empty;
            var resultList = new List<string>(5);
            foreach (var stringLine in listOfLines)
            {
                var splitLine = stringLine.Split('\t');

                if (splitLine.Length == 2)
                {
                    var first = splitLine[0].Trim();
                    var second = splitLine[1].Trim();

                    if (string.Equals(first, second))
                    {
                        var r = $"Lines are same for : [{first}] == [{second}]";
                        resultList.Add(r);
                        sameLinePossible++;
                    }
                    else
                    {
                        var r2 = $"!!!! Lines are NOT same for : [{first}] != [{second}]";
                        resultList.Add(r2);
                    }
                }
            }

            var r3 = $"{Environment.NewLine} TotalLine Matches : {sameLinePossible}";
            resultList.Add(r3);

            result = string.Join(Environment.NewLine, resultList);

            return sameLinePossible;
        }
    }
}

namespace DoubleNamespaceExample2
{
    public static class DoubleNamespaceClass2
    {
        public static int GetDuplicatesCount(string entries, out string result)
        {
            var listOfLines = entries.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            var sameLinePossible = 0;
            result = string.Empty;
            var resultList = new List<string>(5);

            foreach (var stringLine in listOfLines)
            {
                var splitLine = stringLine.Split('\t');

                if (splitLine.Length == 2)
                {
                    var first = splitLine[0].Trim();
                    var second = splitLine[1].Trim();

                    if (string.Equals(first, second))
                    {
                        var r = $"Lines are same for : [{first}] == [{second}]";
                        resultList.Add(r);
                        sameLinePossible++;
                    }
                    else
                    {
                        var r2 = $"!!!! Lines are NOT same for : [{first}] != [{second}]";
                        resultList.Add(r2);
                    }
                }
            }

            var r3 = $"{Environment.NewLine} TotalLine Matches : {sameLinePossible}";
            resultList.Add(r3);

            result = string.Join(Environment.NewLine, resultList);

            return sameLinePossible;
        }
    }
}


namespace DoubleNamespaceExample3
{
    public static class DoubleNamespaceClass3
    {
        public static int GetDuplicatesCount(string entries, out string result)
        {
            var listOfLines = entries.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            var sameLinePossible = 0;
            result = string.Empty;
            var resultList = new List<string>(5);

            foreach (var stringLine in listOfLines)
            {
                var splitLine = stringLine.Split('\t');

                if (splitLine.Length == 2)
                {
                    var first = splitLine[0].Trim();
                    var second = splitLine[1].Trim();

                    if (string.Equals(first, second))
                    {
                        var r = $"Lines are same for : [{first}] == [{second}]";
                        resultList.Add(r);
                        sameLinePossible++;
                    }
                    else
                    {
                        var r2 = $"!!!! Lines are NOT same for : [{first}] != [{second}]";
                        resultList.Add(r2);
                    }
                }
            }

            var r3 = $"{Environment.NewLine} TotalLine Matches : {sameLinePossible}";
            resultList.Add(r3);

            result = string.Join(Environment.NewLine, resultList);

            return sameLinePossible;
        }
    }
}

