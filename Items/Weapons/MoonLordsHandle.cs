using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;

namespace Hyperion.Items.Weapons
{
    class MoonLordsHandle : ModItem
    {


        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("The core material for the Hyperion");


        }

        public override void SetDefaults()
        {
            Item.sellPrice(10, 0, 0, 0);
            Item.rare = ItemRarityID.Master;
            Item.height = 32;
            Item.width = 32;
            Item.consumable = false;
            Item.material = true;
            Item.maxStack = 1;

        }


    }


    class MyGlobalNPC : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {


            if (npc.type == NPCID.MoonLordCore)
            {
                 npcLoot.Add(ItemDropRule.MasterModeDropOnAllPlayers(ModContent.ItemType<MoonLordsHandle>(), 25));
            }
        }

    }




}
