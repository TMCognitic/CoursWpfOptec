﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursWpfOptec.Models.Entities
{
    public class Voiture
    {
        public string Plaque { get; }

        public Voiture(string plaque)
        {
            Plaque = plaque;
        }
    }
}
