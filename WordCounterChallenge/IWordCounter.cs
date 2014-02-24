using System.Collections.Generic;

namespace WordCounterChallenge
{
	public interface IWordCounter
	{
		void CountWords(string content);
		Dictionary<string, int> Counts { get; }
		int LastPositionOfWordBoundary(string content);
	}
}