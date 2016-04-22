using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackOnDynamicArray;
using StackOnLinkedList;
using MyCommonInterfaces;
using System.ComponentModel;

namespace TestCommonInterfacesGUI
{
    class TestExecutor
    {
        public TimeSpan MyStackTestDuration { get; private set; }
        public TimeSpan dNETTestDuration { get; set; }
        
        public void RunTest(MyCommonInterfaces.IMyStack<TestObject> stack, object sender, int numberOfItemsToPush)
        {
            var dNETStack = new Stack<TestObject>();
            var startTime = DateTime.Now;
            BackgroundWorker worker = sender as BackgroundWorker;

            //Testing my implementation
            for (int i = 0; i < numberOfItemsToPush && worker.CancellationPending == false; i++)
            {
                stack.Push(new TestObject(i));
                worker.ReportProgress((i*25) / numberOfItemsToPush);
            }
            for (int i = 0; i < numberOfItemsToPush && worker.CancellationPending == false; i++)
            {
                stack.Pop();
                worker.ReportProgress(25 + (i * 25) / numberOfItemsToPush);
            }
            var stopTime = DateTime.Now;
            MyStackTestDuration = stopTime - startTime;

            //Testing .NET Implementation
            startTime = DateTime.Now;
            for (int i = 0; i < numberOfItemsToPush && worker.CancellationPending == false; i++)
            {
                dNETStack.Push(new TestObject(i));
                worker.ReportProgress(50 + (i * 25) / numberOfItemsToPush);
            }
            for (int i = 0; i < numberOfItemsToPush && worker.CancellationPending == false; i++)
            {
                dNETStack.Pop();
                worker.ReportProgress(75 + (i * 25) / numberOfItemsToPush);
            }
            stopTime = DateTime.Now;
            dNETTestDuration = stopTime - startTime;
        }

        public class TestObject
        {
            private int ID = 0;
            public TestObject(int counter) { ID = counter; }
        }
    }
}

