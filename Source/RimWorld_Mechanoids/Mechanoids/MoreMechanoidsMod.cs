using Verse;

namespace MoreMechanoids;

public class MoreMechanoidsMod : Mod
{	

	public MoreMechanoidsMod(ModContentPack content)
		: base(content)
	{
        
        new HarmonyLib.Harmony("zal.moremechanoids").PatchAll();
		
	}
	
}
