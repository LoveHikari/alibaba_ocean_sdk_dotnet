using System.Text.Json.Serialization;

namespace Alibaba.Ocean.Sdk.Results;

public class GatewayAPIResponse
{
    /// <summary>
    /// 错误码
    /// </summary>
    [JsonPropertyName("error_code")]
    public string? ErrorCode { get; set; }
    /// <summary>
    /// 错误信息
    /// </summary>
    [JsonPropertyName("error_message")]
    public string? ErrorMessage { get; set; }
    /// <summary>
    /// 是否成功，成功时为true, 失败时为null
    /// </summary>
    [JsonPropertyName("success")]
    public bool? Success { get; set; }
}