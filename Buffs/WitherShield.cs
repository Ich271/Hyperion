
using Terraria;
using Terraria.ModLoader;

namespace Hyperion.Buffs
{
    class WitherShield : ModBuff
    {


		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("WitherShield"); 
			Description.SetDefault("Healing ability is on cooldown. Grands 10% damage reduction"); 
			Main.buffNoSave[Type] = true; 
		}

		public override void Update(Player player, ref int buffIndex)
		{

           player.endurance += (float)(0.1);
			
		}


	}

	



}
