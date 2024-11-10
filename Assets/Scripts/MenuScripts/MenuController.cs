using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
    using UnityEditor;
#endif

public class MenuController : MonoBehaviour
{
    [SerializeField] SaveManager saveManager = SaveManager.Instance;
    
    public void Start()
    {
        if (saveManager == null)
        {
            saveManager = SaveManager.Instance;
        }
        SaveManager.Instance.DisplayHighScores();

    }
    
    public void StartGame() 
    {
        SaveManager.Instance.UpdateName();
        SceneManager.LoadScene(1);
    }

    //private IEnumerator HighScoreWait()
    //{
    //    yield return new WaitForSeconds(.1f); 
    //    SaveManager.Instance.DisplayHighScores();
    //}

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
