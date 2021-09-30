using LandonHotel.Controllers;
using System;
using Xunit;
using Moq;
using LandonHotel.Services;
using System.Collections.Generic;
using LandonHotel.Data;
using LandonHotel.Repositories;

namespace Test
{
    public class BookingControllerTest
    {
        public Mock<IRoomService> _roomService;

        public BookingControllerTest()
        {
            _roomService = new Mock<IRoomService>();
        }
        
        [Fact]
        public void Test_Calling_BookingController_Method_GetAllRooms_Once()
        {
            //arrange
            BookingController controller = new BookingController(_roomService.Object);
            //act
            var response = controller.Index();
            //assert
            _roomService.Verify(x => x.GetAllRooms(), Times.Once);

        }

        [Fact]
        //[MemberData(nameof(Data))]
        public void Test_GetRooms_SHouldReturnTrue(/*List<Room> expectedList*/)
        {

            //arrange
            //BookingController controller = new BookingController(_roomService.Object);
            IRoomsRepository roomRepo = new RoomsRepository();
            //act
            var response = roomRepo.GetRooms();
            //assert
            Assert.Equal(2, response.Count);

        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[]
                {
                    "Winchester",
                    true,
                    5,
                    200
                },
                new object[]
                {
                    "Piccadilly",
                    false,
                    3,
                    250
                }
            };
    }
}
