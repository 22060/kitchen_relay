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
            foreach (var item in player.carryingItems)
            {
                if (other.GetComponent<Pot>().AddItem(item) == 1)
                {
                    Debug.Log($"Added {item} to pot");
                    FindAnyObjectByType<GameManager>().AddScore(5);
                    player.carryingItems.Remove(item);
                    break;
                }
            }
        }

        // ---鍋から食材を取り出す---
        else if (other.CompareTag("Pot") && player.carryingItems.Count == 0)
        {
            var pot = other.GetComponent<Pot>();
            if (pot.itemsInPot.Count > 0)
            {
                string item = pot.itemsInPot[pot.itemsInPot.Count - 1];
                pot.itemsInPot.RemoveAt(pot.itemsInPot.Count - 1);
                player.carryingItems.Add(item);
                Debug.Log($"Took {item} from pot");
            }
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
