using System;
using Modules.UISystem.Base;
using UnityEngine;

namespace Homeworks.PopupSystem
{
    [Serializable]
    public sealed class PopupInfo
    {
        [SerializeField]
        public PopupKey m_Key;

        [SerializeField] 
        public Window m_Prefab;
    }
}