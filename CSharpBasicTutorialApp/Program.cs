using System;
using System.Threading.Tasks;

namespace CSharpBasicTutorialApp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 测试async await 使用两个方法不相互依赖

            //Method1();
            //Method2();
            //Console.ReadKey();
            #endregion

            #region await关键字对于等待Method 1任务的完成起着至关重要的作用。
            CallMethod();
            Console.ReadKey();
            #endregion

            /* Console.WriteLine( Math.Acosh(60) );
             Console.ReadLine();*/
        }


        public static async void CallMethod()
        {
            Task<int> task = Method1();
            Method2();
            int count = await task;
            Method3(count);
        }

        /// <summary>
        /// Method 1
        /// </summary>
        /// <returns></returns>
        public static async Task<int> Method1()
        {
            int count = 0;
            await Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine("Method 1");
                    count += 1;
                }
            });
            return count;

        }

        /// <summary>
        /// Method 2
        /// </summary>
        /// <returns></returns>
        public static void Method2()
        {
            for (int i = 0; i < 25; i++)
            {
                Console.WriteLine("Method 2");
            }

        }


        /// <summary>
        /// Method 3
        /// </summary>
        /// <returns></returns>
        public static void Method3(int count)
        {
            Console.WriteLine("Total count is " + count);
        }
    }
}