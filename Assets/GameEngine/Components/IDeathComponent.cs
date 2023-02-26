using System;

namespace GameEngine.Components
{
    public interface IDeathComponent
    {
        event Action<object> OnDeath;
        void Death(object reason);
    }
}