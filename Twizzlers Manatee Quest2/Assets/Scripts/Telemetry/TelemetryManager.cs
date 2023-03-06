using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;
using UnityEngine.UI;

public class TelemetryManager : MonoBehaviour {
    public static TelemetryManager instance;
    private int frameCount = 0;
    private bool isInternetConnected = false;
    private int lookingAtCount = 0;
    private string lookingAtTarget = "";
    public static string lastScene = "";
    public static string session = "";
    public static List<TelemetryEntry> entries = new List<TelemetryEntry>();
    public static string url = "http://18.222.189.147/";

    public Transform playerTransform;

    private void Awake() {
        // Ensure there is only one instance of the telemetry manager between scenes
        if (instance != null) {

            Destroy(this);
        } else {
            instance = this;
            StartCoroutine(Initialize());
            DontDestroyOnLoad(gameObject);
        }   
    }

    private IEnumerator Initialize() {
        Debug.Log("Initilizing");
        // isInternetConnected = Api.isInternetConnected();
        using (UnityWebRequest webRequest = UnityWebRequest.Get(TelemetryManager.url + "session/new")) {
            // Send the request
            yield return webRequest.SendWebRequest();
            
            
            try
            {
                // Parse the json response
                var jsonResponse = JsonUtility.FromJson<CreateSessionResponse>(webRequest.downloadHandler.text);
                Debug.Log("jsonResponse: " + jsonResponse.data.session);
                // Set the session id
                TelemetryManager.session = jsonResponse.data.session;
                Debug.Log("Telemetry successfully initialized");
            } catch (Exception e)
            {
                Debug.LogError("An error occured with telemetry");
            }
        }
    }

    // The update function to tick per frame.
    private void Update() {
        frameCount++;

        /* Handle key presses */ {
            /*
             Outsourced to
              - N/A
            */
        }

        /* Raycast to find what the user is looking at */ {

            // Make sure the player transform is active before doing the raycas
            if(playerTransform != null)
            {
                RaycastHit hit;
                Ray ray = new Ray(playerTransform.position, playerTransform.forward);
                if (Physics.Raycast(ray, out hit, 100)) {
                    if (hit.transform.gameObject.name == lookingAtTarget) {
                        lookingAtCount++;
                    } else {
                        TelemetryManager.entries.Add(
                            new TelemetryEntry("lookingAt", hit.transform.gameObject.name, (int) (lookingAtCount / (double) 60))
                        );
                        lookingAtTarget = hit.transform.gameObject.name;
                        lookingAtCount = 1;
                    }
                }
            }
        }

        if (frameCount % 60 == 0)
            StartCoroutine(Poll());

        if (frameCount % 600 == 0)
            StartCoroutine(WebManager.SendPayload());

    }

    private IEnumerator Poll() {

        // Ensure player transform is set up before doing anything
        if (playerTransform != null)
        {
            /* Handle Head Rotation */ {
                entries.Add(
                    new TelemetryEntry("playerHeadRotation", Vec3.from(playerTransform.eulerAngles))
                );
            }

            /* Handle Player Position */ {
                entries.Add(
                    new TelemetryEntry("playerPosition", Vec3.from(playerTransform.position))
                );
            }
        }

        yield return null;
    }

    /// <summary>
    /// Update this script's player transform (when the player object changes between scenes)
    /// </summary>
    /// <param name="player"> The new player transform to track </param>
    public void SetPlayerTransform(Transform player)
    {
        this.playerTransform = player;
    }
}