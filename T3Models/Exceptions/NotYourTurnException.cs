using System;
using System.Diagnostics;

namespace T3Models.Exceptions{
    public class NotYourTurnException : Exception {

        public NotYourTurnException(string message) 
        : base(message){
            
        }
    }
}