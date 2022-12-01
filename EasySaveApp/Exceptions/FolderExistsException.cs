using System;

namespace EasySaveApp.Exceptions
{
    // We create an exception class who is derivated from Exception.
    // It's a custom exception, so we can put it in our MainViewModel wherever we want. 
    // If there is a problem with a folder creation or existant, the error will be appear.
    class FolderExistsException : Exception
    {
        public FolderExistsException()
        {
        }

        public FolderExistsException(string message) : base(string.Format("Invalid folder : {0}", message))
        {
        }
    }
}
