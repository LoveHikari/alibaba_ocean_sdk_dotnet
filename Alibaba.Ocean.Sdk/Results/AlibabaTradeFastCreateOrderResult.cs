using System.Text.Json.Serialization;

namespace Alibaba.Ocean.Sdk.Results;

public class AlibabaTradeFastCreateOrderResult : GatewayAPIResponse
{
    /// <summary>
    /// 错误码
    /// </summary>
    [JsonPropertyName("code")]
    public string? Code { get; set; }
    /// <summary>
    /// 错误信息
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }
    /// <summary>
    /// 查询返回列表
    /// </summary>
    [JsonPropertyName("result")]
    public AlibabaTradeFastResult Result { get; set; }
}

public class AlibabaTradeFastResult
{
    /// <summary>
    /// 下单成功的订单总金额，单位：分
    /// </summary>
    [JsonPropertyName("totalSuccessAmount")]
    public long TotalSuccessAmount { get; set; }
    /// <summary>
    /// 下单成功后的订单id,生成多笔订单时，该字段为空，读取multiOrders模型
    /// </summary>
    [JsonPropertyName("orderId")]
    public string OrderId { get; set; }
    /// <summary>
    /// 创建订单时的运费，生成多笔订单时，该字段为空，读取multiOrders模型
    /// </summary>
    [JsonPropertyName("postFee")]
    public long PostFee { get; set; }
    /// <summary>
    /// 生成多笔订单时，由该模型返回
    /// </summary>
    [JsonPropertyName("multiOrders")]
    public object MultiOrders { get; set; }
}