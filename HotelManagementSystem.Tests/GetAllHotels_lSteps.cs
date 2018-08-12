using FluentAssertions;
using HotelManagementSystem.Models;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace HotelManagementSystem.Tests
{
    [Binding]
    public class GetAllHotels_lSteps
    {
        List<Hotel> hotel = new List<Hotel>();

        [When(@"User calls List_Of_Hotel api")]
         public void WhenListOfHotel()
        {
            hotel = HotelsApiCaller.GetAllHotels();
        }

        [Then(@"All Hotels should be displayed in the response")]
        public void ThenAllHotelsShouldBeDisplayedInTheResponse()
        {
            
            hotel.Find(x => x.Id == (HotelsApiCaller.hotel_Id.Find(y => y == x.Id))).Should().NotBeNull(string.Format("All hotels are not present in the response"));


        }
    }
}
