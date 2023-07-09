Introduction
============
espen is an unofficial open source third-party tool to inspect dialog files as used in Black Geyser: Couriers of Darkness, a cRPG developed by GrapeOcean Technologies and published by V Publishing

Note that espen is currently in an alpha preview, with limited features and support.

Download
========
Compiled downloads are not available during this early development phase.

Compiling
=========
To clone and run this application, you'll need [Git](https://git-scm.com) and [.NET](https://dotnet.microsoft.com/) installed on your computer. From your command line:

```
# Clone this repository
$ git clone https://github.com/btigi/espen

# Go into the repository
$ cd src

# Build  the app
$ dotnet build
```

Usage
=====
espen is a command-line application, and accepts a command line as below:

```espen unpacked_directory filename.dia processor```

Where
 unpacked_directory is the full path to the unpacked content of data.bgd
 filename.dia is the name of a .dia file (assumed to be in /data/dialogs within the unpacked_directory)
 processor is 'console' or 'html'

e.g. 
```espen D:\data\bg Meetings_Alumu_in_GoD.dia html```

Note: Text is read from the /data/languages/en directory within the unpacked_directory.

Note: The html processor outputs a HTML file to the current directory, named after the input dia file, overwriting any existing file.

An example console processor output is available [here](https://htmlpreview.github.io/?https://github.com/btigi/espen/blob/master/resources/sample-output-png.png)
An example html processor output is available [here](https://htmlpreview.github.io/?https://github.com/btigi/espen/blob/master/resources/sample-output-html.html)

Support Disclaimer
==================
espen is currently in an alpha preview, bugs are possible.


Purchasing
==========
Black Geyser: Couriers of Darkness is available purchase on Steam https://store.steampowered.com/app/1374930/ and GOG https://www.gog.com/en/game/black_geyser_couriers_of_darkness
For further information check the official game website https://www.blackgeyser.com/

Licencing
=========
espen is licenced under CC BY-NC-ND 4.0 https://creativecommons.org/licenses/by-nc-nd/4.0/ Full licence details are available in licence.md