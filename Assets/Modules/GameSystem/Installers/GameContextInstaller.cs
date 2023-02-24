using System.Collections.Generic;
using Modules.GameSystem.Context;
using Modules.GameSystem.GameElements;
using UnityEngine;

namespace Modules.GameSystem.Installers
{
    public class GameContextInstaller
    {
        public void RegisterServices(List<MonoBehaviour> services, IGameContext context)
        {
            foreach (var service in services)
            {
                context.RegisterService(service);
            }
        }

        public void RegisterElements(List<MonoBehaviour> elements, IGameContext context)
        {
            foreach (var element in elements)
            {
                if (element is IGameElement gameElement)
                {
                    context.RegisterElement(gameElement);   
                }
            }
        }
    }
}