﻿using BepInEx;
using BepInEx.Logging;
using ManeaterDamagePatch.Misc;
using HarmonyLib;
using ManeaterDamagePatch.Patches;
namespace ManeaterDamagePatch
{
    [BepInPlugin(Metadata.GUID,Metadata.NAME,Metadata.VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        internal static readonly Harmony harmony = new(Metadata.GUID);
        internal static readonly ManualLogSource mls = BepInEx.Logging.Logger.CreateLogSource(Metadata.NAME);

        void Awake()
        {
            harmony.PatchAll(typeof(CaveDwellerAIPatcher));
            mls.LogInfo($"{Metadata.NAME} {Metadata.VERSION} has been loaded successfully.");
        }
    }   
}
