using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
    
    namespace TestMod.Items
    {
        public class MedicStash : ModItem
        {
            public override void SetStaticDefaults()
            {
				DisplayName.SetDefault("Medic's Stash");
                Tooltip.SetDefault("Unlimited Biotic Bullets");
            }
    
            public override void SetDefaults()
            {
                item.width = 24;
                item.height = 24;
                item.maxStack = 1;
                item.value = Item.sellPrice(0, 0, 0, 25);
                item.rare = 1;
				item.ammo = mod.ItemType("BioticBullet");
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