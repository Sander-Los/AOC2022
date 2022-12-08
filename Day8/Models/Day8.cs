using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Day8.Models;

public class Day8 : IAOC2022
{
    public string[] TestInput = File.ReadAllLines(@"C:\Users\conta\source\repos\AOC2022\Day8\testinput.txt");
    public string[] Input = File.ReadAllLines(@"C:\Users\conta\source\repos\AOC2022\Day8\input.txt");
    public List<List<Tree>> TreeArray = new List<List<Tree>>();

    public Day8()
    {
        Setup();

    }

    public void Part1()
    {
        for (var row = 0; row < TreeArray.Count; row++)
        {
            for (var column = 0; column < TreeArray[row].Count; column++)
            {
                var currentTree = TreeArray[row][column];

                if (currentTree.Visible) continue;

                var height = currentTree.Height;
                if (VisibleFromLeft(height, row, column) || VisibleFromRight(height, row, column) || VisibleFromTop(height, row, column) ||
                    VisibleFromBottom(height, row, column))
                {
                    TreeArray[row][column] = currentTree.IsVisible();
                }
            }
        }

        var sum = 0;
        foreach (var row in TreeArray)
        {
            sum += row.Where(x => x.Visible).Count();
        }
        Console.WriteLine($"Part 1: {sum}");

    }

    public void Part2()
    {
        var highestScore = 0;
        for (var row = 0; row < TreeArray.Count; row++)
        {
            for (var column = 0; column < TreeArray[row].Count; column++)
            {
                var currenttree = TreeArray[row][column];
                var height = currenttree.Height;
                TreeArray[row][column] = currenttree
                    .WithLeftView(CalculateLeftView(height, row, column))
                    .WithRightView(CalculateRightView(height, row, column))
                    .WithTopView(CalculateTopView(height, row, column))
                    .WithBottomView(CalculateBottomView(height, row, column));
                var score = TreeArray[row][column].LeftView * TreeArray[row][column].RightView * TreeArray[row][column].BottomView * TreeArray[row][column].TopView;
                if (score > highestScore)
                {
                    highestScore = score;
                }
            }
        }

        Console.WriteLine($"Part 2: {highestScore}");

    }

    private int CalculateBottomView(int height, int row, int column)
    {
        var result = 0;

        while (row < TreeArray.Count - 1)
        {
            result++;
            if (TreeArray[row + 1][column].Height < height)
            {
                row++;
                continue;
            }
            break;

        }
        return result;
    }

    private int CalculateTopView(int height, int row, int column)
    {
        var result = 0;

        while (row > 0)
        {
            result++;
            if (TreeArray[row - 1][column].Height < height)
            {
                
                row--;
                continue;
            }
            break;

        }
        return result;
    }

    private int CalculateRightView(int height, int row, int column)
    {
        var result = 0;

        while (column < TreeArray[row].Count - 1)
        {
            result++;
            if (TreeArray[row][column + 1].Height < height)
            {
                column++;
                continue;
            }
            break;

        }
        return result;
    }

    private int CalculateLeftView(int height, int row, int column)
    {
        var result = 0;

        while (column > 0)
        {
            result++;
            if (TreeArray[row][column - 1].Height < height)
            {
                
                column--;
                continue;
            }
            break;

        }
        return result;
    }


    private bool VisibleFromLeft(int height, int row, int column)
    {
        var result = true;

        while (column > 0)
        {
            if (TreeArray[row][column - 1].Height < height)
            {
                column--;
                continue;
            }

            result = false;
            break;

        }
        return result;
    }

    private bool VisibleFromRight(int height, int row, int column)
    {
        var result = true;
        while (column < TreeArray[row].Count - 1)
        {
            if (TreeArray[row][column + 1].Height < height)
            {
                column++;
                continue;
            }

            result = false;
            break;
        }
        return result;
    }

    private bool VisibleFromTop(int height, int row, int column)
    {
        var result = true;

        while (row > 0)
        {
            if (TreeArray[row - 1][column].Height < height)
            {
                row--;
                continue;

            }
            result = false;
            break;
        }
        return result;
    }

    private bool VisibleFromBottom(int height, int row, int column)
    {
        var result = true;
        while (row < TreeArray.Count - 1)
        {
            if (TreeArray[row + 1][column].Height < height)
            {
                row++;
                continue;
            }
            result = false;
            break;
        }
        return result;
    }

    public void Setup()
    {
        // create 2d array and initalize the edges as visible

        for (int row = 0; row < Input.Length; row++)
        {
            var treeRow = new List<Tree>();

            for (var column = 0; column < Input[row].Length; column++)
            {
                // first and last row
                if (row == 0 || row == Input.Length - 1)
                {
                    treeRow.Add(
                        new Tree(int.Parse(Input[row][column].ToString()))
                            .IsAnEdge()
                            .IsVisible());
                }
                else
                {
                    // first and last tree in a line
                    if (column == 0 || column == Input[row].Length - 1)
                    {
                        treeRow.Add(
                            new Tree(int.Parse(Input[row][column].ToString()))
                                .IsAnEdge()
                                .IsVisible());
                    }
                    else
                    {
                        treeRow.Add(new Tree(int.Parse(Input[row][column].ToString())));
                    }
                }

            }
            TreeArray.Add(treeRow);
        }
        // create last row

        // --- TEST INPUT ---
        //for (int row = 0; row < TestInput.Length; row++)
        //{
        //    var treeRow = new List<Tree>();

        //    for (var column = 0; column < TestInput[row].Length; column++)
        //    {
        //        // first and last row
        //        if (row == 0 || row == TestInput.Length - 1)
        //        {
        //            treeRow.Add(
        //                new Tree(int.Parse(TestInput[row][column].ToString()))
        //                    .IsAnEdge()
        //                    .IsVisible());
        //        }
        //        else
        //        {
        //            // first and last tree in a line
        //            if (column == 0 || column == TestInput[row].Length - 1)
        //            {
        //                treeRow.Add(
        //                    new Tree(int.Parse(TestInput[row][column].ToString()))
        //                        .IsAnEdge()
        //                        .IsVisible());
        //            }
        //            else
        //            {
        //                treeRow.Add(new Tree(int.Parse(TestInput[row][column].ToString())));
        //            }
        //        }

        //    }
        //    TreeArray.Add(treeRow);
        //}


    }
}
