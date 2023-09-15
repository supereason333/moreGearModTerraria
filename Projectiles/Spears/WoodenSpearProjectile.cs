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
	public class WoodenSpearProjectile : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.width = 60;  // set width when i make sprite
			Projectile.height = 20;
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
		float projAnim = 0;
		float projPosFac = 20;
		float projMoveSpd = 4f;
		float holdOffset = 10;

		public override bool PreAI()
		{
			Player projOwner = Main.player[Projectile.owner];
			projAnim++;

			projOwner.heldProj = Projectile.whoAmI;

			if (projAnim <= projOwner.itemAnimationMax / 2)
			{
				projPosFac += projMoveSpd;
			}
			else
			{
				projPosFac -= projMoveSpd;
			}

            Projectile.position = projOwner.MountedCenter - new Vector2(25, 15) + Projectile.velocity * projPosFac;// + new Vector2(holdOffset * (float)Math.Sin(Projectile.velocity.ToRotation()), holdOffset * (float)Math.Cos(Projectile.velocity.ToRotation()));
			Projectile.rotation = Projectile.velocity.ToRotation();														// ^ side offset code

			if (projAnim >= projOwner.itemAnimationMax) Projectile.Kill();

			return false;
		}
    }
}