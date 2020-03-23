using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;

public class LoseWindow : MonoBehaviour
{
    public Button retryButton;

    public void Init(UnityAction action)
    {
        retryButton.onClick.AddListener(() => action());
    }
}
