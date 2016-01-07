using System;

namespace PandaWeb
{
    internal class RequriedAttribute : Attribute
    {
        public bool AllowEmptyStrings { get; set; }
        public string ErrorMessage { get; set; }
    }
}
