using System;
using Tales.Services;
using Moq;
using System.Web.Mvc;
using Tales.Web;
using Tales.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Tales.Modal;

namespace Tales.Web.Tests.Controllers
{
    [TestClass]
    public class PostControllerTest
    {

        Mock<IPostService> postService;
        Mock<ITagService> tagService;
        Mock<ICommentService> commentService;
        Mock<IUserService> userService;

        [TestInitialize]
        public void TestInitialize()
        {
             postService = new Moq.Mock<IPostService>();
             tagService = new Mock<ITagService>();
             commentService = new Mock<ICommentService>();
             userService = new Mock<IUserService>();
        }

        [TestMethod]
        public void Index()
        {
           
            PostController controller = new
            PostController(postService.Object, tagService.Object, commentService.Object, userService.Object);

            var result = controller.Index(1) as ViewResult;

            Assert.AreEqual(result.ViewName, "Index");

            Assert.IsNotNull(result.Model);

            Assert.IsInstanceOfType(result.Model, typeof(List<Post>));

        }

        [TestMethod]
        public void ShowPost()
        {
            PostController controller = new
            PostController(postService.Object, tagService.Object, commentService.Object, userService.Object);

          
            var result = controller.Index(1) as ViewResult;

            
            Assert.IsNotNull(result.Model);
                
        }
    }
}
