namespace JukeBox.Core.Helpers;

public static class GetJsonSerializerOptions
{
	public static JsonSerializerOptions GetInstanceJsonSerializerOptions()
	{
		return new JsonSerializerOptions
		{
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
	}
}

