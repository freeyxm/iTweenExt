using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[System.Serializable]
public class iTweenScaleModel : iTweenCommTransModel
{
    iTweenScaleModel()
        : base("scale")
    {
    }

    protected override void GetArgs(Hashtable args)
    {
        if (actionType == ActionType.Action_By || actionType == ActionType.Action_Add)
        {
            base.SetTranStr("amount");
        }
        base.GetArgs(args);
    }

    public override void DoAction(GameObject target)
    {
        Hashtable args = new Hashtable();
        GetArgs(args);

        switch (actionType)
        {
            case ActionType.Action_From:
                iTween.ScaleFrom(target, args);
                break;
            case ActionType.Action_To:
                iTween.ScaleTo(target, args);
                break;
            case ActionType.Action_By:
                iTween.ScaleBy(target, args);
                break;
            case ActionType.Action_Add:
                iTween.ScaleAdd(target, args);
                break;
        }
    }
}
