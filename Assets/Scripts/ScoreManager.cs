using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 50;

    // Evento
    public delegate void OnScoreChanged(int newScore);
    public event OnScoreChanged onScoreChanged;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void AddScore(int amount)
    {
        score += amount;

        score = Mathf.Clamp(score, 0, 100);

        Debug.Log("Score: " + score);

        onScoreChanged?.Invoke(score);
    }
}