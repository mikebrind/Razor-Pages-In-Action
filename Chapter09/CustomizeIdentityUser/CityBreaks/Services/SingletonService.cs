
using System;

namespace CityBreaks.Services
{
    public class SingletonService
    {
        private readonly LifetimeDemoService _dependency;
        public SingletonService(LifetimeDemoService dependency)
        {
            _dependency = dependency;
        }

        public Guid DependencyValue => _dependency.Value;

    }
}