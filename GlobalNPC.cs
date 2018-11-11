using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Utilities;

class MyGlobalNPC : GlobalNPC
{

	public override void NPCLoot(NPC npc)
	{
		if (Main.rand.NextFloat() < .025f && npc.lifeMax > 5){
			if(npc.type != mod.NPCType("TokenSlime"))
			{
				if(npc.type != mod.NPCType("AmmoSlime"))
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Token"));
				}
			}
		}

		if (Main.rand.NextFloat() < .0125f && NPC.downedBoss1 && npc.lifeMax > 5 || Main.rand.NextFloat() < .0125f && NPC.downedSlimeKing && npc.lifeMax > 5)
		{
			if(npc.type != mod.NPCType("TokenSlime"))
			{
				if(npc.type != mod.NPCType("AmmoSlime"))
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AmmoPack"));
				}
			}
		}
		
		if(npc.type == NPCID.BlueJellyfish && Main.rand.NextFloat() < .05f || npc.type == NPCID.PinkJellyfish && Main.rand.NextFloat() < .05f || npc.type == NPCID.GreenJellyfish && Main.rand.NextFloat() < .05f)
		{
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BubbleWand"));
		}

		if(npc.type == NPCID.GoblinThief && Main.rand.NextFloat() < .01f)
		{
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ThiefsMask"));
		}

		if(npc.type == NPCID.Shark && Main.rand.NextFloat() < .1f)
		{
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("NeptunesTrident"));
		}

		if(npc.type == NPCID.MeteorHead && Main.rand.NextFloat() < .025f)
		{
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BrokenGunPiece"));
		}

		if(npc.type == NPCID.FireImp && Main.rand.NextFloat() < .05f)
		{
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BrokenGunPiece"));
		}

		if(npc.type == NPCID.EyeofCthulhu && Main.rand.NextFloat() < .10f)
		{
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Sasha"));
		}
	}
}