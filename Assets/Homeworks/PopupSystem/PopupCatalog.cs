using System;
using Modules.UISystem.Base;
using UnityEngine;

namespace Homeworks.PopupSystem
{
    [CreateAssetMenu(
        fileName = "PopupCatalog", 
        menuName = "Game Engine/GUI/New PopupCatalog", 
        order = 0)]
    public class PopupCatalog : ScriptableObject
    {
        [SerializeField] 
        private PopupInfo[] m_Popups = { };

        public Window GetPrefab(PopupKey key)
        {
            foreach (var info in m_Popups)
            {
                if (info.m_Key == key)
                {
                    return info.m_Prefab;
                }
            }

            throw new Exception($"Prefab '{key}' not found!");
        }
    }
}