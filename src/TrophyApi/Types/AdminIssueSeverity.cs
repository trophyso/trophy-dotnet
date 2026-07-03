using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(AdminIssueSeveritySerializer))]
public enum AdminIssueSeverity
{
    [EnumMember(Value = "error")]
    Error,

    [EnumMember(Value = "warning")]
    Warning,
}

internal class AdminIssueSeveritySerializer
    : global::System.Text.Json.Serialization.JsonConverter<AdminIssueSeverity>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        AdminIssueSeverity
    > _stringToEnum = new()
    {
        { "error", AdminIssueSeverity.Error },
        { "warning", AdminIssueSeverity.Warning },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        AdminIssueSeverity,
        string
    > _enumToString = new()
    {
        { AdminIssueSeverity.Error, "error" },
        { AdminIssueSeverity.Warning, "warning" },
    };

    public override AdminIssueSeverity Read(
        ref global::System.Text.Json.Utf8JsonReader reader,
        global::System.Type typeToConvert,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        var stringValue =
            reader.GetString()
            ?? throw new global::System.Exception("The JSON value could not be read as a string.");
        return _stringToEnum.TryGetValue(stringValue, out var enumValue) ? enumValue : default;
    }

    public override void Write(
        global::System.Text.Json.Utf8JsonWriter writer,
        AdminIssueSeverity value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override AdminIssueSeverity ReadAsPropertyName(
        ref global::System.Text.Json.Utf8JsonReader reader,
        global::System.Type typeToConvert,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        var stringValue =
            reader.GetString()
            ?? throw new global::System.Exception(
                "The JSON property name could not be read as a string."
            );
        return _stringToEnum.TryGetValue(stringValue, out var enumValue) ? enumValue : default;
    }

    public override void WriteAsPropertyName(
        global::System.Text.Json.Utf8JsonWriter writer,
        AdminIssueSeverity value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
