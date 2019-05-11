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
            var newEvent = new EventsFields();
            newEvent.Name = "test";
            var addNewEvent = new EventsFromJson();

            //ACT

            var sut = addNewEvent.Create(newEvent);

            //ASSERT

            sut.Name.Should().Be(newEvent.Name);
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

            sut[0].TicketsType.Should().Be(type);
        }        
    }
}
