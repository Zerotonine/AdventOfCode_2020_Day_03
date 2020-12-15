using System;
using System.Collections.Generic;
using System.IO;

/*
 * Solution for the 3rd advent of code challenge 2020
 * Find out more about advent of code @ https://adventofcode.com/
 */
namespace AdventOfCode_2020_Day_03
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputList = new List<string>(File.ReadAllLines("input.txt"));

            //example from AoC - Number of Trees should be 7 for Puzzle One and 336 for Puzzle Two
            //List<string> inputList = new List<string>(File.ReadAllLines("example.txt"));

            Console.WriteLine("Solution One: " + PuzzleOne(inputList));
            Console.WriteLine("Solution Two: " + PuzzleTwo(inputList));
            
            Console.ReadKey(true);
        }

        static int PuzzleOne(in List<string> input)
        {
            const int down = 1;
            const int right = 3;
            int index = 0;
            int trees = 0;

            for (int i = 0; i < input.Count; i += down)
            {
                if (input[i][index] == '#')
                    trees++;
                for (int j = 0; j < right; j++)
                {
                    index++;
                    if (index >= input[0].Length)
                        index = 0;
                }                
            }
            return trees;
        }

        static uint PuzzleTwo(in List<string> input)
        {
            List<(int right, int down)> tuples = new List<(int, int)> 
            { 
                (1, 1),
                (3, 1),
                (5, 1),
                (7, 1),
                (1, 2)
            };
            int index = 0;
            int treeCounter;
            List<int> trees = new List<int>();
            uint solution = 1;

            for(int i = 0; i < tuples.Count; i++)
            {
                treeCounter = 0;
                index = 0;
                for (int j = 0; j < input.Count; j+= tuples[i].down)
                {
                    if (input[j][index] == '#')
                        treeCounter++;
                    for(int k = 0; k < tuples[i].right; k++)
                    {
                        index++;
                        if (index >= input[0].Length)
                            index = 0;
                    }
                }
                trees.Add(treeCounter);
            }
            
            trees.ForEach(a => solution *= (uint)a);
            return solution;
        }
    }
}
