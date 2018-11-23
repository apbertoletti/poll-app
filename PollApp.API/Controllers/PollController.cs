using Microsoft.AspNetCore.Mvc;
using PollApp.Domain.DTOs.Poll;
using PollApp.Domain.DTOs.PollOption;
using PollApp.Domain.Interfaces.Services;
using System.Linq;

namespace PollApp.API.Controllers
{
    /// <summary>
    /// API repsonsável por controlar as ações relacionadas as enquantes do aplicativo
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class PollController : ControllerBase
    {
        #region Fields

        IPollService _pollService;

        IPollOptionService _pollOptionService;

        #endregion

        #region Constructors

        public PollController(IPollService pollService, IPollOptionService pollOptionService)
        {
            _pollService = pollService;
            _pollOptionService = pollOptionService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Retorna a lista de todas as enquetes e suas respectivas opções cadastradas.
        /// </summary>
        /// <returns>Lista das enquetes cadastradas</returns>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_pollService.Get());
        }


        /// <summary>
        /// Retorna a enquete informada, bem como suas respectivas opções
        /// </summary>
        /// <param name="id">ID da enquete a ser consultada</param>
        /// <returns>Dados da enquete cadastrada</returns>
        [HttpGet]
        [Route("{id}")]
        public ActionResult GetById(int id)
        {
            var result = _pollService.GetById(id);

            if (result == null)
                return NotFound();

            _pollService.RegisterView(id);

            return Ok(result);
        }

        /// <summary>
        /// Adiciona uma nova enquete no banco de dados, bem como suas repectivas opções
        /// </summary>
        /// <param name="poll">Dados da enquente a ser adicionada</param>
        /// <returns>ID da nova enquete adicionada</returns>
        [HttpPost]
        public ActionResult Add([FromBody]AddPollRequest poll)
        {
            var result = _pollService.Add(poll);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Exclui uma enquete do banco de dados, bem como suas repectivas opções
        /// </summary>
        /// <param name="id">ID da enquete a ser excluída</param>
        [HttpDelete]
        [Route("{id}")]
        public ActionResult Remove(int id)
        {
            if (_pollService.GetById(id) == null)
                return NotFound();

            _pollService.Remove(id);

            return NoContent();
        }

        /// <summary>
        /// Registra um voto na opção de enquete informada.
        /// </summary>
        /// <param name="id">ID da enquete a ser votada</param>
        /// <param name="option">Dados da opção a ser votada</param>
        /// <returns>Dados da opção que recebeu o voto</returns>
        [HttpPost()]
        [Route("{id}/vote")]
        public ActionResult VoteByOptionId(int id, [FromBody]VotePollOptionRequest option)
        {
            var poll = _pollService.GetById(id);

            if (poll == null)
                return NotFound($"Enquete (id={id}) não encontrada");

            var optionVote = _pollOptionService.GetById((int)option.Option_Id);

            if (optionVote == null)
                return NotFound($"Opção (id={option.Option_Id}) não encontrada");

            if (!poll.Options.Any(c => c.Option_Id == optionVote.Option_Id))
                return NotFound($"Esta opção (id={option.Option_Id}) não pertence a esta enquete (id={id})");

            return Ok(_pollOptionService.Vote((VotePollOptionRequest)optionVote));
        }

        /// <summary>
        /// Retorna as estatísticas da enquete informada, bem como a quantitade de votos registrada em cada opção.
        /// </summary>
        /// <param name="id">ID da enquete a ser consultada</param>
        /// <returns>Dados estatísticos da enquete</returns>
        [HttpGet]
        [Route("{id}/stats")]    
        public ActionResult GetStatsById(int id)
        {
            if (_pollService.GetById(id) == null)
                return NotFound();

            return Ok(_pollService.GetStatsById(id));
        }

        #endregion
    }
}