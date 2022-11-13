// using HarmonyLib;
// using UnityEngine;
// using System.Linq;
// using System.Collections.Generic;
// using static UltimateMods.Modules.Assets;

// namespace UltimateMods.Maps
// {
//     public static class GodMira
//     {
//         public static GameObject DropShip;
//         public static EdgeCollider2D Shadow;
//         public static SpriteRenderer ShadowRend;

//         public static void ShipStatusAwake(ShipStatus __instance)
//         {
//             if (COHelpers.IsGodMiraHQ)
//             {
//                 DropShip = GameObject.Find("Walls/Dropship");
//                 DropShip.SetActive(false);

//                 GameObject GodMiraHQMap = GameObject.Instantiate(GodMiraHQ, __instance.transform);
//                 GodMiraHQMap.name = "GodMiraHQ";
//                 GodMiraHQMap.transform.localPosition = new Vector3(6.8f, 15.26f, 0.5f);
//                 GodMiraHQMap.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
//                 GodMiraHQMap.SetActive(true);

//                 GameObject GodDropShip = GameObject.Instantiate(NewDropShip, __instance.transform);
//                 GodDropShip.name = "GodDropShip";
//                 GodDropShip.transform.localPosition = new Vector3(-11.6f, 14.5f, 0.5f);
//                 GodDropShip.transform.localScale = new Vector3(0.8f, 0.8f, 1f);
//                 GodDropShip.SetActive(true);

//                 var LabHallWireTask = GameObject.Find("MiraShip(Clone)/LabHall/FixWiringConsole");
//                 Vector3 LabHallWireTaskPos = LabHallWireTask.transform.position + new Vector3(-0.65f, 0.15f, 0f);
//                 if (LabHallWireTask != null && COHelpers.IsGodMiraHQ)
//                 {
//                     LabHallWireTask.transform.position = LabHallWireTaskPos;
//                 }

//                 GameObject ShadowBase = GameObject.Find("MiraShip(Clone)/Walls/CafeteriaWalls");
//                 {
//                     SpriteRenderer renderer = ShadowBase.GetComponent<SpriteRenderer>();
//                     if (renderer != null)
//                     {
//                         GodMiraHQMap.transform.GetChild(0).transform.GetComponent<SpriteRenderer>().material = renderer.material;
//                         GodMiraHQMap.transform.GetChild(1).transform.GetComponent<SpriteRenderer>().material = renderer.material;
//                         GodMiraHQMap.transform.GetChild(2).transform.GetComponent<SpriteRenderer>().material = renderer.material;
//                         GodDropShip.transform.GetChild(0).transform.GetComponent<SpriteRenderer>().material = renderer.material;
//                         GodDropShip.transform.GetChild(1).transform.GetComponent<SpriteRenderer>().material = renderer.material;
//                     }
//                 }

//                 Transform LabHallShadow = __instance.transform.Find("LabHall").FindChild("Shadows LabHall");
//                 EdgeCollider2D Shadow = LabHallShadow.GetComponent<EdgeCollider2D>();
//                 EdgeCollider2D Shadow2 = LabHallShadow.gameObject.AddComponent<EdgeCollider2D>();

//                 List<Vector2> VanillaShadow = Shadow.points.ToArray()[..5].ToList();
//                 List<Vector2> VanillaShadow2 = new();
//                 VanillaShadow.Add(new Vector2(-1.0047f, 3.0883f));
//                 VanillaShadow2.Add(new Vector2(0.2554f, 3.1168f));
//                 VanillaShadow2.AddRange(Shadow.points.ToArray()[6..].ToList());

//                 Shadow.points = VanillaShadow.ToArray();
//                 Shadow2.points = VanillaShadow2.ToArray();
//             }
//         }

//         [HarmonyPatch(typeof(ShipStatus), nameof(ShipStatus.Awake))]
//         static class ShipStatusAwakePatch
//         {
//             static void Postfix(ShipStatus __instance)
//             {
//                 ShipStatusAwake(__instance);
//             }
//         }
//     }
// }