using System;
using System.IO;
using System.Linq;

namespace WordCounterChallenge
{
	public class ChunkedStreamReader : IChunkedStreamReader
	{
		private readonly Stream _stream;
		protected int BufferLength = 8192;

		public ChunkedStreamReader(Stream inputStream)
		{
			_stream = inputStream;
		}

		public void Read(Action<string> processLine)
		{
			var buffer = new char[BufferLength];

			using (var sr = new StreamReader(_stream))
			{
				var charactersRead = 0;
				while ((charactersRead = sr.ReadBlock(buffer, 0, BufferLength)) > 0)
				{
					var bufferAsString = new string(buffer.Take(charactersRead).ToArray());

					processLine(bufferAsString);
				}
			}
		}
	}
}