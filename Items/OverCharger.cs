using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
    
    namespace TestMod.Items
    {
        public class OverCharger : ModItem
        {
            public override void SetStaticDefaults()
            {
				DisplayName.SetDefault("Over Charger");
                Tooltip.SetDefault("Unlimited Pulse Munition");
            }
    
            public override void SetDefaults()
            {
                item.width = 24;
                item.height = 24;
                item.maxStack = 1;
                item.value = Item.sellPrice(0, 0, 0, 25);
                item.rare = 1;
				item.ammo = mod.ItemType("PulseMunition");
				item.consumable = false;
            }
			
			public override void AddRecipes()
			{
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(ItemID.DirtBlock);
				recipe.AddTile(TileID.WorkBenches);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
        }
    }