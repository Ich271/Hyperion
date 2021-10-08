using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace Hyperion.Items.Weapons
{
	
	public class Hyperion : ModItem

	{
		private int playerMaxMana;
		
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("KEKW");
			

		}


        public override void PostUpdate()
        {
			playerMaxMana = Main.LocalPlayer.statManaMax2 * 5;
        }

        public override void SetDefaults()
		{
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.shootSpeed = 0;
			Item.sellPrice(20, 0, 0, 0);
			Item.damage = 500;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 1;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 1;
			Item.noMelee = false; 
			Item.knockBack = 0;
			Item.crit = 69420;
			Item.rare = ItemRarityID.Gray;
            Item.shoot = ProjectileID.None;
			Item.autoReuse = false;
			Item.UseSound = SoundID.Item1;
			Item.useAnimation = 1;
		}



		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		public override void OnConsumeMana(Player player, int manaConsumed)
		{
			if (player.altFunctionUse == 2)
			{

				// Stats for rightclick ability ----------------------------------------------------------------------------------------------------------
				Item.damage = Main.LocalPlayer.statManaMax2 * 4;
				Item.shoot = ModContent.ProjectileType<Projectiles.Witherimpact>();
				Item.shootSpeed = 0f;
				Item.autoReuse = false;
				Terraria.Audio.SoundEngine.PlaySound(Mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/explode"), Main.LocalPlayer.position);
				Main.LocalPlayer.statMana -= 200;

				// setting up teleportation --------------------------------------------------------------------------------------------------------------

				Vector2 playerLoc = Main.LocalPlayer.position;
				Vector2 curserWorld = Main.MouseWorld;
				Vector2 CurserPlayer = playerLoc - curserWorld;
				double mouseHypotenuse = Math.Sqrt((CurserPlayer.X * CurserPlayer.X) + (CurserPlayer.Y * CurserPlayer.Y));
				float sin = (float)(CurserPlayer.Y / mouseHypotenuse);
				float cos = (float)(CurserPlayer.X / mouseHypotenuse);

				// checking for valid block and telportation ---------------------------------------------------------------------------------------------

				for (int i = 0; i < 501; i++)
				{

					float nextLocY = sin * i;
					float nextLocX = cos * i;
					Vector2 nextLocVector = new(nextLocX, nextLocY);
					Vector2 nextLocWorld = playerLoc - nextLocVector;
					Vector2 noBlockTeleport = new(nextLocWorld.X - 30, nextLocWorld.Y - 30);

					if (!Main.tile[nextLocWorld.ToTileCoordinates().X, nextLocWorld.ToTileCoordinates().Y].IsActive) player.position = noBlockTeleport; else break;
				}

				// wither shield ability -----------------------------------------------------------------------------------------------------------------

				if (!player.HasBuff(ModContent.BuffType<Buffs.WitherShield>()) && player.statLife != player.statLifeMax2)
				{
					player.AddBuff(ModContent.BuffType<Buffs.WitherShield>(), 300, false, true);
					player.statLife += player.statDefense * 4;
					player.HealEffect(player.statDefense * 4, true);
					Terraria.Audio.SoundEngine.PlaySound(Mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/WitherImpactSound"), Main.LocalPlayer.position);

				}
			}
			else
				Item.shoot = ProjectileID.None;
				Item.mana = 1;
				Item.UseSound = SoundID.Item1;
				Item.autoReuse = true;


		}
  

        public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<MoonLordsHandle>(), 1)
				.AddIngredient(ItemID.FragmentNebula, 24)
				.AddIngredient(ItemID.LunarBar, 24)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
		}
	}
}