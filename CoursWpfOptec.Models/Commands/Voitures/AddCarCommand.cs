using CoursWpfOptec.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Cqs.Commands;

namespace CoursWpfOptec.Models.Commands.Voitures
{
    public class AddCarCommand : ICommandDefinition<Voiture>
    {
        public string Plaque { get; }

        public AddCarCommand(string plaque)
        {
            Plaque = plaque;
        }
    }
}
