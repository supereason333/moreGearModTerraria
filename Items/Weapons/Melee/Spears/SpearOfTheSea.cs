using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace moreGearMod.Items.Weapons.Melee.Spears
{
    public class SpearOfTheSea : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 40;
            Item.DamageType = DamageClass.Melee;
            Item.width = 70;
            Item.height = 40;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 2;
            Item.value = 1500000;
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;

            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.Spears.SpearOfTheSeaProjectile>();
            Item.shootSpeed = 1f;
            Item.useTurn = false;
        }
        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[Item.shoot] < 1;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Trident, 1);
            recipe.AddIngredient(ItemID.Coral, 4);
            recipe.AddIngredient(ItemID.Seashell, 4);
            recipe.AddIngredient(ItemID.Shrimp, 2);
            recipe.AddIngredient(ItemID.Prismite, 2);
            recipe.AddIngredient(ItemID.AtlanticCod, 2);
            recipe.AddIngredient(ItemID.Ruby, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
            base.AddRecipes();
        }
    }
}