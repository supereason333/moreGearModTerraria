using Terraria;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.ModLoader;
using moreGearMod.Projectiles;

namespace moreGearMod.Items
{
	public class SolarFury : ModItem
    {
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.testNewVersonMod.hjson file.
        public override void SetStaticDefaults()
        {
            Item.staff[Item.type] = true;
        }
        public override void SetDefaults()
		{
			Item.damage = 50;
			Item.DamageType = DamageClass.Melee;
			Item.width = 30;
			Item.height = 30;
			Item.useTime = 15;
			Item.useAnimation = Item.useTime;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 6;
			Item.value = 5700000;
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item71;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<GlowSwordProjectile>();
			Item.noMelee = true;
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