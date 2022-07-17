using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceTrigger : MonoBehaviour
{
    public delegate void Resolve();
    public static Resolve OnResolve;
    [SerializeField] AudioSource resolveSound;
    [SerializeField] GameObject explosionLevel1Prefab;
    [SerializeField] GameObject explosionLevel2Prefab;
    [SerializeField] GameObject explosionLevel3Prefab;

    protected void Complete(int level)
    {
        OnResolve?.Invoke();
        AudioSource.PlayClipAtPoint(resolveSound.clip, transform.position);

        if (level == 1)
        {
            Instantiate(explosionLevel1Prefab, transform.position, Quaternion.identity);
        } else if (level == 2)
        {
            Instantiate(explosionLevel2Prefab, transform.position, Quaternion.identity);
        } else if (level == 3)
        {
            Instantiate(explosionLevel3Prefab, transform.position, Quaternion.identity);
        }
    }
}
