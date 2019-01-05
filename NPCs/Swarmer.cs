using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Utilities;

namespace TestMod.NPCs
{
    public class Swarmer : ModNPC
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Swarmer");
        }

        public override void SetDefaults()
        {
            if(!NPC.downedPlantBoss)
            {
                npc.alpha = 100;
                npc.width = 44;
                npc.height = 28;
                npc.damage = 24;
                npc.defense = 6;
                npc.lifeMax = 250;
                npc.HitSound = SoundID.NPCHit1;
                npc.DeathSound = SoundID.NPCDeath1;
                npc.value = 60f;
                npc.knockBackResist = .05f;
                npc.aiStyle = 1;
                aiType = NPCID.GreenSlime;
                animationType = NPCID.GreenSlime;
                Main.npcFrameCount[npc.type] = 2;
                banner = Item.NPCtoBanner(NPCID.PurpleSlime);
            }
            else
            {
                npc.alpha = 100;
                npc.width = 44;
                npc.height = 28;
                npc.damage = 64;
                npc.defense = 18;
                npc.lifeMax = 350;
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
                return SpawnCondition.OverworldDaySlime.Chance * .1f;
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
            Dust.NewDust(npc.position, npc.width, npc.height, 13);
            Dust.NewDust(npc.position, npc.width, npc.height, 13);
            Dust.NewDust(npc.position, npc.width, npc.height, 13);
            Dust.NewDust(npc.position, npc.width, npc.height, 13);
            Dust.NewDust(npc.position, npc.width, npc.height, 13);
            if (npc.life <= 0)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, 13);
                Dust.NewDust(npc.position, npc.width, npc.height, 13);
                Dust.NewDust(npc.position, npc.width, npc.height, 13);
                Dust.NewDust(npc.position, npc.width, npc.height, 13);
                Dust.NewDust(npc.position, npc.width, npc.height, 13);
                int number = NPC.NewNPC((int) npc.position.X, (int) npc.position.Y, 1, 0, 0.0f, 0.0f, 0.0f, 0.0f, (int) byte.MaxValue);
                NPC.NewNPC((int) npc.position.X + 25, (int) npc.position.Y - 25, 1, 0, 0.0f, 0.0f, 0.0f, 0.0f, (int) byte.MaxValue);
                NPC.NewNPC((int) npc.position.X - 25, (int) npc.position.Y + 25, 1, 0, 0.0f, 0.0f, 0.0f, 0.0f, (int) byte.MaxValue);
                NPC.NewNPC((int) npc.position.X + 10, (int) npc.position.Y + 10, -3, 0, 0.0f, 0.0f, 0.0f, 0.0f, (int) byte.MaxValue);
                NPC.NewNPC((int) npc.position.X - 10, (int) npc.position.Y - 10, -3, 0, 0.0f, 0.0f, 0.0f, 0.0f, (int) byte.MaxValue);
            }
        }

        public override void NPCLoot()
        {
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Gel);
                if(Main.rand.NextFloat() < .014f)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SlimeStaff);
                }
            }
        }
    }
}