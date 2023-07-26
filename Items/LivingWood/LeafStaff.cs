using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace moreGearMod.Items.LivingWood
{
	public class LeafStaff : ModItem
	{
        public override void SetStaticDefaults()
        {
            Item.staff[Item.type] = true;
        }
        public override void SetDefaults()
		{
			Item.damage = 6;
			Item.mana = 3;
			Item.DamageType = DamageClass.Magic;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 10;
			Item.useAnimation = Item.useTime;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 2;
			Item.value = 3403;
			Item.rare = ItemRarityID.White;
			Item.UseSound = SoundID.Item7;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.Leaf;
			Item.shootSpeed = 7f;
			Item.noMelee = true;
			Item.scale = 1.4f;
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
			Vector2 offset = new Vector2(8,0);
			return offset;
        }
    }
}