/**************************************************************************************
File name: UnitTest.cs
Purpose:   1. Tests methods implemented in the MathQuizApp solution
Version: 1.0.0
Author: ┬  ┬ ┬┬┌─┌─┐┬ ┬┌─┐╦╔╦╗
        │  │ │├┴┐├┤ │││├─┤║ ║
        ┴─┘└─┘┴ ┴└─┘└┴┘┴ ┴╩ ╩
Date: February 16, 2023
License: MIT License

GitHub Repository: https://github.com/LukeWait/math-quiz-app
**************************************************************************************/

using MathQuestion;
using NUnit.Framework;
using System.Collections.Generic;

namespace NUnitTest
{
    public class Tests
    {
        // create a MathQues list
        List<MathQues> quesList = new List<MathQues>();

        [SetUp]
        public void Setup()
        {
            // populate the MathQues list with data to be used with tests
            quesList.Add(new MathQues(1, "+", 1, 2));
            quesList.Add(new MathQues(2, "*", 2, 4));
            quesList.Add(new MathQues(4, "-", 3, 1));
            quesList.Add(new MathQues(20, "/", 1, 20));
        }

        /****************************************************************************
        Method:     BubbleSort()
        Purpose:    Sorts a list of math questions in asc or desc order with
                    the bubble sort technique
        Input:      List<MathQues> (the list to be sorted)
                    String (order to sort the list, asc or desc)
        Output:     void
        ****************************************************************************/
        /// <summary>
        /// BubbleSort()
        /// </summary>
        /// <param name="list">The list to be sorted</param>
        /// <param name="order">Order to sort the list, asc or desc</param>
        public void BubbleSort(List<MathQues> list, string order)
        {
            int swapCounter = 0;

            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count - 1; j++)
                {
                    if (order.Equals("asc"))
                    {
                        if (list[i].Answer < list[j].Answer)
                        {
                            // swap values
                            MathQues temp = list[i];
                            list[i] = list[j];
                            list[j] = temp;
                            swapCounter++;
                        }
                    }
                    else if (order.Equals("desc"))
                    {
                        if (list[i].Answer > list[j].Answer)
                        {
                            // swap values
                            MathQues temp = list[i];
                            list[i] = list[j];
                            list[j] = temp;
                            swapCounter++;
                        }
                    }

                }
            }
        }// end BubbleSort()

        /****************************************************************************
        Method:     BinarySearch()
        Purpose:    returns an index value respective to the found value in a sorted array of integers
        Input:      List<MathQues> (sorted list of math questions to search through)
                    MathQues (question to search for)
        Output:     int (index position of the array where the value was found)
        ****************************************************************************/
        /// <summary>
        /// BinarySearch() method
        /// </summary>
        /// <param name="list">List of questions to be compared to</param>
        /// <param name="quesToSearch">Question to be compared</param>
        /// <returns>Index of found question</returns>
        static int BinarySearch(List<MathQues> list, string quesToSearch)
        {
            bool foundStatus = false;
            int firstIndex = 0;
            int lastIndex = list.Count - 1;
            int posFound = -1;

            // loop while foundStatus is false AND first is less than or equal to last
            while (!foundStatus && firstIndex <= lastIndex)
            {
                // get mid index value
                int mid = (firstIndex + lastIndex) / 2;

                // check if number to search is less than the value positioned in the middle of the sorted array
                // if it is, then change the last position to that of the middle less 1
                // this way, last becomes the last value in the sorted upper half of the array
                if (quesToSearch.CompareTo(list[mid].ToString()) < 0)
                {
                    lastIndex = mid - 1;
                }
                // check if number to search is greater than the value positioned in the middle of the sorted array
                // if it is, then change the first position to that of the middle plus 1
                // this way, first becomes the first value in the sorted lower half of the array
                else if (quesToSearch.CompareTo(list[mid].ToString()) > 0)
                {
                    firstIndex = mid + 1;
                }
                // otherwise, the value has been found
                else
                {
                    foundStatus = true;
                    posFound = mid;
                }
            }
            return posFound;

        }// end BinarySearch()

        [Test]
        public void BubbleSortAscTest()
        {
            // create an expected MathQues list
            List<MathQues> expectedQuesList = new List<MathQues>
            {
                new MathQues(4, "-", 3, 1),
                new MathQues(1, "+", 1, 2),
                new MathQues(2, "*", 2, 4),
                new MathQues(20, "/", 1, 20)
            };

            BubbleSort(quesList, "asc");
           
            // converted Lists to strings as NUnit was returning a fail despite saying that
            // the values of each element where the same
            string sortedListString = "";
            string expectedString = "";           
            foreach(MathQues s in expectedQuesList)
            {
                sortedListString = s.ToString();
            }
            foreach (MathQues s in quesList)
            {
                expectedString = s.ToString();
            }

            Assert.AreEqual(sortedListString, expectedString);
        }

        [Test]
        public void BubbleSortDescTest()
        {
            // create an expected MathQues list
            List<MathQues> expectedQuesList = new List<MathQues>
            {
                new MathQues(20, "/", 1, 20),
                new MathQues(2, "*", 2, 4),
                new MathQues(1, "+", 1, 2),
                new MathQues(4, "-", 3, 1)
            };

            BubbleSort(quesList, "desc");
            
            string sortedListString = "";
            string expectedString = "";
            foreach (MathQues s in expectedQuesList)
            {
                sortedListString = s.ToString();
            }
            foreach (MathQues s in quesList)
            {
                expectedString = s.ToString();
            }

            Assert.AreEqual(sortedListString, expectedString);
        }
        
        [Test]
        public void BinarySearchFoundTest()
        {
            int foundIndex = BinarySearch(quesList, "2 * 2 = 4");
            int expectedIndex = 1;

            Assert.AreEqual(foundIndex, expectedIndex);
        }

        [Test]
        public void BinarySearchNotFoundTest()
        {
            int foundIndex = BinarySearch(quesList, "2 * 3 = 6");
            int expectedIndex = -1;

            Assert.AreEqual(foundIndex, expectedIndex);
        }
    }
}