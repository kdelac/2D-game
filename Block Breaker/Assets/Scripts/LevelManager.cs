using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Text text;
    public static int countScore = 0;
    public void LoadLevel(string name)
    {
        
        Cigla.brickCount = 0;
        SceneManager.LoadScene(name);
        
    }

    public void QuitRequest()
    {
        Application.Quit();
    }

    public void LoadNextLevel()
    {

        Cigla.brickCount = 0;
        SceneManager.LoadScene(Application.loadedLevel + 1);
        
    }

    public void BrickDestroyed()
    {
        if (Cigla.brickCount <= 0)
        {
            
            LoadNextLevel();
        }
    }
}
