using System;
using System.Collections.Generic;

namespace MH
{
    /// <summary>
    /// struct pair
    /// </summary>
    [Serializable]
    public struct SPair<T, U>
    {
        public T first;
        public U second;

        public SPair(T f, U s) { first = f; second = s; }
        public static SPair<T,U> Create(T f, U s) { return new SPair<T,U>(f, s);}

        public T x { get { return first; } set { first = value; } }
        public U y { get { return second; } set { second = value; } }
        public T v0 { get { return first; } set { first = value; } }
        public U v1 { get { return second; } set { second = value; } }

        //public P v0;
        //public T v1;

        //public SPair(P _v0, T _v1) { v0 = _v0; v1 = _v1; }
    }
}
