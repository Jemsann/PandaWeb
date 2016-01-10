using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PandaWeb.Models
{
    // C# entity framework class model

    public class Protocol
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Added { get; set; }
        public string FileName { get; set; }
        public string Type { get; set; }
        public byte[] File { get; set; }
        
    }
}