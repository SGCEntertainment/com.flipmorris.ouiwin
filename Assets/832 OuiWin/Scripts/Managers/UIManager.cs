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

        GameManager.OnGameFinsihed += (IsWin) =>
        {
            GameObject popupPrefab = IsWin ? Resources.Load<GameObject>("win") : Resources.Load<GameObject>("lose");
            GameObject _popupGO = Instantiate(popupPrefab, GameObject.Find("screen").transform);
            _popupGO.GetComponent<Popup>().SetData(() =>
            {
                Destroy(_popupGO);
            });
        };
    }
}