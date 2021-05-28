using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliancesModel
{
    public interface IAppliances
    {
        ICollection<Appliance> Stock { get; set; }

        int Id { get; set; }

        void InitializeModel();
    }
}
