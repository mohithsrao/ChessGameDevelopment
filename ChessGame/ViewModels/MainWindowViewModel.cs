using ChessElements;
using ChessElements.Extensions;
using ChessInfrastructure;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

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
            Board = ChessBoard.Instance.Board;
        }

        #endregion

        #region Public Methods
        
        /// <summary>
        /// Method hit on select of any piece
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ChessBoard.Instance.Clearhighlights();
                var tile = (sender as FrameworkElement).DataContext as Tile;
                if (tile == null || tile.IsEmptyTile) return;
                var moveList = tile.Piece.GetMoveList(tile);
                moveList.AssignBackground();
            }
            catch (Exception)
            {
                //TODO: Write Exception Handeling to let user know Some crach has happened
                throw;
            }
        }

        #endregion
    }
}
