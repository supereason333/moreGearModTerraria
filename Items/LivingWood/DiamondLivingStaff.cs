using Terraria;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.ModLoader;

namespace moreGearMod.Items.LivingWood
{ 
	public class DiamondLivingStaff : ModItem
    {
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.testNewVersonMod.hjson file.
        public override void SetStaticDefaults()
        {
            Item.staff[Item.type] = true;
        }
        public override void SetDefaults()
		{
			Item.damage = 30;
			Item.DamageType = DamageClass.Magic;
			Item.crit = 5;
			Item.mana = 8;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 25;
			Item.useAnimation = Item.useTime;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 5.5f;
			Item.value = 65000;
			Item.rare = ItemRarityID.White;
			Item.UseSound = SoundID.Item8;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.DiamondBolt;
			Item.shootSpeed = 9.5f;
			Item.noMelee = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Wood, 20);
			recipe.AddIngredient(ItemID.Vine, 3);
			recipe.AddIngredient(ItemID.DiamondStaff, 1);
			recipe.AddTile(TileID.LivingLoom);
			recipe.Register();
		}
	}
}