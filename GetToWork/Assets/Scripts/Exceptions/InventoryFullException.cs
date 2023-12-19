using System;

namespace Exceptions
{
    public class InventoryFullException : Exception
    {
        public InventoryFullException(string message) : base(message)
        {
        }
        
        public InventoryFullException(string message, System.Exception inner) : base(message, inner)
        {
        }
    }
}