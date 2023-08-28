namespace order_api.Models.Wrapper
{
    public class Result<T>
    {
        public bool Success { get; set; } = false;
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }

        public Result(T data, string messege = "", bool success = true)
        {
            Data = data;
            Message = messege;
            Success = success;
        }
    }

    public class Result
    {
        public static Result<T> GetResult<T>(T data, string messege = "", bool success = true)
            where T : class
        {
            return new Result<T>(data, messege, success);
        }
    }
}
