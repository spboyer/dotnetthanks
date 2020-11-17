using System.Collections.Generic;

namespace dotnetthanks
{
    public class SemVer2Comparer : IComparer<string>
    {
        public static SemVer2Comparer Instance => new SemVer2Comparer();

        private SemVer2Comparer()
        {
        }

        public int Compare(string x, string y)
        {
            // The strings start with a "v" that we need to trim, then parse the rest as a semantic version
            if (!NuGet.Versioning.SemanticVersion.TryParse(x?.Substring(1), out var xVersion))
            {
                // If 'x' isn't a semantic version, consider it less ("older") than 'y'
                return -1;
            }
            if (!NuGet.Versioning.SemanticVersion.TryParse(y?.Substring(1), out var yVersion))
            {
                // If 'y' isn't a semantic version, consider it less ("older") than 'x'
                return 1;
            }

            return xVersion.CompareTo(yVersion);
        }
    }
}
