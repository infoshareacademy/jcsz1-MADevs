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

        [Fact]
        public void CreateUserOwnEvent()
        {
            //ARRANGE
            var newEvent = new RootObject();
            newEvent.name = "test";
            var addNewEvent = new EventsFromJson();

            //ACT

            var sut = addNewEvent.Create(newEvent);

            //ASSERT

            sut.name.Should().Be(newEvent.name);
        }


        [Fact]
        public void FilterEventsByTicketsType()
        {
            //ARRANGE

            string type = "free";
            var filtered = new EventsFromJson();
            filtered.GetJson();

            //ACT

            var sut = filtered.GetEventsByTicketType(type);

            //ASSERT

            sut[0].tickets.type.Should().Be(type);
        }        
    }
}
