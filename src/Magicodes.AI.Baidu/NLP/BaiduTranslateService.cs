using System.Threading.Tasks;
using Magicodes.AI.Baidu.Helper;
using Magicodes.AI.Core.NPL;
using Magicodes.AI.Core.NPL.Dto;

namespace Magicodes.AI.Baidu.NLP
{
    public class BaiduTranslateService: IBaiduTranslateService
    {
        public Task<TranslateOutput> Translate(TranslateInput input)
        {
            var output = BaiduAiHelper.PostTranslate(input);
            return Task.FromResult(output);
        }
    }
}
