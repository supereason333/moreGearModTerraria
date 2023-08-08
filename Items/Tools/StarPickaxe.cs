using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace moreGearMod.Items.Tools
{
	public class StarPickaxe : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 12;
			Item.DamageType = DamageClass.Melee;
			Item.mana = 0;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 16;
			Item.useAnimation = 16;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 2;
			Item.value = 7000;
			Item.rare = ItemRarityID.Orange;
			Item.autoReuse = true;
			Item.pick = 100;
			Item.useTurn = true;
			Item.scale = 1f;
		}
		bool isNormal = true;
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2 && isNormal == true)
            {
                Item.DamageType = DamageClass.Magic;
                Item.useTime = 6;
                Item.useAnimation = 6;
                Item.mana = 2;
                Item.pick = 120;
                isNormal = false;
            }
            else if (player.altFunctionUse == 2 && isNormal == false)
            {
                Item.DamageType = DamageClass.Melee; 
                Item.useTime = 16;
                Item.useAnimation = 16;
                Item.mana = 0;
                Item.pick = 100;
                isNormal = true;
            }
			if (player.altFunctionUse == 2)
			{
                SoundEngine.PlaySound(SoundID.MaxMana, player.position);
                for (int i = 0; i <= 5; i++)   
                {
                    int dust = Dust.NewDust(player.position, player.width, player.height, DustID.Flare_Blue);
                    Main.dust[dust].velocity *= (float)Main.rand.Next(65, 90) * 0.01f;
                    Main.dust[dust].scale = (float)Main.rand.Next(80, 115) * 0.013f;
                    Main.dust[dust].noGravity = false;
                }
            }
            return base.CanUseItem(player);
        }
        public override bool AltFunctionUse(Player player)
        {
			return true;
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.HellstoneBar, 8);
			recipe.AddIngredient(ItemID.FallenStar, 5);
			recipe.AddIngredient(ItemID.Wood, 10);
			recipe.AddIngredient(ItemID.Diamond, 3);
            recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
    }
}