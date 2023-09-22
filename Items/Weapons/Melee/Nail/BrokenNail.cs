using moreGearMod.Projectiles.Nail;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace moreGearMod.Items.Weapons.Melee.Nail
{
	public class BrokenNail : ModItem
	{
        public override void SetDefaults()
		{
			Item.damage = 20;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 30;
			Item.useAnimation = Item.useTime;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.value = 1500;
			Item.rare = ItemRarityID.Gray;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.shoot = ModContent.ProjectileType<NailProjectile>();
			Item.shootSpeed = 1f;
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