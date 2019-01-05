using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;

namespace TestMod.NPCs
{
    public class Bit : ModNPC
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bit");
        }

        public override void SetDefaults()
        {

            npc.width = 16;
            npc.height = 16;
            npc.damage = 30;
            npc.defense = 6;
            npc.lifeMax = 50;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 60f;
            npc.knockBackResist = .05f;
            npc.aiStyle = 3;
            animationType = 3;
            Main.npcFrameCount[npc.type] = 4;
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
    }
}