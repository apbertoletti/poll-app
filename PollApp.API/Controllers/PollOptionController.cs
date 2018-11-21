using Microsoft.AspNetCore.Mvc;
using PollApp.Domain.DTOs.PollOption;
using PollApp.Domain.Interfaces.Services;

namespace PollApp.API.Controllers
{
    [ApiController]
    public class PollOptionController : ControllerBase
    {
        private IPollOptionService _pollOptionService;

        public PollOptionController(IPollOptionService pollOptionService)
        {
            _pollOptionService = pollOptionService;
        }

        [HttpPost()]
        [Route("poll/{id}/vote")]
        public ActionResult VoteByOptionId(int id, [FromBody]VotePollOptionRequest option)
        {
            var optionVote = _pollOptionService.GetById(id);

            if (optionVote == null)
                return NotFound();

            return Ok(_pollOptionService.Vote((VotePollOptionRequest)optionVote));
        }
    }
}
