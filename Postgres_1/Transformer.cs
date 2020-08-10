using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using Postgres_1;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;

namespace Postgres_1
{
    // Default Missing Values on GET
    // Decrypt Values on GET
    // Encrypt values on POST
    // Validate DataType on POST

    public enum TargetTableName
    {
        Store,
        Product

    }
    public class Transformer
    {
        public void GetExtentionProperty(int ownerId, TargetTableName targetTableName, int storeId)
        {
            var _dbContext = new ProductsAndStoresContext();
            var extensionProperties = (from q in _dbContext.Set<ExtensionDomain>()
                                       join b in _dbContext.Set<ExtensionProperty>() on q.ExtensionDomainId equals b.ExtensionDomainId
                                       where (q.OwnerId == ownerId && q.TargetTableName == targetTableName.ToString())
                                       select b
                        ).ToList();

            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
            extensionProperties.ForEach(x => {
                keyValuePairs.TryAdd(x.ColumnName, x.DefaultValue);
            });

            Debug.WriteLine(JsonConvert.SerializeObject(keyValuePairs));
            

            var exData = _dbContext.Store.Where(x=>x.StoreId == storeId).Select(x => x.ExtensionProperty).ToList();
            exData.ForEach(x =>
            {
                var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(x);
                foreach(var dataKV in data)
                {
                    if (keyValuePairs.ContainsKey(dataKV.Key))
                    {
                        var ep = extensionProperties.FirstOrDefault(x => x.ColumnName == dataKV.Key);
                        if (ep.IsEncrypted)
                            keyValuePairs[dataKV.Key] = DecryptProperty(dataKV.Value.ToString());
                        else
                            keyValuePairs[dataKV.Key] = dataKV.Value;
                        
                    }
                }
            });
            Debug.WriteLine(JsonConvert.SerializeObject(keyValuePairs));
        }
        public void SaveExtentionProperty(int ownerId, TargetTableName targetTableName, int storeId)
        {
            var _dbContext = new ProductsAndStoresContext();
            var extensionProperties = (from q in _dbContext.Set<ExtensionDomain>()
                                       join b in _dbContext.Set<ExtensionProperty>() on q.ExtensionDomainId equals b.ExtensionDomainId
                                       where (q.OwnerId == ownerId && q.TargetTableName == targetTableName.ToString())
                                       select b
                        ).ToList();

            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
            extensionProperties.ForEach(x => {
                keyValuePairs.TryAdd(x.ColumnName, x.DefaultValue);
            });

            Debug.WriteLine(JsonConvert.SerializeObject(keyValuePairs));

            var exData = _dbContext.Store.Where(x => x.StoreId == storeId).Select(x => x.ExtensionProperty).ToList();
            exData.ForEach(x =>
            {
                var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(x);
                foreach (var dataKV in data)
                {
                    if (keyValuePairs.ContainsKey(dataKV.Key))
                    {
                        var ep = extensionProperties.FirstOrDefault(x => x.ColumnName == dataKV.Key);
                        switch (ep.DataType)
                        {
                            case "string":
                                if (dataKV.Value.ToString().Length > ep.MaxLength)
                                    Console.WriteLine("Validation Failed");
                                break;
                            case "number":
                                
                                break;
                            case "date":
                                break;
                            case "bool":
                                break;
                        }
                        if (ep.IsEncrypted)
                            keyValuePairs[dataKV.Key] = EncryptProperty(dataKV.Value.ToString());
                        else
                            keyValuePairs[dataKV.Key] = dataKV.Value;
                    }
                }
            });
            Console.WriteLine(JsonConvert.SerializeObject(keyValuePairs));
        }

        public string EncryptProperty(string data)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(data);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public string DecryptProperty (string data)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(data);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }




}
