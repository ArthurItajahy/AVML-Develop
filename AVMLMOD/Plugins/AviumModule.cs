using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using UnityEngine;

namespace AVMLMOD
{
  

    public class AviumPartModule : PartModule
    {
        // Called when the right-click menu is opened
        [KSPEvent(guiActive = true, guiName = "Activate Avium-Language")]
        public void ActivateAviumLanguage()
        {
            // Action when the menu item is clicked
            Debug.Log("Avium-Language activated!");
            ScreenMessages.PostScreenMessage("Avium-Language is now active!", 5f, ScreenMessageStyle.UPPER_CENTER);
        }

        // Called when the module is loaded or reloaded
        public override void OnStart(StartState state)
        {
            base.OnStart(state);
            Debug.Log("AviumPartModule initialized.");
        }
    }
}
