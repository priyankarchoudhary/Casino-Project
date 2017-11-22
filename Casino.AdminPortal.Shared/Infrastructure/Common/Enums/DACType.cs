namespace Casino.AdminPortal.Shared
{
    /// <summary>
    /// Data Access Component Type
    /// </summary>
    public enum DACType
    {

        [QualifiedTypeName("Casino.AdminPortal.Data.dll", "Casino.AdminPortal.Data.SampleDAC")]
        SampleDAC = 1,
        [QualifiedTypeName("Casino.AdminPortal.Data.dll", "Casino.AdminPortal.Data.CustomerDAC")]
        CustomerDAC = 2,
    }
}
