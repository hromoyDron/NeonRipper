using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class StartWindow : MonoBehaviour
{
    public Button startButton;

    public void Init(UnityAction action)
    {
        startButton.onClick.AddListener(() => action());
    }
}
