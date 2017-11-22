namespace Casino.AdminPortal.Shared
{
    /// <summary>
    /// Data Transfer Objects
    /// </summary>
    public enum DTOType
    {

        /// <summary>
        /// Undefined DTO (Default)
        /// </summary>
        Undefined = 0,
        [QualifiedTypeName("Casino.AdminPortal.DTOModel.dll", "Casino.AdminPortal.DTOModel.SampleDTO")]
        SampleDTO = 1,
        [QualifiedTypeName("Casino.AdminPortal.DTOModel.dll", "Casino.AdminPortal.DTOModel.CustomerDTO")]
        CustomerDTO = 2,
        
    }
}
