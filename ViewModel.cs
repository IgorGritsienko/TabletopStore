using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TabletopStore
{
    internal class ViewModel : INotifyPropertyChanged
    {
        private TabletopViewModel selectedGame;

        public ObservableCollection<TabletopViewModel> Tabletops { get; }
        public ObservableCollection<TabletopViewModel> futureTabletops { get; }

        public TabletopViewModel SelectedGame
        {
            get { return selectedGame; }
            set
            {
                selectedGame = value;
                OnPropertyChanged(nameof(SelectedGame));
            }
        }

        public ViewModel()
        {
            Tabletops = new ObservableCollection<TabletopViewModel>
            {
                new TabletopViewModel(new TabletopGame { Name = "Tyrants of the Underdark", Brand = "Wizards of the Coast",
                    Price = 3000, Description = string.Empty, ImagePath = "/Images/Tyrant.jpg" }),
                new TabletopViewModel(new TabletopGame { Name = "Dungeon Mayhem", Brand = "Dungeons & Dragons",
                    Price = 2500, Description = string.Empty, ImagePath = "/Images/DungeonMayhem.jpg" }),
                new TabletopViewModel(new TabletopGame { Name = "Tomb of Annihilation", Brand = "WizKids",
                    Price = 4200, Description = string.Empty, ImagePath = "/Images/TombOfAnnihilation.jpg" }),
            };

            futureTabletops = new ObservableCollection<TabletopViewModel>
            {
                new TabletopViewModel(new TabletopGame { Name = "Avalon Hill", Brand = "Avalon Hill",
                    Price = 0, Description = "Never Split the Party…Unless Someone is the Traitor!", ImagePath = "/Images/AvalonHill.jpg" }),
                new TabletopViewModel(new TabletopGame { Name = "Dragonfire", Brand = "Bushiroad",
                    Price = 0, Description = "Dragon fire is a 3 to 6 player cooperative deck builder game set on this planet’s greatest roleplaying game setting, Dungeons Dragons",
                    ImagePath = "/Images/Dragonfire.jpg" }),
            };
        }

        // команда добавления нового объекта
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??= new RelayCommand(obj =>
                  {
                      TabletopViewModel tabletopGame = new TabletopViewModel(new TabletopGame());
                      Tabletops.Insert(0, tabletopGame);
                      SelectedGame = tabletopGame;
                  });
            }
        }

        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??= new RelayCommand(obj =>
                    {
                        if (obj is TabletopViewModel tabletopGame)
                        {
                            Tabletops.Remove(tabletopGame);
                        }
                    },
                    (obj) => Tabletops.Count > 0);
            }
        }

        private RelayCommand doubleCommand;
        public RelayCommand DoubleCommand
        {
            get
            {
                return doubleCommand ??= new RelayCommand(obj =>
                {
                    if (obj is TabletopViewModel tabletopGame)
                    {
                        TabletopViewModel phoneCopy = new TabletopViewModel(new TabletopGame
                        {
                            //Company = tabletopGame.Company,
                            //Price = tabletopGame.Price,
                            //Title = tabletopGame.Title
                        });

                        Tabletops.Insert(0, phoneCopy);
                    }
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
