using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace ExtraLighing.Scripts
{
    public class CampFireLight : MonoBehaviour
    {
        ParticleSystem particleSystem;
        Light light;
        Color firecol;
        void Start () 
        {
            particleSystem = transform.GetChild(4).GetChild(0).GetChild(0).GetComponent<ParticleSystem>();
            light = gameObject.AddComponent<Light>();
            firecol = new Color(1, 0.4442f, 0, 1);
            light.color = firecol;
            light.intensity = 3;
        }
        void LateUpdate () 
        {
            light.enabled = particleSystem.isEmitting;
        }
    }
}
