using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using HarmonyLib;
using UnityEngine;


namespace Il2Cpp_Cheat_Base
{
    [BepInPlugin(GUID, MODNAME, VERSION)]
    public class Plugin : BepInEx.IL2CPP.BasePlugin
    {
        //Plugin info.
        public const string
            MODNAME = "warmode_cheat",
            AUTHOR = "stikosek",
            GUID = "net." + AUTHOR + "." + MODNAME,
            VERSION = "0.0.1";

        public override void Load()
        {
            //harmony shit
            var harmony = new Harmony(GUID);
            harmony.PatchAll();
       
            //Creates gui object
            Gui.MainStrut.CreateInstance(this);

        }





    }
 }
