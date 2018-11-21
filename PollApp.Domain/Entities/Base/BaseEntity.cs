namespace PollApp.Domain.Entities.Base
{
    public class BaseEntity
    {
        #region Methods

        public BaseEntity(int? id)
        {
            ID = id;
        }

        #endregion

        #region Properties

        public int? ID { get; private set; }

        #endregion

        #region Methods

        public void SetNewId(int? newId)
        {
            ID = newId;
        }

        #endregion
    }
}
