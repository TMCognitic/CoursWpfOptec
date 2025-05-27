using CoursWpfOptec.Models.Entities;
using CoursWpfOptec.Models.Queries.Voitures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Cqs.Queries;

namespace CoursWpfOptec.Models.Repositories
{
    public interface IVoitureRepository :
        IQueryHandler<GetAllCarsQuery, IEnumerable<Voiture>>
    {
    }
}
