using HarmonyLib;
using UnityEngine;
using static UltimateMods.Modules.Assets;

namespace UltimateMods.Maps
{
    public static class GodMira
    {
        public static GameObject DropShip;

        public static void ShipStatusAwake(ShipStatus __instance)
        {
            if (PlayerControl.LocalPlayer.isMira() && CustomOptionHolder.EnableGodMiraHQ.getBool())
            {
                DropShip = GameObject.Find("Walls/Dropship");
                DropShip.SetActive(false);

                GameObject GodMiraHQMap = GameObject.Instantiate(GodMiraHQ, __instance.transform);
                GodMiraHQMap.name = "GodMiraHQ";
                GodMiraHQMap.transform.localPosition = new Vector3(6.8f, 15.26f, 0.5f);
                GodMiraHQMap.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
                GodMiraHQMap.SetActive(true);

                GameObject GodDropShip = GameObject.Instantiate(NewDropShip, __instance.transform);
                GodDropShip.name = "GodDropShip";
                GodDropShip.transform.localPosition = new Vector3(-11.6f, 14.5f, 0.5f);
                GodDropShip.transform.localScale = new Vector3(0.8f, 0.8f, 1f);
                GodDropShip.SetActive(true);
            }
        }

        [HarmonyPatch(typeof(ShipStatus), nameof(ShipStatus.Awake))]
        static class ShipStatusAwakePatch
        {
            static void Postfix(ShipStatus __instance)
            {
                ShipStatusAwake(__instance);
            }
        }
    }
}