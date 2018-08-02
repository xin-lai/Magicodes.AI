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
using Baidu.Aip.Ocr;
using Magicodes.AI.Baidu.Configuration;

namespace Magicodes.AI.Baidu.Helper
{
    public static class BaiduAiHelper
    {
        private static Ocr _sOcr;

        internal static Func<BaiduApiConfiguration> GetConfigFunc { get; set; }

        /// <summary>
        /// OCR识别API
        /// </summary>
        public static Ocr Ocr
        {
            get
            {
                if (_sOcr != null) return _sOcr;
                var config = GetConfigFunc();
                _sOcr = new Ocr(config.AppId, config.SecurityKey);
                return _sOcr;
            }
            set => _sOcr = value;
        }
    }
}