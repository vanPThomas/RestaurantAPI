using BusinessLayer.Interfaces;
using BusinessLayer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using RestaurantAPI;
using RestaurantAPI.Controllers;
using RestaurantAPI.DTOs;
using System;
using Xunit;

namespace UnitTester
{
    public class UnitTestReservationController
    {
        private readonly Mock<IRepository<Reservation>> mockRepo;
        private readonly Mock<IReservationService> mockReservationService;
        private readonly Mock<ILogger<ReservationController>> mockLogger;
        private readonly ReservationController reservationController;
        ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddFile("./Logs/ReservationLogs/ReservationLog.txt");
        });

        public UnitTestReservationController()
        {
            mockRepo = new Mock<IRepository<Reservation>>();
            mockReservationService = new Mock<IReservationService>();
            mockLogger = new Mock<ILogger<ReservationController>>();
            reservationController = new ReservationController(
                mockReservationService.Object,
                loggerFactory
            );
        }

        [Fact]
        public void GetReservation_ReturnsOkResult_WithReservationDTO()
        {
            var user = new User { UserID = 1, Name = "JohnDoe" };

            var restaurant = new Restaurant { RestaurantID = 1, Name = "SampleRestaurant" };

            var reservation = new Reservation
            {
                ReservationID = 1,
                User = user,
                Restaurant = restaurant,
                ReservationNumber = 123,
                Date = DateTime.Now.Date,
                Time = new TimeSpan(18, 30, 0),
                TableNumber = 5,
                NumberOfSeats = 4
            };
            // Arrange
            mockReservationService
                .Setup(service => service.GetReservationById(1))
                .Returns(reservation);

            // Act
            var result = reservationController.GetReservation(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var reservationDTO = Assert.IsType<ReservationDTO>(okResult.Value);
            Assert.Equal(1, reservationDTO.RestaurantId);
        }

        [Fact]
        public void GetReservation_ThrowsException_WhenReservationIsNull()
        {
            // Arrange
            int reservationId = 1;
            mockReservationService
                .Setup(service => service.GetReservationById(reservationId))
                .Returns((Reservation)null);

            // Act & Assert
            Assert.Throws<NullException>(() => reservationController.GetReservation(reservationId));
        }

        [Fact]
        public void DeleteReservation_ReturnsNoContent()
        {
            // Arrange
            mockReservationService
                .Setup(service => service.GetReservationById(1))
                .Returns(new Reservation { ReservationID = 1 });

            // Act
            var result = reservationController.DeleteReservation(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void DeleteReservation_WithUnknownID_ReturnsNotFound()
        {
            // Arrange
            mockReservationService
                .Setup(service => service.GetReservationById(1))
                .Returns((Reservation)null);

            // Act
            var result = reservationController.DeleteReservation(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void UpdateReservation_ReturnsNoContent()
        {
            // Arrange
            var existingReservation = new Reservation { ReservationID = 1 };
            var updatedReservationDTO = new ReservationDTO { ReservationId = 1 };

            mockReservationService
                .Setup(service => service.GetReservationById(1))
                .Returns(existingReservation);

            // Act
            var result = reservationController.UpdateReservation(1, updatedReservationDTO);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void UpdateReservation_WithMismatchedId_ReturnsBadRequest()
        {
            // Arrange
            var updatedReservationDTO = new ReservationDTO { ReservationId = 2 };

            // Act
            var result = reservationController.UpdateReservation(1, updatedReservationDTO);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void UpdateReservation_WithUnknownId_ReturnsNotFound()
        {
            // Arrange
            var updatedReservationDTO = new ReservationDTO { ReservationId = 1 };

            mockReservationService
                .Setup(service => service.GetReservationById(1))
                .Returns((Reservation)null);

            // Act
            var result = reservationController.UpdateReservation(1, updatedReservationDTO);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void CreateReservation_ReturnsCreatedAtAction()
        {
            // Arrange
            var reservationDTO = new ReservationDTO();
            var createdReservation = new Reservation { ReservationID = 1 };

            mockReservationService
                .Setup(service => service.AddReservation(It.IsAny<Reservation>()))
                .Callback<Reservation>(r => createdReservation = r);

            // Act
            var result = reservationController.CreateReservation(reservationDTO);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.Equal(
                nameof(ReservationController.GetReservation),
                createdAtActionResult.ActionName
            );
            Assert.Equal(createdReservation.ReservationID, createdAtActionResult.RouteValues["id"]);
        }

        [Fact]
        public void CreateReservation_WithException_ReturnsInternalServerError()
        {
            // Arrange
            mockReservationService
                .Setup(service => service.AddReservation(It.IsAny<Reservation>()))
                .Throws(new Exception());

            // Act
            var result = reservationController.CreateReservation(new ReservationDTO());

            // Assert
            Assert.IsType<ObjectResult>(result.Result);
            var statusCodeResult = (ObjectResult)result.Result;
            Assert.Equal(500, statusCodeResult.StatusCode);
            Assert.Equal("Internal Server Error", statusCodeResult.Value);
        }
    }
}
