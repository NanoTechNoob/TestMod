using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using TestMod.Projectiles;
namespace TestMod.Items.Weapons
{
	public class TeslaClaw : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tesla Claw");
			Tooltip.SetDefault("80% chance not to comsume ammo");
		}
		public override void SetDefaults()
		{
			item.damage = 5;
			item.crit = 21;
			item.ranged = true;
			item.width = 10;
			item.height = 10;
			item.useTime = 2;
			item.useAnimation = 2;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 0;
			item.value = 1000;
			item.rare = 2;
			item.autoReuse = true;
            item.UseSound = new Terraria.Audio.LegacySoundStyle(2, 12);
			item.shoot = mod.ProjectileType("TeslaBolt");
			item.shootSpeed = 10f;
			item.useAmmo = mod.ItemType("TeslaBolt");
		}

        public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() >= .80f;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{  
			    int numberProjectiles = 1;
			    for (int i = 0; i < numberProjectiles; i++)
                {
				    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(3));
				    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			    }
			return false;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-4, 0);
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