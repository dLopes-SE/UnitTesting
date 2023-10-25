using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration;
using Moq;
using PersonalPhotos.Controllers;
using PersonalPhotos.Models;
using System.Text;

namespace PersonalPhotos.Test
{
  public class PhotosTests
  {
    [Fact]
    public async Task Upload_GivenFileName_ReturnsDisplayAction()
    {
      // The controller method has an attribute that validates if the user is in this session
      // Then we need to add it with Set
      var session = Mock.Of<ISession>();
      session.Set("user", Encoding.UTF8.GetBytes("a@test.com"));

      var context = Mock.Of<HttpContext>(x => x.Session ==  session);
      var accessor = Mock.Of<IHttpContextAccessor>(x => x.HttpContext == context);

      var fileStorage = Mock.Of<IFileStorage>();
      var keyGenerator = Mock.Of<IKeyGenerator>();
      var photoMetadata = Mock.Of<IPhotoMetaData>();

      var formFile = Mock.Of<IFormFile>();
      var model = Mock.Of<PhotoUploadViewModel>(x => x.File == formFile);

      var controller = new PhotosController(keyGenerator, accessor, photoMetadata, fileStorage);

      var result = (await controller.Upload(model)) as RedirectToActionResult;

      Assert.NotNull(result);
      Assert.Equal("Display", result.ActionName, ignoreCase: true);
    }
  }
}
