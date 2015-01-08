using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[System.Serializable]
public class iTweenMethodsModel
{
    [System.Serializable]
    public struct iTweenMethod
    {
        /// <summary>
        /// for a reference to the GameObject that holds the method.
        /// </summary>
        public GameObject target;
        /// <summary>
        /// for the name of a function to launch.
        /// </summary>
        public string methodName;
        /// <summary>
        /// for arguments to be sent to the method.
        /// </summary>
        public object methodParams;
    }

    [System.Serializable]
    public struct Methods
    {
        public iTweenMethod onstart;
        public iTweenMethod onupdate;
        public iTweenMethod oncomplete;
    }
    public Methods m_methods;

    protected virtual void GetArgs(Hashtable args)
    {
        GetArgs(args, "onstart", m_methods.onstart);
        GetArgs(args, "onupdate", m_methods.onupdate);
        GetArgs(args, "oncomplete", m_methods.oncomplete);
    }

    static void GetArgs(Hashtable args, string name, iTweenMethod method)
    {
        if (method.target != null && !string.IsNullOrEmpty(method.methodName))
        {
            args.Add(name, method.methodName);
            args.Add(name + "target", method.target);
            if (method.methodParams != null)
                args.Add(name + "params", method.methodParams);
        }
    }
}
