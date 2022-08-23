using System;
using System.Collections.Generic;
using UnityEngine;

namespace MH.Mumbler
{
    public class testCol : MonoBehaviour
    {
        void OnCollisionEnter(Collision c)
        {
            Dbg.CLog(this, "{0}: imp: {1}", name, c.impulse.ToString("F3"));
        }
    }
}
