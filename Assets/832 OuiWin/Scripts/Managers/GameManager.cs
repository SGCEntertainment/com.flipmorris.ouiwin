using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get => FindObjectOfType<GameManager>(); }
    public static Action OnHandlePulled { get; set; } = delegate { };
    public static Action<bool> OnGameFinsihed { get; set; } = delegate { };

    private const string target = "WINOUI";
    public string inputString = string.Empty;
    private readonly char[] letters = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

    private bool IsStarted;
    private int index = 0;
    public Slot[] slots;

    public void Spin()
    {
        RestartGame();
        OnHandlePulled?.Invoke();
        IsStarted = true;
    }

    public void Check()
    {
        OnGameFinsihed?.Invoke(string.Equals(target, inputString));
    }

    public char GetRandomLetter()
    {
        return letters[UnityEngine.Random.Range(0, letters.Length)];
    }

    public void StopSomeSlot()
    {
        if(index > slots.Length - 1 || !IsStarted)
        {
            IsStarted = false;
            return;
        }

        slots[index].StopMe();
        index++;
    }

    public void RestartGame()
    {
        index = 0;
        inputString = string.Empty;
    }
}