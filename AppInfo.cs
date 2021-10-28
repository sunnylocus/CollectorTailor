using System;
using System.Collections.Generic;
namespace CollectorTailor
{
    /// <summary>
    /// Bean class
    /// For more details about these properties, see https://docs.microsoft.com/en-us/windows/win32/cimwin32prov/win32-process
    /// and https://docs.microsoft.com/en-us/previous-versions/aa394323(v=vs.85)
    /// </summary>
    public class AppInfo
	{ [SkipProperty] public ulong BatchNo { get; set; }                            // Customize property. This property indicates the number of rounds of gathering data.
       [Win32PropertyAttribute] public string CsName { get; set; }                 // The name of the computer name.
       [Win32PropertyAttribute] public UInt32 ProcessId { get; set; }              // Numeric identifier used to distinguish one process from another.
       [Win32PropertyAttribute] public string Description { get; set; }		       // The process name without its path.
       [Win32PropertyAttribute] public string ExecutablePath { get; set; }         // Path to the executable file of the process. Example: "C:\Windows\System\Explorer.Exe"
       [Win32PropertyAttribute] public UInt32 HandleCount { get; set; }            // Total number of open handles owned by the process. 
       [Win32PropertyAttribute] public UInt32 ThreadCount { get; set; }            // Number of active threads in a process
       [Win32PropertyAttribute] public UInt64 KernelModeTime { get; set; }         // Time in kernel mode, in 100 nanosecond units. If this information is not available, use a value of 0 (zero).
       [Win32PropertyAttribute] public UInt64 UserModeTime { get; set; }           // Time in user mode, in 100 nanosecond units. If this information is not available, use a value of 0 (zero).
       [Win32PropertyAttribute] public UInt64 OtherOperationCount { get; set; }    // Number of I/O operations performed that are not read or write operations.
       [Win32PropertyAttribute] public UInt64 OtherTransferCount { get; set; }     // Amount of data transferred during operations that are not read or write operations.
       [Win32PropertyAttribute] public UInt32 PageFaults { get; set; }             // Number of page faults that a process generates.
       [Win32PropertyAttribute] public UInt32 PageFileUsage { get; set; }          // Amount of page file space that a process is using currently. This value is consistent with the VMSize value in TaskMgr.exe.
       [Win32PropertyAttribute] public UInt32 PeakPageFileUsage { get; set; }      // Maximum amount of page file space used during the life of a process.
       [Win32PropertyAttribute] public UInt64 PeakVirtualSize { get; set; }        // Maximum virtual address space a process uses at any one time.
       [Win32PropertyAttribute] public UInt32 PeakWorkingSetSize { get; set; }     // Peak working set size of a process.
       [Win32PropertyAttribute] public UInt32 Priority { get; set; }               // Scheduling priority of a process within an operating system. The higher the value, the higher priority a process receives. Priority values can range from 0 (zero), which is the lowest priority to 31, which is highest priority.
       [Win32PropertyAttribute] public UInt64 PrivatePageCount { get; set; }       // It is equivalent to PageFileUsage. But it is in bytes instead of kilobytes.
       [Win32PropertyAttribute] public UInt32 QuotaNonPagedPoolUsage{ get; set; }  // Quota amount of nonpaged pool usage for a process. Example: 15
       [Win32PropertyAttribute] public UInt32 QuotaPagedPoolUsage { get; set; }    // Quota amount of paged pool usage for a process. Example: 22
       [Win32PropertyAttribute] public UInt32 QuotaPeakNonPagedPoolUsage { get; set; }  //Peak quota amount of nonpaged pool usage for a process. Example: 31
       [Win32PropertyAttribute] public UInt64 ReadOperationCount { get; set; }	   // Number of read operations performed.
       [Win32PropertyAttribute] public UInt64 ReadTransferCount { get; set; }      // Amount of data read.
       [Win32PropertyAttribute] public UInt64 VirtualSize { get; set; }            // Current size of the virtual address space that a process is using, not the physical or virtual memory actually used by the process.
       [Win32PropertyAttribute] public UInt64 WorkingSetSize { get; set; }         // Amount of memory in bytes that a process needs to execute efficiently—for an operating system that uses page-based memory management.
       [Win32PropertyAttribute] public UInt64 WriteOperationCount { get; set; }    // Number of write operations performed.
       [Win32PropertyAttribute] public UInt64 WriteTransferCount { get; set; }     // Amount of data written.
       
       [PerfPropertyAttribute] public UInt32 IDProcess { get; set; }  
       [PerfPropertyAttribute] public string Name { get; set; }
       [PerfPropertyAttribute] public UInt64 IODataOperationsPerSec { get; set; }  
       [PerfPropertyAttribute] public UInt64 IOOtherOperationsPerSec { get; set; }  
       [PerfPropertyAttribute] public UInt64 IOReadBytesPerSec { get; set; }
       [PerfPropertyAttribute] public UInt64 IOReadOperationsPerSec { get; set; }
       [PerfPropertyAttribute] public UInt64 IOWriteBytesPerSec { get; set; }
       [PerfPropertyAttribute] public UInt64 IOWriteOperationsPerSec { get; set; }
       [PerfPropertyAttribute] public UInt64 IODataBytesPerSec { get; set; }
       [PerfPropertyAttribute] public UInt64 IOOtherBytesPerSec { get; set; }
       [PerfPropertyAttribute] public UInt32 PageFaultsPerSec { get; set; }
       [PerfPropertyAttribute] public UInt64 PageFileBytes { get; set; }
       [PerfPropertyAttribute] public UInt64 PageFileBytesPeak { get; set; }
       [PerfPropertyAttribute] public UInt64 PercentPrivilegedTime { get; set; }
       [PerfPropertyAttribute] public UInt64 PercentProcessorTime { get; set; }
       [PerfPropertyAttribute] public UInt64 PercentUserTime { get; set; }
       [PerfPropertyAttribute] public UInt32 PoolNonpagedBytes { get; set; }
       [PerfPropertyAttribute] public UInt32 PoolPagedBytes { get; set; }
       [PerfPropertyAttribute] public UInt32 PriorityBase { get; set; }
       [PerfPropertyAttribute] public UInt64 PrivateBytes { get; set; }
       [PerfPropertyAttribute] public UInt64 VirtualBytes { get; set; }
       [PerfPropertyAttribute] public UInt64 VirtualBytesPeak { get; set; }
       [PerfPropertyAttribute] public UInt64 WorkingSet { get; set; }
       [PerfPropertyAttribute] public UInt64 WorkingSetPeak { get; set; }
       
       [SkipProperty] public UInt32 TcpConnectionAmount { get; set; } // Customize property. The feature indicates how many TCP connections
       [SkipProperty] public string TcpConnections { get; set; }      // Customize property. The feature stores Tcp connection strings.
       [SkipProperty] public string OSVersion { get; set; }           // Customize property. The OS Version.
       [SkipProperty] public string UserName { get; set; }            // Customize property. User name
       [SkipProperty] public string ComputerId { get; set; }
       [SkipProperty] public long TimeStamp { get; set; }             // Customize property. The time when the data gathered.
    }   
}