namespace CompanyFileManager
{
    using System;
    using System.IO;

    public class FileManager : IFileManager
    {
        private readonly string _path;
        private const int _startDirectory = 0;
        private const int _startSubDirectory = 2;
        private const int _directoryNameLength = 2;

        public FileManager(string path)
            => _path = path;

        /// <summary>
        /// save the file
        /// </summary>
        /// <param name="base64">the file on format Base64</param>
        /// <param name="FileName">the filename</param>
        public void Save(string base64, string FileName)
        {
            try
            {
                // Encoding to hexadecimal
                var fileNameInHex = EncodingWordToHex(FileName);

                // Get Name of Directory and SubDirectory
                var Directory = GetDirectory(fileNameInHex, _startDirectory, _directoryNameLength);
                var SubDirectory = GetDirectory(fileNameInHex, _startSubDirectory, _directoryNameLength);

                // create directory
                CreateDirectory(BuildPath(new string[] { _path, Directory }));

                // create sub directory
                CreateDirectory(BuildPath(new string[] { _path, Directory, SubDirectory }));

                // Save File
                File.WriteAllText(BuildPath(new string[] { _path, Directory, SubDirectory, FileName }), base64);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// get file by filename
        /// </summary>
        /// <param name="FileName">the filename</param>
        /// <returns></returns>
        public string Get(string FileName)
        {
            try
            {
                // Encoding to hexadecimal
                var fileNameInHex = EncodingWordToHex(FileName);

                // Get Name of Directory and SubDirectory
                var Directory = GetDirectory(fileNameInHex, _startDirectory, _directoryNameLength);
                var SubDirectory = GetDirectory(fileNameInHex, _startSubDirectory, _directoryNameLength);

                // Path File
                var Path_File = BuildPath(new string[] { _path, Directory, SubDirectory, FileName });

                // Convert file to Base64
                string Base64 = File.ReadAllText(Path_File);

                return Base64;
            }
            catch (DirectoryNotFoundException ex)
            {
                throw ex;
            }
            catch (FileNotFoundException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// delete file
        /// </summary>
        /// <param name="FileName">the filename</param>
        public void Delete(string FileName)
        {
            try
            {
                // Encoding to hexadecimal
                var fileNameInHex = EncodingWordToHex(FileName);

                // Get Name of Directory and SubDirectory
                var Directory = GetDirectory(fileNameInHex, _startDirectory, _directoryNameLength);
                var SubDirectory = GetDirectory(fileNameInHex, _startSubDirectory, _directoryNameLength);

                // Path File
                var Path_File = BuildPath(new string[] { _path, Directory, SubDirectory, FileName });

                if (CheckExistFile(Path_File))
                    File.Delete(Path_File);
                else
                    throw new FileNotFoundException();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region private methods

        /// <summary>
        /// create directory 
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="subDirectory"></param>
        private void CreateDirectory(string directory)
        {
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
        }

        /// <summary>
        /// encoding filename on Hex
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        private string EncodingWordToHex(string FileName)
        {
            FletcherChecksum fletcher = new FletcherChecksum();
            var Encoding = fletcher.GetChecksum(FileName, 16);
            var EncodingHexa = Encoding.ToString("X").ToString();
            return EncodingHexa;
        }

        /// <summary>
        /// extract name of directory from filename on Hex
        /// </summary>
        /// <param name="HexFileName">filename on Hex</param>
        /// <param name="IndexStart">index of start</param>
        /// <param name="Length">the length that you want to extract</param>
        /// <returns></returns>
        private string GetDirectory(string HexFileName, int IndexStart, int Length)
            => HexFileName.Substring(IndexStart, Length);

        /// <summary>
        /// join array of name directory 
        /// </summary>
        /// <param name="NameDirectory">array of name directory</param>
        /// <returns></returns>
        private string BuildPath(string[] NameDirectory)
            => string.Join("/", NameDirectory);

        /// <summary>
        /// check file is exists
        /// </summary>
        /// <param name="NameDirectory"></param>
        /// <returns></returns>
        private bool CheckExistFile(string NameDirectory)
            => File.Exists(NameDirectory);

        #endregion

    }
}
