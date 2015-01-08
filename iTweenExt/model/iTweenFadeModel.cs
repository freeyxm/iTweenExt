using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[System.Serializable]
public class iTweenFadeModel : iTweenCommModel
{
    public ActionType actionType;

    /// <summary>
    /// for the initial alpha value of the animation.
    /// </summary>
    public double alpha;

    /// <summary>
    /// for the initial alpha value of the animation.
    /// </summary>
    public double amount;

    /// <summary>
    /// for whether or not to include children of this GameObject. True by default.
    /// </summary>
    public bool includeChildren = true;

    protected override void GetArgs(Hashtable args)
    {
        base.GetArgs(args);

        args.Add("alpha", alpha);

        if (!amount.Equals(0.0))
            args.Add("amount", amount);

        if (includeChildren != false)
            args.Add("includechildren", includeChildren);
    }

    public void DoAction(GameObject target)
    {
        Hashtable args = new Hashtable();
        GetArgs(args);

        if (actionType == ActionType.Action_From)
            iTween.FadeFrom(target, args);
        else
            iTween.FadeTo(target, args);
    }
}
