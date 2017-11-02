using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Coinbase.Extensions
{
    public static class RestClientExtensions
    {
        //public static async Task<RestResponse> ExecuteAsync<T>(this IRestClient client, IRestRequest request)
        //{
        //    TaskCompletionSource<IRestResponse> taskCompletion = new TaskCompletionSource<IRestResponse>();
        //    RestRequestAsyncHandle handle = client.ExecuteAsync(request, r => taskCompletion.SetResult(r));
        //    return (RestResponse)(await taskCompletion.Task);
        //}
        //public static RestResponse Execute<T>(this IRestClient client, IRestRequest request)
        //{
        //    TaskCompletionSource<IRestResponse> taskCompletion = new TaskCompletionSource<IRestResponse>();
        //    RestRequestAsyncHandle handle = client.ExecuteAsync(request, r => taskCompletion.SetResult(r));
        //    return (RestResponse)(taskCompletion.Task.Result);
        //}

        public static T Execute<T>(this IRestClient client, IRestRequest request)
        {
            TaskCompletionSource<IRestResponse> taskCompletion = new TaskCompletionSource<IRestResponse>();
            RestRequestAsyncHandle handle = client.ExecuteAsync(request, r => taskCompletion.SetResult(r));

            var content = taskCompletion.Task.Result.Content;

            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
