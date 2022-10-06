using Data_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Interfaces
{
    public interface ICategoryService
    {
        int Update(Category UpdateCategory);
        Category ReadById (int id);
        List<Category> ReadAll();
        int Create(Category newcategory);
    }
}
