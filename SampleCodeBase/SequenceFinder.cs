using System;
using System.Collections.Generic;

namespace SampleCodeBase
{
    public class StringSequenceFinder
    {
        private readonly int _sequenceNumber;
        public readonly IList<string> SequenceFoundList;

        public StringSequenceFinder(int foundSequenceNumber)
        {
            _sequenceNumber = foundSequenceNumber;
            SequenceFoundList = new List<string>(foundSequenceNumber + 2);
        }

        public void TakeSequenceInput()
        {
            SequenceFoundList.Clear();

            for (var i = 1; i <= _sequenceNumber; i++)
            {
                Console.WriteLine($"Sequence Index [{i}]:");
                var input = Console.ReadLine();
                SequenceFoundList.Add(input);
            }

            Console.WriteLine("Sequence Collection Complete.");
        }

        public void TakeSequenceInputAsWholeString()
        {
            SequenceFoundList.Clear();
            Console.WriteLine("Enter whole sequence:");

            var input = Console.ReadLine();
            Console.WriteLine("Spliting Keys:");
            var splitingKeys = Console.ReadLine();

            var splittedStrings = input.Split(new[] { splitingKeys }, StringSplitOptions.None);

            for (var i = 1; i <= splittedStrings.Length; i++)
            {
                var currentSequence = splittedStrings[i - 1];
                Console.WriteLine($"Sequence Index [{i}]: {currentSequence}");
                SequenceFoundList.Add(currentSequence.Trim());
            }

            Console.WriteLine("Sequence Collection Complete.");
        }

        public string GetResultingSequence()
        {
            var indexList = new List<List<int>>(10);
            char[] currentChars = null;
            var finalApplyNumbers = new List<int>(10);

            for (var i = 1; i < SequenceFoundList.Count; i++)
            {
                var previous = SequenceFoundList[i - 1];
                var current = SequenceFoundList[i];

                var previousChars = previous.ToCharArray();
                currentChars = current.ToCharArray();

                indexList.Add(new List<int>(previousChars.Length));
                var currentWorkingList = indexList[i - 1];

                for (var j = 0; j < previousChars.Length; j++)
                {
                    var currentChar = (int) currentChars[j];
                    var previousChar = (int) previousChars[j];
                    var diff = currentChar - previousChar;
                    currentWorkingList.Add(diff);
                }
            }

            for (var i = indexList.Count - 1; i >= 1; i--)
            {
                var currentIndexDiffs = indexList[i];
                var previousIndexDiffs = indexList[i - 1];

                for (var j = 0; j < currentIndexDiffs.Count; j++)
                {
                    var current = currentIndexDiffs[j];
                    var prev = previousIndexDiffs[j];

                    // var diff = current - prev;

                    if (current == 0 &&
                        prev == 0)
                    {
                        finalApplyNumbers.Add(0);

                        continue;
                    }

                    finalApplyNumbers.Add(current);
                }

                break;
            }

            Console.WriteLine("Sequence Found:");
            Console.WriteLine("");
            var newChars = new List<char>(currentChars.Length);

            for (var i = 0; i < finalApplyNumbers.Count; i++)
            {
                var currentChar = (int) currentChars[i];
                var newSequence = currentChar + finalApplyNumbers[i];
                var newSeqChar = (char) newSequence;
                Console.Write($"Current Sequence:{currentChar}, Sequence Diff: {finalApplyNumbers[i]}, new char: {newSeqChar} | ");
                newChars.Add(newSeqChar);
            }

            Console.WriteLine("");
            var finalResult = string.Join("", newChars);
            Console.WriteLine($"Final : {finalResult}");

            return finalResult;
        }
    }
}