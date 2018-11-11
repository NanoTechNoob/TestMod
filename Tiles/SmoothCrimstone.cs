using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TestMod.Tiles
{
	public class SmoothCrimstone : ModTile
	{
		
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = false;
			Main.tileBlockLight[Type] = false;
			Main.tileLighted[Type] = false;
			drop = mod.ItemType("SmoothCrimstone");
			AddMapEntry(new Color(211, 0, 0));
			// Set other values here
		}
	}
}