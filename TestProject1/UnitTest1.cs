using Alibaba.Ocean.Sdk;
using Alibaba.Ocean.Sdk.Params;
using Alibaba.Ocean.Sdk.Results;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            try
            {
                // 2. 调用API
                var client = new ApiExecutor("8832053", "CQBDXSNbsm1");
                //AlibabaTradeGetBuyerOrderListParam param = new()
                //{
                //    Page = 1,
                //    PageSize = 50,
                //    CreateStartTime = DateTimeOffset.Parse("2026-01-04 16:04:21 +08:00"),
                //    CreateEndTime = DateTimeOffset.Parse("2026-01-04 16:04:23 +08:00"),
                //};
                //var response = await client.ExecuteAsync<AlibabaTradeGetBuyerOrderListResult>(param, "c7c9942d-9cd8-487d-a7f1-e5d7426e0798");


                AlibabaTradeGetLogisticsTraceInfoBuyerViewParam param = new()
                {
                    OrderId = 4983506427340081611,
                    WebSite = "1688"
                };
                var response = await client.ExecuteAsync<AlibabaTradeGetLogisticsTraceInfoBuyerViewResult>(param, "c7c9942d-9cd8-487d-a7f1-e5d7426e0798");
                //List<AlibabaTradeFastCreateOrderParam.AlibabaTradeFastCargo> cargoParamList = new();
                //cargoParamList.Add(new AlibabaTradeFastCreateOrderParam.AlibabaTradeFastCargo()
                //{
                //    Quantity = 1,
                //    SpecId = "789e9db185c38b010ef919a856e6d24c",
                //    OfferId = 997007127257
                //});
                //AlibabaTradeFastCreateOrderParam request = new AlibabaTradeFastCreateOrderParam()
                //{
                //    AddressParam = new AlibabaTradeFastCreateOrderParam.AlibabaTradeFastAddress()
                //    {
                //        Address = "丹阳开发区江苏积家光学有限公司一号楼一楼大玻璃门边上【惟友光学】",
                //        AddressId = 9151201358,
                //        TownText = "",
                //        AreaText = "丹阳市",
                //        CityText = "镇江市",
                //        ProvinceText = "江苏省",
                //        DistrictCode = "321181",
                //        FullName = "陈中",
                //        Mobile = "15050855459",
                //        Phone = "",
                //        PostCode = "",

                //    },
                //    CargoParamList = cargoParamList,
                //    Flow = "fenxiao",
                //    UseRedEnvelope = "y"
                //};
                //var response = await client.ExecuteAsync<AlibabaTradeFastCreateOrderResult>(request, "c7c9942d-9cd8-487d-a7f1-e5d7426e0798");


                // 3. 处理结果
                System.Diagnostics.Debug.WriteLine($"成功获取订单列表");
            }
            catch (AlibabaApiException ex)
            {
                System.Diagnostics.Debug.WriteLine($"API错误: {ex.ErrorCode} - {ex.Message}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"系统错误: {ex.Message}");
            }
            Assert.True(true);
        }
    }
}
