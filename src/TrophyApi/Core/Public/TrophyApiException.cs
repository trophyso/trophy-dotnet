namespace TrophyApi;

/// <summary>
/// Base exception class for all exceptions thrown by the SDK.
/// </summary>
public class TrophyApiException(string message, Exception? innerException = null)
    : Exception(message, innerException);
