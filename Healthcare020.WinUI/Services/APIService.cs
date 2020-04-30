using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Healthcare020.WinUI.Helpers;

namespace Healthcare020.WinUI.Services
{
    public class APIService<TResourceParameters>
    {
        private IFlurlRequest request;

        public APIService(string route)
        {
            request = Auth.GetAuthorizedApiRequest(route);
        }


        public async Task<List<T>> Get<T>(TResourceParameters resourceParameters)
        {
            var result =  await request.SetQueryParams(resourceParameters).GetAsync().ReceiveJson<List<T>>();

            return result;
        }
    }
}