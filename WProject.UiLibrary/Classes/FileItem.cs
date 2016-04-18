using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WProject.UiLibrary.Interfaces;

namespace WProject.UiLibrary.Classes
{
    [Serializable]
    public class FileItem : ICloneable<FileItem>, IEquatable<FileItem>, IEqualityComparer<FileItem>, ICloneable
    {
        #region Properties

        /// <summary>
        /// File name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// File extension
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// File name with extension
        /// </summary>
        public string FullName => string.IsNullOrEmpty(Extension) ? Name : $"{Name}.{Extension}";

        /// <summary>
        /// Creator of thew file
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Creation date
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Size in bites
        /// </summary>
        public long Size { get; set; }

        /// <summary>
        /// Icon of the file
        /// </summary>
        public Image Icon { get; set; }

        /// <summary>
        /// File content
        /// </summary>
        public byte[] Data { get; set; }

        /// <summary>
        /// Extra file data
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        /// Phisycal path on disk of the file
        /// </summary>
        public string FilePath { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Create new file item
        /// </summary>
        public FileItem()
        {
        }

        /// <summary>
        /// Create new FileItem from physical File
        /// </summary>
        /// <param name="filePath">Path of file</param>
        /// <param name="loadFileContent">If true all file will be loaded in Data property <remarks>Atention! File will be loaded in memory!</remarks></param>
        public FileItem(string filePath, bool loadFileContent = false)
        {
            var mf = new FileInfo(filePath);

            Name = Path.GetFileNameWithoutExtension(filePath);
            Extension = mf.Extension.Replace(".", string.Empty);
            CreatedAt = mf.CreationTime;
            FilePath = filePath;
            Size = mf.Length;

            if (loadFileContent)
                Data = File.ReadAllBytes(filePath);
        }

        #endregion
        
        #region Implementation of ICloneable<FileItem>

        public FileItem Clone()
        {
            return new FileItem
            {
                Name = Name,
                CreatedAt = CreatedAt,
                CreatedBy = CreatedBy,
                Size = Size,
                Data = Data.Clone() as byte[],
                Icon = Icon.Clone() as Image,
                Extension = Extension,
                FilePath = FilePath,
                Tag = Tag
            };
        }

        #endregion

        #region Implementation of IEquatable<FileItem>

        public bool Equals(FileItem file)
        {
            return Size == file.Size &&
                   Name == file.Name &&
                   Extension == file.Extension &&
                   CreatedBy == file.CreatedBy &&
                   CreatedAt == file.CreatedAt &&
                   FilePath == file.FilePath &&
                   Data.SequenceEqual(file.Data);
        }

        #endregion

        #region Implementation of IEqualityComparer<in FileItem>

        public bool Equals(FileItem first, FileItem second)
        {
            return first.GetHashCode() == second.GetHashCode();
        }

        public int GetHashCode(FileItem obj)
        {
            return obj.GetHashCode();
        }

        #endregion

        #region Implementation of ICloneable

        object ICloneable.Clone()
        {
            return Clone();
        }

        #endregion
    }
}
