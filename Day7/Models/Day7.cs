using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Day7.Models
{
    public class Day7 : IAOC2022
    {
        public AOCDirectory Root = new AOCDirectory
        {
            Name = "root",
            isRoot = true
        };

        public AOCDirectory CurrentDirectory;
        public string[] TestInput = File.ReadAllLines(@"C:\Users\conta\source\repos\AOC2022\Day7\testinput.txt");
        public string[] Input = File.ReadAllLines(@"C:\Users\conta\source\repos\AOC2022\Day7\input.txt");

        public Day7()
        {
            Setup();
        }

        public void Part1()
        {
            Root.GetFileSize();
            var resultAocDirectories = Root.GetDirectoriesWithMaxSize(100000);

            Console.WriteLine($"Part 1: {resultAocDirectories.Sum(x => x.TotalSize)}");
        }

        public void Part2()
        {

            Root.GetFileSize();
            
            var totalSize = 70000000;
            var currentFree = totalSize - Root.TotalSize;
            var difference = 30000000 - currentFree;
            var candidateDirectorySize = Root.GetDirectoriesWithMaxSize(int.MaxValue).Where(x => x.TotalSize > difference).OrderBy(x => x.TotalSize).First().TotalSize;
            Console.WriteLine($"Part 2: {candidateDirectorySize}");
        }

        public void Setup()
        {
            CurrentDirectory = Root;
            // create the file system
            foreach (var output in Input)
            {
                // command check
                if (output.StartsWith('$'))
                {
                    ParseCommand(output);
                    
                }
                // item is a directory or file in CurrentDirectory
                else
                {
                    ParseItem(output);
                }
                
            }

            
        }

        private void ParseItem(string output)
        {
            var item = output.Split(' ');
            // item is a directory, check if it already exists, else create it
            if (item[0] == "dir")
            {
                if (!DirectoryExists(item[1]))
                {
                    CurrentDirectory.Directories.Add(new AOCDirectory
                    {
                        Name = item[1],
                        Parent = CurrentDirectory
                    });
                }
            }
            // item is a file
            else
            {
                if (!FileExists(item[1]))
                {
                    CurrentDirectory.Files.Add(new AOCFile
                    {
                        Name = item[1],
                        Size = int.Parse(item[0])
                    });
                }
            }
        }

        private bool FileExists(string name)
        {
            return CurrentDirectory.Files.FirstOrDefault(x => x.Name.Equals(name)) != null;
        }

        private bool DirectoryExists(string name)
        {
            return CurrentDirectory.Directories.FirstOrDefault(x => x.Name == name) != null;
        }

        /// <summary>
        /// only parse the cd command. Everything after LS will be parsed separate based on CurrentFolder as it does not start with "$"
        /// </summary>
        /// <param name="output"></param>
        private void ParseCommand(string output)
        {
            var command = output.Split(' ');
            // check if directory already exists, if not, create it and set currentdirectory to it
            if (command[1] == "cd")
            {
                // move to root
                if (command[2] == "/")
                {
                    CurrentDirectory = Root;
                }

                //move one directory up
                else if (command[2] == "..")
                {
                    // if we are not in root go to parent
                    CurrentDirectory = CurrentDirectory != Root ? CurrentDirectory.Parent : Root;
                }

                // move to specified directory
                else
                {
                    var directoryExists = DirectoryExists(command[2]);
                    if (directoryExists)
                    {
                        CurrentDirectory = CurrentDirectory.Directories.FirstOrDefault(x => x.Name == command[2]);
                    }
                    else
                    {
                        CurrentDirectory.Directories.Add(new AOCDirectory
                        {
                            Parent = CurrentDirectory,
                            Name = command[2]
                        });
                        CurrentDirectory = CurrentDirectory.Directories.FirstOrDefault(x => x.Name == command[2]);
                    }
                }
            }
        }
    }
}
