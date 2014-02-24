namespace WordCounterChallenge
{
	public interface IBufferManager
	{
		string Previous { get; }
		string Current { get; }
		void SplitInputChunk(IWordCounter wordCounter, string buffer);
	}
}