using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
    
    namespace TestMod.Items
    {
        public class ChocolateDonut : ModItem
        {
            public override void SetStaticDefaults()
            {
				DisplayName.SetDefault("Chocolate Donut");
                Tooltip.SetDefault("The inscription says: Token is redeemable for money.");
            }

            public override void SetDefaults()
            {
                item.width = 16;
                item.height = 16;
                item.maxStack = 999;
                item.value = Item.sellPrice(0, 0, 12, 50);
                item.rare = 1;
                item.useTime = 30;
                item.useAnimation = 30;
                item.useStyle = 4;
                item.consumable = true;
            }

            public override bool CanUseItem(Player player)
            {
                if(!Main.dayTime)
                {
                    return !NPC.AnyNPCs(mod.NPCType("DoomNut"));
                }
                return false;
            }

            public override bool UseItem(Player player)
            {
                if(!Main.dayTime)
                {
                    NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("DoomNut"));
                    Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
                    Main.PlaySound(2, (int)player.position.X, (int)player.position.Y, 2);
                    player.AddBuff(26, 10800, false);

                    return true;
                }
                return false;
            }

            public override void AddRecipes()
			{
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(ItemID.DirtBlock);
				recipe.SetResult(this, 99);
				recipe.AddRecipe();
			}
        }
    }