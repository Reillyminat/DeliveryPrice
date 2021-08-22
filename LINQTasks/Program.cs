using System;

namespace LINQTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            var example = new LinqExamples(new TestData());
            example.QueryTask();
        }
    }
}
