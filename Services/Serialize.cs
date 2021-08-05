using System.Text.Json;

namespace Super.GlobalPlatform.Regression.Api.Services
{
    public class Serialize
    {
        public string SerializeIndented(object obj)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
            return JsonSerializer.Serialize(obj, options);
        }
    }
}
