using System.Text.Json;
using System.Text.Json.Serialization;

namespace Alibaba.Ocean.Sdk;

public class DateTimeOffsetConverter : JsonConverter<DateTimeOffset?>
{
    private const string Format = "yyyyMMddHHmmssfffzzz";

    public override DateTimeOffset? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var str = reader.GetString();
        if (str == null) return null;
        var timeStr = $"{str[..^2]}:{str[^2..]}";
        return DateTimeOffset.ParseExact(timeStr, Format, null);
    }

    public override void Write(Utf8JsonWriter writer, DateTimeOffset? value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value?.ToString(Format).Replace(":", ""));
    }
}