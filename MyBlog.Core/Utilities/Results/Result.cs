namespace MyBlog.Core.Utilities.Results
{
    public abstract class Result : IDataResult
    {
        protected Result(bool success)
        {
            Success = success;
        }
        protected Result(bool success, string message) : this(success)
        {
            Message = message;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
