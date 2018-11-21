using Microsoft.AspNetCore.Mvc;
using PollApp.API.Controllers;
using PollApp.Domain.DTOs.PollOption;
using PollApp.Domain.Interfaces.Repositories;
using PollApp.Domain.Interfaces.Services;
using PollApp.Test.API.Fakes.Repositories;
using PollApp.Test.Fakes.Services;
using Xunit;

namespace PollApp.Test.API
{
    public class PollOptionControllerTest 
    {
        #region Fields

        private PollOptionController pollOptionController;
        private IPollOptionService pollOptionService;
        private IPollOptionRepository pollOptionRepository;

        #endregion

        #region Constructors

        public PollOptionControllerTest()
        {
            pollOptionRepository = new PollOptionRepositoryFake();
            pollOptionService = new PollOptionServiceFake(pollOptionRepository);
            pollOptionController = new PollOptionController(pollOptionService);
        }

        #endregion

        #region Methods

        [Fact]
        public void VoteByOptionId_Ok_Test()
        {
            var ret = pollOptionController.VoteByOptionId(3, new VotePollOptionRequest());

            var result = Assert.IsType<OkObjectResult>(ret);
            var value = Assert.IsType<VotePollOptionResponse>(result.Value);
            Assert.Equal(3, value.Option_Id);
            Assert.Equal("Peixe assado", value.Option_Description);
            Assert.Equal(3, value.Option_Votes);
        }

        [Fact]
        public void VoteByOptionId_NotFound_Test()
        {
            var ret = pollOptionController.VoteByOptionId(999, new VotePollOptionRequest());

            Assert.IsType<NotFoundResult>(ret);
        }

        #endregion
    }
}
