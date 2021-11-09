using BusinessLogic.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ICategoriesService
    {
        List<string> GetCategoriesByGenre(string url);
    }
}
