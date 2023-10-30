using Bongo.Core.Services;
using Bongo.DataAccess;
using Bongo.DataAccess.Repository.IRepository;
using Bongo.Models.Model;
using Bongo.Models.Model.VM;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Bongo.Core.Tests
{
  [Trait("Category", "StudyRoomBookingServiceTests")]
  public class StudyRoomBookingServiceTests
  {
    private readonly Mock<IStudyRoomBookingRepository> _studyRoomBookingRepo;
    private readonly Mock<IStudyRoomRepository> _studyRoomRepo;
    private readonly StudyRoomBookingService _bookingService;

    public StudyRoomBookingServiceTests()
    {
      // Setup DbContext
      var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "temp_Bongo").Options;
      var context = new ApplicationDbContext(options);

      _studyRoomBookingRepo = new Mock<IStudyRoomBookingRepository>();
      _studyRoomRepo = new Mock<IStudyRoomRepository>();
      _bookingService = new StudyRoomBookingService(_studyRoomBookingRepo.Object, _studyRoomRepo.Object);
    }

    [Fact]
    public void GetAllBooking_InvokeMethod_CheckIfRepoIsCalled()
    {
      _bookingService.GetAllBooking();
      _studyRoomBookingRepo.Verify(x => x.GetAll(null), Times.Once);
    }

    [Fact]
    public void GetAllBooking_NullRequest_ThrowArgumentNullException()
    {
      // Null request
      StudyRoomBooking? request = null;

      // Assert
      Assert.Throws<ArgumentNullException>(() => _bookingService.BookStudyRoom(request));
    }

    [Fact]
    public void BookStudyRoom_HavingZeroRoomsAvailable_ReturnNoRoomAvailable()
    {
      // Setup GetAll studyRooms, making it to return an empty list
      _studyRoomRepo.Setup(x => x.GetAll()).Returns(new List<StudyRoom>(){ });

      // Execute Method
      var result = _bookingService.BookStudyRoom(new StudyRoomBooking() { });

      // Verify if _studyRoomBookingRepository.GetAll was called
      _studyRoomBookingRepo.Verify(x => x.GetAll(It.IsAny<DateTime>()), Times.Once);

      // Ensure that _studyRoomBookingRepository.Book was never called
      _studyRoomBookingRepo.Verify(x => x.Book(It.IsAny<StudyRoomBooking>()), Times.Never);

      // Assert
      Assert.Equal(StudyRoomBookingCode.NoRoomAvailable, result.Code);
      Assert.True(result.BookingId == null);
    }

    [Fact]
    public void BookStudyRoom_BookAvailableRoom_ReturnStudyRoomBookingResult()
    {
      // Setup Request Parameter
      var request = new StudyRoomBooking()
      {
        FirstName = "Dylan",
        LastName = "Lopes",
        Email = "dylan.lopes@test.pt",
        Date = DateTime.Now.AddDays(1)
      };

      // Setup GetAll studyRooms, making it to return an available room
      _studyRoomRepo.Setup(x => x.GetAll()).Returns(new List<StudyRoom>()
        {
          new StudyRoom()
          {
            Id = 1,
            RoomName = "Room 1",
            RoomNumber = "One"
          }
        });

      StudyRoomBooking savedBooking;
      _studyRoomBookingRepo.Setup(x => x.Book(It.IsAny<StudyRoomBooking>()))
                           .Callback<StudyRoomBooking>(booking =>
                           {
                             booking.BookingId = 1;
                             savedBooking = booking;
                           });

      // Execute method
      var result = _bookingService.BookStudyRoom(request);

      // Verify if _studyRoomBookingRepository.GetAll was called
      _studyRoomBookingRepo.Verify(x => x.GetAll(It.IsAny<DateTime>()), Times.Once);

      // Ensure that _studyRoomBookingRepository.Book was called once aswell
      _studyRoomBookingRepo.Verify(x => x.Book(It.IsAny<StudyRoomBooking>()), Times.Once);

      // Expected result
      var expectedResult = new StudyRoomBookingResult()
      {
        BookingId = 1,
        FirstName = request.FirstName,
        LastName = request.LastName,
        Email = request.Email,
        Date = request.Date,
        Code = StudyRoomBookingCode.Success
      };

      // Assert
      Assert.Equivalent(expectedResult, result);

      
    }
  }
}
