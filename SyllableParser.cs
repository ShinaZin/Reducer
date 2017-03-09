using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reducer
{
    /// <summary>
    /// Предоставляет статические методы для работы со слогами в слове
    /// </summary>
    public class SyllableParser
    {
        // строка с гласными
        private static string vowel = "аеёиоуыэюяeyuioa"; //аеёиоуыэюя
        // строка с согласными
        private static string consonant = "бвгджзйклмнпрстфхцчшщъьqwrtpasdfghjklzxcvbnm";//бвгджзйклмнпрстфхцчшщъь
        // строка с двухзвучными гласными
        private static string doublevowel = "еёюя";

        /// <summary>
        /// Определяет тип буквы: Vowel (гласная) или Consonant (согласная);
        /// в остальных случаях возвращается тип Unknown
        /// </summary>
        /// <param name="letter">исходная буква</param>
        /// <returns></returns>
        public static LetterType GetLetterType(char letter)
        {
            // переводим букву в нижний регистр для удобства
            letter = Char.ToLower(letter);

            // проверка на гласную букву
            if (vowel.Contains(letter))
                return LetterType.Vowel;
            // проверка на согласную букву
            if (consonant.Contains(letter))
                return LetterType.Consonant;
            // двухзвучная буква "еёюя"
            if (doublevowel.Contains(letter))
                return LetterType.DoubleVowel;
            // иначе неопределенная буква
            return LetterType.Unknown;
        }

        /// <summary>
        /// Разделяет строку, состоящую только из согласных, на две подстроки
        /// </summary>
        /// <param name="word">строка, состоящая только из согласных</param>
        /// <param name="consonants">массив из двух элементов</param>
        /// <returns>Массив строк из двух элементов</returns>
        private static bool ExplodeConsonant(string word, out string[] consonants)
        {
            // создаем массив для будущих подстрок
            consonants = new string[2];
            string buf = "";

            // проходим по слову до конца и пока буквы являются согласными
            for (int i = 0; i < word.Length && GetLetterType(word[i]) == LetterType.Consonant; i++)
            {
                // добавляем очередную букву
                buf += word[i];
            }

            // если длина буфера получилась меньше двух, то ОШИБКА
            if (buf.Length < 2)
            {
                return false;
            }

            // если длина буфера является четной, то разделяем его на две части
            // и помещаем их в массив
            if (buf.Length % 2 == 0)
            {
                consonants[0] = buf.Substring(0, buf.Length / 2);
                consonants[1] = buf.Substring(buf.Length / 2, buf.Length / 2);
            }
            // а если длина буфера нечетна, то первая часть будет на один символ больше,
            // чем вторая
            else
            {
                consonants[0] = buf.Substring(0, (buf.Length - 1) / 2 + 1);
                consonants[1] = buf.Substring((buf.Length - 1) / 2 + 1, (buf.Length - 1) / 2);
            }
            return true; // процедура выполнена УСПЕШНО
        }

        /// <summary>
        /// Разделяет слово по слогам
        /// </summary>
        /// <param name="word">исходное слово</param>
        /// <returns>массив слогов или NULL в случае ошибки</returns>
        public static string[] Parse(string word)
        {
            // проверка: строка должна быть длиной не менее двух символов
            if (word == null || word.Length < 2)
            {
                return new string[] { word };
            }
            // проверка: в строке могут быть только гласные или согласные буквы
            foreach (char c in word)
            {
                if (GetLetterType(c) == LetterType.Unknown)
                    return null;
            }

            LetterType Old = GetLetterType(word[0]), Cur = LetterType.Unknown;
            string preformat = word[0].ToString();
            // посимвольно проходим по исходному слову и формируем его маску
            for (int i = 1; i < word.Length; i++)
            {
                // тип текущей буквы
                Cur = GetLetterType(word[i]);
                // если предыдущая буква была гласная и текущая тоже гласная,
                // то добавляем пробел в маску
                if (Old == LetterType.Vowel && Cur == LetterType.Vowel)
                {
                    preformat += " ";
                }
                // если предыдущая буква и текущая разные по типу, то также добавляем пробел
                if (Old != Cur)
                {
                    preformat += " ";
                }
                // предыдущий тип равен текущему
                Old = Cur;
                // прибавляем в преформат текущую букву
                preformat += word[i];
            }

            // преобразуем преформат в массив, пробел является разделителем
            string[] PreformatArray = preformat.Split(' ');

            // результирующий массив никак не больше преформатного массива
            string[] ResultArray = new string[PreformatArray.Length];
            //
            int k = 0;
            // проходимся по каждому элементу преформатного массива
            for (int i = 0; i < PreformatArray.Length; i++)
            {
                // если первая буква в текущем элементе - гласная...
                if (GetLetterType(PreformatArray[i][0]) == LetterType.Vowel)
                {
                    // ... и если в текущем элементе результирующего массива уже есть
                    // и гласная, и согласная...
                    if (HasConsonant(ResultArray[k]) && HasVowel(ResultArray[k]))
                        // ... то переходим к следующему элементу массива
                        k++;
                    // прибавляем к текущему элементу результирующего массива
                    // элемент преформатного массива
                    ResultArray[k] += PreformatArray[i];
                }
                // если первая буква в текущем элементе - согласная...
                if (GetLetterType(PreformatArray[i][0]) == LetterType.Consonant)
                {

                    string[] buf = null;

                    // ... пытаемся разделить текущий элемент, состоящий из согласных
                    // на два новых элемента массива
                    if (ExplodeConsonant(PreformatArray[i], out buf))
                    {
                        // в случае успеха прибавляем первый элемент массива к текущему слогу
                        ResultArray[k] += buf[0];
                        // если в текущем слоге есть и гласная и согласная, то
                        if (HasConsonant(ResultArray[k]) && HasVowel(ResultArray[k]))
                            // переходим к новому слогу
                            k++;
                        // и добавляем второй элемент к новому слогу
                        ResultArray[k] += buf[1];
                    }
                    else
                    {
                        // если разделение на два элемента произошло с ошибкой, то
                        // проверяем текущий слог на "полноценность" и, в случае истины,
                        // переходим к новому слогу
                        if (HasConsonant(ResultArray[k]) && HasVowel(ResultArray[k]))
                            k++;
                        ResultArray[k] += PreformatArray[i];
                    }
                }
            }

            // далее идет процедура, которая проверяет, не является ли последний элемент
            // результирующего массива длиной в 1 символ; если да, то склеиваем предпоследний
            // слог с последним
            int LastIndex = 0;

            // проходим результирующий массив до тех пор, пока не встретим пустой элемент
            for (int i = 0; i < ResultArray.Length; i++)
            {
                if (ResultArray[i] == null)
                    break;
                else
                    LastIndex++;
            }

            // корректируем индекс последнего элемента
            LastIndex--;

            // если длина последнего значащего элемента массива равна 1 и последний индекс
            // больше 1, то прибавляем последний элемент к предпоследнему
            if (ResultArray[LastIndex].Length == 1 && LastIndex >= 1)
            {
                ResultArray[LastIndex - 1] += ResultArray[LastIndex];
                ResultArray[LastIndex] = null;
            }

            return ResultArray;
        }
        /// <summary>
        /// Разделяет слово по слогам альтернативным способом
        /// </summary>
        /// <param name="word">исходное слово</param>
        /// <returns>массив слогов или NULL в случае ошибки</returns>
        public static string[] ParseAlt(string word)
        {
            List<int> vowelIndexes = new List<int>();
            for (int i = 0; i < word.Length; i++)
            {
                string symbol = word.Substring(i, 1);
                if (GetLetterType(symbol[0]) == LetterType.Vowel)
                    vowelIndexes.Add(i);
            }
            string result = string.Empty;
            for (int i = vowelIndexes.Count - 1; i > 0; i--)
            {
                if (vowelIndexes[i] - vowelIndexes[i - 1] == 1)
                    continue;
                int n = vowelIndexes[i] - vowelIndexes[i - 1] - 1;
                result = "-" + word.Substring(vowelIndexes[i - 1] + 1 + n / 2) + result;
                word = word.Remove(vowelIndexes[i - 1] + 1 + n / 2);
            }
            result = word + result;
            return result.Split('-');
        }

        /// <summary>
        /// Определяет, есть ли в строке гласная буква
        /// </summary>
        /// <param name="word">исходное слово</param>
        /// <returns>ИСТИНА, если имеет гласную, в противном случае ЛОЖЬ</returns>
        public static bool HasVowel(string word)
        {
            if (word == null)
                return false;
            for (int i = 0; i < word.Length; i++)
            {
                if (GetLetterType(word[i]) == LetterType.Vowel)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Определяет, есть ли в строке согласная буква
        /// </summary>
        /// <param name="word">исходное слово</param>
        /// <returns>ИСТИНА, если в строке есть согласная, в противном случае ЛОЖЬ</returns>
        public static bool HasConsonant(string word)
        {
            if (word == null)
                return false;
            for (int i = 0; i < word.Length; i++)
            {
                if (GetLetterType(word[i]) == LetterType.Consonant)
                    return true;
            }
            return false;
        }
    }
    // Перечисление с типами букв:

    /// <summary>
    /// Тип буквы (гласная или согласная)
    /// </summary>
    public enum LetterType
    {
        /// <summary>
        /// Не гласная и не согласная
        /// </summary>
        Unknown,
        /// <summary>
        /// Гласная
        /// </summary>
        Vowel,
        /// <summary>
        /// Согласная
        /// </summary>
        Consonant,
        /// <summary>
        /// Двухзвучная гласная
        /// </summary>
        DoubleVowel
    }
}
