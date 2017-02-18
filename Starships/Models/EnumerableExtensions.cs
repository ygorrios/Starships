using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Text;

namespace Starships.Models
{

    public static class EnumerableExtensions
    {
        /// <summary>
        /// This method get the value of StringValue in Enum
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static string GetStringValue(this Enum value)
        {
            // Get the type
            Type type = value.GetType();

            // Get fieldinfo for this type
            System.Reflection.FieldInfo fieldInfo = type.GetField(value.ToString());

            // Caso retorne NULL é porque não encontro o enum
            if (fieldInfo != null)
            {
                // Get the stringvalue attributes
                StringValueAttribute[] attribs = fieldInfo.GetCustomAttributes(
                typeof(StringValueAttribute), false) as StringValueAttribute[];

                // Return the first if there was a match.
                return attribs.Length > 0 ? attribs[0].StringValue : null;
            }
            else
                return string.Empty;
        }

        /// <summary>
        /// This method get the value of StringDescription in Enum
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetStringDescription(this Enum value)
        {
            // Get the type
            Type type = value.GetType();

            // Get fieldinfo for this type
            System.Reflection.FieldInfo fieldInfo = type.GetField(value.ToString());

            // Caso retorne NULL é porque não encontro o enum
            if (fieldInfo != null)
            {
                // Get the stringdescription attributes
                StringDescriptionAttribute[] attribs = fieldInfo.GetCustomAttributes(
                typeof(StringDescriptionAttribute), false) as StringDescriptionAttribute[];

                // Return the first if there was a match.
                return attribs.Length > 0 ? attribs[0].StringDescription : null;
            }
            else
                return string.Empty;
        }

      
    }

    public class StringValueAttribute : Attribute
    {
        #region Properties
        /// <summary>
        /// Holds the stringvalue for a value in an enum.
        /// </summary>
        public string StringValue { get; protected set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor used to init a StringValue Attribute
        /// </summary>
        /// <param name="value"></param>
        public StringValueAttribute(string value)
        {
            this.StringValue = value;
        }
        #endregion
    }

    public class StringDescriptionAttribute : Attribute
    {
        #region Properties
        /// <summary>
        /// Holds the stringdescription for a value in an enum.
        /// </summary>
        public string StringDescription { get; protected set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor used to init a StringDescription Attribute
        /// </summary>
        /// <param name="value"></param>
        public StringDescriptionAttribute(string value)
        {
            this.StringDescription = value;
        }
        #endregion
    }
}