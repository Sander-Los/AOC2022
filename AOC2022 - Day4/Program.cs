using static System.Console;

public class Program

{
    static void Main(string[] args)
    {
        Day4.Part1();
        Day4.Part2();
    }
}

public static class Day4
{
    public static string[] SectionAssignments =
        File.ReadAllLines(@"C:\Users\conta\source\repos\AdventOfCode\AOC2022 - Day4\input.txt");
    
    public static void Part1()
    {
        var sum = 0;

        foreach (var sectionAssignment in SectionAssignments)
        {
            var (first, second) = GetValueSequenceFromSectionAssignment(sectionAssignment);

            var overlapLength = first.Where(x => second.Contains(x)).Count();
            var isTotalOverlap = overlapLength == first.Count() || overlapLength == second.Count();
            
            if (isTotalOverlap) 
                sum++;
            
        }
        
        WriteLine($"Part 1 answer: {sum}");
    }
    public static void Part2()
    {
        var sum = 0;

        foreach (var sectionAssignment in SectionAssignments)
        {
            var (first, second) = GetValueSequenceFromSectionAssignment(sectionAssignment);

            var overlapLength = first.Where(x => second.Contains(x)).Count();
            var isOverlap = overlapLength > 0;

            if (isOverlap)
                sum++;
        }
        
        WriteLine($"Part 2 answer: {sum}");
    }

    private static  (IEnumerable<int>, IEnumerable<int>) GetValueSequenceFromSectionAssignment(string sectionAssignment)
    {
        var firstPair = sectionAssignment.Split(',')[0].Split('-');
        var secondPair = sectionAssignment.Split(',')[1].Split('-');

        var firstElementsCount = int.Parse(firstPair[1]) - int.Parse(firstPair[0]) + 1;
        var secondElementsCount = int.Parse(secondPair[1]) - int.Parse(secondPair[0]) + 1;

        var first = Enumerable.Range(int.Parse(firstPair[0]), firstElementsCount);
        var second = Enumerable.Range(int.Parse(secondPair[0]), secondElementsCount);
        
        return (first, second);
    }

}