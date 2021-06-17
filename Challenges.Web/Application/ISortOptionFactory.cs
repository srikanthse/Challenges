using Challenges.Application.Services;
using Challenges.Application.Utils;

namespace Challenges.Application
{
    public interface ISortOptionFactory
    {
        ISortOptionService GetSortingServiceInstance(SortOption sortOption);
    }
}
