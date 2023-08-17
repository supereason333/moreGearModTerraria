using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;
using System.Net.Mail;
using System.Collections.Generic;

namespace moreGearMod.Projectiles.Whips
{
	public class BasicWhipProjectile : ModProjectile
	{
        public override void SetStaticDefaults()
        {
			ProjectileID.Sets.IsAWhip[0] = true;
        }
        public override void SetDefaults()
		{
			Projectile.DefaultToWhip();
		}
		private float Timer
		{
			get => Projectile.ai[0];
			set => Projectile.ai[0] = value;
		}
		private float ChargeTime
		{
            get => Projectile.ai[1];
            set => Projectile.ai[1] = value;
        }
        public override bool PreAI()
        {
			Player owner = Main.player[Projectile.owner];

			if(!owner.channel || ChargeTime >= 120)
			{
				return true;
			}

			if(++ChargeTime % 12 == 0)
			{
				Projectile.WhipSettings.Segments++;
			}
			Projectile.WhipSettings.RangeMultiplier += 1 / 120f;

			owner.itemAnimation = owner.itemAnimationMax;
			owner.itemTime = owner.itemTimeMax;
            return false;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
			Main.player[Projectile.owner].MinionAttackTargetNPC = target.whoAmI;
        }
		public void DrawLine(List<Vector2> list)
		{
            Texture2D texture = TextureAssets.FishingLine.Value;
            Rectangle frame = texture.Frame();
            Vector2 origin = new Vector2(frame.Width / 2, 2);

            Vector2 pos = list[0];
            for (int i = 0; i < list.Count - 1; i++)
            {
                Vector2 element = list[i];
                Vector2 diff = list[i + 1] - element;

                float rotation = diff.ToRotation() - MathHelper.PiOver2;
                Color color = Lighting.GetColor(element.ToTileCoordinates(), Color.White);
                Vector2 scale = new Vector2(1, (diff.Length() + 2) / frame.Height);

                Main.EntitySpriteDraw(texture, pos - Main.screenPosition, frame, color, rotation, origin, scale, SpriteEffects.None, 0);

                pos += diff;
            }
		}
        public override bool PreDraw(ref Color lightColor)
        {
            List<Vector2> list = new List<Vector2>();
            Projectile.FillWhipControlPoints(Projectile, list);

            DrawLine(list);
            
            return false;
        }
    }
}