using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Hyperion;

namespace Hyperion.Items.Weapons
{

	public class Astrea : ModItem

	{

		public override string Texture => "Hyperion/Items/Weapons/WitherBlade";
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Item Ability: Wither Impact RIGHT CLICK \n" +
				"Teleports 30 tiles ahead of you.Then implode dealing damage based on your total mana to nearby enemies.\n"
				 + "Also applies the wither shield scroll ability reducing damage taken and granting an Absorption shield for 5 seconds.\n"
				  + "Mana cost: 190");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

		}

		public override void HoldItem(Player player)
		{
			player.statManaMax2 += 20;
			player.statDefense += 100;
			
		}




		public override void SetDefaults()
		{
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.shootSpeed = 0;
			Item.sellPrice(20, 0, 0, 0);
			Item.damage = 150;
			Item.DamageType = DamageClass.Melee;
			Item.mana = 1;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 5;
			Item.noMelee = false;
			Item.knockBack = 0;
			Item.crit = 50;
			Item.rare = ItemRarityID.Gray;
			Item.shoot = ModContent.ProjectileType<Projectiles.Witherimpact>();
			Item.autoReuse = false;
			Item.useAnimation = 5;
		
		}

		
		public override bool AltFunctionUse(Player player) { return true; }


        public override bool CanUseItem(Player player)
        {
			
			if (player.altFunctionUse != 2)
            {
				Item.mana = 0;
				Item.DamageType = DamageClass.Melee;
				Item.shoot = ProjectileID.None;
				return true;
			} 
			else
            {
				Item.mana = 150;
				Item.DamageType = DamageClass.Magic;
				Item.shoot = ModContent.ProjectileType<Projectiles.Witherimpact>();
				return true;
			}
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
       	
				SoundEngine.PlaySound(new SoundStyle("Hyperion/Sounds/Item/explode"));

				//setting Up tp
				Vector2 playerPos = player.position;
				Vector2 curserWorld = Main.MouseWorld;
				Vector2 PlayerToCurser = curserWorld - playerPos;
				Vector2 direction = PlayerToCurser.SafeNormalize(Vector2.UnitX);

				//executing tp untill collision
				for (int i = 0; i < 500; i++)
				{
					Vector2 distance = new(i, i);
					Vector2 nextLocation = playerPos + (direction * distance);
					
					
					if (!Collision.SolidCollision(nextLocation, player.width, player.height)) player.position = nextLocation;
					else break;
					
				}

				//Wither Shield effect
				if (!player.HasBuff(ModContent.BuffType<Buffs.WitherShield>()) && player.statLife != player.statLifeMax2 && player.altFunctionUse == 2)
				{
					player.AddBuff(ModContent.BuffType<Buffs.WitherShield>(), 300, false, true);
					player.statLife += player.GetWeaponCrit(Item) * 2;
					player.HealEffect(player.GetWeaponCrit(Item) * 2, true);
					SoundEngine.PlaySound(new SoundStyle("Hyperion/Sounds/Item/WitherImpactSound"));
					for (int i = 0; i < 50; i++)
					{
						Vector2 speed = Main.rand.NextVector2CircularEdge(1f, 1f);
						Dust d = Dust.NewDustPerfect(Main.LocalPlayer.Top, DustID.PurpleCrystalShard, speed * 5, Scale: 1.5f);
						d.noGravity = true;
					}
				}

			return true;
		}
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddRecipeGroup("Hyperion:WitherBlades")
				.AddIngredient(ItemID.FragmentStardust, 24)
				.AddTile(TileID.LunarCraftingStation)
				.Register();		
		}
	}
}
