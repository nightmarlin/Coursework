using System;

namespace Solution.Errors {

    /// <summary>
    /// Occurs when you try to reference a non-".BSharp" file as a ".BSharp" file
    /// </summary>
    [Serializable]
    public class BSharp_NotABSharpIndexException : Exception {

    }

}