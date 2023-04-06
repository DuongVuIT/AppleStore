using AppleStore.Areas.Admin.Controllers;
using AppleStore.Controllers;
using AppleStore.Models;
using Moq;
using NUnit.Framework;
using System.Web;
using System.Web.Mvc;

namespace AppleStore.LoginTest
{
    [TestFixture]
    public class LoginTest
    {
        private AdminController controller;
        private Mock<HttpSessionStateBase> sessionMock;
        private AppleStoreEntities db;

        [SetUp]
        public void Setup()
        {
            var mockHttpSession = new Mock<HttpSessionStateBase>(MockBehavior.Strict);
            mockHttpSession.Setup(s => s["ten"]).Returns("giatri");

            sessionMock = new Mock<HttpSessionStateBase>(MockBehavior.Strict);
            var httpContext = new Mock<HttpContextBase>();
            httpContext.Setup(x => x.Session).Returns(sessionMock.Object);

            controller = new AdminController()
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = httpContext.Object
                }
            };
            db = new AppleStoreEntities();
        }

        [Test]
        public void Login_Returns_ViewResult()
        {
            // Arrange
            var expectedResult = typeof(ViewResult);

            // Act
            var result = controller.Login() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf(expectedResult, result);
        }

        [Test]
        public void Login_Returns_RedirectResult_When_LoggedIn()
        {
            // Arrange
            var expectedResult = typeof(RedirectToRouteResult);
            var username = "admin";
            var password = "admin";

            // Act
            var result = controller.Login(username, password) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf(expectedResult, result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [Test]
        public void Login_Returns_ViewResult_With_Error_Message_When_Login_Fails()
        {
            // Arrange
            // Arrange
            var expectedViewName = "Login";
            var expectedErrorMessage = "Đăng nhập thất bại";
            var username = "invalidusername";
            var password = "invalidpassword";

            // Act
            // Act
            var result = controller.Login(username, password);

            // Assert
            Assert.IsNotNull(result);

            if (result is ViewResult viewResult)
            {
                Assert.AreEqual(expectedViewName, viewResult.ViewName);
                Assert.AreEqual(expectedErrorMessage, viewResult.ViewBag.error);
            }
            else
            {
                Assert.Fail("Login action did not return a ViewResult");
            }
        }
    }
}

