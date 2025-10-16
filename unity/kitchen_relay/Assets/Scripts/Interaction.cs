using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    public PlayerController player;
    private PlayerInput playerInput;
    private InputAction fireAction;
    private Cooldown cd = new Cooldown(0.2f);

    void Start()
    {
        player = GetComponent<PlayerController>();
        playerInput = GetComponent<PlayerInput>();
        fireAction = playerInput.actions["Pickup"];
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (cd.onCooldown) return;
        if (!fireAction.IsPressed()) return;

        // --- 冷蔵庫から食材を取得 ---
        if (other.CompareTag("Fridge_Tomato") && player.carryingItems.Count < player.maxCarryCount)
        {
            player.carryingItems.Add("Tomato");
        }
        else if (other.CompareTag("Fridge_Meat") && player.carryingItems.Count < player.maxCarryCount)
        {
            player.carryingItems.Add("Meat");
        }
        else if (other.CompareTag("Fridge_Carrot") && player.carryingItems.Count < player.maxCarryCount)
        {
            player.carryingItems.Add("Carrot");
        }

        // --- 鍋に入れてスコア加算 ---
        else if (other.CompareTag("Pot") && player.carryingItems.Count > 0)
        {
            FindAnyObjectByType<GameManager>().AddScore(player.carryingItems.Count);
            player.carryingItems.Clear();
        }

        // --- 一時置き場（Storage） ---
        else if (other.CompareTag("Storage"))
        {
            var spot = other.GetComponent<StorageSpot>();
            spot.Interact(player);
        }

        player.PrintCarryingItems();
        StartCoroutine(cd.start_cd());
    }
}
