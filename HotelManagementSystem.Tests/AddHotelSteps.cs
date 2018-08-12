using FluentAssertions;
using HotelManagementSystem.Models;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace HotelManagementSystem.Tests
{
    [Binding]
    public class AddHotelSteps
    {
        private Hotel hotel = new Hotel();
        private List<Hotel> hotels = new List<Hotel>();
        //public static List<int> ID = new List<int>();

        [Given(@"User provided valid Id '(.*)'  and '(.*)'for hotel")]
        public void GivenUserProvidedValidIdAndForHotel(int id, string name)
        {
            hotel.Id = id;
            hotel.Name = name;
            
        }

        [Given(@"Use has added required details for hotel")]
        public void GivenUseHasAddedRequiredDetailsForHotel()
        {
            SetHotelBasicDetails();
        }

        [Given(@"User call AddHotel api")]
        [When(@"User calls AddHotel api")]
        public void WhenUserCallsAddHotelApi()
        {
            HotelsApiCaller.hotel_Id.Add(hotel.Id);
            hotels = HotelsApiCaller.AddHotel(hotel);
        }

        [Then(@"Hotel with id '(.*)' should be present in the response")]
        public void ThenHotelWithNameShouldBePresentInTheResponse(int id)
        {
            hotel = hotels.Find(htl => htl.Id==id);
            hotel.Should().NotBeNull(string.Format("Hotel with name {0} not found in response",hotel.Name));
        }


        private void SetHotelBasicDetails()
        {
            hotel.ImageURLs = new List<string>() { "image1", "image2" };
            hotel.LocationCode = "Location";
            hotel.Rooms = new List<Room>() { new Room() { NoOfRoomsAvailable = 10, RoomType = "delux" } };
            hotel.Address = "Address1";
            hotel.Amenities = new List<string>() { "swimming pool", "gymnasium" };
        }
    }
}
