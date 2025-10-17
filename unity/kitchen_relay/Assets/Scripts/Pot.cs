using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Pot : MonoBehaviour
{
    public List<string> itemsInPot = new List<string>();
    public RecipeBook recipeBook;

    public int AddItem(string item)
    {
        if (item == null) return 0;
        if (itemsInPot.Count >= recipeBook.maxitems())
        {
            Debug.Log("Pot is full, cannot add more items.");
            return 0;
        }
        itemsInPot.Add(item);
        Debug.Log($"Added {item} to pot");

        TryCook();
        return 1;
    }

    private async void TryCook()
    {
        Recipe matched = recipeBook.GetMatchingRecipe(itemsInPot);
        if (matched != null)
        {
            Debug.Log($"✅ Recipe matched! Cooked: {matched.resultItem}");
            itemsInPot.Clear();
            await Task.Delay((int)(matched.cookTime * 1000));
            itemsInPot.Add(matched.resultItem);
        }
    }
}
