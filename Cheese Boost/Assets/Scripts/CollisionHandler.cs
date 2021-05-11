
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{  
    private void OnCollisionEnter(Collision other) 
    {
        switch(other.gameObject.tag){
            case "Friendly":
                Debug.Log("Start");
                break;
            case "Fuel":
                Debug.Log("Fuel"); 
                break;
            case "Finish":
                LoadNextLevel();
                break;
            default:
                ReloadLevel(); 
                break;
        }
    }
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        SceneManager.LoadScene(currentSceneIndex);
    }
    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneInex = currentSceneIndex + 1;
        if (nextSceneInex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneInex = 0;
        } 
        SceneManager.LoadScene(nextSceneInex);
    }

}
