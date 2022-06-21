namespace COMPANY.Controllers
{
    using Application.Models;
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Presentation.Controllers.Base;
    using InovaFileManager;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FileManagerController : BaseController
    {
        private readonly IFileManager _fileManager;

        public FileManagerController(IFileManager fileManager) => _fileManager = fileManager;

        /// <summary>
        /// save list of files
        /// </summary>
        /// <param name="fileManagerModels"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult<Result> CreateFile([FromBody] List<FileManagerModel> fileManagerModels)
        {
            try
            {
                fileManagerModels.ForEach(file => { _fileManager.Save(file.Base64, file.Name); });
                return Ok(Result.Success("Files saved with successfully"));
            }
            catch (Exception)
            {
                var result = Result.Failed(null, "save files failed");
                return StatusCode(500, result);
            }
        }

        /// <summary>
        /// get file by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("{name}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult<Result<string>> Get([FromRoute] string name)
        {
            try
            {
                var result = Result<string>.Success(_fileManager.Get(name));
                return Ok(result);
            }
            catch (Exception)
            {
                var result = Result<string>.Failed(null, "file does not found");
                return NotFound(result);
            }
        }

        /// <summary>
        /// delete file
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpDelete("{name}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult<Result> Delete([FromRoute] string name)
        {
            try
            {
                _fileManager.Delete(name);
                return Ok(Result.Success("File deleted with successfully"));
            }
            catch (Exception)
            {
                var result = Result.Failed(null, "delete file failed");
                return StatusCode(500, result);
            }
        }

        /// <summary>
        /// delete list files
        /// </summary>
        /// <param name="names">the list of names</param>
        /// <returns>a result instance</returns>
        [HttpPost("DeleteList")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult<Result> Delete([FromRoute] List<string> names)
        {
            try
            {
                names.ForEach(name => { _fileManager.Delete(name); });
                return Ok(Result.Success("Files deleted with successfully"));
            }
            catch (Exception)
            {
                var result = Result.Failed(null, "delete files failed");
                return StatusCode(500, result);
            }
        }

    }
}