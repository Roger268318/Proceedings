namespace Proceedings.Identity.BussinessObjects.HandlerErrorException
{
    public class ApiResponse<T>
    {
        public Int32 StatusCode { get; set; }
        public T Data { get; set; }

        public bool Succeeded { get; set; }

        public string? Message { get; set; }

        public static ApiResponse<T> Fail(string errorMessage, Int32 StatusCode)
        {
            return new ApiResponse<T> { Succeeded = false, Message = errorMessage, StatusCode = StatusCode };
        }
        public static ApiResponse<T> Success(T data)
        {
            return new ApiResponse<T> { Succeeded = true, Data = data };
        }
    }
}
