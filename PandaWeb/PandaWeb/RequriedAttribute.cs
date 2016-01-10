using System;

namespace PandaWeb
{
    // Class used by the built-in-user-system provided by Microsoft.
    internal class RequriedAttribute : Attribute
    {
        public bool AllowEmptyStrings { get; set; }
        public string ErrorMessage { get; set; }
    }
}
