using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : TargetControllerBase<Cat>
{
    protected override void createTarget()
    {
        base.createTarget();

        float scaleMultiplier = Random.Range(1, 2f);
        _targets[_targets.Count - 1].transform.localScale *= scaleMultiplier;
        _targets[_targets.Count - 1].transform.Translate(new Vector3(0, (scaleMultiplier - 1) / 2f, 0), Space.Self);
    }
}
