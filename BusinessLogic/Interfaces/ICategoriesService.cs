using MoviesLibrary.Models;
using System.Threading.Tasks;

namespace MoviesLibrary.BusinessLogic.Interfaces
{
    public interface ICategoriesService
    {
        Task<MovieResult> GetCategoriesByGenre(string url);
    }
}
