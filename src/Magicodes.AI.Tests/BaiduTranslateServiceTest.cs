using System;
using System.Collections.Generic;
using System.Text;
using Magicodes.AI.Baidu.NLP;
using Magicodes.AI.Baidu.OCR;
using Magicodes.AI.Core.NPL;
using Magicodes.AI.Core.NPL.Dto;
using Shouldly;
using Xunit;

namespace Magicodes.AI.Tests
{
    public class BaiduTranslateServiceTest : TestBase
    {
        private readonly IBaiduTranslateService _baiduTranslateService;

        public BaiduTranslateServiceTest()
        {
            _baiduTranslateService = new BaiduTranslateService();
        }

        [Fact(DisplayName = "翻译")]
        public void Translate_Test()
        {
            var result = _baiduTranslateService.Translate(new TranslateInput()
            {
                TranslatedText = "Name\nAge\nLast Modifier User Id",
                FromLanguage = TranslateLanguage.en,
                ToLanguage = TranslateLanguage.zh,
                RequestType = RequestType.Http
            });
            result.ShouldNotBeNull();
        }
    }
}
