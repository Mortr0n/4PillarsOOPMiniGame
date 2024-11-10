using UnityEngine;

public class GameInitializer : MonoBehaviour
{    void Start()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.StartGame();
        }
    }
}
