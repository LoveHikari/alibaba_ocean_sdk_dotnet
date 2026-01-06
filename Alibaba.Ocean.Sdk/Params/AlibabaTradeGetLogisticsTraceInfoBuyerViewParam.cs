using System.Text.Json.Serialization;

namespace Alibaba.Ocean.Sdk.Params;
/// <summary>
/// 获取交易订单的物流跟踪信息(买家视角)
/// </summary>
public class AlibabaTradeGetLogisticsTraceInfoBuyerViewParam : GatewayAPIRequest
{
    /// <summary>
    /// 该订单下的物流编号
    /// </summary>
    [JsonPropertyName("logisticsId")]
    public string? LogisticsId { get; set; }
    /// <summary>
    /// 订单号
    /// </summary>
    [JsonPropertyName("orderId")]
    public long OrderId { get; set; }
    /// <summary>
    /// 是1688业务还是icbu业务，1688或者alibaba
    /// </summary>
    [JsonPropertyName("webSite")]
    public string WebSite { get; set; }
}