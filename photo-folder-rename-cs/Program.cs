using System;

namespace photo_folder_rename_cs
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Length == 2)
			{
				Renamer renamer = new Renamer(args[0], args[1]);
				renamer.RenameFiles();
			}
			else if (args.Length == 2)
			{
				Renamer renamer = new Renamer(args[0], args[1], args[2]);
				renamer.RenameFiles();
			}
			else
			{
				Console.WriteLine("Missing path to calculate.");
				Console.WriteLine("usage: PhotoFolderRename '<path>' '<new group name>'");
				Console.WriteLine("usage: PhotoFolderRename '<path>' '<file name pattern>' '<new group name>'");
				return;
			}
		}
	}
}
