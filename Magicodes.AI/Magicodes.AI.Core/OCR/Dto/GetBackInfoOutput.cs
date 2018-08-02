// ======================================================================
//   
//           Copyright (C) 2018-2020 湖南心莱信息科技有限公司    
//           All rights reserved
//   
//           filename : GetBackInfoOutput.cs
//           description :
//   
//           created by 雪雁 at  2018-08-02 9:45
//           Mail: wenqiang.li@xin-lai.com
//           QQ群：85318032（技术交流）
//           Blog：http://www.cnblogs.com/codelove/
//           GitHub：https://github.com/xin-lai
//           Home：http://xin-lai.com
//   
// ======================================================================

namespace Magicodes.AI.Core.OCR.Dto
{
    public class GetBackInfoOutput
    {
        /// <summary>
        ///     签发日期
        /// </summary>
        public string IssueDate { get; set; }

        /// <summary>
        ///     签发机关
        /// </summary>
        public string IssuingAuthority { get; set; }

        /// <summary>
        ///     失效日期
        /// </summary>
        public string ExpiryDate { get; set; }
    }
}