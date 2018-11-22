using Newtonsoft.Json.Serialization;

namespace PollApp.API.Resolvers
{
    public class LowerCaseContractResolver : DefaultContractResolver
    {
        #region Methods

        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.ToLower();
        }

        #endregion
    }
}
