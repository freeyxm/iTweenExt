using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[System.Serializable]
public class iTweenTransformModel : iTweenCommTransModel
{
    public enum TranType
    {
        PunchPosition,
        PunchRotation,
        PunchScale,
        ShakePosition,
        ShakeRotation,
        ShakeScale,
    }

    iTweenTransformModel()
        : base("amount")
    {
    }

    public TranType tranType;

    /// <summary>
    /// for applying the transformation in either the world coordinate or local cordinate system. Defaults to local space.
    /// </summary>
    public Space space = iTween.Defaults.space;

    /// <summary>
    /// for whether or not the GameObject will orient to its direction of travel.  False by default.
    /// </summary>
    public bool orientToPath = iTween.Defaults.orientToPath;

    /// <summary>
    /// for a target the GameObject will look at.
    /// </summary>
    public Vector3 lookTarget;

    /// <summary>
    /// for the time in seconds the object will take to look at either the "looktarget".
    /// </summary>
    public double lookTime;

    protected override void GetArgs(Hashtable args)
    {
        base.GetArgs(args);

        if (space != iTween.Defaults.space)
            args.Add("space", space);

        if (orientToPath != iTween.Defaults.orientToPath)
            args.Add("orienttopath", orientToPath);

        if (lookTarget != null)
            args.Add("looktarget", lookTarget);

        if (!lookTime.Equals(0.0))
            args.Add("looktime", lookTime);
    }

    public override void DoAction(GameObject target)
    {
        Hashtable args = new Hashtable();
        GetArgs(args);

        switch (tranType)
        {
            case TranType.PunchPosition:
                iTween.PunchPosition(target, args);
                break;
            case TranType.PunchRotation:
                iTween.PunchRotation(target, args);
                break;
            case TranType.PunchScale:
                iTween.PunchScale(target, args);
                break;
            case TranType.ShakePosition:
                iTween.ShakePosition(target, args);
                break;
            case TranType.ShakeRotation:
                iTween.ShakeRotation(target, args);
                break;
            case TranType.ShakeScale:
                iTween.ShakeScale(target, args);
                break;
        }
    }
}
