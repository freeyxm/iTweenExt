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
    public ValueType m_valueType;
    public Value m_from;
    public Value m_to;

    protected override void GetArgs(Hashtable args)
    {
        base.GetArgs(args);

        switch (m_valueType)
        {
            case ValueType._Single:
                args.Add("from", m_from._single);
                args.Add("to", m_to._single);
                break;
            case ValueType._Vector2:
                args.Add("from", m_from.vec2);
                args.Add("to", m_to.vec2);
                break;
            case ValueType._Vector3:
                args.Add("from", m_from.vec3);
                args.Add("to", m_to.vec3);
                break;
            case ValueType._Color:
                args.Add("from", m_from.color);
                args.Add("to", m_to.color);
                break;
            case ValueType._Rect:
                args.Add("from", m_from.rect);
                args.Add("to", m_to.rect);
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
