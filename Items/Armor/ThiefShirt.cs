using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TestMod.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class ThiefShirt : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Thief Shirt");
			Tooltip.SetDefault("Increases melee damage by 10%");
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
			return legs.type == mod.ItemType("ThiefPants") && head.type == mod.ItemType("ThiefHeadware");
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.05f;
		}

        public override void UpdateArmorSet(Player player)
		{
			player.meleeSpeed += 0.10f;
            player.setBonus = "Increases melee speed by 10%";
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