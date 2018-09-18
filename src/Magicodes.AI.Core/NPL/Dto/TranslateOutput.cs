using System.Collections.Generic;

namespace Magicodes.AI.Core.NPL.Dto
{
    /// <summary>
    ///     翻译返回
    /// </summary>
    public class TranslateOutput
    {
        /// <summary>
        ///     翻译源语言
        /// </summary>
        public string from { get; set; }

        /// <summary>
        ///     译文语言
        /// </summary>
        public string to { get; set; }

        /// <summary>
        ///     翻译结果
        /// </summary>
        public virtual IList<TransResult> trans_result { get; set; }

        /// <summary>
        ///     错误码
        /// </summary>
        public string error_code { get; set; }

        /// <summary>
        ///     错误消息
        /// </summary>
        public string error_msg { get; set; }
    }

    /// <summary>
    ///     翻译结果
    /// </summary>
    public class TransResult
    {
        /// <summary>
        ///     原文
        /// </summary>
        public string src { get; set; }

        /// <summary>
        ///     译文
        /// </summary>
        public string dst { get; set; }
    }
}