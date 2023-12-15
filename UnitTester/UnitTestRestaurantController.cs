using BusinessLayer.Interfaces;
using BusinessLayer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using RestaurantAPI.Controllers;
using RestaurantAPI.DTOIn;
using RestaurantAPI.DTOs;
using System;
using Xunit;

namespace UnitTester
{
    public class UnitTestRestaurantController
    {
        private readonly Mock<IRestaurantService> mockRestaurantService;
        private readonly Mock<ILogger<RestaurantController>> mockLogger;
        private readonly RestaurantController restaurantController;
        ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddFile("./Logs/ReservationLogs/ReservationLog.txt");
        });

        public UnitTestRestaurantController()
        {
            mockRestaurantService = new Mock<IRestaurantService>();
            mockLogger = new Mock<ILogger<RestaurantController>>();
            restaurantController = new RestaurantController(
                mockRestaurantService.Object,
                loggerFactory
            );
        }

        //[Fact]
        //public void GetRestaurant_ReturnsOkResult_WithRestaurantDTO()
        //{
        //    // Arrange
        //    var existingRestaurant = new Restaurant { RestaurantID = 1 };

        //    mockRestaurantService
        //        .Setup(service => service.GetRestaurantById(1))
        //        .Returns(existingRestaurant);

        //    // Act
        //    var result = restaurantController.GetRestaurant(1);

        //    // Assert
        //    Assert.IsType<OkObjectResult>(result.Result);
        //}

        [Fact]
        public void GetRestaurant_WithUnknownID_ReturnsNotFound()
        {
            // Arrange
            mockRestaurantService
                .Setup(service => service.GetRestaurantById(1))
                .Returns((Restaurant)null);

            // Act
            var result = restaurantController.GetRestaurant(1);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        //[Fact]
        //public void CreateRestaurant_ReturnsCreatedAtAction()
        //{
        //    // Arrange
        //    var restaurantDTO = new RestaurantDTO();
        //    var createdRestaurant = new Restaurant { RestaurantID = 1 };

        //    mockRestaurantService
        //        .Setup(service => service.AddRestaurant(It.IsAny<Restaurant>()))
        //        .Callback<Restaurant>(r => createdRestaurant = r);

        //    // Act
        //    var result = restaurantController.CreateRestaurant(restaurantDTO);

        //    // Assert
        //    Assert.IsType<CreatedAtActionResult>(result.Result);
        //}

        [Fact]
        public void CreateRestaurant_WithException_ReturnsInternalServerError()
        {
            // Arrange
            mockRestaurantService
                .Setup(service => service.AddRestaurant(It.IsAny<Restaurant>()))
                .Throws(new Exception());

            // Act
            var result = restaurantController.CreateRestaurant(new RestaurantDTOIn());

            // Assert
            Assert.IsType<ObjectResult>(result.Result);
            var statusCodeResult = (ObjectResult)result.Result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        //[Fact]
        //public void UpdateRestaurant_ReturnsNoContent()
        //{
        //    // Arrange
        //    var restaurantDTO = new RestaurantDTO();
        //    mockRestaurantService
        //        .Setup(service => service.GetRestaurantById(1))
        //        .Returns(new Restaurant { RestaurantID = 1 });

        //    // Act
        //    var result = restaurantController.UpdateRestaurant(1, restaurantDTO);

        //    // Assert
        //    Assert.IsType<NoContentResult>(result);
        //}

        //[Fact]
        //public void UpdateRestaurant_WithUnknownID_ReturnsNotFound()
        //{
        //    // Arrange
        //    var restaurantDTO = new RestaurantDTO();
        //    mockRestaurantService
        //        .Setup(service => service.GetRestaurantById(1))
        //        .Returns((Restaurant)null);

        //    // Act
        //    var result = restaurantController.UpdateRestaurant(1, restaurantDTO);

        //    // Assert
        //    Assert.IsType<NotFoundResult>(result);
        //}

        [Fact]
        public void DeleteRestaurant_ReturnsNoContent()
        {
            // Arrange
            mockRestaurantService
                .Setup(service => service.GetRestaurantById(1))
                .Returns(new Restaurant { RestaurantID = 1 });

            // Act
            var result = restaurantController.DeleteRestaurant(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void DeleteRestaurant_WithUnknownID_ReturnsNotFound()
        {
            // Arrange
            mockRestaurantService
                .Setup(service => service.GetRestaurantById(1))
                .Returns((Restaurant)null);

            // Act
            var result = restaurantController.DeleteRestaurant(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
