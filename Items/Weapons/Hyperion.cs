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
			Item.CloneDefaults(ItemID.TerraBlade);
			Item.sellPrice(20, 0, 0, 0);
			Item.damage = 3000;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 1;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 1;
			Item.noMelee = false; 
			Item.knockBack = 0;
			Item.crit = 20;
			Item.value = 1000000;
			Item.rare = ItemRarityID.Gray;
			Item.UseSound = SoundID.Item20;
			Item.shoot = ProjectileID.None;
			Item.autoReuse = false;
			
			Item.UseSound = Mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/WitherImpactSound");
			

			
		}



		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		public override void OnConsumeMana(Player player, int manaConsumed)
		{
			if (player.altFunctionUse == 2)
			{
				Item.damage = Main.LocalPlayer.statManaMax2 * 9;
				Item.shoot = ModContent.ProjectileType<Projectiles.Witherimpact>();
				Item.mana = 200;
				Item.shootSpeed = 0f;

				Vector2 playerLoc = Main.LocalPlayer.position;
				Vector2 curserWorld = Main.MouseWorld;
				Vector2 CurserPlayer = playerLoc - curserWorld;
				double mouseHypotenuse = Math.Sqrt((CurserPlayer.X * CurserPlayer.X) + (CurserPlayer.Y * CurserPlayer.Y));
				float sin = (float)(CurserPlayer.Y / mouseHypotenuse);
				float cos = (float)(CurserPlayer.X / mouseHypotenuse);



				for (int i = 0; i < 501; i++)
				{

					float nextLocY = sin * i;
					float nextLocX = cos * i;
					Vector2 nextLocVector = new(nextLocX, nextLocY);
					Vector2 nextLocWorld = playerLoc - nextLocVector;
					Vector2 noBlockTeleport = new(nextLocWorld.X - 30, nextLocWorld.Y - 30);

					if (!Main.tile[nextLocWorld.ToTileCoordinates().X, nextLocWorld.ToTileCoordinates().Y].IsActive) player.position = noBlockTeleport; else break;
				}

				if (!player.HasBuff(ModContent.BuffType<Buffs.WitherShield>()) && player.statLife != player.statLifeMax2)
				{
					player.AddBuff(ModContent.BuffType<Buffs.WitherShield>(), 300, false, true);
					player.statLife += player.statDefense * 4;
					player.HealEffect(player.statDefense * 4, true);

				}
			}
			else
				Item.shoot = ProjectileID.None;
				Item.mana = 1;

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