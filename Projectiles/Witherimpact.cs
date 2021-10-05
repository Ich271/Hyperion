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
			Projectile.penetrate = 1000;
			Projectile.timeLeft = 2;
			Projectile.aiStyle = 1;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			
			

			
		}




        

    }
}