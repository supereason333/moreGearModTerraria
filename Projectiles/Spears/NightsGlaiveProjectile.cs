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
		float changeRotation = 10;
		float changeRotationTotal = 90;
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
            changeRotation -= changeRotationTotal / projOwner.itemAnimationMax;

            Projectile.position = projOwner.MountedCenter - new Vector2(25, 15) + Projectile.velocity * projPosFac;// + new Vector2(holdOffset * (float)Math.Sin(Projectile.velocity.ToRotation()), holdOffset * (float)Math.Cos(Projectile.velocity.ToRotation()));
			Projectile.rotation = Projectile.velocity.ToRotation() + changeRotation;

			if (projAnim >= projOwner.itemAnimationMax) Projectile.Kill();

			int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Flare_Blue);
			Main.dust[dust].velocity = Projectile.velocity * (float)Main.rand.Next(65, 90) * 0.01f;
			Main.dust[dust].scale = (float)Main.rand.Next(80, 115) * 0.013f;
			Main.dust[dust].noGravity = true;

			return false;
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
			
            base.OnHitNPC(target, hit, damageDone);
        }
    }
}