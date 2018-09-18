using System.Threading.Tasks;
using Magicodes.AI.Core.NPL.Dto;

namespace Magicodes.AI.Core.NPL
{
    /// <summary>
    /// 百度翻译服务
    /// </summary>
    public interface IBaiduTranslateService
    {
        /// <summary>
        /// 翻译.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        Task<TranslateOutput> Translate(TranslateInput input);
    }
}
