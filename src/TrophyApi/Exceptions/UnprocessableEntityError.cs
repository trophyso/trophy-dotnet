namespace TrophyApi;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
public class UnprocessableEntityError(ErrorBody body)
    : TrophyApiApiException("UnprocessableEntityError", 422, body)
{
    /// <summary>
    /// The body of the response that triggered the exception.
    /// </summary>
    public new ErrorBody Body => body;
}
