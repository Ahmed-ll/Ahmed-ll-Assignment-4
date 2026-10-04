# LeetCode Account:   https://leetcode.com/u/Olivar

________________________________________________________________________________

# Part 26 — Valid Anagram

## https://leetcode.com/problems/valid-anagram


(1) How it determines anagrams:
Uses one array of size 123 (indexed by ASCII code).
Increments the count for each char in str1, decrements for each char in str2.
If both strings match in characters and frequency, every slot ends up at 0.

(2) Different lengths:
Returns false, no counting needed — different lengths can never be anagrams.

(3) Comparing frequencies:
One shared array instead of two: increment with str1, decrement with str2.
Matching counts cancel out to 0.

(4) Time Complexity:
O(n) — two simple passes over the strings

(5) Space Complexity:
O(1) — array size is fixed (123) regardless of input length.

________________________________________________________________________________

# Part 27 — Greatest Common Divisor of Strings

## https://leetcode.com/problems/greatest-common-divisor-of-strings


1) What it means for one string to divide another:
String A divides string B if B equals A repeated some whole number of times.

2) How repeated patterns are detected:
By checking str1 + str2 == str2 + str1. If true, both strings are built from the same repeating base unit.

3) Why some pairs have no common divisor:
If the strings aren't built from the same base pattern, no string can repeat to form both.

4) How the greatest valid pattern is found:
Once a common divisor exists, its max length = GCD(len(str1), len(str2)).
The first GCD characters of either string is the answer.

5) Time Complexity: concatenation and comparison take O(n+m).

6) Space Complexity: O(n + m) — due to creating the concatenated strings.