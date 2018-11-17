using Microsoft.AspNetCore.Mvc;
using PollApp.API.Controllers;
using PollApp.Domain.Entities;
using PollApp.Domain.Interfaces.Services;
using System.Collections.Generic;
using Xunit;

namespace PollApp.Test.API
{
    public class PollControllerTest
    {
        #region Properties

        PollController pollController;
        IPollService pollService;

        #endregion

        #region Constructors

        public PollControllerTest()
        {
            pollService = new PollServiceFake();
            pollController = new PollController(pollService);
        }

        #endregion

        #region Methods

        [Fact]
        public void GetTest()
        {
            var ret = pollController.Get();

            var result = Assert.IsType<OkObjectResult>(ret.Result);
            var value = Assert.IsType<List<Poll>>(result.Value);
            Assert.Equal(2, value.Count);
        }

        #endregion
    }
}
