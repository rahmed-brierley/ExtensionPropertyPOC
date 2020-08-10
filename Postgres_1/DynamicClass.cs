using System;
using System.Collections.Generic;
using System.Dynamic;
using Postgres_1.ProductsAndStores;

namespace Postgres_1
{
    public class DynamicClass : DynamicObject
    {
        private Dictionary<string, KeyValuePair<Type, object>> _fields;

        public DynamicClass(List<ExtensionProperty> fields)
        {
            _fields = new Dictionary<string, KeyValuePair<Type, object>>();
            fields.ForEach(x => _fields.Add(x.ColumnName,
                new KeyValuePair<Type, object>(typeof(string), null)));
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (_fields.ContainsKey(binder.Name))
            {
                var type = _fields[binder.Name].Key;
                if (value.GetType() == type)
                {
                    _fields[binder.Name] = new KeyValuePair<Type, object>(type, value);
                    return true;
                }
                else throw new Exception("Value " + value + " is not of type " + type.Name);
            }
            return false;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = _fields[binder.Name].Value;
            return true;
        }
    }




}
