// using System.Collections.Generic;
// using UnityEngine;

// public class CookingStation : MonoBehaviour
// {
//     public GameManager gameManager;

//     void OnTriggerEnter2D(Collider2D other)
//     {
//         PlayerController player = other.GetComponent<PlayerController>();
//         if (player != null)
//         {
//             string dish = CheckRecipe(player.carryingItems);
//             if (dish != null)
//             {
//                 Debug.Log($"Created dish: {dish}");
//                 gameManager.AddScore(10);
//                 player.DropAll();
//             }
//         }
//     }

//     string CheckRecipe(List<string> items)
//     {
//         // 組み合わせを判定（順不同）
//         HashSet<string> set = new HashSet<string>(items);

//         if (set.SetEquals(new[] { "Tomato", "Lettuce" }))
//             return "Salad";

//         if (set.SetEquals(new[] { "Bread", "Tomato", "Lettuce" }))
//             return "Sandwich";

//         return null;
//     }
// }
