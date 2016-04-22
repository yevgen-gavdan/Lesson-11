using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using StackOnDynamicArray;
using StackOnLinkedList;

namespace TestCommonInterfacesGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            test = new TestExecutor();
            btnStopTest.Enabled = false;
            numberOfObject = (int)numericUpDown1.Value;
        }
        private TestExecutor test;
        private string currentTestName;
        int numberOfObject;

        private void btnStartTest_Click(object sender, EventArgs e)
        {
            currentTestName = cmbTestList.Text;
            if (String.IsNullOrEmpty(currentTestName))
            {
                MessageBox.Show("Please select test from drop down list");
                return;
            }

            btnStartTest.Enabled = false;
            btnStopTest.Enabled = true;
            switch (currentTestName)
            {
                case "MyStack (DynamicArray based) us Stack<>":
                    var stackOnDynamicArray = new DynamicStack<TestExecutor.TestObject>();
                    backgroundWorker1.RunWorkerAsync(stackOnDynamicArray);
                    break;

                case "MyStack (Linked List based) us Stack<>":
                    var stackOnLinkedList = new MyStack<TestExecutor.TestObject>();
                    backgroundWorker1.RunWorkerAsync(stackOnLinkedList);
                    break;
            }

        }

        private void btnStopTest_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                backgroundWorker1.CancelAsync();
                btnStartTest.Enabled = true;
                btnStopTest.Enabled = false;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            test.RunTest((MyCommonInterfaces.IMyStack<TestExecutor.TestObject>)e.Argument, sender, numberOfObject);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.dataGridView1.Rows.Add(this.dataGridView1.Rows.Count + 1, currentTestName, test.MyStackTestDuration.Milliseconds, test.dNETTestDuration.Milliseconds);
            progressBar1.Value = 0;
            btnStartTest.Enabled = true;
            btnStopTest.Enabled = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numberOfObject = (int)numericUpDown1.Value;
        }

    }
}
