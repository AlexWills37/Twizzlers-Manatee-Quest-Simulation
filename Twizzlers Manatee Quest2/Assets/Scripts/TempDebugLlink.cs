using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TempDebugLlink : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI debugtext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();
        debugtext.SetText("Sticks: " + OVRInput.Get(OVRInput.RawAxis2D.LThumbstick));
    }
}
