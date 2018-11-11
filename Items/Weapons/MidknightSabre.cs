using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace TestMod.Items.Weapons
{
	public class MidknightSabre : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Midknight Sabre");
			Tooltip.SetDefault("");
		}
		public override void SetDefaults()
		{
			item.damage = 70;
			item.crit = 11;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = 1000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			int lifeSteal = damage / 3;
			player.statLife += lifeSteal;
			player.HealEffect(lifeSteal);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.GetItem("KnightSabre"));
			recipe.AddIngredient(ItemID.Muramasa);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}