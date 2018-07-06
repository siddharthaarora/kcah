//Given a binary tree, find the length of the longest path where each node 
//in the path has the same value. This path may or may not pass through the root.
//Note: The length of path between two nodes is represented by the number of edges between them.
// https://leetcode.com/problems/longest-univalue-path/description/

using System;

namespace Challenge
{    
    public static partial class LeetCode
    {
        public static int FindLongestUnivaluePath(OldTreeNode node)
        {
            int pathLength = 0;
            LongestUnivaluePath(ref pathLength, node);
            return pathLength;   
        }

        private static int LongestUnivaluePath(ref int pathLength, OldTreeNode node)
        {
            if (node == null)
            { return 0;}

            int left = LongestUnivaluePath(ref pathLength, node.Left);
            int right = LongestUnivaluePath(ref pathLength, node.Right);

            int leftArrowLength = 0, rightArrowLength = 0;
            if (node.Left != null && node.Left.Value == node.Value)
            { 
                leftArrowLength += left + 1;
            }

            if (node.Right != null && node.Right.Value == node.Value)
            {
                rightArrowLength += right + 1;
            }

            pathLength = Math.Max(pathLength, leftArrowLength + rightArrowLength);
            return Math.Max(leftArrowLength, rightArrowLength);
        }
    }
}