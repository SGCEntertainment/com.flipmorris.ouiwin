using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private Text textComponent;

    private void Awake()
    {
        textComponent = GetComponent<Text>();
        GameManager.OnHandlePulled += () =>
        {
            StartCoroutine(nameof(SpinMe));
        };
    }

    private IEnumerator SpinMe()
    {
        while(true)
        {
            textComponent.text = GameManager.Instance.GetRandomLetter().ToString();
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void StopMe()
    {
        StopCoroutine(nameof(SpinMe));
        GameManager.Instance.inputString += textComponent.text;
    }
}
