﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Notifications;
using HotelAppGuestWin10.Model;

namespace HotelAppGuestWin10.Facade
{
    /// <summary>
    /// 
    /// </summary>
    public static class FacadeGuest
    {

        const string serverUrl = "http://webservicehotelguestasyncdemo20170403082435.azurewebsites.net/";
        //const string serverUrl = "http://localhost:55555";
        public static string messageError = "";

        /// <summary>
        /// Henter en enkelt gæst
        /// </summary>
        /// <param name="guestid"></param>
        /// <returns>liste af gæster </returns>
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
                    //var response = await client.GetAsync(urlString);
                    var response =  client.GetAsync(urlString).Result;
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
        //public static List<Guest> GetAllGuestAsync()
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
                    //var response =  client.GetAsync(urlString).Result;
                    if (response.IsSuccessStatusCode)
                    {

                        var guestList = await response.Content.ReadAsAsync<List<Guest>>();
                        //var guestList =  response.Content.ReadAsAsync<List<Guest>>(),Result;

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
