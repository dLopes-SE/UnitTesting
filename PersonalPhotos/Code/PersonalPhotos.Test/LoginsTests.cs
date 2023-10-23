using Core.Interfaces;
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
    private readonly Mock<IHttpContextAccessor> _acessor;

    public LoginsTests()
    {
      _controller = new LoginsController(_logins.Object, _acessor.Object);
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
  }
}