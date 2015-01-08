using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[System.Serializable]
public class iTweenLookModel : iTweenCommModel
{
    public ActionType actionType;

    /// <summary>
    /// for a target the GameObject will look at.
    /// </summary>
    public Vector3 lookTarget;

    /// <summary>
    /// Restricts rotation to the supplied axis only.
    /// </summary>
    public string axis;

    protected override void GetArgs(Hashtable args)
    {
        base.GetArgs(args);

        if (!lookTarget.Equals(Vector3.zero))
            args.Add("looktarget", lookTarget);

        if (!string.IsNullOrEmpty(axis))
            args.Add("axis", axis);
    }

    public void DoAction(GameObject target)
    {
        Hashtable args = new Hashtable();
        GetArgs(args);

        if (actionType == ActionType.Action_From)
            iTween.LookFrom(target, args);
        else
            iTween.LookTo(target, args);
    }
}
