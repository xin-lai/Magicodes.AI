using System;
using System.Reflection;
using Magicodes.AI.Baidu.OCR;
using Magicodes.AI.Core.OCR;
using Magicodes.AI.Core.OCR.Dto;
using Xunit;
using Shouldly;

namespace Magicodes.AI.Tests
{
    public class IdCardServiceTest : TestBase
    {
        private readonly IIdcardService _idCardService;

        public IdCardServiceTest()
        {
            _idCardService = new BaiduIdcardService();
        }

        [Theory(DisplayName = "身份证正面信息识别测试")]
        [InlineData("demo-card-1.png")]
        [InlineData("demo-card-2.png")]
        [InlineData("demo-card-3.png")]
        [InlineData("demo-card-4.png")]
        [InlineData("demo-card-5.png")]
        [InlineData("demo-card-6.png")]
        public void GetFrontInfo_Test(string path)
        {
            var base64Str = GetManifestResourceBase64String("Magicodes.AI.Tests.images.IdCard.Front." + path);
            var result = _idCardService.GetFrontInfo(new GetFrontInfoInput()
            {
                Base64String = base64Str
            }).Result;
            result.ShouldNotBeNull();
            result.Address.ShouldNotBeNull();
            result.Birthday.ShouldNotBeNull();
            result.IdNo.ShouldNotBeNull();
            result.Name.ShouldNotBeNull();
            result.Nation.ShouldNotBeNull();
            result.Sex.ShouldNotBeNull();
        }
    }
}
