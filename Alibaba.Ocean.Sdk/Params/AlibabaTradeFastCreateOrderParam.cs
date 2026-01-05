using System.Text.Json.Serialization;

namespace Alibaba.Ocean.Sdk.Params;
/// <summary>
/// 创建采购订单请求
/// </summary>
public class AlibabaTradeFastCreateOrderParam : GatewayAPIRequest
{
    /// <summary>
    /// general（创建大市场订单），fenxiao（创建分销订单）,saleproxy流程将校验分销关系,paired(火拼下单),boutiquefenxiao(精选货源分销价下单，采购量1个使用包邮)， boutiquepifa(精选货源批发价下单，采购量大于2使用).
    /// </summary>
    [JsonPropertyName("flow")]
    public string Flow { get; set; }
    /// <summary>
    /// 买家留言
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }
    /// <summary>
    /// 收货地址信息
    /// </summary>
    [JsonPropertyName("addressParam")]
    public AlibabaTradeFastAddress AddressParam { get; set; }
    /// <summary>
    /// 商品信息
    /// </summary>
    [JsonPropertyName("cargoParamList")]
    public List<AlibabaTradeFastCargo> CargoParamList { get; set; }
    /// <summary>
    /// 使用红包：n不使用，y使用。默认使用红包
    /// </summary>
    [JsonPropertyName("useRedEnvelope")]
    public string UseRedEnvelope { get; set; } = "y";
    public class AlibabaTradeFastAddress
    {
        /// <summary>
        /// 收货地址id
        /// </summary>
        [JsonPropertyName("addressId")]
        public long AddressId { get; set; }
        /// <summary>
        /// 收货人姓名
        /// </summary>
        [JsonPropertyName("fullName")]
        public string FullName { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        [JsonPropertyName("mobile")]
        public string Mobile { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        [JsonPropertyName("phone")]
        public string Phone { get; set; }
        /// <summary>
        /// 邮编
        /// </summary>
        [JsonPropertyName("postCode")]
        public string PostCode { get; set; }
        /// <summary>
        /// 	市文本
        /// </summary>
        [JsonPropertyName("cityText")]
        public string CityText { get; set; }
        /// <summary>
        /// 省份文本
        /// </summary>
        [JsonPropertyName("provinceText")]
        public string ProvinceText { get; set; }
        /// <summary>
        /// 区文本
        /// </summary>
        [JsonPropertyName("areaText")]
        public string AreaText { get; set; }
        /// <summary>
        /// 镇文本
        /// </summary>
        [JsonPropertyName("townText")]
        public string TownText { get; set; }
        /// <summary>
        /// 街道地址
        /// </summary>
        [JsonPropertyName("address")]
        public string Address { get; set; }
        /// <summary>
        /// 地址编码
        /// </summary>
        [JsonPropertyName("districtCode")]
        public string DistrictCode { get; set; }
    }
    public class AlibabaTradeFastCargo
    {
        /// <summary>
        /// 商品对应的offer id
        /// </summary>
        [JsonPropertyName("offerId")]
        public long OfferId { get; set; }
        /// <summary>
        /// 商品规格id
        /// </summary>
        [JsonPropertyName("specId")]
        public string SpecId { get; set; }
        /// <summary>
        /// 商品数量(计算金额用)
        /// </summary>
        [JsonPropertyName("quantity")]
        public double Quantity { get; set; }
    }
}