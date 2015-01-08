using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[System.Serializable]
public class iTweenCommTransModel : iTweenCommModel
{
    public enum AxisType
    {
        Axis_A = 0x00,
        Axis_X = 0x01,
        Axis_Y = 0x02,
        Axis_Z = 0x04,
        Axis_XY = 0x80 | Axis_X | Axis_Y,
        Axis_XZ = 0x80 | Axis_X | Axis_Z,
        Axis_YZ = 0x80 | Axis_Y | Axis_Z,
        Axis_XYZ = 0x80 | Axis_X | Axis_Y | Axis_Z,
    }

    protected string mTranStr;
    protected iTweenCommTransModel(string _tranStr)
    {
        mTranStr = _tranStr;
    }

    public ActionType actionType;

    [System.Serializable]
    public struct Target
    {
        /// <summary>
        /// deside which param will be use: scale,x,y,z
        /// </summary>
        public AxisType type;

        /// <summary>
        /// for the final scale.
        /// </summary>
        public Vector3 value;

        /// <summary>
        /// for the individual setting of the x axis.
        /// </summary>
        public double x;
        /// <summary>
        /// for the individual setting of the y axis.
        /// </summary>
        public double y;
        /// <summary>
        /// for the individual setting of the z axis.
        /// </summary>
        public double z;
    };
    public Target target;

    protected override void GetArgs(Hashtable args)
    {
        base.GetArgs(args);

        if (target.type == AxisType.Axis_A && !string.IsNullOrEmpty(mTranStr))
        {
            args.Add(mTranStr, target.value);
        }
        else
        {
            if ((target.type & AxisType.Axis_X) != 0)
                args.Add("x", target.x);
            if ((target.type & AxisType.Axis_Y) != 0)
                args.Add("y", target.y);
            if ((target.type & AxisType.Axis_Z) != 0)
                args.Add("z", target.z);
        }
    }

    protected void SetTranStr(string _tranStr)
    {
        mTranStr = _tranStr;
    }
}
