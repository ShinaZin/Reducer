using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reducer
{
    public partial class FormSettingsOfReduce : Form
    {
        FormMain _formMain;
        public FormSettingsOfReduce(FormMain formMain)
        {
            InitializeComponent();
            _formMain = formMain;
            // Копируем параметры в форму из переменных
            numericSyllables.Value = ReducerSettings.MaxSyllables;
            trackBarVowels.Value = ReducerSettings.VowelsDeletePercent;
            checkBoxDeleteNewLines.Checked = ReducerSettings.DeleteNewLineSymbols;
            checkBoxDeleteSpaces.Checked = ReducerSettings.DeleteSpacesAndTabs;
            numericSyllToHyphen.Value = ReducerSettings.SyllablesToHyphen;
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {

            ReducerSettings.MaxSyllables = (int)numericSyllables.Value;
            ReducerSettings.VowelsDeletePercent = trackBarVowels.Value;
            ReducerSettings.DeleteNewLineSymbols = checkBoxDeleteNewLines.Checked;
            ReducerSettings.DeleteSpacesAndTabs = checkBoxDeleteSpaces.Checked;
            ReducerSettings.SyllablesToHyphen = (int)numericSyllToHyphen.Value;

        }
    }
}
