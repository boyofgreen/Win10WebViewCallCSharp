// For an introduction to the Blank template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkId=232509
(function () {
	"use strict";

	var app = WinJS.Application;
	var activation = Windows.ApplicationModel.Activation;

	app.onactivated = function (args) {
	    if (args.detail.kind === activation.ActivationKind.launch) {

	        var webview = document.getElementById('webview');

	        webview.style.height = '100%';
	        webview.style.width = '100%';

	        var communicationWinRT = new CommunicationWinRT.CommunicationWinRT();
	        var cameraWinRT = new CommunicationWinRT.cameraWinRT();
	        webview.addWebAllowedObject("jeffRocks", communicationWinRT);
	       // webview.addWebAllowedObject("jeffRocksCamera", cameraWinRT);
	        webview.navigate("ms-appx-web:///page.html");
	       // webview.navigate("https://testjeff.azurewebsites.net");

		}
	};

	app.oncheckpoint = function (args) {
		// TODO: This application is about to be suspended. Save any state that needs to persist across suspensions here.
		// You might use the WinJS.Application.sessionState object, which is automatically saved and restored across suspension.
		// If you need to complete an asynchronous operation before your application is suspended, call args.setPromise().
	};

	app.start();
})();
