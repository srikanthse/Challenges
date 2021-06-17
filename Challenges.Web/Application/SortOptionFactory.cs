using System;
using Challenges.Application.Services;
using Challenges.Application.Utils;

namespace Challenges.Application
{
    public class SortOptionFactory : ISortOptionFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public SortOptionFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ISortOptionService GetSortingServiceInstance(SortOption sortOption)
        {
            switch (sortOption)
            {
                case SortOption.Low:
                    return GetSortOptionService<PriceAscendingSortOptionService>();
                case SortOption.High:
                    return GetSortOptionService<PriceDescendingSortOptionService>();
                case SortOption.Ascending:
                    return GetSortOptionService<NameAscendingSortOptionService>();
                case SortOption.Descending:
                    return GetSortOptionService<NameDescendingSortOptionService>();
                case SortOption.Recommended:
                    return GetSortOptionService<RecommendedSortOptionService>();
                default:
                    return GetSortOptionService<PriceAscendingSortOptionService>();
            }
        }

        private ISortOptionService GetSortOptionService<T>() => (ISortOptionService) _serviceProvider.GetService(typeof(T));
    }
}
