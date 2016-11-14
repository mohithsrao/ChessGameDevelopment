using ChessElements;
using ChessInfrastructure;
using System.Collections.ObjectModel;

namespace ChessGame.ViewModels
{
    public class MainWindowViewModel : ObservableClass
    {
        #region Properties

        private ObservableCollection<Tile> _board;
        public ObservableCollection<Tile> Board
        {
            get { return _board; }
            set
            {
                if (_board == value) return;
                _board = value;
                RaisePropertyChanged("Board");
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor for loading the ViewModel of the main Window of the application
        /// </summary>
        public MainWindowViewModel()
        {
            InitiateGUI();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Loades the UI with initial positions of all the pawns in the Chess Board
        /// </summary>
        private void InitiateGUI()
        {
            Board = ChessBoard.Instance.CreateChessBoard();
        }

        #endregion
    }
}
