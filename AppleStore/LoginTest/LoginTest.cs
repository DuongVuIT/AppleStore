using AppleStore.Areas.Admin.Controllers;
using AppleStore.Controllers;
using AppleStore.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppleStore.LoginTest
{
    public class LoginTest
    {
        private Mock<HttpSessionStateBase> sessionMock;
        private AdminController controller;
        private AppleStoreEntities db;

        [SetUp]
        public void Setup()
        {
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
        public void Login_Success()
        {
            // Arrange
            var taikhoan = "admin";
            var matkhau = "admin";

            // Act
            var result = controller.Login(taikhoan, matkhau) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [Test]
        public void Login_Fail_Password()
        {
            // Arrange
            var taikhoan = "admin";
            var matkhau = "wrongpassword";

            // Act
            var result = controller.Login(taikhoan, matkhau) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(controller.ModelState.IsValid);
            Assert.IsTrue(controller.ViewBag.errormk == "Mật khẩu không đúng" || controller.ViewBag.errortk == "Tài khoản không đúng");
        }

        [Test]
        public void Login_Fail_Username()
        {
            // Arrange
            var taikhoan = "";
            var matkhau = "";

            // Act
            var result = controller.Login(taikhoan, matkhau) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(controller.ModelState.IsValid);
            Assert.IsTrue(controller.ViewBag.errortk == "Tài khoản không đúng");
        }

        [TearDown]
        public void TearDown()
        {
            db.Dispose();
        }
    }
}