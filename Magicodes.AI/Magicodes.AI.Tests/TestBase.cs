using System;
using System.IO;
using Magicodes.AI.Baidu.Builder;

namespace Magicodes.AI.Tests
{
    public class TestBase
    {
        static TestBase()
        {
            BaiduAiBuilder
                .Create()
                .RegisterGetConfigFunc(() => new Baidu.Configuration.BaiduApiConfiguration()
                {
                    AppId = "dh0inRxNjGwoXaUaOfOE72Gf",
                    SecurityKey = "gh7Ow0IvsAVa8Y6cFEDGnjXgelrddrIB"
                }).Build();
        }

        protected Stream GetManifestResourceStream(string path)
        {
            return GetType().Assembly
                .GetManifestResourceStream(path);
        }

        protected string GetManifestResourceBase64String(string path)
        {
            using (var ms = GetManifestResourceStream(path))
            {
                var arr = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(arr, 0, (int)ms.Length);
                return Convert.ToBase64String(arr);
            }
        }
    }
}