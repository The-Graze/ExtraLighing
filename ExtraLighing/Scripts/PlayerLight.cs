using GorillaNetworking;
using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ExtraLighing.Scripts
{
    public class PlayerLight : MonoBehaviour
    {
        VRRig rig;
        Light light;
        Color Orange;
        bool gotcosmetics;
        Color col()
        {
            if (Plugin.Instance.ColourPlayerLights.Value == false)
            {
                return Plugin.Instance.StaticColour.Value;
            }
            if (rig == GorillaTagger.Instance.offlineVRRig)
            {
                return rig.materialsToChangeTo[0].color;
            }
            else
            {
                if (rig.setMatIndex == 0)
                {
                    return rig.materialsToChangeTo[0].color;
                }
                if (rig.setMatIndex == 1)
                {
                    return rig.materialsToChangeTo[1].color;
                }
                if (rig.setMatIndex == 2)
                {
                    return Orange;
                }
                if (rig.setMatIndex == 3)
                {
                    return Color.blue;
                }
                if (rig.setMatIndex == 4)
                {
                    return rig.materialsToChangeTo[4].color;
                }
                if (rig.setMatIndex == 5)
                {
                    return rig.materialsToChangeTo[5].color;
                }
                if (rig.setMatIndex == 7)
                {
                    return Color.blue;
                }
                if (rig.setMatIndex == 8)
                {
                    return rig.materialsToChangeTo[8].color;
                }
                if (rig.setMatIndex == 9)
                {
                    return rig.materialsToChangeTo[9].color;
                }
                if (rig.setMatIndex == 10)
                {
                    return rig.materialsToChangeTo[10].color;
                }
                if (rig.setMatIndex == 11)
                {
                    return Orange;
                } 
            }
            return Plugin.Instance.StaticColour.Value;
        }

        void Start () 
        {
            gotcosmetics = false;
            rig = this.GetComponent<VRRig>();
            light = gameObject.AddComponent<Light>();
            Orange = new Color(1, 0.3288f, 0, 1);
            light.intensity = 3;
            light.range = 3;
        }

        void LateUpdate()
        {
            if (rig == GorillaTagger.Instance.offlineVRRig)
            {
                light.enabled = !PhotonNetwork.InRoom;
            }
            if(light.enabled)light.color = col();
            if (rig.initializedCosmetics && gotcosmetics == false)
            {
                CosmeticsAdd();
                gotcosmetics = true;
            }
        }

        void TestSparker()
        {
            Light Light2 = rig.transform.Find("SPARKLER").GetChild(1).gameObject.AddComponent<Light>();
            Light2.range = 1;
            Light2.intensity = 4;
            Light2.color = new Color(1, 1, 0.2453f, 1);
        }
        void CosmeticsAdd()
        {
            if (rig.cosmeticSet.items.Contains(CosmeticsController.instance.allCosmeticsDict["LBAAS."]))
            {
                Light Light2 = rig.transform.Find("SPARKLER").GetChild(1).gameObject.AddComponent<Light>();
                Light2.range = 1;
                Light2.intensity = 4;
                Light2.color = new Color(1, 1, 0.2453f, 1);
            }
            if(rig.cosmeticSet.items.Contains(CosmeticsController.instance.allCosmeticsDict[""]))
            {

            }
        }
    }
}
