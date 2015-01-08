﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class iTweenFade : iTweenBase
{
    public iTweenFadeModel[] actions = new iTweenFadeModel[1];

    public override bool StartITweenAction(string name)
    {
        bool flag = base.StartITweenAction(name);
        if (flag)
        {
            for (int i = 0; i < actions.Length; ++i)
            {
                iTweenFadeModel action = actions[i];
                action.DoAction(this.gameObject);
            }
        }
        return flag;
    }
}

