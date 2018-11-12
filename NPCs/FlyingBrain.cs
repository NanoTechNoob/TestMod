using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Utilities;

namespace TestMod.NPCs
{
    public class FlyingBrain : ModNPC
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flying Brain");
        }

        public override void SetDefaults()
        {
            npc.width = 64;
            npc.height = 52;
            npc.damage = 45;
            npc.defense = 6;
            npc.lifeMax = 250;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 60f;
            npc.knockBackResist = .005f;
            npc.aiStyle = NPCID.DemonEye;
            aiType = NPCID.DemonEye;
            animationType = NPCID.Wraith;
            Main.npcFrameCount[npc.type] = 4;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if(!Main.dayTime && NPC.downedBoss2)
            {
                return SpawnCondition.OverworldNightMonster.Chance * 0.1f;
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
    }
}