using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("移動設定")]
    public float moveSpeed = 3f;

    [Header("持ち物設定")]
    public int maxCarryCount = 3;
    public List<string> carryingItems = new List<string>();

    private Vector2 moveInput;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // --- 新InputSystemで呼ばれる ---
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }

    public void PrintCarryingItems()
    {
        string items = carryingItems.Count > 0 ? string.Join(", ", carryingItems) : "なし";
        Debug.Log("現在の持ち物: " + items);
    }
}
