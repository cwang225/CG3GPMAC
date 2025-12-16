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
        owner.volume.profile.TryGet(out colorAdjustments);
        StartCoroutine(Animate());
   }

IEnumerator AnimatePostProcess()
    {
        //Color startColor = Color.white;
        Color startColor = new Color(0.9176f, 0.2863f, 0.9882f, 1.0f);
        Color targetColor = new Color(.933f, .565f, .988f, 1f);
        float t = 0f;
        float duration = 1f;
        while (t < 1f)
        {
            // t += Time.deltaTime;
            t += Time.deltaTime;
            float normalizedTime = t / duration;
            //float intensity = owner.colorAdjustIntensity.Evaluate(t);
            float intensity = t*2;
            //float chromeIntensity = owner.chromeIntensity.Evaluate(t);
            chrome.intensity.value = owner.chromeIntensity.Evaluate(t);
            colorAdjustments.colorFilter.value = Color.Lerp(targetColor, startColor, normalizedTime);
            yield return null;
            }
    }

    IEnumerator Animate ()
    {
        StartCoroutine(AnimatePostProcess());
        owner.ability.Perform();

        yield return owner.ability.Animate(owner.currentTile);
        chrome.intensity.value = 0.15f;
        colorAdjustments.colorFilter.value = new Color(255f/255, 255f/255, 255f/255);
        if (owner.allianceTurn == Alliances.Player)
        
            owner.ChangeState<SelectActionState>();
        else
            owner.ChangeState<EnemySelectActionState>();
    }

}
