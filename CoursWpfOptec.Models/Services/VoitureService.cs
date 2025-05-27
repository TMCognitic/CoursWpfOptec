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

        public IEnumerable<Voiture> Execute(GetAllCarsQuery query)
        {
            return _dataSource;
        }
    }
}
