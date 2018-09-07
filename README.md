# Tree-Path-MaxSum
Find the path that provides the maximum possible sum of the numbers per the given binary tree.

# Rules

1. Start from the top and move downwards to the last possible child.
2. Must proceed by changing between even and oddnumberssubsequently. Suppose that
you are on an even number, the next number you choose must be odd, or if you are on an
odd number the next number must be even. In other words, the final path would be
Odd -> even -> odd -> even …
3. Must reach to the bottom of the pyramid.
4. Assume that there is at least one valid path to the bottom.
5. If there are multiple paths, which result in the samemaximumamount, you can choose any
of them.

# Example

Sample Input:  
1  
8 9  
1 5 9  
4 5 2 3  

Output:  
Max sum: 16  
Path: 1, 8, 5, 2 

# Question
Per the above rules, what is the maximum sum of the below input? Please take this pyramid as an
input (as a file,or constants directly inside the code) for your implementation and solve it.

215  
192 124  
117 269 442  
218 836 347 235  
320 805 522 417 345  
229 601 728 835 133 124  
248 202 277 433 207 263 257  
359 464 504 528 516 716 871 182  
461 441 426 656 863 560 380 171 923  
381 348 573 533 448 632 387 176 975 449  
223 711 445 645 245 543 931 532 937 541 444  
330 131 333 928 376 733 017 778 839 168 197 197  
131 171 522 137 217 224 291 413 528 520 227 229 928  
223 626 034 683 839 052 627 310 713 999 629 817 410 121  
924 622 911 233 325 139 721 218 253 223 107 233 230 124 233  

Note that, each node has only two children here (except the bottom row). As an example, you can
walk from 215 to 124 or 192, and then from 124 to 269, since 442 is even just like its parent. From
124 you cannot go to 117 because it is not a direct child of 124.

# Answer
Max sum 8186
Path: 215, 192, 269, 836, 805, 728, 433, 528, 863, 632, 931, 778, 413, 310, 253
