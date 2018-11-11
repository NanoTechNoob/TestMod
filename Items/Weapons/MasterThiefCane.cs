using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace TestMod.Items.Weapons
{
	public class MasterThiefCane : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Master Thief Cane");
			Tooltip.SetDefault("Pick your enemy's pockets. Enemies will drop more coins when killed.");
		}
		public override void SetDefaults()
		{			
			item.damage = 25;
			item.crit = 2;
			item.melee = true;
			item.width = 64;
			item.height = 64;
			item.useTime = 35;
			item.useAnimation = 35;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = 15000;
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Midas, 60);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("BrokenCane"));
			recipe.AddIngredient(mod.ItemType("Token"), 15);
			recipe.AddIngredient(ItemID.Wood, 25);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}