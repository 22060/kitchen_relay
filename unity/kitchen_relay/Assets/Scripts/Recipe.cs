using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Recipe
{
    public string recipeName;           // 料理名
    public List<string> ingredients;    // 必要な食材
    public string resultItem;           // 出来上がる料理
    public int score;                 // 料理のスコア
    public float cookTime;            // 料理にかかる時間
}
