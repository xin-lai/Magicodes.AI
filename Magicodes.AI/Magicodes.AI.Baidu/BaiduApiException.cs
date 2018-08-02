// ======================================================================
//   
//           Copyright (C) 2018-2020 湖南心莱信息科技有限公司    
//           All rights reserved
//   
//           filename : BaiduApiException.cs
//           description :
//   
//           created by 雪雁 at  2018-08-02 11:17
//           Mail: wenqiang.li@xin-lai.com
//           QQ群：85318032（技术交流）
//           Blog：http://www.cnblogs.com/codelove/
//           GitHub：https://github.com/xin-lai
//           Home：http://xin-lai.com
//   
// ======================================================================

using System;

namespace Magicodes.AI.Baidu
{
    /// <summary>
    ///     百度API异常信息
    /// </summary>
    public class BaiduApiException : Exception
    {
        public BaiduApiException(string message) : base(message)
        {
        }
    }
}