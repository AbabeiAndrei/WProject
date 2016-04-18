using System;
using System.Collections.Generic;
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
                Icon = file?.GetThumbnail(),
                Tag = file?.Metadata
            };
        }
    }
}
