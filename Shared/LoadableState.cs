namespace blazor_blog.Shared
{
    public abstract record LoadableState
    {
        public bool IsLoading { get; init; }
        public bool HasError { get; init; }
        public string ErrorMessage { get; init; }
    }
}