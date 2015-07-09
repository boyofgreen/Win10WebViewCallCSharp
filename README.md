# Win10WebViewCallCSharp

##A windows 10 webview calling a C# object through addweballowedobject

In Windows 10, for both a webview and a hosted app, you can add a native component that you call directly from yoru web code.  A few steps are required:

###Step 1
Set up your C# or C++ object as a PCL

###Step 2
Add the "allow for web" meta content to the object like so:

`[Windows.Foundation.Metadata.AllowForWeb]`

###Step 3
Create a JS project with a webview in it
`   <x-ms-webview id="webview"></x-ms-webview>`

###Step 4
Instantiate your native object as a JS object in the app

`	        var communicationWinRT = new CommunicationWinRT.CommunicationWinRT();
`

###Step 5
Use "addWebAllowedObject" to expose and name the objects inside the webveiw
`
	        webview.addWebAllowedObject("jeffRocks", communicationWinRT);
`

###Step 6
Call it from your website, it will now be part of the DOM on page load
`
	if(window.jeffRocks) jeffRocks.toastMessage('Hello World', 0);

