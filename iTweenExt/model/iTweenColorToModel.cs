﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[System.Serializable]
public class iTweenColorToModel : iTweenCommModel
{
    public ActionType m_actionType;

    public enum ColorType
    {
        Color_C = 0x00,
        Color_R = 0x01,
        Color_G = 0x02,
        Color_B = 0x04,
        Color_A = 0x08,
        Color_RGB = 0x80 | Color_R | Color_G | Color_B,
    }
    [System.Serializable]
    public struct ColorInfo
    {
        public ColorType type;
        /// <summary>
        /// to change the GameObject's color to.
        /// </summary>
        public Color color;
        /// <summary>
        /// for the individual setting of the color red.
        /// </summary>
        public double r;
        /// <summary>
        /// for the individual setting of the color green.
        /// </summary>
        public double g;
        /// <summary>
        /// for the individual setting of the color blue.
        /// </summary>
        public double b;
        /// <summary>
        /// for the individual setting of the color alpha.
        /// </summary>
        public double a;
    }
    public ColorInfo m_color;

    /// <summary>
    /// Many shaders use more than one color. Use can have iTween's Color methods operate on them by name.
    /// </summary>
    public iTween.NamedValueColor m_namedValueColor = iTween.Defaults.namedColorValue;

    /// <summary>
    /// for whether or not to include children of this GameObject. True by default.
    /// </summary>
    public bool m_includeChildren = true;

    protected override void GetArgs(Hashtable args)
    {
        base.GetArgs(args);

        if (m_color.type == ColorType.Color_C)
        {
            args.Add("color", m_color.color);
        }
        else
        {
            if ((m_color.type & ColorType.Color_R) != 0)
                args.Add("r", m_color.r);
            if ((m_color.type & ColorType.Color_G) != 0)
                args.Add("g", m_color.g);
            if ((m_color.type & ColorType.Color_B) != 0)
                args.Add("b", m_color.b);
            if ((m_color.type & ColorType.Color_A) != 0)
                args.Add("a", m_color.a);
        }

        if (!m_namedValueColor.Equals(iTween.Defaults.namedColorValue))
            args.Add("namedcolorvalue", m_namedValueColor);

        if (m_includeChildren != true)
            args.Add("includechildren", m_includeChildren);
    }

    public override void DoAction(GameObject target)
    {
        Hashtable args = new Hashtable();
        GetArgs(args);

        if (m_actionType == ActionType.Action_From)
            iTween.ColorFrom(target, args);
        else
            iTween.ColorTo(target, args);
    }
}
