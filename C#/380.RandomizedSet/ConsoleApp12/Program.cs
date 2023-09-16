﻿using System;
using System.Runtime.CompilerServices;

namespace Arrays
{
    public class RandomizedSet
    {
        IList<int> nums;
        Dictionary<int, int> indices;
        Random random;
        public RandomizedSet()
        {
            nums = new List<int>();
            indices = new Dictionary<int, int>();
            random = new Random();
        }
        public bool Insert(int val)
        {
            if (indices.ContainsKey(val))
            {
                return false;
            }
            int index = nums.Count;
            nums.Add(val);
            indices.Add(val, index);
            return true;
        }
        public bool Remove(int val)
        {
            if (!indices.ContainsKey(val))
            {
                return false;
            }
            int index = indices[val];
            int last = nums[nums.Count - 1];
            nums[index] = last;
            indices[last] = index;
            nums.RemoveAt(nums.Count - 1);
            indices.Remove(val);
            return true;
        }
        public int GetRandom()
        {
            int randomIndex = random.Next(nums.Count);
            return nums[randomIndex];
        }
    }
}