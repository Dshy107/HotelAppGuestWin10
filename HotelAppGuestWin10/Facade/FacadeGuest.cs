using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Notifications;
using HotelAppGuestWin10.Model;

namespace HotelAppGuestWin10.Facade
{
    public static class FacadeGuest
    {

        const string serverUrl = "http://localhost.fiddler:55555";
        //const string serverUrl = "http://localhost:55555";
        public static string messageError = "";

        public static async Task<Guest> GetSingleGuestAsync(int guestid)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlString = "api/Guests/" + guestid;
                try
                {
                    //var response =  client.GetAsync(urlString).Result;
                    var response = await client.GetAsync(urlString);
                    if (response.IsSuccessStatusCode)
                    {
                        
                        var guest =  response.Content.ReadAsAsync<Guest>().Result;

                        return guest;

                    }
                    messageError = response.StatusCode.ToString();
                    return null;

                }
                catch (Exception e)
                {
                    messageError = "Der er sket en fejl : " + e.Message;
                    return null;
                }
            }
        }

        public static async Task<List<Guest>> GetAllGuestAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlString = "api/Guests/";
                try
                {
                    //var response =  client.GetAsync(urlString).Result;
                    var response = await client.GetAsync(urlString);
                    if (response.IsSuccessStatusCode)
                    {

                        var guestList = response.Content.ReadAsAsync<List<Guest>>().Result;

                        return guestList;

                    }
                    messageError = response.StatusCode.ToString();
                    return null;

                }
                catch (Exception e)
                {
                    messageError = "Der er sket en fejl : " + e.Message;
                    return null;
                }
            }
        }


        public static async Task AddSingleGuestAsync(Guest newGuest)
        {
            
        }


        public static async Task UpdateSingleGuestAsync(Guest newGuest)
        {

        }

        public static async Task DeleteSingleGuestAsync(Guest newGuest)
        {

        }



    }
}
