﻿using PollApp.Domain.Entities;
using PollApp.Domain.Extensions;
using PollApp.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PollApp.Test.API.Fakes.Repositories
{
    public class PollOptionRepositoryFake : IPollOptionRepository
    {
        private List<PollOption> _options;

        public PollOptionRepositoryFake()
        {
            _options = new List<PollOption>()
            {
                new PollOption(id: 1, poll: null, description: "Lazanha"),
                new PollOption(id: 2, poll: null, description: "Strogonoff" ),
                new PollOption(id: 3, poll: null, description: "Peixe assado" ),
                new PollOption(id: 4, poll: null, description: "Verde" ),
                new PollOption(id: 5, poll: null, description: "Azul" ),
                new PollOption(id: 6, poll: null, description: "Amarelo" ),
                new PollOption(id: 7, poll: null, description: "Roxo" ),
                new PollOption(id: 8, poll: null, description: "Vermelho" ),
                new PollOption(id: 9, poll: null, description: "Dormir" ),
                new PollOption(id: 10, poll: null, description: "Gritar" ),
                new PollOption(id: 11, poll: null, description: "Fugir" ),
                new PollOption(id: 12, poll: null, description: "Cantar" ),
            };

            /** Simula dois votos no opção 3 - Peixe assado **/
            _options[2].Vote();
            _options[2].Vote();

            /** Simula dois votos no opção 4 - Verde **/
            _options[3].Vote();

            /** Simula dois votos no opção 11 - Fugir **/
            _options[10].Vote();
            _options[10].Vote();
            _options[10].Vote();
        }

        public PollOption GetById(int id)
        {
            return _options.FirstOrDefault(c => c.ID == id);
        }

        public PollOption Vote(PollOption option)
        {
            return option.Vote();        
        }
    }
}