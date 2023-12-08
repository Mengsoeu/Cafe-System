using CafesystemAPI.DBContext;

namespace CafesystemAPI.Logics
{
    public class DetailsLogic : IDetailsLogic
    {
        public IEnumerable<Detail> DetailsList()
        {
            using (var context = new CDbContext())
            {
                var DetailsList = context.Details.ToList();
                return DetailsList;
            }
        }
       
    }
}
