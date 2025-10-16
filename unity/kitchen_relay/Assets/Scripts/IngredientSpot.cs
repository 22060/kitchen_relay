// using UnityEngine;

// public class IngredientSpot : MonoBehaviour
// {
//     public string ingredientName;

//     void OnTriggerEnter2D(Collider2D other)
//     {
//         PlayerController player = other.GetComponent<PlayerController>();
//         if (player != null)
//         {
//             if (player.PickItem(ingredientName))
//             {
//                 Debug.Log($"Player picked {ingredientName}");
//                 Destroy(gameObject); // 食材を消す
//             }
//         }
//     }
// }
