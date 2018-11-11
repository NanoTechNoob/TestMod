using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
    
    namespace TestMod.Items
    {
        public class Soullet : ModItem
        {
            public override void SetStaticDefaults()
            {
				DisplayName.SetDefault("Soullet");
                Tooltip.SetDefault("");
            }
    
            public override void SetDefaults()
            {
                item.width = 16;
                item.height = 16;
                item.maxStack = 999;
                item.value = Item.sellPrice(0, 0, 0, 25);
                item.rare = 1;
				item.ammo = mod.ItemType("Soullet");
				item.consumable = true;
            }
			
			public override void AddRecipes()
			{
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(ItemID.DirtBlock);
				recipe.AddTile(TileID.WorkBenches);
				recipe.SetResult(this, 111);
				recipe.AddRecipe();
			}
        }
    }