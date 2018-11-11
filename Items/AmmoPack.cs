using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
    
    namespace TestMod.Items
    {
        public class AmmoPack : ModItem
        {
            public override void SetStaticDefaults()
            {
				DisplayName.SetDefault("Ammo Pack");
                Tooltip.SetDefault("Right-Click to open.");
            }

            public override void SetDefaults()
            {
                item.width = 16;
                item.height = 16;
                item.maxStack = 999;
                item.value = Item.sellPrice(0, 0, 0, 0);
                item.rare = 1;
            }

            public override bool CanRightClick()
		{
			return true;
		}

            public override void RightClick(Player player)
	    	{
                int choice = Main.rand.Next(7);
                if (choice == 0)
                {
                    int choice0 = Main.rand.Next(7);
                    if (choice0 == 0)
                    {
		        	player.QuickSpawnItem(mod.ItemType("BioticBullet"), 25);
                    }

                    else if (choice0 == 1)
                    {
		        	player.QuickSpawnItem(mod.ItemType("BioticBullet"), 15);
                    }

                    else if (choice0 != 1)
                    {
		        	player.QuickSpawnItem(mod.ItemType("BioticBullet"), 10);
                    }
                }

                else if (choice == 1)
                {
                    int choice1 = Main.rand.Next(7);
                    if (choice1 == 0)
                    {
		        	player.QuickSpawnItem(mod.ItemType("TeslaBolt"), 50);
                    }

                    else if (choice1 == 1)
                    {
		        	player.QuickSpawnItem(mod.ItemType("TeslaBolt"), 30);
                    }

                    else if (choice1 != 1)
                    {
		        	player.QuickSpawnItem(mod.ItemType("TeslaBolt"), 20);
                    }
                }

                if (choice == 2)
                {
                    int choice2 = Main.rand.Next(7);
                    if (choice2 == 0)
                    {
		        	player.QuickSpawnItem(mod.ItemType("PulseMunition"), 25);
                    }

                    else if (choice2 == 1)
                    {
		        	player.QuickSpawnItem(mod.ItemType("PulseMunition"), 15);
                    }

                    else if (choice2 != 1)
                    {
		        	player.QuickSpawnItem(mod.ItemType("PulseMunition"), 10);
                    }
                }

                else if (choice != 1 && choice != 2)
                {
                    int choice3 = Main.rand.Next(7);
                    if (choice3 == 0)
                    {
                    player.QuickSpawnItem(mod.ItemType("Token"));
                    }

                    if (choice3 == 1)
                    {
                    player.QuickSpawnItem(ItemID.MusketBall, 25);
                    }

                    if (choice3 != 1)
                    {
                    player.QuickSpawnItem(ItemID.SilverCoin, 25);
                    }
                }
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