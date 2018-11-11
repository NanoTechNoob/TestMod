using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using TestMod.Projectiles;

namespace TestMod.Items.Weapons
{
	public class BlackBox : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Black Box");
			Tooltip.SetDefault("");
		}
		public override void SetDefaults()
		{
			item.damage = 15;
			item.crit = 5;
			item.ranged = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 40;
			item.useAnimation = 40;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 0;
			item.value = 1000;
			item.rare = 2;
			item.UseSound = SoundID.Item11;
			item.autoReuse = false;
			item.shoot = 10;
			item.shootSpeed = 25f;
			item.useAmmo = AmmoID.Bullet;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (type == ProjectileID.Bullet)
			{
				type = ProjectileID.RocketI;
			}
			return true;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-12, 0);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IllegalGunParts, 5);
			recipe.AddIngredient(ItemID.Bomb, 99);
			recipe.AddIngredient(mod.ItemType("Token"), 15);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}