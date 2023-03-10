using Vintagestory.API.Common;
using Vintagestory.API.MathTools;
using Vintagestory.API.Server;
using Vintagestory.GameContent;

namespace PamelasMod {
  public class PamelasMod : ModSystem {
    public override double ExecuteOrder() => double.MaxValue;

    public override void AssetsFinalize(ICoreAPI api) {
      base.AssetsFinalize(api);
      if (api.Side != EnumAppSide.Server) {
        return;
      }
      var sapi = (ICoreServerAPI)api;
      SetWildCropDropMultiplier(sapi);
      SetLootVesselDrops(sapi);
      SetMaxStackSize(sapi);
    }

    private void SetWildCropDropMultiplier(ICoreServerAPI sapi) {
      BlockCrop.WildCropDropMul = 1.0f;
    }

    private void SetMaxStackSize(ICoreServerAPI sapi) {
      foreach (var obj in sapi.World.Collectibles) {
        SetMaxStackSize(obj);
      }
    }

    private void SetMaxStackSize(CollectibleObject obj) {
      switch (obj) {
        case CollectibleObject o when o.Durability != 0:
          break;
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

    private void SetLootVesselDrops(ICoreServerAPI sapi) {
      BlockLootVessel.lootLists["seed"] = LootList.Create(2f, new LootItem[]
      {
        LootItem.Item(1f, 8f, 16f, new string[]
        {
          "seeds-carrot",
          "seeds-onion",
          "seeds-spelt",
          "seeds-turnip",
          "seeds-rice",
          "seeds-rye",
          "seeds-soybean",
          "seeds-pumpkin",
          "seeds-cabbage"
        })
      });

      BlockLootVessel.lootLists["food"] = LootList.Create(4f, new LootItem[]
      {
        LootItem.Item(3f, 16f, 32f, new string[]
        {
          "grain-spelt",
          "grain-rice",
          "grain-flax",
          "grain-rice",
          "grain-rye"
        }),
        LootItem.Item(0.1f, 1f, 1f, new string[]
        {
          "tuningcylinder-1",
          "tuningcylinder-2",
          "tuningcylinder-3",
          "tuningcylinder-4",
          "tuningcylinder-5",
          "tuningcylinder-6",
          "tuningcylinder-7",
          "tuningcylinder-8",
          "tuningcylinder-9"
        })
      });

      BlockLootVessel.lootLists["forage"] = LootList.Create(4f, new LootItem[]
      {
        LootItem.Item(4f, 32f, 64f, new string[]
        {
          "stick",
          "drygrass"
        }),
        LootItem.Item(2f, 16f, 32f, new string[]
        {
          "stone-obsidian"
        }),
        LootItem.Item(2f, 32f, 64f, new string[]
        {
          "clay-blue",
          "clay-fire"
        }),
        LootItem.Item(2f, 16f, 32f, new string[]
        {
          "stone-andesite",
          "stone-chalk",
          "stone-claystone",
          "stone-chalk",
          "stone-granite",
          "stone-chalk",
          "stone-sandstone",
          "stone-shale"
        }),
        LootItem.Item(2f, 16f, 32f, new string[]
        {
          "cattailtops"
        }),
        LootItem.Item(4f, 16f, 32f, new string[]
        {
          "flaxfibers"
        }),
        LootItem.Item(1f, 8f, 16f, new string[]
        {
          "honeycomb"
        }),
        LootItem.Item(2f, 8f, 16f, new string[]
        {
          "poultice-linen-honey-sulfur"
        })
      });

      BlockLootVessel.lootLists["ore"] = LootList.Create(5f, new LootItem[]
      {
        LootItem.Item(2f, 16f, 32f, new string[]
        {
          "ore-lignite",
          "ore-bituminouscoal"
        }),
        LootItem.Item(1f, 8f, 16f, new string[]
        {
          "ore-quartz",
          "ore-bituminouscoal"
        }),
        LootItem.Item(2f, 10f, 30f, new string[]
        {
          "nugget-nativecopper"
        }),
        LootItem.Item(1f, 2f, 3f, new string[]
        {
          "nugget-sphalerite",
          "nugget-bismuthinite"
        }),
        LootItem.Item(1f, 5f, 15f, new string[]
        {
          "nugget-galena",
          "nugget-chromite",
          "nugget-ilmenite"
        }),
        LootItem.Item(2f, 5f, 15f, new string[]
        {
          "nugget-limonite",
          "nugget-magnetite"
        }),
        LootItem.Item(2f, 8f, 16f, new string[]
        {
          "nugget-cassiterite",
          "nugget-nativegold",
          "nugget-nativesilver",
          "nugget-cassiterite",
          "nugget-nativegold",
          "nugget-nativesilver"
        })
      });

      BlockLootVessel.lootLists["tool"] = LootList.Create(3f, new LootItem[]
      {
        LootItem.Item(1f, 1f, 1f, new string[]
        {
          "axe-obsidian",
          "shovel-obsidian",
          "knife-obsidian"
        }),
        LootItem.Item(3f, 1f, 1f, new string[]
        {
          "axe-copper",
          "shovel-copper",
          "knife-copper",
          "scythe-copper",
          "axe-copper",
          "shovel-copper",
          "knife-copper",
          "blade-falx-copper"
        }),
        LootItem.Item(3f, 1f, 1f, new string[]
        {
          "pickaxe-copper",
          "pickaxe-tinbronze"
        }),
        LootItem.Item(3f, 1f, 1f, new string[]
        {
          "axe-tinbronze",
          "shovel-tinbronze",
          "knife-tinbronze",
          "scythe-tinbronze",
          "axe-tinbronze",
          "shovel-tinbronze",
          "knife-tinbronze",
          "blade-falx-tinbronze"
        }),
        LootItem.Item(1f, 8f, 16f, new string[]
        {
          "gear-rusty"
        })
      });

      BlockLootVessel.lootLists["farming"] = LootList.Create(4f, new LootItem[]
      {
        LootItem.Item(1f, 1f, 1f, new string[]
        {
          "linensack"
        }),
        LootItem.Item(0.25f, 32f, 64f, new string[]
        {
          "feather"
        }),
        LootItem.Item(2f, 32f, 64f, new string[]
        {
          "flaxfibers"
        }),
        LootItem.Item(1f, 16f, 32f, new string[]
        {
          "flaxtwine"
        }),
        LootItem.Item(1f, 8f, 16f, new string[]
        {
          "seeds-cabbage"
        }),
        LootItem.Item(1f, 16f, 32f, new string[]
        {
          "cattailtops"
        }),
        LootItem.Item(1f, 1f, 1f, new string[]
        {
          "scythe-copper",
          "scythe-tinbronze",
          "scythe-copper",
          "scythe-tinbronze"
        })
      });

      BlockLootVessel.lootLists["arcticsupplies"] = LootList.Create(3f, new LootItem[]
      {
        LootItem.Item(2f, 32f, 64f, new string[]
        {
          "cattailtops"
        }),
        LootItem.Item(2f, 32f, 64f, new string[]
        {
          "drygrass"
        }),
        LootItem.Item(2f, 32f, 64f, new string[]
        {
          "stick"
        }),
        LootItem.Item(1f, 64f, 64f, new string[]
        {
          "stone-andesite",
          "stone-chalk",
          "stone-granite",
          "stone-chalk",
          "stone-basalt",
          "stone-chalk"
        }),
        LootItem.Block(1f, 64f, 64f, new string[]
        {
          "soil-medium-none"
        }),
        LootItem.Item(1f, 64f, 64f, new string[]
        {
          "clay-blue",
          "clay-fire"
        }),
        LootItem.Item(0.5f, 16f, 16f, new string[]
        {
          "poultice-linen-horsetail"
        }),
        LootItem.Item(0.5f, 40f, 56f, new string[]
        {
          "flaxfibers"
        }),
        LootItem.Item(0.3f, 3f, 9f, new string[]
        {
          "honeycomb"
        }),
        LootItem.Item(0.2f, 4f, 12f, new string[]
        {
          "gear-rusty"
        })
      });
    }
  }
}
