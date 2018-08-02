// ======================================================================
//   
//           Copyright (C) 2018-2020 湖南心莱信息科技有限公司    
//           All rights reserved
//   
//           filename : BaiduAIBuilder.cs
//           description :
//   
//           created by 雪雁 at  2018-08-02 14:03
//           Mail: wenqiang.li@xin-lai.com
//           QQ群：85318032（技术交流）
//           Blog：http://www.cnblogs.com/codelove/
//           GitHub：https://github.com/xin-lai
//           Home：http://xin-lai.com
//   
// ======================================================================

using System;
using Magicodes.AI.Baidu.Configuration;
using Magicodes.AI.Baidu.Helper;

namespace Magicodes.AI.Baidu.Builder
{
    /// <summary>
    /// </summary>
    public class BaiduAiBuilder
    {
        private Func<BaiduApiConfiguration> GetConfigFunc { get; set; }

        /// <summary>
        ///     创建实例
        /// </summary>
        /// <returns></returns>
        public static BaiduAiBuilder Create()
        {
            return new BaiduAiBuilder();
        }

        /// <summary>
        ///     注册配置获取逻辑
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public BaiduAiBuilder RegisterGetConfigFunc(Func<BaiduApiConfiguration> func)
        {
            GetConfigFunc = func;
            return this;
        }

        /// <summary>
        ///     确定配置
        /// </summary>
        public void Build()
        {
            if (GetConfigFunc != null)
                BaiduAiHelper.GetConfigFunc = GetConfigFunc;
        }
    }
}