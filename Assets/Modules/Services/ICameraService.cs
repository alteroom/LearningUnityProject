using UnityEngine;

namespace Modules.Services
{
    public interface ICameraService
    {
        Camera Camera { get; }
        Transform CameraTransform { get; }
    }

}