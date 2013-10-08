using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Sys.DataManager
{
    public enum ApprovalAction
    {
        None = 0,
        Approved = 1,
        Rejected = 2,
        Disputed = 3
    }

    public interface IApproval
    {
        ApprovalAction ApprovalAction { get; }
        void Approve();
        void Reject(string reason);
        void Dispute(string reason);
        string History { get; }
        void SaveApproval();
    }
}
