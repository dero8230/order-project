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
}
