using UnityEngine;
using UnityEngine.UI;

public class ScoreBar : MonoBehaviour
{
    public Image fillImage;

    public int minScore = 0;
    public int maxScore = 100;

    public Gradient gradient;

    float currentFill = 0f;
    float targetFill = 0f;

    float velocity = 0f;
    public float smoothTime = 0.2f;

    void OnEnable()
    {
        if (ScoreManager.instance != null)
            ScoreManager.instance.onScoreChanged += OnScoreChanged;
    }

    void OnDisable()
    {
        if (ScoreManager.instance != null)
            ScoreManager.instance.onScoreChanged -= OnScoreChanged;
    }

    void Start()
    {
        // Inicializa con el score actual
        OnScoreChanged(ScoreManager.instance.score);

        // Evita animación brusca al inicio
        currentFill = targetFill;
        fillImage.fillAmount = currentFill;
        fillImage.color = gradient.Evaluate(currentFill);
    }

    void OnScoreChanged(int score)
    {
        targetFill = Mathf.InverseLerp(minScore, maxScore, score);
    }

    void Update()
    {
        currentFill = Mathf.SmoothDamp(currentFill, targetFill, ref velocity, smoothTime);

        fillImage.fillAmount = currentFill;
        fillImage.color = gradient.Evaluate(currentFill);
    }
}
