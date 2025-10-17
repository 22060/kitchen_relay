using System.Collections.Generic;
using UnityEngine;

public class RecipeBook : MonoBehaviour
{
    public List<Recipe> recipes = new List<Recipe>();

    // 食材リストから完成レシピを判定
    public Recipe GetMatchingRecipe(List<string> items)
    {
        foreach (var recipe in recipes)
        {
            if (IsMatch(recipe.ingredients, items))
                return recipe;
        }
        return null;
    }

    public int maxitems()
    {
        int max = 0;
        foreach (var recipe in recipes)
        {
            if (recipe.ingredients.Count > max)
                max = recipe.ingredients.Count;
        }
        return max;
    }

    private bool IsMatch(List<string> required, List<string> provided)
    {
        if (required.Count != provided.Count)
            return false;

        // 並び順を無視して判定
        foreach (var ingredient in required)
        {
            if (!provided.Contains(ingredient))
                return false;
        }
        return true;
    }
}
