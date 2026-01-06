using System.Text.Json.Serialization;

namespace Alibaba.Ocean.Sdk.Results;

/// <summary>
/// 获取交易订单的物流跟踪信息(买家视角)
/// </summary>
public class AlibabaTradeGetLogisticsTraceInfoBuyerViewResult : GatewayAPIResponse
{
    /// <summary>
    /// 是否成功，成功时为true, null或false时为失败
    /// </summary>
    [JsonPropertyName("success")]
    public bool? Success { get; set; }
    /// <summary>
    /// 跟踪单详情
    /// </summary>
    [JsonPropertyName("logisticsTrace")]
    public List<AlibabaTradeLogisticsTrace>? LogisticsTrace { get; set; }
}

public class  AlibabaTradeLogisticsTrace
{
    /// <summary>
    /// 物流跟踪步骤
    /// </summary>
    [JsonPropertyName("logisticsSteps")]
    public List<AlibabaTradeLogisticsStep> LogisticsSteps { get; set; }

    public class AlibabaTradeLogisticsStep
    {
        /// <summary>
        /// 物流跟踪单该步骤的时间
        /// </summary>
        [JsonPropertyName("acceptTime")]
        public string AcceptTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [JsonPropertyName("remark")]
        public string Remark { get; set; }
    }
}