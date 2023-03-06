using Vintagestory.API.Common;
using Vintagestory.API.MathTools;
using Vintagestory.GameContent;

namespace PamelasMod {
  public class PamelasMod : ModSystem {
    public override void Start(ICoreAPI api) {
      base.Start(api);
    }

    public override void AssetsFinalize(ICoreAPI api) {
      base.AssetsFinalize(api);

      foreach (var obj in api.World.Collectibles) {
        SetMaxStackSize(obj);
      }
    }

    private void SetMaxStackSize(CollectibleObject obj) {
      switch (obj) {
        case ItemPlantableSeed a:
        case ItemTreeSeed b:
        case CollectibleObject c when c.Code.Path.Contains("flour"):
        case CollectibleObject d when d.Code.Path.Contains("feather"):
          obj.MaxStackSize = GameMath.Max(512, obj.MaxStackSize);
          break;
        case ItemRustyGear a:
        case ItemTemporalGear b:
          obj.MaxStackSize = GameMath.Max(5000, obj.MaxStackSize);
          break;
        default:
          obj.MaxStackSize = GameMath.Max(256, obj.MaxStackSize);
          break;
      }
    }
  }
}
