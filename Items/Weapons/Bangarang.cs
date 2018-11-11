using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using TestMod.Projectiles;

namespace TestMod.Items.Weapons
{
	public class Bangarang : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("When ammo is low, just right-click to throw.");
		}

		public override void SetDefaults()
		{
			item.width = 92;
			item.height = 60;
			item.useTime = 20;
			item.useAnimation = 5;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = 2;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IllegalGunParts);
			recipe.AddIngredient(ItemID.WoodenBoomerang);
			recipe.AddIngredient(mod.ItemType("Token"), 15);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				item.noUseGraphic = true;
				item.UseSound = SoundID.Item1;
				item.useStyle = 1;
				item.ranged = true;
				item.melee = false;
				item.useTime = 20;
				item.useAnimation = 20;
				item.damage = 34;
				item.shootSpeed = 12f;
				item.shoot = mod.ProjectileType<BangarangProjectile>();
				return player.ownedProjectileCounts[item.shoot] < 1; 
			}
			else
			{
				item.noUseGraphic = false;
				item.UseSound = SoundID.Item11;
				item.useStyle = 5;
				item.ranged = true;
				item.melee = false;
				item.useTime = 40;
				item.useAnimation = 40;
				item.damage = 17;
				item.shoot = 14;
				item.shootSpeed = 25f;
			}
			return base.CanUseItem(player);
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if(player.altFunctionUse != 2)
			{
				int numberProjectiles = 4 + Main.rand.Next(2);
				for (int i = 0; i < numberProjectiles; i++)
				{
					Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15));
					Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
				}
			}
			return true;
		}
	}
}