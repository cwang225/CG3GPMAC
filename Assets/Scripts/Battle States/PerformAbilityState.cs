using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
/**
 * Author: Megan Lincicum
 * Date Created: 10/14/25
 * Date Last Updated: 10/31/25
 * Summary: Applies the ability effect to the target (and probably runs an animation)
 */
public class PerformAbilityState : BattleState
{
    private ChromaticAberration chrome;
    private ColorAdjustments colorAdjustments;
    private float chromeIntensityTime;
    private float colorAdjustIntensityTime;
   public override void Enter()
   {
        base.Enter();
        print("Performing action " + owner.ability.name);
        owner.volume.profile.TryGet(out chrome);
        // owner.volume.profile.TryGet(out colorAdjustments);
        StartCoroutine(Animate());
   }

   private void postProcess()
    {
        chromeIntensityTime = Time.realtimeSinceStartup;
        colorAdjustIntensityTime = Time.realtimeSinceStartup;
        chrome.intensity.value = owner.chromeIntensity.Evaluate(Time.realtimeSinceStartup - chromeIntensityTime);
        // colorAdjustments.colorFilter.value = newColor(owner.colorAdjustIntensity.Evaluate(Time.realtimeSinceStartup - colorAdjustIntensityTime);
        // chrome.intensity.value = 0.5f;
        // Color color = new Color(255f/255, 132f/255, 25f/255);
        // colorAdjustments.colorFilter.value = color;

    }

    IEnumerator Animate ()
    {
        postProcess();
        owner.ability.Perform();

        yield return owner.ability.Animate(owner.currentTile);
        if (owner.allianceTurn == Alliances.Player)
        
            owner.ChangeState<SelectActionState>();
        else
            owner.ChangeState<EnemySelectActionState>();
    }

}
