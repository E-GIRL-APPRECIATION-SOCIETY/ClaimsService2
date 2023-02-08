
namespace ClaimsServiceTest
{

using Microsoft.EntityFrameworkCore;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClaimsService;
using ClaimsService.Controllers;
using Microsoft.Extensions.Logging;
using Moq;


[TestClass]
public class ClaimsPostTest
{
    private ClaimsController _controller;

  [TestInitialize]
public void SetupBeforeEachTest()
{
    var mockLogger = new Mock<ILogger<ClaimsController>>();
    _controller = new ClaimsController(mockLogger.Object, new List<Claims>());
}

    [TestMethod]
    public void PostClaimById_Test()
    {
        //Arrange
        Claims claims = new Claims() { 
            ClaimId = 3, ClaimDate = new DateTime(2023, 02, 06, 12, 11, 0), CustomerId = 2266, Description = "Hvorfor kommer taxa'en ikke?" };
        //Act
        var result = _controller.Post(claims);
        //Assert
        Assert.AreEqual(2, result.Count);
    }
}
}
