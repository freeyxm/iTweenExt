﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class iTweenBase : MonoBehaviour
{
    public string m_name;

    public virtual bool StartITweenAction(string name)
    {
        return (string.IsNullOrEmpty(m_name) || m_name.Equals(name) || "_ALL_".Equals(name));
    }
}
