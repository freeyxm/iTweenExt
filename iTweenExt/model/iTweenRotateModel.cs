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
    public Space m_space = iTween.Defaults.space;

    /// <summary>
    /// for whether to animate in world space or relative to the parent. False by default.
    /// </summary>
    public bool m_isLocal = iTween.Defaults.isLocal;

    protected override void GetArgs(Hashtable args)
    {
        if (m_actionType == ActionType.Action_By || m_actionType == ActionType.Action_Add)
        {
            base.SetTranStr("amount");
        }
        base.GetArgs(args);

        if (m_space != iTween.Defaults.space)
            args.Add("space", m_space);

        if (m_isLocal != iTween.Defaults.isLocal)
            args.Add("islocal", m_isLocal);
    }

    public override void DoAction(GameObject target)
    {
        Hashtable args = new Hashtable();
        GetArgs(args);

        switch (m_actionType)
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
