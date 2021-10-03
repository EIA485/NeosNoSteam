using HarmonyLib;
using NeosModLoader;
using FrooxEngine;
using BaseX;
using System;
using CloudX.Shared;

namespace NoSteam
{
    public class NoSteam : NeosMod
    {
        public override string Name => "NoSteam";
        public override string Author => "eia485";
        public override string Version => "1.0.0";
        public override string Link => "https://github.com/EIA485/NeosNoSteam/";
        public override void OnEngineInit()
        {
            Harmony harmony = new Harmony("net.eia485.NoSteam");
            harmony.PatchAll();
        }
        [HarmonyPatch(typeof(SteamConnector))]
        class NoSteamPatch
        {
            [HarmonyPrefix]
            [HarmonyPatch("InitializeSteamAPI")]
            static bool InitializeSteamAPIPrefix()
            {
                return false;
            }
            [HarmonyPrefix]
            [HarmonyPatch("InitializationAttempted", MethodType.Getter)]
            static bool InitializationAttemptedPrefix(ref bool __result)
            {
                __result = true;
                return false;
            }
        }
    }
}