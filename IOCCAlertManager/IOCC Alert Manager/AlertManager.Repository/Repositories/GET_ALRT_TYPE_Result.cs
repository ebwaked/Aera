//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OperationsAlertManager.Data.Repositories
{
    using System;
    
    public partial class GET_ALRT_TYPE_Result
    {
        public int ALRT_TYPE_ID { get; set; }
        public string ALRT_TYPE_NME { get; set; }
        public string ALRT_TYPE_DESC { get; set; }
        public System.DateTime EFTV_DTE { get; set; }
        public Nullable<System.DateTime> TERM_DTE { get; set; }
        public Nullable<int> ALRT_PRCS_TYPE_ID { get; set; }
        public string DFLT_FAC_TYPE_CDE { get; set; }
        public Nullable<int> DFLT_MGMT_PLNT_FAC_ID { get; set; }
        public Nullable<int> ALRT_DFLT_PRIO_TYPE_ID { get; set; }
        public string ACTV_INDC { get; set; }
    }
}