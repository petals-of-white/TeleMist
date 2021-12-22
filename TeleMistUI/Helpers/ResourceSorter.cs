using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleMistUI.Helpers
{
    public static class ResourceSorter
    {
     
        internal static void SortResource<T>(string resourceName, IComparer<T> comparer)
        {
            List<T> resources = App.Current.TryFindResource(resourceName) as List<T>;

            var updatedResources = from resource in new List<T>(resources)
                                   select resource;
            var sortedResources = updatedResources.ToList();
            sortedResources.Sort(comparer);


            App.Current.Resources [resourceName] = sortedResources;

        }

        /// <summary>
        /// Сортує ресурс-список за навзою ресурсу, з елементами типу T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resourceName"></param>
        /// <param name="comparer"></param>
        internal static void SortResource<T>(string resourceName)
        {
            List<T> resources = App.Current.TryFindResource(resourceName) as List<T>;
            var updatedResources = from resource in new List<T>(resources)
                                   select resource;
            var sortedResources = updatedResources.ToList();
            sortedResources.Sort();
            App.Current.Resources [resourceName] = sortedResources;

        }
    }
}
