using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class ListExtensions
{
    public static List<T> Clone<T>(this List<T> listToClone)
    {
        return listToClone.Select(item => (T)item.Clone()).ToList();
    }

    public static T Clone<T>(this T obj)
    {
        var bytes = ObjectToByteArray(obj);
        return ByteArrayToObject<T>(bytes);
    }

    public static byte[] ObjectToByteArray<T>(T obj)
    {
        if (obj == null) return null;
        BinaryFormatter bf = new BinaryFormatter();
        MemoryStream ms = new MemoryStream();
        bf.Serialize(ms, obj);
        return ms.ToArray();
    }

    public static T ByteArrayToObject<T>(byte[] arrBytes)
    {
        MemoryStream memStream = new MemoryStream();
        BinaryFormatter bf = new BinaryFormatter();
        memStream.Write(arrBytes, 0, arrBytes.Length);
        memStream.Seek(0, SeekOrigin.Begin);
        return (T)bf.Deserialize(memStream);
    }

    #region Shuffle List
    private static System.Random rng = new System.Random();

    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
    #endregion
}