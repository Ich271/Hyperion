using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using Terraria.Audio;
using Terraria.DataStructures;

namespace Hyperion.Items.Weapons
{
	
	public class Hyperion : ModItem

	{
		
		
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("KEKW");
			

		}


      

        public override void SetDefaults()
		{
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.shootSpeed = 0;
			Item.sellPrice(20, 0, 0, 0);
			Item.damage = 200;
			Item.DamageType = DamageClass.Melee;
			Item.mana = 1;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 1;
			Item.noMelee = false; 
			Item.knockBack = 0;
			Item.crit = 69420;
			Item.rare = ItemRarityID.Gray;
            Item.shoot = ModContent.ProjectileType<Projectiles.Witherimpact>();
			Item.autoReuse = false;
			Item.useAnimation = 1;
		}

        public override void ModifyManaCost(Player player, ref float reduce, ref float mult)
        {
			if (player.altFunctionUse == 2) mult += 200;
        }

        public override bool AltFunctionUse(Player player) { return true; }

        

        public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {


			if (player.altFunctionUse != 2)	return false;
			else
			{
				

				SoundEngine.PlaySound(SoundLoader.GetLegacySoundSlot(Mod, "Sounds/Item/explode"));


				Vector2 playerLoc = player.Center;
				Vector2 curserWorld = Main.MouseWorld;
				Vector2 CurserPlayer = playerLoc - curserWorld;
				double mouseHypotenuse = Math.Sqrt((CurserPlayer.X * CurserPlayer.X) + (CurserPlayer.Y * CurserPlayer.Y));
				float sin = (float)(CurserPlayer.Y / mouseHypotenuse);
				float cos = (float)(CurserPlayer.X / mouseHypotenuse);

				for (int i = 0; i < 16; i++)
				{
					float nextLocY = sin * i;
					float nextLocX = cos * i;
					Point nextLocVector = new((int)Math.Round(nextLocX - 1, 0), (int)Math.Round(nextLocY - 1, 0));
					Point nextLocWorld = playerLoc.ToTileCoordinates() - nextLocVector;

					if (!Main.tile[nextLocWorld.X + 1, nextLocWorld.Y + 1].IsActive) player.position = nextLocWorld.ToWorldCoordinates();
					else break;
				}


				if (!player.HasBuff(ModContent.BuffType<Buffs.WitherShield>()) && player.statLife != player.statLifeMax2)
				{
						player.AddBuff(ModContent.BuffType<Buffs.WitherShield>(), 300, false, true);
						player.statLife += player.statDefense * 4;
						player.HealEffect(player.statDefense * 4, true);
						SoundEngine.PlaySound(SoundLoader.GetLegacySoundSlot(Mod, "Sounds/Item/WitherImpactSound"));				
				}

				
				
				return true;
			}


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
