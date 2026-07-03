namespace TrophyApi;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class UnauthorizedError(object body, TrophyApi.RawResponse? rawResponse = null)
    : TrophyApiApiException("UnauthorizedError", 401, body, rawResponse: rawResponse);
