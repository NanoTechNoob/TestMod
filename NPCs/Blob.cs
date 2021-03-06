using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Utilities;

namespace TestMod.NPCs
{
    public class Blob : ModNPC
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blob");
        }

        public override void SetDefaults()
        {
            if(!NPC.downedPlantBoss)
            {
                npc.alpha = 100;
                npc.width = 64;
                npc.height = 64;
                npc.damage = 24;
                npc.defense = 6;
                npc.lifeMax = 120;
                npc.HitSound = SoundID.NPCHit1;
                npc.DeathSound = SoundID.NPCDeath1;
                npc.value = 60f;
                npc.knockBackResist = .05f;
                npc.aiStyle = 1;
                aiType = NPCID.GreenSlime;
                animationType = NPCID.GreenSlime;
                Main.npcFrameCount[npc.type] = 2;
            }
            else
            {
                npc.alpha = 25;
                npc.width = 64;
                npc.height = 64;
                npc.damage = 64;
                npc.defense = 18;
                npc.lifeMax = 260;
                npc.HitSound = SoundID.NPCHit1;
                npc.DeathSound = SoundID.NPCDeath1;
                npc.value = 60f;
                npc.knockBackResist = .05f;
                npc.aiStyle = 1;
                aiType = NPCID.GreenSlime;
                animationType = NPCID.GreenSlime;
                Main.npcFrameCount[npc.type] = 2;
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if(NPC.downedBoss1 && Main.dayTime)
            {
                return SpawnCondition.OverworldDaySlime.Chance * .0001f;
            }
            return 0;
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
            Dust.NewDust(npc.position, npc.width, npc.height, 3);
            Dust.NewDust(npc.position, npc.width, npc.height, 3);
            if (npc.life <= 0)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, 3);
                Dust.NewDust(npc.position, npc.width, npc.height, 3);
                Dust.NewDust(npc.position, npc.width, npc.height, 3);
            }
        }

        public override void NPCLoot()
        {
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Gel, 5);
                if(Main.rand.NextFloat() < .25f)
                {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SlimeStaff);
                }
            }
        }
    }
}