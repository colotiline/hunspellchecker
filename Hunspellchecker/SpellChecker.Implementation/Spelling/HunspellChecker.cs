using System.Collections.Generic;
using NHunspell;

namespace Hunspellchecker.Spelling
{
    public class HunspellChecker
    {
        protected const string RussianAlphabet = "абвгдеёжзийклмнопрстуфхцчшщьъыэюя";

        protected static Hunspell _russian;

        protected static Hunspell _english;

        static HunspellChecker()
        {
            _russian = new Hunspell(Properties.Resources.ru_RU_aff, Properties.Resources.ru_RU_dic); 
            _english = new Hunspell(Properties.Resources.en_US_aff, Properties.Resources.en_US_dic); 
        }

        public bool CheckText(string text, out List<string> suggests)
        {
            suggests = null;

            bool result;
            if (RussianAlphabet.Contains(text[0].ToString().ToLower()))
            {
                result =  _russian.Spell(text);
                if (!result) suggests = _russian.Suggest(text);
            }
            else
            {
                result = _english.Spell(text);
                if (!result) suggests = _english.Suggest(text);
            }

            return result;
        }
    }
}