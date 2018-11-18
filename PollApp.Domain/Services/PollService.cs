using System.Collections.Generic;
using System.Linq;
using PollApp.Domain.DTOs.Poll;
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
                    new PollOption(id: 4, poll: null, description: "Dormir" ),
                    new PollOption(id: 5, poll: null, description: "Gritar" ),
                    new PollOption(id: 6, poll: null, description: "Fugir" ),
                    new PollOption(id: 7, poll: null, description: "Cantar" ),
                })
            };
        }

        public AddPollResponse Add(AddPollRequest poll)
        {
            int nextId = _polls.Max(c => c.ID) + 1;

            var newPoll = new Poll(nextId, poll.Poll_Description, new List<PollOption>());

            var newOptions = new List<PollOption>();
            for (int i = 1; i <= poll.Options.Count(); i++)
                newOptions.Add(new PollOption(i * (-1), newPoll, poll.Options.ElementAt(i - 1).Option_Description));

            newPoll.Options.AddRange(newOptions);

            _polls.Add(newPoll);

            return new AddPollResponse() { Poll_Id = newPoll.ID };
        }

        public IEnumerable<GetPollResponse> Get()
        {
            return _polls.ToList().Select(entidade => (GetPollResponse)entidade);
        }

        public GetPollResponse GetById(int id)
        {
            return (GetPollResponse)_polls.FirstOrDefault(c => c.ID == id);
        }

        public void Remove(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
