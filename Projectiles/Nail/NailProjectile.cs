using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
namespace moreGearMod.Projectiles.Nail
{
	public class NailProjectile : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.DamageType = DamageClass.Melee;
			Projectile.width = 30;
			Projectile.height = 10;
			Projectile.aiStyle = 19;

			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 15;
			Projectile.light = 0.1f;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.scale = 1f;
			Projectile.alpha = 50;
		}

        public override bool PreAI()
        {
            Player projOwner = Main.player[Projectile.owner];
			Projectile.position = projOwner.MountedCenter + Projectile.velocity * 70;
			Projectile.rotation = Projectile.velocity.ToRotation() + 90;

			if (Projectile.alpha > 10) Projectile.alpha -= 10;
            return false;
        }
    }
}