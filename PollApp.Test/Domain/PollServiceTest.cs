using PollApp.Domain.Interfaces.Repositories;
using PollApp.Domain.Interfaces.Services;
using PollApp.Test.API.Fakes.Repositories;
using PollApp.Test.API.Fakes.Services;
using Xunit;

namespace PollApp.Test.Domain
{
    public class PollServiceTest
    {
        private IPollService _pollService;
        private IPollRepository _pollRepository;

        public PollServiceTest()
        {
            _pollRepository = new PollRepositoryFake();
            _pollService = new PollServiceFake(_pollRepository);
        }

        [Fact]
        public void RegisterView_Test()
        {
            var idPollTest = 3;

            var viewsBefore = _pollRepository.GetById(idPollTest).Views;

            _pollService.RegisterView(idPollTest);

            var viewsAfter = _pollRepository.GetById(idPollTest).Views;

            Assert.Equal(3, viewsBefore);
            Assert.Equal(4, viewsAfter);
        }
    }
}
