using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PersonalPhotos.Controllers;
using PersonalPhotos.Models;

namespace PersonalPhotos.Test
{
  public class LoginsTests
  {
    private readonly LoginsController _controller;
    private readonly Mock<ILogins> _logins;
    private readonly Mock<IHttpContextAccessor> _accessor;

    public LoginsTests()
    {
      var session = Mock.Of<ISession>();
      var httpContext = Mock.Of<HttpContext>(x => x.Session == session);
      
      _logins = new Mock<ILogins>();

      _accessor = new Mock<IHttpContextAccessor>();
      _accessor.Setup(x => x.HttpContext).Returns(httpContext);

      _controller = new LoginsController(_logins.Object, _accessor.Object);
    }

    [Fact]
    public void Index_GivenNoReturnUrl_ReturnLoginView()
    {
      var result = (_controller.Index() as ViewResult);

      Assert.NotNull(result);
      Assert.Equal("Login", result.ViewName, ignoreCase: true);
    }

    [Fact]
    public async Task Login_GivenModelStateInvalid_ReturnLoginView()
    {
      _controller.ModelState.AddModelError("Test", "Test");

      var result = await _controller.Login(Mock.Of<LoginViewModel>()) as ViewResult;

      Assert.NotNull(result);
      Assert.Equal("Login", result.ViewName, ignoreCase: true);
    }

    [Fact]
    public async Task Login_GivenCorrectPassword_RedirectToDisplayAction()
    {
      var modelView = Mock.Of<LoginViewModel>(x => x.Email == "test@test.com" && x.Password == "123");
      var modelUser = Mock.Of<User>(x => x.Password == "123");

      // Setup Logins, so that whenever it makes a call to GetUser, then it returns the user Model we mocked
      // It.IsAny<string>() -> we dont care about the email, so that it generates a random string (if we dont care about the value passed)
      _logins.Setup(x => x.GetUser(It.IsAny<string>())).ReturnsAsync(modelUser);

      var result = await _controller.Login(modelView);

      Assert.IsType<RedirectToActionResult>(result);
    }

    [Fact]
    public async Task Login_GivenWrongPassword_RedirectToLoginView()
    {
      var modelView = Mock.Of<LoginViewModel>(x => x.Email == "test@test.com" && x.Password == "123");
      var modelUser = Mock.Of<User>(x => x.Password == "1234");

      _logins.Setup(x => x.GetUser(It.IsAny<string>())).ReturnsAsync(modelUser);

      var result = await _controller.Login(modelView) as ViewResult;

      Assert.NotNull(result);
      Assert.Equal("Login", result.ViewName, ignoreCase: true);
    }
  }
}