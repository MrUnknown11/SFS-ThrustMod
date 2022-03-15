using HarmonyLib;
using ModLoader;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Reflection;
using System.IO;
using SFS;

namespace ThrustMod
{
    public class Main : SFSMod
    {
        public Main() : base(
           "Launch",
           "LaunchPad",
           "Mr. Unknown",
           "v1.1.x",
           "v0.2"
           )
        { }

        public override void early_load()
        {
            Main.patcher = new Harmony("mods.Unknown.Thrust");
            Main.patcher.PatchAll();
            SceneManager.sceneLoaded += OnSceneLoaded;
            return;
        }

        public override void load()
        {
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            switch (scene.name)
            {
                case "World_PC":
                    worldViewObject = new GameObject("UnknownWorldObject");
                    worldViewObject.AddComponent<Thrust>();
                    UnityEngine.Object.DontDestroyOnLoad(worldViewObject);
                    worldViewObject.SetActive(true);
                    return;

                default:
                    UnityEngine.Object.Destroy(Main.worldViewObject);
                    break;
            }
            if (VideoSettingsPC.main.uiOpacitySlider.value == 0)
            {
                active = false;
                worldViewObject.SetActive(false);
            }
            else
            {
                active = true;
                worldViewObject.SetActive(true);
            }
        }

        public override void unload()
        {
            throw new NotImplementedException();
        }



        public static bool active;

        public static GameObject worldViewObject;

        public static Harmony patcher;

        public static string modDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\";
    }
}
