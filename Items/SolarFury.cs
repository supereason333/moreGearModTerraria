using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using moreGearMod.Projectiles;
using System;
using Mono.Cecil;
using static Terraria.ModLoader.PlayerDrawLayer;

namespace moreGearMod.Items
{ 
	public class SolarFury : ModItem
	{
        public override void SetDefaults()
		{
			Item.damage = 250;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 20;
			Item.useAnimation = Item.useTime;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 5;
			Item.value = 3403000;
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item7;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.Flamelash;
			Item.shootSpeed = 15f;
			Item.scale = 3f;
        }
		int offsetNum = 0;
		int offsetWidth = 30;
		float rotation = 0;
		Vector2 offset = new Vector2(0,0);
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			if (player.altFunctionUse == 2)
			{
				Item.useTime = 30;
				Item.damage = 350;
				Item.useAnimation = Item.useTime;
				int a = Projectile.NewProjectile(source, position, velocity, ProjectileID.DD2BetsyFireball, damage, knockback);
				Main.projectile[a].friendly = true;
				Main.projectile[a].hostile = false;
			}
			else
			{
                Item.useTime = 20;
                Item.damage = 250;
                Item.useAnimation = Item.useTime;
            }

			return true;
        }
        public override bool AltFunctionUse(Player player)
        {
			return true;
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Wood, 20);
			recipe.AddIngredient(ItemID.WandofSparking, 1);
			recipe.AddTile(TileID.LivingLoom);
			recipe.Register();
		}
        public override Vector2? HoldoutOffset()
        {
			Vector2 offset = new Vector2(10,0);
			return offset;
        }
    }
}