using System;
using System.Collections.Generic;
using System.Linq;

namespace Configs.Resource
{
    namespace InternalAssets.Infrustructure.Extensions
    {
        public static class BigNumExtension
        {
            private const int AlphabetLettersNum = 26;
            private const int DigitsNumber = 2;
            private const int RoundPrecision = 1;

            private static readonly IEnumerable<string> Letters;
            private static readonly IEnumerable<string> HomogenousSymbols;
            private static readonly IEnumerable<string> CompositeSymbols;
            private static readonly List<string> Symbols = new List<string>();
            private static Dictionary<int, string> SymbolsDict = new Dictionary<int, string>();

            static BigNumExtension()
            {
                Letters = Enumerable
                    .Range('a', AlphabetLettersNum)
                    .Select(x => ((char)x).ToString());

                HomogenousSymbols = new[] { String.Empty, "", "K", "M", "B", "T" };

                CompositeSymbols = Enumerable
                    .Range(0, DigitsNumber - 1)
                    .Aggregate(Letters, (curr, next)
                        => curr.SelectMany(s => Letters, (s, c) => s + c));

                Symbols = HomogenousSymbols.Concat(CompositeSymbols).ToList();
                Symbols.Remove("");

                InitDictionary();
            }

            private static void InitDictionary()
            {
                var degree = 0;

                foreach (var symbol in Symbols)
                {
                    SymbolsDict.Add(degree, symbol);

                    degree += 3;
                }
            }

            public static string ToBigNum(this double value, int roundPrecision = RoundPrecision)
            {
                var degree = 0;

                while (value >= 1000)
                {
                    degree += 3;
                    value /= 1000;
                }

                return $"{Math.Round(value, roundPrecision)}{SymbolsDict[degree]}";
            }
        }
    }
}