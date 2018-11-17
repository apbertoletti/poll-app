using Microsoft.AspNetCore.Mvc;
using PollApp.API.Controllers;
using Xunit;

namespace PollApp.Test.API
{
    public class PollControllerTest
    {
        #region Properties

        PollController pollController;

        #endregion

        #region Constructors

        public PollControllerTest()
        {
            pollController = new PollController();
        }

        #endregion

        #region Methods

        [Fact]
        public void GetTest()
        {
            var ret = pollController.Get();

            Assert.IsType<OkObjectResult>(ret);
        }

        #endregion
    }
}
