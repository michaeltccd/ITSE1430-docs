# Recommended Programs and Features

Windows is designed for a novice user. Programming is considered advanced user tasks and therefore the default Windows settings and programs are not ideal. The following are recommended changes you make to your computer to simplify your programming efforts.

## Show real filenames

Out of the box Windows does not show you the real name of files. Most files have a file extension that help identify the type of file but users are generally not concerned with this. We will be and therefore showing the full filename is important.

1. Open Windows Explorer (not Internet Explorer).
2. For Windows 10
    1. Go to the View tab
    1. Check the option for File name extensions 
    ![File Extensions](fileextensions.png)
3. For older Windows versions
    1. Press the Alt key to bring up the menu for Explorer and select Tools\Options
    1. Go to the View tab
    1. Uncheck the option to Hide file extensions for known file types
4. All files shown in Windows Explorer will now show the (generally 3 letter) file extension after the file name (ex. Explorer.exe).

## Install an Archiving Program

Windows ships with built in support for archive (.zip) files but there are several problems with it. For one it is really slow even for small files. Secondly it shows the file as a folder which gives you the illusion of it actually being a folder in which you can double click files. But this rarely works and more likely will cause errors so replacing the standard Windows archive program with a better one is recommended. 

One freely available and solid program is 7-Zip. I recommend that you install it (or another tool).

1. Download the [program](http://7zip.org). For most computers the 64-bit exe version is the correct version.
2. Run the setup program to install it. 

*Warning: Free programs tend to offer additional software during their installation. Read each screen carefully and only install the core program. Do not install additional software such as Yahoo Toolbar or Bing, etc.)*

3. After installation start the program as an administrator (right click the icon and select Run as Adminstrator).
4. Go to Tools\Options.
5. Select all the files in the list (click the first item, hold down Shift and click the last item) and  then click either the option to associate all files just for you or for all users. Then click Apply. 
![7zip](7zip-extensions.png)
6. Now when you are working with any .zip file it will use 7-zip. To extract a .zip file right-click and select one of the Extract menu options.

## Install a Text Editor Program

Windows ships with a couple of text editors and you likely also have Word but they are either too simple or too complex. There are many freely available text editors but I recommend Notepad++.

1. Download the [program](https://notepad-plus-plus.org/).
2. Run the setup program. (Warning: Refer to the warning earlier about setup programs) You don’t need to install anything other than the core program files but you may want to review what other options are available.
3. Now you can right-click any text file and select the option to open in Notepad++. 

It is recommended that you set Notepad++ as the default program for most text files.

## Blocked Files

Windows is designed to be secure by default. When downloading a file from the Internet Windows may mark the file as blocked. This is to protect you from running dangerous files. In general, trying to access a blocked file will fail. To check whether a file is blocked or not do the following.

1. Open Windows Explorer and locate the file.
2. Right click the file and select Properties.
3. On the General tab, if the file is blocked you will see a message about it being blocked and an option to unblock it. 
![Unblock](unblock.png)
4. Click the option to unblock the file.
