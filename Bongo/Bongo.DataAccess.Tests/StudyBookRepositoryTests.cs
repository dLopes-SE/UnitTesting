using Bongo.DataAccess.Repository;
using Bongo.Models.Model;
using Microsoft.EntityFrameworkCore;

namespace Bongo.DataAccess.Tests
{
  [Trait("Category", "StudyBookRepositoryTests")]
  public class StudyBookRepositoryTests
  {
    private StudyRoomBooking studyRoomBooking_One;
    private StudyRoomBooking studyRoomBooking_Two;
    private readonly DbContextOptions<ApplicationDbContext> _options;


    public StudyBookRepositoryTests()
    {
      studyRoomBooking_One = new StudyRoomBooking()
      {
        FirstName = "Dylan1",
        LastName = "Lopes1",
        Date = new DateTime(2023, 1, 1),
        Email = "dylan1@test.com",
        BookingId = 11,
        StudyRoomId = 1
      };

      studyRoomBooking_Two = new StudyRoomBooking()
      {
        FirstName = "Dylan2",
        LastName = "Lopes2",
        Date = new DateTime(2023, 2, 2),
        Email = "dylan2@test.com",
        BookingId = 22,
        StudyRoomId = 2
      };

      // arrange (Mocking an inMemoryDatabase)
      _options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "temp_Bongo").Options;

    }

    [Fact]
    public void SaveBook_Booking_One_CheckTheValuesFromDB()
    {
      // act -> saving the book to the inMemoryDB
      using var context = new ApplicationDbContext(_options);
      context.Database.EnsureDeleted();

      var repo = new StudyRoomBookingRepository(context);
      repo.Book(studyRoomBooking_One);

      // Assert -> verify if the booking was correctly inserted
      Assert.True(studyRoomBooking_One.Equals(context.StudyRoomBookings.FirstOrDefault(x => x.StudyRoomId == studyRoomBooking_One.StudyRoomId)));
    }

    [Fact]
    public void GetAll_Booking_Both_CheckReturnedBookings()
    {
      // act -> saving the book to the inMemoryDB
      using var context = new ApplicationDbContext(_options);
      context.Database.EnsureDeleted();

      var repo = new StudyRoomBookingRepository(context);
      repo.Book(studyRoomBooking_One);
      repo.Book(studyRoomBooking_Two);

      // GetAll
      var bookings = repo.GetAll();

      // Assert
      Assert.Equivalent(new List<StudyRoomBooking>() { studyRoomBooking_One, studyRoomBooking_Two }, bookings);
    }
  }
}
