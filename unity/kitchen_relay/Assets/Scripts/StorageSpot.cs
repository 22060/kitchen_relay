using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageSpot : MonoBehaviour
{
    public List<string> storedItems = new List<string>();
    private Cooldown cd = new Cooldown(0.5f);

    public void Interact(PlayerController player)
    {
        if (cd.onCooldown) return;

        // プレイヤーの持ち物がある → 一時置き場に移動
        if (player.carryingItems.Count > 0)
        {
            storedItems.AddRange(player.carryingItems);
            player.carryingItems.Clear();
        }
        // 一時置き場にアイテムがある → プレイヤーが拾う
        else if (storedItems.Count > 0)
        {
            player.carryingItems.AddRange(storedItems);
            storedItems.Clear();
        }

        StartCoroutine(cd.start_cd());
        Debug.Log("StorageSpot状態: " + string.Join(", ", storedItems));
    }
}
