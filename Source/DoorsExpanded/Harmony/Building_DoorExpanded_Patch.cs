using DoorsExpanded;
using HarmonyLib;
using MoreMechanoids;
using RimWorld;
using System.Collections.Generic;
using Verse;

[HarmonyPatch(typeof(Building_Door), nameof(Building_Door.GetGizmos))]
public static class Building_Door_GetGizmos_Patch
{
    public static IEnumerable<Gizmo> Postfix(IEnumerable<Gizmo> __result, Building_Door __instance)
    {
        foreach (var gizmo in __result)
        {
            // Only modify if this is a Building_DoorExpanded
            if (__instance is Building_DoorExpanded expandedDoor &&
                gizmo is Command_Toggle t &&
                t.defaultLabel == "CommandToggleDoorHoldOpen".Translate())
            {
                var forcedOpen = expandedDoor.IsForcedOpen();
                t.Disabled = forcedOpen;
                t.disabledReason = forcedOpen ? "DisabledForcedOpen".Translate() : null;
            }

            yield return gizmo;
        }
    }
}
