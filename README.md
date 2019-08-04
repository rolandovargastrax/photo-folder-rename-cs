# Photo Folder Renamer

Renames all the files in a given path.
Assumes all files in the path are .NEF files for Nikon RAW images.

## Usage

usage: PhotoFolderRename '\<path>' '\<new group name>'<br/>
usage: PhotoFolderRename '\<path>' '\<file name pattern>' '\<new group name>'

### Notes

The Date Taken property from the files is read from this link:
https://stackoverflow.com/questions/13940436/get-date-taken-for-nef-format-images

It requires the NEF codec from [Nikon](https://downloadcenter.nikonimglib.com/en/products/170/NEF_Codec.html)
