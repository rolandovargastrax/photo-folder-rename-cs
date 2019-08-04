using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace photo_folder_rename_cs
{
	public class ImageFile
	{
		public DateTime DateTaken { get; set; }
		public FileInfo FileInfo { get; set; }

		public ImageFile(FileInfo fileInfo)
		{
			this.FileInfo = fileInfo;
			this.DateTaken = GetDateTaken(this.FileInfo);
		}

		private DateTime GetDateTaken(FileInfo f)
		{
			// https://stackoverflow.com/questions/13940436/get-date-taken-for-nef-format-images
			string date = null;

			using (FileStream fs = new FileStream(f.FullName, FileMode.Open, FileAccess.Read, FileShare.Read))
			{
				BitmapSource img = BitmapFrame.Create(fs);
				BitmapMetadata md = (BitmapMetadata)img.Metadata;
				date = md.DateTaken;
			}

			return DateTime.Parse(date);
		}
	}
}
