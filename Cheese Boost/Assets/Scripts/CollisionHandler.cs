
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{  
    Movement movement;
    AudioSource audioSource;
    bool isTransitioning = false;
    bool isCheatMode = false;
    [SerializeField] float delay = 1f;
    [SerializeField] AudioClip crashSound;
    [SerializeField] AudioClip landSound;
    [SerializeField] ParticleSystem crashParticle;
    [SerializeField] ParticleSystem landParticle;

    void Start(){

        audioSource = GetComponent<AudioSource>();
    }
    void Update() {
          if (Input.GetKey(KeyCode.L)){
              GoToNextLevel(); 
          }
          if (Input.GetKeyDown(KeyCode.C)){
              isCheatMode = !isCheatMode;
          }
    }    
    private void OnCollisionEnter(Collision other) 
    {
        if (isTransitioning || isCheatMode){
            return;
        } 

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
       
    }

    void StartCrashSequence()
    {  
            movement = GetComponent<Movement>(); 
            movement.enabled = false;
            audioSource.Stop();
            audioSource.PlayOneShot(crashSound);  
            crashParticle.Play();
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
            audioSource.Stop();
            audioSource.PlayOneShot(landSound);  
            landParticle.Play();
            Invoke("LoadNextLevel", delay);  
         
    }
    void LoadNextLevel()
    {
        Debug.Log(SceneManager.sceneCountInBuildSettings);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneInex = currentSceneIndex + 1;
        if (nextSceneInex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneInex = 0;
        } 
        SceneManager.LoadScene(nextSceneInex);
    }

}
