namespace TrophyApi;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class UnprocessableEntityError(object body, TrophyApi.RawResponse? rawResponse = null)
    : TrophyApiApiException("UnprocessableEntityError", 422, body, rawResponse: rawResponse);
