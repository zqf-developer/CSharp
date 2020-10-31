using System;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpBasicTutorialApp
{
    class Program
    {
        static void Main()
        {
            #region 测试async await 使用两个方法不相互依赖

            //Method1();
            //Method2();
            //Console.ReadKey();
            #endregion

            #region await关键字对于等待Method 1任务的完成起着至关重要的作用。
            //CallMethod();
            //Console.ReadKey();
            #endregion

            #region Creating and running tasks explicitly
            //Thread.CurrentThread.Name = "Main";

            //// Create a task and supply a user delegate by using a lambda expression.
            ////Task taskA = new Task(() => Console.WriteLine("Hello from taskA."));

            //// Define and run the task.
            //Task taskA = Task.Run(() => Console.WriteLine("Hello from taskA."));

            //// Start the task.
            ////taskA.Start();

            //// Output a message from the calling thread.
            //Console.WriteLine("Hello from thread '{0}'.",
            //                  Thread.CurrentThread.Name);


            //taskA.Wait();//

            // The example displays output like the following:
            //       Hello from thread 'Main'.
            //       Hello from taskA.
            #endregion

            #region TaskFactory.StartNew method to create and start a task

            Task[] taskArray = new Task[10];
            for (int i = 0; i < taskArray.Length; i++)
            {
                taskArray[i] = Task.Factory.StartNew((Object obj) => {
                    CustomData data = obj as CustomData;
                    if (data == null)
                        return;

                    data.ThreadNum = Thread.CurrentThread.ManagedThreadId;
                },
                                                      new CustomData() { Name = i, CreationTime = DateTime.Now.Ticks });
            }
            Task.WaitAll(taskArray);
            foreach (var task in taskArray)
            {
                var data = task.AsyncState as CustomData;
                if (data != null)
                    Console.WriteLine("Task #{0} created at {1}, ran on thread #{2}.",
                                      data.Name, data.CreationTime, data.ThreadNum);
            }

            #endregion


            /* Console.WriteLine( Math.Acosh(60) );*/
            Console.ReadLine();
        }

        public class CustomData
        {
            public long CreationTime;
            public int Name;
            public int ThreadNum;
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