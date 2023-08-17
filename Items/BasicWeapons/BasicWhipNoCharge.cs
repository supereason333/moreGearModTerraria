using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using moreGearMod.Projectiles.Whips;
using Terraria.GameContent.Creative;

namespace moreGearMod.Items.BasicWeapons
{
	public class BasicWhipNoCharge : ModItem
	{
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.testNewVersonMod.hjson file.
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
		{
			Item.DefaultToWhip(ModContent.ProjectileType<BasicWhipProjectileNoCharge>(), 50, 2, 4);
			Item.shootSpeed = 4;
			Item.rare = ItemRarityID.Blue;
		}
        public override bool MeleePrefix()
        {
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