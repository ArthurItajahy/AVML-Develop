using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using KSP.UI.Screens;
using System.Collections;



[KSPAddon(KSPAddon.Startup.SpaceCentre, false)]
public class AviumPartModule : PartModule
{
    // Called when the right-click menu is opened
    [KSPEvent(guiActive = true, guiName = "Activate Avium-Language")]
    public void ActivateAviumLanguage()
    {
        // Action when the menu item is clicked
        UnityEngine.Debug.Log("Avium-Language activated!");
        ScreenMessages.PostScreenMessage("Avium-Language is now active!", 5f, ScreenMessageStyle.UPPER_CENTER);
    }

    // Called when the module is loaded or reloaded
    public override void OnStart(StartState state)
    {
        base.OnStart(state);
        UnityEngine.Debug.Log("AviumPartModule initialized.");
    }
}
