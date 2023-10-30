using Bongo.Core.Services;
using Bongo.DataAccess.Repository.IRepository;
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
  }
}
