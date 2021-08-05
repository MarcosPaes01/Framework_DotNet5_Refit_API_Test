using NUnit.Framework;

using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Super.GlobalPlatform.Regression.Api.Util
{
    public class ReportService
    {
        private readonly string CurrentTestFolder = TestContext.CurrentContext.TestDirectory;
        private DirectoryInfo TestResultFolder;
        private DirectoryInfo SubTestFolder;

        public async Task GenerateReportAsync(string request, string response,
                HttpStatusCode statusCode, string url, string method)
        {
            var report = GetReport(request, response, statusCode, url, method);
            await SaveReportAsync(report);
        }

        private async Task SaveReportAsync(string report)
        {
            var path = GetPath();

            var name = TestContext.CurrentContext.Test.Name;

            name = Regex.Replace(name, "[^0-9A-Za-z]", "");

            var filename = $"{name}_{DateTime.Now:yyyyMMddHHmmssffffff}.txt";

            await SaveFileAsync(report, path, filename);
        }

        private DirectoryInfo GetPath()
        {
            TestResultFolder = Directory.CreateDirectory(Path.Combine(CurrentTestFolder, "TestResult"));

            var currentClassName = TestContext.CurrentContext.Test.ClassName;
            var currentMethodName = TestContext.CurrentContext.Test.MethodName;
            SubTestFolder = Directory.CreateDirectory
                (Path.Combine(TestResultFolder.FullName, currentClassName.Split(new[] { '.' }).Last(), currentMethodName));

            var fullPath = Directory.CreateDirectory(Path.Combine(SubTestFolder.FullName));

            return fullPath;
        }

        private async Task SaveFileAsync(string text, DirectoryInfo path, string filename)
        {
            FileStream fs = new FileStream(Path.Combine(path.FullName, filename), FileMode.Create, FileAccess.Write);

            using var sw = new StreamWriter(fs);

            await sw.WriteAsync(text);

            TestContext.AddTestAttachment(Path.Combine(path.FullName, filename));
        }

        private string GetReport(string requestBody, string responseBody,
            HttpStatusCode statusCode, string url, string method)
        {
            return $"================================================================= \n" +
                    $"URL: {url} \n" +
                    $"StatusCode: {statusCode} \n" +
                    $"Method: {method} \n" +
                    $"================================================================= \n" +
                    $"                           REQUEST                                \n" +
                    $"================================================================= \n" +
                    $"{requestBody} \n" +
                    $"================================================================= \n" +
                    $"                           RESPONSE                               \n" +
                    $"================================================================= \n" +
                    $"{responseBody} \n";
        }
    }
}

