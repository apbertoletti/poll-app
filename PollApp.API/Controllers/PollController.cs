using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PollApp.Domain.Entities;
using PollApp.Domain.Interfaces.Services;

namespace PollApp.API.Controllers
{
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

        [HttpGet]
        public ActionResult<IEnumerable<Poll>> Get()
        {
            return Ok(_pollService.Get());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Poll> GetById(int id)
        {
            var result = _pollService.GetById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        #endregion
    }
}