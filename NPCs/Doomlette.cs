using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Utilities;

namespace TestMod.NPCs
{
    public class Doomlette : ModNPC
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Doomlette");
        }

        public override void SetDefaults()
        {
            {
                npc.width = 32;
                npc.height = 32;
                npc.damage = 15;
                npc.defense = 0;
                npc.lifeMax = 25;
                npc.HitSound = SoundID.NPCHit1;
                npc.DeathSound = SoundID.NPCDeath1;
                npc.value = 0f;
                npc.knockBackResist = .05f;
                npc.aiStyle = 1;
                aiType = NPCID.GreenSlime;
                animationType = NPCID.GreenSlime;
                Main.npcFrameCount[npc.type] = 2;
            }
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter -= 0.25F;
            npc.frameCounter %= 4;
            int frame = (int)(npc.frameCounter / 2.0) + 1;
            npc.frame.Y = frame * frameHeight;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            Dust.NewDust(npc.position, npc.width, npc.height, 22);
            Dust.NewDust(npc.position, npc.width, npc.height, 22);
            if (npc.life <= 0)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, 22);
                Dust.NewDust(npc.position, npc.width, npc.height, 22);
                Dust.NewDust(npc.position, npc.width, npc.height, 22);
            }
        }
    }
}