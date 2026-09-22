using UnityEngine;
using UnityEngine.SceneManagement;
public class GameMenu : MonoBehaviour
{
   [SerializeField] private string gameSceneName;
   [SerializeField] private string mainMenuName;
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            Play();
        }
        if (Input.GetKeyDown("t"))
        {
            Menu();
        }
    }
   public void Play()
    {
        SceneManager.LoadScene(gameSceneName);
    }
    public void Menu()
    {
        SceneManager.LoadScene(mainMenuName);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
