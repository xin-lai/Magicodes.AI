using System;
using System.Collections.Generic;
using System.Text;

namespace Magicodes.AI.Core.NPL.Dto
{
    /// <summary>
    /// 翻译入参
    /// </summary>
    public class TranslateInput
    {
        /// <summary>
        /// 翻译文本
        /// </summary>
        public string TranslatedText { get; set; }

        /// <summary>
        /// 源语言
        /// </summary>
        public TranslateLanguage? FromLanguage  { get; set; }


        /// <summary>
        /// 源语言
        /// </summary>
        public TranslateLanguage ToLanguage { get; set; }

        /// <summary>
        /// API请求类型
        /// </summary>
        public RequestType RequestType { get; set; }
    }
}
