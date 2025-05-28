using CoursWpfOptec.Models.Commands.Voitures;
using CoursWpfOptec.Models.Entities;
using CoursWpfOptec.Models.Queries.Voitures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Cqs.Commands;
using Tools.Cqs.Queries;

namespace CoursWpfOptec.Models.Repositories
{
    public interface IVoitureRepository :
        IAsyncQueryHandler<GetAllCarsQuery, IEnumerable<Voiture>>,
        IAsyncCommandHandler<AddCarCommand, Voiture>
    {
    }
}
