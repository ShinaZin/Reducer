using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reducer
{
    class FlowSplitter
    {
        string _text;
        string _delims;
        string _lastdelims;
        public FlowSplitter(string text)
        {
            _text = text;
            _delims = " ";
        }
        public FlowSplitter(string text, string delims)
        {
            _text = text;
            _delims = delims;
        }
        public string LastDelims{
            get
            {
                return _lastdelims;
            }
        }
        public int Length
        {
            get { return _text.Length; }
        }
        public string GetNext()
        {
            string res="";
            _lastdelims = "";
            // Пока текущие символы - буквы
            while ( _text.Length != 0 && _delims.Contains(_text[0])==false )
            {
                res += _text[0];
                _text=_text.Remove(0, 1);
            }

            // Пока текущие символы - разделители
            while (_text.Length != 0 && _delims.Contains(_text[0]) == true)
            {
                _lastdelims += _text[0];
                _text = _text.Remove(0, 1);
            }

            return res;
        }
    }
}
