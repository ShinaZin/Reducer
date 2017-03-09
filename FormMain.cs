using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Reducer
{
    
    public partial class FormMain : Form
    {
        // Инициализация
        public FormMain()
        {
            InitializeComponent();
            InitSettings();
            
            ParseAndHandle(Environment.GetCommandLineArgs());
        }
        private void InitSettings()
        {
            ReducerSettings.MaxSyllables = 2;
            ReducerSettings.VowelsDeletePercent = 30;
            ReducerSettings.DeleteNewLineSymbols = false;
            ReducerSettings.DeleteSpacesAndTabs = false;
            ReducerSettings.SyllablesToHyphen = 4;
        }
        

        // Преобразующие текст функции
        /// <summary>
        /// Главная функция, вызывающая остальные функции сокращения
        /// </summary>
        private void ReduceTheText()
        {
            string[] words = textBoxInput.Text.Split(' ');
            if (words.Length == 0)
            {
                MessageBox.Show("Введите текст для сокращения!", "Ошибка");
                return;
            }
            FlowSplitter flowSplitter = new FlowSplitter(textBoxInput.Text, "@#$;:!?%^&\"\',./-_=~`\\+*\t\n\r(){}[]<> ");
            textBoxOutput.Text = "";
            while (flowSplitter.Length > 0)
            {
                // Получаем новое слово
                string word = flowSplitter.GetNext();
                string res = RemVowels(
                    TrimWord(word, ReducerSettings.MaxSyllables, ReducerSettings.SyllablesToHyphen),
                    ReducerSettings.VowelsDeletePercent
                    );
                // Если длина слова не изменилась, то берем оригинал
                if (res.Length == word.Length) res = word;
                textBoxOutput.Text += res;
                // Дописываем разделители
                textBoxOutput.Text += RemDelims(flowSplitter.LastDelims,
                    ReducerSettings.DeleteSpacesAndTabs,
                    ReducerSettings.DeleteNewLineSymbols
                    );
            }
        }
        /// <summary>
        /// Удаляет гласные буквы из слова
        /// </summary>
        /// <param name="sInpWord">Входная строка (без пробелов)</param>
        /// <param name="intense">Интнсивность в процентах</param>
        /// <returns></returns>
        private string RemVowels(string sInpWord, int intense)
        {
            string res = "";
            // Если интенсивность меньше 1, то не удаляем гласные
            if (intense < 1) return sInpWord;
            if(sInpWord.Length < 3)
                return sInpWord;
            // Переводим проценты в "каждый k-й"
            int everyK = 100 / intense;

            // Отбираем все буквы
            int cnt = 0;
            //foreach (char ch in sInpWord)
            for (int i=0;i<sInpWord.Length;i++)
            {
                char ch = sInpWord[i];
                if (SyllableParser.GetLetterType(ch) == LetterType.Consonant)
                {
                    res += ch;
                }
                if (SyllableParser.GetLetterType(ch) == LetterType.Vowel)
                {
                    cnt++;
                    if (cnt % everyK != 0)
                        res += ch;
                    //если буква последння
                    else if (i == sInpWord.Length - 1)
                        res += ch;

                }
                if (SyllableParser.GetLetterType(ch) == LetterType.Unknown)
                    res += ch;
            }
            // Сохраняем первую гласную
            if (SyllableParser.GetLetterType(sInpWord[0]) == LetterType.Vowel)
                if (res[0] != sInpWord[0])
                    res = sInpWord[0] + res;
            return res;
        }
        /// <summary>
        /// Сокращает слово
        /// </summary>
        /// <param name="sInpWord">Входная строка</param>
        /// <param name="maxSyll">Максимальное число слогов</param>
        /// <returns></returns>
        private string TrimWord(string sInpWord, int maxSyll, int syllsToHyphen)
        {
            string sOutWord = "";
            if (sInpWord.Length < 3)
                return sInpWord;

            string[] Syllables = SyllableParser.ParseAlt(sInpWord);
            if (Syllables.Length > syllsToHyphen)
            {
                return Syllables[0] +Syllables[1][0]+ '-' + Syllables.Last();//Test test test
            }
            else
            {
                for (int i = 0; i < Syllables.Length; i++)
                {
                    sOutWord += Syllables[i];
                    if (i >= maxSyll - 1)
                    {
                        // Добавляем 1 согласную букву из следующего слога,
                        if (Syllables.Length - 1 >= i + 1) // если он(слог) есть)))0)
                            sOutWord += Syllables[i + 1][0];

                        // Удаляем все гласные в конце слова
                        while (SyllableParser.GetLetterType(sOutWord.Last()) == LetterType.Vowel)
                            sOutWord = sOutWord.Remove(sOutWord.Length - 1, 1);

                        // Добавляенм точку, если сократили слово
                        if (sOutWord.Length < sInpWord.Length)
                            sOutWord += '.';
                        break;
                    }
                }
            }

            return sOutWord;
        }
        /// <summary>
        /// Удаляет разделители из входной строки
        /// </summary>
        /// <param name="delimsString">Входная строка</param>
        /// <param name="DeleteSpaces">Флаг удаления пробелов и табуляций</param>
        /// <param name="DeleteNewLines">Флаг удаления переводов строк</param>
        /// <returns></returns>
        private string RemDelims(string delimsString, bool DeleteSpaces, bool DeleteNewLines)
        {
            string res = delimsString;
            Regex r;

            if (DeleteNewLines == true)
            {
                r = new Regex(@"[\r\n]+");
                res = r.Replace(res, @" ");
            }

            if (DeleteSpaces == true)
            {
                r = new Regex(@"[ \t]+");
                res = r.Replace(res, @" ");
            }
            return res;
        }

        // UI
        private void buttonReduce_Click(object sender, EventArgs e)
        {
            ReduceTheText();

        }
        private void настройкиСокращенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSettingsOfReduce form = new FormSettingsOfReduce(this);
            form.ShowDialog();
        }
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Открытие файла на обработку
            openFileDialog.ShowDialog();
            string fileName = openFileDialog.FileName;
            StreamReader sr = new StreamReader(fileName,Encoding.GetEncoding(1251));
            textBoxInput.Text = sr.ReadToEnd();
            sr.Close();
            
        }
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Сохранение сокращенного текста
            saveFileDialog.ShowDialog();
            string fileName = saveFileDialog.FileName;
            StreamWriter sw = new StreamWriter(fileName,false, Encoding.GetEncoding(1251));
            sw.Write(textBoxOutput.Text);
            sw.Close();
        }
        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Просто закрытие файла
        }
        private void помощьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ReducerSettings.HelpString, "Помощь");
        }

        // Вспомогательные функции
        private void ParseAndHandle(string [] args)
        {
            string InpFile = "";
            string OutFile = "";
            if (args.Length < 2) return;
            for (int i = 0; i < args.Length; i++)
            {
                string arg = args[i].ToLower();
                if (arg == "-i" && (i + 1) < args.Length)
                    InpFile = args[i + 1];
                if (arg == "-o" && (i + 1) < args.Length)
                    OutFile = args[i + 1];
                if (arg == "-s")
                    ReducerSettings.DeleteSpacesAndTabs = true;
                if (arg == "-n")
                    ReducerSettings.DeleteNewLineSymbols = true;
                // Максимум слогов
                if (arg == "-ms" && (i + 1) < args.Length) {
                    int res;
                    bool isSucces = int.TryParse(args[i + 1],out res);
                    ReducerSettings.MaxSyllables = isSucces ? res : ReducerSettings.MaxSyllables;
                }
                // Слогов для сокращения дефисом
                if (arg == "-mh" && (i + 1) < args.Length)
                {
                    int res;
                    bool isSucces = int.TryParse(args[i + 1], out res);
                    ReducerSettings.SyllablesToHyphen = isSucces ? res : ReducerSettings.SyllablesToHyphen;
                }
                // Процент удаляемых гласных
                if (arg == "-dv" && (i + 1) < args.Length)
                {
                    int res;
                    bool isSucces = int.TryParse(args[i + 1], out res);
                    ReducerSettings.VowelsDeletePercent = isSucces ? res : ReducerSettings.VowelsDeletePercent;
                }
                if (arg == "-h" || arg == "-help")
                {
                    MessageBox.Show(ReducerSettings.HelpString, "Помощь");
                    Environment.Exit(0);
                }
            }
            // Случай Drag'n'drop'a
            if (args.Length == 2)
                    InpFile = args[1];
            // Проверка существования файла
            if (File.Exists(InpFile) == false) return;
            // Если имя выходного файла не задано
            if (OutFile == "") OutFile = InpFile + ".reduced.txt";

            // Чтение файла
            var sr = new StreamReader(InpFile, Encoding.GetEncoding(1251));
            textBoxInput.Text = sr.ReadToEnd();
            sr.Close();

            // главная функция сокращения
            ReduceTheText();

            // Запись в файл
            var sw = new StreamWriter(OutFile, false, Encoding.GetEncoding(1251));
            sw.Write(textBoxOutput.Text);
            sw.Close();
            //Application end
            //this.Close();//Ошибка при выходе
            Environment.Exit(0);
            //Application.Exit();

        }


    }
}
