using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
namespace moreGearMod.Projectiles
{
	public class GlowSwordProjectile : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.DamageType = DamageClass.Melee;
			Projectile.width = 30;
			Projectile.height = 10;
			Projectile.aiStyle = 0;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.penetrate = 100;
			Projectile.timeLeft = 30;
			Projectile.light = 1f;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.scale =1f;
		}
		int frameAmount = 4;
        public override void AI()
        {
			frameAmount++;
			if (frameAmount > 5)
			{
			int dust = Dust.NewDust(Projectile.Center, 1, 1, DustID.SolarFlare, 0f, 0f, 0, default(Color), 1f);
			Main.dust[dust].velocity *= 0.8f;
			Main.dust[dust].scale = (float)Main.rand.Next(80, 115) * 0.013f;
			Main.dust[dust].noGravity = true;
			frameAmount = 0;
			}

        }
        public override void OnSpawn(IEntitySource source)
        {
			Projectile.rotation = (float)Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X);
        }
    }
}