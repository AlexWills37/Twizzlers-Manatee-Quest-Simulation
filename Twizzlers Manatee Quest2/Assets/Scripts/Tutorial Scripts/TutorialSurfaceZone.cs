using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSurfaceZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(TutorialBehavior.TaskNumber == 2 && other.gameObject.CompareTag("Player"))
        {
            TutorialBehavior.singleton.CompleteTaskAndProgress(3);
        }
    }
}
