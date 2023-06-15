using System.Collections.Generic;
using UnityEngine;

public class TargetManager
{
    private List<Target> _targets = new List<Target>();

    public void createTarget(Target target)
    {
        _targets.Add(target);
    }

    public void checkHit(Vector2 worldPos)
    {

        foreach (Target target in _targets)
        {
            if (target.checkHit(worldPos))
            {
                target.onShooted();
                Debug.Log("moue");
                // do something
                // only one kill by one bullet
                break;
            }
        }
    }
    
}
