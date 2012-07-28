﻿using System.Collections.Generic;
using NHunspell;

namespace SpellChecker.Spelling
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