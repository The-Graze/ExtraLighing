using ExtraLighing.Scripts;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtraLighing.Patches
{
  /*  [HarmonyPatch(typeof(VRRig))]
    [HarmonyPatch("Awake", MethodType.Normal)]
    internal class PlayerPatch
    {
        private static bool Prefix(VRRig __instance)
        {
            if (Plugin.Instance.PlayerLights.Value == true)
            {
                __instance.gameObject.AddComponent<PlayerLight>();
            }
                return true;
        }
    }*/
}