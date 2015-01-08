using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[System.Serializable]
public class iTweenCommModel : iTweenMethodsModel
{
    public enum ActionType
    {
        Action_From,
        Action_To,
        Action_By,
        Action_Add,
    }

    /// <summary>
    /// for the time in seconds the animation will take to complete.
    /// </summary>
    public double time = iTween.Defaults.time;

    /// <summary>
    /// for the time in seconds the animation will wait before beginning.
    /// </summary>
    public double delay = iTween.Defaults.delay;

    /// <summary>
    /// can be used instead of time to allow animation based on speed.
    /// </summary>
    public double speed = 0.0;

    /// <summary>
    /// for the shape of the easing curve applied to the animation.
    /// </summary>
    public iTween.EaseType easeType = iTween.Defaults.easeType;

    /// <summary>
    /// for the type of loop to apply once the animation has completed.
    /// </summary>
    public iTween.LoopType loopType = iTween.Defaults.loopType;

    protected override void GetArgs(Hashtable args)
    {
        base.GetArgs(args);

        if (!time.Equals(iTween.Defaults.time))
            args.Add("time", time);

        if (!delay.Equals(iTween.Defaults.delay))
            args.Add("delay", delay);

        if (!speed.Equals(0.0))
            args.Add("speed", speed);

        if (easeType != iTween.Defaults.easeType)
            args.Add("easetype", easeType);

        if (loopType != iTween.Defaults.loopType)
            args.Add("looptype", loopType);
    }

    public virtual void DoAction(GameObject go)
    {
    }
}
