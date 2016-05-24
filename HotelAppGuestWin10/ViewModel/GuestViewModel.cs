using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAppGuestWin10.ViewModel
{
    public class GuestViewModel
    {
        public SingletonViewModel SingletonViewModel { get; private set; }

        //public RelayCommand GetGuestsCommand 

        private RelayCommand getGuestCommand;

        public RelayCommand GetGuestCommand
        {
            get { return getGuestCommand; }
            set { getGuestCommand = value; }
        }


        public GuestViewModel()
        {
            this.SingletonViewModel = SingletonViewModel.Instance;
            GetGuestCommand = new RelayCommand(SingletonViewModel.LoadGuestsAsync);
        }
    }
}
