using System;
using System.Diagnostics;

namespace T3Models.Exceptions {
    public class PositionNotEmptyException : Exception {
        public PositionNotEmptyException(string message)
        :base(message)
        {
            
        }
    }
}