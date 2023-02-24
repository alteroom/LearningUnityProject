using System;
using System.Collections.Generic;

namespace Modules.GameSystem
{
    internal class ServicesContext : IServicesContext
    {
        private readonly List<object> m_Services = new ();
        public void RegisterService(object service)
        {
            if (m_Services.Contains(service))
            {
                return;
            }
            m_Services.Add(service);
        }

        public void UnregisterService(object service)
        {
            if (m_Services.Contains(service))
            {
                m_Services.Remove(service);
            }
        }

        public T GetService<T>()
        {
            foreach (var serivce in m_Services)
            {
                if (serivce is T concreteService)
                {
                    return concreteService;
                }
            }
            return default(T);
        }

        public bool TryGetService<T>(out T service)
        {
            foreach (var s in m_Services)
            {
                if (s is T concreteService)
                {
                    service = concreteService;
                    return true;
                }
            }

            service = default(T);
            return false;
        }

        public T[] GetServices<T>()
        {
            var services = new List<T>();
            foreach (var service in m_Services)
            {
                if (service is T concreteService)
                {
                    services.Add(concreteService);
                }
            }
            return services.ToArray();
        }
    }
}