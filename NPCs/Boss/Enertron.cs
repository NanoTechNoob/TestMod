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
    public class Enertron : ModNPC
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Enertron");
            NPCID.Sets.MustAlwaysDraw[npc.type] = true;
        }
        public override void SetDefaults()
        {
            npc.lifeMax = 2500;   //boss life
            npc.damage = 100;  //boss damage
            npc.defense = 10000;    //boss defense
            npc.knockBackResist = 0f;
            npc.width = 96;
            npc.height = 75;
            animationType = NPCID.DemonEye;   //this boss will behavior like the DemonEye
            Main.npcFrameCount[npc.type] = 2;    //boss frame/animation 
            npc.value = Item.buyPrice(0, 10, 0, 0);
            npc.npcSlots = 1f;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.buffImmune[24] = true;
            music = MusicID.Boss2;
            npc.netAlways = true;
        }
        
        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.HealingPotion;   //boss drops
        }

        public override void AI()
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

            if(npc.life >= npc.lifeMax / 5)
            {
                npc.ai[1]++;
                if (npc.ai[1] == 15) //fire rate
                {
                    float Speed = 12f;  //projectile speed
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                    int damage = 25;  //projectile damage
                    int type = mod.ProjectileType("TeslaBall");
                    float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f)));
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0, 0);
                    npc.life += -25;
                }
                else if (npc.ai[1] == 30)
                {
                    float Speed = 12f;  //projectile speed
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                    int damage = 25;  //projectile damage
                    int type = mod.ProjectileType("TeslaBall");
                    float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f)));
                    int num55 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation + 25) * Speed) * -1), (float)((Math.Sin(rotation + 25) * Speed) * -1), type, damage, 0, 0);
                    int num57 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation -25) * Speed) * -1), (float)((Math.Sin(rotation - 25) * Speed) * -1), type, damage, 0, 0);
                    npc.life += -25;
                }
                else if (npc.ai[1] == 45)
                {
                    float Speed = 12f;  //projectile speed
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                    int damage = 25;  //projectile damage
                    int type = mod.ProjectileType("TeslaBall");
                    float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f)));
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0, 0);
                    int num56 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation + 50) * Speed) * -1), (float)((Math.Sin(rotation + 50) * Speed) * -1), type, damage, 0, 0);
                    int num58 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation - 50) * Speed) * -1), (float)((Math.Sin(rotation - 50) * Speed) * -1), type, damage, 0, 0);
                    npc.life += -25;
                }
                else if (npc.ai[1] == 60)
                {
                    float Speed = 12f;  //projectile speed
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                    int damage = 25;  //projectile damage
                    int type = mod.ProjectileType("TeslaBall");
                    float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f)));
                    int num55 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation + 25) * Speed) * -1), (float)((Math.Sin(rotation + 25) * Speed) * -1), type, damage, 0, 0);
                    int num57 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation -25) * Speed) * -1), (float)((Math.Sin(rotation - 25) * Speed) * -1), type, damage, 0, 0);
                    npc.ai[1] = 0;
                    npc.life += -25;
                }
            }
            else if(npc.life <= npc.lifeMax / 5)
            {
                npc.ai[1]++;
                if (npc.ai[1] >= 6) //fire rate
                {
                    float Speed = 10f;  //projectile speed
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                    int damage = 10;  //projectile damage
                    int type = mod.ProjectileType("TeslaBall");
                    float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f)));
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0, 0);
                    int num56 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation + 50) * Speed) * -1), (float)((Math.Sin(rotation + 50) * Speed) * -1), type, damage, 0, 0);
                    int num58 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation -50) * Speed) * -1), (float)((Math.Sin(rotation - 50) * Speed) * -1), type, damage, 0, 0);
                    npc.ai[1] = 0;
                }
            }
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            Dust.NewDust(npc.position, npc.width, npc.height, 11);
            Dust.NewDust(npc.position, npc.width, npc.height, 105);
            if (npc.life <= 0)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, 11);
                Dust.NewDust(npc.position, npc.width, npc.height, 11);
                Dust.NewDust(npc.position, npc.width, npc.height, 105);
                Dust.NewDust(npc.position, npc.width, npc.height, 105);
            }
        }
    }
}