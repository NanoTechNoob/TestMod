using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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

        public override void AI()
        {
            npc.ai[0]++;
                Player P = Main.player[npc.target];
                if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
                {
                    npc.TargetClosest(true);
                }
                npc.netUpdate = true;

                npc.ai[1]++;
                if (npc.ai[1] >= 270)
                {
                    float Speed3 = 1f;
                    int damage3 = 10;
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                    float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f)));
                    int type3 = mod.ProjectileType("ProNut3");
                    int num59 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed3) * -1), (float)((Math.Sin(rotation) * Speed3) * -1), type3, damage3, -4f, 0);
                    npc.ai[1] = 0;
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