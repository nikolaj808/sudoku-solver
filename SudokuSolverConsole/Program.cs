using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SudokuSolverConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            SudokuBoard board = new SudokuBoard();
            board.PrintBoard();
            Console.WriteLine("\n");
            try
            {
                board.Solve();
            }
            catch (Exception)
            {
                Console.WriteLine("\n\n");
            }
            board.NewBoard(3);
            board.PrintBoard();
            Console.WriteLine("\n");
            try
            {
                board.Solve();
            }
            catch (Exception)
            {
                Console.WriteLine("\n\n");
            }

            Console.WriteLine();
        }
    }
}
