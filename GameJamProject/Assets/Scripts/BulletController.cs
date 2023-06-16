using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private GameObject[] _bullets;

    public void refill()
    {
        foreach (var bullet in _bullets)
        {
            bullet.SetActive(true);
        }
    }

    public int remainingBullets()
    {
        int counter = 0;
        foreach (var bullet in _bullets)
        {
            if (bullet.activeInHierarchy)
            {
                counter++;
            }
        }

        return counter;
    }

    public void decreaseBullets()
    {
        GameObject lastActive = null;

        foreach (var bullet in _bullets)
        {
            if (bullet.activeInHierarchy)
            {
                lastActive = bullet;
            }
            else if (lastActive != null)
            {
                lastActive.SetActive(false);
                lastActive = null;
                break;
            }
        }

        if (lastActive != null)
        {
            lastActive.SetActive(false);
        }

    }

    
}
