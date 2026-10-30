namespace TrophyApi;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class ConflictError(ErrorBody body, TrophyApi.RawResponse? rawResponse = null)
    : TrophyApiApiException("ConflictError", 409, body, rawResponse: rawResponse)
{
    /// <summary>
    /// The body of the response that triggered the exception.
    /// </summary>
    public new ErrorBody Body => body;
}
