using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.ModLoader;

namespace moreGearMod.Items.Weapons
{
	public class VortexShotbow : ModItem
	{
        public override void SetDefaults()
		{
			Item.damage = 83;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 10;
			Item.useAnimation = Item.useTime;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 6;
			Item.value = 120000;
			Item.rare = ItemRarityID.Purple;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
			Item.shoot = AmmoID.Arrow;
			Item.useAmmo = AmmoID.Arrow;
			Item.shootSpeed = 45f;
			Item.noMelee = true;
			Item.scale = 1.4f;
		}
		Vector2 velocityOffset = new Vector2(0, 0);
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			for (int i = 0; i <= 4; i++)
			{
				velocityOffset = new Vector2(Main.rand.Next(-10, 10), Main.rand.Next(-10, 10));
                Projectile.NewProjectile(source, position, velocity + velocityOffset, type, damage, knockback);
            }
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }
        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.FragmentVortex, 14);
			recipe.AddIngredient(ItemID.LunarBar, 10);
			recipe.AddIngredient(ItemID.SoulofLight, 5);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
        public override Vector2? HoldoutOffset()
        {
            Vector2 offset = new Vector2(6, 0);
            return offset;
        }
    }
}