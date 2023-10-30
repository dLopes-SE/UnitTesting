using Bongo.Core.Services;
using Bongo.DataAccess.Repository.IRepository;
using Bongo.Models.Model;
using Bongo.Models.Model.VM;
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
    public void BookStudyRoom_HavingZeroRoomsAvailable_ReturnNoRoomAvailable()
    {
      // Setup GetAll studyRooms, making it to return an empty list
      _studyRoomRepo.Setup(x => x.GetAll()).Returns(new List<StudyRoom>(){ });

      // Execute Method
      var result = _bookingService.BookStudyRoom(new StudyRoomBooking() { });

      // Verify if _studyRoomBookingRepository.GetAll was called
      _studyRoomBookingRepo.Verify(x => x.GetAll(It.IsAny<DateTime>()), Times.Once);

      // Assert
      Assert.Equal(StudyRoomBookingCode.NoRoomAvailable, result.Code);
      Assert.True(result.BookingId == null);
    }
  }
}
