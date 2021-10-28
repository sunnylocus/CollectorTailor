using System;

namespace CollectorTailor
{
    /// <summary>
    /// This class is used to mark which properties will not be reflected.
    /// </summary>
    public class SkipPropertyAttribute : Attribute {
    }
    
    public class Win32PropertyAttribute : Attribute {
    }
    
    
    public class PerfPropertyAttribute : Attribute {
    }

}