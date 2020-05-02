using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text;

namespace DapperContracts.CLR
{
    public struct Date : IComparable, IComparable<Date>, IEquatable<Date>, IFormattable, ISerializable, IConvertible
    {
        private readonly DateTime DateTime;

        private IConvertible Convertible => DateTime;

        public static Date Parse(string value)
        {
            var dateTime = DateTime.Parse(value.Substring(0, 10), null, DateTimeStyles.AssumeLocal);
            return new Date(dateTime);
        }

        public Date(DateTime dateTime)
        {
            DateTime = dateTime.Date;
        }

        public Date(int year, int month, int day)
        {
            DateTime = new DateTime(year, month, day);
        }

        public Date(int year, int month, int day, Calendar calendar)
        {
            DateTime = new DateTime(year, month, day, calendar);
        }

        private Date(SerializationInfo info, StreamingContext context)
        {
            DateTime = (DateTime)info.GetValue(nameof(DateTime), typeof(DateTime));
        }

        public int CompareTo(Date other)
        {
            return DateTime.CompareTo(other.DateTime);
        }

        public int CompareTo(object obj)
        {
            if (obj is Date date)
                return CompareTo(date);
            if (obj is DateTime datetime)
                return DateTime.CompareTo(datetime);
            return 0;
        }

        public bool Equals(Date other)
        {
            return DateTime.Ticks == other.DateTime.Ticks;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(DateTime), DateTime);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return DateTime.ToString(format, formatProvider);
        }

        TypeCode IConvertible.GetTypeCode()
        {
            return Convertible.GetTypeCode();
        }

        bool IConvertible.ToBoolean(IFormatProvider provider)
        {
            return Convertible.ToBoolean(provider);
        }

        byte IConvertible.ToByte(IFormatProvider provider)
        {
            return Convertible.ToByte(provider);
        }

        char IConvertible.ToChar(IFormatProvider provider)
        {
            return Convertible.ToChar(provider);
        }

        DateTime IConvertible.ToDateTime(IFormatProvider provider)
        {
            return new DateTime(DateTime.Ticks);
        }

        decimal IConvertible.ToDecimal(IFormatProvider provider)
        {
            return Convertible.ToDecimal(provider);
        }

        double IConvertible.ToDouble(IFormatProvider provider)
        {
            return Convertible.ToDouble(provider);
        }

        short IConvertible.ToInt16(IFormatProvider provider)
        {
            return Convertible.ToInt16(provider);
        }

        int IConvertible.ToInt32(IFormatProvider provider)
        {
            return Convertible.ToInt32(provider);
        }

        long IConvertible.ToInt64(IFormatProvider provider)
        {
            return Convertible.ToInt64(provider);
        }

        sbyte IConvertible.ToSByte(IFormatProvider provider)
        {
            return Convertible.ToSByte(provider);
        }

        float IConvertible.ToSingle(IFormatProvider provider)
        {
            return Convertible.ToSingle(provider);
        }

        string IConvertible.ToString(IFormatProvider provider)
        {
            return Convertible.ToString(provider);
        }

        object IConvertible.ToType(Type conversionType, IFormatProvider provider)
        {
            return Convertible.ToType(conversionType, provider);
        }

        ushort IConvertible.ToUInt16(IFormatProvider provider)
        {
            return Convertible.ToUInt16(provider);
        }

        uint IConvertible.ToUInt32(IFormatProvider provider)
        {
            return Convertible.ToUInt32(provider);
        }

        ulong IConvertible.ToUInt64(IFormatProvider provider)
        {
            return Convertible.ToUInt64(provider);
        }

        public static implicit operator Date(DateTime dateTime)
        {
            return new Date(dateTime);
        }

        public static implicit operator Date?(DateTime? dateTime)
        {
            return dateTime.HasValue ? new Date(dateTime.Value) : (Date?)null;
        }
    }
}
