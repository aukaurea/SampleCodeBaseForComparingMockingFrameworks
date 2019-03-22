using System;
using SampleCodeBase;

namespace SampleCodeBaseConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // SequenceFinder();

            // DuplicateFinder.TakeEntriesAndResultDuplicateItemsFoundInLine();

            TypesDisplay();
        }

        private static void TypesDisplay()
        {
            var systemTypeDataInfo = new SystemTypeDataInfo();
            var types = systemTypeDataInfo.GetSystemTypesList();
            var typesDisplay = systemTypeDataInfo.GetTypesString(types);
            Console.WriteLine(typesDisplay);
            Console.ReadLine();
        }

        private static void SequenceFinder()
        {
            while (true)
            {
                Console.WriteLine("Give sequence count:");
                var sequence = int.Parse(Console.ReadLine());
                var sequenceFounder = new StringSequenceFinder(sequence);
                sequenceFounder.TakeSequenceInputAsWholeString();
                var finalResult = sequenceFounder.GetResultingSequence();

                Console.WriteLine($"Final Result :{finalResult}");
                Console.ReadLine();
            }
        }
    }
}