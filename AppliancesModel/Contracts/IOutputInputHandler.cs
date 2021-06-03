using AppliancesModel.Contracts;

namespace AppliancesModel
{
    public interface IOutputInputHandler
    {
        void RunMenu(IAppliancesDistribution distribution);
    }
}
