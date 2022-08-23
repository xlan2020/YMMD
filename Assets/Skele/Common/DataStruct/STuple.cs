using System;
using System.Collections.Generic;

namespace MH
{
    /// <summary>
    /// struct tuple
    /// </summary>
    [Serializable]
    public struct STuple<T0, T1>
    {
        public T0 v0;
        public T1 v1;

        public STuple(T0 v0, T1 v1) { this.v0 = v0; this.v1 = v1; }
    }

    /// <summary>
    /// struct tuple
    /// </summary>
    [Serializable]
    public struct STuple<T0, T1, T2>
    {
        public T0 v0;
        public T1 v1;
        public T2 v2;

        public STuple(T0 v0, T1 v1, T2 v2) { this.v0 = v0; this.v1 = v1; this.v2 = v2;}
    }

    /// <summary>
    /// struct tuple
    /// </summary>
    [Serializable]
    public struct STuple<T0, T1, T2, T3>
    {
        public T0 v0;
        public T1 v1;
        public T2 v2;
        public T3 v3;

        public STuple(T0 v0, T1 v1, T2 v2, T3 v3) { this.v0 = v0; this.v1 = v1; this.v2 = v2; this.v3 = v3;}
    }

    /// <summary>
    /// struct tuple
    /// </summary>
    [Serializable]
    public struct STuple<T0, T1, T2, T3, T4>
    {
        public T0 v0;
        public T1 v1;
        public T2 v2;
        public T3 v3;
        public T4 v4;

        public STuple(T0 v0, T1 v1, T2 v2, T3 v3, T4 v4) { this.v0 = v0; this.v1 = v1; this.v2 = v2; this.v3 = v3; this.v4 = v4;}
    }

    /// <summary>
    /// struct tuple
    /// </summary>
    [Serializable]
    public struct STuple<T0, T1, T2, T3, T4, T5>
    {
        public T0 v0;
        public T1 v1;
        public T2 v2;
        public T3 v3;
        public T4 v4;
        public T5 v5;

        public STuple(T0 v0, T1 v1, T2 v2, T3 v3, T4 v4, T5 v5) { this.v0 = v0; this.v1 = v1; this.v2 = v2; this.v3 = v3; this.v4 = v4; this.v5 = v5;}
    }
}
