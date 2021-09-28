using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Audio;



namespace Hyperion.Sounds
{
    class WitherImpactSound : ModSound
    {

        public override SoundEffectInstance PlaySound(ref SoundEffectInstance soundInstance, float volume, float pan, Terraria.ModLoader.SoundType type)
        {
            

			SoundEffectInstance instance = Sound.Value.CreateInstance();
			instance.Play();
			instance.Volume = volume * .5f;
			instance.Pitch = -1.0f;
			return instance;

			
		}
	}
}



