using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject game;

    private void Awake()
    {
        LoadingGO.OnLoadingStarted += () =>
        {
            game.SetActive(false);
        };

        LoadingGO.OnLoadingFinished += () =>
        {
            game.SetActive(true);
        };
    }
}