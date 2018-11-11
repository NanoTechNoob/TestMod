using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TestMod.Tiles
{
	public class SmoothEbonstone : ModTile
	{
		
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = false;
			Main.tileBlockLight[Type] = false;
			Main.tileLighted[Type] = false;
			drop = mod.ItemType("SmoothEbonstone");
			AddMapEntry(new Color(87, 0, 127));
			// Set other values here
		}
	}
}