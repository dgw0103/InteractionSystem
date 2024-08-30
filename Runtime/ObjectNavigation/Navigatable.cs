using System.Collections;
using UnityEngine;
using System;

namespace InteractionSystem
{
    internal class Navigatable : MonoBehaviour
    {
        [SerializeField] private bool isNavigated = true;



        internal bool IsNavigated { get => isNavigated; set => isNavigated = value; }
    }
}