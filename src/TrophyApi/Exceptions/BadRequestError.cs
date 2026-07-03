namespace TrophyApi;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class BadRequestError(object body, TrophyApi.RawResponse? rawResponse = null)
    : TrophyApiApiException("BadRequestError", 400, body, rawResponse: rawResponse);
