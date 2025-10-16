
using System.Collections;
using UnityEngine;
public class Cooldown
{
    // This class is intentionally left empty as the cooldown functionality
    // is implemented directly within the StorageSpot class.
    public float cd_s = 0.5f;
    public bool onCooldown = false;
    public Cooldown(float cooldownSeconds = 0.5f)
    {
        cd_s = cooldownSeconds;

    }

    public IEnumerator start_cd()
    {
        onCooldown = true;
        yield return new WaitForSeconds(cd_s); // チャタリング防止
        onCooldown = false;
    }
}