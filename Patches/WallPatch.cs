using HarmonyLib;
using UnityEngine;
using static UltimateMods.Modules.Assets;
using System.Linq;
using System.Collections.Generic;
namespace UltimateMods.Maps
{
    public static class ResetLabHallWall
    {
        public static void ShipStatusAwake(ShipStatus __instance)
        {
            if (COHelpers.IsGodMiraHQ)
            {
                Transform Walls = __instance.transform.Find("LabHall");
                EdgeCollider2D Collider1 = Walls.GetComponentsInChildren<EdgeCollider2D>()[0];
                EdgeCollider2D Collider2 = Walls.gameObject.AddComponent<EdgeCollider2D>();
                List<Vector2> points1 = new();
                List<Vector2> points2 = new();
                points1.Add(new Vector2(0.3708f, -3.5563f));
                points1.Add(new Vector2(0.3725f, 0.931f));
                points1.Add(new Vector2(0.5054f, 0.9247f));
                points1.Add(new Vector2(0.4976f, -2.7148f));
                points1.Add(new Vector2(5.231f, -2.7148f));
                points1.Add(new Vector2(5.258f, 1.7546f));
                points1.Add(new Vector2(1.1274f, 1.7418f));
                points1.Add(new Vector2(1.1157f, 2.1783f));
                points1.Add(new Vector2(0.3054f, 2.1791f));
                points2.Add(new Vector2(-0.9047f, 2.1791f));
                points2.Add(new Vector2(-1.5097f, 1.3651f));
                points2.Add(new Vector2(-1.8551f, 1.477f));
                points2.Add(new Vector2(-1.8782f, -1.6192f));
                points2.Add(new Vector2(-1.9957f, -1.6167f));
                points2.Add(new Vector2(-2.0201f, 1.9835f));
                points2.Add(new Vector2(-3.1187f, 1.9831f));
                points2.Add(new Vector2(-3.962f, 1.0953f));
                points2.Add(new Vector2(-4.7947f, 1.0891f));
                points2.Add(new Vector2(-5.6462f, 2.0045f));
                points2.Add(new Vector2(-6.7684f, 2.0074f));
                points2.Add(new Vector2(-6.7533f, -2.7233f));
                points2.Add(new Vector2(-1.8634f, -2.7335f));
                points2.Add(new Vector2(-1.875f, -3.5603f));
                Collider1.points = points1.ToArray();
                Collider2.points = points2.ToArray();

                GameObject CloudGenCollider = GameObject.Find("MiraShip(Clone)/CloudGen");
                foreach (EdgeCollider2D c in CloudGenCollider.GetComponents<EdgeCollider2D>())
                {
                    c.enabled = false;
                }
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