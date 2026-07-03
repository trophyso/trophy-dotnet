namespace TrophyApi;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class NotFoundError(object body, TrophyApi.RawResponse? rawResponse = null)
    : TrophyApiApiException("NotFoundError", 404, body, rawResponse: rawResponse);
