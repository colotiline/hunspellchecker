using System.Collections.Generic;
using System.IO;
using NHunspell;
using System.Windows.Forms;

namespace Hunspellchecker.Spelling
{
    public class HunspellChecker
    {
        protected const string RussianAlphabet = "абвгдеёжзийклмнопрстуфхцчшщьъыэюя";

        protected static Hunspell _russian;

        protected static Hunspell _english;

        static HunspellChecker()
        {
            AddDllsIfNotExist();
            _russian = new Hunspell(Properties.Resources.ru_RU_aff, Properties.Resources.ru_RU_dic); 
            _english = new Hunspell(Properties.Resources.en_US_aff, Properties.Resources.en_US_dic); 
        }

        static void AddDllsIfNotExist()
        {
            var path = Path.Combine(Application.StartupPath, "Hunspellx86.dll");
            if (!File.Exists(path))
            {
                File.WriteAllBytes(path, Properties.Resources.Hunspellx86);
            }

            path = Path.Combine(Application.StartupPath, "Hunspellx64.dll");
            if (!File.Exists(path))
            {
                File.WriteAllBytes(path, Properties.Resources.Hunspellx64);
            }
        }

        public bool CheckText(string text, out List<string> suggests)
        {
            if (RussianAlphabet.Contains(text[0].ToString().ToLower()))
            {
                suggests = _russian.Suggest(text);
                return _russian.Spell(text);
            }
            else
            {
                suggests = _english.Suggest(text);
                return _english.Spell(text);
            }
        }
    }
}