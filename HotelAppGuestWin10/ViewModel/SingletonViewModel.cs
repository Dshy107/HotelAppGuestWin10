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
        private static SingletonViewModel InstanceSingletonViewModel { get; set; } = new SingletonViewModel();

        public ObservableCollection<Guest>  GuestList { get; private set; }

        public Guest NewGuest { get; set; }
        public Guest SelectedGuest { get; set; }

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

        public async Task LoadGuestsAsync()
        {
            //this.GuestList.Clear();
            //this.GuestList.Add(new Guest() {Guest_No =200,Address = "testvej",Name = "test"});
            foreach (var g in await FacadeGuest.GetAllGuestAsync())
            {
                this.GuestList.Add(g);
            }

            //this.GuestList = new ObservableCollection<Guest>(FacadeGuest.GetAllGuestAsync().Result);;
        }


    }
}
