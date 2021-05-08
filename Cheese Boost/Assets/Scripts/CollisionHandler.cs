
using UnityEngine;

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
            default:
                Debug.Log("what did you touch???");
                break;
        }
    }
}
