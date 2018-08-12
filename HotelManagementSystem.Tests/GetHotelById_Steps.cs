using FluentAssertions;
using HotelManagementSystem.Models;
using System;
using TechTalk.SpecFlow;

namespace HotelManagementSystem.Tests
{
    [Binding]
    public class GetHotelById_Steps
    {

        private static Hotel hotel;
        [When(@"User calls Get_Hotel_By_Id '(.*)' api")]
        public void WhenGetHotelByIdCall(int id)
        {
            hotel = HotelsApiCaller.GetHotelById(id);
        }

        [Then(@"Hotel with id '(.*)' should be displayed in the response")]
        public void ThenHotelWithIdShouldBeDisplayedInTheResponse(int id)
        {
          
            hotel.Should().NotBeNull(string.Format("Hotel with name {0} not found in response", hotel.Name));
        }
    }
}
