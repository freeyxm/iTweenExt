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
    public double m_time = iTween.Defaults.time;

    /// <summary>
    /// for the time in seconds the animation will wait before beginning.
    /// </summary>
    public double m_delay = iTween.Defaults.delay;

    /// <summary>
    /// can be used instead of time to allow animation based on speed.
    /// </summary>
    public double m_speed = 0.0;

    /// <summary>
    /// for the shape of the easing curve applied to the animation.
    /// </summary>
    public iTween.EaseType m_easeType = iTween.Defaults.easeType;

    /// <summary>
    /// for the type of loop to apply once the animation has completed.
    /// </summary>
    public iTween.LoopType m_loopType = iTween.Defaults.loopType;

    protected override void GetArgs(Hashtable args)
    {
        base.GetArgs(args);

        if (!m_time.Equals(iTween.Defaults.time))
            args.Add("time", m_time);

        if (!m_delay.Equals(iTween.Defaults.delay))
            args.Add("delay", m_delay);

        if (!m_speed.Equals(0.0))
            args.Add("speed", m_speed);

        if (m_easeType != iTween.Defaults.easeType)
            args.Add("easetype", m_easeType);

        if (m_loopType != iTween.Defaults.loopType)
            args.Add("looptype", m_loopType);
    }

    public virtual void DoAction(GameObject go)
    {
    }
}
