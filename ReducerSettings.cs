using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reducer
{
    class ReducerSettings
    {
        public static int MaxSyllables;
        public static int VowelsDeletePercent;
        public static bool DeleteSpacesAndTabs;
        public static bool DeleteNewLineSymbols;
        public static int SyllablesToHyphen;

        public static string HelpString = @"Помощь по работе из командной строки:
--------------
Использование:
    1)Reducer [имя файла]
    2)Reducer -i имя файла [необязательные ключи (-o xxx -s -n ..)]
Ключи:
    -i имя входного файла
    -o имя выходного файла
    -s - если задан, то будут удалены повторяющиеся пробелы и табуляции
    -n - удаление всех переводов строк
    -ms число - максимальное число слогов
    -mh число - минимальное число слогов для сокращения через дефис
    -dv число - процент удаляемых гласных
";
    }
}
