using System;
using UnityEngine;
using RollBall.Cons;
using System.Collections.Generic;

namespace RollBall
{
    [Serializable]
    public sealed class SavedData
    {
        public int bonusTotal;
        public int bonusCount;
        public int helth = 0;
        public bool invulnerability;
        public Vector3Serializable playerPos;
        public List<BonusSave> bonuses;
    }

    [Serializable]
    public struct BonusSave 
    {
        public BonusType bonusType;
        public Vector3Serializable pos;
    }

    [Serializable]
    public struct Vector3Serializable
    {
        public float X;
        public float Y;
        public float Z;
        private Vector3Serializable(float valueX, float valueY, float valueZ)
        {
            X = valueX;
            Y = valueY;
            Z = valueZ;
        }

        public static implicit operator Vector3(Vector3Serializable value)
        {
            return new Vector3(value.X, value.Y, value.Z);
        }

        public static implicit operator Vector3Serializable(Vector3 value)
        {
            return new Vector3Serializable(value.x, value.y, value.z);
        }
    }
}

