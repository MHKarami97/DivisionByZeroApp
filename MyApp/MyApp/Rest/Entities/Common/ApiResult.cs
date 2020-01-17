namespace MyApp.Rest.Entities.Common
{
    public class ApiResult<TReturnEntity>
    {
        public bool IsSuccess { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public TReturnEntity Data { get; set; }
    }

    public class ApiNullResult
    {
        public bool IsSuccess { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}