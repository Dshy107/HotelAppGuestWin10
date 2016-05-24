using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Notifications;
using HotelAppGuestWin10.Annotations;
using HotelAppGuestWin10.Facade;
using HotelAppGuestWin10.Model;

namespace HotelAppGuestWin10.ViewModel
{
    public class SingletonViewModel : INotifyPropertyChanged
    {
        private bool _isBusy;
         public bool IsBusy
        {
            get { return _isBusy; }
             set
             {
                 _isBusy = value;
                 OnPropertyChanged(nameof(IsBusy));
             }
        }

        public Guest SelectedGuestComboBox
        {
            get { return _selectedGuestComboBox; }
            set
            {
                _selectedGuestComboBox = value; 
                OnPropertyChanged();
            }
        }

        private Guest _selectedGuest;
        private Guest _selectedGuestComboBox;
        private static SingletonViewModel InstanceSingletonViewModel { get; set; } = new SingletonViewModel();

        public ObservableCollection<Guest>  GuestList { get; private set; }

        public Guest NewGuest { get; set; }

        public Guest SelectedGuest
        {
            get { return _selectedGuest; }
            set
            {
                _selectedGuest = value;
                OnPropertyChanged();
            }
        }

        private SingletonViewModel()
        {
            GuestList = new ObservableCollection<Guest>();
            NewGuest = new Guest();
            SelectedGuest = new Guest();
            LoadGuestsAsync();
        }

        public static SingletonViewModel Instance
        {
            get { 
                if (InstanceSingletonViewModel == null)
                    return InstanceSingletonViewModel = new SingletonViewModel();
                else
                    return InstanceSingletonViewModel;
            }
        }

        public void AddGuest(Guest newGuest)
        {
            GuestList.Add(newGuest);
            var response = FacadeGuest.AddSingleGuestAsync(newGuest);
        }

        public void DeleteGuest(Guest deleteGuest)
        {

        }

        public async void LoadGuestsAsync()
        {

            try
            {
                IsBusy = true;

                this.GuestList.Clear();
                foreach (var g in await FacadeGuest.GetAllGuestAsync())
                {
                    this.GuestList.Add(g);
                }
            }
            catch (Exception e)
            {
                //TODO her skal der vises en meddelse til brugeren hvis noget går galt
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
