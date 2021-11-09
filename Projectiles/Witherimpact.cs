﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Hyperion.Projectiles
{
	public class Witherimpact : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.width = 520;
			Projectile.height = 520;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.penetrate = 1000;
			Projectile.timeLeft = 2;
			Projectile.aiStyle = 1;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			

			
		}




        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			
            base.OnHitNPC(target, damage, knockback, false);
        }

    }
}
