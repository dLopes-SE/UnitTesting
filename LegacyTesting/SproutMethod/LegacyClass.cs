using System.Collections.Generic;
using System.Linq;

namespace SproutMethod
{
  public class LegacyClass
  {
    public void AppendDictionary<TKey, TValue>(Dictionary<TKey, TValue> fromDict, Dictionary<TKey, TValue> toDict)
    {
      Dictionary<TKey, TValue> validItems = GetValidItems(fromDict, toDict);

      foreach (var item in validItems)
      {
        toDict.Add(item.Key, item.Value);
      }
    }

    public Dictionary<TKey, TValue> GetValidItems<TKey, TValue>(Dictionary<TKey, TValue> fromDict, Dictionary<TKey,
        TValue> toDict)
    {
      return fromDict.Where(x => !toDict.ContainsKey(x.Key))
                   .ToDictionary(d => d.Key, d => d.Value);
    }
  }
}
