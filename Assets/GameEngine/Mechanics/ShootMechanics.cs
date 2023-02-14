using Homeworks._1_GameMechanics.Scripts.Primitives.Containers;
using Homeworks._1_GameMechanics.Scripts.Primitives.Events;
using Homeworks._1_GameMechanics.Scripts.Primitives.Timers;
using UnityEngine;

namespace Homeworks._1_GameMechanics.Scripts.Mechanics
{
    public class ShootMechanics : MonoBehaviour
    {
        [SerializeField] 
        private IntBehaviour ammo;

        [SerializeField] 
        private TimerBehaviour countdown;
        
        [SerializeField]
        private Vector3EventReceiver shootInDirectionReceiver;

        [SerializeField]
        private Vector3EventReceiver spawnBulletEvent;
        private void OnEnable()
        {
            this.shootInDirectionReceiver.OnEvent += this.OnRequestShoot;
        }

        private void OnDisable()
        {
            this.shootInDirectionReceiver.OnEvent -= this.OnRequestShoot;
        }

        private bool CanShoot => !this.countdown.IsPlaying && this.ammo.Value > 0;
        private void OnRequestShoot(Vector3 point)
        {
            if (!CanShoot)
            {
                return;
            }

            this.ammo.Value -= 1;
            this.spawnBulletEvent.Call(point);
            
            this.countdown.ResetTime();
            this.countdown.Play();
        }
    }
}