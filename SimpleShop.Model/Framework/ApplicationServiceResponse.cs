namespace SimpleShop.Model.Framework;

public class ApplicationServiceResponse
{
    private readonly List<string> _errors = new ();
    public bool IsSuccess => !IssFailur;
    public bool IssFailur => _errors.Any();

    public void AddError(string errorMessage)
    {
        _errors.Add(errorMessage);
    }

    public IReadOnlyList<string> Errors => _errors;
}

public class ApplicationServiceResponse<TResult>: ApplicationServiceResponse
{
    public TResult Result { get; set; }
}
