using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using TestMod.Projectiles;

namespace TestMod.Items.Weapons
{
	public class Sokolyumi : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sokolyumi");
			Tooltip.SetDefault("");
		}

		public override void SetDefaults()
		{
			item.damage = 40;
			item.crit = 0;
			item.ranged = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 0;
			item.value = 1000;
			item.rare = 2;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shoot = 10;
			item.shootSpeed = 25f;
			item.useAmmo = AmmoID.Arrow;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
            if (type == ProjectileID.WoodenArrowFriendly)
			{
				type = ProjectileID.BoneArrow;
			    float numberProjectiles = 3;
		    	float rotation = MathHelper.ToRadians(5);
		    	position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
		    	for (int i = 0; i < numberProjectiles; i++)
		    	{
				    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 1f;
			    	Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
		    	}
			}
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}