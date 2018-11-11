using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TestMod.Tiles
{
	public class SmoothStone : ModTile
	{
		
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = false;
			Main.tileLighted[Type] = false;
			drop = mod.ItemType("SmoothStone");
			AddMapEntry(new Color(154, 154, 154));
			// Set other values here
		}
	}
}