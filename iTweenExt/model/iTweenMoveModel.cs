using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[System.Serializable]
public class iTweenMoveModel : iTweenCommTransModel
{
    iTweenMoveModel()
        : base("position")
    {
    }

    /// <summary>
    /// for a list of points to draw a Catmull-Rom through for a curved animation path.
    /// </summary>
    public Vector3[] path;

    /// <summary>
    /// for whether to automatically generate a curve from the GameObject's current position to the beginning of the path. True by default.
    /// </summary>
    public bool moveToPath = true;

    /// <summary>
    /// for whether or not the GameObject will orient to its direction of travel.  False by default.
    /// </summary>
    public bool orientToPath = iTween.Defaults.orientToPath;

    /// <summary>
    /// for a target the GameObject will look at.
    /// </summary>
    public Vector3 lookTarget;

    /// <summary>
    /// for the time in seconds the object will take to look at either the "looktarget" or "orienttopath".
    /// </summary>
    public double lookTime;

    /// <summary>
    /// for how much of a percentage to look ahead on a path to influence how strict "orientopath" is.
    /// </summary>
    public double lookAhead = iTween.Defaults.lookAhead;

    /// <summary>
    /// for whether to animate in world space or relative to the parent. False by default.
    /// </summary>
    public bool isLocal = iTween.Defaults.isLocal;

    /// <summary>
    /// Restricts rotation to the supplied axis only.
    /// </summary>
    public string axis;

    /// <summary>
    /// for applying the transformation in either the world coordinate or local cordinate system. Defaults to local space.
    /// </summary>
    public Space space = iTween.Defaults.space;

    protected override void GetArgs(Hashtable args)
    {
        base.GetArgs(args);

        if (path.Length > 0)
            args.Add("path", path);

        if (moveToPath != false)
            args.Add("movetopath", moveToPath);

        if (orientToPath != iTween.Defaults.orientToPath)
            args.Add("orienttopath", orientToPath);

        if (!lookTarget.Equals(Vector3.zero))
            args.Add("looktarget", lookTarget);

        if (!lookTime.Equals(0.0))
            args.Add("looktime", lookTime);

        if (!lookAhead.Equals(iTween.Defaults.lookAhead))
            args.Add("lookahead", lookAhead);

        if (isLocal != iTween.Defaults.isLocal)
            args.Add("islocal", isLocal);

        if (!string.IsNullOrEmpty(axis))
            args.Add("axis", axis);

        if (space != iTween.Defaults.space)
            args.Add("space", space);
    }

    public override void DoAction(GameObject target)
    {
        Hashtable args = new Hashtable();
        GetArgs(args);

        base.DoAction(target);

        switch (actionType)
        {
            case ActionType.Action_From:
                iTween.MoveFrom(target, args);
                break;
            case ActionType.Action_To:
                iTween.MoveTo(target, args);
                break;
            case ActionType.Action_By:
                iTween.MoveBy(target, args);
                break;
            case ActionType.Action_Add:
                iTween.MoveAdd(target, args);
                break;
        }
    }
}
