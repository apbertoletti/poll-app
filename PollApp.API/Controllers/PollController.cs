using Microsoft.AspNetCore.Mvc;
using PollApp.Domain.DTOs.Poll;
using PollApp.Domain.Interfaces.Services;

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

        #endregion

        #region Constructors

        public PollController(IPollService pollService)
        {
            _pollService = pollService;
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