using Terraria;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.ModLoader;

namespace moreGearMod.Items.LivingWood
{ 
	public class SapphireLivingStaff : ModItem
    {
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.testNewVersonMod.hjson file.
        public override void SetStaticDefaults()
        {
            Item.staff[Item.type] = true;
        }
        public override void SetDefaults()
		{
			Item.damage = 21;
			Item.DamageType = DamageClass.Magic;
			Item.crit = 5;
			Item.mana = 6;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 32;
			Item.useAnimation = Item.useTime;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 4f;
			Item.value = 20000;
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item8;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.SapphireBolt;
			Item.shootSpeed = 8f;
			Item.noMelee = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Wood, 20);
			recipe.AddIngredient(ItemID.Vine, 3);
			recipe.AddIngredient(ItemID.SapphireStaff, 1);
			recipe.AddTile(TileID.LivingLoom);
			recipe.Register();
		}
	}
}