using System.Text.Json;

namespace Cinevoraces.Utils;

public static class Serialization
{
    private static readonly JsonSerializerOptions SerializerConfig =
        new()
        {
            PropertyNameCaseInsensitive = true,
            AllowTrailingCommas = true,
            MaxDepth = 64,
        };

    public static T Deserialize<T>(string json)
    {
        var deserializedJson = JsonSerializer.Deserialize<T>(json, SerializerConfig);
        return deserializedJson is null
            ? throw new Exception("Failed to deserialize JSON")
            : deserializedJson;
    }
}
