using System;
using System.ComponentModel.DataAnnotations;
using T3Models.Exceptions;

namespace T3Models
{
    public class Board
    {
        private Player[] _layout;

        private Player PreviousPlayer;

        public Board()
        {
            _layout = new Player[9];
            for (int i = 0; i < _layout.Length; i++)
            {
                _layout[i] = Player.None;
            }
            PreviousPlayer = Player.None;
        }
        
        public Player[] CurrentBoard{
            get{
                return _layout;
            }
        }

        public void TakeTurn(Player player, int position)
        {
            ThrowIfNotYourTurn(player);

            ThrowIfPositionNotEmpty(position);

            _layout[position - 1] = player;

            PreviousPlayer = player;

        }

        private void ThrowIfPositionNotEmpty(int position)
        {
            if (!IsEmptyAtPosition(position)) throw new PositionNotEmptyException($"Position({position}) is not empty.");
        }

        private void ThrowIfNotYourTurn(Player player)
        {
            if (PreviousPlayer == player) throw new NotYourTurnException($"It is not Player {player}'s turn");
        }

        public bool IsEmpty(){
            for(int i=1;i< _layout.Length+1; i++){
                if( !IsEmptyAtPosition(i)) return false;
            }
            return true;
        }


        public bool IsEmptyAtPosition([Range(1, 9, 
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]int position){
            return _layout[position-1] == Player.None;
        }
    }
}
