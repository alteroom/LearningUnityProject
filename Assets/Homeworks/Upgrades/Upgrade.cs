using System;
using UnityEngine;

namespace Homeworks.Upgrades
{
    [Serializable]
    public class Upgrade
    {
        [SerializeField] 
        public int Level;

        [SerializeField] 
        public int HitPoints;

        [SerializeField] 
        public int Damage;
        
        [SerializeField] 
        public int Cost;

        public int MaxLevel { get; } = 100;

        public int MaxHitPoints { get; } = 1000;
        
    }
}