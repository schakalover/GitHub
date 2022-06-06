using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Store.Core.DTO;
using Store.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Web
{
    public class ResponseMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var originalBodyStream = context.Response.Body;

            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;

                await next(context);

                string jsonResponseText = await DynamicField(context.Response);
                context.Response.Body = originalBodyStream;
                byte[] responsebytes = Encoding.UTF8.GetBytes(jsonResponseText);
                originalBodyStream.BeginWrite(responsebytes, 0, responsebytes.Length, null, null);
                context.Response.StatusCode = 200;

                originalBodyStream.Flush();
                responseBody.Position = 0;

            }
            return;
        }

        private async Task<string> DynamicField(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            string jsonText = "";
            string text = "";

            text = await new StreamReader(response.Body).ReadToEndAsync();

            jsonText = text;

            response.Body.Seek(0, SeekOrigin.Begin);

            string key = "";

            if (jsonText != "")
            {

                if (response.HttpContext.Request.Path.Value.Contains("Stores"))
                {
                    var responseApi = JsonConvert.DeserializeObject<ResponseModel<List<StoreDTO>>>(jsonText);
                    if (responseApi.Total_elements > 1)
                    {
                        key = "stores";
                    }
                    else
                    {
                        key = "store";
                    }
                   
                    jsonText = jsonText.Replace("\"" + "model_name" + "\":", "\"" + key + "\":");
                }

                if (response.HttpContext.Request.Path.Value.Contains("Articles"))
                {
                    var responseApi = JsonConvert.DeserializeObject<ResponseModel<List<StoreDTO>>>(jsonText);

                    if (responseApi.Total_elements > 1)
                    {
                        key = "articles";
                    }
                    else
                    {
                        key = "article";
                    }

                    jsonText = jsonText.Replace("\"" + "model_name" + "\":", "\"" + key + "\":");
                }
            }
   
            return jsonText;
        }
    }
}
