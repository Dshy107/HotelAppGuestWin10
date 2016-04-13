using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace HotelRESTConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            const string serverUrl = "http://localhost.fiddler:16149";




            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlString = "api/hotels/5";
                try
                {
                    HttpResponseMessage response = client.GetAsync(urlString).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var hotel = response.Content.ReadAsAsync<Hotel>().Result;

                            Console.WriteLine("hotel : " + hotel.Name + "hoteladresse : " + hotel.Address);

                        foreach (var room in hotel.Room)
                        {
                            Console.WriteLine("room n0: "+ room.Room_No +" price: "+room.Price);
                        }

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Der er sket en fejl : " + e.Message);
                }
            }

            Console.ReadLine();
            return;



            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();


                string urlString = "api/hotels/2000";
                HttpResponseMessage response = client.DeleteAsync(urlString).Result;


                if (response.IsSuccessStatusCode)

                {
                    Console.WriteLine("Du har slettet et hotel");
                    Console.WriteLine("Statuskode : " + response.StatusCode);

                }

                else

                {
                    Console.WriteLine("Fejl, hotellet blev ikke slettet");
                    Console.WriteLine("Statuskode : " + response.StatusCode);

                }
            }

            Console.ReadLine();

            return;
            var MyBestNewHotel = new Hotel()
            {
                Name = "First hotel"
                ,
                Address = "Rampelyset 12"
                ,
                Hotel_No = 3000
            };

            MyBestNewHotel.Name = "Mysecond Hotel";

            Console.WriteLine("Nu kan du attache debuggeren");
            Console.ReadLine();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();


                var response = client.PutAsJsonAsync<Hotel>("API/Hotels/3000", MyBestNewHotel).Result;

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Hotellet er opdateret");
                }
                else
                {
                    Console.WriteLine("Fejl, hotellet blev ikke opdateret");
                }


            }
            Console.ReadLine();
            return;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();

                var response = client.PostAsJsonAsync<Hotel>("API/Hotels", MyBestNewHotel).Result;

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Hotellet er oprettet");
                    Console.WriteLine("Statuskode :" + response.StatusCode);
                }
                else
                {
                    Console.WriteLine("Fejl, hotellet er ikke oprettet");
                    Console.WriteLine("Statuskode :" + response.StatusCode);
                }


            }


            Console.ReadLine();
            return;


            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string urlString = "api/hotels";

                try
                {
                    HttpResponseMessage response = client.GetAsync(urlString).Result;
                    if (response.IsSuccessStatusCode)

                    {
                        var hotelList = response.Content.ReadAsAsync<List<Hotel>>().Result;
                        //.Content.ReadAsAsync<List<Hotel>>().Result;

                        foreach (var hotel in hotelList)
                        {
                            Console.WriteLine("hotel : " + hotel.Name + "hoteladresse : " + hotel.Address);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Der er sket en fejl " + e.Message);                    
                }


                Console.ReadLine();






            }





            return;

            int hotelnr = 1017;

            var MyNewHotel = new Hotel()
            {
                Hotel_No = hotelnr,
                Address = "Fiddlerhotel "+hotelnr,
                Name = "Fiddler hotel",
            };


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlString = "api/hotels/1014";
                try
                {
                    HttpResponseMessage response = client.DeleteAsync(urlString).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Du har slettet et hotel");
                        Console.WriteLine("Statuskode : " + response.StatusCode);
                    }
                    else
                    {
                        Console.WriteLine("Fejl, hotellet blev ikke slettet");
                        Console.WriteLine("Statuskode : " + response.StatusCode);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Der er sket en fejl : " + e.Message);
                }

            }

            Console.ReadLine();
            


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();

                try
                {
                    var response = client.PostAsJsonAsync<Hotel>("API/Hotels", MyNewHotel).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Du har indsat et nyt hotel");
                        Console.WriteLine("Post Content: " + response.Content.ReadAsStringAsync());
                    }
                    else
                    {
                        Console.WriteLine("Fejl, hotellet blev ikke indsat");
                        Console.WriteLine("Statuskode : " + response.StatusCode);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Der er sket en fejl : " + e.Message);
                }
            }

            var MyUpdatedHotel = new Hotel()
            {
                Hotel_No = 1015,
                Address = "Fiddlerhotel " + hotelnr,
                Name = "Fiddler hotel",
            };

            MyUpdatedHotel.Name = "EASJ Hotel";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();

                try
                {
                    var response = client.PutAsJsonAsync<Hotel>("API/Hotels/1015", MyNewHotel).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Du har opdateret et hotel");
                        Console.WriteLine("Statuskode : " + response.StatusCode);
                    }
                    else
                    {
                        Console.WriteLine("Fejl, hotellet blev ikke opdateret");
                        Console.WriteLine("Statuskode : " + response.StatusCode);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Der er sket en fejl : " + e.Message);
                }
            }


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlString = "api/hotels/1015" + hotelnr;
                try
                {
                    HttpResponseMessage response = client.DeleteAsync(urlString).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Du har slettet et hotel");
                        Console.WriteLine("Statuskode : " + response.StatusCode);
                    }
                    else
                    {
                        Console.WriteLine("Fejl, hotellet blev ikke slettet");
                        Console.WriteLine("Statuskode : " + response.StatusCode);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Der er sket en fejl : " + e.Message);
                }

            }

            Console.ReadLine();
            return;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string urlString = "api/hotels/" + hotelnr;
                HttpResponseMessage response =  client.GetAsync(urlString).Result;
                Console.WriteLine("GetAsync : " + urlString);
                Console.WriteLine("Status code : " + response.StatusCode);
                Console.WriteLine(response.Headers.ToString());
                Console.WriteLine("Location : " + response.Headers.Location );
                if (response.IsSuccessStatusCode)
                {
                    var hotel = response.Content.ReadAsAsync<Hotel>().Result;
                    Console.WriteLine("hotel : " + hotel.Name + "hoteladresse : "+hotel.Address);
                }

            }


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlString = "api/hotels";
                try
                {
                    HttpResponseMessage response = client.GetAsync(urlString).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var hotelList = response.Content.ReadAsAsync<List<Hotel>>().Result;

                        foreach (var hotel in hotelList)
                        {
                            Console.WriteLine("hotel : " + hotel.Name + "hoteladresse : " + hotel.Address);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Der er sket en fejl : " +e.Message );
                }
            }


            Console.ReadLine();

            //Guest nygæst = new Guest();



        }



        /// <summary>
        /// Select (HTTP Get) hotel number 3 and put it into an List of type Hotel (List<Hotel>)
        /// </summary>
        /// <param name="serverUrl"></param>
        /// <param name="selectHotel">the hotels number ex. 3</param>
        private static void Excercise1(string serverUrl, int selectHotel)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string urlString = "api/hotels/" + selectHotel;

                try
                {
                    var response = client.GetAsync(urlString).Result;
                    Console.WriteLine("GetAsync : " + urlString);
                    if (response.IsSuccessStatusCode)
                    {
                        var hotel = response.Content.ReadAsAsync<Hotel>().Result;
                        Console.WriteLine("hotel : " + hotel.ToString());
                    }
                    else
                    {
                        Console.WriteLine("Error: " + response.StatusCode);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception : " +e.Message);
                }

            }
        }

        /// <summary>
        /// Exercise 2:
        /// Select (HTTP Get) all hotels and all of them located in Roskilde 
        /// should be put into a list of hotels using LINQ
        /// </summary>
        /// <param name="serverUrl"></param>
        /// <param name="hotellist"></param>
        private static void Exercise2(string serverUrl, List<Hotel> hotellist)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.GetAsync("api/hotels").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var hotels = response.Content.ReadAsAsync<IEnumerable<Hotel>>().Result;

                        //finds the hotels located in Roskilde
                        var roskildeHotels = hotels.Where(x => x.Address.Contains("Roskilde")).ToList();

                        hotellist.AddRange(roskildeHotels);

                        Console.WriteLine("Hotels in Roskilde");
                        foreach (var rh in roskildeHotels)
                        {
                            Console.WriteLine(rh.ToString());
                        }
                    }
                    else
                    {
                        Console.WriteLine("Hotelsresponse error status code: " + response.StatusCode);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception : " + e.Message);
                }
            }
        }


        /// <summary>
        /// Exercise 3:
        /// Select (HTTP Get) all hotels, and all of them located in Roskilde 
        /// should be put into a list of hotels. Select all the rooms for this hotels(Roskilde hotels) 
        /// and put them into another list of rooms using LINQ
        /// </summary>
        /// <param name="serverUrl"></param>
        /// <param name="hotellist"></param>
        /// <param name="roomlist"></param>
        private static void Exercise3(string serverUrl,List<Hotel> hotellist, List<Room> roomlist)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.GetAsync("api/hotels").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var hotels = response.Content.ReadAsAsync<IEnumerable<Hotel>>().Result;

                        //finds the hotels located in Roskilde
                        var roskildeHotels = hotels.Where(x => x.Address.Contains("Roskilde")).ToList();

                        hotellist.AddRange(roskildeHotels);

                        Console.WriteLine("Hotels in Roskilde");
                        foreach (var rh in roskildeHotels)
                        {
                            Console.WriteLine(rh.ToString());
                        }

                        var roomresponse = client.GetAsync("api/rooms").Result;

                        if (roomresponse.IsSuccessStatusCode)
                        {
                            var rooms = roomresponse.Content.ReadAsAsync<IEnumerable<Room>>().Result;

                            //join rooms with the hotels
                            var roskildeRoom = from r in rooms
                                               join h in hotellist 
                                               on r.Hotel_No equals h.Hotel_No
                                               select r;

                            roomlist.AddRange(roskildeRoom.OrderBy(x => x.Hotel_No).ToList());

                            foreach (var rr in roomlist)
                            {
                                Console.WriteLine(rr.ToString());
                            }
                        }
                        else
                        {
                            Console.WriteLine("Roomresponse error status code: " + response.StatusCode);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Hotelsresponse error status code: " + response.StatusCode);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception : " + e.Message);
                }
            }
        }

        /// <summary>
        /// Update (HTTP Put) hotel number 3, change the name of the hotel. 
        /// You have to create a new Hotel Object with the data and then use this object 
        /// when you create your content string. 
        /// </summary>
        /// <param name="serverUrl"></param>
        private static void Exercise4(string serverUrl)
        {
            var hotel3 = new Hotel();
            hotel3 = null;
            int hotelno = 3;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();

                try
                {
                    //First thing to do is to get the hotel number 3 into the hotel3 variable by a http Get request
                    HttpResponseMessage hotelResponse = client.GetAsync("api/hotels/" + hotelno).Result;

                    if (hotelResponse.IsSuccessStatusCode)
                    {
                        hotel3 = hotelResponse.Content.ReadAsAsync<Hotel>().Result;
                        Console.WriteLine(hotel3.ToString());
                    }
                    else
                    {
                        Console.WriteLine("Error , we diden't get the Hotel ,see if the hotel exist in the database");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: for GET api/hotels/" + hotelno + " message: " + e.Message);
                }

                if (hotel3 != null)
                {
                    //Now change the name and address of the hotel3
                    hotel3.Name = "Great Hotel";
                    hotel3.Address = "Great Hotel Road 1";
                    try
                    {
                        //Using a Http Put Request we can update the Hotel number 3
                        HttpResponseMessage updateResponse = client.PutAsJsonAsync<Hotel>("api/hotels/" + hotelno, hotel3).Result;
                        if (updateResponse.IsSuccessStatusCode)
                        {
                            Console.WriteLine("Hotel is updated");
                        }
                        else
                        {
                            Console.WriteLine("Error: Hotel is NOT updated");
                        }

                        Console.WriteLine("status code : " + updateResponse.StatusCode);

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception: for PUT api/hotels/" + hotelno + " message: " + e.Message);

                    }
                }
            }
        }


        /// <summary>
        /// Insert (HTTP Post) a new hotel fx number 200. 
        /// </summary>
        /// <param name="serverUrl"></param>
        private static void Exercise5(string serverUrl)
        {
            Console.WriteLine("Exercise 5");
            Console.WriteLine("Insert (HTTP Post) a new hotel fx number 200");

            int myNewHotelNo = 200;
            //First we create the new hotel object
            var myNewHotel = new Hotel()
            {
                Hotel_No = myNewHotelNo,
                Address = "Fiddlerhotel 1",
                Name = "Fiddler hotel",
                Room = new List<Room>()
            };

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();

                var responsePost = client.PostAsJsonAsync<Hotel>("api/hotels", myNewHotel).Result;
                Console.WriteLine("PostAsync");
                Console.WriteLine("Status code " + responsePost.StatusCode);

                if (responsePost.IsSuccessStatusCode)
                {
                    Console.WriteLine("Success, the hotel is added");
                    Console.WriteLine("Status code  POST" + responsePost.StatusCode);

                    //Success , Now we can get the hotel by a Http GET to see if it is in the Database
                    var responseHotel = client.GetAsync("api/hotels/" + myNewHotelNo).Result;
                    Console.WriteLine("GetAsync");

                    if (responseHotel.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Success to GET the Hotel200");
                        var hotel200 = responseHotel.Content.ReadAsAsync<Hotel>().Result;
                        Console.WriteLine(hotel200.ToString());
                    }
                    else
                    {
                        Console.WriteLine("Error, diden't GET the hotel200");
                    }
                    Console.WriteLine("Statuscode GET:" + responseHotel.StatusCode);
                }
                else
                {
                    Console.WriteLine("Error the HTTP POST diden't work");
                    Console.WriteLine("Statuscode POST:" + responsePost.StatusCode);

                }
            }
        }


        /// <summary>
        /// Exercise 6:
        /// Delete (HTTP Delete) the Hotel number 200.
        /// </summary>
        /// <param name="serverUrl"></param>
        /// <param name="deleteHotelNo">The hotel number to delete ex. 200</param>
        private static void Exercise6(string serverUrl, int deleteHotelNo)
        {
            Console.WriteLine("Exercise6");
            Console.WriteLine(" 6) Delete(HTTP Delete) the Hotel number 200");
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();

                try
                {
                    string deleteUrl = "api/hotels/" + deleteHotelNo;
                    HttpResponseMessage response = client.DeleteAsync(deleteUrl).Result;

                    Console.WriteLine("Delete Async " + deleteUrl);
                    Console.WriteLine(response.StatusCode);

                    Console.WriteLine(response.IsSuccessStatusCode
                        ? "Succcesfull delete"
                        : "Someting went wrong, hotel not deleted");
                }
                catch (Exception e)
                {
                    Console.WriteLine("EXCEPTION HTTP DELETE:  " + e.Message);
                }
            }
        }


        /// <summary>
        /// Exercise7:
        /// Insert a new Room on Hotel number 4 (POST)
        /// </summary>
        /// <param name="hotelNo"></param>
        /// <param name="roomNo"></param>
        /// <param name="serverUrl"></param>
        private static void exercise7(int hotelNo, int roomNo, string serverUrl)
        {
            Console.WriteLine("7) Insert a new Room on Hotel number 4");

            //First we create the new room object
            Room myNewRoom = new Room()
            {
                Hotel_No = hotelNo,
                Price = 250.0,
                Room_No = roomNo,
                Types = "S"
            };
            CreateRoom(serverUrl, myNewRoom);
        }

        /// <summary>
        /// a method to create a new room 
        /// </summary>
        /// <param name="serverUrl"></param>
        /// <param name="myNewRoom"></param>
        private static void CreateRoom(string serverUrl, Room myNewRoom)
        {

            //Create a Http post
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string posturl = "api/rooms";
                try
                {
                    HttpResponseMessage response = client.PostAsJsonAsync(posturl, myNewRoom).Result;

                    Console.WriteLine("Post async " + posturl);

                    Console.WriteLine(response.IsSuccessStatusCode
                    ? "Succcesfull added the room"
                    : "Someting went wrong, room not added");

                    Console.WriteLine("Status code " + response.StatusCode);

                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception http post Room:  " + e.Message);
                }

            }
        }



        /// <summary>
        /// Exercise8:
        /// Update all hotels in roskilde increase the price of a single room with 20%, 
        /// show the prices before and after the update. 
        /// </summary>
        /// <param name="serverUrl"></param>
        /// <param name="hotellist"></param>
        /// <param name="roomlist"></param>
        private static void Exercise8(string serverUrl, List<Hotel> hotellist, List<Room> roomlist)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();

                try
                {
                    var response = client.GetAsync("api/hotels").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Succes we get the hotels");
                        var hotels = response.Content.ReadAsAsync<IEnumerable<Hotel>>().Result;

                        //filter so we only have the hotels in Roskilde
                        var roskildeHotels = hotels.Where(x => x.Address.Contains("Roskilde")).ToList();

                        hotellist.AddRange(roskildeHotels);

                        Console.WriteLine("Hotels in roskilde");
                        foreach (var rh in roskildeHotels)
                        {
                            Console.WriteLine(rh.ToString());
                        }

                        //fetch all the rooms
                        var roomresponse = client.GetAsync("api/rooms").Result;

                        if (roomresponse.IsSuccessStatusCode)
                        {
                            var rooms = roomresponse.Content.ReadAsAsync<IEnumerable<Room>>().Result;

                            //LINQ to join the two list , we only want the single rooms "S"
                            var roskildeRoom = from r in rooms
                                               join h in hotellist on r.Hotel_No equals h.Hotel_No
                                               where r.Types == "S"
                                               select new Room()
                                               {
                                                   Hotel_No = r.Hotel_No,
                                                   Price = r.Price,
                                                   Room_No = r.Room_No,
                                                   Types = r.Types
                                               };

                            roomlist.AddRange(roskildeRoom.OrderBy(x => x.Hotel_No).ToList());

                            Console.WriteLine("How many rooms will be updated: " + roomlist.Count);

                            foreach (var room in roomlist)
                            {
                                try
                                {
                                    Console.WriteLine("Room Price before : " + room.Price);

                                    //increase roomprice with 20%
                                    room.Price *= 1.2;
                                    string putRoom = "api/rooms/" + room.Room_No;

                                    var roomResponse = client.PutAsJsonAsync(putRoom, room).Result;
                                    Console.WriteLine("StatusCode " + roomResponse.StatusCode);
                                    Console.WriteLine(room.ToString());

                                    if (roomResponse.IsSuccessStatusCode)
                                    {
                                        Console.WriteLine("Succes: updated the room no: " + room.Room_No);
                                        Console.WriteLine("Room price after " + room.Price);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Upps something went wrong for room no: " + room.Room_No);
                                    }
                                }
                                catch (Exception exception)
                                {

                                    Console.WriteLine("Exception : "+exception.Message);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Room response error status code: " + response.StatusCode);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Hotel GET response error status code: " + response.StatusCode);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception:  " + e.Message);
                }
            }
        }



    }
}    

