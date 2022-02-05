using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.IL2CPP;
using UnityEngine;
using HarmonyLib;


namespace Il2Cpp_Cheat_Base.Gui
{
    public class MainStrut : MonoBehaviour
    {

        //GameObject shit
        public MainStrut(IntPtr ptr) : base(ptr) { }
        private Plugin loader;

        public static void CreateInstance(Plugin loader)
        {
            //Create GameObject
            MainStrut obj = loader.AddComponent<MainStrut>();

            obj.loader = loader;

            //Prevent Unity from deleting when a new Scene loads.
            DontDestroyOnLoad(obj.gameObject);
            obj.hideFlags |= HideFlags.HideAndDontSave;

        }

        public void OnGUI()
        {
            //yes
        }
    }
}
