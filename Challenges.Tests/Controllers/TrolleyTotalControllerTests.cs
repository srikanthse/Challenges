using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Challenges.API.Controllers;
using Challenges.API.Request;
using Challenges.API.RequestValidator;
using Challenges.Application.Dtos;
using Challenges.Application.Services;

namespace Challenges.Tests.Controllers
{
    [TestFixture]
    public class TrolleyTotalControllerTests
    {
        private Mock<ITrolleyTotalRequestValidator> _trolleyTotalRequestValidatorMock;
        private Mock<ITrolleyTotalCalculatorService> _trolleyTotalCalculatorServiceMock;
        private TrolleyTotalController _sut;
        private const string TestErrorMessage = "Test Error";
        private const decimal TestResult = 1000M;

        [SetUp]
        public void SetUp()
        {
            _trolleyTotalRequestValidatorMock = new Mock<ITrolleyTotalRequestValidator>();
            _trolleyTotalCalculatorServiceMock = new Mock<ITrolleyTotalCalculatorService>();

            var httpContext = new DefaultHttpContext();

            var controllerContext = new ControllerContext()
            {
                HttpContext = httpContext,
            };

            _sut = new TrolleyTotalController(_trolleyTotalRequestValidatorMock.Object, _trolleyTotalCalculatorServiceMock.Object)
            {
                ControllerContext = controllerContext
            };
        }

        [Test]
        public async Task ItShouldReturnBadRequestIfValidationErrors()
        {
            _trolleyTotalRequestValidatorMock.Setup(m => m.Validate(It.IsAny<TrolleyTotalRequest>()))
                .Returns(GetTestValidationError);

            var response = await _sut.PostTrolleyTotal(new TrolleyTotalRequest());

            var result = (BadRequestObjectResult)response.Result;
            var error = ((List<ValidationResultDto>) result.Value);
            Assert.IsInstanceOf(typeof(BadRequestObjectResult), result);
            Assert.AreEqual(TestErrorMessage, error[0].Message);
        }

        [Test]
        public async Task ItShouldReturnOkIfNoValidationErrors()
        {
            _trolleyTotalRequestValidatorMock.Setup(m => m.Validate(It.IsAny<TrolleyTotalRequest>()))
                .Returns(() => new List<ValidationResultDto>());
            _trolleyTotalCalculatorServiceMock.Setup(m => m.GetTrolleyTotal(It.IsAny<TrolleyTotalRequest>()))
                .Returns(() => Task.FromResult(TestResult));

            var response = await _sut.PostTrolleyTotal(new TrolleyTotalRequest());

            Assert.IsInstanceOf(typeof(OkObjectResult), response.Result);
            _trolleyTotalCalculatorServiceMock.Verify(x =>
                x.GetTrolleyTotal(It.IsAny<TrolleyTotalRequest>()), Times.Once);
        }

        List<ValidationResultDto> GetTestValidationError()
        {
            return new List<ValidationResultDto>
            {
                new ValidationResultDto
                {
                    Message = "Test Error"
                }
            };
        }
    }
}
