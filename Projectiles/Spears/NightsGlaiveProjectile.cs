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
	public class NightsGlaiveProjectile : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.width = 40;  // set width when i make sprite
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
		float changeRotation = 45;
		float changeRotationTotal = 90;
		bool runProj = true;

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
				if (runProj)
				{
					runProj = false;
                    Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.position - Projectile.velocity * 2, Projectile.velocity * 3, ProjectileID.ThunderSpearShot, Projectile.damage, Projectile.knockBack, Projectile.owner);
                }
			}
            changeRotation -= changeRotationTotal / projOwner.itemAnimationMax;

            Projectile.position = projOwner.MountedCenter - new Vector2(25, 15) + Projectile.velocity * projPosFac;// + new Vector2(holdOffset * (float)Math.Sin(Projectile.velocity.ToRotation()), holdOffset * (float)Math.Cos(Projectile.velocity.ToRotation()));
			Projectile.rotation = Projectile.velocity.ToRotation() + changeRotation;										// ^ side offset code

			if (projAnim >= projOwner.itemAnimationMax) Projectile.Kill();

			// dust
			int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Shadowflame);
			Main.dust[dust].velocity = Projectile.velocity * (float)Main.rand.Next(65, 90) * 0.01f;
			Main.dust[dust].scale = (float)Main.rand.Next(80, 115) * 0.013f;
			Main.dust[dust].noGravity = true;
			return false;
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
			target.AddBuff(BuffID.ShadowFlame, 120);
        }
    }
}