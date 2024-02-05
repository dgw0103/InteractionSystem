using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoJin.InteractionSystem
{
    public class LightEmission : Targeting
    {
        [SerializeField] private MeshRenderer except;



        public override void OnTargeted()
        {
        }
        public override void OnReleased()
        {

        }
    }
}