using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate.Execution;

namespace HotChocolate.Stitching.Pipeline;

public class HttpStitchingRequestInterceptor : IHttpStitchingRequestInterceptor
{
    public virtual ValueTask OnCreateRequestAsync(
        string targetSchema,
        IQueryRequest request,
        HttpRequestMessage requestMessage,
        CancellationToken cancellationToken = default)
    {
        return default;
    }

    public ValueTask<IQueryResult> OnReceivedResultAsync(
        string targetSchema,
        IQueryRequest request,
        IQueryResult result,
        HttpResponseMessage responseMessage,
        CancellationToken cancellationToken = default)
    {
        return new ValueTask<IQueryResult>(result);
    }
}
