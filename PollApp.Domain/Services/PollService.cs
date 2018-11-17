﻿using System.Collections.Generic;
using PollApp.Domain.Entities;
using PollApp.Domain.Interfaces.Services;

namespace PollApp.Domain.Services
{
    public class PollService : IPollService
    {
        private List<Poll> _polls;

        public PollService()
        {
            _polls = new List<Poll>()
            {
                new Poll(id: 1, description: "Qual seu prato favorito?", pollOptions: new List<PollOption>()
                {
                    new PollOption(id: 1, poll: null, description: "Lazanha" ),
                    new PollOption(id: 1, poll: null, description: "Strogonoff" ),
                    new PollOption(id: 1, poll: null, description: "Peixe assado" ),
                }),
                new Poll(id: 1, description: "Qual sua cor favorita?", pollOptions: new List<PollOption>()
                {
                    new PollOption(id: 1, poll: null, description: "Verde" ),
                    new PollOption(id: 1, poll: null, description: "Azul" ),
                    new PollOption(id: 1, poll: null, description: "Amarelo" ),
                    new PollOption(id: 1, poll: null, description: "Roxo" ),
                    new PollOption(id: 1, poll: null, description: "Vermelho" ),
                })
            };
        }

        public Poll Add(Poll poll)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Poll> Get()
        {
            return _polls;
        }

        public Poll GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
