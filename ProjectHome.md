# Overview #

WatinLibrary is a [Robot Framework](http://www.robotframework.org) (remote) test library that uses the popular [WatiN](http://watin.org/) web application testing tool/framework internally. It provides a powerful combination of simple test data syntax and support for multiple browsers, though primarily targeting Internet Explorer.

This library also provides an alternative to the [SeleniumLibrary](http://code.google.com/p/robotframework-seleniumlibrary/) for Robot Framework, for those who prefer or need to use WatiN. In fact, the initial release is targeted for providing as much of a matching set of keywords as what SeleniumLibrary provides so that Robot Framework users can almost seamlessly switch between the two libraries as needed, and not have to learn two different sets of keywords.

# Project Status #

  * Oct 24, 2011 - new job keeping me busy, taking a break, other projects to work on...progress on this project may be delayed for a year. But I'll try to do what I can.

  * March 22, 2011

This library is still under development, and no binary release is available yet. But source code is available for access. ~~A binary release is planned to be out by the end of the year.~~

The plan is to implement the library as a remote library using the [.NET generic remote server](http://code.google.com/p/sharprobotremoteserver/), and customizing it for tighter integration with WatiN, removing need to load the library into the server at runtime, etc.

Alternatively, those interested can port a version of the library to work within [IronPython](http://ironpython.codeplex.com/) instead of as a remote library, for tighter integration with Robot Framework.

The plan is also to build the library as a .NET class library of keywords so that it can be interfaced to IronPython or the remote server easily like a plugin. It would be nice if we could have both an IronPython interface and a .NET remote server interface to WatiN for Robot Framework, both hosted here or one hosted elsewhere.

# Community Support #

If you are a developer (or user) and use or want to use WatiN with Robot Framework, please contribute to this project however you can. I can definitely use testers when the library is available with a binary release.