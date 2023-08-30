using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace moreGearMod.Items.Weapons.Melee.Spears
{
    public class NightsGlaive : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 20;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 6;
            Item.value = 50000;
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;

            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.Spears.NightsGlaiveProjectile>();
            Item.shootSpeed = 2f;
        }
        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[Item.shoot] < 1;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.ShadowScale, 8);
            recipe.AddIngredient(ItemID.IronBar, 6);
            recipe.AddIngredient(ItemID.Spear);
            recipe.AddIngredient(ItemID.DarkLance);
            recipe.AddIngredient(ModContent.ItemType<Pitchfork>());
            recipe.AddIngredient(ItemID.ThunderSpear);
            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();
            base.AddRecipes();
        }
    }
}