namespace InovaFileManager
{
    /// <summary>
    /// an interface defines the methods that should every FileManager implemented
    /// </summary>
    public interface IFileManager
    {
        /// <summary>
        /// delete file
        /// </summary>
        /// <param name="FileName">the filename</param>
        void Delete(string FileName);

        /// <summary>
        /// get file by filename
        /// </summary>
        /// <param name="FileName">the filename</param>
        /// <returns></returns>
        string Get(string FileName);

        /// <summary>
        /// save the file
        /// </summary>
        /// <param name="base64">the file on format Base64</param>
        /// <param name="FileName">the filename</param>
        void Save(string base64, string FileName);
    }
}