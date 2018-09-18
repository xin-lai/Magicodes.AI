// ======================================================================
//   
//           Copyright (C) 2018-2020 湖南心莱信息科技有限公司    
//           All rights reserved
//   
//           filename : BaiduAIHelper.cs
//           description :
//   
//           created by 雪雁 at  2018-08-02 14:08
//           Mail: wenqiang.li@xin-lai.com
//           QQ群：85318032（技术交流）
//           Blog：http://www.cnblogs.com/codelove/
//           GitHub：https://github.com/xin-lai
//           Home：http://xin-lai.com
//   
// ======================================================================

using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Baidu.Aip.Ocr;
using Magicodes.AI.Baidu.Configuration;
using Magicodes.AI.Core.NPL.Dto;
using Newtonsoft.Json;

namespace Magicodes.AI.Baidu.Helper
{
    /// <summary>
    /// BaiduAiHelper
    /// </summary>
    public static class BaiduAiHelper
    {
        private static Ocr _sOcr;

        internal static Func<BaiduApiConfiguration> GetOcrConfigFunc { get; set; }

        internal static Func<BaiduApiConfiguration> GetNlpConfigFunc { get; set; }

        /// <summary>
        /// OCR识别API
        /// </summary>
        public static Ocr Ocr
        {
            get
            {
                if (_sOcr != null) return _sOcr;
                var config = GetOcrConfigFunc();
                _sOcr = new Ocr(config.AppId, config.SecurityKey);
                return _sOcr;
            }
            set => _sOcr = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static TranslateOutput PostTranslate(TranslateInput input)
        {
            var config = GetNlpConfigFunc();
            string requestUrl;
            switch (input.RequestType)
            {
                case RequestType.Http:
                    requestUrl = "http://api.fanyi.baidu.com/api/trans/vip/translate";
                    break;
                case RequestType.Https:
                    requestUrl = "https://fanyi-api.baidu.com/api/trans/vip/translate";
                    break;
                default:
                    throw new BaiduApiException("请求API地址报错！");
            }
            var utf8 = Encoding.UTF8.GetBytes(input.TranslatedText);
            input.TranslatedText = Encoding.UTF8.GetString(utf8);
            var salt = GenerateSalt();
            var sign = GenerateSign(input, salt, config.AppId,config.SecurityKey);
            var from = input.FromLanguage == null ? "auto" : input.FromLanguage.ToString();
            var postStr =
                $"q={input.TranslatedText}&from={from}&to={input.ToLanguage.ToString()}&appid={config.AppId}&salt={salt}&sign={sign}";
            var result = HttpPost(requestUrl, postStr);
            return result;
        }

        private static string GenerateSalt()
        {
            var salt = DateTime.Now.Ticks.ToString();
            return salt;
        }

        private static string GenerateSign(TranslateInput input,string salt, string appId,string securityKey)
        {
            var sb = $"{appId}{input.TranslatedText}{salt}{securityKey}";
            var md5 = MD5.Create();
            var bs = md5.ComputeHash(Encoding.UTF8.GetBytes(sb));
            var sbuilder = new StringBuilder();
            foreach (var b in bs)
                sbuilder.Append(b.ToString("x2"));
            return sbuilder.ToString().ToLower();
        }

        private static TranslateOutput HttpPost(string url, string postData)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            if (!string.IsNullOrWhiteSpace(postData))
            {
                var bytesToPost = Encoding.UTF8.GetBytes(postData);
                request.ContentLength = bytesToPost.Length;
                using (var requestStream = request.GetRequestStream())
                {
                    requestStream.Write(bytesToPost, 0, bytesToPost.Length);
                    requestStream.Close();
                }
            }
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (var sr = new StreamReader(response.GetResponseStream()))
                {
                    var result = sr.ReadToEnd();
                    var translateResponse = JsonConvert.DeserializeObject<TranslateOutput>(result);
                    return translateResponse;
                }
            }
        }
    }
}