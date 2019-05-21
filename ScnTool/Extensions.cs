using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Windows.Forms;

namespace NetsphereScnTool
{
    public static class ResourceExtensions
    {
        internal static Matrix4x4 ReadMatrix(this BinaryReader r)
        {
            return new Matrix4x4(
                r.ReadSingle(), r.ReadSingle(), r.ReadSingle(), r.ReadSingle(),
                r.ReadSingle(), r.ReadSingle(), r.ReadSingle(), r.ReadSingle(),
                r.ReadSingle(), r.ReadSingle(), r.ReadSingle(), r.ReadSingle(),
                r.ReadSingle(), r.ReadSingle(), r.ReadSingle(), r.ReadSingle()
                );
        }

        internal static void Write(this BinaryWriter w, Matrix4x4 value)
        {
            w.Write(value.M11);
            w.Write(value.M12);
            w.Write(value.M13);
            w.Write(value.M14);

            w.Write(value.M21);
            w.Write(value.M22);
            w.Write(value.M23);
            w.Write(value.M24);

            w.Write(value.M31);
            w.Write(value.M32);
            w.Write(value.M33);
            w.Write(value.M34);

            w.Write(value.M41);
            w.Write(value.M42);
            w.Write(value.M43);
            w.Write(value.M44);
        }
    }
    public static class Extensions
    {
        public static void EnableOrDisable(ComponentState state, params ToolStripMenuItem[] items)
        {
            for (int i = 0; i < items.Length; i++)
                if (state == ComponentState.Enable)
                    items[i].Enabled = true;
                else
                    items[i].Enabled = false;
        }

        public static void EnableOrDisable(ComponentState state, params Control[] controls)
        {
            for (int i = 0; i < controls.Length; i++)
                if (state == ComponentState.Enable)
                    controls[i].Enabled = true;
                else
                    controls[i].Enabled = false;
        }
    }

    public static class RotationExtensions
    {
        private static readonly float _Rad2Deg = (float)(360 / (Math.PI * 2));

        public static Quaternion ToQuaternion(this Vector3 v)
        {
            float yaw = (float)Deg2Rad(v.Y);
            float pitch = (float)Deg2Rad(v.X);
            float roll = (float)Deg2Rad(v.Z);
            float rollOver2 = roll * 0.5f;
            float sinRollOver2 = (float)Math.Sin(rollOver2);
            float cosRollOver2 = (float)Math.Cos(rollOver2);
            float pitchOver2 = pitch * 0.5f;
            float sinPitchOver2 = (float)Math.Sin(pitchOver2);
            float cosPitchOver2 = (float)Math.Cos(pitchOver2);
            float yawOver2 = yaw * 0.5f;
            float sinYawOver2 = (float)Math.Sin(yawOver2);
            float cosYawOver2 = (float)Math.Cos(yawOver2);
            Quaternion result;
            result.W = cosYawOver2 * cosPitchOver2 * cosRollOver2 + sinYawOver2 * sinPitchOver2 * sinRollOver2;
            result.X = cosYawOver2 * sinPitchOver2 * cosRollOver2 + sinYawOver2 * cosPitchOver2 * sinRollOver2;
            result.Y = sinYawOver2 * cosPitchOver2 * cosRollOver2 - cosYawOver2 * sinPitchOver2 * sinRollOver2;
            result.Z = cosYawOver2 * cosPitchOver2 * sinRollOver2 - sinYawOver2 * sinPitchOver2 * cosRollOver2;

            return result;
        }

        public static Vector3 ToEuler(this Quaternion q1)
        {
            float sqw = q1.W * q1.W;
            float sqx = q1.X * q1.X;
            float sqy = q1.Y * q1.Y;
            float sqz = q1.Z * q1.Z;
            float unit = sqx + sqy + sqz + sqw; // if normalised is one, otherwise is correction factor
            float test = q1.X * q1.W - q1.Y * q1.Z;
            Vector3 v;

            if (test > 0.4995f * unit) // singularity at north pole
            {
                v.Y = (float)(2f * Math.Atan2(q1.Y, q1.X));
                v.X = (float)(Math.PI / 2);
                v.Z = 0;
                return NormalizeAngles(v * _Rad2Deg);
            }
            if (test < -0.4995f * unit) // singularity at south pole
            {
                v.Y = (float)(-2f * Math.Atan2(q1.Y, q1.X));
                v.X = (float)(-Math.PI / 2);
                v.Z = 0;
                return NormalizeAngles(v * _Rad2Deg);
            }
            var q = new Quaternion(q1.W, q1.Z, q1.X, q1.Y);
            v.Y = (float)Math.Atan2(2f * q.X * q.W + 2f * q.Y * q.Z, 1 - 2f * (q.Z * q.Z + q.W * q.W));      // Yaw
            v.X = (float)Math.Asin(2f * (q.X * q.Z - q.W * q.Y));                                            // Pitch
            v.Z = (float)Math.Atan2(2f * q.X * q.Y + 2f * q.Z * q.W, 1 - 2f * (q.Y * q.Y + q.Z * q.Z));      // Roll
            return NormalizeAngles(v * _Rad2Deg);
        }

        private static Vector3 NormalizeAngles(Vector3 angles)
        {
            angles.X = NormalizeAngle(angles.X);
            angles.Y = NormalizeAngle(angles.Y);
            angles.Z = NormalizeAngle(angles.Z);
            return angles;
        }

        private static float NormalizeAngle(float angle)
        {
            while (angle > 360)
                angle -= 360;
            while (angle < 0)
                angle += 360;
            return angle;
        }

        private static double Deg2Rad(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        private static double Rad2Deg(double angle)
        {
            return angle * (180.0 / Math.PI);
        }
    }

    public static class StackExtensions
    {
        public static Stack<T> Reverse<T>(this Stack<T> st)
        {
            var rev = new Stack<T>();

            while (st.Count != 0)
            {
                rev.Push(st.Pop());
            }

            return rev;
        }
    }
}
