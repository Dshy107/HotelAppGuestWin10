using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Notifications;
using HotelAppGuestWin10.Facade;
using HotelAppGuestWin10.Model;

namespace HotelAppGuestWin10.ViewModel
{
    public class SingletonViewModel
    {
        private static SingletonViewModel InstanceSingletonViewModel { get; } = new SingletonViewModel();

        public ObservableCollection<Guest>  GuestList { get; private set; }

        public Guest NewGuest { get; set; }
        public Guest SelectedGuest { get; set; }

        private SingletonViewModel()
        {
            GuestList = new ObservableCollection<Guest>();
            NewGuest = new Guest();
            SelectedGuest = new Guest();
        }

        public static SingletonViewModel Instance
        {
            get { return InstanceSingletonViewModel; }
        }

        public void AddGuest(Guest newGuest)
        {
            GuestList.Add(newGuest);
            var response = FacadeGuest.AddSingleGuestAsync(newGuest);
        }

        public void DeleteGuest(Guest deleteGuest)
        {

        }

        public void LoadGuests()
        {
           this.GuestList.Clear();
           this.GuestList = new ObservableCollection<Guest>(FacadeGuest.GetAllGuestAsync().Result);;
        }


    }
}
