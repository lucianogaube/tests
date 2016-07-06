using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestControlExpert
{
    public static class OrderedListofLists
    {
        /// <summary>
        /// You are given a List of objects.
        /// You must print every item of the list, including a number that represents an element orer and level.
        /// You sould print elements that are Int32 or strings.
        /// If an element is a List of objects, it should represent elements of a new sub-level.        
        /// Each element should be printed on a new line and preceed by its level number.
        /// Ex: If you receive the following list:
        /// 
        /// new List<object>(){
        ///                     350,
        ///                     "Banana",
        ///                     new List<object>(){
        ///                         "second level",
        ///                         "nice",
        ///                         new List<object>(){
        ///                             3
        ///                         },
        ///                     },
        ///                     "last"
        ///                    };
        ///                    
        /// Then the output should be:
        /// 
        /// 1 350
        /// 2 Banana
        /// 2.1 second level
        /// 2.2 nice
        /// 2.2.1 3
        /// 3 last
        /// 
        /// </summary>

        public static void Run()
        {
            var list = new List<object>
            {
                 350,
                 "Banana",
                 new List<object>(){
                     "second level",
                     "nice",
                     new List<object>{
                         3
                     },
                 },
                 "last"
            };

            ExecuteConsole(list);
        }


        private static void ExecuteConsole(List<object> list)
        {
            var result = Solve(list);
            Console.WriteLine(result);
        }

        /// <summary>
        /// Returning string for Unit tests
        /// </summary>
        /// <param name="list"></param>
        /// <param name="level"></param>
        /// <returns>String containing the result</returns>
        public static string Solve(List<object> list, string level = "")
        {
            var itemIndex = 0;
            var result = new StringBuilder();

            foreach (var item in list)
            {
                var listItem = item as List<object>;

                if (listItem != null)
                {
                    if (itemIndex == 0)
                    {
                        itemIndex = 1;
                    }

                    result.Append(Solve(listItem, $"{level}{itemIndex}."));
                }
                else
                {
                    itemIndex++;
                    result.AppendLine($"{level}{itemIndex} {item}");
                }
            }
            return result.ToString();
        }
    }

    [TestFixture]
    public class ControlExpertTest
    {
        private List<object> _testList;

        [SetUp]
        public void Init()
        {
            _testList = new List<object>
            {
                 350,
                 "Banana",
                 new List<object>{
                     "second level",
                     "nice",
                     new List<object>{
                         3
                     },
                 },
                 "last"
            };
        }


        [Test]
        public void Test_case_1()
        {
            var testResult = OrderedListofLists.Solve(_testList);

            var expected = new StringBuilder();
            expected.AppendLine("1 350");
            expected.AppendLine("2 Banana");
            expected.AppendLine("2.1 second level");
            expected.AppendLine("2.2 nice");
            expected.AppendLine("2.2.1 3");
            expected.AppendLine("3 last");


            Assert.AreEqual(expected.ToString(), testResult);
        }

        [Test]
        public void Test_case_2()
        {
            _testList = new List<object>
            {
                 "item 1",
                 "item 2",
                 "item 3",
                 new List<object>{
                     "level 2, item 1",
                     "level 2, item 2",
                     new List<object>{
                         "level 3, item 1",
                          new List<object>{
                             "level 4, item 1",
                             "level 4, item 2"
                          },
                         "level 3, item 2",
                     },
                     "level 2, item 3",
                 },
                 "last item"
            };

            var testResult = OrderedListofLists.Solve(_testList);

            var expected = new StringBuilder();
            expected.AppendLine("1 item 1");
            expected.AppendLine("2 item 2");
            expected.AppendLine("3 item 3");
            expected.AppendLine("3.1 level 2, item 1");
            expected.AppendLine("3.2 level 2, item 2");
            expected.AppendLine("3.2.1 level 3, item 1");
            expected.AppendLine("3.2.1.1 level 4, item 1");
            expected.AppendLine("3.2.1.2 level 4, item 2");
            expected.AppendLine("3.2.2 level 3, item 2");
            expected.AppendLine("3.3 level 2, item 3");
            expected.AppendLine("4 last item");

            Assert.AreEqual(expected.ToString(), testResult);
        }
    }


}
