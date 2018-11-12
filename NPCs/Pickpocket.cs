using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TestMod.NPCs
{
    public class Pickpocket : ModNPC
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pickpocket");
        }

        public override void SetDefaults()
        {
            npc.width = 30;
            npc.height = 40;
            npc.damage = 30;
            npc.defense = 6;
            npc.lifeMax = 200;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 60f;
            npc.knockBackResist = .05f;
            npc.aiStyle = 3;
            animationType = 3;
            Main.npcFrameCount[npc.type] = 4;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if(!Main.dayTime && NPC.downedBoss2)
            {
                return SpawnCondition.OverworldNightMonster.Chance * .1f;
            }
            return 0;
        }

        const int frame = 1;

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.001;
            if (npc.frameCounter >= 200)
			{
            npc.frame.Y = frame * frameHeight;
            }
            else if (npc.frameCounter >= 400)
			{
            npc.frame.Y = frame * (frameHeight * 2);
            }
            else if (npc.frameCounter >= 600)
			{
            npc.frame.Y = frame * (frameHeight * 3);
            }
            else if (npc.frameCounter >= 800)
			{
            npc.frame.Y = frame * (frameHeight * 4);
            npc.frameCounter = 0;
            }
            npc.spriteDirection = npc.direction;
        }

        public override void NPCLoot()
        {
            {
                if(Main.rand.NextFloat() < .05f)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BrokenCane"));
                }
            }
        }
    }
}