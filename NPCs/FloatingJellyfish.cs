using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Utilities;

namespace TestMod.NPCs
{
    public class FloatingJellyfish : ModNPC
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Floating Jellyfish");
        }

        public override void SetDefaults()
        {
            npc.width = 28;
            npc.height = 34;
            npc.damage = 45;
            npc.defense = 6;
            npc.lifeMax = 250;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 60f;
            npc.knockBackResist = .005f;
            npc.aiStyle = 2;
            aiType = NPCID.DemonEye;
            animationType = NPCID.Wraith;
            Main.npcFrameCount[npc.type] = 2;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if(!Main.dayTime && NPC.downedBoss2)
            {
                return SpawnCondition.OverworldNightMonster.Chance * 0.1f;
            }
            return 0;
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter -= 0.75F;
            npc.frameCounter %= 4;
            int frame = (int)(npc.frameCounter / 2.0);
            npc.frame.Y = frame * frameHeight;

            npc.spriteDirection = npc.direction;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            Dust.NewDust(npc.position, npc.width, npc.height, 243);
            Dust.NewDust(npc.position, npc.width, npc.height, 243);
            if (npc.life <= 0)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, 243);
                Dust.NewDust(npc.position, npc.width, npc.height, 243);
                Dust.NewDust(npc.position, npc.width, npc.height, 243);
            }
        }

        public override void NPCLoot()
        {
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Glowstick);
                if(Main.rand.NextFloat() < .05f)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BrokenClawPiece"));
                }
            }

        }
    }
}