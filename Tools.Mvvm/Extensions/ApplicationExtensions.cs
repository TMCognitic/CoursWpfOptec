using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tools.Mvvm.Extensions
{
    public static class ApplicationExtensions
    {
        public static IServiceProvider? GetServiceProvider(this Application a)
        {
            Type applicationType = a.GetType();

            PropertyInfo? propertyInfo = applicationType.GetProperty("ServiceProvider");

            if (propertyInfo is null) 
                return null;

            return propertyInfo.GetValue(a, null) as IServiceProvider;
        }
    }
}
