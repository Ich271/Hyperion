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


			if (player.altFunctionUse != 2) return false;
			else
			{
				SoundEngine.PlaySound(SoundLoader.GetLegacySoundSlot(Mod, "Sounds/Item/explode"));


				Vector2 playerLoc = player.position;
				Vector2 curserWorld = Main.MouseWorld;
				Vector2 PlayerToCurser = curserWorld - playerLoc;
				Vector2 direction = PlayerToCurser.SafeNormalize(Vector2.UnitX);

				for (int i = 0; i < 350; i++)
				{
					Vector2 distance = new(i, i + 1);
					Vector2 nextLocation = playerLoc + (direction * distance);

					if (!Collision.SolidCollision(nextLocation, player.width, player.height)) player.position = nextLocation;
					else break;
				}





				if (!player.HasBuff(ModContent.BuffType<Buffs.WitherShield>()) && player.statLife != player.statLifeMax2 && player.altFunctionUse == 2)
				{
					player.AddBuff(ModContent.BuffType<Buffs.WitherShield>(), 300, false, true);
					player.statLife += player.statDefense * 4;
					player.HealEffect(player.statDefense * 4, true);
					SoundEngine.PlaySound(SoundLoader.GetLegacySoundSlot(Mod, "Sounds/Item/WitherImpactSound"));
					for (int i = 0; i < 50; i++)
					{
						Vector2 speed = Main.rand.NextVector2CircularEdge(1f, 1f);
						Dust d = Dust.NewDustPerfect(Main.LocalPlayer.Top, DustID.PurpleCrystalShard, speed * 5, Scale: 1.5f);
						d.noGravity = true;
					}
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
