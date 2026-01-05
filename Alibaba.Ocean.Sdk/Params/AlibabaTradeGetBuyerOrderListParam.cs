using System.Text.Json.Serialization;

namespace Alibaba.Ocean.Sdk.Params;

public class AlibabaTradeGetBuyerOrderListParam : GatewayAPIRequest
{
    [JsonPropertyName("page")]
    public int Page { get; set; } = 1;
    [JsonPropertyName("pageSize")]
    public int PageSize { get; set; } = 20;
    [JsonPropertyName("createStartTime")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset? CreateStartTime { get; set; }
    [JsonPropertyName("createEndTime")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset? CreateEndTime { get; set; }
}

