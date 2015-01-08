using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[System.Serializable]
public class iTweenRotateModel : iTweenCommTransModel
{
    iTweenRotateModel()
        : base("rotation")
    {
    }

    /// <summary>
    /// for applying the transformation in either the world coordinate or local cordinate system. Defaults to local space.
    /// </summary>
    public Space space = iTween.Defaults.space;

    /// <summary>
    /// for whether to animate in world space or relative to the parent. False by default.
    /// </summary>
    public bool isLocal = iTween.Defaults.isLocal;

    protected override void GetArgs(Hashtable args)
    {
        base.GetArgs(args);

        if (space != iTween.Defaults.space)
            args.Add("space", space);

        if (isLocal != iTween.Defaults.isLocal)
            args.Add("islocal", isLocal);
    }

    public override void DoAction(GameObject target)
    {
        Hashtable args = new Hashtable();
        GetArgs(args);

        switch (actionType)
        {
            case ActionType.Action_From:
                iTween.RotateFrom(target, args);
                break;
            case ActionType.Action_To:
                iTween.RotateTo(target, args);
                break;
            case ActionType.Action_By:
                iTween.RotateBy(target, args);
                break;
            case ActionType.Action_Add:
                iTween.RotateAdd(target, args);
                break;
        }
    }
}
