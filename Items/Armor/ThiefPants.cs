using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TestMod.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class ThiefPants : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Thief Pants");
			Tooltip.SetDefault("Increases melee critical strike chance by 10%");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 2;
			item.defense = 30;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("ThiefShirt") && head.type == mod.ItemType("ThiefHeadware");
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeCrit += 10;
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