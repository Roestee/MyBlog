namespace MyBlog.Core.Utilities.Results
{
    public interface IDataResult
    {
        public bool Success { get; }
        public string Message { get; }
    }
}
