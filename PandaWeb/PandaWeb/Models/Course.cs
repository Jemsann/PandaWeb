﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PandaWeb.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ForeignKey { get; set; }
    }
}