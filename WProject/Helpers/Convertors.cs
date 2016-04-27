using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WProject.UiLibrary.Classes;
using WProject.WebApiClasses.Classes;

namespace WProject.Helpers
{
    public static class Convertors
    {
        public static ChatMessage Convert(TaskComment taskComment, bool send)
        {
            return new ChatMessage
            {
                DateTime = taskComment?.CreatedAt ?? DateTime.Now,
                Send = send,
                SendBy = taskComment?.CreatedBy?.Name ?? string.Empty,
                Message = taskComment?.Text ?? string.Empty,
                Empty = taskComment == null
            };
        }

        public static FileItem Convert(File file)
        {
            return new FileItem
            {
                Name = file?.Name ?? string.Empty,
                CreatedBy = file?.CreatedBy?.Name ?? string.Empty,
                CreatedAt = file?.CreatedAt ?? DateTime.MinValue,
                FilePath = file?.Path ?? string.Empty,
                Extension = file?.Extension ?? string.Empty,
                Size = file?.Size ?? 0,
                Data = file?.Content,
                Icon = GetIconForFile(file),
                Tag = file?.Metadata
            };
        }

        public static Image GetIconForFile(File file)
        {
            //todo pentru mai multe formate
            if (file == null)
                return null;

            if (string.IsNullOrEmpty(file.Extension))
                return Properties.Resources.file; 

            if (file.IsImage)
            {
                var mtm = file.GetThumbnail();
                if (mtm != null)
                    return mtm;
            }

            //if(File.IMAGE_EXTENSIONS.Con)
            return Properties.Resources.file;
        }
    }
}
