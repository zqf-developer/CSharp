using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesMovie.Dependency
{
    /// <summary>
    /// index的model都是依赖PageModel类
    /// </summary>
    public class IndexModel:PageModel
    {
        /// <summary>
        /// 要用不同的实现替换 MyDependency，必须修改类。
        ///如果 MyDependency 具有依赖关系，则必须由类对其进行配置。
        ///在具有多个依赖于 MyDependency 的类的大型项目中，配置代码在整个应用中会变得分散。 这种实现很难进行单元测试。 应用应使/用模拟或存根 MyDependency 类，该类不能使用此方法。
        ///依赖关系注入通过以下方式解决了这些问题： 使用接口或基类抽象化依赖关系实现。
        /// </summary>
        //MyDependency _dependency = new MyDependency();


        private readonly IMyDependency _myDependency;

        public IndexModel(IMyDependency myDependency)
        {
            _myDependency = myDependency;
        }

        /// <summary>
        /// C#提供Async和Await关键字来实现异步编程
        /// </summary>
        /// <returns></returns>
        public async Task OnGetAsync()
        {
            await _myDependency.WriteMessage(
            "IndexModel.OnGetAsync created this message.");
        }
    }
}
