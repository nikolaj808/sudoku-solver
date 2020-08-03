using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace SudokuSolverLibrary
{
    public class SudokuBoard
    {
        #region Variables
        private int[,] board = new int[9,9]
        {
            {0, 0, 0, 0, 0, 0, 0, 0, 0 },
            {0, 0, 0, 0, 0, 0, 0, 0, 0 },
            {0, 0, 0, 0, 0, 0, 0, 0, 0 },
            {0, 0, 0, 0, 0, 0, 0, 0, 0 },
            {0, 0, 0, 0, 0, 0, 0, 0, 0 },
            {0, 0, 0, 0, 0, 0, 0, 0, 0 },
            {0, 0, 0, 0, 0, 0, 0, 0, 0 },
            {0, 0, 0, 0, 0, 0, 0, 0, 0 },
            {0, 0, 0, 0, 0, 0, 0, 0, 0 }
        };

        private ObservableCollection<int> boardArray = new ObservableCollection<int>();

        #endregion

        #region Properties

        public int[,] Board
        {
            get => board;
            private set => board = value;
        }

        public ObservableCollection<int> BoardArray
        {
            get => boardArray;
            private set => boardArray = value;
        }

        #endregion

        #region SudokuBoard

        public SudokuBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    boardArray.Add(board[i, j]);
                }
            }
        }

        #endregion

        #region PrintBoard

        public void PrintBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write($"{board[i, j]}  ");
                }
                Console.WriteLine();
            }
        }

        #endregion

        #region Square

        private int Square((int, int) ij)
        {
            if (ij.Item1 >= 0 && ij.Item1 <= 2)
            {
                if (ij.Item2 >= 0 && ij.Item2 <= 2)
                {
                    return 1;
                }
                else if (ij.Item2 >= 3 && ij.Item2 <= 5)
                {
                    return 2;
                }
                else if (ij.Item2 >= 6 && ij.Item2 <= 8)
                {
                    return 3;
                }
            }
            else if (ij.Item1 >= 3 && ij.Item1 <= 5)
            {
                if (ij.Item2 >= 0 && ij.Item2 <= 2)
                {
                    return 4;
                }
                else if (ij.Item2 >= 3 && ij.Item2 <= 5)
                {
                    return 5;
                }
                else if (ij.Item2 >= 6 && ij.Item2 <= 8)
                {
                    return 6;
                }
            }
            else if (ij.Item1 >= 6 && ij.Item1 <= 8)
            {
                if (ij.Item2 >= 0 && ij.Item2 <= 2)
                {
                    return 7;
                }
                else if (ij.Item2 >= 3 && ij.Item2 <= 5)
                {
                    return 8;
                }
                else if (ij.Item2 >= 6 && ij.Item2 <= 8)
                {
                    return 9;
                }
            }
            return 0;
        }

        #endregion

        #region GetSquare

        private int[,] GetSquare((int, int) ij)
        {
            int[,] square;
            switch (Square(ij))
            {
                // First row of squares
                case 1:
                    {
                        square = new int[,]
                        {
                        {board[0, 0], board[0, 1], board[0, 2]},
                        {board[1, 0], board[1, 1], board[1, 2]},
                        {board[2, 0], board[2, 1], board[2, 2]}
                        };
                        break;
                    }
                case 2:
                    {
                        square = new int[,]
                        {
                        {board[0, 3], board[0, 4], board[0, 5]},
                        {board[1, 3], board[1, 4], board[1, 5]},
                        {board[2, 3], board[2, 4], board[2, 5]}
                        };
                        break;
                    }
                case 3:
                    {
                        square = new int[,]
                        {
                        {board[0, 6], board[0, 7], board[0, 8]},
                        {board[1, 6], board[1, 7], board[1, 8]},
                        {board[2, 6], board[2, 7], board[2, 8]}
                        };
                        break;
                    }

                // Second row of squares
                case 4:
                    {
                        square = new int[,]
                        {
                        {board[3, 0], board[3, 1], board[3, 2]},
                        {board[4, 0], board[4, 1], board[4, 2]},
                        {board[5, 0], board[5, 1], board[5, 2]}
                        };
                        break;
                    }
                case 5:
                    {
                        square = new int[,]
                        {
                        {board[3, 3], board[3, 4], board[3, 5]},
                        {board[4, 3], board[4, 4], board[4, 5]},
                        {board[5, 3], board[5, 4], board[5, 5]}
                        };
                        break;
                    }
                case 6:
                    {
                        square = new int[,]
                        {
                        {board[3, 6], board[3, 7], board[3, 8]},
                        {board[4, 6], board[4, 7], board[4, 8]},
                        {board[5, 6], board[5, 7], board[5, 8]}
                        };
                        break;
                    }

                // Third row of squares
                case 7:
                    {
                        square = new int[,]
                        {
                        {board[6, 0], board[6, 1], board[6, 2]},
                        {board[7, 0], board[7, 1], board[7, 2]},
                        {board[8, 0], board[8, 1], board[8, 2]}
                        };
                        break;
                    }
                case 8:
                    {
                        square = new int[,]
                        {
                        {board[6, 3], board[6, 4], board[6, 5]},
                        {board[7, 3], board[7, 4], board[7, 5]},
                        {board[8, 3], board[8, 4], board[8, 5]}
                        };
                        break;
                    }
                case 9:
                    {
                        square = new int[,]
                        {
                        {board[6, 6], board[6, 7], board[6, 8]},
                        {board[7, 6], board[7, 7], board[7, 8]},
                        {board[8, 6], board[8, 7], board[8, 8]}
                        };
                        break;
                    }

                default:
                    {
                        square = new int[,] { };
                        break;
                    }
            }

            return square;
        }

        #endregion

        #region GetSquareValues

        private int[] GetSquareValues((int, int) ij)
        {
            int[,] square = GetSquare(ij);
            int[] squareValues = new int[9];
            int counter = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    squareValues[counter] = square[i, j];
                    counter++;
                }
            }

            return squareValues;
        }

        #endregion

        #region GetHorizontal

        private int[] GetHorizontal((int, int) ij)
        {
            int[] horizontal = new int[9];

            for (int j = 0; j < 9; j++)
            {
                horizontal[j] = board[ij.Item1, j];
            }

            return horizontal;
        }

        #endregion

        #region GetVertical

        private int[] GetVertical((int, int) ij)
        {
            int[] vertical = new int[9];

            for (int i = 0; i < 9; i++)
            {
                vertical[i] = board[i, ij.Item2];
            }

            return vertical;
        }

        #endregion

        #region Possible

        public bool Possible((int, int) ij, int num)
        {
            Dictionary<int, bool> taken = new Dictionary<int, bool>
            {
                {1,false}, {2,false}, {3,false}, {4,false}, {5,false}, {6,false}, {7,false}, {8,false}, {9,false}
            };

            foreach (var squareValue in GetSquareValues(ij))
            {
                if (squareValue != 0)
                {
                    if (!taken[squareValue])
                    {
                        taken[squareValue] = true;
                    }
                }
            }

            foreach (var horizontalValue in GetHorizontal(ij))
            {
                if (horizontalValue != 0)
                {
                    if (!taken[horizontalValue])
                    {
                        taken[horizontalValue] = true;
                    }
                }
            }

            foreach (var verticalValue in GetVertical(ij))
            {
                if (verticalValue != 0)
                {
                    if (!taken[verticalValue])
                    {
                        taken[verticalValue] = true;
                    }
                }
            }

            return !taken[num];
        }

        #endregion

        #region Solve

        public void Solve()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i, j] == 0)
                    {
                        for (int k = 1; k < 10; k++)
                        {
                            if (Possible((i, j), k))
                            {
                                board[i, j] = k;
                                Solve();
                                board[i, j] = 0;
                            }
                        }
                        return;
                    }
                }
            }
            boardArray.Clear();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    boardArray.Add(board[i, j]);
                }
            }
            throw new Exception();
        }

        #endregion

        #region NewBoard

        public void NewBoard(int diff = 1)
        {
            string difficulty;
            string boardJson;
            string url;

            switch (diff)
            {
                case 1:
                    difficulty = "easy";
                    break;

                case 2:
                    difficulty = "medium";
                    break;

                case 3:
                    difficulty = "hard";
                    break;

                default:
                    difficulty = "easy";
                    break;
            }

            url = $"https://sugoku.herokuapp.com/board?difficulty={difficulty}";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            
            Stream resStream = response.GetResponseStream();

            using (var reader = new StreamReader(resStream))
            {
                boardJson = reader.ReadToEnd();
            }

            Dictionary<string, int[,]> newBoard = JsonConvert.DeserializeObject<Dictionary<string, int[,]>>(boardJson);

            foreach (var value in newBoard.Values)
            {
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        board[i, j] = value[i, j];
                    }
                }
            }

            boardArray.Clear();
            foreach (var value in newBoard.Values)
            {
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        boardArray.Add(value[i, j]);
                    }
                }
            }
        }

        #endregion
    }
}
