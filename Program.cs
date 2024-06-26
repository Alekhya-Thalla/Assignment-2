﻿using System.Text;

namespace Assignment_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int numberOfUniqueNumbers = RemoveDuplicates(nums1);
            Console.WriteLine(numberOfUniqueNumbers);

            //Question 2:
            Console.WriteLine("Question 2:");
            int[] nums2 = { 0, 1, 0, 3, 12 };
            IList<int> resultAfterMovingZero = MoveZeroes(nums2);
            string combinationsString = ConvertIListToArray(resultAfterMovingZero);
            Console.WriteLine(combinationsString);

            //Question 3:
            Console.WriteLine("Question 3:");
            int[] nums3 = { -1, 0, 1, 2, -1, -4 };
            IList<IList<int>> triplets = ThreeSum(nums3);
            string tripletResult = ConvertIListToNestedList(triplets);
            Console.WriteLine(tripletResult);

            //Question 4:
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 1, 0, 1, 1, 1 };
            int maxOnes = FindMaxConsecutiveOnes(nums4);
            Console.WriteLine(maxOnes);

            //Question 5:
            Console.WriteLine("Question 5:");
            int binaryInput = 101010;
            int decimalResult = BinaryToDecimal(binaryInput);
            Console.WriteLine(decimalResult);

            //Question 6:
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 6, 9, 1 };
            int maxGap = MaximumGap(nums5);
            Console.WriteLine(maxGap);

            //Question 7:
            Console.WriteLine("Question 7:");
            int[] nums6 = { 2, 1, 2 };
            int largestPerimeterResult = LargestPerimeter(nums6);
            Console.WriteLine(largestPerimeterResult);

            //Question 8:
            Console.WriteLine("Question 8:");
            string result = RemoveOccurrences("daabcbaabcbc", "abc");
            Console.WriteLine(result);
        }

        /*
        
        Question 1:
        Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same. Then return the number of unique elements in nums.

        Consider the number of unique elements of nums to be k, to get accepted, you need to do the following things:

        Change the array nums such that the first k elements of nums contain the unique elements in the order they were present in nums initially. The remaining elements of nums are not important as well as the size of nums.
        Return k.

        Example 1:

        Input: nums = [1,1,2]
        Output: 2, nums = [1,2,_]
        Explanation: Your function should return k = 2, with the first two elements of nums being 1 and 2 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
        Example 2:

        Input: nums = [0,0,1,1,1,2,2,3,3,4]
        Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
        Explanation: Your function should return k = 5, with the first five elements of nums being 0, 1, 2, 3, and 4 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
 

        Constraints:

        1 <= nums.length <= 3 * 104
        -100 <= nums[i] <= 100
        nums is sorted in non-decreasing order.
        */

        public static int RemoveDuplicates(int[] nums)
        {
            try
            {
                if (nums == null || nums.Length == 0)
                    return 0; // Return 0 if array is empty or null

                int k = 1; // Initializing with one as the first element is always unique.

                for (int i = 1; i < nums.Length; i++)// Iterate through the array starting from the second element
                {
                    if (nums[i] != nums[i - 1]) // Checking if the current element is different from the previous one
                    {
                        nums[k] = nums[i]; // Moving the unique element to the next position
                        k++; // Increase the count of unique elements
                    }
                }
                return k;// Return the count of unique elements
            }
            catch (Exception)
            {
                throw;// Re-throw any exceptions that occur during processing
            }
        }

        /*Self- Reflection
         
        - This code efficiently identifies and counts unique elements in a sorted array, compacting them at the array's start.
        - It checks for non-duplicates by comparing each element with its predecessor, moving unique ones forward, and incrementally tracking the count of unique elements. 
        - The process begins by ensuring the array isn't empty or null, and employs a try-catch block for robust error handling, showcasing a practical and memory-efficient approach to array deduplication.
         */

        /*
        
        Question 2:
        Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

        Note that you must do this in-place without making a copy of the array.

        Example 1:

        Input: nums = [0,1,0,3,12]
        Output: [1,3,12,0,0]
        Example 2:

        Input: nums = [0]
        Output: [0]
 
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1
        */

        public static IList<int> MoveZeroes(int[] nums)
        {
            try
            {
                // Check if array is null or has only one element
                if (nums == null || nums.Length <= 1)
                    return nums.ToList(); // If so, return the array as a list

                int nonZeroIndex = 0; // Keep track of position for non-zero elements

                // Iterate through the array
                for (int i = 0; i < nums.Length; i++)
                {
                    // If current element is non-zero
                    if (nums[i] != 0)
                    {
                        // Move non-zero element to its correct position
                        nums[nonZeroIndex] = nums[i];
                        nonZeroIndex++; // Increment position for next non-zero element
                    }
                }

                // Fill the remaining positions from nonZeroIndex to end of array with zeroes
                for (int i = nonZeroIndex; i < nums.Length; i++)
                {
                    nums[i] = 0; // Fill with zeroes
                }

                // Convert array to list and return
                return nums.ToList();
            }
            catch (Exception)
            {
                throw; // Rethrow any exceptions
            }
        }
        /*Self- Reflection:
         
         - This code thoughtfully rearranges an array to move all zeros to the end while preserving the order of non-zero elements. 
         - It starts with a practical check for null or very short arrays, where no action is needed.
         - The method then uses a straightforward two-step process: first, it shifts all non-zero elements towards the beginning, maintaining their relative order. Next, it fills the remainder of the array with zeros. 
         */

        /*

        Question 3:
        Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

        Notice that the solution set must not contain duplicate triplets.

 

        Example 1:

        Input: nums = [-1,0,1,2,-1,-4]
        Output: [[-1,-1,2],[-1,0,1]]
        Explanation: 
        nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
        nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
        nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
        The distinct triplets are [-1,0,1] and [-1,-1,2].
        Notice that the order of the output and the order of the triplets does not matter.
        Example 2:

        Input: nums = [0,1,1]
        Output: []
        Explanation: The only possible triplet does not sum up to 0.
        Example 3:

        Input: nums = [0,0,0]
        Output: [[0,0,0]]
        Explanation: The only possible triplet sums up to 0.
 

        Constraints:

        3 <= nums.length <= 3000
        -105 <= nums[i] <= 105

        */

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            try
            {
                IList<IList<int>> result = new List<IList<int>>(); // Initialize list to store triplets
                Array.Sort(nums); // Sort the array

                // Iterate through the array, leave out the last two elements to form a triplet
                for (int i = 0; i < nums.Length - 2; i++)
                {
                    // Skip duplicates to avoid duplicate triplets
                    if (i > 0 && nums[i] == nums[i - 1])
                        continue;

                    int left = i + 1; // Pointer for the element after nums[i]
                    int right = nums.Length - 1; // Pointer for the last element

                    // Two-pointer approach to find the other two elements
                    while (left < right)
                    {
                        int sum = nums[i] + nums[left] + nums[right]; // Calculate sum of current triplet

                        // If sum is zero, we found a triplet
                        if (sum == 0)
                        {
                            // Add the triplet to the result list
                            result.Add(new List<int> { nums[i], nums[left], nums[right] });

                            // Skip duplicates for left and right pointers
                            while (left < right && nums[left] == nums[left + 1])
                                left++;
                            while (left < right && nums[right] == nums[right - 1])
                                right--;

                            // Move pointers to find other triplets
                            left++;
                            right--;
                        }
                        else if (sum < 0)
                        {
                            left++; // Move left pointer to increase sum
                        }
                        else
                        {
                            right--; // Move right pointer to decrease sum
                        }
                    }
                }

                return result; // Return list of unique triplets
            }
            catch (Exception)
            {
                throw; // Re-throw any exceptions
            }
        }

        /*Self- Reflection:
         
          - This code searches for groups of three numbers that add up to zero. It smartly arranges the numbers first to make searching easier.
          - It then sweeps through, avoiding repeats and using a two-pointer strategy to zero in on the perfect combos. When it finds a match, it secures the treasure. If it hits a snag, it's ready to sound the alarm.
         */

        /*

        Question 4:
        Given a binary array nums, return the maximum number of consecutive 1's in the array.

        Example 1:

        Input: nums = [1,1,0,1,1,1]
        Output: 3
        Explanation: The first two digits or the last three digits are consecutive 1s. The maximum number of consecutive 1s is 3.
        Example 2:

        Input: nums = [1,0,1,1,0,1]
        Output: 2
 
        Constraints:

        1 <= nums.length <= 105
        nums[i] is either 0 or 1.

        */

        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            try
            {
                int maxCount = 0; // Initialize maximum consecutive count
                int currentCount = 0; // Initialize current consecutive count

                // Iterate through the array
                foreach (int num in nums)
                {
                    if (num == 1)
                    {
                        currentCount++; // Increment current count if current element is 1
                    }
                    else
                    {
                        maxCount = Math.Max(maxCount, currentCount); // Update max count if necessary
                        currentCount = 0; // Reset current count for consecutive zeroes
                    }
                }

                // Check for the last sequence if it's the largest
                maxCount = Math.Max(maxCount, currentCount);

                return maxCount; // Return the maximum consecutive count
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*Self- Reflection:
         
         - This code finds for the longest run of 1s in a series of numbers. 
         - It counts each 1 it finds, keeping an eye out for breaks in the streak. When it encounters a different number, it takes a moment to see if the current streak sets a new record, then resets and starts the search anew. 
         - Once it's gone through all the numbers, it checks one last time to make sure it hasn't missed a longer streak at the end.
         - It's a diligent search to pinpoint the longest continuous stretch of 1s.
         
         */

        /*

        Question 5:
        You are tasked with writing a program that converts a binary number to its equivalent decimal representation without using bitwise operators or the `Math.Pow` function. You will implement a function called `BinaryToDecimal` which takes an integer representing a binary number as input and returns its decimal equivalent. 

        Requirements:
        1. Your program should prompt the user to input a binary number as an integer. 
        2. Implement the `BinaryToDecimal` function, which takes the binary number as input and returns its decimal equivalent. 
        3. Avoid using bitwise operators (`<<`, `>>`, `&`, `|`, `^`) and the `Math.Pow` function for any calculations. 
        4. Use only basic arithmetic operations such as addition, subtraction, multiplication, and division. 
        5. Ensure the program displays the input binary number and its corresponding decimal value.

        Example 1:
        Input: num = 101010
        Output: 42


        Constraints:

        1 <= num <= 10^9

        */

        public static int BinaryToDecimal(int binary)
        {
            try
            {
                int decimalVal = 0; // Initialize the decimal value to 0
                int baseVal = 1; // Initialize the base value to 1

                while (binary != 0)
                {
                    int Digit = binary % 10; // Extract the last digit of the binary number
                    binary /= 10; // Remove the last digit from the binary number

                    decimalVal += Digit * baseVal; // Update the decimal value
                    baseVal *= 2; // Update the base value (power of 2)
                }

                return decimalVal; // Return the decimal value after conversion
            }
            catch (Exception)
            {
                throw; // Re-throw any exceptions that occur during processing
            }
        }

        /*Self- Reflection:
        
          - This code is like a translator that turns binary language (a series of 0s and 1s) into decimal numbers, the kind we use every day. 
          - It starts with zero and works its way through the binary number, taking each digit from the end and seeing how much it contributes to the total in our familiar number system. 
          - For each step, it doubles the value it's adding on, just like moving up in powers of 2 because that's how binary numbers work. If it runs into trouble, it's prepared to signal for help, ensuring a smooth translation from the language of computers to the language of people.
         */

        /*

        Question:6
        Given an integer array nums, return the maximum difference between two successive elements in its sorted form. If the array contains less than two elements, return 0.
        You must write an algorithm that runs in linear time and uses linear extra space.

        Example 1:

        Input: nums = [3,6,9,1]
        Output: 3
        Explanation: The sorted form of the array is [1,3,6,9], either (3,6) or (6,9) has the maximum difference 3.
        Example 2:

        Input: nums = [10]
        Output: 0
        Explanation: The array contains less than 2 elements, therefore return 0.
 

        Constraints:

        1 <= nums.length <= 105
        0 <= nums[i] <= 109

        */

        public static int MaximumGap(int[] nums)
        {
            try
            {
                if (nums.Length < 2)
                    return 0;

                int maxGap = 0;

                // Find the minimum and maximum elements in the array
                int minNum = nums[0];
                int maxNum = nums[0];

                foreach (int num in nums)
                {
                    minNum = Math.Min(minNum, num);
                    maxNum = Math.Max(maxNum, num);
                }

                // Calculate the size of each bucket
                int bucketSize = Math.Max(1, (maxNum - minNum) / (nums.Length - 1));

                // Calculate the number of buckets
                int numBuckets = (maxNum - minNum) / bucketSize + 1;

                // Initialize buckets
                int[] minBucket = new int[numBuckets];
                int[] maxBucket = new int[numBuckets];
                bool[] hasValue = new bool[numBuckets];

                // Place elements into buckets
                foreach (int num in nums)
                {
                    int bucketIndex = (num - minNum) / bucketSize;
                    minBucket[bucketIndex] = hasValue[bucketIndex] ? Math.Min(minBucket[bucketIndex], num) : num;
                    maxBucket[bucketIndex] = hasValue[bucketIndex] ? Math.Max(maxBucket[bucketIndex], num) : num;
                    hasValue[bucketIndex] = true;
                }

                // Calculate the maximum gap
                int prevMax = minNum;
                for (int i = 0; i < numBuckets; i++)
                {
                    if (hasValue[i])
                    {
                        maxGap = Math.Max(maxGap, minBucket[i] - prevMax);
                        prevMax = maxBucket[i];
                    }
                }

                return maxGap;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*Self- Reflection
         
         - This code acts like a gap finder among numbers, much like spotting the widest spaces between dots on a line. 
         - It starts by checking if there are enough dots to form a space. Then, it identifies the smallest and largest dots, dividing them into groups or "buckets" to ensure every dot is sorted without overcrowding. Each dot is placed into a bucket based on its size, and the code calculates the biggest gap by comparing the highest number in one bucket to the lowest in the next. 
         - It's a smart way to find the largest distance between numbers, ensuring no gap is overlooked.
         */

        /*

        Question:7
        Given an integer array nums, return the largest perimeter of a triangle with a non-zero area, formed from three of these lengths. If it is impossible to form any triangle of a non-zero area, return 0.

        Example 1:

        Input: nums = [2,1,2]
        Output: 5
        Explanation: You can form a triangle with three side lengths: 1, 2, and 2.
        Example 2:

        Input: nums = [1,2,1,10]
        Output: 0
        Explanation: 
        You cannot use the side lengths 1, 1, and 2 to form a triangle.
        You cannot use the side lengths 1, 1, and 10 to form a triangle.
        You cannot use the side lengths 1, 2, and 10 to form a triangle.
        As we cannot use any three side lengths to form a triangle of non-zero area, we return 0.

        Constraints:

        3 <= nums.length <= 104
        1 <= nums[i] <= 106

        */

        public static int LargestPerimeter(int[] nums)
        {
            try
            {
                if (nums == null || nums.Length < 3)
                    return 0; // Return 0 if array contains less than 3 elements

                Array.Sort(nums); // Sort the array in ascending order

                // Start from the end of the sorted array to maximize perimeter
                for (int i = nums.Length - 1; i >= 2; i--)
                {
                    // Check if the current triplet forms a triangle with non-zero area
                    if (nums[i] < nums[i - 1] + nums[i - 2])
                        return nums[i] + nums[i - 1] + nums[i - 2]; // Return perimeter if triangle is possible
                }

                return 0; // Return 0 if no triangle with non-zero area is possible
            }
            catch (Exception)
            {
                throw; // Re-throw any exceptions
            }
        }
        /*Self- Reflection
         
         - This code is like a puzzle solver, looking to make the biggest triangle from a set of sticks.
         - It checks if there are enough sticks to start with, sorts them by length, and then tries to find three that can actually form a triangle, starting with the longest sticks.
         - If it finds a set that works, it adds up their lengths for the triangle's perimeter. If not, it decides a triangle can't be made. 
         - It's a straightforward strategy to find the longest possible triangle perimeter with the given sticks.
         */
         
        /*

        Question:8

        Given two strings s and part, perform the following operation on s until all occurrences of the substring part are removed:

        Find the leftmost occurrence of the substring part and remove it from s.
        Return s after removing all occurrences of part.

        A substring is a contiguous sequence of characters in a string.

 

        Example 1:

        Input: s = "daabcbaabcbc", part = "abc"
        Output: "dab"
        Explanation: The following operations are done:
        - s = "daabcbaabcbc", remove "abc" starting at index 2, so s = "dabaabcbc".
        - s = "dabaabcbc", remove "abc" starting at index 4, so s = "dababc".
        - s = "dababc", remove "abc" starting at index 3, so s = "dab".
        Now s has no occurrences of "abc".
        Example 2:

        Input: s = "axxxxyyyyb", part = "xy"
        Output: "ab"
        Explanation: The following operations are done:
        - s = "axxxxyyyyb", remove "xy" starting at index 4 so s = "axxxyyyb".
        - s = "axxxyyyb", remove "xy" starting at index 3 so s = "axxyyb".
        - s = "axxyyb", remove "xy" starting at index 2 so s = "axyb".
        - s = "axyb", remove "xy" starting at index 1 so s = "ab".
        Now s has no occurrences of "xy".

        Constraints:

        1 <= s.length <= 1000
        1 <= part.length <= 1000
        s​​​​​​ and part consists of lowercase English letters.

        */

        public static string RemoveOccurrences(string s, string part)
        {
            try
            {
                while (s.Contains(part))
                {
                    int index = s.IndexOf(part); // Find the index of the leftmost occurrence of part
                    s = s.Remove(index, part.Length); // Remove part from s starting at index
                }
                return s; // Return s after removing all occurrences of part
            }
            catch (Exception)
            {
                throw; // Re-throw any exceptions
            }


            /*Self- Reflection
             
             - This code functions as an editor, deleting particular undesired phrases from a text. 
             - It scans the text for the first occurrence of the term it wishes to eliminate, removes it, and then repeats the procedure. 
             - It repeats this until the phrase can no longer be discovered, guaranteeing that the final text is clear of that specific sequence of words. 
             - It's a meticulous and thorough method for cleaning up a text, leaving just the bits that are meant to keep.
         */
        }

        static string ConvertIListToArray(IList<int> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "" + input[i] + ""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }

        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }
    }
}

