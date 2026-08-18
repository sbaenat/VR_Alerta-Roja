using TMPro;
using UnityEngine;

public class ObjectCounterUI : MonoBehaviour
{
    public TextMeshProUGUI counterText;

    void OnEnable()
    {
        if (EndingManager.instance != null)
        {
            EndingManager.instance.onObjectCollected += UpdateCounter;
        }
    }

    void OnDisable()
    {
        if (EndingManager.instance != null)
            EndingManager.instance.onObjectCollected -= UpdateCounter;
    }

    void Start()
    {
        UpdateCounter(0);
    }

    void UpdateCounter(int collected)
    {
        counterText.text = $"{collected}";
    }
}
