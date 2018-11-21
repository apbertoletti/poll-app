using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PollApp.Domain.DTOs.Poll;
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
        public ActionResult Get()
        {
            return Ok(_pollService.Get());
        }

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

        [HttpPost]
        public ActionResult Add([FromBody]AddPollRequest poll)
        {
            var result = _pollService.Add(poll);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Remove(int id)
        {
            if (_pollService.GetById(id) == null)
                return NotFound();

            _pollService.Remove(id);

            return NoContent();
        }

        #endregion
    }
}