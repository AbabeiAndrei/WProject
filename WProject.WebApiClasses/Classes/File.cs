using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WProject.GenericLibrary.Helpers.Drawing;
using WProject.WebApiClasses.Interfaces;

namespace WProject.WebApiClasses.Classes
{
    public class File : TableNameble
    {
        private const string TABLE_NAME = "file";

        public int Id { get; set; }

        public string Name { get; set; }

        public string Extension { get; set; }

        public string Type { get; set; }

        public byte[] Content { get; set; }

        public byte[] Thumbmail { get; set; }

        public long? Size { get; set; }

        public string ParentType { get; set; }

        public int? ParentId { get; set; }

        public string Metadata { get; set; }

        public string Path { get; set; }

        public string Url { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? CreatedById { get; set; }

        public bool Deleted { get; set; }

        public object Parent { get; set; }

        public User CreatedBy { get; set; }

        public Image GetImage()
        {
            if (Content != null)
                return ImageHelper.Convert(Content);

            return !string.IsNullOrEmpty(Url)
                        ? ImageHelper.DownloadImage(Url)
                        : null;
        }

        public Image GetThumbnail()
        {
            return Thumbmail != null 
                        ? ImageHelper.Convert(Thumbmail) 
                        : null;
        }

        public async Task<Image> GetImageAsync()
        {
            if (Content != null)
                return ImageHelper.Convert(Content);
            if (!string.IsNullOrEmpty(Url))
                return await ImageHelper.DownloadImageAsync(Url);
            return null;
        }

        public new static string TableName => TABLE_NAME;
    }
}
