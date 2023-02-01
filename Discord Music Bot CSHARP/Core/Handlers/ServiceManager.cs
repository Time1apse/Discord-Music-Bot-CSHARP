﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord_Music_Bot_CSHARP.Core.Handlers
{
    public class ServiceManager
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static void SetProvider(ServiceCollection collection)
            => ServiceProvider = collection.BuildServiceProvider(); 

        public static T GetService<T>() where T: new() 
            => ServiceProvider.GetRequiredService<T>();
    }
}
