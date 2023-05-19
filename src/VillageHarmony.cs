using HarmonyLib;
using Vintagestory.API.Common;
using Vintagestory.API.MathTools;
using Vintagestory.ServerMods;

namespace PamelasMod {
  [Harmony]
  public class VillagePatch : ModSystem {
    [HarmonyPatch(typeof(WorldGenStructure), "TryGenerate")]
    public static void Postfix(WorldGenStructure __instance, bool __result, IBlockAccessor blockAccessor, IWorldAccessor worldForCollectibleResolve, BlockPos startPos, int climateUpLeft, int climateUpRight, int climateBotLeft, int climateBotRight) {
      if (__instance.Code.Contains("village-4") && __result) {
        worldForCollectibleResolve.Logger.Debug("{0} generated at {1}", __instance.Code, startPos);
      }
    }

    public override void Start(ICoreAPI api) {
      base.Start(api);
      new Harmony("pam").PatchAll();
    }
  }
}
