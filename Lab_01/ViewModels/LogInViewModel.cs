using System;
using System.Threading.Tasks;
using System.Windows;

namespace KMA.CSharp2020.Lab01
{
    internal class LogInViewModel : BaseViewModel
    {
        #region Fields
        private DateTime _birthDate;
        private int _age;
        private string _westernZodiac;
        private string _chineseZodiac;
        private User _user;

        #region Commands
        private RelayCommand<object> _calculateCommand;
        #endregion

        #endregion

        #region Properties
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set
            {
                _birthDate = value;
                OnPropertyChanged();
            }
        }
        public int Age
        {
            get { return _user == null ? 0 : _user.Age; }
            set
            {
                _age = value;
                OnPropertyChanged();
            }
        }
        public string WesternZodiac
        {
            get { return _user == null ? "" : _user.WesternZodiac; }
            set
            {
                _westernZodiac = value;
                OnPropertyChanged();
            }
        }
        public string ChineseZodiac
        {
            get { return _user == null ? "" : _user.ChineseZodiac; }
            set
            {
                _chineseZodiac = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Commands
        public RelayCommand<Object> CalculateCommand
        {
            get { return _calculateCommand ?? (_calculateCommand = new RelayCommand<object>(Calculate, o => CanExecuteCommand())); }
        }

        #endregion

        #region Methods
        public bool CanExecuteCommand() { return true; }

        private async void Calculate(object obj)
        {
            if (_birthDate.Year < DateTime.Today.Year - 135 || _birthDate > DateTime.Today)
            {
                MessageBox.Show("Wrong value", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (_user == null) _user = new User(_birthDate);
            else _user.BirthDate = _birthDate;
            await Task.Run(() => ChineseZodiac = _user.ChineseZodiac);
            await Task.Run(() => WesternZodiac = _user.WesternZodiac);
            Age = _user.Age;
            if (BirthDate.Month == DateTime.Today.Month && BirthDate.Day == DateTime.Today.Day) MessageBox.Show("Happy Birthday!", "Congratulations!", MessageBoxButton.OK, MessageBoxImage.Question);

        }
        #endregion
    }
}