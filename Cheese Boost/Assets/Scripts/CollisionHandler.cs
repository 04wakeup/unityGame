
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{  
    Movement movement;
    AudioSource audioSource;
    bool isTransitioning = false;
    [SerializeField] float delay = 1f;
    [SerializeField] AudioClip crashSound;
    [SerializeField] AudioClip landSound;

    void Start(){

        audioSource = GetComponent<AudioSource>();
    }
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
                isTransitioning = true;
                GoToNextLevel(); 
                break;
            default:
                isTransitioning = true;
                StartCrashSequence(); 
                break;
        }
        if (isTransitioning){
            movement = GetComponent<Movement>(); 
            movement.enabled = false;
        }
    }

    void StartCrashSequence()
    { 
        audioSource.PlayOneShot(landSound); 
        Invoke("ReloadLevel", delay);  
    }
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    
    void GoToNextLevel(){ 
        audioSource.PlayOneShot(crashSound); 
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
