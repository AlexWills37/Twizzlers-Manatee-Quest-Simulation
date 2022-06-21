using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manatee AI: Sit still for five seconds.
/// 
/// @author Alex Wills
/// Updated: 6/16/2022
/// </summary>
public class ManateeRest : ManateeAction
{
    /// <summary>
    /// Do nothing for five seconds
    /// </summary>
    protected override IEnumerator ActionCoroutine()
    {
        yield return new WaitForSeconds(5f);
        this.EndAction();
    }
}
