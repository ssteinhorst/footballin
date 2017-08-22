﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSync
{
    public class Players
    {
        public Dictionary<string, List<Player>> players { get; set; }
    }

    public class Player
    {
        public string sequence { get; set; }
        public string clubcode { get; set; }
        public string playerName { get; set; }
        public string statId { get; set; }
        public string yards { get; set; }

    }
}
