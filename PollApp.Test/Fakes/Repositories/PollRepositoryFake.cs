using PollApp.Domain.Entities;
using PollApp.Domain.Extensions;
using PollApp.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace PollApp.Test.API.Fakes.Repositories
{
    public class PollRepositoryFake : IPollRepository
    {
        private List<Poll> _polls;

        public PollRepositoryFake()
        {
            _polls = new List<Poll>()
            {
                new Poll(id: 1, description: "Qual seu prato favorito?", pollOptions: new List<PollOption>()
                {
                    new PollOption(id: 1, poll: null, description: "Lazanha" ),
                    new PollOption(id: 2, poll: null, description: "Strogonoff" ),
                    new PollOption(id: 3, poll: null, description: "Peixe assado" ),
                }),
                new Poll(id: 2, description: "Qual sua cor favorita?", pollOptions: new List<PollOption>()
                {
                    new PollOption(id: 4, poll: null, description: "Verde" ),
                    new PollOption(id: 5, poll: null, description: "Azul" ),
                    new PollOption(id: 6, poll: null, description: "Amarelo" ),
                    new PollOption(id: 7, poll: null, description: "Roxo" ),
                    new PollOption(id: 8, poll: null, description: "Vermelho" ),
                }),
                new Poll(id: 3, description: "O que iria fazer nesta situação?", pollOptions: new List<PollOption>()
                {
                    new PollOption(id: 9, poll: null, description: "Dormir" ),
                    new PollOption(id: 10, poll: null, description: "Gritar" ),
                    new PollOption(id: 11, poll: null, description: "Fugir" ),
                    new PollOption(id: 12, poll: null, description: "Cantar" ),
                })
            };

            /** Simula duas visualizações no enquete 1 - Qual seu prato favorito **/
            _polls[0].DoView();
            _polls[0].DoView();

            /** Simula três visualizações no enquete 3 - O que você iria fazer nesta situação **/
            _polls[2].DoView();
            _polls[2].DoView();
            _polls[2].DoView();

            /** Simula dois votos no opção 3 - Peixe assado **/
            _polls[0].Options[2].DoVote();
            _polls[0].Options[2].DoVote();

            /** Simula dois votos no opção 4 - Verde **/
            _polls[1].Options[3].DoVote();

            /** Simula dois votos no opção 9 - Dormir**/
            _polls[2].Options[0].DoVote();
            _polls[2].Options[0].DoVote();

            /** Simula dois votos no opção 11 - Fugir **/
            _polls[2].Options[2].DoVote();
            _polls[2].Options[2].DoVote();
            _polls[2].Options[2].DoVote();
            _polls[2].Options[2].DoVote();

            /** Simula dois votos no opção 12 - Cantar **/
            _polls[2].Options[3].DoVote();
        }

        public Poll Add(Poll poll)
        {
            int? nextId = _polls.Max(c => c.ID) + 1;

            poll.SetNewId(nextId);

            _polls.Add(poll);

            return poll;
        }

        public IEnumerable<Poll> Get()
        {
            return _polls;
        }

        public Poll GetById(int id)
        {
            return _polls.FirstOrDefault(c => c.ID == id);
        }

        public void RegisterView(int id)
        {
            _polls.FirstOrDefault(c => c.ID == id).DoView();
        }

        public void Remove(int id)
        {
            _polls.Remove(_polls.First(c => c.ID == id));
        }
    }
}
