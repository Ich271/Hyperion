using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;


namespace Hyperion.Items.Weapons
{

	public class NecronsBladeUnrefined : ModItem

	{

		public override string Texture => "Hyperion/Items/Weapons/WitherBlade";

		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("KEKW");
			DisplayName.SetDefault("Necron's Blade (Unrefined)");
			
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			
		}

		public override void HoldItem(Player player)
		{
			player.statManaMax2 += 20;

		}




		public override void SetDefaults()
		{
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.shootSpeed = 0;
			Item.sellPrice(20, 0, 0, 0);
			Item.damage = 150;
			Item.DamageType = DamageClass.Melee;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 5;
			Item.noMelee = false;
			Item.knockBack = 0;
			Item.crit = 50;
			Item.rare = ItemRarityID.Gray;
			Item.autoReuse = false;
			Item.useAnimation = 5;
			
		}



		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<MoonLordsHandle>(), 1)
				.AddIngredient(ItemID.LunarBar, 24)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
		}
	}
}
