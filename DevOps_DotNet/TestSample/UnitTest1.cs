using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Diagnostics;
using System.IO;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            StartIIS();
            Driver = new ChromeDriver(Directory.GetCurrentDirectory());
        }


        /// <summary>
        /// WEB ブラウザのドライバーを取得します。
        /// </summary>
        protected IWebDriver Driver { get; private set; }

        /// <summary>
        /// IIS のポート
        /// </summary>
        private const int Port = 13301;

        /// <summary>
        /// IIS Express のプロセス
        /// </summary>
        private static Process _iisProcess;


        /// <summary>
        /// ベースアドレス
        /// </summary>
        protected static readonly string BaseAddress = $"http://localhost:{Port}";


        [Test]
        public void Test1()
        {
            Assert.Pass();
        }


        /// <summary>
        /// IIS Express を開始します。
        /// </summary>
        private static void StartIIS()
        {
            if (_iisProcess == null)
            {
                var applicationPath = GetApplicationPath("DevOps_DotNet");
                var programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
                var iisPath = Path.Combine(programFiles, "IIS Express", "iisexpress.exe");
                var startInfo = new ProcessStartInfo
                {
                    FileName = iisPath,
                    Arguments = $"/path:\"{applicationPath}\" /port:{Port}",
                };
                _iisProcess = Process.Start(startInfo);
            }
        }

        /// <summary>
        /// ソリューションフォルダ直下にあるテスト対象アプリのフォルダパスを取得します。
        /// </summary>
        /// <returns>テスト対象アプリのフォルダパス</returns>
        private static string GetApplicationPath(string applicationName)
        {
            var solutionFolder = Path.GetDirectoryName(
                Path.GetDirectoryName(
                    Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)));
            return Path.Combine(solutionFolder, applicationName);
        }

        /// <summary>
        /// IIS Express を停止します。
        /// </summary>
        private static void StopIIS()
        {
            if (_iisProcess != null &&
                _iisProcess.HasExited == false)
            {
                _iisProcess.Kill();
            }
        }

        [TearDown]
        public void SetDown()
        {
            StopIIS();
            Driver.Quit();
        }
    }
}