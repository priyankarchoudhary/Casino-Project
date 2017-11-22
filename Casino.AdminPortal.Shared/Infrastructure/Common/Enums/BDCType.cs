namespace Casino.AdminPortal.Shared
{
    /// <summary>
    /// Business Domain Component Type
    /// </summary>
    public enum BDCType
    {
        [QualifiedTypeName("Casino.AdminPortal.Business.dll", "Casino.AdminPortal.Business.SampleBDC")]
        SampleBDC = 0,
        [QualifiedTypeName("Casino.AdminPortal.Business.dll", "Casino.AdminPortal.Business.CustomerBDC")]
        CustomerBDC = 1
    }
}
