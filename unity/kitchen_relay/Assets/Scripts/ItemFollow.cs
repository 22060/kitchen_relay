using UnityEngine;

public class ItemFollow : MonoBehaviour
{
    [SerializeField] private Transform player;  // プレイヤーのTransform
    [SerializeField] private Vector3 offset = new Vector3(0.5f, 0.5f, 0f); // 相対位置

    void LateUpdate()
    {
        if (player == null) return;

        // プレイヤーの位置 + オフセット に追従
        transform.position = player.position + offset;
    }

    // エディタでプレイヤーを自動登録したいとき
    private void Reset()
    {
        player = GameObject.FindWithTag("Player")?.transform;
    }
}
