using UnityEngine;

namespace GameEngine.Services
{
    public interface ICameraService
    {
        Camera Camera { get; }
        Transform CameraTransform { get; }
    }

}