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
        public void Get_Ok_Test()
        {
            var ret = pollController.Get();

            var result = Assert.IsType<OkObjectResult>(ret);
            var value = Assert.IsAssignableFrom<IEnumerable<GetPollResponse>>(result.Value);
            Assert.Equal(3, value.ToList().Count);
        }

        [Fact]
        public void GetById_Ok_Test()
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
        public void GetById_NotFound_Test()
        {
            var ret = pollController.GetById(999);

            Assert.IsType<NotFoundResult>(ret);
        }

        [Fact]
        public void Add_Ok_Test()
        {
            string newDescription = "A posição política que você mais se encaixa é:";
            var newOptions = new string[] { "Extrema direita", "Direita", "Centro direita", "Centro esquerda", "Esquerda", "Extrema esquerda" };

            var newPoll = new AddPollRequest()
            {
                Poll_Description = newDescription,
                Options = newOptions
            };

            var addRet = pollController.Add(newPoll);

            var addResult = Assert.IsType<OkObjectResult>(addRet);
            var addValue = Assert.IsType<AddPollResponse>(addResult.Value);
            Assert.Equal(4, addValue.Poll_Id);

            var getRet = pollController.GetById(4);
       
            var getResult = Assert.IsType<OkObjectResult>(getRet);
            var getValue = Assert.IsType<GetPollResponse>(getResult.Value);
            Assert.Equal(4, getValue.Poll_Id);
            Assert.Equal(newDescription, getValue.Poll_Description);

            var options = getValue.Options.ToList();
            Assert.Equal(6, options.Count);
            Assert.Equal(newOptions[0], options[0].Option_Description);
            Assert.Equal(newOptions[1], options[1].Option_Description);
            Assert.Equal(newOptions[2], options[2].Option_Description);
            Assert.Equal(newOptions[3], options[3].Option_Description);
            Assert.Equal(newOptions[4], options[4].Option_Description);
            Assert.Equal(newOptions[5], options[5].Option_Description);
        }

        [Fact]
        public void Remove_Ok_Test()
        {
            var removeRet = pollController.Remove(1);
            Assert.IsType<NoContentResult>(removeRet);

            var getRet = pollController.GetById(1);
            Assert.IsType<NotFoundResult>(getRet);
        }

        [Fact]
        public void Remove_NotFound_Test()
        {
            var ret = pollController.Remove(999);

            Assert.IsType<NotFoundResult>(ret);
        }

        #endregion
    }
    }
