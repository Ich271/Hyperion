using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Terraria.ID;
using Hyperion.Items.Weapons;

namespace Hyperion
{
	public class Hyperion : Mod
	{
		    
    
	public override void AddRecipeGroups()
	{
		RecipeGroup WitherBlades = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Wither Blade", new int[]
		{
		ModContent.ItemType<NecronsBladeUnrefined>(),
		ModContent.ItemType<Astrea>(),
		ModContent.ItemType<Items.Weapons.Hyperion>(),
		ModContent.ItemType<Scylla>(),
		ModContent.ItemType<Valkyrie>()
		});
		RecipeGroup.RegisterGroup("Hyperion:WitherBlades", WitherBlades);
	}




	}
	
}