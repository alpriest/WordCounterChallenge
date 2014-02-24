namespace WordCounterChallenge
{
	public class BufferManager : IBufferManager
	{
		public string Previous { get; private set; }
		public string Current { get; private set; }

		public BufferManager()
		{
			Previous = string.Empty;
		}

		public void SplitInputChunk(IWordCounter wordCounter, string buffer)
		{
			var wholeBuffer = Previous + buffer;
			var lastPositionOfWordBoundary = wordCounter.LastPositionOfWordBoundary(wholeBuffer);

			Current = wholeBuffer.Substring(0, lastPositionOfWordBoundary);

			var fromLastWordBoundaryOnwards = wholeBuffer.Substring(lastPositionOfWordBoundary);
			Previous = fromLastWordBoundaryOnwards;
		}
	}
}