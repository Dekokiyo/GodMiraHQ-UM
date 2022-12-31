namespace UltimateMods.Maps
{
    public static class ResetLabHallWall
    {
        public static void ShipStatusAwake(ShipStatus __instance)
        {
            if (Helpers.IsGodMiraHQ)
            {
                Transform LabHallWalls = __instance.transform.Find("LabHall");
                EdgeCollider2D Collider1 = LabHallWalls.GetComponentsInChildren<EdgeCollider2D>()[0];
                EdgeCollider2D Collider2 = LabHallWalls.gameObject.AddComponent<EdgeCollider2D>();
                List<Vector2> Points1 = Collider1.points.ToArray()[..7].ToList();
                List<Vector2> Points2 = new();
                Points1.Add(new Vector2(0.3054f, 2.1791f));
                Points2.Add(new Vector2(-0.9047f, 2.1791f));
                Points2.AddRange(Collider1.points.ToArray()[9..].ToList());
                Collider1.points = Points1.ToArray();
                Collider2.points = Points2.ToArray();

                Transform LaunchPadWalls = __instance.transform.Find("LaunchPad");
                EdgeCollider2D Collider3 = LaunchPadWalls.GetComponentsInChildren<EdgeCollider2D>()[0];
                EdgeCollider2D Collider4 = LaunchPadWalls.gameObject.AddComponent<EdgeCollider2D>();
                List<Vector2> Points3 = Collider3.points.ToArray()[..6].ToList();
                List<Vector2> Points4 = Collider3.points.ToArray()[6..].ToList();
                Collider3.points = Points3.ToArray();
                Collider4.points = Points4.ToArray();

                GameObject CloudGenCollider = GameObject.Find("MiraShip(Clone)/CloudGen");
                foreach (EdgeCollider2D ec2 in CloudGenCollider.GetComponents<EdgeCollider2D>())
                {
                    ec2.enabled = false;
                }
            }
        }

        public static void Shadow(ShipStatus __instance)
        {
            if (Helpers.IsGodMiraHQ)
            {/*
                Transform Shadows = Transform.Instantiate(__instance.transform.FindChild("Cafe").FindChild("Shadows"), __instance.transform.FindChild("LabHall"));
                foreach (Object component in Shadows.GetComponents<EdgeCollider2D>())
                    Object.Destroy(component);
                Shadows.gameObject.SetActive(true);

                Shadows.gameObject.AddComponent<EdgeCollider2D>().points = new Il2CppStructArray<Vector2>(new Vector2[22]
                { // 24.22 1.89
                    new Vector2(5.7f, 15.9f),
                    new Vector2(5.7f, 21.2f),
                    new Vector2(5.7f, 21.2f),
                    new Vector2(5.7f, 20.7f),
                    new Vector2(-3.9f, 20.7f),
                    new Vector2(-3.9f, 12.15f),
                    new Vector2(-5f, 12.15f),
                    new Vector2(-5f, 20.7f),
                    new Vector2(-6f, 20.7f),
                    new Vector2(-6f, 23.5f),
                    new Vector2(5.7f, 23.5f),
                    new Vector2(5.7f, 22.7f),
                    new Vector2(7.22f, 22.7f),
                    new Vector2(7.22f, 21.6f),
                    new Vector2(7.21f, 21.6f),
                    new Vector2(7.21f, 22.7f),
                    new Vector2(10f, 22.7f),
                    new Vector2(10f, 16.4f),
                    new Vector2(7.3f, 16.4f),
                    new Vector2(7.3f, 20.6f),
                    new Vector2(7.2f, 20.6f),
                    new Vector2(7.2f, 14.9f),
                });*/
            }
        }

        [HarmonyPatch(typeof(ShipStatus), nameof(ShipStatus.Awake))]
        static class ShipStatusAwakePatch
        {
            static void Postfix(ShipStatus __instance)
            {
                ShipStatusAwake(__instance);
                Shadow(__instance);
            }
        }
    }
}