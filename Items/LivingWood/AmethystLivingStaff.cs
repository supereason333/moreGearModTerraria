using Terraria;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.ModLoader;

namespace moreGearMod.Items.LivingWood
{ 
	public class AmethystLivingStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.staff[Item.type] = true;
        }
        public override void SetDefaults()
		{
			Item.damage = 17;
			Item.DamageType = DamageClass.Magic;
			Item.crit = 5;
			Item.mana = 5;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 37;
			Item.useAnimation = Item.useTime;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 2.5f;
			Item.value = 6000;
			Item.rare = ItemRarityID.White;
			Item.UseSound = SoundID.Item8;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.AmethystBolt;
			Item.shootSpeed = 6f;
			Item.noMelee = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Wood, 20);
			recipe.AddIngredient(ItemID.Vine, 3);
			recipe.AddIngredient(ItemID.AmethystStaff, 1);
			recipe.AddTile(TileID.LivingLoom);
			recipe.Register();
		}
	}
}