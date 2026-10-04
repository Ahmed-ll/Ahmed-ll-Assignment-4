(1) Which approach was faster with 100 iterations?
	StringBuilder was much faster: 316.4 ns vs. 2,685.1 ns — 8.5x faster.

(2) Which approach was faster with 100,000 iterations?
	StringBuilder was much faster: 549,195.7 ns vs. 6,986,249,727.8 ns for StringConcatenation.

(3) Which approach allocated more memory?
	At 100,000 iterations: it allocated roughly 48.8 GB vs. only 1.9 MB for StringBuilder — about 24,800x more.

(4) What happened to string concatenation performance as the loop size increased?
	Performance degraded quadratically:
		- Each time the iteration count grew by 10x, the runtime grew by far more than 10x — the classic signature of O(n²) complexity.
		- StringBuilder, by contrast, grew almost linearly (O(n)).

(5) Why does repeated string concatenation create additional allocations?
	Because string in .NET is immutable. Every str = str + "x" operation:
		- Allocates a brand-new block of memory sized to hold the old string plus the new addition
		- Copies the entire old string's content into that new memory
		- Leaves the old string behind as garbage for the GC to eventually collect

(6) Why does StringBuilder usually perform better when text is repeatedly appended?
	- Because it maintains a mutable internal buffer (a character array).
	- Appends write directly into the buffer's free space without copying the existing content each time.
	- That's why both time and memory scale near-linearly instead of quadratically.

(7) Is StringBuilder always better than normal string operations? Explain.
	No, not always — this is clear from the earlier single-concatenation comparison, where plain StringConcatenation was actually faster for a very small number of operations.