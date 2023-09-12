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
			Projectile.height = 15;
			Projectile.aiStyle = 28;
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

            Projectile.position = projOwner.MountedCenter + Projectile.velocity * projPosFac;
			Projectile.rotation = Projectile.velocity.ToRotation();              

            if (projAnim >= projOwner.itemAnimationMax) Projectile.Kill();
            return false;
		}
	}
}
