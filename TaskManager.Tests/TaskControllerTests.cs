using Moq;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using TaskManager.API.Controllers;
using TaskManager.Core.Entities;
using TaskManager.Application.Interfaces;
using TaskManager.API.DTOs;

namespace TaskManager.Tests.Controllers
{
    [TestFixture]
    public class TasksControllerTests
    {
        private Mock<ITaskService> _mockTaskService;
        private TaskController _controller;

        [SetUp]
        public void Setup()
        {
            _mockTaskService = new Mock<ITaskService>();
            _controller = new TaskController(_mockTaskService.Object);
        }
        [Test]
        public void TestMethod()
        {
            Assert.Pass();
        }
        [Test]
        public async Task Save_ShouldReturnBadRequest_WhenCodeIsNull()
        {
            var input = new TaskItemInputModel { Code = "", Description = "Teste" };

            var result = await _controller.Save(input);

            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        }

        [Test]
        public async Task Save_ShouldReturnBadRequest_WhenCodeAlreadyExists()
        {
            var input = new TaskItemInputModel { Code = "001", Description = "Teste" };

            _mockTaskService.Setup(s => s.Get("001")).ReturnsAsync(new TaskItem { Code = "001", Description = "Já existe" });

            var result = await _controller.Save(input);

            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        }

        [Test]
        public async Task Save_ShouldReturnBadRequest_WhenDescriptionIsNull()
        {
            var input = new TaskItemInputModel { Code = "002", Description = "" };

            _mockTaskService.Setup(s => s.Get("002")).ReturnsAsync((TaskItem)null);

            var result = await _controller.Save(input);

            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        }

    }
}
