using System.Collections.Generic;
using System.IO;

namespace photo_folder_rename_cs
{
	class Renamer
	{
		DirectoryInfo folder = null;
		string fileNamePattern = "*.NEF";
		string newGroupName = "photo";

		public Renamer(string path, string newGroupName)
		{
			this.folder = new DirectoryInfo(path);
			this.newGroupName = newGroupName;
		}
		public Renamer(string path, string fileNamePattern, string newGroupName) : this(path, newGroupName)
		{
			this.fileNamePattern = fileNamePattern;
		}

		public void RenameFiles()
		{
			this.RenameFilesHelper("tempFileNameFromRenamer");
			this.RenameFilesHelper(string.Empty);
		}

		public void RenameFilesHelper(string tempFileName)
		{
			FileInfo[] files = folder.GetFiles(this.fileNamePattern);

			// sort the files based on create timestamp
			List<ImageFile> sortedFiles = new List<ImageFile>();
			foreach (var currentFileInfo in files)
			{
				ImageFile i = new ImageFile(currentFileInfo);
				sortedFiles.Add(i);
			}
			sortedFiles.Sort((x, y) => x.DateTaken.CompareTo(y.DateTaken));

			int fileSequenceNumber = 1;
			// figure out the max padding size
			var paddingLength = (files.Length.ToString().Length);

			// iterate over all the files from the folder
			foreach (var currentImage in sortedFiles)
			{
				// calculate the new file name
				string newFileName = Path.Combine(this.folder.FullName, $"{(tempFileName.Length > 0 ? "tempFileName" : currentImage.DateTaken.ToString("yyyy MM dd"))} - {newGroupName} - {fileSequenceNumber.ToString().PadLeft(paddingLength, '0')}{currentImage.FileInfo.Extension}");
				while (File.Exists(newFileName))
				{
					fileSequenceNumber++;
					newFileName = Path.Combine(this.folder.FullName, $"{(tempFileName.Length > 0 ? "tempFileName" : currentImage.DateTaken.ToString("yyyy MM dd"))} - {newGroupName} - {fileSequenceNumber.ToString().PadLeft(paddingLength, '0')}{currentImage.FileInfo.Extension}");
				}
				// rename the file
				currentImage.FileInfo.MoveTo(newFileName);
			}
		}
	}
}
