using System.Collections;
using UnityEngine;
using System;

namespace InteractionSystem
{
    public class Navigatable : MonoBehaviour
    {
        [SerializeField] private bool isNavigated = true;



        public bool IsNavigated { get => isNavigated; set => isNavigated = value; }
    }
}