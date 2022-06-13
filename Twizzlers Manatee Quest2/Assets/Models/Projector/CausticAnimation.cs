using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Repeatedly changes the texture on a material to animate it on a loop.
/// 
/// @author Original author not specified
/// @author Alex Wills
/// Updated June 11, 2022
/// </summary>
public class CausticAnimation : MonoBehaviour
{
    [Tooltip("How many frames in the animation to go through in one second.")]
    public float FPS = 30.0f;

    [Tooltip("List of all the frames in the animation to loop through.")]
    public Texture[] causticsTextures;

    private int currentCaustic = 0;
    private Material causticsMat;

    private float timeDelay;

    // Start is called before the first frame update
    void Start()
    {
        causticsMat = GetComponent<Projector>().material;

        timeDelay = 1.0f / FPS;
        StartCoroutine(ChangeCaustics());
    }

    // Deprecated
    void ChangeCaustic()
    {
        currentCaustic = (currentCaustic + 1) % causticsTextures.Length;
        causticsMat.SetTexture("_ShadowTex", causticsTextures[currentCaustic]);
    }

    /// <summary>
    /// Coroutine to iterate through the list of textures at the specified framerate.
    /// </summary>
    /// <returns></returns>
    private IEnumerator ChangeCaustics()
    {
        while (true)
        {
            // Switch to the next texture
            currentCaustic = (currentCaustic + 1) % causticsTextures.Length;
            causticsMat.SetTexture("_ShadowTex", causticsTextures[currentCaustic]);

            // Wait for the calculated time between frames
            yield return new WaitForSeconds(timeDelay);
        }
    }
}
