namespace PollApp.Domain.DTOs.PollOption
{
    public class VotePollOptionRequest
    {
        public int? Option_Id { get; set; }

        public static explicit operator VotePollOptionRequest(GetPollOptionResponse entity)
        {
            if (entity == null)
                return null;

            return new VotePollOptionRequest()
            {
                Option_Id = entity.Option_Id
            };
        }
    }
}
