// ======================================================================
//   
//           Copyright (C) 2018-2020 湖南心莱信息科技有限公司    
//           All rights reserved
//   
//           filename : IIdcardService.cs
//           description :
//   
//           created by 雪雁 at  2018-08-02 9:40
//           Mail: wenqiang.li@xin-lai.com
//           QQ群：85318032（技术交流）
//           Blog：http://www.cnblogs.com/codelove/
//           GitHub：https://github.com/xin-lai
//           Home：http://xin-lai.com
//   
// ======================================================================

using System.Threading.Tasks;
using Magicodes.AI.Core.OCR.Dto;

namespace Magicodes.AI.Core.OCR
{
    /// <summary>
    ///     身份证识别服务
    /// </summary>
    public interface IIdcardService
    {
        /// <summary>
        ///     身份证正面识别（个人信息那面）
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetFrontInfoOutput> GetFrontInfo(GetFrontInfoInput input);

        /// <summary>
        ///     身份证背面识别（国徽那面）
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetBackInfoOutput> GetBackInfo(GetBackInfoInput input);
    }
}