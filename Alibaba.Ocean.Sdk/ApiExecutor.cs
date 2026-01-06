using System.Security.Cryptography;
using System.Text;
using Alibaba.Ocean.Sdk.Params;
using Alibaba.Ocean.Sdk.Results;

namespace Alibaba.Ocean.Sdk
{
    public class ApiExecutor
    {
        private readonly string _appKey;
        private readonly string _appSecret;
        private readonly HttpClient _httpClient;

        public ApiExecutor(string appKey, string appSecret)
        {
            _appKey = appKey;
            _appSecret = appSecret;
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// 执行
        /// </summary>
        public async Task<T> ExecuteAsync<T>(GatewayAPIRequest request,string accessToken) where T : GatewayAPIResponse
        {
            string urlPath = "";
            if (request.GetType() == typeof(AlibabaTradeFastCreateOrderParam))
            {
                urlPath = "param2/1/com.alibaba.trade/alibaba.trade.fastCreateOrder";
            }
            else if (request.GetType() == typeof(AlibabaTradeGetBuyerOrderListParam))
            {
                // 2. 生成签名
                urlPath = "param2/1/com.alibaba.trade/alibaba.trade.getBuyerOrderList";
            }
            else if (request.GetType() == typeof(AlibabaTradeGetLogisticsTraceInfoBuyerViewParam))
            {
                urlPath = "param2/1/com.alibaba.logistics/alibaba.trade.getLogisticsTraceInfo.buyerView";
            }

            urlPath += $"/{_appKey}";
            // 1. 构建参数字典（不含签名）
            var parameters = BuildParameters(request, accessToken);

            
            string signature = GenerateSignature(urlPath, parameters, _appSecret);

            urlPath += $"?_aop_signature={signature}&_aop_timestamp={parameters["_aop_timestamp"]}&access_token={parameters["access_token"]}";
            parameters.Remove("_aop_timestamp");
            parameters.Remove("access_token");
            // 2. 构建请求URL（不包含查询参数）
            string apiUrl = $"https://gw.open.1688.com/openapi/{urlPath}";

            var content = ToHttpContent(parameters);

            // 4. 发送请求
            var response = await _httpClient.PostAsync(apiUrl, content);
            //response.EnsureSuccessStatusCode();

            // 5. 解析响应
            var json = await response.Content.ReadAsStringAsync();
            var apiResponse = System.Text.Json.JsonSerializer.Deserialize<T>(json);

            if (apiResponse == null)
            {
                throw new AlibabaApiException("INVALID_RESPONSE", "API返回格式错误");
            }

            //if (apiResponse.ErrorCode != null)
            //{
            //    throw new AlibabaApiException(apiResponse.ErrorCode, apiResponse.ErrorMessage);
            //}

            return apiResponse;
        }

        /// <summary>
        /// 构建参数字典（不含签名）
        /// </summary>
        private Dictionary<string, object> BuildParameters(GatewayAPIRequest request, string accessToken)
        {
            var parameters = new Dictionary<string, object?>();

            // 系统参数
            parameters.Add("_aop_timestamp", GetCurrentTimestamp().ToString());
            if (!string.IsNullOrEmpty(accessToken))
            {
                parameters.Add("access_token", accessToken);
            }

            // 业务参数
            var json = System.Text.Json.JsonSerializer.Serialize(request, request.GetType());
            var dic = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, object?>>(json);
            var pp = parameters.Union(dic).Where(x => x.Value != null).ToDictionary();
            
            return pp;
        }


        private long GetCurrentTimestamp()
        {
            return (long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalMilliseconds;
        }

        /// <summary>
        /// 转换为HttpContent
        /// </summary>
        private HttpContent ToHttpContent(IDictionary<string, object> parameters)
        {
            string urlEncoded = string.Join("&",
                parameters.Select(kvp =>
                    $"{Uri.EscapeDataString(kvp.Key)}={Uri.EscapeDataString(kvp.Value.ToString() ?? string.Empty)}")); ;
            return new StringContent(urlEncoded, Encoding.UTF8, "application/x-www-form-urlencoded");
        }
        /// <summary>
        /// 生成1688开放平台API签名（HmacSHA1）
        /// </summary>
        /// <param name="urlPath">签名因子1：从协议开始的路径</param>
        /// <param name="parameters">请求参数字典（不含签名本身）</param>
        /// <param name="appSecret">应用的appSecret</param>
        /// <returns>大写的十六进制签名字符串</returns>
        private string GenerateSignature(string urlPath, IDictionary<string, object> parameters, string appSecret)
        {
            byte[] signatureKey = Encoding.UTF8.GetBytes(appSecret);//此处用自己的签名密钥
            List<string> list = new List<string>();
            foreach (KeyValuePair<string, object> kv in parameters)
            {
                list.Add(kv.Key + kv.Value);
            }
            list.Sort();
            string tmp = urlPath;
            foreach (string kvstr in list)
            {
                tmp = tmp + kvstr;
            }

            //HMAC-SHA1
            HMACSHA1 hmacsha1 = new HMACSHA1(signatureKey);
            hmacsha1.ComputeHash(Encoding.UTF8.GetBytes(tmp));

            byte[] hash = hmacsha1.Hash;
            //TO HEX
            return BitConverter.ToString(hash).Replace("-", string.Empty).ToUpper();
        }
    }

    public class AlibabaApiException : System.Exception
    {
        public string ErrorCode { get; }

        public AlibabaApiException(string errorCode, string message)
            : base($"API Error ({errorCode}): {message}")
        {
            ErrorCode = errorCode;
        }
    }
}