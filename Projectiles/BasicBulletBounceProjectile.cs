using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace moreGearMod.Projectiles
{
	public class BasicBulletBounceProjectile : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.width = 4;
			Projectile.height = 10;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 800;
			Projectile.light = 0f;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = true;
			Projectile.scale =0.7f;
			Projectile.extraUpdates = 1;
		}

		int bounce = 0;
		int maxBounce = 3;
        public override void AI()
        {
			Projectile.aiStyle = 0;
			Lighting.AddLight(Projectile.position, 0.2f, 0.2f, 0.2f);
			Lighting.Brightness(1, 1);
			base.AI();
        }
        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
			for (int i = 0; i <= 4; i++)
			{
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 0, default(Color), 1f);
			}
        }
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			bounce++;
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
            for (int i = 0; i <= 4; i++)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 0, default(Color), 1f);
            }
			if(Projectile.velocity.X != oldVelocity.X) Projectile.velocity.X = -oldVelocity.X;
			if(Projectile.velocity.Y != oldVelocity.Y) Projectile.velocity.Y = -oldVelocity.Y;
			Projectile.aiStyle = 1;
			if (bounce >= maxBounce) return true;
			else return false;
        }
    }
}