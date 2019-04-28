using Common;
using Common.Models;
using Common.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CultureInGdansk.Tests.BussinessLogicTests
{
    public class BussinessLogicShould : EventsFromJson
    {
        [Fact]
        public void GetDataFromAPI()
        {
            //ACT

           var result = GetJson();

            //ASSERT

           Assert.NotEmpty(result);

        }
       
        //[Fact]
        //public void CreateUserOwnEvent()
        //{
        //    RootObject newEvent = new RootObject()
        //    {
            
        //    newEvent.name = "test"
            
        //    }
        //}

        [Fact]
        public void FilterEventsByTicketsType()
        {
           string type = "free";
           var Filtered = new EventsFromJson();
            Filtered.GetJson();

            //ACT

            var sut = Filtered.GetEventsByTicketType(type);

            //ASSERT

            sut[0].tickets.type.Should().Be(type);

            
        }

    }
}
