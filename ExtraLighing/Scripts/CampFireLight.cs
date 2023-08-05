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
        Color firecol = new Color(1, 0.4442f, 0, 1);
        void Start () 
        {
            particleSystem = transform.FindChild("lava particle").GetComponent<ParticleSystem>();
            light = gameObject.AddComponent<Light>();
            light.color = firecol;
            light.intensity = 3;
        }
        void LateUpdate () 
        {
            light.enabled = particleSystem.isEmitting;
        }
    }
}
