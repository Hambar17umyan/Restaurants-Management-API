namespace Application.Api.Common;

public class FailResponse : IResponse
{
    public string Message { get; set; } = "No Data";
    public Dictionary<string, object> MetaData { get; set; } = [];
}
