namespace Insurance.Application.ResponseContracts
{
    public class APIResponse
    {
        public APIResponse(bool isSuccess, Error error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        public bool IsSuccess { get; }
        public Error Error { get; }

        public static APIResponse Success() => new(true, Error.None);

        public static APIResponse Failure(Error error) => new(false, error);

        public static APIResponse<T> Success<T>(T data) => new(true, Error.None, data);

        public static APIResponse<T> Failure<T>(Error error) => new(false, error, default);
    }

    public class APIResponse<T> : APIResponse
    {
        public T? Data { get; }

        public APIResponse(bool isSuccess, Error error, T? data) : base(isSuccess, error)
        {
            Data = data;
        }
    }

    public class Error
    {
        public Error(string message)
        {
            Message = message;
        }

        public string Message { get; }

        public static Error None => new(string.Empty);

        public static implicit operator Error(string message) => new(message);

        public static implicit operator string(Error error) => error.Message;
    }
}
