using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This script adjust the height of the camera. It needs to be attached to the camera.
 * 
 * @author Sami Cemek
 * Updated: 08/20/21
 */

public class AutoHeightScaler : MonoBehaviour
{
    [SerializeField] private float defaultHeight = 1.8f;
    [SerializeField] private Camera camera;
    
    private void Resize()
    {
        float headHeight = camera.transform.localPosition.y;
        float scale = defaultHeight / headHeight;
        transform.localScale = Vector3.one * scale;
    }

    void OnEnable()
    {
        //Resize();
    }

}
