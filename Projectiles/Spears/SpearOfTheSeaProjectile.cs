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
	public class SpearOfTheSeaProjectile : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.width = 90;  // set width when i make sprite
			Projectile.height = 30;
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
		float projPosFac = 0;
		float projMoveSpd = 7f;
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

            Projectile.position = projOwner.MountedCenter + Projectile.velocity * (projPosFac + 10);// + new Vector2(holdOffset * (float)Math.Sin(Projectile.velocity.ToRotation()), holdOffset * (float)Math.Cos(Projectile.velocity.ToRotation()));
			Projectile.rotation = Projectile.velocity.ToRotation();														// ^ side offset code

			if (projAnim >= projOwner.itemAnimationMax) Projectile.Kill();

			return false;
		}
    }
}