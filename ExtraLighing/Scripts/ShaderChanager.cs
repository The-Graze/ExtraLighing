using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace ExtraLighing.Scripts
{
    public class ShaderChanager : MonoBehaviour
    {
        void Start()
        {
            foreach (Transform t in transform)
            {
                t.gameObject.AddComponent<ShaderChanager>();
            }
            if (this.GetComponent<SkinnedMeshRenderer>() != null || this.GetComponent<MeshRenderer>() != null && !gameObject.name.Contains("Wind"))
            {
                foreach (Material m in this.GetComponent<Renderer>().materials)
                {
                    m.shader = Shader.Find("Standard");
                    m.SetFloat("_SpecularHighlights", 0f);
                    m.EnableKeyword("_SPECULARHIGHLIGHTS_OFF");
                    m.EnableKeyword("_GLOSSYREFLECTIONS_ON");
                    m.DisableKeyword("_GLOSSYREFLECTIONS_OFF");
                }
                Destroy(this);
            }
            else Destroy(this);
        }
    }
}