using ControllersAndActions.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ControllersAndActionsTests
{
     public class ActionTests
    {
        [Fact]
        public void ViewSelected()
        {
            //Arrange
            HomeController controller = new HomeController();

            //Act
            RedirectToActionResult result = controller?.ReceiveForm("Adam", "London");// ?? new RedirectToActionResult("Data", "Home", new {name = "Adam", city = "London" });
           // ViewResult result = controller.Index();
            //Assert
            Assert.Equal("Data", result?.ActionName);
        }

        [Fact]
        public void ModelObjecType()
        {
            //Arrange
           ExampleController controller = new ExampleController();

            //Act
            ViewResult result = controller.Index();

            //Assert
            Assert.IsType<string>(result.ViewData["Message"]);
            Assert.Equal("Hello", result.ViewData["Message"]);
            Assert.IsType<DateTime>(result.ViewData["Date"]);
        }

        [Fact]
        public void Redirection()
        {
            //Arrange
            ExampleController controller = new ExampleController();
            //Act
            RedirectToActionResult result = controller.Redirect();
            //Assert
            Assert.False(result.Permanent);
            Assert.Equal("Index", result.ActionName);
            //Assert.Equal("Example", result.RouteValues["controller"]);
            //Assert.Equal("Index", result.RouteValues["action"]);
            // Assert.Equal("MyID", result.RouteValues["ID"]);
        }

        [Fact]
        public void JsonActionMethod()
        {
            //Arrange
            ExampleController controller = new ExampleController();
            //Act
            JsonResult result = controller.Index2();
            //Assert
            Assert.Equal(new[] { "Alice", "Bob", "Joe" }, result.Value);
        }

        [Fact]
        public void NotFoundActionMethod()
        {
            //Arrange
            ExampleController controller = new ExampleController();
            //Act
            NotFoundResult result = controller.Index7();
            //Assert
            Assert.Equal(404, result.StatusCode);
        }
    }
}
