using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[System.Serializable]
public class iTweenLookModel : iTweenCommModel
{
    public ActionType m_actionType;

    /// <summary>
    /// for a target the GameObject will look at.
    /// </summary>
    public Vector3 m_lookTarget;

    /// <summary>
    /// Restricts rotation to the supplied axis only.
    /// </summary>
    public string m_axis;

    protected override void GetArgs(Hashtable args)
    {
        base.GetArgs(args);

        if (!m_lookTarget.Equals(Vector3.zero))
            args.Add("looktarget", m_lookTarget);

        if (!string.IsNullOrEmpty(m_axis))
            args.Add("axis", m_axis);
    }

    public void DoAction(GameObject target)
    {
        Hashtable args = new Hashtable();
        GetArgs(args);

        if (m_actionType == ActionType.Action_From)
            iTween.LookFrom(target, args);
        else
            iTween.LookTo(target, args);
    }
}
