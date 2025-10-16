using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text timeText;
    public TMP_Text carryText;

    private int score = 0;
    private float timeLeft = 60f;

    void Update()
    {
        timeLeft -= Time.deltaTime;
        timeText.text = $"Time: {Mathf.CeilToInt(timeLeft)}";
    }

    public void AddScore(int value)
    {
        score += value;
        scoreText.text = $"Score: {score}";
    }

    public void UpdateCarryList(PlayerController player)
    {
        carryText.text = "Items: " + string.Join(", ", player.carryingItems);
    }
}
