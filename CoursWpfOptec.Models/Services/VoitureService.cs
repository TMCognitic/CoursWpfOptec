using CoursWpfOptec.Models.Commands.Voitures;
using CoursWpfOptec.Models.Entities;
using CoursWpfOptec.Models.Queries.Voitures;
using CoursWpfOptec.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursWpfOptec.Models.Services
{
    public class VoitureService : IVoitureRepository
    {
        private readonly IList<Voiture> _dataSource;

        public VoitureService(IList<Voiture> dataSource)
        {
            _dataSource = dataSource;
        }

        public async Task<IEnumerable<Voiture>> ExecuteAsync(GetAllCarsQuery query)
        {
            await Task.Delay(100);
            return _dataSource;
        }

        public async Task<Voiture> ExecuteAsync(AddCarCommand command)
        {
            await Task.Delay(100);
            Voiture voiture = new Voiture(command.Plaque);
            _dataSource.Add(voiture);
            return voiture;
        }
    }
}
