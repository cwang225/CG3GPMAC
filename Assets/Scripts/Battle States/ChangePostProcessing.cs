using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ChangePostProcessing : BattleState
{
    [SerializeField] private Volume volume;
    // Start is called before the first frame update
    public override void Enter()
    {
        base.Enter();
        volume.GetComponent<ChromaticAberration>().intensity.value = 0.5f;

    }
}
