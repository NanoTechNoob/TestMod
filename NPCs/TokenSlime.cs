using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Utilities;

namespace TestMod.NPCs
{
    public class TokenSlime : ModNPC
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Token Slime");
        }

        public override void SetDefaults()
        {
            if(!NPC.downedPlantBoss)
            {
                npc.alpha = 100;
                npc.width = 32;
                npc.height = 24;
                npc.damage = 12;
                npc.defense = 5;
                npc.lifeMax = 120;
                npc.HitSound = SoundID.NPCHit1;
                npc.DeathSound = SoundID.NPCDeath1;
                npc.value = 60f;
                npc.knockBackResist = 0.5f;
                npc.aiStyle = 1;
                aiType = NPCID.GreenSlime;
                animationType = NPCID.GreenSlime;
                Main.npcFrameCount[npc.type] = 2;
            }
            else
            {
                npc.alpha = 100;
                npc.width = 32;
                npc.height = 24;
                npc.damage = 118;
                npc.defense = 5;
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
            banner = Item.NPCtoBanner(NPCID.BlueSlime);
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if(NPC.downedBoss1 && Main.dayTime || NPC.downedSlimeKing && Main.dayTime)
            {
                return SpawnCondition.OverworldDaySlime.Chance * 0.25f;
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
            Dust.NewDust(npc.position, npc.width, npc.height, 80);
            Dust.NewDust(npc.position, npc.width, npc.height, 80);
            Dust.NewDust(npc.position, npc.width, npc.height, 80);
            Dust.NewDust(npc.position, npc.width, npc.height, 80);
            Dust.NewDust(npc.position, npc.width, npc.height, 80);
            if (npc.life <= 0)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, 80);
                Dust.NewDust(npc.position, npc.width, npc.height, 80);
                Dust.NewDust(npc.position, npc.width, npc.height, 80);
                Dust.NewDust(npc.position, npc.width, npc.height, 80);
                Dust.NewDust(npc.position, npc.width, npc.height, 80);
            }
        }

        public override void NPCLoot()
        {
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Token"));
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Gel);
                if(Main.rand.NextFloat() < .014f)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SlimeStaff);
                }
            }

        }
    }
}