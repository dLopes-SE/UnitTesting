using Bongo.Core.Services.IServices;
using Bongo.Models.Model;
using Bongo.Models.Model.VM;
using Bongo.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Moq;

namespace Bongo.Web.Tests
{
  [Trait("Category", "RoomBookingControllerTests")]
  public class RoomBookingControllerTests
  {
    private readonly Mock<IStudyRoomBookingService> _studyRoomBookingService;
    private readonly RoomBookingController _controller;
    private readonly StudyRoomBooking _studyRoomBookingRequest;

    public RoomBookingControllerTests()
    {
      _studyRoomBookingService = new Mock<IStudyRoomBookingService>();
      _controller = new RoomBookingController(_studyRoomBookingService.Object);

      // Setup studyRoomBooking Parameter
      _studyRoomBookingRequest = new StudyRoomBooking()
      {
        FirstName = "Dylan",
        LastName = "Lopes",
        Email = "dylan.lopes@test.pt",
        Date = DateTime.Now.AddDays(1)
      };
    }

    [Fact]
    public void Index_CallRequest_VerifyInvoking()
    {
      _controller.Index();
      _studyRoomBookingService.Verify(x => x.GetAllBooking(), Times.Once);
    }

    [Fact]
    public void BookRoomCheck_ModelStateInvalid_ReturnView()
    {
      _controller.ModelState.AddModelError("test", "test");

      var result = _controller.Book(new StudyRoomBooking()) as ViewResult;

      Assert.NotNull(result);
      Assert.Equal("Book", result.ViewName, ignoreCase: true);
    }

    [Fact]
    public void BookRoomCheck_GivenStudyRoomBooking_NoRoomAvailable()
    {
      // Setup
      _studyRoomBookingService.Setup(x => x.BookStudyRoom(It.IsAny<StudyRoomBooking>())).Returns(new StudyRoomBookingResult { Code = StudyRoomBookingCode.NoRoomAvailable });

      // Execute
      var result = _controller.Book(_studyRoomBookingRequest) as ViewResult;

      // Assert
      Assert.NotNull(result);
      Assert.Equal("Book", result.ViewName, ignoreCase: true);
      Assert.Equal("No Study Room available for selected date", result.ViewData["Error"]?.ToString(), ignoreCase: true);
    }

    [Fact]
    public void BookRoomCheck_GivenStudyRoomBooking_ReturnBookingConfirmationView()
    {
      // Setup
      _studyRoomBookingService.Setup(x => x.BookStudyRoom(It.IsAny<StudyRoomBooking>())).Returns(new StudyRoomBookingResult { Code = StudyRoomBookingCode.Success });

      // Execute
      var result = _controller.Book(_studyRoomBookingRequest) as RedirectToActionResult;

      // Assert
      Assert.NotNull(result);
      Assert.Equal("BookingConfirmation", result.ActionName, ignoreCase: true);
      Assert.Equal(StudyRoomBookingCode.Success, result.RouteValues?["Code"]);
    }

    [Fact]
    public void BookingConfirmation_BeingRedirectedFromBookAction_ReturnView()
    {
      var result = _controller.BookingConfirmation(new StudyRoomBookingResult()) as ViewResult;

      // Assert
      Assert.NotNull(result);
      Assert.Equal("BookingConfirmation", result.ViewName, ignoreCase: true);
    }
  }
}
