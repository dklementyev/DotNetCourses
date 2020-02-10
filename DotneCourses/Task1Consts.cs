using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotneCourses
{
    public static class Task1Consts
    {
        public const char MapElementSeparator = '(';

        #region MapElementTypes

        public const string BaseElementType = "base";

        public const string BridgeElementType = "bridge";

        public const string TreasureElementType = "treasure";

        public const string WaterElementType = "water";

        #endregion

        #region MapElementSybmols

        public const string BaseSymbol = "@";

        public const string BridgeSymbol = "#";

        public const string TreasureSymbol = "+";

        public const string WaterSymbol = "~";

        public const string EmptySymbol = ".";

        #endregion

        #region MapLimits

        public const int XLimit = 40;

        public const int YLimit = 19;

        #endregion
    }
}
