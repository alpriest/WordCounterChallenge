namespace WordCounterChallenge
{
	public class WordCountManager
	{
		private readonly IWordCounter _wordCounter;
		private readonly IBufferManager _bufferManager;
		private readonly IChunkedStreamReader _reader;

		public WordCountManager(IWordCounter wordCounter, IBufferManager bufferManager, IChunkedStreamReader reader)
		{
			_wordCounter = wordCounter;
			_bufferManager = bufferManager;
			_reader = reader;
		}

		public void Execute()
		{
			_reader.Read(ProcessInputChunk);
			_wordCounter.CountWords(_bufferManager.Previous);
		}

		private void ProcessInputChunk(string buffer)
		{
			_bufferManager.SplitInputChunk(_wordCounter, buffer);
			_wordCounter.CountWords(_bufferManager.Current);
		}
	}
}