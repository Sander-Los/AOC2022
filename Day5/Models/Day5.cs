namespace Day5.Models
{
    public class Day5 : IAOC2022
    {
        public List<Stack<string>> CrateStacks { get; set; }
        public string[] TestInput = File.ReadAllLines(@"C:\Users\conta\source\repos\AOC2022\Day5\testinput.txt");
        public string[] Input = File.ReadAllLines(@"C:\Users\conta\source\repos\AOC2022\Day5\input.txt");


        public void Part1()
        {
            Setup();
            foreach (var line in Input)
            {
                var (moves, from, to) = ParseMoveInput(line);
                MoveCrates(moves, from, to);
            }

            var output = "";
            foreach (var crateStack in CrateStacks)
            {
                output += crateStack.Pop();
            }

            Console.WriteLine($"Part 1: {output}");
        }

        public void Part2()
        {
            Setup();
            foreach (var line in Input)
            {
                var (moves, from, to) = ParseMoveInput(line);
                MoveCratesPart2(moves, from, to);
            }

            var output = "";
            foreach (var crateStack in CrateStacks)
            {
                output += crateStack.Pop();
            }

            Console.WriteLine($"Part 2: {output}");
        }

        private void MoveCratesPart2(int moves, int from, int to)
        {
            var bufferStack = new Stack<string>();

            for (int i = 0; i < moves; i++)
            {
                var el = CrateStacks.ElementAt(from - 1).Pop();
                bufferStack.Push(el);
            }

            while(bufferStack.Any())
            {
                CrateStacks.ElementAt(to - 1).Push(bufferStack.Pop());
            }
        }

        private void MoveCrates(int moves, int from, int to)
        {
            for (int i = 0; i < moves; i++)
            {
                CrateStacks.ElementAt(to - 1).Push(CrateStacks.ElementAt(from - 1).Pop());
            }
        }

        private (int moves, int from, int to) ParseMoveInput(string line)
        {
            var splitInstructions = line.Split(' ');
            var moves = int.Parse(splitInstructions.ElementAt(1));
            var from = int.Parse(splitInstructions.ElementAt(3));
            var to = int.Parse(splitInstructions.ElementAt(5));
            return (moves, from, to);
        }


        #region Setup
        public void Setup()
        {
            var stacks = new List<Stack<string>>();

            ////Example data
            //var stack1 = new Stack<string>();
            //stack1.Push("Z");
            //stack1.Push("N");

            //var stack2 = new Stack<string>();
            //stack2.Push("M");
            //stack2.Push("C");
            //stack2.Push("D");

            //var stack3 = new Stack<string>();
            //stack3.Push("P");

            //stacks.Add(stack1);
            //stacks.Add(stack2);
            //stacks.Add(stack3);
            //CrateStacks = stacks;

            // Full data
            var stack1 = new Stack<string>();
            stack1.Push("B");
            stack1.Push("P");
            stack1.Push("N");
            stack1.Push("Q");
            stack1.Push("H");
            stack1.Push("D");
            stack1.Push("R");
            stack1.Push("T");

            var stack2 = new Stack<string>();
            stack2.Push("W");
            stack2.Push("G");
            stack2.Push("B");
            stack2.Push("J");
            stack2.Push("T");
            stack2.Push("V");

            var stack3 = new Stack<string>();
            stack3.Push("N");
            stack3.Push("R");
            stack3.Push("H");
            stack3.Push("D");
            stack3.Push("S");
            stack3.Push("V");
            stack3.Push("M");
            stack3.Push("Q");

            var stack4 = new Stack<string>();
            stack4.Push("P");
            stack4.Push("Z");
            stack4.Push("N");
            stack4.Push("M");
            stack4.Push("C");

            var stack5 = new Stack<string>();
            stack5.Push("D");
            stack5.Push("Z");
            stack5.Push("B");

            var stack6 = new Stack<string>();
            stack6.Push("V");
            stack6.Push("C");
            stack6.Push("W");
            stack6.Push("Z");

            var stack7 = new Stack<string>();
            stack7.Push("G");
            stack7.Push("Z");
            stack7.Push("N");
            stack7.Push("C");
            stack7.Push("V");
            stack7.Push("Q");
            stack7.Push("L");
            stack7.Push("S");

            var stack8 = new Stack<string>();
            stack8.Push("L");
            stack8.Push("G");
            stack8.Push("J");
            stack8.Push("M");
            stack8.Push("D");
            stack8.Push("N");
            stack8.Push("V");

            var stack9 = new Stack<string>();
            stack9.Push("T");
            stack9.Push("P");
            stack9.Push("M");
            stack9.Push("F");
            stack9.Push("Z");
            stack9.Push("C");
            stack9.Push("G");

            CrateStacks = new List<Stack<string>> {
                stack1, stack2, stack3, stack4, stack5,
                stack6, stack7, stack8, stack9
            };
        }
        #endregion
    }
}
