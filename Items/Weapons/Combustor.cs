using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace TestMod.Items.Weapons
{
	public class Combustor : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Combustor");
			Tooltip.SetDefault("");
		}
		
		public override void SetDefaults()
		{
			item.damage = 15;
			item.crit = 2;
			item.ranged = true;
			item.width = 10;
			item.height = 10;
			item.useTime = 40;
			item.useAnimation = 39;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 0;
			item.value = 1000;
			item.rare = 2;
			item.autoReuse = true;
			item.shoot = 30;
			item.shootSpeed = 10f;
			item.useAmmo = AmmoID.Bullet;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (type == ProjectileID.Bullet)
			{
				type = 664;
			}
			return true;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-2, 0);
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("BrokenGunPiece"));
			recipe.AddIngredient(mod.ItemType("Token"), 15);
			recipe.AddIngredient(ItemID.HellstoneBar, 5);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}