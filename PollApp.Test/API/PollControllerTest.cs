using Microsoft.AspNetCore.Mvc;
using PollApp.API.Controllers;
using PollApp.Domain.DTOs.Poll;
using PollApp.Domain.DTOs.PollOption;
using PollApp.Domain.Entities;
using PollApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;

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

            var result = Assert.IsType<OkObjectResult>(ret);
            var value = Assert.IsAssignableFrom<IEnumerable<GetPollResponse>>(result.Value);
            Assert.Equal(3, value.ToList().Count);
        }

        [Fact]
        public void GetByIdTest()
        {
            var ret = pollController.GetById(1);

            var result = Assert.IsType<OkObjectResult>(ret);
            var value = Assert.IsType<GetPollResponse>(result.Value);
            Assert.Equal(1, value.Poll_Id);
            Assert.Equal("Qual seu prato favorito?", value.Poll_Description);

            var options = value.Options.ToList();
            Assert.Equal(3, options.Count);
            Assert.Equal("Lazanha", options[0].Option_Description);
            Assert.Equal("Strogonoff", options[1].Option_Description);
            Assert.Equal("Peixe assado", options[2].Option_Description);
        }

        [Fact]
        public void AddTest()
        {
            var newPoll = new AddPollRequest()
            {
                Poll_Description = "A posição política que você mais se encaixa é:",
                Options = new List<AddPollOptionRequest>()
                {
                    new AddPollOptionRequest() { Option_Description = "Extrema direita" },
                    new AddPollOptionRequest() { Option_Description = "Direita" },
                    new AddPollOptionRequest() { Option_Description = "Centro direita" },
                    new AddPollOptionRequest() { Option_Description = "Centro esquerda" },
                    new AddPollOptionRequest() { Option_Description = "Esquerda" },
                    new AddPollOptionRequest() { Option_Description = "Extrema esquerda" },
                }                  
            };

            var ret = pollController.Add(newPoll);

            var result = Assert.IsType<OkObjectResult>(ret);
            var value = Assert.IsType<AddPollResponse>(result.Value);
            Assert.Equal(4, value.Poll_Id);
        }

        #endregion
    }
}
