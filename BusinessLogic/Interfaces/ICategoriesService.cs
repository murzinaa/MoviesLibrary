using MoviesLibrary.Models;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ICategoriesService
    {
        Task<MovieResult> GetCategoriesByGenre(string url);
    }
}
