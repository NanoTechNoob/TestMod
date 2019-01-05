using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Utilities;

namespace TestMod.NPCs
{
    public class AmmoSlime : ModNPC
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ammo Slime");
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
                npc.knockBackResist = .05f;
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
            banner = Item.NPCtoBanner(NPCID.GreenSlime);
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if(NPC.downedBoss1 && NPC.downedSlimeKing && Main.dayTime)
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
            Dust.NewDust(npc.position, npc.width, npc.height, 3);
            Dust.NewDust(npc.position, npc.width, npc.height, 3);
            Dust.NewDust(npc.position, npc.width, npc.height, 3);
            Dust.NewDust(npc.position, npc.width, npc.height, 3);
            Dust.NewDust(npc.position, npc.width, npc.height, 3);
            if (npc.life <= 0)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, 3);
                Dust.NewDust(npc.position, npc.width, npc.height, 3);
                Dust.NewDust(npc.position, npc.width, npc.height, 3);
                Dust.NewDust(npc.position, npc.width, npc.height, 3);
                Dust.NewDust(npc.position, npc.width, npc.height, 3);
            }
        }

        public override void NPCLoot()
        {
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AmmoPack"));
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Gel);
                if(Main.rand.NextFloat() < .014f)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SlimeStaff);
                }
            }
        }
    }
}