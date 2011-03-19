There will be a customized version of the .NET generic remote server to run the WatinLibrary. The customized version will be compiled with the WatinLibrary class source code file and use reflection to load the class as opposed to using reflection on a dynamically loaded class assembly DLL file to use the class.

So then use of the library with startup parameters will simply be starting the remote server executable with optional parameters for hostname and port bindings. The server will automatically load the WatinLibrary class and its accompanying XML documentation for use with Robot Framework.

The custom server code will go here, but for now, until I've customized the server, you can find the generic version here:

http://code.google.com/p/sharprobotremoteserver/