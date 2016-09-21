using FubuMVC.Core.Registration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Fubu3TodoApp.Settings
{
    public class FubuJsonSerializationSettings : IConfigurationAction
    {
        public void Configure(BehaviorGraph graph)
        {
            graph.Settings.Get<JsonSerializerSettings>().ContractResolver 
                = new CamelCasePropertyNamesContractResolver();
        }
    }
}