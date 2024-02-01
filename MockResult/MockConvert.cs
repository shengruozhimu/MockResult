using System;
using System.Collections;
using System.Linq;
using System.Reflection;

namespace MockResult
{
    public static class MockConvert
    {
        volatile static int LEN = 3;

        volatile static int DEEP = 4;

        static object lenObj = new object();

        static object deepObj = new object();

        public static void SetLength(int len)
        {
            lock (lenObj)
            {
                LEN = len;
            }
        }

        public static void SetDeep(int deep)
        {
            lock (deepObj)
            {
                DEEP = deep;
            }
        }

        private static bool IsAssignableFromIEnumerable(this Type t)
        {
            return typeof(IEnumerable).IsAssignableFrom(t);
        }

        static Guid _objectGuid = typeof(object).GUID;
        static Guid _boolGuid = typeof(bool).GUID;
        static Guid _byteGuid = typeof(byte).GUID;
        static Guid _sbyteGuid = typeof(sbyte).GUID;
        static Guid _shortGuid = typeof(short).GUID;
        static Guid _ushortGuid = typeof(ushort).GUID;
        static Guid _intGuid = typeof(int).GUID;
        static Guid _uintGuid = typeof(uint).GUID;
        static Guid _longGuid = typeof(long).GUID;
        static Guid _ulongGuid = typeof(ulong).GUID;
        static Guid _doubleGuid = typeof(double).GUID;
        static Guid _floatGuid = typeof(float).GUID;
        static Guid _decimalGuid = typeof(decimal).GUID;
        static Guid _stringGuid = typeof(string).GUID;
        static Guid _dateTimeGuid = typeof(DateTime).GUID;
        static Guid _dateTimeOffsetGuid = typeof(DateTimeOffset).GUID;
        static Guid _guidGuid = typeof(Guid).GUID;
        static Guid _nullableGenericGuid = typeof(Nullable<>).GUID;

        static bool IsStructDefaultValue(Type type,object value)
        {
            if(type == null) return false;
            if (type.GUID == _objectGuid) return value == null;
            if (type.GUID == _boolGuid) return (bool)value == default(bool);
            if (type.GUID == _byteGuid) return (byte)value == default(byte);
            if (type.GUID == _sbyteGuid) return (sbyte)value == default(sbyte);
            if (type.GUID == _shortGuid) return (short)value == default(short);
            if (type.GUID == _ushortGuid) return (ushort)value == default(ushort);
            if (type.GUID == _longGuid) return (long)value == default(long);
            if (type.GUID == _uintGuid) return (uint)value == default(uint);
            if (type.GUID == _ulongGuid) return (ulong)value == default(ulong);
            if (type.GUID == _longGuid) return (long)value == default(long);
            if (type.GUID == _doubleGuid) return (double)value == default(double);
            if (type.GUID == _floatGuid) return (float)value == default(float);
            if (type.GUID == _decimalGuid) return (decimal)value == default(decimal);
            if (type.GUID == _stringGuid) return (string)value == string.Empty || (string)value == default(string);
            if (type.GUID == _dateTimeGuid) return (DateTime)value == default(DateTime);
            if (type.GUID == _dateTimeOffsetGuid) return (DateTimeOffset)value == default(DateTimeOffset);
            if (type.GUID == _nullableGenericGuid) return IsStructDefaultValue(type.GenericTypeArguments.FirstOrDefault(), value);
            return true;
        }

        static object NewObject(Type t,int deep, MemberInfo memberInfo = null)
        {
            if (t.GUID == _objectGuid) return new object();
            else if (t.GUID == _boolGuid) return Extentions.RollBoolean(memberInfo);
            else if (t.GUID == _byteGuid) return Extentions.RollByte(memberInfo);
            else if (t.GUID == _sbyteGuid) return Extentions.RollSByte(memberInfo);
            else if (t.GUID == _shortGuid) return Extentions.RollShort(memberInfo);
            else if (t.GUID == _ushortGuid) return Extentions.RollUShort(memberInfo);
            else if (t.GUID == _intGuid) return Extentions.RollInt(memberInfo);
            else if (t.GUID == _uintGuid) return Extentions.RollUInt(memberInfo);
            else if (t.GUID == _longGuid) return Extentions.RollLong(memberInfo);
            else if (t.GUID == _ulongGuid) return Extentions.RollULong(memberInfo);
            else if (t.GUID == _doubleGuid) return Extentions.RollDouble(memberInfo);
            else if (t.GUID == _floatGuid) return Extentions.RollFloat(memberInfo);
            else if (t.GUID == _decimalGuid) return Extentions.RollDecimal(memberInfo);
            else if (t.GUID == _dateTimeGuid) return Extentions.RollDateTime(memberInfo);
            else if (t.GUID == _dateTimeOffsetGuid) return Extentions.RollDateTimeOffset(memberInfo);
            else if (t.GUID == _guidGuid) return Extentions.RollGuid(memberInfo);
            else if (t.GUID == _stringGuid) return Extentions.RollString(memberInfo);
            else if (t.GUID == _nullableGenericGuid) return NewObject(Nullable.GetUnderlyingType(t),deep,memberInfo);
            else if (t.IsEnum)
            {
                if (typeof(byte).IsAssignableFrom(t)) return Enum.ToObject(t, Extentions.RollByte(memberInfo));
                if (typeof(sbyte).IsAssignableFrom(t)) return Enum.ToObject(t, Extentions.RollSByte(memberInfo));
                if (typeof(short).IsAssignableFrom(t)) return Enum.ToObject(t, Extentions.RollShort(memberInfo));
                if (typeof(ushort).IsAssignableFrom(t)) return Enum.ToObject(t, Extentions.RollUShort(memberInfo));
                if (typeof(int).IsAssignableFrom(t)) return Enum.ToObject(t, Extentions.RollInt(memberInfo));
                if (typeof(uint).IsAssignableFrom(t)) return Enum.ToObject(t, Extentions.RollUInt(memberInfo));
                if (typeof(long).IsAssignableFrom(t)) return Enum.ToObject(t, Extentions.RollLong(memberInfo));
                if (typeof(ulong).IsAssignableFrom(t)) return Enum.ToObject(t, Extentions.RollULong(memberInfo));
                return 0;
            }
            else if (t.IsArray)
            {
                var arr = Array.CreateInstance(t.GetElementType(), LEN);
                foreach (var index in Enumerable.Range(0, LEN))
                {
                    if (deep  < DEEP) 
                        arr.SetValue(NewObject(t.GetElementType(), deep+1, memberInfo), index);
                }
                return arr;
            }
            else if (t.IsInterface || t.IsAbstract)
            {
                return null;
            }
            else if (t.IsAssignableFromIEnumerable())
            {
                var enumer = Activator.CreateInstance(t);
                var add = t.GetMethod("Add") ?? t.GetMethod("TryAdd");
                if (add != null)
                {
                    foreach (var index in Enumerable.Range(0, LEN))
                    {
                        var parameters = add.GetParameters();
                        if (parameters.Any())
                        {
                            if (deep < DEEP)
                                add.Invoke(enumer, parameters.Select(x => NewObject(x.ParameterType, deep+1, memberInfo)).ToArray());
                        }

                    }
                }
                return enumer;
            }
            else if (t.IsClass || t.IsAnsiClass)
            {
                var construct = t.GetConstructors().OrderBy(x => x.GetParameters().Length).ToArray();
                var argsTypes = construct.First().GetParameters();
                object obj = null;
                if (deep < DEEP)
                {
                    if (argsTypes.Any())
                    {

                        obj = Activator.CreateInstance(t, argsTypes.Select(x => NewObject(x.ParameterType, deep + 1)).ToArray());
                    }
                    else
                    {
                        obj = Activator.CreateInstance(t);
                    }

                    var pps = t.GetProperties(BindingFlags.Public |BindingFlags.NonPublic
                        | BindingFlags.Instance
                        | BindingFlags.CreateInstance
                        | BindingFlags.Static);
                    foreach (var pp in pps)
                    {
                        var pt = pp.PropertyType;
                        if (deep < DEEP && pp.CanWrite)
                        {
                            if (pp.CanRead)
                            {
                                object oldValue = pp.GetValue(obj);
                                if (IsStructDefaultValue(pt, oldValue))
                                {
                                    pp.SetValue(obj, NewObject(pt, deep + 1, pp));
                                }
                            }


                        }
   
                    }
                }
                return obj;
            }
            else
                return null;
        }

        public static T NewObject<T>()
        {
            return (T)NewObject(typeof(T),0);
        }
    }
}
