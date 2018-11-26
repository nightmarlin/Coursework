using System;
using System.IO;

using Solution.Errors;

namespace Solution.Welcome {

    /// <summary>
    /// A data structure representing a recently opened project
    /// </summary>
    public class RecentItem {

        /// <summary>
        /// Initialises the RecentItem with the Project Name, Location and Date Last Accessed. Can throw a <see cref="T:BSharp_NotABSharpIndexException" />
        /// </summary>
        /// <param name="ProjectName">The name of the B# project this Item represents</param>
        /// <param name="FilePath">The filepath where the ".BSharp" index can be found</param>
        /// <param name="LastSaved">The date the item was saved on</param>
        public RecentItem(string ProjectName, string FilePath, DateTime LastSaved) {
            this.ProjectName = ProjectName;
            this.FilePath = FilePath;
            this.LastSaved = LastSaved;

            if (!FilePath.EndsWith(".BSharp")) {
                // Not a .BSharp reference
                throw new BSharp_NotABSharpIndexException();
            }
        }
        
        /// <summary>
        /// The Name of the B# project
        /// </summary>
        public string ProjectName { get; }

        /// <summary>
        /// The location of the ".BSharp" index
        /// </summary>
        public string FilePath { get; }

        /// <summary>
        /// The <see cref="T:System.DateTime"/> the project was last saved at
        /// </summary>
        public DateTime LastSaved { get; set; }

        /// <summary>
        /// Tells you whether the <see cref="T:System.IO.File"/> exists.
        /// </summary>
        public bool Exists => File.Exists(FilePath);

        /// <summary>
        /// Gets the info in string form
        /// </summary>
        /// <returns>The project name, location, DateTime saved at and whether it still exists in the form:
        /// "[Name] - Location: '[File Path]' - Last Saved: '[dd/mm/yyyy hh:mm]' -
        /// Exists: '[Yes / No]'"</returns>
        public new string ToString() {
            return $"{ProjectName} " +
                   $"- Location: '{FilePath}' " +
                   $"- Last Saved: '{LastSaved:g}' " +
                   $"- Exists: '{(Exists ? "Yes" : "No")}'";
        }


    }

}