using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace GenericAttributes.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    [DebuggerDisplay("GenericServiceFilter: Order={Order}")]

    public class GenericServiceFilterAttribute<TFilter> : Attribute, IFilterFactory, IOrderedFilter
    {/// <inheritdoc />
        public int Order { get; set; }

        /// <inheritdoc />
        public bool IsReusable { get; set; }

        /// <inheritdoc />
        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            var filter = (IFilterMetadata)serviceProvider.GetRequiredService(typeof(TFilter));
            if (filter is IFilterFactory filterFactory)
            {
                // Unwrap filter factories
                filter = filterFactory.CreateInstance(serviceProvider);
            }

            return filter;
        }
    }
}
