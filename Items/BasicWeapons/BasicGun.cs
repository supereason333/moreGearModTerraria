using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.ModLoader;
using moreGearMod.Projectiles;

namespace moreGearMod.Items.BasicWeapons
{
	public class BasicGun : ModItem
	{
        public override void SetDefaults()
		{
			Item.damage = 50;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 20;
			Item.useAnimation = Item.useTime;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 0.1f;
			Item.value = 10000;
			Item.rare = ItemRarityID.White;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<BasicBulletBounceProjectile>();
			Item.useAmmo = AmmoID.Bullet;
			Item.shootSpeed = 10f;
			Item.noMelee = true;
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Vector2 offset = new Vector2(3, 3);
			position += offset;
			return true;
		}
        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}