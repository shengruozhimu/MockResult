using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Xml;

namespace MockResult
{
    static class Extentions
    {
        private static Random _roll = new Random();

        internal static byte RollByte(MemberInfo memberInfo = null)
        {
            return Convert.ToByte(_roll.Next(byte.MinValue, byte.MaxValue));
        }

        internal static byte RollSByte(MemberInfo memberInfo = null)
        {
            return Convert.ToByte(_roll.Next(sbyte.MinValue, sbyte.MaxValue));
        }

        internal static bool RollBoolean(MemberInfo memberInfo = null)
        {
            return _roll.NextDouble() >= 0.5d;
        }

        internal static int RollInt(MemberInfo memberInfo = null)
        {
            return _roll.Next();
        }

        internal static uint RollUInt(MemberInfo memberInfo = null)
        {
            return (uint)_roll.Next();
        }

        internal static Guid RollGuid(MemberInfo memberInfo = null)
        {
            return Guid.NewGuid();
        }

        internal static string RollString(MemberInfo memberInfo = null)
        {
            if(memberInfo == null) return "";
            return memberInfo.Name.ToUpper();
        }

        internal static decimal RollDecimal(MemberInfo memberInfo = null)
        {
            return Convert.ToDecimal(_roll.Next());
        }

        internal static double RollDouble(MemberInfo memberInfo = null)
        {
            return _roll.NextDouble() * 10000.0d;
        }

        internal static float RollFloat(MemberInfo memberInfo = null)
        {
            return (float)_roll.NextDouble() * 10000f;
        }

        internal static long RollLong(MemberInfo memberInfo = null)
        {
            return _roll.Next();
        }

        internal static ulong RollULong(MemberInfo memberInfo = null)
        {
            return (ulong)_roll.Next();
        }

        internal static short RollShort(MemberInfo memberInfo = null)
        {
            return (short)_roll.Next();
        }

        internal static ushort RollUShort(MemberInfo memberInfo = null)
        {
            return (ushort)_roll.Next();
        }

        internal static DateTime RollDateTime(MemberInfo memberInfo = null)
        {
            return DateTime.Now.AddSeconds(-RollInt());
        }

        internal static DateTimeOffset RollDateTimeOffset(MemberInfo memberInfo = null)
        {
            return new DateTimeOffset(RollDateTime());
        }
    }
}
