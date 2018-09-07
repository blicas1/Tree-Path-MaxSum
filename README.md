# Tree-Path-MaxSum
Find the path that provides the maximum possible sum of the numbers per the given binary tree.

#Rules
1. Start from the top and move downwards to the last possible child.
2. Must proceed by changing between even and oddnumberssubsequently. Suppose that
you are on an even number, the next number you choose must be odd, or if you are on an
odd number the next number must be even. In other words, the final path would be
Odd -> even -> odd -> even …
3. Must reach to the bottom of the pyramid.
4. Assume that there is at least one valid path to the bottom.
5. If there are multiple paths, which result in the samemaximumamount, you can choose any
of them.

#Example

Sample Input:
1
8 9
1 5 9
4 5 2 3

Output:
Max sum: 16
Path: 1, 8, 5, 2 
