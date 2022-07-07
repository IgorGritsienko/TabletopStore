using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TabletopStore
{
    public class TabletopViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        private readonly TabletopGame _tabletopGame;

        public TabletopViewModel(TabletopGame tabletopGame)
        {
            _tabletopGame = tabletopGame;
        }

        public string this[string columnName]
        { 
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case nameof(Price):
                        if (_tabletopGame.Price < 0)
                        {
                            error = "Отрицательная цена";
                        }
                        break;
                }
                return error;
            }
        }
       
        public string Name
        {
            get { return _tabletopGame.Name; }
            set
            {
                _tabletopGame.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Brand
        {
            get { return _tabletopGame.Brand; }
            set
            {
                _tabletopGame.Brand = value;
                OnPropertyChanged(nameof(Brand));
            }
        }

        public int Price
        {
            get { return _tabletopGame.Price; }
            set
            {
                _tabletopGame.Price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        public string ImagePath
        {
            get { return _tabletopGame.ImagePath; }
            set
            {
                _tabletopGame.ImagePath = value;
                OnPropertyChanged(nameof(ImagePath));
            }
        }

        public string Description
        { 
            get { return _tabletopGame.Description;} 
            set
            {
                _tabletopGame.Description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public string Error => throw new NotImplementedException();

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            //if (PropertyChanged != null)
            //    PropertyChanged(this, new PropertyChangedEventArgs(prop));

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
