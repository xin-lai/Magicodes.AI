// ======================================================================
//   
//           Copyright (C) 2018-2020 湖南心莱信息科技有限公司    
//           All rights reserved
//   
//           filename : BaiduIdcardService.cs
//           description :
//   
//           created by 雪雁 at  2018-08-02 11:07
//           Mail: wenqiang.li@xin-lai.com
//           QQ群：85318032（技术交流）
//           Blog：http://www.cnblogs.com/codelove/
//           GitHub：https://github.com/xin-lai
//           Home：http://xin-lai.com
//   
// ======================================================================

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Baidu.Aip.Ocr;
using Magicodes.AI.Baidu.Helper;
using Magicodes.AI.Core.OCR;
using Magicodes.AI.Core.OCR.Dto;

namespace Magicodes.AI.Baidu.OCR
{
    /// <summary>
    /// 百度身份证识别服务
    /// </summary>
    public class BaiduIdcardService : IIdcardService
    {
        public Task<GetFrontInfoOutput> GetFrontInfo(GetFrontInfoInput input)
        {
            //移除data:image/jpeg;base64,
            if (input.Base64String.Contains(",")) input.Base64String = input.Base64String.Split(',')[1];
            var bytes = Convert.FromBase64String(input.Base64String);
            var result = BaiduAiHelper.Ocr.Idcard(bytes, "front", new Dictionary<string, object>
            {
                //精准度，精度越高，速度越慢。default：auto
                {"accuracy", "high"},
                //是否开启身份证风险类型(复印件、临时身份证、翻拍等类型)功能，默认不开启，即：false。可选值:true-开启；false-不开启
                {"detect_risk", "true"}
            });
            if (result["error_code"] != null) throw new BaiduApiException(result["error_msg"]?.ToString());
            var wordsResult = result["words_result"];
            var output = new GetFrontInfoOutput
            {
                Address = (wordsResult["住址"]["words"] ?? "").ToString(),
                Birthday = (wordsResult["出生"]["words"] ?? "").ToString(),
                IdNo = (wordsResult["公民身份号码"]["words"] ?? "").ToString(),
                Name = (wordsResult["姓名"]["words"] ?? "").ToString(),
                Sex = (wordsResult["性别"]["words"] ?? "").ToString(),
                Nation = (wordsResult["民族"]["words"] ?? "").ToString()
            };
            return Task.FromResult(output);
        }

        public Task<GetBackInfoOutput> GetBackInfo(GetBackInfoInput input)
        {
            //移除data:image/jpeg;base64,
            if (input.Base64String.Contains(",")) input.Base64String = input.Base64String.Split(',')[1];
            var bytes = Convert.FromBase64String(input.Base64String);
            var result = BaiduAiHelper.Ocr.Idcard(bytes, "back", new Dictionary<string, object>
            {
                //精准度，精度越高，速度越慢。default：auto
                {"accuracy", "high"},
                //是否开启身份证风险类型(复印件、临时身份证、翻拍等类型)功能，默认不开启，即：false。可选值:true-开启；false-不开启
                {"detect_risk", "true"}
            });
            if (result["error_code"] != null) throw new BaiduApiException(result["error_msg"]?.ToString());
            var wordsResult = result["words_result"];
            var output = new GetBackInfoOutput
            {
                ExpiryDate = (wordsResult["失效日期"]["words"] ?? "").ToString(),
                IssueDate = (wordsResult["签发日期"]["words"] ?? "").ToString(),
                IssuingAuthority = (wordsResult["签发机关"]["words"] ?? "").ToString()
            };
            return Task.FromResult(output);
        }
    }
}