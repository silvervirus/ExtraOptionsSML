using HarmonyLib;

namespace ExtraOptions.Patches
{
    [HarmonyPatch(typeof(WaterscapeVolume), nameof(WaterscapeVolume.RenderImage))]
    public static class WaterscapeVolume_Patches
    {
        [HarmonyPrefix]
        public static void Patch_RenderImage(ref bool cameraInside)
        {
            if (Main.config.FogFix)
                cameraInside = false;
        }
    }
}