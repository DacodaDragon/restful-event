using Microsoft.Identity.Client;
using System.Linq.Expressions;

namespace restful_event.Utility
{
    public static class Reflection
    {
        public static Func<Ta, Tb> CreateConversionExpression<Ta, Tb>()
        {
            var param = Expression.Parameter(typeof(Ta));
            var conversion = Expression.ConvertChecked(param, typeof(Tb));
            return Expression.Lambda<Func<Ta, Tb>>(conversion, param).Compile();
        }
    }
}
