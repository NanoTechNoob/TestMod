using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TestMod.Items.Accessories
{
	public class ThiefsMask : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.value = 10000;
			item.rare = 2;
			item.accessory = true;
			item.defense = 5;
			item.lifeRegen = 0;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
				player.meleeSpeed += 0.5f;
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