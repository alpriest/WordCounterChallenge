using System.IO;
using System.Text;
using NUnit.Framework;
using WordCounterChallenge;

namespace WordCounterTests
{
	[TestFixture]
	public class ChunkedStreamBlockReaderFixture
	{
		[Test]
		public void ReadsWholeStreamWhenOnlyOneLine()
		{
			// Arrange
			var inputStream = new MemoryStream(Encoding.UTF8.GetBytes("hello world"));
			var result = string.Empty;

			// Act
			new ChunkedStreamReader(inputStream).Read(x => result = x);

			// Assert
			Assert.That(result, Is.EqualTo("hello world"));
		}

		[Test]
		public void ReadsWholeStreamWhenLargeFile()
		{
			// Arrange
			var inputStream = new MemoryStream(Encoding.UTF8.GetBytes(Resource1.Large));
			var buffer = new StringBuilder();

			// Act
			new ChunkedStreamReader(inputStream).Read(x => buffer.Append(x));

			// Assert
			Assert.That(buffer.ToString(), Is.EqualTo(Resource1.Large));
		}
	}
}