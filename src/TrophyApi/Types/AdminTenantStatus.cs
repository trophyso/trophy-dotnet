using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(AdminTenantStatusSerializer))]
public enum AdminTenantStatus
{
    [EnumMember(Value = "active")]
    Active,

    [EnumMember(Value = "archived")]
    Archived,
}

internal class AdminTenantStatusSerializer
    : global::System.Text.Json.Serialization.JsonConverter<AdminTenantStatus>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        AdminTenantStatus
    > _stringToEnum = new()
    {
        { "active", AdminTenantStatus.Active },
        { "archived", AdminTenantStatus.Archived },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        AdminTenantStatus,
        string
    > _enumToString = new()
    {
        { AdminTenantStatus.Active, "active" },
        { AdminTenantStatus.Archived, "archived" },
    };

    public override AdminTenantStatus Read(
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
        AdminTenantStatus value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override AdminTenantStatus ReadAsPropertyName(
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
        AdminTenantStatus value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
