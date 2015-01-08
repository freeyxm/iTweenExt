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
    public Vector3[] m_path;

    /// <summary>
    /// for whether to automatically generate a curve from the GameObject's current position to the beginning of the path. True by default.
    /// </summary>
    public bool m_moveToPath = true;

    /// <summary>
    /// for whether or not the GameObject will orient to its direction of travel.  False by default.
    /// </summary>
    public bool m_orientToPath = iTween.Defaults.orientToPath;

    /// <summary>
    /// for a target the GameObject will look at.
    /// </summary>
    public Vector3 m_lookTarget;

    /// <summary>
    /// for the time in seconds the object will take to look at either the "looktarget" or "orienttopath".
    /// </summary>
    public double m_lookTime;

    /// <summary>
    /// for how much of a percentage to look ahead on a path to influence how strict "orientopath" is.
    /// </summary>
    public double m_lookAhead = iTween.Defaults.lookAhead;

    /// <summary>
    /// Restricts rotation to the supplied axis only.
    /// </summary>
    public string m_axis;

    /// <summary>
    /// for whether to animate in world space or relative to the parent. False by default.
    /// </summary>
    public bool m_isLocal = iTween.Defaults.isLocal;

    /// <summary>
    /// for applying the transformation in either the world coordinate or local cordinate system. Defaults to local space.
    /// </summary>
    public Space m_space = iTween.Defaults.space;

    protected override void GetArgs(Hashtable args)
    {
        if (m_actionType == ActionType.Action_By || m_actionType == ActionType.Action_Add)
        {
            base.SetTranStr("amount");
        }
        base.GetArgs(args);

        if (m_path.Length > 0)
            args.Add("path", m_path);

        if (m_moveToPath != false)
            args.Add("movetopath", m_moveToPath);

        if (m_orientToPath != iTween.Defaults.orientToPath)
            args.Add("orienttopath", m_orientToPath);

        if (!m_lookTarget.Equals(Vector3.zero))
            args.Add("looktarget", m_lookTarget);

        if (!m_lookTime.Equals(0.0))
            args.Add("looktime", m_lookTime);

        if (!m_lookAhead.Equals(iTween.Defaults.lookAhead))
            args.Add("lookahead", m_lookAhead);

        if (m_isLocal != iTween.Defaults.isLocal)
            args.Add("islocal", m_isLocal);

        if (!string.IsNullOrEmpty(m_axis))
            args.Add("axis", m_axis);

        if (m_space != iTween.Defaults.space)
            args.Add("space", m_space);
    }

    public override void DoAction(GameObject target)
    {
        Hashtable args = new Hashtable();
        GetArgs(args);

        base.DoAction(target);

        switch (m_actionType)
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
