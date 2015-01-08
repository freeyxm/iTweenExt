using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class iTweenBase : MonoBehaviour
{
    public string mName;

    public virtual bool StartITweenAction(string name)
    {
        return (string.IsNullOrEmpty(mName) || mName.Equals(name) || "_ALL_".Equals(name));
    }
}
