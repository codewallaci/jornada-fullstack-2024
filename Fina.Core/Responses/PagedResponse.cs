using System.Text.Json.Serialization;

namespace Fina.Core.Responses;

public class PagedResponse<TData> : Response<TData>
{

    [JsonConstructor]
    public PagedResponse(TData? data, int totalCount, int currentPag = 1,
        int pageSize = Configuration.DefaultPageSize) : base(data)
    {
        Data = data;
        TotaCount = totalCount;
        CurrentPage = currentPag;
        PageSize = pageSize;
    }

    public PagedResponse(TData? data, int code = Configuration.DefaultStatusCode, string? message = null) : base(data, code, message)
    {
    }
    public int CurrentPage { get; set; }
    public int TotalPages => (int)Math.Ceiling((TotaCount / (double)PageSize));

    public int PageSize { get; set; } = Configuration.DefaultPageSize;
    public int TotaCount { get; set; } 
        
}
