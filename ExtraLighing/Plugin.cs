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
            QualitySettings.pixelLightCount = 12;
        }
        void Start()
        {Utilla.Events.GameInitialized += OnGameInitialized;}

        void OnEnable()
        {HarmonyPatches.ApplyHarmonyPatches();}
        void OnDisable()
        {HarmonyPatches.RemoveHarmonyPatches();}

        void OnGameInitialized(object sender, EventArgs e)
        {
            GameObject.Find("Level").AddComponent<ShaderChanager>();
            if (MapChanges.Value == true)
            {
                MapLightChanages();
            }
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = -1;
        }

        void MapLightChanages()
        {
            GameObject.Find("Level/forest/ForestObjects/campfire").AddComponent<CampFireLight>();
        }
    }
}
