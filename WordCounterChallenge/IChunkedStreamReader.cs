using System;

namespace WordCounterChallenge
{
	public interface IChunkedStreamReader
	{
		void Read(Action<string> processLine);
	}
}