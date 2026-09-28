using UnityEngine;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Assignment
{
    public class StudentSolution : IAssignment
    {
        #region Lecture
        public int[] LCT01_SelectionSortAscending(int[] numbers)
        {
            int n = numbers.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (numbers[j] < numbers[minIndex])
                    {
                        minIndex = j;
                    }
                }
                int temp = numbers[minIndex];
                numbers[minIndex] = numbers[i];
                numbers[i] = temp;
                (numbers[i], numbers[minIndex]) = (numbers[minIndex], numbers[i]);
            }
            foreach (var n_ in numbers)
            {
                Debug.Log(n_);
            }
            return numbers;
        }

        public int[] LCT02_BubbleSortAscending(int[] numbers)

        {

            int n = numbers.Length;

            for (int i = 0; i < n - 1; i++)
            {

                for (int j = 0; j < n - i - 1; j++)
                {

                    if (numbers[j] > numbers[j + 1])
                    {

                        int temp = numbers[j];

                        numbers[j] = numbers[j + 1];

                        numbers[j + 1] = temp;

                    }

                }

            }

            foreach (var n_ in numbers)
            {

                Debug.Log(n_);

            }

            return numbers;

        }

        public int[] LCT03_InsertionSortAscending(int[] numbers)

        {

            int n = numbers.Length;

            for (int i = 0; i < n; i++)
            {

                int key = numbers[i];

                int j = i - 1;

                while (j >= 0 && numbers[j] > key)
                {

                    numbers[j + 1] = numbers[j];

                    j--;

                }

                numbers[j + 1] = key;

            }

            foreach (var n_ in numbers)

            {

                Debug.Log(n_);

            }

            return numbers;

        }


        #endregion

        #region Assignment

        public int[] AS01_SelectionSortDescending(int[] numbers)
        {
            int[] result = (int[])numbers.Clone();

            for (int i = 0; i < result.Length - 1; i++)
            {
                int maxIndex = i;

                for (int j = i + 1; j < result.Length; j++)
                {
                    if (result[j] > result[maxIndex])
                    {
                        maxIndex = j;
                    }
                }

                int temp = result[i];
                result[i] = result[maxIndex];
                result[maxIndex] = temp;
            }

            return result;
        }


        public int[] AS02_BubbleSortDescending(int[] numbers)
        {
            int[] result = (int[])numbers.Clone();

            for (int i = 0; i < result.Length - 1; i++)
            {
                for (int j = 0; j < result.Length - 1 - i; j++)
                {
                    if (result[j] < result[j + 1])
                    {
                        int temp = result[j];
                        result[j] = result[j + 1];
                        result[j + 1] = temp;
                    }
                }
            }

            return result;
        }


        public int[] AS03_InsertionSortDescending(int[] numbers)
        {
            int[] result = (int[])numbers.Clone();

            for (int i = 1; i < result.Length; i++)
            {
                int current = result[i];
                int j = i - 1;

                while (j >= 0 && result[j] < current)
                {
                    result[j + 1] = result[j];
                    j--;
                }

                result[j + 1] = current;
            }

            return result;
        }


        public int AS04_FindTheSecondLargestNumber(int[] numbers)
        {
            int largest = numbers[0];
            int secondLargest = numbers[0];
            bool foundSecond = false;

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > largest)
                {
                    secondLargest = largest;
                    largest = numbers[i];
                    foundSecond = true;
                }
                else if (numbers[i] < largest)
                {
                    if (!foundSecond || numbers[i] > secondLargest)
                    {
                        secondLargest = numbers[i];
                        foundSecond = true;
                    }
                }
            }

            return secondLargest;
        }

        #endregion

        public int EX01_FindLongestConsecutiveSequence(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                return 0;
            }

            int[] sorted = (int[])numbers.Clone();

            // Selection Sort
            for (int i = 0; i < sorted.Length - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < sorted.Length; j++)
                {
                    if (sorted[j] < sorted[minIndex])
                    {
                        minIndex = j;
                    }
                }

                int temp = sorted[i];
                sorted[i] = sorted[minIndex];
                sorted[minIndex] = temp;
            }

            int longest = 1;
            int current = 1;

            for (int i = 1; i < sorted.Length; i++)
            {
                // ข้ามค่าที่ซ้ำ
                if (sorted[i] == sorted[i - 1])
                {
                    continue;
                }

                // ตัวเลขต่อเนื่องกัน
                if ((long)sorted[i] == (long)sorted[i - 1] + 1)
                {
                    current++;

                    if (current > longest)
                    {
                        longest = current;
                    }
                }
                else
                {
                    current = 1;
                }
            }

            return longest;
        }

    }
}
