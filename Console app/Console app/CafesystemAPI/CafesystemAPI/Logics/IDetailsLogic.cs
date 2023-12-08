using CafesystemAPI.DBContext;

namespace CafesystemAPI.Logics
{
    public interface IDetailsLogic
    {
        IEnumerable<Detail> DetailsList();
    }
}
