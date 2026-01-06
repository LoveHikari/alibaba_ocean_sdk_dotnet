using System.Text.Json.Serialization;

namespace Alibaba.Ocean.Sdk.Results
{
    /// <summary>
    /// 订单列表API响应根对象
    /// </summary>
    public class AlibabaTradeGetBuyerOrderListResult : GatewayAPIResponse
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
        /// 总记录数
        /// </summary>
        [JsonPropertyName("totalRecord")]
        public long TotalRecord { get; set; }

        /// <summary>
        /// 查询返回列表
        /// </summary>
        [JsonPropertyName("result")]
        public List<AlibabaTradeTradeInfo> Result { get; set; }

    }

    /// <summary>
    /// 结果数据
    /// </summary>
    public class AlibabaTradeTradeInfo
    {
        [JsonPropertyName("tradeTerms")]
        public List<AlibabaTradeTradeTermsInfo> TradeTerms { get; set; }
        /// <summary>
        /// 订单基础信息
        /// </summary>
        [JsonPropertyName("baseInfo")]
        public AlibabaTradeOrderBaseInfo BaseInfo { get; set; }
        /// <summary>
        /// 商品条目信息
        /// </summary>
        [JsonPropertyName("productItems")]
        public List<AlibabaTradeProductItemInfo> ProductItems { get; set; }
        /// <summary>
        /// 订单基本信息 (字段需根据文档补充)
        /// </summary>
        public class AlibabaTradeTradeTermsInfo
        {
            /// <summary>
            /// 支付状态
            /// </summary>
            [JsonPropertyName("payStatus")]
            public string PayStatus { get; set; }

            [JsonPropertyName("payStatusDesc")]
            public string PayStatusDesc { get; set; }
            /// <summary>
            /// 阶段金额
            /// </summary>
            [JsonPropertyName("phasAmount")]
            public Decimal PhasAmount { get; set; }
        }

        public class AlibabaTradeOrderBaseInfo
        {
            /// <summary>
            /// 交易id
            /// </summary>
            [JsonPropertyName("id")]
            public long Id { get; set; }
            /// <summary>
            /// 创建时间
            /// </summary>
            [JsonPropertyName("createTime")]
            [JsonConverter(typeof(DateTimeOffsetConverter))]
            public DateTimeOffset? CreateTime { get; set; }
            /// <summary>
            /// 卖家联系人
            /// </summary>
            [JsonPropertyName("sellerContact")]
            public AlibabaTradeTradeSellerContact SellerContact { get; set; }
            /// <summary>
            /// 买家留言
            /// </summary>
            [JsonPropertyName("buyerFeedback")]
            public string? BuyerFeedback { get; set; }
            public class AlibabaTradeTradeSellerContact
            {
                /// <summary>
                /// 公司名称
                /// </summary>
                [JsonPropertyName("companyName")]
                public string CompanyName { get; set; }
                /// <summary>
                /// 联系人在平台的IM账号
                /// </summary>
                [JsonPropertyName("imInPlatform")]
                public string ImInPlatform { get; set; }
                /// <summary>
                /// 邮箱
                /// </summary>
                [JsonPropertyName("email")]
                public string Email { get; set; }
                /// <summary>
                /// 联系电话
                /// </summary>
                [JsonPropertyName("phone")]
                public string Phone { get; set; }
            }
        }

        public class AlibabaTradeProductItemInfo
        {
            /// <summary>
            /// 产品ID
            /// </summary>
            [JsonPropertyName("productID")]
            public long productId { get; set; }
            /// <summary>
            /// 订单销售属性ID
            /// </summary>
            [JsonPropertyName("specId")]
            public string SpecId { get; set; }
            /// <summary>
            /// 商品名称
            /// </summary>
            [JsonPropertyName("name")]
            public string Name { get; set; }
            /// <summary>
            /// 以unit为单位的数量
            /// </summary>
            [JsonPropertyName("quantity")]
            public int Quantity { get; set; }
            /// <summary>
            /// 售中退款单号
            /// </summary>
            [JsonPropertyName("refundId")]
            public string? RefundId { get; set; }
            /// <summary>
            /// 商品图片url
            /// </summary>
            [JsonPropertyName("productImgUrl")]
            public List<string> ProductImgUrl { get; set; }
            /// <summary>
            /// SKU属性描述
            /// </summary>
            [JsonPropertyName("skuInfos")]
            public List<AlibabaTradeSkuItemDesc>? SkuInfos { get; set; }
            public class AlibabaTradeSkuItemDesc
            {
                /// <summary>
                /// 属性名
                /// </summary>
                [JsonPropertyName("name")]
                public string Name { get; set; }
                /// <summary>
                /// 属性值
                /// </summary>
                [JsonPropertyName("value")]
                public string Value { get; set; }
            }
        }
    }


}

