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
            suggests = null;
            var trimmedText = text.Trim(new[] {'\''});

            bool result;
            if (RussianAlphabet.Contains(trimmedText[0].ToString().ToLower()))
            {
                result = _russian.Spell(trimmedText);
                if (!result) suggests = _russian.Suggest(trimmedText);
            }
            else
            {
                result = _english.Spell(trimmedText);
                if (!result) suggests = _english.Suggest(trimmedText);
            }

            return result;
        }
    }
}