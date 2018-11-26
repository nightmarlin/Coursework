using System;

namespace Solution.Saving {

    /// <summary>
    /// The data contained within a BSharp file, put into a class
    /// </summary>
    public class BSharpSaveFile {

        /// <summary>
        /// The Name of the project assigned by the user
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// The location of the BSharp index file
        /// </summary>
        public string BSharpIndexFilePath { get; set; }
        
        /// <summary>
        /// The date and time that the project was last saved
        /// </summary>
        public DateTime LastSaved { get; set; }

    }

}