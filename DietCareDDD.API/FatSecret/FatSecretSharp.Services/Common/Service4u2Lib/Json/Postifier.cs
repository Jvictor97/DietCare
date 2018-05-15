using System;
using System.Collections;
using System.Collections.Generic;

namespace Service4u2.Json
{
    /// <summary>
    /// Extensions to help postify parameters.
    /// </summary>
    public static class PostifyExtensions
    {
        private static Postifier postifier = new Postifier();

        /// <summary>
        /// Postifies the specified values.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <returns></returns>
        public static string Postify(this Dictionary<string, object> values)
        {
            return postifier.Postify(values);
        }

        /// <summary>
        /// Postifies the specified value.
        /// </summary>
        /// <typeparam name="TValType">The type of the val type.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>A url string version of the passed in value.</returns>
        public static string Postify<TValType>(this TValType value)
            where TValType : class
        {
            return postifier.Postify(value);
        }
    }

    /// <summary>
    /// A helper class for producing .Net MVC Controller Action friendly post query strings out of objects.
    /// </summary>
    public class Postifier
    {
        /// <summary>
        /// Postifies the specified value.
        /// </summary>
        /// <param name="value">The anonymous object to postify.</param>
        /// <returns>The postified string representation of the object.</returns>
        public string Postify(object value)
        {
            // Custom object; take properties.
            var objVals = new Dictionary<string, object>();
            var currKey = string.Empty;
            object currValue = null;
            foreach (var prop in value.GetType().GetProperties())
            {
                if (!prop.CanRead)
                    continue;

                // format: keyName.propertyName
                currKey = string.Format("{0}", prop.Name);
                currValue = prop.GetValue(value, null);

                objVals.Add(currKey, currValue);
            }

            return Postify(objVals);
        }

        /// <summary>
        /// Postifies the specified values.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <returns>A postified string representation of the passed in values.</returns>
        public string Postify(Dictionary<string, object> values)
        {
            var result = string.Empty;
            var currVal = string.Empty;
            var parms = new List<string>();
            foreach (var val in values)
            {
                currVal = string.Empty;
                
                if (val.Value == null)
                {
                    currVal = string.Format("{0}=", val.Key);
                }
                // If the val is a simple type, set it.
                else if (val.Value.GetType().IsPrimitive || val.Value is string)
                {
                    currVal = string.Format("{0}={1}", val.Key, val.Value);
                }
                // DateTime's are stored as RFC string representations.
                else if (val.Value is DateTime)
                {
                    currVal = string.Format("{0}={1:r}", val.Key, (DateTime)val.Value);
                }
                // Loop through lists and get property values.
                else if (val.Value is IEnumerable)
                {
                    currVal = PostifyList(val.Key, (IEnumerable)val.Value);
                }
                else
                {
                    // Custom object; take properties.
                    var objVals = new Dictionary<string, object>();
                    var currKey = string.Empty;
                    object currValue = null;
                    foreach (var prop in val.Value.GetType().GetProperties())
                    {
                        if (!prop.CanRead)
                            continue;

                        // format: keyName.propertyName
                        currKey = string.Format("{0}.{1}", val.Key, prop.Name);
                        currValue = prop.GetValue(val.Value, null);

                        objVals.Add(currKey, currValue);
                    }

                    currVal = Postify(objVals);
                }

                parms.Add(currVal);
            }

            result = string.Join("&", parms.ToArray());

            return result;
        }

        /// <summary>
        /// Postifies the list.
        /// </summary>
        /// <param name="keyBase">The key base.</param>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        private string PostifyList(string keyBase, IEnumerable list)
        {
            int index = 0;
            Dictionary<string, object> objVals = new Dictionary<string, object>();

            string currKey = string.Empty;
            object currValue = null;
            foreach (var obj in list)
            {
                currKey = string.Format("{0}[{1}]", keyBase, index);
                // If the val is a simple type, set it.
                if (obj is int || obj is double || obj is float || obj is string || obj is DateTime)
                {
                    objVals.Add(currKey, obj);
                }
                // Loop through lists and get property values.
                else if (obj is IEnumerable)
                {
                    objVals.Add(currKey, obj);
                }
                else
                {
                    // Loop through the readable properties and build up a dictionary to postify.
                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        if (!prop.CanRead)
                            continue;

                        currKey = string.Format("{0}[{1}].{2}", keyBase, index, prop.Name);
                        currValue = prop.GetValue(obj, null);

                        objVals.Add(currKey, currValue);
                    }
                }
                ++index;
            }

            return Postify(objVals);
        }
    }
}
