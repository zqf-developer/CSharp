using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace RazorPagesMovie.Dependency
{
    /// <summary>
    /// IMyDependency 接口定义了服务为应用提供的方法： 此接口由具体类型 MyDependency 实现：
    /// </summary>
    public class MyDependency : IMyDependency
    {
        private readonly ILogger<MyDependency> _logger;

        public MyDependency(ILogger<MyDependency> logger)
        {
            _logger = logger;
        }

        public Task WriteMessage(string message)
        {
            _logger.LogInformation("MyDependency.WriteMessage called. Message:{message}");
         /*   Console.WriteLine($"MyDependency.WriteMessage called. Message:{message}");*/
            return Task.FromResult(0);
        }
    }
}
