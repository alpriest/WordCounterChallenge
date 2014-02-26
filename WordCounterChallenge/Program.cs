using System;
using System.IO;
using System.Linq;

namespace WordCounterChallenge
{
	class Program
	{
		static void Main(string[] args)
		{
			if (!ValidArguments(args))
			{
				return;
			}

			var filename = args[0];
			var wordCounter = new WordCounter();

			using (var sr = File.Open(filename, FileMode.Open))
			{
				var manager = new WordCountManager(wordCounter, new BufferManager(), new ChunkedStreamReader(sr));
				manager.Execute();
			}

			foreach (var word in wordCounter.Counts.OrderByDescending(x => x.Value))
			{
				Console.WriteLine("{0} : {1}", word.Key, wordCounter.Counts[word.Key]);
			}

			Console.ReadLine();
		}

		private static bool ValidArguments(string[] args)
		{
			if (args.Length < 1)
			{
				Usage();
				return false;
			}

			if (!File.Exists(args[0]))
			{
				Console.WriteLine("File does not exist.");
				return false;
			}

			return true;
		}
		private static void Usage()
		{
			Console.WriteLine("Please specify the filename to parse as the first argument");
		}
	}
}
