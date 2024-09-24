using MelonLoader;
using BTD_Mod_Helper;
using SpongeBob;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using UnityEngine.InputSystem.Utilities;

[assembly: MelonInfo(typeof(SponbeBob.SpongeBob), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace SponbeBob;

public class SpongeBob : BloonsTD6Mod
{
    public override void OnApplicationStart()
    {
        MelonLogger.Msg("SpongeBob mod loaded!");
    }
}