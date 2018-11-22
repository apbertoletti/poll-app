using Microsoft.AspNetCore.Mvc;
using PollApp.Domain.DTOs.PollOption;
using PollApp.Domain.Interfaces.Services;

namespace PollApp.API.Controllers
{
    /// <summary>
    /// API repsonsável por controlar as ações relacionadas as opções de cada enquete do aplicativo
    /// </summary>
    [ApiController]
    public class PollOptionController : ControllerBase
    {
        #region Fields

        private IPollOptionService _pollOptionService;

        #endregion

        #region Constructors

        public PollOptionController(IPollOptionService pollOptionService)
        {
            _pollOptionService = pollOptionService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Registra um voto na opção de enquete informada.
        /// </summary>
        /// <param name="id">ID da opção a ser registrado o voto</param>
        /// <param name="option">Dados da opção a ser votada</param>
        /// <returns>Dados da opção que recebeu o voto</returns>
        [HttpPost()]
        [Route("poll/{id}/vote")]
        public ActionResult VoteByOptionId(int id, [FromBody]VotePollOptionRequest option)
        {
            var optionVote = _pollOptionService.GetById(id);

            if (optionVote == null)
                return NotFound();

            return Ok(_pollOptionService.Vote((VotePollOptionRequest)optionVote));
        }

        #endregion
    }
}
