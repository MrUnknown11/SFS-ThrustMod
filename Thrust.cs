using SFS.UI;
using SFS.World;
using System;
using UnityEngine;
using SFS;

namespace ThrustMod
{

    public class Thrust : MonoBehaviour
    {
        public static Rect windowRect = new Rect(1300f, Screen.height * 0.05f, 150f, 220f);

        public static Rocket rocket;

        public static float count = 1;

        private string thrustx;

        private float thrust;

        private float maxSliderValue = 5;
        private float minSliderValue = 1;
        private float currentValue = 0;

        private int selected;
        private string[] strings = { "Slider", "Custom" };

        public void windowFunc(int windowID)
        {
            GUI.Label(new Rect(40f, 20f, 160f, 20f), "Select Mode");
            GUI.Label(new Rect(0f, 30f, 200f, 20f), "-------------------------------------------------------------------------------");
            selected = GUI.Toolbar(new Rect(10f, 50f, 130f, 25f), selected, strings);
            GUI.Label(new Rect(0f, 70f, 200f, 20f), "-------------------------------------------------------------------------------");
            if(selected == 0)
            {
                GUI.Label(new Rect(10f, 90f, 130f, 20f), "Increase Thrust");
                currentValue = GUI.HorizontalSlider(new Rect(10f, 110f, 130f, 20f), currentValue, minSliderValue, maxSliderValue);
                if(GUI.Button(new Rect(10f, 130f, 100f, 20f), "Increase"))
                {
                    SetThrottle(currentValue);
                }
                GUI.Label(new Rect(0f, 150f, 200f, 20f), "-------------------------------------------------------------------------------");
                GUI.Label(new Rect(10f, 170f, 130f, 20f), "Thrust x" + currentValue.ToString());
                GUI.Label(new Rect(0f, 190f, 200f, 20f), "-------------------------------------------------------------------------------");
            }
            if (selected == 1)
            {
                GUI.Label(new Rect(10f, 90f, 130f, 20f), "Increase Thrust");
                thrustx = GUI.TextField(new Rect(10f, 110f, 130f, 20f), thrustx);
                if (GUI.Button(new Rect(10f, 130f, 100f, 20f), "Increase"))
                {
                    thrust = float.Parse(thrustx);
                    SetThrottle(thrust);
                }
                GUI.Label(new Rect(0f, 150f, 200f, 20f), "-------------------------------------------------------------------------------");
                GUI.Label(new Rect(10f, 170f, 130f, 20f), "Thrust x" + thrust.ToString());
                GUI.Label(new Rect(0f, 190f, 200f, 20f), "-------------------------------------------------------------------------------");
            }
            GUI.DragWindow();
        }       

        public void SetThrottle(float value)
        {
            if(rocket = PlayerController.main.player.Value as Rocket)
                rocket.throttle.throttlePercent.Value = value;
        }

        public void OnGUI()
        {
            if (Main.active == true)
            {
                windowRect = GUI.Window(GUIUtility.GetControlID(FocusType.Passive), windowRect, new GUI.WindowFunction(windowFunc), "Thrust Mod");
            }
            else
            {
                return;
            }
        }
    }
}
