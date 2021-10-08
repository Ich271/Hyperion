using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Hyperion.Projectiles
{
	public class Witherimpact : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.width = 500;
			Projectile.height = 500;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 5;
			Projectile.aiStyle = 1;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			
			

			
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			
			target.immune[Projectile.owner] = 5;
		}




	}
}