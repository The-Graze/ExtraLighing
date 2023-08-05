using BepInEx;
using BepInEx.Configuration;
using ExtraLighing.Scripts;
using System;
using UnityEngine;
using Utilla;

namespace ExtraLighing
{
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        public static volatile Plugin Instance;
        public ConfigEntry<bool> PlayerLights;
        public ConfigEntry<bool> ColourPlayerLights;
        public ConfigEntry<Color> StaticColour;
        public ConfigEntry<bool> MapChanges;
        void Awake()
        {
            Instance = this;
            PlayerLights = Config.Bind("Settings", "Player Lights", true, "Pick if Players Should Have lights on them");
            ColourPlayerLights = Config.Bind("Settings", "Colour Player Lights?", true, "Should the Players lights match their colour");
            StaticColour = Config.Bind("Settings", "Static Light Colour", Color.white, "The Static Light Colour if you disable Player colours");
            MapChanges = Config.Bind("Settings", "Apply Map Lighting Changes", true, "Decide if you want the map chanaged applied (eg campfire)");
            QualitySettings.SetQualityLevel((int)QualityLevel.Fastest);
            QualitySettings.pixelLightCount = 20;
        }
        void Start()
        {Utilla.Events.GameInitialized += OnGameInitialized;}

        void OnEnable()
        {HarmonyPatches.ApplyHarmonyPatches();}
        void OnDisable()
        {HarmonyPatches.RemoveHarmonyPatches();}

        void OnGameInitialized(object sender, EventArgs e)
        {
            foreach(Light l in Resources.FindObjectsOfTypeAll<Light>()) 
            {
                Destroy(l);
            }
            if (PlayerLights.Value == true)
            {
                GorillaTagger.Instance.offlineVRRig.gameObject.AddComponent<PlayerLight>();
                GameObject rb = GameObject.Find("Rig Parent");
                rb.transform.GetChild(0).gameObject.AddComponent<PlayerLight>();
                rb.transform.GetChild(1).gameObject.AddComponent<PlayerLight>();
                rb.transform.GetChild(2).gameObject.AddComponent<PlayerLight>();
                rb.transform.GetChild(3).gameObject.AddComponent<PlayerLight>();
                rb.transform.GetChild(4).gameObject.AddComponent<PlayerLight>();
                rb.transform.GetChild(5).gameObject.AddComponent<PlayerLight>();
                rb.transform.GetChild(6).gameObject.AddComponent<PlayerLight>();
                rb.transform.GetChild(7).gameObject.AddComponent<PlayerLight>();
                rb.transform.GetChild(8).gameObject.AddComponent<PlayerLight>();
                rb.transform.GetChild(9).gameObject.AddComponent<PlayerLight>();
            }
            GameObject.Find("LocalObjects_Prefab").AddComponent<ShaderChanager>();
            if (MapChanges.Value == true)
            {
                MapLightChanages();
            }
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = -1;
        }

        void MapLightChanages()
        {
            GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Props/campfire").AddComponent<CampFireLight>();
        }
    }
}
