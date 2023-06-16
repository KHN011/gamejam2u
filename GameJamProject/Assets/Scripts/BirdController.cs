using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : TargetControllerBase<Bird>
{
    public Target balloon;
    protected override void createTarget()
    {
        base.createTarget();

        _targets[_targets.Count - 1].setBalloon(balloon.transform);
    }
    private void Update()
    {
        if (balloon != null)
        {
            foreach (var bird in _targets)
            {
                Vector2 pos = new Vector2(bird.transform.position.x, bird.transform.position.y);
                balloon.checkHit(pos);

                if (balloon == null)
                {
                    return;
                }
            }
        }
            
    }
}
