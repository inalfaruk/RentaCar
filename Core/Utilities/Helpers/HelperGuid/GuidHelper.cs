using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Helpers.HelperGuid
{
    public class GuidHelper
    {
        public static string CreateGuid()
        {

            return Guid.NewGuid().ToString();

        }

    }
}
