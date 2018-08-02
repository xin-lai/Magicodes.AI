// ======================================================================
//   
//           Copyright (C) 2018-2020 湖南心莱信息科技有限公司    
//           All rights reserved
//   
//           filename : GetFrontInfoOutput.cs
//           description :
//   
//           created by 雪雁 at  2018-08-02 9:42
//           Mail: wenqiang.li@xin-lai.com
//           QQ群：85318032（技术交流）
//           Blog：http://www.cnblogs.com/codelove/
//           GitHub：https://github.com/xin-lai
//           Home：http://xin-lai.com
//   
// ======================================================================

namespace Magicodes.AI.Core.OCR.Dto
{
    public class GetFrontInfoOutput
    {
        /// <summary>
        ///     地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        ///     姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     性别
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        ///     生日
        /// </summary>
        public string Birthday { get; set; }

        /// <summary>
        ///     证件号码
        /// </summary>
        public string IdNo { get; set; }

        /// <summary>
        ///     民族
        /// </summary>
        public string Nation { get; set; }
    }
}