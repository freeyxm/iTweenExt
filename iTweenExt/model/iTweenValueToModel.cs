using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[System.Serializable]
public class iTweenValueToModel : iTweenCommModel
{
    public enum ValueType
    {
        _Single,
        _Vector2,
        _Vector3,
        _Color,
        _Rect,
    }

    [System.Serializable]
    public struct Value
    {
        public Single _single;
        public Vector2 vec2;
        public Vector3 vec3;
        public Color color;
        public Rect rect;
    };
    public ValueType valueType;
    public Value from;
    public Value to;

    protected override void GetArgs(Hashtable args)
    {
        base.GetArgs(args);

        switch (valueType)
        {
            case ValueType._Single:
                args.Add("from", from._single);
                args.Add("to", to._single);
                break;
            case ValueType._Vector2:
                args.Add("from", from.vec2);
                args.Add("to", to.vec2);
                break;
            case ValueType._Vector3:
                args.Add("from", from.vec3);
                args.Add("to", to.vec3);
                break;
            case ValueType._Color:
                args.Add("from", from.color);
                args.Add("to", to.color);
                break;
            case ValueType._Rect:
                args.Add("from", from.rect);
                args.Add("to", to.rect);
                break;
        }
    }

    public override void DoAction(GameObject target)
    {
        Hashtable args = new Hashtable();
        GetArgs(args);

        iTween.ValueTo(target, args);
    }
}
