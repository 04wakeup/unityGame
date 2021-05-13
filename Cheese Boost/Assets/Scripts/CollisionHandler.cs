
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{  
    Movement movement;
    [SerializeField] float delay = 1f;
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
                GoToNextLevel();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    void StartCrashSequence()
    {
        movement = GetComponent<Movement>(); 
        movement.enabled = false;
        Invoke("ReloadLevel", delay);  
    }
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    
    void GoToNextLevel(){
        movement = GetComponent<Movement>(); 
        movement.enabled = false;
        Invoke("LoadNextLevel", delay);  
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
