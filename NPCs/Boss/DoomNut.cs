using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace TestMod.NPCs.Boss
{
    [AutoloadBossHead]
    public class DoomNut : ModNPC
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Doom Nut");
            NPCID.Sets.MustAlwaysDraw[npc.type] = true;
        }
        public override void SetDefaults()
        {
            npc.lifeMax = 4000;   //boss life
            npc.damage = 20;  //boss damage
            npc.defense = 10;    //boss defense
            npc.knockBackResist = 0f;
            npc.width = 100;
            npc.height = 100;
            animationType = NPCID.DemonEye;   //this boss will behavior like the DemonEye
            Main.npcFrameCount[npc.type] = 2;    //boss frame/animation 
            npc.value = Item.buyPrice(0, 10, 0, 0);
            npc.npcSlots = 1f;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.buffImmune[24] = true;
            music = MusicID.Boss2;
            npc.netAlways = true;
        }
        
        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.HealingPotion;   //boss drops
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            //npc.lifeMax = (int)(npc.lifeMax * 0.579f * bossLifeScale);  //boss life scale in expertmode
            npc.damage = (int)(npc.damage * 0.6f);  //boss damage increase in expermode
        }
        public override void AI()
        {
            if(npc.life >= npc.lifeMax / 2)
            {
                npc.noGravity = true;
                npc.noTileCollide = true;
                npc.aiStyle = 5;
                npc.ai[0]++;
                Player P = Main.player[npc.target];
                if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
                {
                    npc.TargetClosest(true);
                }
                npc.netUpdate = true;

                npc.ai[1]++;
                if (npc.ai[1] >= 120)  // 230 is projectile fire rate
                {
                    float Speed = 10f;  //projectile speed
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                    int damage = 10;  //projectile damage
                    int type = mod.ProjectileType("ProNut");  //put your projectile
                    float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f)));
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                    int num55 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation + 25) * Speed) * -1), (float)((Math.Sin(rotation + 25) * Speed) * -1), type, damage, 0f, 0);
                    int num56 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation + 50) * Speed) * -1), (float)((Math.Sin(rotation + 50) * Speed) * -1), type, damage, 0f, 0);
                    int num57 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation -25) * Speed) * -1), (float)((Math.Sin(rotation - 25) * Speed) * -1), type, damage, 0f, 0);
                    int num58 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation -50) * Speed) * -1), (float)((Math.Sin(rotation - 50) * Speed) * -1), type, damage, 0f, 0);
                    npc.ai[1] = 0;
                }
            }
            else if(npc.life <= npc.lifeMax / 2)
            {
                npc.noGravity = false;
                npc.noTileCollide = false;
                npc.aiStyle = 0;
                npc.ai[0]++;
                Player P = Main.player[npc.target];
                if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
                {
                    npc.TargetClosest(true);
                }
                npc.netUpdate = true;

                npc.ai[1]++;
                if (npc.ai[1] >= 45)  //projectile fire rate
                {
                    float Speed = 5f;  //projectile speed
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                    int damage = 10;  //projectile damage
                    int type = mod.ProjectileType("ProNut2");  //put your projectile
                    float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f)));
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                    int num56 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation + 50) * Speed) * -1), (float)((Math.Sin(rotation + 50) * Speed) * -1), type, damage, 0f, 0);
                    int num58 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation -50) * Speed) * -1), (float)((Math.Sin(rotation - 50) * Speed) * -1), type, damage, 0f, 0);
                    npc.ai[1] = 0;
                }
            }
            if (npc.ai[0] % 300 == 3)  //Npc spawn rate

            {
                NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("Doomlette"));
            }
        }
    }
}