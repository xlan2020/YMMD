using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This class makes a numerator waits for n frames.
 */
public static class WaitFor
{
    public static IEnumerator FramesNum(int frameCount)
    {
        while (frameCount > 0)
        {
            frameCount--;
            // makes the loop wait for 1 frame
            yield return null;
        }
    }
}
