using System;
using System.Collections.Generic;
using System.Data;

namespace CourierManagementAPI.Models.Shared
{
    static class DataReaderExtensions
    {
        public static IDataReader AsDataReader<TSource>(this IEnumerable<IGetValue> Source, int FieldCount)
        {
            return EnumerableDataReader.Create<IGetValue>(Source, FieldCount);
        }
    }

    internal static class EnumerableDataReader
    {
        public static IDataReader Create<TSource>(IEnumerable<IGetValue> Source, int FieldCount)
        {
            return new EnumerableDataReader<TSource>(Source.GetEnumerator(), FieldCount);
        }
    }

    internal class EnumerableDataReader<TSource> : IDataReader
    {
        private readonly IEnumerator<IGetValue> _source;
        private readonly int _fieldCount;

        internal EnumerableDataReader(IEnumerator<IGetValue> Source, int FieldCount)
        {
            _source = Source;
            _fieldCount = FieldCount;

        }

        public void Dispose()
        {
            // Nothing.
        }

        public bool GetBoolean(int i)
        {
            throw new NotImplementedException();
        }

        public byte GetByte(int i)
        {
            throw new NotImplementedException();
        }

        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }

        public char GetChar(int i)
        {
            throw new NotImplementedException();
        }

        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }

        public IDataReader GetData(int i)
        {
            throw new NotImplementedException();
        }

        public string GetDataTypeName(int i)
        {
            throw new NotImplementedException();
        }

        public DateTime GetDateTime(int i)
        {
            throw new NotImplementedException();
        }

        public decimal GetDecimal(int i)
        {
            throw new NotImplementedException();
        }

        public double GetDouble(int i)
        {
            throw new NotImplementedException();
        }

        public Type GetFieldType(int i)
        {
            throw new NotImplementedException();
        }

        public float GetFloat(int i)
        {
            throw new NotImplementedException();
        }

        public Guid GetGuid(int i)
        {
            throw new NotImplementedException();
        }

        public short GetInt16(int i)
        {
            throw new NotImplementedException();
        }

        public int GetInt32(int i)
        {
            throw new NotImplementedException();
        }

        public long GetInt64(int i)
        {
            throw new NotImplementedException();
        }

        public string GetName(int i)
        {
            throw new NotImplementedException();
        }

        public int GetOrdinal(string name)
        {
            throw new NotImplementedException();
        }

        public string GetString(int i)
        {
            throw new NotImplementedException();
        }

        public object GetValue(int i)
        {
            return _source.Current?.GetValue(i);
        }

        public int GetValues(object[] values)
        {
            throw new NotImplementedException();
        }

        public bool IsDBNull(int i)
        {
            return _source.Current?.GetValue(i) == null;
        }

        public int FieldCount
        {
            get { return _fieldCount; }
        }

        public object this[int i] => throw new NotImplementedException();

        public object this[string name] => throw new NotImplementedException();

        public void Close()
        {
            //Nothing to do here;
        }

        public DataTable GetSchemaTable()
        {
            throw new NotImplementedException();
        }

        public bool NextResult()
        {
            throw new NotImplementedException();
        }

        public bool Read()
        {
            return _source.MoveNext();
        }

        public int Depth { get; }
        public bool IsClosed { get; }
        public int RecordsAffected { get; }
    }
}
