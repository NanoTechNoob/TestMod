using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
    
    namespace TestMod.Items
    {
        public class BrokenClawPiece : ModItem
        {
            public override void SetStaticDefaults()
            {
				DisplayName.SetDefault("Broken Claw Piece");
                Tooltip.SetDefault("");
            }
    
            public override void SetDefaults()
            {
                item.width = 16;
                item.height = 16;
                item.maxStack = 999;
                item.value = Item.sellPrice(0, 0, 2, 50);
                item.rare = 1;
            }
        }
    }