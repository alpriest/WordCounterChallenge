using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WordCounterChallenge
{
	public class WordCounter : IWordCounter
	{
		private readonly Regex _splitOnWordBoundaries = new Regex(@"([\w-])+");

		public Dictionary<string, int> Counts { get; private set; }

		public WordCounter()
		{
			Counts = new Dictionary<string, int>();
		}

		public void CountWords(string content)
		{
			var matches = _splitOnWordBoundaries.Matches(content);

			foreach (Match m in matches)
			{
				RecordSingleMatchFound(m.Value);
			}
		}

		private void RecordSingleMatchFound(string m)
		{
			if (!Counts.ContainsKey(m))
			{
				Counts.Add(m, 0);
			}

			Counts[m]++;
		}

		public int LastPositionOfWordBoundary(string content)
		{
			var matches = _splitOnWordBoundaries.Matches(content);
			return matches[matches.Count - 1].Index;
		}
	}
}