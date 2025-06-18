using System;
using System.Text.Json;
using System.Text.Json.Serialization;

class GoalConverter : JsonConverter<Goal>
{
    public override Goal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using (var doc = JsonDocument.ParseValue(ref reader))
        {
            var root = doc.RootElement;
            var type = root.GetProperty("Type").GetString();

            return type switch
            {
                "SimpleGoal" => JsonSerializer.Deserialize<SimpleGoal>(root.GetRawText(), options),
                "EternalGoal" => JsonSerializer.Deserialize<EternalGoal>(root.GetRawText(), options),
                "ChecklistGoal" => JsonSerializer.Deserialize<ChecklistGoal>(root.GetRawText(), options),
                "NegativeGoal" => JsonSerializer.Deserialize<NegativeGoal>(root.GetRawText(), options),
                _ => throw new Exception("Unknown goal type")
            };
        }
    }

    public override void Write(Utf8JsonWriter writer, Goal value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString("Type", value.GetType().Name);
        foreach (var prop in value.GetType().GetProperties())
        {
            writer.WritePropertyName(prop.Name);
            JsonSerializer.Serialize(writer, prop.GetValue(value), options);
        }
        writer.WriteEndObject();
    }
}