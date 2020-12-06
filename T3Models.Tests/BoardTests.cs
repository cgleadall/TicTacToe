using System;
using Xunit;
using T3Models.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace T3Models.Tests
{
    [ExcludeFromCodeCoverage]
    public class BoardTests
    {
        [Fact]
        public void Board_Initiazlies_in_empty_state()
        {
            var sut = new Board();

            Assert.True(sut.IsEmpty());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(10)]
        public void IsEmpty_Fails_for_position_off_the_board(int position){
            var sut = new Board();

            Action act = () => sut.IsEmptyAtPosition(position);

            Assert.Throws<IndexOutOfRangeException>(act);
        }

        [Fact]
        public void TakeTurn_throws_PositionNotEmptyException(){
            var sut = new Board();

            sut.TakeTurn(Player.O, 1);

            Action act = () => sut.TakeTurn(Player.X,1);

            Assert.Throws<PositionNotEmptyException>(act);    
        }

        [Fact]
        public void TakeTurn_throws_NotYourTurnException()
        {
            var sut = new Board();

            sut.TakeTurn(Player.X,1);

            Action act = () => sut.TakeTurn(Player.X,2);

            Assert.Throws<NotYourTurnException>(act);
        }

        [Fact]
        public void Board_has_correct_layout(){
            var sut = new Board();

            sut.TakeTurn(Player.X, 1);
            sut.TakeTurn(Player.O, 2);
            sut.TakeTurn(Player.X, 3);

            var layout = sut.CurrentBoard;

            Assert.Equal(Player.X, layout[0]);
            Assert.Equal(Player.O, layout[1]);
            Assert.Equal(Player.X, layout[2]);

        }

        [Fact]
        public void Full_board_is_not_Empty(){
            var sut = new Board();

            for(int i=1;i<=9;i++){
                sut.TakeTurn(((i%2==0)? Player.O : Player.X), i);
            }

            Assert.False(sut.IsEmpty());

        }
    }
}
