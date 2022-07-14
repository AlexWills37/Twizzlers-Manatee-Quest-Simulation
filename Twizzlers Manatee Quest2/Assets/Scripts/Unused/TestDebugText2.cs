using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestDebugText2 : MonoBehaviour
{
    [SerializeField]
    private Transform toDebug;

    [SerializeField]
    private string preMessage = "";

    private TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        this.text = this.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.SetText(preMessage + " " + toDebug.localEulerAngles);
    }
}
