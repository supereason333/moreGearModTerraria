using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.CodeAnalysis;

namespace moreGearMod.Projectiles.Spears
{
	public class PitchforkProjectile : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.width = 6;  // set width when i make sprite
			Projectile.height = 6;
			Projectile.aiStyle = 19;
			Projectile.penetrate = -1;
			Projectile.scale = 1f;
			Projectile.alpha = 0;

			Projectile.hide = true;
			Projectile.ownerHitCheck = true;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.tileCollide = false;
			Projectile.friendly = true;
		}
		float movement = 1;
		float movementOffset = 1.26f;

		public override void AI()
		{
			Player projOwner = Main.player[Projectile.owner];

			if (projOwner.itemAnimation >= projOwner.itemAnimationMax / 2)
			{
				Projectile.position += Projectile.velocity * movement;
				movement *= movementOffset;
			}
			else
			{
				Projectile.position += Projectile.velocity * movement;
				movement /= movementOffset;
			}
			if (projOwner.itemAnimation == 0) Projectile.Kill();
		}
	}
}
