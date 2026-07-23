namespace TrophyApi;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class ForbiddenError(object body, TrophyApi.RawResponse? rawResponse = null)
    : TrophyApiApiException("ForbiddenError", 403, body, rawResponse: rawResponse);
