using Vintagestory.API.Common;
using Vintagestory.API.MathTools;
using Vintagestory.API.Server;
using Vintagestory.GameContent;

namespace PamelasMod {
  public class PamelasMod : ModSystem {
    public override double ExecuteOrder() {
      return double.MaxValue;
    }

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
      // Not using switch statement in order to target C#5.0 so that the game will load and compile raw .cs file
      if (obj.Durability != 0) {
        return;
      }

      if (obj is ItemRustyGear || obj is ItemTemporalGear) {
        obj.MaxStackSize = GameMath.Max(5000, obj.MaxStackSize);
        return;
      }

      if (obj is ItemPlantableSeed || obj is ItemTreeSeed || obj.Code.Path.Contains("flour") || obj.Code.Path.Contains("feather")) {
        obj.MaxStackSize = GameMath.Max(512, obj.MaxStackSize);
        return;
      }

      obj.MaxStackSize = GameMath.Max(256, obj.MaxStackSize);
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

      BlockLootVessel.lootLists["food"] = LootList.Create(2f, new LootItem[]
      {
        LootItem.Item(3f, 16f, 32f, new string[]
        {
          "grain-spelt",
          "grain-rice",
          "grain-flax",
          "grain-rice",
          "grain-rye"
        }),
        LootItem.Item(3f, 8f, 16f, new string[]
        {
          "fruit-redapple",
          "fruit-pinkapple",
          "fruit-yellowapple",
          "fruit-cherry",
          "fruit-peach",
          "fruit-pear",
          "fruit-orange",
          "fruit-mango",
          "fruit-breadfruit",
          "fruit-lychee",
          "fruit-pomegranate"
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
        LootItem.Item(3f, 16f, 32f, new string[]
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
        LootItem.Item(2f, 1f, 1f, new string[]
        {
          "axe-obsidian",
          "shovel-obsidian",
          "knife-generic-obsidian",
        }),
        LootItem.Item(2f, 1f, 1f, new string[]
        {
          "axe-copper",
          "shovel-copper",
          "knife-copper",
          "scythe-copper",
          "axe-felling-copper",
          "shovel-copper",
          "knife-generic-copper",
          "blade-falx-copper"
        }),
        LootItem.Item(1f, 1f, 1f, new string[]
        {
          "axe-tinbronze",
          "shovel-tinbronze",
          "knife-tinbronze",
          "scythe-tinbronze",
          "axe-felling-tinbronze",
          "shovel-tinbronze",
          "knife-generic-tinbronze",
          "blade-falx-tinbronze"
        }),
        LootItem.Item(1f, 1f, 1f, new string[]
        {
          "pickaxe-copper"
        }),
        LootItem.Item(0.5f, 1f, 1f, new string[]
        {
          "pickaxe-tinbronze"
        }),
        LootItem.Item(1f, 8f, 16f, new string[]
        {
          "gear-rusty"
        })
      });

      BlockLootVessel.lootLists["farming"] = LootList.Create(2f, new LootItem[]
      {
        LootItem.Item(1f, 1f, 1f, new string[]
        {
          "linensack"
        }),
        LootItem.Item(0.125f, 32f, 64f, new string[]
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
