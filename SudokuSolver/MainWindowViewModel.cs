using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Threading;
using Prism.Commands;
using Prism.Mvvm;
using SudokuSolverLibrary;

namespace SudokuSolver
{
    public class MainWindowViewModel : BindableBase
    {
        SudokuBoard _board = new SudokuBoard();
        private ObservableCollection<int> boardArray;
        private DispatcherTimer _timer = new DispatcherTimer();
        private Clock _clock = new Clock();

        public MainWindowViewModel()
        {
            boardArray = _board.BoardArray;
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += new EventHandler((object sender, EventArgs e) => Clock.Update());
            _timer.Start();
        }

        public ObservableCollection<int> BoardArray
        {
            get => boardArray;
        }

        public Clock Clock
        {
            get => _clock;
            set => _clock = value;
        }

        private ICommand levelEasyCommand;
        private ICommand levelMediumCommand;
        private ICommand levelHardCommand;
        private ICommand solveCommand;

        public ICommand LevelEasyCommand
        {
            get
            {
                return levelEasyCommand ?? (levelEasyCommand = new DelegateCommand(() => _board.NewBoard(1)));
            }
        }

        public ICommand LevelMediumCommand
        {
            get
            {
                return levelMediumCommand ?? (levelMediumCommand = new DelegateCommand(() => _board.NewBoard(2)));
            }
        }

        public ICommand LevelHardCommand
        {
            get
            {
                return levelHardCommand ?? (levelHardCommand = new DelegateCommand(() => _board.NewBoard(3)));
            }
        }

        public ICommand SolveCommand
        {
            get
            {
                return solveCommand ?? (solveCommand = new DelegateCommand(() =>
                {
                    try
                    {
                        _board.Solve();
                    }
                    catch (Exception)
                    {
                    }
                }));
            }
        }

    }
}
