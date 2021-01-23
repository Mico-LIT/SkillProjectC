using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.Threading.TPL
{
    public class _015_TPL_Exception
    {
        public _015_TPL_Exception()
        {
            Task task = new Task(MyTask);

            try
            {
                task.Start();
                task.Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception:        {ex.GetType()}");
                Console.WriteLine($"Message:          {ex.Message}");

                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception  {ex.InnerException}");
                }
            }
            finally
            {
                Console.WriteLine($" State Task : {task.Status}");
            }

        }

        static void MyTask()
        {
            Console.WriteLine("Running task");

            // throw new Exception(); // For Test

            Console.WriteLine("Is Completed task");
        }
    }
}
