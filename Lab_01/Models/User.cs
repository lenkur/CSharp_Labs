using System;

namespace KMA.CSharp2020.Lab01
{
    internal class User
    {
        #region Fields
        private DateTime _birthDate;
        private string _westernZodiac;
        private string _chineseZodiac;
        static readonly string[] _westernZodiacSigns = {
            "Aquarius",            "Pisces",            "Aries",
            "Taurus",              "Gemini",            "Cancer",
            "Leo",                 "Virgo",             "Libra",
            "Scorpio",             "Sagittarius",       "Capricorn"};
        static readonly string[] _chineseZodiacSigns = {
            "Monkey",            "Rooster",            "Dog",
            "Pig",               "Rat",                "Ox",
            "Tiger",             "Rabbit",             "Dragon",
            "Snake",             "Horse",              "Goat"};
        #endregion

        #region Properties
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set
            {
                _birthDate = value;
                fillProperties();
            }
        }

        public int Age
        {
            get
            {
                int res = DateTime.Now.Year - _birthDate.Year;
                return DateTime.Now < _birthDate.AddYears(res) ? res - 1 : res;
            }
        }

        public string WesternZodiac
        {
            get { return _westernZodiac; }
            set { _westernZodiac = value; }
        }

        public string ChineseZodiac
        {
            get { return _chineseZodiac; }
            set { _chineseZodiac = value; }
        }
        #endregion

        #region Constructor
        public User(DateTime birthDate) { BirthDate = birthDate; }
        #endregion


        private void fillProperties()
        {
            CalcWesternZodiac();
            CalcChineseZodiac();
        }

        private void CalcWesternZodiac()
        {
            int m = BirthDate.Month;
            switch (m)
            {
                case 1:
                    WesternZodiac = BirthDate.Day < 20 ? _westernZodiacSigns[11] : _westernZodiacSigns[m - 1];
                    break;
                case 2:
                    WesternZodiac = BirthDate.Day < 19 ? _westernZodiacSigns[m - 2] : _westernZodiacSigns[m - 1];
                    break;
                case 3:
                    WesternZodiac = BirthDate.Day < 21 ? _westernZodiacSigns[m - 2] : _westernZodiacSigns[m - 1];
                    break;
                case 4:
                    WesternZodiac = BirthDate.Day < 20 ? _westernZodiacSigns[m - 2] : _westernZodiacSigns[m - 1];
                    break;
                case 5:
                    WesternZodiac = BirthDate.Day < 21 ? _westernZodiacSigns[m - 2] : _westernZodiacSigns[m - 1];
                    break;
                case 6:
                    WesternZodiac = BirthDate.Day < 21 ? _westernZodiacSigns[m - 2] : _westernZodiacSigns[m - 1];
                    break;
                case 7:
                    WesternZodiac = BirthDate.Day < 23 ? _westernZodiacSigns[m - 2] : _westernZodiacSigns[m - 1];
                    break;
                case 8:
                    WesternZodiac = BirthDate.Day < 23 ? _westernZodiacSigns[m - 2] : _westernZodiacSigns[m - 1];
                    break;
                case 9:
                    WesternZodiac = BirthDate.Day < 23 ? _westernZodiacSigns[m - 2] : _westernZodiacSigns[m - 1];
                    break;
                case 10:
                    WesternZodiac = BirthDate.Day < 23 ? _westernZodiacSigns[m - 2] : _westernZodiacSigns[m - 1];
                    break;
                case 11:
                    WesternZodiac = BirthDate.Day < 22 ? _westernZodiacSigns[m - 2] : _westernZodiacSigns[m - 1];
                    break;
                case 12:
                    WesternZodiac = BirthDate.Day < 22 ? _westernZodiacSigns[m - 2] : _westernZodiacSigns[m - 1];
                    break;
            }
        }

        private void CalcChineseZodiac() { ChineseZodiac = _chineseZodiacSigns[_birthDate.Year % 12]; }
    }
}
